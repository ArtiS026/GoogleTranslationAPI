using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleTranslationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GoogleTranslationAPI.Repository
{
    public class TranslateRepository : ITranslateRepository
    {
        TranslationDBContext db;//db connectionS

        public TranslateRepository(TranslationDBContext _db)
        {
            db = _db;
        }
        public async Task<List<Translator>> GetTranslator()
        {
            if (db != null)
            {
                return await db.Translator.ToListAsync();
            }

            return null;
        }  


        public async Task<List<LanguageInfo>> Getsource()
        {
            if (db != null)
            {
                return await (from s in db.Source
                              from t in db.Translator
                              where s.TranslatorId == t.Id
                              select new LanguageInfo
                              {
                                  SourceId = s.SourceId,
                                  SourceTxt = s.SourceTxt,
                                  LanguageCode = s.LanguageCode
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<LanguageInfo> Getsource(int? sourceId)
        {
            if (db != null)
            {
                return await (from s in db.Source
                              from t in db.Translator
                              where s.TranslatorId == t.Id
                              select new LanguageInfo
                              {
                                  SourceId = s.SourceId,
                                  SourceTxt = s.SourceTxt,
                                  TranslatorId = s.TranslatorId,
                                  englishname = t.TransText,
                                  LanguageCode = s.LanguageCode
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> AddPhrases(Source source)
        {
            if (db != null)
            {
                await db.Source.AddAsync(source);
                await db.SaveChangesAsync();

                return source.SourceId;
            }

            return 0;
        }

        public async Task<int> DeletePhrases(int? sourceId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the Phrase for specific Phrase id
                var Phrase = await db.Source.FirstOrDefaultAsync(x => x.SourceId == sourceId);

                if (Phrase != null)
                {
                    //Delete that Phrase
                    db.Source.Remove(Phrase);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task UpdatePhrase(Source source)
        {
            if (db != null)
            {
                //Delete that phrases
                db.Source.Update(source);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}

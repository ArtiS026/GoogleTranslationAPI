using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleTranslationAPI.Models;

namespace GoogleTranslationAPI.Repository
{
    public interface ITranslateRepository
    {
        Task<List<Translator>> GetTranslator();

        Task<List<LanguageInfo>> Getsource();

        Task<LanguageInfo> Getsource(int? sourceId);

        Task<int> AddPhrases(Source source);

        Task<int> DeletePhrases(int? sourceId);

       Task UpdatePhrase(Source source);

    }
}

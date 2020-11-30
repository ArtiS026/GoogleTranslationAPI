using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using GoogleTranslationAPI.Models;

namespace GoogleTranslationAPI.Business
{
    public class CultureInfoDetail
    {
        public static List<LanguageInfo> GetCultureInfo()
        { // get culture info data 
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            List<LanguageInfo> languageinfo = new List<LanguageInfo>();
            //to get this to list instead of for 
            foreach (CultureInfo culture in cultures)
            {
                LanguageInfo lst = new LanguageInfo();
                lst.twoletterISOlanguagenamet = culture.TwoLetterISOLanguageName;
                lst.englishname = culture.EnglishName;
                languageinfo.Add(lst);
            }

            return languageinfo;
        }

    }
}

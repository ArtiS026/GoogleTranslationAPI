using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleTranslationAPI.Models
{
    public class LanguageInfo
    {
        public string twoletterISOlanguagenamet { get; set; }
        public string englishname { get; set; }
        public int SourceId { get; set; }
        public string SourceTxt { get; set; }
        public int? TranslatorId { get; set; }
        public string LanguageCode { get; set; }
        public Translator Translator { get; set; }
    }
}

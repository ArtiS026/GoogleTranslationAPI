using System;
using System.Collections.Generic;

namespace GoogleTranslationAPI.Models
{
    public partial class Source
    {
        public int SourceId { get; set; }
        public string SourceTxt { get; set; }
        public int? TranslatorId { get; set; }
        public string LanguageCode { get; set; }

        public Translator Translator { get; set; }
    }
}

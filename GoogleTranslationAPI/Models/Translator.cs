using System;
using System.Collections.Generic;

namespace GoogleTranslationAPI.Models
{
    public partial class Translator
    {
        public Translator()
        {
            Source = new HashSet<Source>();
        }

        public int Id { get; set; }
        public string TransText { get; set; }
        public string LanguageCode { get; set; }

        public ICollection<Source> Source { get; set; }
    }
}

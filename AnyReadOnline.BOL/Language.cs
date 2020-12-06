using AnyReadOnline.BOL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL
{
    public class Language:Audit,ILanguage
    {
        public int LanguageID { get; set; }
        public string LanguageName { get; set; }
       
    }
}

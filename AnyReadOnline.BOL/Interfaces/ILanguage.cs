﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL.Interfaces
{
    public interface ILanguage
    {
        int LanguageID { get; set; }
        string LanguageName { get; set; }
    }
}
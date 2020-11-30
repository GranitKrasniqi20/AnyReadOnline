using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.Models.Interfaces
{
    public interface ILanguage
    {
        string language { get; set; }
        int LanguageID { get; set; }
    }
}
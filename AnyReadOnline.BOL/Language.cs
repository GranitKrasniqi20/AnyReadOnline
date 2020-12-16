using AnyReadOnline.BOL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL
{
    public class Language:Audit
    {
        public int LanguageID { get; set; }

        [Required]
        [StringLength(50)]
        public string LanguageName { get; set; }
       
    }
}

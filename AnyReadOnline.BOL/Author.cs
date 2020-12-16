using AnyReadOnline.BOL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AnyReadOnline.BOL
{
    public class Author : Audit
    {
        public int AuthorID { get; set; }

        [Required]
        [StringLength(50)]
        public string  FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get ; set; }

        [Required]
        public  string ImagePath { get; set; }
    }
}

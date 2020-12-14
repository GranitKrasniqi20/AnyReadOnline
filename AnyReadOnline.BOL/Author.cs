using AnyReadOnline.BOL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AnyReadOnline.BOL
{
    public class Author : Audit
    {
        public int AuthorID { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get ; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}

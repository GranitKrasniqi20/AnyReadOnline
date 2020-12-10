using AnyReadOnline.BOL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL
{
    public class Author : Audit
    {
        public int AuthorID { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get ; set; }
    }
}

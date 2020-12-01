using AnyReadOnline.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyReadOnline.Models
{
    public class Author : Audit, IAuthor
    {
        public int AuthorID { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get ; set; }
    }
}

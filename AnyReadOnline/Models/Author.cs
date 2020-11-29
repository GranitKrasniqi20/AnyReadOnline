using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANYREAD.Models
{
    public class Author : IAuthor
    {
        public int AuthorID { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get ; set; }
    }
}

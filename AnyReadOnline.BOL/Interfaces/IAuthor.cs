using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL.Interfaces
{
    public interface IAuthor
    {
        int AuthorID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
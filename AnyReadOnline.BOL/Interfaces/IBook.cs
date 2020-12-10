using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL.Interfaces
{
    public interface IBook:IMeasure
    {

        IAuthor Author { get; set; }
        int AuthorID { get; set; }
        int BookID { get; set; }
        string ISBN { get; set; }
        ILanguage Language { get; set; }
        int LanguageID { get; set; }
        int PageNumber { get; set; }
        double Price { get; set; }
        IPublishHouse PublishHouse { get; set; }
        int PublishHouseID { get; set; }
        string PublishPlace { get; set; }
        DateTime PublishYear { get; set; }
        int Quantity { get; set; }
        string Title { get; set; }

    }
}
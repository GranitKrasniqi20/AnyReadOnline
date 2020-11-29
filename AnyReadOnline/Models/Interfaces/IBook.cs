using ANYREAD.Models.Interfaces;
using System;

namespace ANYREAD.Models
{

    public interface IBook:IMeasure
    {

        IAuthor Author { get; set; }
        int AuthorID { get; set; }
        int BookID { get; set; }
        string ISBN { get; set; }
        Language Language { get; set; }
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
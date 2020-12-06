using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.BOL
{
    public class Book : Audit , IBook
    {

        public int BookID { get; set; }
        public int LanguageID { get; set; }
        public ILanguage Language { get; set; }
        public int AuthorID { get; set; }
        public IAuthor Author { get; set; }
        public int PublishHouseID { get; set; }
        public IPublishHouse PublishHouse { get; set; }
        public string Title { get; set; }
        public DateTime PublishYear { get; set; }
        public string PublishPlace { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }
        public int PageNumber { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }


        public Book(Language language, IAuthor author, IPublishHouse publishHouse)
        {
            Language = language;
            Author = author;
            PublishHouse = publishHouse;
        }

        public Book(ILanguage language, IAuthor author, IPublishHouse publishHouse)
        {
            Language = language;
            Author = author;
            PublishHouse = publishHouse;
        }
    }
}

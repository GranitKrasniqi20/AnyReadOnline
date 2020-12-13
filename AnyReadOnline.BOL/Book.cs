using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;
using System.ComponentModel;
using System.Web.Mvc;

namespace AnyReadOnline.BOL
{
    public class Book : Audit
    {
        public Book()
        {
            Genre = new Genre();
            Language = new Language();
            PublishHouse = new PublishHouse();
            Author = new Author();
        }

        public int BookID { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public int LanguageID { get; set; }
        public Language Language { get; set; }
        public int PublishHouseID { get; set; }
        public PublishHouse PublishHouse { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishYear { get; set; }
        public string PublishPlace { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }
        public int PageNumber { get; set; }

        [DisplayName("Upload File")]
        public string BookCover { get; set; }

        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
    }
}

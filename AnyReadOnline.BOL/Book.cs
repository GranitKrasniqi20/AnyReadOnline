using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.BOL
{
    public class Book : Audit
    {
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
        public string BookCover { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }


        public Book()
        {
            Genre = new Genre();
            Language = new Language();
            PublishHouse = new PublishHouse();
            Author = new Author();
        }
    }
}

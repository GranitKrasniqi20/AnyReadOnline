using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;
using System.ComponentModel;
using System.Web;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public int GenreID { get; set; }
        public Genre Genre { get; set; }

        [Required]
        public int LanguageID { get; set; }
        public Language Language { get; set; }

        [Required]
        public int PublishHouseID { get; set; }
        public PublishHouse PublishHouse { get; set; }

        [Required]
        public int AuthorID { get; set; }
        public Author Author { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1,2020, ErrorMessage = "The field PublishYear must be between 1 and actual Year.")]
       /* [NumberValidation(ErrorMessage = "The field PublishYear must be between 1 and actual Year.")]*/
        public int PublishYear { get; set; }

        [Required]
        [StringLength(50)]
        public string PublishPlace { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "ISBN should have only 13 digits")]
        public string ISBN { get; set; }

        [Required]
        [Range(1,1000000)]
        public int Quantity { get; set; }
        [Required]
        [Range(1, 100000)]
        public int PageNumber { get; set; }

        public string ImagePath { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "999.99")]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "99.99")]
        public decimal Weight { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "99.99")]
        public decimal Length { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "99.99")]
        public decimal Width { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "99.99")]
        public decimal Height { get; set; }
    }
}

using AnyReadOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANYREAD.Models
{

    public class Factory : Audit
    {

        public static IBook GetBook()
        {
            return new Book(GetLanguage(), GetAuthor(), GetPublishHouse());
        }


        public static Language GetLanguage()
        {
            return new Language();
        }

        public static IGenre GetGenre()
        {
            return new Genre();
        }
        public static IAuthor GetAuthor()
        {
            return new Author();
        }

        public static IPublishHouse GetPublishHouse()
        {
            return new PublishHouse();
        }


    }
}

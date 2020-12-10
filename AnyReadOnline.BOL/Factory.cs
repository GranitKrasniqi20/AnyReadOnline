using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.BOL
{

    public class Factory : Audit
    {
        public static ILanguage GetLanguage()
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

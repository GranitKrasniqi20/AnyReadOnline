using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyReadOnline.BOL;
using AnyReadOnline.BOL.Interfaces;
using AnyReadOnline.DAL;
using System.Web.Mvc;
using System.IO;
using System.Web;

namespace AnyReadOnline.BLL
{
    public class BookBLL : ICrud<Book>
    {
        private readonly BookDAL bookDAL = new BookDAL();

        private readonly AuthorDAL authorDAL = new AuthorDAL();
        private readonly GenreDAL genreDAL = new GenreDAL();
        private readonly PublishHouseDAL publishHouseDAL = new PublishHouseDAL();
        private readonly LanguageDAL languageDAL = new LanguageDAL();

        public int Add(Book obj)
        {
            return bookDAL.Add(obj);
        }

        public int Delete(int id)
        {
            return bookDAL.Delete(id);
        }

        public Book Get(int id)
        {
            return bookDAL.Get(id);
        }

        public List<Book> GetAll()
        {
            return bookDAL.GetAll();
        }

        public int Update(Book obj)
        {
            return bookDAL.Update(obj);
        }

        public void AddForeignKeys(Book book)
        {
            foreach (var item in genreDAL.GetAll())
            {
                if (item.GenreID == book.Genre.GenreID)
                {
                    book.GenreID = item.GenreID;
                    break;
                }
            }

            foreach (var item in languageDAL.GetAll())
            {
                if (item.LanguageID == book.Language.LanguageID)
                {
                    book.LanguageID = item.LanguageID;
                    break;
                }
            }

            foreach (var item in publishHouseDAL.GetAll())
            {
                if (item.PublishHouseID == book.PublishHouse.PublishHouseID)
                {
                    book.PublishHouseID = item.PublishHouseID;
                    break;
                }
            }

            foreach (var item in authorDAL.GetAll())
            {
                if (item.AuthorID == book.Author.AuthorID)
                {
                    book.AuthorID = item.AuthorID;
                    break;
                }
            }
        }

        public  void UpdateForeignKeys(Book GetItem, Book book)
        {
            foreach (var item in genreDAL.GetAll())
            {
                if (item.GenreID == book.Genre.GenreID)
                {
                    GetItem.GenreID = item.GenreID;
                    break;
                }
            }

            foreach (var item in languageDAL.GetAll())
            {
                if (item.LanguageID == book.Language.LanguageID)
                {
                    GetItem.LanguageID = item.LanguageID;
                    break;
                }
            }

            foreach (var item in publishHouseDAL.GetAll())
            {
                if (item.PublishHouseID == book.PublishHouse.PublishHouseID)
                {
                    GetItem.PublishHouseID = item.PublishHouseID;
                    break;
                }
            }

            foreach (var item in authorDAL.GetAll())
            {
                if (item.AuthorID == book.Author.AuthorID)
                {
                    GetItem.AuthorID = item.AuthorID;
                    break;
                }
            }
        }

        public string BookImagePath(Book book)
        {
            string fileName = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
            string extension = Path.GetExtension(book.ImageFile.FileName);
            fileName += DateTime.Now.ToString("yymmssfff") + extension;
            book.ImagePath = "~/Content/img/" + fileName;
            fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/img/"), fileName);
            book.ImageFile.SaveAs(fileName);

            return book.ImagePath;
        }

        public List<Book> GetTop4EarliestBooks()
        {
            return bookDAL.GetTop4EarliestBooks();
        }

        public List<Book> GetTop4LatestBooks()
        {
            return bookDAL.GetTop4LatestBooks();
        }
    }
}

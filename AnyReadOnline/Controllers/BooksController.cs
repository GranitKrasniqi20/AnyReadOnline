using AnyReadOnline.BLL;
using AnyReadOnline.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace AnyReadOnline.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookBLL bookBLL = new BookBLL();
        AuthorBLL authorBLL = new AuthorBLL();
        GenreBLL genreBLL = new GenreBLL();
        PublishHouseBLL publishHouseBLL = new PublishHouseBLL();
        LanguageBLL languageBLL = new LanguageBLL();

        // GET: Books
        public ActionResult Index()
        {
            return View(bookBLL.GetAll());
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            return View(bookBLL.Get(id));
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.Genres = genreBLL.GetAll();
            ViewBag.Languages = languageBLL.GetAll();
            ViewBag.PublishHouses = publishHouseBLL.GetAll();
            ViewBag.Authors = authorBLL.GetAll();

            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                bookBLL.AddForeignKeys(book);

                /*string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
                string extension = Path.GetExtension(image.ImageFile.FileName);
                fileName += DateTime.Now.ToString("yymmssfff") + extension;
                image.ImagePath = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                image.ImageFile.SaveAs(fileName);*/

                if (bookBLL.Add(book) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on CreateBook");
            }
            catch
            {
                return View(book);
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Genres = genreBLL.GetAll();
            ViewBag.Languages = languageBLL.GetAll();
            ViewBag.PublishHouses = publishHouseBLL.GetAll();
            ViewBag.Authors = authorBLL.GetAll();

            return View(bookBLL.Get(id));
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                var GetItem = bookBLL.Get(id);

                bookBLL.UpdateForeignKeys(GetItem, book);

               /* foreach (var item in genreBLL.GetAll())
                {
                    if (item.GenreID == book.Genre.GenreID)
                    {
                        GetItem.GenreID = item.GenreID;
                        break;
                    }
                }

                foreach (var item in languageBLL.GetAll())
                {
                    if (item.LanguageID == book.Language.LanguageID)
                    {
                        GetItem.LanguageID = item.LanguageID;
                        break;
                    }
                }

                foreach (var item in publishHouseBLL.GetAll())
                {
                    if (item.PublishHouseID == book.PublishHouse.PublishHouseID)
                    {
                        GetItem.PublishHouseID = item.PublishHouseID;
                        break;
                    }
                }

                foreach (var item in authorBLL.GetAll())
                {
                    if (item.AuthorID == book.Author.AuthorID)
                    {
                        GetItem.AuthorID = item.AuthorID;
                        break;
                    }
                }*/

                GetItem.Title = book.Title;
                GetItem.Description = book.Description;
                GetItem.PublishYear = book.PublishYear;
                GetItem.PublishPlace = book.PublishPlace;
                GetItem.ISBN = book.ISBN;
                GetItem.Quantity = book.Quantity;
                GetItem.PageNumber = book.PageNumber;
                GetItem.BookCover = book.BookCover;
                GetItem.Price = book.Price;
                GetItem.Weight = book.Weight;
                GetItem.Length = book.Length;
                GetItem.Width = book.Width;
                GetItem.Height = book.Height;

                if (bookBLL.Update(GetItem) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on EditGenre to methods Add()");
            }
            catch
            {
                return View(book);
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View(bookBLL.Get(id));
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Book book)
        {
            try
            {
                // TODO: Add delete logic here

                if (bookBLL.Delete(id) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on DeleteAuthor");
            }
            catch
            {
                return View(book);
            }
        }
    }
}

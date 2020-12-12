using AnyReadOnline.BLL;
using AnyReadOnline.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnyReadOnline.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookBLL bookBLL = new BookBLL();
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
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View(bookBLL.Get(id));
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                // TODO: Add update logic here

                var GetItem = bookBLL.Get(id);

                GetItem.GenreID = book.GenreID;
                GetItem.LanguageID = book.LanguageID;
                GetItem.PublishHouseID = book.PublishHouseID;
                GetItem.AuthorID = book.AuthorID;
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

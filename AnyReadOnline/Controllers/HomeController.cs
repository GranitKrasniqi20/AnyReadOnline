using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnyReadOnline.BOL;
using AnyReadOnline.BLL;

namespace AnyReadOnline.Controllers
{
    public class HomeController : Controller
    {
        BookBLL bookBLL;
        AuthorBLL authorBLL;

        [HttpGet]
        public ActionResult Index()
        {
            bookBLL = new BookBLL();
            authorBLL = new AuthorBLL();
            List<Book> top4EarliestBooks = new List<Book>();
            List<Book> top4LatestBooks = new List<Book>();
            List<Author> top4EarliestAuthors = new List<Author>();


            top4EarliestBooks = bookBLL.GetTop4EarliestBooks();
            top4LatestBooks = bookBLL.GetTop4LatestBooks();
            top4EarliestAuthors = authorBLL.GetTop4EarliestAuthors();

            ViewBag.myEarlyBooks = top4EarliestBooks;
            ViewBag.myLateBooks = top4LatestBooks;
            ViewBag.myEarlyAuthors = top4EarliestAuthors;

            return View();
        }
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Searching(string text)
        {

            List<Book> searchedBooks = new List<Book>();
            bookBLL = new BookBLL();

            searchedBooks = bookBLL.GetTop4EarliestBooks();
            



            return View(searchedBooks.Where(b => b.Genre.GenreName.StartsWith(text) ||
                                            b.Author.FirstName.StartsWith(text) ||
                                            b.Author.LastName.StartsWith(text) ||
                                            b.Title.StartsWith(text) ||
                                            text == null).ToList());
        }
    }
}
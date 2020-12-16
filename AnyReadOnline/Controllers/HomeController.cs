using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnyReadOnline.BOL;
using AnyReadOnline.BLL;
using PagedList.Mvc;
using PagedList;

namespace AnyReadOnline.Controllers
{
    public class HomeController : Controller
    {
        BookBLL bookBLL;
        GenreBLL genreBLL;
        LanguageBLL languageBLL;
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

        public ActionResult Searching(string text, string SortDropdown, int? page)
        {
            



            if (text == null)
            {
                text = "";
            }

            List<Book> searchedBooks = new List<Book>();
            bookBLL = new BookBLL();
            genreBLL = new GenreBLL();
            languageBLL = new LanguageBLL();
            authorBLL = new AuthorBLL();

            ViewBag.myGenres = genreBLL.GetAll();
            ViewBag.myLanguages = languageBLL.GetAll();
            ViewBag.myAuthors = authorBLL.GetAll();

            searchedBooks = bookBLL.GetAll();
            ViewBag.booksCount = searchedBooks.Count();

            
            if (SortDropdown == "Sort by Latest")
            {
                return View(searchedBooks.Where(b => b.Genre.GenreName.StartsWith(text) ||
                                            b.Author.FirstName.StartsWith(text) ||
                                            b.Author.LastName.StartsWith(text) ||
                                            b.Title.StartsWith(text) ||
                                            text == null).ToList().OrderByDescending(b => b.BookID).ToPagedList(page ?? 1, 3));
            }
            else
            {
                //return View(searchedBooks.Where(b => b.Genre.GenreName.StartsWith(text) ||
                //                            b.Author.FirstName.StartsWith(text) ||
                //                            b.Author.LastName.StartsWith(text) ||
                //                            b.Title.StartsWith(text) ||
                //                            text == null).ToList().ToPagedList(page ?? 1, 3));

                return View(searchedBooks.Where(b => b.Genre.GenreName.StartsWith(text) ||
                                            b.Author.FirstName.StartsWith(text) ||
                                            b.Author.LastName.StartsWith(text) ||
                                            b.Title.StartsWith(text) ||
                                            text == null).ToList().OrderByDescending(b => b.BookID).ToPagedList(page ?? 1, 3));
            }
            



        }
    }
}
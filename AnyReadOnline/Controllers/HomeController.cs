using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnyReadOnline.BOL;
using AnyReadOnline.BLL;

namespace AnyReadOnline.Controllers
{
    [AllowAnonymous]
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

            Order order = new Order();
            order.ShippingAddress = new Address();
            order.ShippingAddress.Address1 = "Ejup Gashi 101";
            order.ShippingAddress.City = "Prishtine";
            order.ShippingAddress.Country = new Country();
            order.ShippingAddress.Country.CountryName = "Albania";
            order.ShippingAddress.Country.CountryCode = "AL";
            order.ShippingAddress.PostalCode = "10000";

            order.OrderDetails = new List<OrderDetails>();

            BookBLL BOOK = new BookBLL();
            foreach (var item in BOOK.GetAll())
            {
                order.OrderDetails.Add(new OrderDetails() { Book = item });
            }
            FedExRates.addmore(order);
            
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

            searchedBooks = bookBLL.GetAll();

            return View(searchedBooks.Where(b => b.Genre.GenreName.StartsWith(text) ||
                                            b.Author.FirstName.StartsWith(text) ||
                                            b.Author.LastName.StartsWith(text) ||
                                            b.Title.StartsWith(text) ||
                                            text == null));
        }
    }
}
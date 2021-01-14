using AnyReadOnline.BLL;
using AnyReadOnline.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PagedList.Mvc;
using PagedList;
using AnyReadOnline.Models;

namespace AnyReadOnline.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookBLL bookBLL = new BookBLL();
        private readonly AuthorBLL authorBLL = new AuthorBLL();
        private readonly GenreBLL genreBLL = new GenreBLL();
        private readonly PublishHouseBLL publishHouseBLL = new PublishHouseBLL();
        private readonly LanguageBLL languageBLL = new LanguageBLL();

        // GET: Books
        // [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Index()
        {
            return View(bookBLL.GetAll());
        }

        // GET: Books/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View(bookBLL.Get(id));
        }



       /* [HttpPost]
        [AllowAnonymous]
        public ActionResult Details(int id, int quantity)
        {
            return View(bookBLL.Get(id));
        }*/
        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult Details(int id, int quantity)
        //{
        //    return View(bookBLL.Get(id));
        //}



        // GET: Books/Create
        /*[Authorize(Roles = "SuperAdmin,Admin")]*/
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
        /*[Authorize(Roles = "SuperAdmin,Admin")]*/
        public ActionResult Create(Book book, HttpPostedFileBase imageFile)
        {
            try
            {
                bookBLL.AddDropDownListValues(book);
                book.ImagePath = bookBLL.BookImagePath(book, imageFile);

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
        /*[Authorize(Roles = "SuperAdmin,Admin")]*/
        public ActionResult Edit(int id)
        {
            ViewBag.Genres = genreBLL.GetAll();
            ViewBag.Languages = languageBLL.GetAll();
            ViewBag.PublishHouses = publishHouseBLL.GetAll();
            ViewBag.Authors = authorBLL.GetAll();

            ViewBag.MyGenre = bookBLL.Get(id).GenreID;
            ViewBag.MyPublishHouse = bookBLL.Get(id).PublishHouseID;
            ViewBag.MyLanguage = bookBLL.Get(id).LanguageID;
            ViewBag.MyAuthor = bookBLL.Get(id).AuthorID;

            return View(bookBLL.Get(id));
        }

        // POST: Books/Edit/5
        [HttpPost]
      /*  [Authorize(Roles = "SuperAdmin,Admin")]*/
        public ActionResult Edit(int id, Book book, HttpPostedFileBase imageFile)
        {
            try
            {
                if (bookBLL.Update(bookBLL.UpdateObj(id, book, imageFile)) > 0)
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
        // [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Delete(int id)
        {
            return View(bookBLL.Get(id));
        }

        // POST: Books/Delete/5
        [HttpPost]
        // [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Delete(int id, Book book)
        {
            try
            {
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

        public ActionResult GetBooksByAuthor(int id)
        {
            List<Book> tempBooks = new List<Book>();
            tempBooks = bookBLL.GetAll().Where(b => b.AuthorID == id).ToList();

            ViewBag.SelectedBooks = tempBooks;
            return View(authorBLL.Get(id));
        }

        public ActionResult GetBooksByGenre(int id)
        {
            if (id == null)
            {
                id = 1;
            }
            List<Book> tempBooks = new List<Book>();
            tempBooks = bookBLL.GetAll().Where(b => b.GenreID == id).ToList();

            ViewBag.SelectedBooks = tempBooks;
            return View(genreBLL.Get(id));
        }

        public ActionResult GoToCart()
        {
            if (Session["cart"] == null)
            {
                return View("EmptyCart");
            }
            else
            {
                return View("ShoppingCart");
            }
            
        }

        public ActionResult AddToCart(int id)
        {
            if (Session["cart"] == null)
            {
                List<CartItemModel> cart = new List<CartItemModel>();
                Book cartItem = bookBLL.Get(id);

                cart.Add(new CartItemModel()
                {
                    book = cartItem,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<CartItemModel> cart = (List<CartItemModel>)Session["cart"];
                Book cartItem = bookBLL.Get(id);
                bool foundItem = false;

                foreach (var item in cart)
                {
                    if (cart.Contains(item))
                    {
                        if (item.book.BookID == cartItem.BookID)
                        {
                            item.Quantity++;
                            foundItem = true;
                            break;
                        }
                    }
                    else
                    {
                        foundItem = false;
                    }
                }

                if (!foundItem)
                {
                    cart.Add(new CartItemModel()
                    {
                        book = cartItem,
                        Quantity = 1
                    });
                }
                
                Session["cart"] = cart;
            }
            return View("ShoppingCart");
        }

        public ActionResult RemoveFromCart(int id)
        {
            List<CartItemModel> cart = (List<CartItemModel>)Session["cart"];

            foreach (var item in cart)
            {
                if (item.book.BookID == id)
                {
                    cart.Remove(item);
                    break;
                }
            }

            Session["cart"] = cart;

            return Redirect("~/Home/Index");
        }
    }
}

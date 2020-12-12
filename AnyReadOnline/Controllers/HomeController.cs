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
        Book book = new Book();
        BookBLL bookBLL = new BookBLL();

        public ActionResult Index()
        {
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
            return View();
        }
    }
}
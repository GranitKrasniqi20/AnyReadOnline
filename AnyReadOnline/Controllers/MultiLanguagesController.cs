using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AnyReadOnline.Controllers
{
    public class MultiLanguagesController : Controller
    {
        // GET: MultiLanguages
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Change(string lngName)
        {
            if(lngName != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lngName);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lngName);
            }

            HttpCookie cookie = new HttpCookie("LanguageCookie"); //Language nje emer ku ruhen variablat
            cookie.Value = lngName;
            Response.Cookies.Add(cookie);

            return View("Index");
        }
    }
}
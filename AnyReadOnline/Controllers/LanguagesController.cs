using AnyReadOnline.BLL;
using AnyReadOnline.BOL;
using AnyReadOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnyReadOnline.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly LanguageDAL languageDAL = new LanguageDAL();

        // GET: Languages
        public ActionResult Index()
        {
            return View(languageDAL.GetAll());
        }

        // GET: Languages/Details/5
        public ActionResult Details(int id)
        {
            return View(languageDAL.Get(id));
        }

        // GET: Languages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Languages/Create
        [HttpPost]
        public ActionResult Create(Language language)
        {
            try
            {
                // TODO: Add insert logic here

                if (languageDAL.Add(language) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on CreateLanguge");
            }
            catch
            {
                return View(language);
            }
        }

        // GET: Languages/Edit/5
        public ActionResult Edit(int id)
        {
            return View(languageDAL.Get(id));
        }

        // POST: Languages/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Language language)
        {
            try
            {
                // TODO: Add update logic here

                var GetItem = languageDAL.Get(id);
                GetItem.LanguageName = language.LanguageName;

                if (languageDAL.Update(GetItem) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on EditLanguage to methods Add()");
            }
            catch
            {
                return View(language);
            }
        }

        // GET: Languages/Delete/5
        public ActionResult Delete(int id)
        {
            return View(languageDAL.Delete(id));
        }

        // POST: Languages/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Language language)
        {
            try
            {
                // TODO: Add delete logic here

                if (languageDAL.Delete(id) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on DeleteLangugage");
            }
            catch
            {
                return View(language);
            }
        }
    }
}

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
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class GenresController : Controller
    {
        private readonly GenreBLL genreBLL = new GenreBLL();

        // GET: Genres
        public ActionResult Index()
        {
            return View(genreBLL.GetAll());
        }

        // GET: Genres/Details/5
        public ActionResult Details(int id)
        {
            return View(genreBLL.Get(id));
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            try
            {
                if (genreBLL.Add(genre) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on CreateGenre");
            }
            catch
            {
                return View(genre);
            }
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int id)
        {
            return View(genreBLL.Get(id));
        }

        // POST: Genres/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Genre genre)
        {
            try
            {
                /* var GetItem = genreBLL.Get(id);
                 GetItem.GenreName = genre.GenreName;*/

                if (genreBLL.Update(genreBLL.UpdateObj(id, genre)) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on EditGenre to methods Add()");
            }
            catch
            {
                return View(genre);
            }
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int id)
        {
            return View(genreBLL.Get(id));
        }

        // POST: Genres/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Genre genre)
        {
            try
            {
                // TODO: Add delete logic here

                if (genreBLL.Delete(id) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on DeleteGenre");
            }
            catch
            {
                return View(genre);
            }
        }
    }
}

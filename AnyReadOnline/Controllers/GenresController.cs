using AnyReadOnline.DAL;
using AnyReadOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnyReadOnline.Controllers
{
    public class GenresController : Controller
    {
        readonly GenreDAL genreDAL = new GenreDAL();

        // GET: Genres
        public ActionResult Index()
        {
            return View(genreDAL.GetAll());
        }

        // GET: Genres/Details/5
        public ActionResult Details(int id)
        {
            return View(genreDAL.Get(id));
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
                // TODO: Add insert logic here

                if (genreDAL.Add(genre) > 0)
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
            return View(genreDAL.Get(id));
        }

        // POST: Genres/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Genre genre)
        {
            try
            {
                // TODO: Add update logic here

                var GetItem = genreDAL.Get(id);
                GetItem.GenreName = genre.GenreName;

                if (genreDAL.Update(GetItem) > 0)
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
            return View(genreDAL.Get(id));
        }

        // POST: Genres/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Genre genre)
        {
            try
            {
                // TODO: Add delete logic here

                if (genreDAL.Delete(id) > 0)
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

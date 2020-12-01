using AnyReadOnline.Models;
using AnyReadOnline.DAL;

using System.Web.Mvc;

namespace AnyReadOnline.Controllers
{
    public class GenreController : Controller
    {
        GenreDAL genreDAL = new GenreDAL();
        // GET: Genre
        public ActionResult Index()
        {
            return View(genreDAL.GetAll());
        }

        // GET: Genre/Details/5
        public ActionResult Details(int id)
        {
            return View(genreDAL.GetByID(id));
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View(new Genre());
        }
         
        // POST: Genre/Create
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

        // GET: Genre/Edit/5
        public ActionResult Edit(int id)
        {
            return View(genreDAL.GetByID(id));
        }

        // POST: Genre/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Genre genre)
        {
            try
            {
                // TODO: Add update logic here

                var GetItem = genreDAL.GetByID(id);
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

        // GET: Genre/Delete/5
        public ActionResult Delete(int id)
        {
            return View(genreDAL.GetByID(id));
        }

        // POST: Genre/Delete/5
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

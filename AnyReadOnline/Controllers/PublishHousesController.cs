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
    public class PublishHousesController : Controller
    {
        private readonly PublishHouseBLL publishHouseBLL = new PublishHouseBLL();

        // GET: PublishHouses
        public ActionResult Index()
        {
            return View(publishHouseBLL.GetAll());
        }

        // GET: PublishHouses/Details/5
        public ActionResult Details(int id)
        {
            return View(publishHouseBLL.Get(id));
        }

        // GET: PublishHouses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublishHouses/Create
        [HttpPost]
        public ActionResult Create(PublishHouse publishHouse)
        {
            try
            {
                // TODO: Add insert logic here

                if (publishHouseBLL.Add(publishHouse) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on CreatePublishHouse");
            }
            catch
            {
                return View(publishHouse);
            }
        }

        // GET: PublishHouses/Edit/5
        public ActionResult Edit(int id)
        {
            return View(publishHouseBLL.Get(id));
        }

        // POST: PublishHouses/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PublishHouse publishHouse)
        {
            try
            {
                // TODO: Add update logic here

                var GetItem = publishHouseBLL.Get(id);
                GetItem.PublishHouseName = publishHouse.PublishHouseName;

                if (publishHouseBLL.Update(GetItem) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on EditPublishHouse to methods Add()");
            }
            catch
            {
                return View(publishHouse);
            }
        }

        // GET: PublishHouses/Delete/5
        public ActionResult Delete(int id)
        {
            return View(publishHouseBLL.Delete(id));
        }

        // POST: PublishHouses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PublishHouse publishHouse)
        {
            try
            {
                // TODO: Add delete logic here

                if (publishHouseBLL.Delete(id) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on DeleteLangugage");
            }
            catch
            {
                return View(publishHouse);
            }
        }
    }
}

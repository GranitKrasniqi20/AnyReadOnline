using AnyReadOnline.BLL;
using AnyReadOnline.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnyReadOnline.Controllers
{
    public class AddressesController : Controller
    {
        private AddressBLL addressBLL = new AddressBLL();

        private CountryBLL countryBLL=new CountryBLL();

        // GET: Addresses
        public ActionResult Index()
        {
            return View(addressBLL.GetAll());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            ViewBag.Countries = countryBLL.GetAll();
            //Address address = new Address();

            return View();
        }

        // POST: Addresses/Create
        [HttpPost]
        public ActionResult Create(Address address)
        {
            ViewBag.Countries = countryBLL.GetAll();
            try
            {
                foreach (var item in countryBLL.GetAll())
                {
                    if (item.CountryID == address.Country.CountryID)
                    {
                        address.CountryID = item.CountryID;
                        break;
                    }
                }

                if (addressBLL.Add(address) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error while Creating Address!");
            }
            /*return View(address);*/
            catch
            {
                return View();
            }
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Addresses/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Addresses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

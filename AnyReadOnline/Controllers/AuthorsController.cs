﻿using AnyReadOnline.BLL;
using AnyReadOnline.BOL;
using AnyReadOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnyReadOnline.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AuthorBLL authorBLL = new AuthorBLL();

        // GET: Authors
        public ActionResult Index()
        {
            return View(authorBLL.GetAll());
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            return View(authorBLL.Get(id));
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        public ActionResult Create(Author author)
        {
            try
            {
                // TODO: Add insert logic here

                if (authorBLL.Add(author) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on CreateAuthor");
            }
            catch
            {
                return View(author);
            }
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int id)
        {
            return View(authorBLL.Get(id));
        }

        // POST: Authors/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Author author)
        {
            try
            {
                // TODO: Add update logic here

                var GetItem = authorBLL.Get(id);
                GetItem.FirstName = author.FirstName;
                GetItem.LastName = author.LastName;

                if (authorBLL.Update(GetItem) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on EditAuthor to methods Add()");
            }
            catch
            {
                return View(author);
            }
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            return View(authorBLL.Delete(id));
        }

        // POST: Authors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Author author)
        {
            try
            {
                // TODO: Add delete logic here

                if (authorBLL.Delete(id) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error on DeleteAuthor");
            }
            catch
            {
                return View(author);
            }
        }
    }
}
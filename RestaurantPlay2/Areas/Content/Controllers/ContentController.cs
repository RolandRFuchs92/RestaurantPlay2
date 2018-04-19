using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantPlay2.Areas.Content.ViewModels;
using DataAccess.Content;

namespace RestaurantPlay2.Areas.Content
{
    public class ContentController : Controller
    {
        // GET: Content/Content
        public ActionResult Index()
        {
            var imageCardList = new DataAccess.Content.ContentRepo().GetCoreContents();

            return View(imageCardList);
        }

        // GET: Content/Content/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Content/Content/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Content/Content/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Content/Content/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Content/Content/Edit/5
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

        // GET: Content/Content/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Content/Content/Delete/5
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

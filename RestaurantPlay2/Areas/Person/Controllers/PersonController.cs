using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using RestaurantPlay2.Areas.Person.ViewModels;
using RestaurantPlay2.Context;
using RestaurantPlay2.Entities.Person;

namespace RestaurantPlay2.Areas.Person.Controllers
{
    public class PersonController : Controller
    {

        // GET: Person/Person
        public ActionResult Index()
        {
            var personList = new PersonDisplayViewModel();
            personList.PersonName = "Samuel L Jackson";

            using (var db = new AppsContext())
            {
                personList.Persons = (from person in db.Persons
                    select person).ToList();
            }
            return View("Index", personList);
        }

        // GET: Person/Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Person/Create
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

        // GET: Person/Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Person/Edit/5
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

        // GET: Person/Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Person/Delete/5
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

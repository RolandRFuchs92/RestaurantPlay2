using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess.Context;
using DataAccess.Entities;

namespace RestaurantPlay2.Areas.ContactForm.Controllers
{
    public class EnquiryController : Controller
    {
        private AppsContext db = new AppsContext();

        // GET: ContactForm/Enquiry
        public ActionResult Index()
        {
            return View(db.EnquiryFormSubs.ToList());
        }

        // GET: ContactForm/Enquiry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryFormSubs enquiryFormSubs = db.EnquiryFormSubs.Find(id);
            if (enquiryFormSubs == null)
            {
                return HttpNotFound();
            }
            return View(enquiryFormSubs);
        }

        // GET: ContactForm/Enquiry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactForm/Enquiry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnquiryId,Name,PhoneNumber,EmailAddress,FormMessage,Comments")] EnquiryFormSubs enquiryFormSubs)
        {
            if (ModelState.IsValid)
            {
                db.EnquiryFormSubs.Add(enquiryFormSubs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enquiryFormSubs);
        }

        // GET: ContactForm/Enquiry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryFormSubs enquiryFormSubs = db.EnquiryFormSubs.Find(id);
            if (enquiryFormSubs == null)
            {
                return HttpNotFound();
            }
            return View(enquiryFormSubs);
        }

        // POST: ContactForm/Enquiry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnquiryId,Name,PhoneNumber,EmailAddress,FormMessage,Comments")] EnquiryFormSubs enquiryFormSubs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enquiryFormSubs).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enquiryFormSubs);
        }

        // GET: ContactForm/Enquiry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryFormSubs enquiryFormSubs = db.EnquiryFormSubs.Find(id);
            if (enquiryFormSubs == null)
            {
                return HttpNotFound();
            }
            return View(enquiryFormSubs);
        }

        // POST: ContactForm/Enquiry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnquiryFormSubs enquiryFormSubs = db.EnquiryFormSubs.Find(id);
            db.EnquiryFormSubs.Remove(enquiryFormSubs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using DataAccess.Context;
using DataAccess.Entities;

namespace RestaurantPlay2.Areas.ContactForm.Controllers
{
    public class ContactController : Controller
    {
        private AppsContext db = new AppsContext();

        // GET: ContactForm/Contact
        public ActionResult Index()
        {
            return View(db.EnquiryFormSubs.ToList());
        }

        // GET: ContactForm/Contact/Details/5
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

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Name,PhoneNumber,EmailAddress,FormMessage,Comments")] EnquiryFormSubs enquiryFormSubs)
        {

            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                WebMail.UserName = "xienaudh@gmail.com";
                WebMail.Password = "xienleonaudh";

                //Sender email address.  
                WebMail.From = "SenderGamilId@gmail.com";
                //Send email  
                enquiryFormSubs.FormMessage = @"
                    <img src='http://www-www.co.za/X-Crazy-Dv.png' width='80px' height='50px'>
                    <div> " +
                    "<h1> Good Day " + enquiryFormSubs.Name + "</h1>" +
                    "<p>We have recieved your request:</p>" +
                    "" +
                    "<p><b>Message: </b></p>" + enquiryFormSubs.FormMessage +
                    "<p><b>Your contactable number is:</b>" + enquiryFormSubs.PhoneNumber +
                    "</p>" +
                    "" +
                    "<p>Please use This refrence Number when having any issues: <b>" +
                    "</b><p>" +
                    "" +
                    "<p>If you would like to change any details or enquire about something plesse do not heitate to contact us:" +
                    "</p>" +
                    "" +
                    "<a href='mailto:info@www-www.co.za?subject=Web Enquiry'>Email Us Today</a>" +
                    "</div>";

                WebMail.Send(to: enquiryFormSubs.EmailAddress, subject:"Client", body: enquiryFormSubs.FormMessage, cc: "", bcc: "xienaudh@gmail.com", isBodyHtml: true);
                ViewBag.Status = "Email Sent Successfully.";
                if (ModelState.IsValid)
                {
                    db.EnquiryFormSubs.Add(enquiryFormSubs);
                    db.SaveChanges();
                    return RedirectToAction("Success");
                }
            }
            catch (Exception)
            {
                ViewBag.Status = "Problem while sending email, Please check details.";

            }

            return View(enquiryFormSubs);
        }
        public ActionResult Success()
        {
            return View();
        }

        // GET: ContactForm/Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactForm/Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PhoneNumber,EmailAddress,FormMessage,Comments")] EnquiryFormSubs enquiryFormSubs)
        {
            if (ModelState.IsValid)
            {
                db.EnquiryFormSubs.Add(enquiryFormSubs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enquiryFormSubs);
        }

        // GET: ContactForm/Contact/Edit/5
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

        // POST: ContactForm/Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PhoneNumber,EmailAddress,FormMessage,Comments")] EnquiryFormSubs enquiryFormSubs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enquiryFormSubs).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enquiryFormSubs);
        }

        // GET: ContactForm/Contact/Delete/5
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

        // POST: ContactForm/Contact/Delete/5
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

        private string response;
        private string api;
        Dictionary<string, string> Params = new Dictionary<string, string>();

        response = Api.SendSMS(api, Params);
    }
}

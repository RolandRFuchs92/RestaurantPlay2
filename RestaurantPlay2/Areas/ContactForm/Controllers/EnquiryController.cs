﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
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
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "EnquiryId,Name,PhoneNumber,EmailAddress,FormMessage,Comments")] EnquiryFormSubs enquiryFormSubs)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    //Configuring webMail class to send emails  
                    //gmail smtp server , This is the fastest, I tried using my own Domain SMPT Provider, Rather Use GMail to handle emails from your custom mail.
                    WebMail.SmtpServer = "smtp.gmail.com";
                    //gmail port to send emails  
                    WebMail.SmtpPort = 587;
                    WebMail.SmtpUseDefaultCredentials = true;
                    //sending emails with secure protocol  
                    WebMail.EnableSsl = true;
                    //EmailId used to send emails from application  
                    WebMail.UserName = "thecrazydeveloperemail@gmail.com";
                    WebMail.Password = "LoremIpsum01!";
                    //Sender email address.  Should be the same as the one listed on Gmail as the alias.
                    WebMail.From = "infoemail@www-www.co.za";
                    //Send email:  
                    enquiryFormSubs.FormMessage = @"
                    <img src='http://www.www-www.co.za/CCRTestLogo.png' width='100px' height='100px'>
                    <div> " +
                        "<h1> Good Day " + enquiryFormSubs.Name + "</h1>" +
                        "<p>We have recieved your request:</p>" +
                        "" +
                        "<p><b>Message: </b></p>" + enquiryFormSubs.FormMessage +
                        "<p><b>Your contactable number is: </b>" + enquiryFormSubs.PhoneNumber +
                        "</p>" +
                        "" +
                        "<p>Please use This refrence Number when having any issues: <b>" +
                        "</b><p>" +
                        "" +
                        "<p>If you would like to change any details or enquire about something plesse do not heitate to contact us:" +
                        "</p>" +
                        "" +
                        "<a href='mailto:infoemail@www-www.co.za?subject=Web Enquiry'>Email Us Today</a>" +
                        "</div>";

                    WebMail.Send(to: enquiryFormSubs.EmailAddress, subject: "Cascata Country Restaurant Web Enquiry", body: enquiryFormSubs.FormMessage, cc: "", bcc: "xienaudh@gmail.com", isBodyHtml: true);

                    db.EnquiryFormSubs.Add(enquiryFormSubs);
                    db.SaveChanges();

                    //Sending SMS After Save To DB, to get enquiry Number to get direct link to the enquiry.
                    string html = string.Empty;
                    string url = @"https://platform.clickatell.com/messages/http/send?apiKey=FukUwrKiTDmf9rxeRzIciQ==&to=27837074655&content=Please+see+new+enquiry+Link:" + " www.DomainName.co.za/ContactForm/Enquiry/Details/" + enquiryFormSubs.EnquiryId;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.AutomaticDecompression = DecompressionMethods.GZip;

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }
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
        [ValidateInput(false)]
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

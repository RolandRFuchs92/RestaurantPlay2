using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ContactForm
{

    public class GetContactFormRepo : IContactFormRepo
    {
        
        public GetContactFormRepo(GetContactFormRepo context)
        {
            var db = new AppsContext();
        }

        public GetContactFormRepo()
        {
            var db = new AppsContext();
        }

        public List<EnquiryFormSubs> GetContactFormModelModels()
        {
            var db = new AppsContext();
           
            return db.EnquiryFormSubs.ToList();
        }


        public EnquiryFormSubs GetEnquiryFormById(int id)
        {
            var db = new AppsContext();
            return db.EnquiryFormSubs.Find(id);
        }

        public void InsertEnquiryFormSubs(EnquiryFormSubs enquiryFormSubs)
        {
            var db = new AppsContext();
            db.EnquiryFormSubs.Add(enquiryFormSubs);
        }

        public void DeleteEnquiryFormSubs(int id)
        {
            var db = new AppsContext();
            EnquiryFormSubs enquiryFormSubs = db.EnquiryFormSubs.Find(id);
            db.EnquiryFormSubs.Remove(enquiryFormSubs);
        }

        public void UpdateEnquiryFormSubs(EnquiryFormSubs enquiryFormSubs)
        {
            var db = new AppsContext();
            db.Entry(enquiryFormSubs).State = EntityState.Modified;
        }

        public void Save()
        {
            var db = new AppsContext();
            db.SaveChanges();
        }

       
    }
}

using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ContactForm
{
    public interface IContactFormRepo
    {
        List<EnquiryFormSubs> GetContactFormModelModels();
        EnquiryFormSubs GetEnquiryFormById(int id);
        void InsertEnquiryFormSubs(EnquiryFormSubs enquiryFormSubs);
        void DeleteEnquiryFormSubs(int id);
        void UpdateEnquiryFormSubs(EnquiryFormSubs enquiryFormSubs);
        void Save();
    }

}

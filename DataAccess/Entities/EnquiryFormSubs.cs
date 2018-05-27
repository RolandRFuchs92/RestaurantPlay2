using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class EnquiryFormSubs
    {
        [Key]
        public int EnquiryId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FormMessage { get; set; }
        public string Comments { get; set; }
    }
}

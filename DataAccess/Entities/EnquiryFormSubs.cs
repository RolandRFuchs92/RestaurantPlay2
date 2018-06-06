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
        [Required]
        public int EnquiryId { get; set; }

        [Display(Name = "Your Name")]
        [Required]
        public string Name { get; set; }

        
        [Display(Name = "Your Contact Number")]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "Your Email Address :")]
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Display(Name = "How can we assist? :")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string FormMessage { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.ContactForm.ViewModels
{
    public class ContactFormViewModel
    {
        [Key]
        public int EnquriyId { get; set; }

        [Display(Name="Your Name")]
        [Required]
        public string Name { get; set; }

        [Phone]
        [Display(Name = "Your Contact Number")]
        public int PhoneNumber { get; set; }

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
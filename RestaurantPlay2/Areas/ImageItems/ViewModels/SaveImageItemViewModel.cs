using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.ImageItems.ViewModels
{
    public class SaveImageItemViewModel
    {
        public int imageID { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Title")]
        public string DetailTitle { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Sub Title")]
        public string DetailSubTitle { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Image { get; set; }
        [Required]
        [MaxLength(2000)]
        [Display(Name = "Paragraph")]
        public string DetailParagraph { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
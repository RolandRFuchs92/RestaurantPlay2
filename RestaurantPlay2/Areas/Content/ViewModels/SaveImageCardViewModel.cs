using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.Content.ViewModels
{
    public class SaveImageCardViewModel
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Title")]
        public string DetailTitle { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name="Sub Title")]
        public string DetailSubTitle { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        [MaxLength(2000)]
        [Display(Name = "Paragraph")]
        public string DetailParagraph { get; set; }
    }
}
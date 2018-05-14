using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.ImageItems.Interfaces
{
    public interface ISaveImageItem
    {
        int imageID { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Title")]
        string DetailTitle { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Sub Title")]
        string DetailSubTitle { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        string ImageBase { get; set; }
        string ImageName { get; set; }
        [Display(Name = "Is Active")]
        bool IsActive { get; set; }
    }
}
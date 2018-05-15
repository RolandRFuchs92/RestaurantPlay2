using RestaurantPlay2.Areas.ImageItems.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace RestaurantPlay2.Areas.ImageItems.ViewModels.ImageCarousel
{
    public class SaveCarouselViewModel : ISaveImageItem
    {
        public int imageID { get; set; } = 0;
        [Required]
        [MaxLength(100)]
        [Display(Name = "Title")]
        public string DetailTitle { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name="Sub Title")]
        public string DetailSubTitle { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        public string ImageBase { get; set; }
        public string ImageName { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = false;
    }
}
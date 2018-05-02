using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.ImageItems.ViewModels.ImageCarousel
{
    public class EditCarouselViewModel
    {
        public SaveCarouselViewModel SaveCarouselItem { get; set; }
        public List<ImageItemViewModel> CarouselItems { get; set; }
    }
}
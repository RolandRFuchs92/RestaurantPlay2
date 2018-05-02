using RestaurantPlay2.Areas.ImageItems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.ImageItems.ViewModels.ImageCarousel
{
    public class CarouselItemViewModel : IImageItem
    {
        public int ImageId { get; set; }
        public string DetailTitle { get; set; }
        public string DetailSubTitle { get; set; }
        public string DetailImagePath { get; set; }
        public bool DetailIsActive { get; set; }
        public DateTime DetailDateCreated { get; set; }
    }
}
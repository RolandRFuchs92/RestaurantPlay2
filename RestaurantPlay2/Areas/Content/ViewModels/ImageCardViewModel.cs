using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.Content.ViewModels
{
    public class ImageCardViewModel
    {
        public int BLOGDetailID { get; set; }
        public string DetailTitle { get; set; }
        public string DetailSubTitle { get; set; }
        public string DetailImagePath { get; set; }
        public string DetailsImageAltTag { get; set; }
        public string DetailsParagraph { get; set; }
    }
}
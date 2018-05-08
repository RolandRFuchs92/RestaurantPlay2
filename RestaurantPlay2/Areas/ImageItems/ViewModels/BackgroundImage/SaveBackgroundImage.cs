using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.ImageItems.ViewModels.BackgroundImage
{
    public class SaveBackgroundImage
    {
        public HttpFileCollectionBase image { get; set; }
        public int priority { get; set; }
    }
}
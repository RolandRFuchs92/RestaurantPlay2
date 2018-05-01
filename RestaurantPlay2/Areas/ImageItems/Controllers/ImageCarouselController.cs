using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Context;
using DataAccess.ImageItem;
using RestaurantPlay2.Areas.ImageItems.BusinessLogic.ImageCarousel;

namespace RestaurantPlay2.Areas.ImageItems.Controllers
{
    public class ImageCarouselController : Controller
    {
        // GET: ImageItems/ImageCarousel
        public ActionResult Index()
        {
            return View(new ImageCarousel().LoadAllImageItems());
        }

        public ActionResult DisplayCarousel()
        {
            var carouselItems = new ImageCarousel().LoadValidImageItems();
            return View("_CarouselDisplay", carouselItems);
        }

        public ActionResult SaveCarousel()
        {
            return View("_CarouselForm");
        }

    }
}
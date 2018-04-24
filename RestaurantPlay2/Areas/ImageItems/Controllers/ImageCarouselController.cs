using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantPlay2.Areas.ImageItems.Controllers
{
    public class ImageCarouselController : Controller
    {
        // GET: ImageItems/ImageCarousel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayCarousel()
        {
            return View("_CarouselDisplay");
        }

        public ActionResult SaveCarousel()
        {
            return View("_CarouselForm");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Context;
using DataAccess.ImageItem;

namespace RestaurantPlay2.Areas.ImageItems.Controllers
{
    public class ImageCarouselController : Controller
    {
        // GET: ImageItems/ImageCarousel
        public ActionResult Index()
        {
            var img = new ImageItemRepo(2).GetValidImageItems();
            return View(img);
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
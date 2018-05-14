using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Context;
using DataAccess.ImageItem;
using RestaurantPlay2.Areas.ImageItems.BusinessLogic.ImageCarousel;
using RestaurantPlay2.Areas.ImageItems.ViewModels.ImageCarousel;
using System.Net;

namespace RestaurantPlay2.Areas.ImageItems.Controllers
{
    [Authorize]
    public class ImageCarouselController : Controller
    {
        // GET: ImageItems/ImageCarousel
        public ActionResult Index()
        {
            var model = new ImageCarouselLogic().LoadCarouselViewModel();

            return View(model);
        }

        public ActionResult DisplayCarousel()
        {
            var carouselItems = new ImageCarouselLogic().LoadValidImageItems();
            return View("_CarouselDisplay", carouselItems);
        }

        public ActionResult DisplayCarouselStrip()
        {
            var model = new ImageCarouselLogic().LoadAllImageItems();
            return View("_CarouselStrip",model);
        }

        public ActionResult DeleteCarouselItem(int imageId)
        {
            if(!new ImageCarouselLogic().DeleteImageItem(imageId))
                ModelState.AddModelError("Image", "Image not found or matched");

            var model = new ImageCarouselLogic().LoadCarouselViewModel();
            //Rather just reload the cards and the carousel instead of the whole form... but this will work
            return View("Index", model);
        }

        public JsonResult EditCarouselItem(int imageId)
        {
            var model = new ImageCarouselLogic().LoadImageItemById(imageId);
            return Json(model);
        }

        public ActionResult SaveCarousel(SaveCarouselViewModel carouselImage)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            new ImageCarouselLogic().SaveImageItem(carouselImage);

            var model = new ImageCarouselLogic().LoadCarouselViewModel();
            ModelState.Clear();

            return View("~/Areas/ImageItems/Views/ImageCarousel/Index.cshtml", model);
        }
    }
}
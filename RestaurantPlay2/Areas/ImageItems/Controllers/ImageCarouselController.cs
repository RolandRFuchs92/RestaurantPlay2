using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Context;
using DataAccess.ImageItem;
using RestaurantPlay2.Areas.ImageItems.BusinessLogic.ImageCarousel;
using RestaurantPlay2.Areas.ImageItems.ViewModels.ImageCarousel;

namespace RestaurantPlay2.Areas.ImageItems.Controllers
{
    public class ImageCarouselController : Controller
    {
        // GET: ImageItems/ImageCarousel
        public ActionResult Index()
        {
            var carouselModel = new EditCarouselViewModel();
            carouselModel.CarouselItems = new ImageCarousel().LoadAllImageItems();
            carouselModel.SaveCarouselItem = new SaveCarouselViewModel();

            return View(carouselModel);
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
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
            var carouselModel = new EditCarouselViewModel();
            carouselModel.CarouselItems = new ImageCarouselLogic().LoadAllImageItems();
            carouselModel.SaveCarouselItem = new SaveCarouselViewModel();

            return View(carouselModel);
        }

        public ActionResult DisplayCarousel()
        {
            var carouselItems = new ImageCarouselLogic().LoadValidImageItems();
            return View("_CarouselDisplay", carouselItems);
        }

        public ActionResult SaveCarousel(SaveCarouselViewModel carouselImage)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            new ImageCarouselLogic().SaveImageItem(carouselImage);

            var model = new ImageCarouselLogic().LoadAllImageItems();
            ModelState.Clear();

            return View("_CarouselDisplay", model);
        }
    }
}
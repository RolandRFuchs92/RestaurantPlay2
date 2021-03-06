﻿using System.Net;
using System.Web.Mvc;
using DataAccess.ImageItem;
using RestaurantPlay2.Areas.ImageItems.BusinessLogic.ImageCards;
using RestaurantPlay2.Areas.ImageItems.ViewModels;
using RestaurantPlay2.Areas.ImageItems.ViewModels.ImageCard;

namespace RestaurantPlay2.Areas.ImageItems.Controllers
{
    [Authorize]
    public class ImageCardController : Controller
    {
        // GET: Content/Content
        public ActionResult Index()
        {
            var model = new ImageCardLogic().LoadImageCardViewModels();

            return View(model);
        }

        public ActionResult SaveImageCard(SaveImageCardViewModel imageCard)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            new ImageCardLogic().SaveImageCard(imageCard);

            var model = new ImageCardLogic().LoadImageCardViewModels();
            ModelState.Clear();

            Response.StatusCode = 200;
            return PartialView("~/Areas/ImageItems/Views/ImageCard/Presets/_GenerateImageCards.cshtml", model);
        }

        public JsonResult EditImageCard(int imageID)
        {
            var model = new ImageCardLogic().LoadImageCardByImageID(imageID);
            return Json(model);
        }

        public ActionResult DeleteImageCard(int imageID)
        {
            var isDeleted = new ImageItemRepo().DeleteImageItem(imageID);
            if (!isDeleted)
                ModelState.AddModelError("Image", "Image not found or matched");

            var model = new ImageCardLogic().LoadImageCardViewModels();
            return View("Index", model);
        }

        [ChildActionOnly]
        public ActionResult GetImageCards()
        {
            var model = new ImageCardLogic().LoadValidImageCardViewModels();

            return PartialView("Presets/_GenerateImageCards", model);
        }
    }
}

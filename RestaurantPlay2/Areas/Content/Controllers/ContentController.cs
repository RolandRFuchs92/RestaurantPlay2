﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RestaurantPlay2.Areas.Content.ViewModels;
using DataAccess.Content;
using DataAccess.ImageCard;
using RestaurantPlay2.Areas.Content.BusinessLogic.ImageCards;

namespace RestaurantPlay2.Areas.Content
{
    public class ContentController : Controller
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
            return View("Index", model);
        }

        public JsonResult EditImageCard(int imageID)
        {
            var model = new ImageCardLogic().LoadImageCardByImageID(imageID);
            return Json(model);
        }

        public ActionResult DeleteImageCard(int imageID)
        {
            var isDeleted = new ImageCardRepo().DeleteImageCard(imageID);
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

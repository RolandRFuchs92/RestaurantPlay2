using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantPlay2.Areas.Content.ViewModels;
using DataAccess.Content;
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
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var isSaved = new ImageCardLogic().SaveImageCard(imageCard);
            

            return View("Index");
        }
    }
}

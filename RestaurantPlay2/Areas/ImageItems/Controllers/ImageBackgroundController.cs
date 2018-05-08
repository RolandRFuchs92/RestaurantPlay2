using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantPlay2.Areas.ImageItems.Controllers
{
    public class ImageBackgroundController : Controller
    {
        private readonly int _imageTypeID = 3;
        public ActionResult Index()
        {
            return View();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantPlay2.Areas.Blogger.Controllers
{
    public class BloggerController : Controller
    {
        // GET: Blogger/Blogger
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BloggerForm()
        {
            return PartialView("_BloggerForm");
        }

        public ActionResult LatestBlog()
        {
            return PartialView("_BlogTile");
        }
    }
}

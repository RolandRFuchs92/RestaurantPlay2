﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.WebPages;
using RestaurantPlay2.Areas.Blogger.BusinessLogic;
using RestaurantPlay2.Areas.Blogger.ViewModels;
using RestaurantPlay2.Areas.ImageItems.BusinessLogic.Misc;

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

				public ActionResult SaveBlog(BloggerFormViewModel model)
				{
						if (!ModelState.IsValid)
								return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "The data submitted was invalid, please try again!");

						var imagePath = new ImageUtils().SaveImageFile(model.ImageBase, model.ImageName);
						
						if (imagePath.IsEmpty())
								return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "We were unable to save your file. Please try again.");

						model.ImageBase = imagePath;
						var savedBlogMessage = new BloggerLogic().SaveNewBlog(model);

						return Json(new { message= savedBlogMessage });
				}
		}
}

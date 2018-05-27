using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.WebPages;
using DataAccess;
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
						return PartialView("_BlogTile", new BloggerViewModel());
				}

				/// <summary>
				/// Get an editor related to the refered blogId
				/// </summary>
				/// <param name="blogId">BlogDetailId</param>
				/// <returns></returns>
				public ActionResult EditBlog(int blogId)
				{
						var model = new EditBloggerViewModel();

						if (blogId != 0)
								model = new BloggerLogic().EditBloggerViewModel(blogId);

						return View("_BloggerEditor", model);
				}

				/// <summary>
				/// Save the blog using the form viewmodel. Image is passed in as a base64 encoded string. 
				/// </summary>
				/// <param name="model"></param>
				/// <returns></returns>
				public ActionResult SaveBlog(BloggerFormViewModel model)
				{
						if (!ModelState.IsValid)
								return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "The data submitted was invalid, please try again!");

						var imagePath = new ImageUtils().SaveImageFile(model.ImageBase, model.ImageName);

						if (imagePath.IsEmpty())
								return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "We were unable to save your file. Please try again.");

						model.ImageBase = imagePath;
						var savedBlogMessage = new BloggerLogic().SaveNewBlog(model);

						return Json(new { message = savedBlogMessage });
				}

				/// <summary>
				/// Display only the blog on a page according to the blog Id
				/// </summary>
				/// <param name="blogId">BlogDetailId</param>
				/// <returns></returns>
				public ActionResult Blog(int blogId)
				{
						var model = new BloggerLogic().GetBlogById(blogId);

						return PartialView("_BlogTile", model);
				}

				/// <summary>
				/// Return a view with all valid blogs. 
				/// </summary>
				/// <returns></returns>
				public ActionResult GetBlogSnippets()
				{
						var blogs = new BloggerLogic().GetBloggerSnippetsViewModel();

						return PartialView("_bloggerSnippets", blogs);
				}
		}
}

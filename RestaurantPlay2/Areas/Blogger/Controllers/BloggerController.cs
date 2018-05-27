using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.WebPages;
using DataAccess;
using Microsoft.Owin.Security.Provider;
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

				/// <summary>
				/// Get the latest Blog based on the Blog logic.
				/// </summary>
				/// <returns></returns>
				public ActionResult LatestBlog()
				{
						var model = new BloggerLogic().GetLatestBlog();
						return PartialView("_BlogTile", model);
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

						return PartialView("_BloggerEditor", model);
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
						var saveBlog = new BloggerLogic().SaveNewBlog(model);

						Response.StatusCode = (int)HttpStatusCode.OK;
						return Json(saveBlog);
				}

				/// <summary>
				/// Delete the users blog based in the.
				/// </summary>
				/// <param name="blogId"></param>
				/// <returns></returns>
				public ActionResult DeleteBlog(int blogId)
				{
						if (!new BloggerLogic().DeleteBlogById(blogId))
						{
								Response.StatusCode = (int)HttpStatusCode.InternalServerError;
								return Json(new { message = "Oops, There seems to have been an error deleteing this blog! Please try again?" });
						}

						Response.StatusCode = (int)HttpStatusCode.OK;
						return Json(new
						{
								message = "Your blog was successfully deleted!",
						});
				}

				/// <summary>
				/// Display only the blog on a page according to the blog Id
				/// </summary>
				/// <param name="blogId">BlogDetailId</param>
				/// <returns></returns>
				public ActionResult Blog(int blogId)
				{
						var model = new BloggerLogic().GetBlogById(blogId);
						ViewData["SingleBlog"] = true;

						return View("_BlogTile", model);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using DataAccess.Entities;
using RestaurantPlay2.Areas.Blogger.ViewModels;
using RestaurantPlay2.Entities.Blog;

namespace RestaurantPlay2.Areas.Blogger.BusinessLogic
{
		public class BloggerLogic
		{
				public string SaveNewBlog(BloggerFormViewModel model)
				{
						var blogModel = new BlogDetail
						{
								BlogDetailId = model.BlogId,
								BlogStartingDate = model.StartingDate,
								BlogAuthor = model.Author,
								BlogBody = model.Body,
								BlogClosingCaption = model.ClosingCaption,
								BlogImagePath = model.ImageBase,
								BlogIntro = model.Intro,
								BlogRemarks = model.Remarks,
								BlogTitle = model.Title,
								BlogWritenOn = model.WritenOn,
						};

						var result = new BloggerRepo().SaveBlog(blogModel) ? "Successfully saved your blog!" : "An error occured while saving your blog.";

						return result;
				}
		}
}
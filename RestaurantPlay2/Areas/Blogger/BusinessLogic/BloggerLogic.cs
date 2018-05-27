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
				/// <summary>
				/// Save the blog afte rthe image has been saved, and use the returned path to save the blog correctly.
				/// </summary>
				/// <param name="model">Form Viewmodel will be translated into a blogDetail.</param>
				/// <returns></returns>
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

				/// <summary>
				/// Get the lates BlogViewModel. 
				/// The blog must be valid, not flagged as deleted, and the starting date must be greater than today. 
				/// </summary>
				/// <returns></returns>
				public BloggerViewModel GetLatestBlog()
				{
						var blog = new BloggerRepo().GetLatestBlog();

						var model = new BloggerViewModel
						{
								WritenOn = blog.BlogWritenOn,
								Title = blog.BlogTitle,
								Author = blog.BlogAuthor,
								Body = blog.BlogBody,
								ClosingCaption = blog.BlogClosingCaption,
								Remarks = blog.BlogRemarks,
								Intro = blog.BlogIntro,
								StartingDate = blog.BlogStartingDate,
								ImagePath = blog.BlogImagePath,
								Id = blog.BlogDetailId
						};

						return model;
				}

				/// <summary>
				/// Return just the blog according to the specified ID
				/// </summary>
				/// <param name="blogId">BlogDetailId</param>
				/// <returns></returns>
				public BloggerViewModel GetBlogById(int blogId)
				{
						var blog = new BloggerRepo().GetBlogDetailById(blogId);

						var model = new BloggerViewModel
						{
								Author = blog.BlogAuthor,
								WritenOn = blog.BlogWritenOn,
								Title = blog.BlogTitle,
								Body = blog.BlogBody,
								ClosingCaption = blog.BlogClosingCaption,
								Remarks = blog.BlogRemarks,
								Intro = blog.BlogIntro,
								ImagePath = blog.BlogImagePath
						};
						return model;
				}

				/// <summary>
				/// BloggerViewModel snippets to be displayed on the edit/add blog page.
				/// </summary>
				/// <returns></returns>
				public List<BloggerViewModel> GetBloggerSnippetsViewModel()
				{
						var blogs = new BloggerRepo().GetAllBlogDetails();

						var model = (from blog in blogs
												 select new BloggerViewModel
												 {
														 Id = blog.BlogDetailId,
														 Title = blog.BlogTitle.Length > 20 ? blog.BlogTitle.Substring(0, 20) : blog.BlogTitle,
														 Body = blog.BlogBody.Length > 200 ? blog.BlogBody.Substring(0, 200) : blog.BlogBody,
														 ClosingCaption = "",
														 Intro = "",
														 Remarks = "",
														 ImagePath = blog.BlogImagePath,
														 WritenOn = blog.BlogWritenOn
												 }).ToList();

						return model;
				}

				/// <summary>
				/// Get the EditBloggerViewmodel, its made up of just the blog, but the demo needs to be up to date too.
				/// </summary>
				/// <param name="blogId"></param>
				/// <returns></returns>
				public EditBloggerViewModel EditBloggerViewModel(int blogId)
				{
						var model = new EditBloggerViewModel();
						var blog = GetBlogById(blogId);

						model.BloggerViewModel = blog;
						model.BloggerFormViewModel = new BloggerFormViewModel
						{
								Author = blog.Author,
								BlogId = blog.Id,
								Body = blog.Body,
								ClosingCaption = blog.ClosingCaption,
								Intro = blog.Intro,
								Remarks = blog.Remarks,
								StartingDate = blog.StartingDate,
								Title = blog.Title,
								WritenOn = blog.WritenOn
						};

						return model;
				}

				/// <summary>
				/// Deleted blog by flagging it as "IsDeleted".
				/// </summary>
				/// <param name="blogId">BlogDetailId</param>
				/// <returns></returns>
				public bool DeleteBlogById(int blogId)
				{
						return new BloggerRepo().DeleteBlogById(blogId); ;
				}
		}
}
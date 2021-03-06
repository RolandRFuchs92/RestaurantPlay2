﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Entities;

namespace DataAccess
{
	public class BloggerRepo
	{
		private AppsContext _db => new AppsContext();

		/// <summary>
		/// Get all blogs regardless of weather they have been deleted or not.
		/// </summary>
		/// <returns></returns>
		public List<BlogDetail> GetAllBlogDetails()
		{
			return (from blog in _db.BlogDetails
					select blog).ToList();
		}

		/// <summary>
		/// the only thing that makes a blog invalid, is the fact that its marked as deleted.
		/// </summary>
		/// <returns></returns>
		public List<BlogDetail> GetAllValidBlogDetails()
		{
			return (from blog in _db.BlogDetails
					where !blog.IsDeleted
					select blog).ToList();
		}

		/// <summary>
		/// The latest blog must have a starting date earlier than today, it must also not be flagged as deleted.
		/// </summary>
		/// <returns></returns>
		public BlogDetail GetLatestBlog()
		{
			return (from blog in _db.BlogDetails
					where !blog.IsDeleted
						&& blog.BlogStartingDate < DateTime.Today
					orderby blog.BlogStartingDate
					select blog).FirstOrDefault();
		}

		/// <summary>
		/// Get Blog based on the BlogId and it must not be Deleted.
		/// </summary>
		/// <param name="blogId"></param>
		/// <returns></returns>
		public BlogDetail GetBlogDetailById(int blogId)
		{
			return (from blog in _db.BlogDetails
					where blog.BlogDetailId == blogId
								&& !blog.IsDeleted
					select blog).FirstOrDefault();
		}

		/// <summary>
		/// Hide the blog. This is done by flagging the blog as deleted.
		/// </summary>
		/// <param name="blogId"></param>
		/// <returns></returns>
		public bool DeleteBlogById(int blogId)
		{
			try
			{
				using (var db = new AppsContext())
				{
					var blog = (from blogDetail in db.BlogDetails
								where blogDetail.BlogDetailId == blogId
											&& !blogDetail.IsDeleted
								select blogDetail).FirstOrDefault();

					blog.IsDeleted = true;

					db.SaveChanges();

					return true;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		/// <summary>
		/// Save the blog - Must have an image path used when saving and image from base64 encoded string.
		/// </summary>
		/// <param name="blogDetail"></param>
		/// <returns></returns>
		public int SaveBlog(BlogDetail blogDetail)
		{
			var Id = 0;

			try
			{
				using (var db = new AppsContext())
				{
					var foundBlog = db.BlogDetails.SingleOrDefault(i => i.BlogDetailId == blogDetail.BlogDetailId);

					if (foundBlog != null)
					{
						blogDetail.CreatedOn = foundBlog.CreatedOn;
						blogDetail.IsDeleted = foundBlog.IsDeleted;
						db.Entry(foundBlog).CurrentValues.SetValues(blogDetail);
						db.SaveChanges();
						Id = blogDetail.BlogDetailId;
						return Id;
					}


					blogDetail.IsDeleted = false;
					blogDetail.CreatedOn = DateTime.Now;
					db.BlogDetails.Add(blogDetail);
					db.SaveChanges();
					db.CoreBlogs.Add(new COREBlog
					{
						BLOGDetailID = blogDetail.BlogDetailId,
						BLOGTypeID = 1
					});
					db.SaveChanges();
					return blogDetail.BlogDetailId;

				}
			}
			catch (Exception e)
			{
				return 0;
			}
		}
	}
}

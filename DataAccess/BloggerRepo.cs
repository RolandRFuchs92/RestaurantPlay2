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

        public List<BlogDetail> GetAllBlogDetails()
        {
            return (from blog in _db.BlogDetails
                    select blog).ToList();
        }

        public BlogDetail GetLatestBlog()
        {
            return (from blog in _db.BlogDetails
                    orderby blog.BlogStartingDate
                    select blog).FirstOrDefault();
        }

        public BlogDetail GetBlogDetailById(int blogId)
        {
            return (from blog in _db.BlogDetails
                    where blog.BlogDetailId == blogId
                    select blog).FirstOrDefault();
        }

        public bool DeleteBlogById(int blogId)
        {
            try
            {
                var blog = (from blogDetail in _db.BlogDetails
                            where blogDetail.BlogDetailId == blogId
                            select blogDetail).FirstOrDefault();

                blog.IsDeleted = true;

                _db.BlogDetails.Attach(blog);
                _db.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveBlog(BlogDetail blogDetail)
        {
            try
            {
                var foundBlog = _db.BlogDetails.SingleOrDefault(i => i.BlogDetailId == blogDetail.BlogDetailId);

                if (foundBlog != null)
                {
                    _db.Entry(foundBlog).CurrentValues.SetValues(blogDetail);
                }
                else
                {
                    blogDetail.IsDeleted = false;
                    blogDetail.CreatedOn = DateTime.Now;
                    _db.BlogDetails.Add(blogDetail);
                }
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

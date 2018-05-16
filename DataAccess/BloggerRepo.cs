using System;
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
    }
}

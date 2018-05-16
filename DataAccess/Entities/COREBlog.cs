using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class COREBlog
    {
        [Key]
        public int COREBlogID { get; set; }
        public int BLOGTypeID { get; set; }
        public int BLOGDetailID { get; set; }
    }
}

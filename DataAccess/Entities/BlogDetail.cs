using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class BlogDetail
    {
        [Key]
        public int BlogDetailId { get; set; }
        public string BlogImagePath { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public DateTime BlogWritenOn { get; set; }
        public string BlogIntro { get; set; }
        public string BlogBody { get; set; }
        public string BlogRemarks { get; set; }
        public string BlogClosingCaption { get; set; }
        public DateTime BlogStartingDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

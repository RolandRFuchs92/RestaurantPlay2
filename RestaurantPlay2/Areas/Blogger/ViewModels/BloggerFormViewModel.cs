using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.Blogger.ViewModels
{
    public class BloggerFormViewModel
    {
        public int BlogId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
        [Required]
        public DateTime WritenOn { get; set; }
        public string ImageBase { get; set; }
        [MaxLength(500)]
        public string Intro { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Body { get; set; }
        [MaxLength(100)]
        public string Remarks { get; set; }
        [MaxLength(100)]
        public string ClosingCaption{ get; set; }
        [Required]
        public DateTime StartingDate { get; set; }
    }
}
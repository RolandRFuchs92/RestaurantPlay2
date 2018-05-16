using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.Blogger.ViewModels
{
    public class BloggerViewModel
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string  Title { get; set; }
        public string  Author { get; set; }
        public DateTime WritenOn { get; set; }
        public string Intro { get; set; }
        public string Body { get; set; }
        public string Remarks { get; set; }
        public string ClosingCaption { get; set; }
    }
}
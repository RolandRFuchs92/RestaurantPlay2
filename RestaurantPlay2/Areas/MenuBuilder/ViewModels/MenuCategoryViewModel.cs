using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.MenuBuilder.ViewModels
{
    public class MenuCategoryViewModel
    {
        public List<MenuItemViewModel> MenuItems { get; set; }
        public string Title { get; set; }
    }
}
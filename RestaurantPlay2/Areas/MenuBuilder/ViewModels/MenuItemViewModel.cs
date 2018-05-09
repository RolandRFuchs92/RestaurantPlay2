using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.MenuBuilder.ViewModels
{
    public class MenuItemViewModel
    {
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public double MenuItemPrice { get; set; }
        public bool MenuItemDisplayPrice { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.MenuBuilder.ViewModels
{
    public class MenuBuilderViewModel
    {
        public List<MenuCategoryViewModel> MenuCategoryViewModel { get; set; }
        public SaveMenuItemViewModel SaveMenuItemViewModelProp { get; set; }
    }
}
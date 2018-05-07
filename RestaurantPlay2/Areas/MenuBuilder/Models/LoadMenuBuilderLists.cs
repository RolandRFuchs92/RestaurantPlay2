using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using DataAccess.Context;
using DataAccess.Entities;

namespace RestaurantPlay2.Areas.MenuBuilder.Models
{
    public class LoadMenuBuilderLists
    {
        public List<FoodPreference> FoodPreferences => new AppsContext().FoodPreferences.ToList(); 
        public List<MenuItemCategory> MenuItemCategories => new AppsContext().MenuItemCategories.ToList();
        public List<MenuItemType> MenuItemTypes => new AppsContext().MenuItemTypes.ToList();
        public List<int> Priority => Enumerable.Range(1, 25).ToList();
    }
}
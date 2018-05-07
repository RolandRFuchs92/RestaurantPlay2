using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccess.Entities;

namespace RestaurantPlay2.Areas.MenuBuilder.Entities
{
    public class SaveMenuItemViewModel
    {
        public int MenuItemId { get; set; }
        [Display(Name="Menu Item")]
        [MaxLength(50)]
        public string MenuItemName { get; set; }
        [MaxLength(200)]
        [Display(Name="Description")]
        public string MenuItemDescription { get; set; }
        [Display(Name="Price")]
        public double MenuItemPrice { get; set; }
        [Display(Name="Preference Type")]
        public int FoodPreferenceId { get; set; }
    }
}
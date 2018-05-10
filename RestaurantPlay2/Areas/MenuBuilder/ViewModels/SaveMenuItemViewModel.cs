using System.ComponentModel.DataAnnotations;

namespace RestaurantPlay2.Areas.MenuBuilder.ViewModels
{
    public class SaveMenuItemViewModel
    {
        public int MenuItemId { get; set; }
        [Display(Name="Menu Item")]
        [Required]
        [MaxLength(50)]
        public string MenuItemName { get; set; }
        [MaxLength(200)]
        [Required]
        [Display(Name="Description")]
        public string MenuItemDescription { get; set; }
        [Required]
        [Display(Name="Price")]
        public double MenuItemPrice { get; set; }
        [Display(Name="Preference Type")]
        public int FoodPreferenceId { get; set; }
        [Display(Name="Display Menu Item")]
        public bool IsActive { get; set; }
        [Display(Name = "Display Image")]
        public bool DisplayImage { get; set; }
        [Display(Name = "Display Price")]
        public bool DisplayPrice { get; set; }
        [Display(Name="Menu Item Group")]
        public int ItemTypeId { get; set; }
        [Display(Name = "Priority")]
        public int Priority { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
using RestaurantPlay2.Areas.MenuBuilder.ViewModels;
using DataAccess.Entities;
using DataAccess.MenuItem;


namespace RestaurantPlay2.Areas.MenuBuilder.BusinessLogic
{
    public class MenuBuilder
    {
        public bool SaveMenuItem(SaveMenuItemViewModel savedViewModel)
        {
            var menuItem = GetMenuItemFromSavedViewModel(savedViewModel);
            var menuItemSettings = GetMenuItemSettingsFromSavedViewModel(savedViewModel);
            new MenuItemRepo().SaveMenuItem(menuItem, menuItemSettings);

            return new MenuItemRepo().SaveMenuItem(menuItem, menuItemSettings);
        }

        private MenuItem GetMenuItemFromSavedViewModel(SaveMenuItemViewModel savedViewModel)
        {
            return new MenuItem
            {
                MenuItemDescription = savedViewModel.MenuItemDescription,
                MenuItemName = savedViewModel.MenuItemName,
                MenuItemPrice = savedViewModel.MenuItemPrice,
                FoodPreferenceId = savedViewModel.FoodPreferenceId
            };
        }

        private MenuItemSetting GetMenuItemSettingsFromSavedViewModel(SaveMenuItemViewModel savedViewModel)
        {
            return new MenuItemSetting
            {

                MenuItemIsDeleted = false,
                MenuItemPriority = savedViewModel.Priority,
                MenuItemSettingDisplayImage = savedViewModel.DisplayImage,
                MenuItemSettingIsActive = savedViewModel.IsActive,
                MenuItemTypeId = savedViewModel.ItemTypeId,
                MenuItemSettingDisplayPrice = savedViewModel.DisplayPrice
            };
        }

    }
}
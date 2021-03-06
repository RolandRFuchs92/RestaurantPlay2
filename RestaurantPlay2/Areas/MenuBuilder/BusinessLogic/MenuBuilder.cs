﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.MenuItem;
using RestaurantPlay2.Areas.ImageItems.ViewModels;
using RestaurantPlay2.Areas.MenuBuilder.ViewModels;
using DataAccess.Models;

namespace RestaurantPlay2.Areas.MenuBuilder.BusinessLogic
{
    public class MenuBuilder
    {
        /// <summary>
        /// Convert the repo return for view model to a useable viewmodel on our side.
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <returns></returns>
        public SaveMenuItemViewModel LoadFormMenuItemViewModel(int menuItemId)
        {
            var menuItemViewModel = new MenuItemRepo().GetMenuItemFormModelById(menuItemId);

            var saveMenuItemViewModel = new SaveMenuItemViewModel
            {
                FoodPreferenceId = menuItemViewModel.MenuItem.FoodPreferenceId,
                MenuItemId = menuItemViewModel.MenuItem.MenuItemId,
                MenuItemDescription = menuItemViewModel.MenuItem.MenuItemDescription,
                CategoryId = menuItemViewModel.MenuItemSetting.MenuItemCategoryId,
                MenuItemName = menuItemViewModel.MenuItem.MenuItemName,
                MenuItemPrice = menuItemViewModel.MenuItem.MenuItemPrice,
                DisplayImage = menuItemViewModel.MenuItemSetting.MenuItemSettingDisplayImage,
                Priority = menuItemViewModel.MenuItemSetting.MenuItemPriority,
                ItemTypeId = menuItemViewModel.MenuItemSetting.MenuItemTypeId,
                DisplayPrice = menuItemViewModel.MenuItemSetting.MenuItemSettingDisplayPrice,
                IsActive = menuItemViewModel.MenuItemSetting.MenuItemSettingIsActive
            };

            return saveMenuItemViewModel;
        }

        /// <summary>
        /// This is the loading mechanisim to hit the Db and get menu items...
        /// </summary>
        /// <returns></returns>
        public List<MenuCategoryViewModel> LoadMenuItemsViewModel()
        {
            var menuItems = new MenuItemRepo().GetMenuItemModels();

            //TODO User the displayPrice variable and stop hardcoding stuff brah
            var menuItemsViewModel = (from item in menuItems
                                      select new MenuCategoryViewModel
                                      {
                                          MenuItems = (from i in item.MenuItemUnit
                                                      select new MenuItemViewModel
                                                      {
                                                          MenuItemId = i.MenuItemId,
                                                          MenuItemDescription =i.MenuItemDescription,
                                                          MenuItemName =  i.MenuItemName,
                                                          MenuItemPrice = i.MenuItemPrice,
                                                          MenuItemDisplayPrice = true
                                                      }).ToList(),
                                          Title = item.MenuItemCategory.MenuItemCategoryName
                                      }).ToList();


            return menuItemsViewModel;
        }

        /// <summary>
        /// get the viewmodel required for the index page...
        /// </summary>
        /// <returns></returns>
        public MenuBuilderViewModel LoadMenuBuilderViewModel()
        {
            var model = new MenuBuilderViewModel
            {
                MenuCategoryViewModel = new BusinessLogic.MenuBuilder().LoadMenuItemsViewModel(),
                SaveMenuItemViewModelProp = new SaveMenuItemViewModel()
            };

            return model;
        }

        /// <summary>
        /// Save the menu item from the user passed view model.
        /// </summary>
        /// <param name="saveMenuItem"></param>
        /// <returns></returns>
        public bool SaveMenuItem(SaveMenuItemViewModel saveMenuItem)
        {
            var menuItem = PickMenuItemModel(saveMenuItem);
            var menuItemSettings = PickMenuItemSettings(saveMenuItem);

            var moo = new DataAccess.MenuItem.MenuItemRepo().SaveMenuItem(menuItem, menuItemSettings);

            return moo;
        }

        /// <summary>
        /// This is to keep with a solid principal, and a seperation of concerns...
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <returns></returns>
        public bool DeleteMenuItem(int menuItemId)
        {
            return new MenuItemRepo().DeleteMenuItem(menuItemId); ;
        }

        #region private methods
        /// <summary>
        /// pick parts of the saveMenuItemViewModel to create a useful model to save
        /// </summary>
        /// <param name="saveMenuItem"></param>
        /// <returns></returns>
        private MenuItem PickMenuItemModel(SaveMenuItemViewModel saveMenuItem)
        {
            var menuItem = new MenuItem
            {
                FoodPreferenceId = saveMenuItem.FoodPreferenceId,
                MenuItemId = saveMenuItem.MenuItemId,
                MenuItemDescription = saveMenuItem.MenuItemDescription,
                MenuItemName = saveMenuItem.MenuItemName,
                MenuItemPrice = saveMenuItem.MenuItemPrice
            };

            return menuItem;
        }

        /// <summary>
        /// pick parts of the saveMenuItemViewModel to create a useful model to save
        /// </summary>
        /// <param name="saveMenuItem"></param>
        /// <returns></returns>
        private MenuItemSetting PickMenuItemSettings(SaveMenuItemViewModel saveMenuItem)
        {
            var menuItemSettings = new MenuItemSetting
            {
                MenuItemId = saveMenuItem.MenuItemId,
                MenuItemIsDeleted = false,
                MenuItemCategoryId = saveMenuItem.CategoryId,
                MenuItemPriority = saveMenuItem.Priority,
                MenuItemSettingDisplayImage = saveMenuItem.DisplayImage,
                MenuItemTypeId = saveMenuItem.ItemTypeId,
                MenuItemSettingIsActive = saveMenuItem.IsActive,
                MenuItemSettingDisplayPrice = saveMenuItem.DisplayPrice
            };
            return menuItemSettings;
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Models;

namespace DataAccess.MenuItem
{
    public class MenuItemRepo
    {
        public List<Entities.MenuItem> GetMenuAllItems()
        {
            return new AppsContext().MenuItems.ToList();
        }

        /// <summary>
        /// Get menu Items that are active
        /// </summary>
        /// <returns></returns>
        public List<MenuItemModel> GetMenuItemModels()
        {
            var db = new AppsContext();
            var thing = (from ms in db.MenuItemSettings
                         join mi in db.MenuItems on ms.MenuItemId equals mi.MenuItemId
                         //join mc in db.MenuItemCategories on ms.MenuItemCategoryId equals mc.MenuItemCategoryId
                         where ms.MenuItemSettingIsActive
                               && !ms.MenuItemIsDeleted
                         orderby ms.MenuItemPriority
                         group mi by ms.MenuItemCategoryId into g
                         select g).ToList();

            var model = (from i in thing
                         join mc in db.MenuItemCategories on i.Key equals mc.MenuItemCategoryId
                         select new MenuItemModel
                         {
                             MenuItemCategory = mc,
                             MenuItemUnit = i.ToList()
                         }).ToList();

            //This is like super overboard for such a simple thing but i think it works fine... in production i would move this straight into stored proc...
            return model;
        }

        public MenuItemFormModel GetMenuItemFormModelById(int menuItemId)
        {
            var db = new AppsContext();

            return (from mi in db.MenuItems
                    join ms in db.MenuItemSettings on mi.MenuItemId equals ms.MenuItemId
                    where mi.MenuItemId == menuItemId
                          && ms.MenuItemId == menuItemId
                    select new MenuItemFormModel
                    {
                        MenuItem = mi,
                        MenuItemSetting = ms
                    }).FirstOrDefault();
        }

        /// <summary>
        /// Get single menu item by menu Item Id
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <returns></returns>
        public Entities.MenuItem GetMenuItemById(int menuItemId)
        {
            return new AppsContext().MenuItems.FirstOrDefault(i => i.MenuItemId == menuItemId);
        }

        /// <summary>
        /// Add both a MenuItem and a MenuItemSettings row to the db.
        /// </summary>
        /// <param name="menuItem"></param>
        /// <param name="menuItemSettings"></param>
        /// <returns></returns>
        public bool SaveMenuItem(Entities.MenuItem menuItem, MenuItemSetting menuItemSettings)
        {
            using (var db = new AppsContext())
            {
                try
                {
                    menuItem.CreatedOn = DateTime.Now;
                    db.MenuItems.AddOrUpdate(menuItem);
                    db.SaveChanges();
                    menuItemSettings.MenuItemId = menuItem.MenuItemId;

                    db.MenuItemSettings.AddOrUpdate(menuItemSettings);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        /// <summary>
        /// this isnt a real delete its more of a fake one, cause we are really just flagging the row as deleted.
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <returns></returns>
        public bool DeleteMenuItem(int menuItemId)
        {
            using (var db = new AppsContext())
            {
                try
                {
                    var menuItemSettings = (from item in db.MenuItemSettings
                                            where item.MenuItemId == menuItemId
                                            select item).FirstOrDefault();

                    menuItemSettings.MenuItemIsDeleted = true;

                    db.MenuItemSettings.AddOrUpdate(menuItemSettings);

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

    }
}

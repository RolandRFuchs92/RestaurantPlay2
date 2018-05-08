using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Entities;
using System.Data.Entity.Migrations;

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
        public List<Entities.MenuItem> GetActiveMenuItems()
        {
            var db = new AppsContext();

            return (from ms in db.MenuItemSettings
                    join mi in db.MenuItems on ms.MenuItemId equals mi.MenuItemId
                    where ms.MenuItemSettingIsActive == true
                    && ms.MenuItemIsDeleted != true
                    select mi).ToList();
        }

        /// <summary>
        /// Get single menu item by menu Item Id
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <returns></returns>
        public Entities.MenuItem GetMenuItemById(int menuItemId)
        {
            var db = new AppsContext();

            return db.MenuItems.FirstOrDefault(i => i.MenuItemId == menuItemId);
        }

        /// <summary>
        /// Add a menu item and its settings, these 2 entities/tables are coupled.
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
                    menuItem.CreatedOn = menuItem.CreatedOn ?? DateTime.Now;

                    db.MenuItems.AddOrUpdate(menuItem);
                    db.SaveChanges();

                    menuItemSettings.MenuItemId = menuItem.MenuItemId;
                    db.MenuItemSettings.AddOrUpdate(menuItemSettings);

                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// "Deletes" the item but actually just flags the item as "IsDeleted"
        /// </summary>
        /// <returns></returns>
        public bool DeleteMenuItems(int MenuItemId)
        {
            using (var db = new AppsContext())
            {
                try
                {
                    var menuItem = (from item in db.MenuItemSettings
                                    where item.MenuItemId == MenuItemId
                                    select item).FirstOrDefault();

                    menuItem.MenuItemIsDeleted = true;

                    db.MenuItemSettings.AddOrUpdate(menuItem);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    //TODO Add Error Logging
                }


            }


            return false;
        }

    }
}

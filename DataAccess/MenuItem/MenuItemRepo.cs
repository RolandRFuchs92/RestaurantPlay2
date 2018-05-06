using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;

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



}
}

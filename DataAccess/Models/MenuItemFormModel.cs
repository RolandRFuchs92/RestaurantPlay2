using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Models
{
    public class MenuItemFormModel
    {
        public Entities.MenuItem MenuItem { get; set; }
        public MenuItemSetting MenuItemSetting { get; set; }
    }
}

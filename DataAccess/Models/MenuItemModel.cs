using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Models
{
    public class MenuItemModel 
    {
        public List<Entities.MenuItem> MenuItemUnit { get; set; }
        public MenuItemCategory MenuItemCategory { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class MenuItemCategory
    {
        [Key]
        public int MenuItemCategoryId { get; set; }
        public string MenuItemCategoryName { get; set; }
    }
}

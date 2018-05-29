using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ItemListCategory
    {
				[Key]
        public int ItemListCategoryId { get; set; }
        public string ItemListCategoryName { get; set; }
    }
}

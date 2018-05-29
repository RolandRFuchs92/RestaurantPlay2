using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ItemList
    {
				[Key]
        public int ItemListId { get; set; }
        public int ItemListCategoryId { get; set; }
        public int ItemListPriority { get; set; }
        public string ItemListData { get; set; }
    }
}

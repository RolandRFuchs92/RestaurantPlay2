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
        public int ListId { get; set; }
        public int ListCategoryId { get; set; }
        public int ListPriority { get; set; }
        public string ListData { get; set; }
    }
}

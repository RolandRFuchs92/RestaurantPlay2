using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ItemList
    {
        public int ListId { get; set; }
        public int ListCategoryId { get; set; }
        public int ListPriority { get; set; }
        public string ListData { get; set; }
    }
}

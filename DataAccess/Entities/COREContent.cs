using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class COREContent
    {
        [Key]
        public int CONTENTID { get; set; }
        public string CONTENTValue { get; set; }
        public DateTime CONTENTDateCreated { get; set; }
        public bool CONTENTIsActive { get; set; }
    }
}

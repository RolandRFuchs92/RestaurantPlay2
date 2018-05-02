using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImageItem
{
    public class IMAGEItem
    {   
        [Key]
        public int IMAGEItemID { get; set; }
        public string IMAGEItemTitle { get; set; }
        public string IMAGEItemSubTitle { get; set; }
        public string IMAGEItemImagePath { get; set; }
        public string IMAGEItemParagraph { get; set; }
        public bool IMAGEItemIsActive { get; set; }
        public DateTime IMAGEItemDateCreated { get; set; }
        public int IMAGETypeID { get; set; }
    }
}

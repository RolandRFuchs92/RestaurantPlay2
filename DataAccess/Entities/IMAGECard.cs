using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImageCard
{
    public class IMAGECard
    {
        public int IMAGEDetailID { get; set; }
        public string IMAGEDetailTitle { get; set; }
        public string IMAGEDetailSubTitle { get; set; }
        public string IMAGEDetailImagePath { get; set; }
        public string IMAGEDetailParagraph { get; set; }
        public bool IMAGEDetailIsActive { get; set; }
        public DateTime IMAGEDetailDateCreated { get; set; }
    }
}

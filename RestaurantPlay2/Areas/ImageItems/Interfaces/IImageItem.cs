using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPlay2.Areas.ImageItems.Interfaces
{
    public interface IImageItem
    {
        int ImageId { get; set; }
        string DetailTitle { get; set; }
        string DetailSubTitle { get; set; }
        string DetailImagePath { get; set; }
        bool DetailIsActive { get; set; }
        DateTime DetailDateCreated { get; set; }
    }
}

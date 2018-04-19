using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;

namespace DataAccess.ImageCard
{
    public class ImageCardRepo
    {
        //Return 
        public List<IMAGECard> GetImageCards()
        {
            return new AppsContext().ImageCards.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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


        public bool SaveImageCard(IMAGECard imageCard)
        {
            bool saved = false;
            imageCard.IMAGEDetailDateCreated = DateTime.Today;
            imageCard.IMAGEDetailIsActive = true;

            try
            {
                using (var db = new AppsContext())
                {

                    db.ImageCards.Add(imageCard);
                    db.SaveChanges();
                    saved = true;
                }
            }
            catch
            {
                saved = false;
            }

            return saved;
        }

    }
}

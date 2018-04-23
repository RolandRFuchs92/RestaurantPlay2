using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;

namespace DataAccess.ImageCard
{
    public class ImageCardRepo
    {
        /// <summary>
        /// Get all image cards
        /// </summary>
        /// <returns></returns>
        public List<IMAGECard> GetImageCards()
        {
            return new AppsContext().ImageCards.ToList();
        }

        /// <summary>
        /// Get image cards where they are active.
        /// </summary>
        /// <returns></returns>
        public List<IMAGECard> GetValidImageCards()
        {
            var model = new List<IMAGECard>();

            using (var db = new AppsContext())
            {
                model = (from image in db.ImageCards
                    where image.IMAGEDetailIsActive
                    select image).ToList();
            }
            return model;
        }

        /// <summary>
        /// Get Single Image by ID
        /// </summary>
        /// <param name="imageDetailID"></param>
        /// <returns></returns>
        public IMAGECard GetImageCardID(int imageDetailID)
        {
            var imageCard = new IMAGECard();

            using (var db = new AppsContext())
            {
                imageCard = db.ImageCards.FirstOrDefault(i => i.IMAGEDetailID == imageDetailID);
            }

            return imageCard;
        }

        /// <summary>
        /// Save image card, save card model information.
        /// </summary>
        /// <param name="imageCard"></param>
        /// <returns></returns>
        public bool SaveImageCard(IMAGECard imageCard)
        {
            bool saved = false;
            imageCard.IMAGEDetailDateCreated = DateTime.Now;

            try
            {
                using (var db = new AppsContext())
                {
                    db.ImageCards.AddOrUpdate(imageCard);
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

        /// <summary>
        /// Delete Image by ID
        /// </summary>
        /// <param name="imageID"></param>
        /// <returns></returns>
        public bool DeleteImageCard(int imageID)
        {
            try
            {
                using (var db = new AppsContext())
                {
                    var image = GetImageCardID(imageID);
                    db.ImageCards.Attach(image);
                    db.ImageCards.Remove(image);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                
            }

            return false;
        }
    }
}

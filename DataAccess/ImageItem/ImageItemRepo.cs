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
        private int _imageItemTypeID;

        public ImageCardRepo()
        {
            _imageItemTypeID = 1;
        }

        public ImageCardRepo(int ItemTypeID)
        {
            _imageItemTypeID = ItemTypeID;
        }

        /// <summary>
        /// Get all image cards
        /// </summary>
        /// <returns></returns>
        public List<IMAGEItem> GetImageCards()
        {
            return new AppsContext().ImageItems.Where(i => i.IMAGETypeID == _imageItemTypeID).ToList();
        }

        /// <summary>
        /// Get image cards where they are active.
        /// </summary>
        /// <returns></returns>
        public List<IMAGEItem> GetValidImageCards()
        {
            var model = new List<IMAGEItem>();

            using (var db = new AppsContext())
            {
                model =
                    (from image in db.ImageItems
                     where image.IMAGEItemIsActive && 
                           image.IMAGETypeID == _imageItemTypeID
                     select image).ToList();
            }
            return model;
        }

        /// <summary>
        /// Get Single Image by ID
        /// </summary>
        /// <param name="imageDetailID"></param>
        /// <returns></returns>
        public IMAGEItem GetImageCardID(int imageItemID)
        {
            var imageCard = new IMAGEItem();

            using (var db = new AppsContext())
            {
                imageCard = db.ImageItems.FirstOrDefault(i => i.IMAGEItemID == imageItemID && i.IMAGETypeID == _imageItemTypeID);
            }

            return imageCard;
        }

        /// <summary>
        /// Save image card, save card model information.
        /// </summary>
        /// <param name="imageCard"></param>
        /// <returns></returns>
        public bool SaveImageCard(IMAGEItem imageCard)
        {
            bool saved = false;
            imageCard.IMAGEItemDateCreated = DateTime.Now;
            imageCard.IMAGETypeID = _imageItemTypeID;

            try
            {
                using (var db = new AppsContext())
                {
                    db.ImageItems.AddOrUpdate(imageCard);
                    db.SaveChanges();
                    saved = true;
                }
            }
            catch
            {
                throw;
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
                    db.ImageItems.Attach(image);
                    db.ImageItems.Remove(image);
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

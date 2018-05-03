using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;

namespace DataAccess.ImageItem
{
    public class ImageItemRepo
    {
        private readonly int _imageItemTypeID;

        public ImageItemRepo()
        {
            _imageItemTypeID = 1;
        }
        public ImageItemRepo(int ItemTypeID)
        {
            _imageItemTypeID = ItemTypeID;
        }

        /// <summary>
        /// Get all image cards
        /// </summary>
        /// <returns></returns>
        public List<IMAGEItem> GetImageItems()
        {
            return new AppsContext().ImageItems.Where(i => i.IMAGETypeID == _imageItemTypeID).ToList();
        }

        /// <summary>
        /// Get image cards where they are active.
        /// </summary>
        /// <returns></returns>
        public List<IMAGEItem> GetValidImageItems()
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
        /// <param name="imageItemId"></param>
        /// <returns></returns>
        public IMAGEItem GetImageItemId(int imageItemId)
        {
            return new AppsContext().ImageItems
                .FirstOrDefault(i => i.IMAGEItemID == imageItemId
                                     && i.IMAGETypeID == _imageItemTypeID);
        }

        /// <summary>
        /// Save image card, save card model information.
        /// </summary>
        /// <param name="imageItem"></param>
        /// <returns></returns>
        public bool SaveImageItem(IMAGEItem imageItem)
        {
            bool saved = false;
            imageItem.IMAGEItemDateCreated = DateTime.Now;
            imageItem.IMAGETypeID = _imageItemTypeID;

            try
            {
                using (var db = new AppsContext())
                {
                    db.ImageItems.AddOrUpdate(imageItem);
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
        /// <param name="imageId"></param>
        /// <returns></returns>
        public bool DeleteImageItem(int imageId)
        {
            try
            {
                using (var db = new AppsContext())
                {
                    var image = GetImageItemId(imageId);
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

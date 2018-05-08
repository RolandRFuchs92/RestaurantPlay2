using System.Collections.Generic;
using RestaurantPlay2.Areas.ImageItems.ViewModels;

namespace RestaurantPlay2.Areas.ImageItems.Interfaces
{
    public interface IImageItemFrame<T>
    {
        /// <summary>
        /// Load All image items
        /// </summary>
        /// <returns></returns>
        List<T> LoadAllImageItems();
        /// <summary>
        /// Load Only Image items are active (IsActive = 1)
        /// </summary>
        /// <returns></returns>
        List<T> LoadValidImageItems();
        /// <summary>
        /// Load a single image Item by imageId
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        T LoadImageItemById(int imageId);
        /// <summary>
        /// Save an image item.
        /// </summary>
        /// <param name="imageItem"></param>
        /// <returns></returns>
        bool SaveImageItem(ISaveImageItem imageItem);
        /// <summary>
        /// Delete a Image Item
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        bool DeleteImageItem(int imageId);
    }
}

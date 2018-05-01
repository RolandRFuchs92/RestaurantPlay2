using System.Collections.Generic;
using RestaurantPlay2.Areas.ImageItems.ViewModels;

namespace RestaurantPlay2.Areas.ImageItems.Interfaces
{
    public interface IImageItem<T>
    {
        List<T> LoadAllImageItems();
        List<T> LoadValidImageItems();
        T LoadImageItemById(int imageId);
        bool SaveImageItem(SaveImageItemViewModel imageItem);
    }
}

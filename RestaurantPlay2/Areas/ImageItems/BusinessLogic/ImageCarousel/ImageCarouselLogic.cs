using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.WebPages;
using DataAccess.ImageItem;
using RestaurantPlay2.Areas.ImageItems.BusinessLogic.Misc;
using RestaurantPlay2.Areas.ImageItems.Interfaces;
using RestaurantPlay2.Areas.ImageItems.ViewModels;
using RestaurantPlay2.Areas.ImageItems.ViewModels.ImageCarousel;

namespace RestaurantPlay2.Areas.ImageItems.BusinessLogic.ImageCarousel
{
    [Authorize]
    public class ImageCarouselLogic : Misc.ImageUtils, IImageItemFrame<ImageItemViewModel>
    {
        private readonly int _imageItemType = 2;
        public List<ImageItemViewModel> LoadAllImageItems()
        {
            var imageCardList = new DataAccess.ImageItem.ImageItemRepo(_imageItemType).GetImageItems();

            List<ImageItemViewModel> model = (imageCardList
                .Select(i => new ImageItemViewModel
                {
                    ImageId = i.IMAGEItemID,
                    DetailImagePath = i.IMAGEItemImagePath,
                    DetailTitle = i.IMAGEItemTitle,
                    DetailDateCreated = i.IMAGEItemDateCreated,
                    DetailIsActive = i.IMAGEItemIsActive,
                    DetailParagraph = i.IMAGEItemParagraph,
                    DetailSubTitle = i.IMAGEItemSubTitle
                })).ToList();

            return model;
        }

        public List<ImageItemViewModel> LoadValidImageItems()
        {
            var imageCards = new ImageItemRepo(_imageItemType).GetValidImageItems();
            var model = imageCards.Select(i => new ImageItemViewModel
            {
                ImageId = i.IMAGEItemID,
                DetailImagePath = i.IMAGEItemImagePath,
                DetailParagraph = i.IMAGEItemParagraph,
                DetailSubTitle = i.IMAGEItemSubTitle,
                DetailTitle = i.IMAGEItemTitle,
                IsEditable = false
            }).ToList();

            return model;
        }

        public ImageItemViewModel LoadImageItemById(int imageId)
        {
            var imageCard = new ImageItemRepo(_imageItemType).GetImageItemId(imageId);

            var model = new ImageItemViewModel()
            {
                ImageId = imageCard.IMAGEItemID,
                DetailSubTitle = imageCard.IMAGEItemSubTitle,
                DetailIsActive = imageCard.IMAGEItemIsActive,
                DetailImagePath = Path.GetFileName(imageCard.IMAGEItemImagePath),
                DetailParagraph = imageCard.IMAGEItemParagraph,
                DetailTitle = imageCard.IMAGEItemTitle
            };
            return model;
        }

        public bool SaveImageItem(ISaveImageItem imageItem)
        {
            var imagePath = new ImageUtils().SaveImageFile(imageItem.Image);

            if (imagePath.IsEmpty())
                return false;

            var carouselItem = new IMAGEItem
            {
                IMAGEItemIsActive = imageItem.IsActive,
                IMAGEItemID = imageItem.imageID,
                IMAGEItemImagePath = imagePath,
                IMAGEItemSubTitle = imageItem.DetailSubTitle,
                IMAGEItemTitle = imageItem.DetailTitle
            };

            var imageRepo = new ImageItemRepo(_imageItemType);

            return imageRepo.SaveImageItem(carouselItem);
        }

        public bool DeleteImageItem(int imageId)
        {
            return new ImageItemRepo(_imageItemType).DeleteImageItem(imageId);
        }

        public EditCarouselViewModel LoadCarouselViewModel()
        {
            var model = new EditCarouselViewModel
            {
                CarouselItems = new ImageCarouselLogic().LoadAllImageItems(),
                SaveCarouselItem = new SaveCarouselViewModel()
            };

            return model;
        }

    }
}
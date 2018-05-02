using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using DataAccess.ImageItem;
using RestaurantPlay2.Areas.ImageItems.ViewModels;
using RestaurantPlay2.Areas.ImageItems.ViewModels.ImageCard;

namespace RestaurantPlay2.Areas.ImageItems.BusinessLogic.ImageCards
{
    public class ImageCardLogic
    {
        /// <summary>
        /// Load Image card list, converted to a viewmodel
        /// </summary>
        /// <returns></returns>
        public List<ImageCardViewModel> LoadImageCardViewModels()
        {
            var imageCardList = new DataAccess.ImageItem.ImageItemRepo().GetImageItems();

            List<ImageCardViewModel> model = (imageCardList
                .Select(i => new ImageCardViewModel
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

        /// <summary>
        /// Load Valid Image View Models
        /// </summary>
        /// <returns></returns>
        public List<ImageCardViewModel> LoadValidImageCardViewModels()
        {
            var imageCards = new ImageItemRepo().GetValidImageItems();
            var model = imageCards.Select(i => new ImageCardViewModel
            {
                ImageId = i.IMAGEItemID,
                DetailImagePath = i.IMAGEItemImagePath,
                DetailParagraph = i.IMAGEItemParagraph,
                DetailSubTitle = i.IMAGEItemSubTitle,
                DetailTitle = i.IMAGEItemTitle,
                IsEditable =  false
            }).ToList();

            return model;
        }

        /// <summary>
        /// Load Image Card by ID, converted to a viewModel
        /// </summary>
        /// <param name="imageID"></param>
        /// <returns></returns>
        public ImageCardViewModel LoadImageCardByImageID(int imageID)
        {
            var imageCard = new ImageItemRepo().GetImageItemId(imageID);

            var model = new ImageCardViewModel()
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

        /// <summary>
        /// Save image details to database and save Image to Server
        /// </summary>
        /// <param name="imageCard"></param>
        /// <returns></returns>
        public bool SaveImageCard(SaveImageCardViewModel imageCard)
        {
            var imagePath = new ImageCardLogic().SaveImageFile(imageCard.Image);

            if (imagePath.IsEmpty())
                return false;

            var imageCardRepo = new IMAGEItem
            {
                IMAGEItemIsActive = imageCard.IsActive,
                IMAGEItemID = imageCard.imageID,
                IMAGEItemImagePath = imagePath,
                IMAGEItemParagraph = imageCard.DetailParagraph,
                IMAGEItemSubTitle = imageCard.DetailSubTitle,
                IMAGEItemTitle = imageCard.DetailTitle
            };

            var imageRepo = new ImageItemRepo();

            return imageRepo.SaveImageItem(imageCardRepo); 
        }

        /// <summary>
        /// Save image file
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private string SaveImageFile(HttpPostedFileBase image)
        {
            try
            {
                if (image.ContentLength > 0)
                {
                    var _fileName = Path.GetFileName(image.FileName);
                    var _serverPath = $"/Content/Images/{_fileName}";
                    var _path = HttpContext.Current.Server.MapPath(_serverPath);
                    image.SaveAs(_path);
                    return _serverPath;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "Image save was unsuccessful!";
        }
    }
}
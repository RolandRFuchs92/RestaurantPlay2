using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using DataAccess.ImageCard;
using RestaurantPlay2.Areas.ImageCard.ViewModels;

namespace RestaurantPlay2.Areas.ImageCard.BusinessLogic.ImageCards
{
    public class ImageCardLogic
    {
        /// <summary>
        /// Load Image card list, converted to a viewmodel
        /// </summary>
        /// <returns></returns>
        public List<ImageCardViewModel> LoadImageCardViewModels()
        {
            var imageCardList = new DataAccess.ImageCard.ImageCardRepo().GetImageCards();

            List<ImageCardViewModel> model = (imageCardList
                .Select(i => new ImageCardViewModel
                {
                    ImageId = i.IMAGEDetailID,
                    DetailImagePath = i.IMAGEDetailImagePath,
                    DetailTitle = i.IMAGEDetailTitle,
                    DetailDateCreated = i.IMAGEDetailDateCreated,
                    DetailIsActive = i.IMAGEDetailIsActive,
                    DetailParagraph = i.IMAGEDetailParagraph,
                    DetailSubTitle = i.IMAGEDetailSubTitle
                })).ToList();

            return model;
        }

        /// <summary>
        /// Load Valid Image View Models
        /// </summary>
        /// <returns></returns>
        public List<ImageCardViewModel> LoadValidImageCardViewModels()
        {
            var imageCards = new ImageCardRepo().GetValidImageCards();
            var model = imageCards.Select(i => new ImageCardViewModel
            {
                ImageId = i.IMAGEDetailID,
                DetailImagePath = i.IMAGEDetailImagePath,
                DetailParagraph = i.IMAGEDetailParagraph,
                DetailSubTitle = i.IMAGEDetailSubTitle,
                DetailTitle = i.IMAGEDetailTitle,
                isEditable = false
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
            var imageCard = new ImageCardRepo().GetImageCardID(imageID);

            var model = new ImageCardViewModel()
            {
                ImageId = imageCard.IMAGEDetailID,
                DetailSubTitle = imageCard.IMAGEDetailSubTitle,
                DetailIsActive = imageCard.IMAGEDetailIsActive,
                DetailImagePath = Path.GetFileName(imageCard.IMAGEDetailImagePath),
                DetailParagraph = imageCard.IMAGEDetailParagraph,
                DetailTitle = imageCard.IMAGEDetailTitle
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

            var imageCardRepo = new IMAGECard
            {
                IMAGEDetailIsActive = imageCard.IsActive,
                IMAGEDetailID = imageCard.imageID,
                IMAGEDetailImagePath = imagePath,
                IMAGEDetailParagraph = imageCard.DetailParagraph,
                IMAGEDetailSubTitle = imageCard.DetailSubTitle,
                IMAGEDetailTitle = imageCard.DetailTitle,
            };

            var imageRepo = new ImageCardRepo();

            return imageRepo.SaveImageCard(imageCardRepo); 
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
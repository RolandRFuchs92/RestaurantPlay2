using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.ImageCard;
using RestaurantPlay2.Areas.Content.ViewModels;

namespace RestaurantPlay2.Areas.Content.BusinessLogic.ImageCards
{
    public class ImageCardLogic
    {
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

        public bool SaveImageCard(SaveImageCardViewModel imageCard)
        {
            var saveCard = new IMAGECard();

            saveCard.IMAGEDetailParagraph = imageCard.DetailParagraph;
            saveCard.IMAGEDetailSubTitle = imageCard.DetailSubTitle;
            saveCard.IMAGEDetailTitle = imageCard.DetailTitle;

            return false;
        }
    }
}
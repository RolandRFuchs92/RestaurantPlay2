﻿using System;

namespace RestaurantPlay2.Areas.ImageItems.ViewModels
{
    public class ImageCardViewModel
    {
        public bool IsEditable { get; set; } = true;
        public int ImageId { get; set; }
        public string DetailTitle { get; set; }
        public string DetailSubTitle { get; set; }
        public string DetailImagePath { get; set; }
        public string DetailParagraph { get; set; }
        public bool DetailIsActive { get; set; }
        public DateTime DetailDateCreated { get; set; }
    }
}
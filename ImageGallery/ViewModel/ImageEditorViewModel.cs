﻿using ImageGallery.ViewModel.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageGallery.ViewModel
{
    public class ImageEditorViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Caption { get; set; }

        [Required]         
        public HttpPostedFileBase FileImage { get; set; }

        internal static GalleriesVM getEnityModel(ImageEditorViewModel model)
        {
            return new GalleriesVM
            {
                IsActive = true,
                Title = model.Caption, 
                OrderNo = 0
            };
        }

    }

    public class ImageList
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int? OrderNo { get; set; }
        public string Title { get; set; }
        public int WebImageId { get; set; }
        public int? post_like { get; set; }
    }
}
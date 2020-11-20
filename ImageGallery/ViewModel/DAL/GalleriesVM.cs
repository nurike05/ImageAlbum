namespace ImageGallery.ViewModel.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GalleriesVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int WebImageId { get; set; }

        public bool IsActive { get; set; }

        public int? OrderNo { get; set; }

        public int? post_like { get; set; }

        public GalleriesVM()
        {
            IsActive = true;

        }
    }
}

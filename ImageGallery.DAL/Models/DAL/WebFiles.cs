namespace ImageGallery.DAL.Models.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WebFiles
    {
        public int Id { get; set; }

        public byte[] Data { get; set; }

        public bool IsActive { get; set; }

        public DateTime UpdateDate { get; set; }

        public string FileName { get; set; }

        public string FileExt { get; set; }

        public int FileLength { get; set; }

        public string ContentType { get; set; }
    }
}

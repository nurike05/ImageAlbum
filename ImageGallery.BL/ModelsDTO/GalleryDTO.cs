using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.BL.ModelsDTO
{
    public partial class GalleryDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int WebImageId { get; set; }

        public bool IsActive { get; set; }

        public int? OrderNo { get; set; }

        public int? post_like { get; set; }
    }
}

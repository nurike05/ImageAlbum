using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.BL.ModelsDTO
{
    public partial class WebFileDTO
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

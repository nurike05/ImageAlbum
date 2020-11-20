using AutoMapper;
using ImageGallery.BL.ModelsDTO;
using ImageGallery.DAL.Models.DAL;
using ImageGallery.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.BL.ServicesBO
{
    public abstract class GalleryServiceBO
    {
        protected IMapper mapper;
        protected UnitOfWork unitOfWork;

        public GalleryServiceBO(IMapper mapper, UnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
    }
}

using AutoMapper;
using ImageGallery.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.BL.ServicesBO
{
    public abstract class UserServiceBO
    {
        protected IMapper mapper;
        protected UnitOfWork unitOfWork;

        public UserServiceBO(IMapper mapper, UnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
    }
}

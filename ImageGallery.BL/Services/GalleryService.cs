using AutoMapper;
//using ImageGallery.BL.IServices;
using ImageGallery.BL.ModelsDTO;
using ImageGallery.BL.ServicesBO;
using ImageGallery.DAL.Models.DAL;
using ImageGallery.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ImageGallery.BL.Services
{
    public class GalleryService : GalleryServiceBO
    {
        IUnitOfWork unitOfWork;

        public GalleryService(IMapper mapper, UnitOfWork unitOfWork, IUnityContainer container)
            : base(mapper, unitOfWork)
        {
            this.unitOfWork = new UnitOfWork();
        }
        public IEnumerable<GalleryDTO> LoadAll()  //из DataObj в BusinessObj
        {
            var coaches = unitOfWork.Galleries.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Galleries, GalleryDTO>()).CreateMapper();
            var res = coaches.AsEnumerable().Select(c => mapper.Map<GalleryDTO>(c)).ToList();
            return res;           
        }
     
        public GalleryDTO Load(int? id)
        {
            var coach = unitOfWork.Galleries.GetById(id);
            return new GalleryDTO { 
                Id = coach.Id, 
                IsActive = coach.IsActive, 
                OrderNo = coach.OrderNo,
                post_like = coach.post_like,
                Title = coach.Title,
                WebImageId = coach.WebImageId
            };
        }

        public void Save(GalleryDTO coachesDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Galleries, GalleryDTO>()).CreateMapper();
            var coach = mapper.Map<Galleries>(coachesDTO);
            if (coachesDTO.Id == 0) 
            {
                Add(coach); // попробывать описать по отдельности по стандарту добавление и обновление данные. Для этого ADDED и Updated нужно расписать.
            }
            else
            {
                Update(coach);
            }
            unitOfWork.Galleries.Save();
        }
        private void Add(Galleries coach)
        {
            unitOfWork.Galleries.Create(coach);
        }
        private void Update(Galleries coach)
        {
           
            unitOfWork.Galleries.Update(coach);
           
        }
      
        public void Delete(GalleryDTO coachDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Galleries, GalleryDTO>()).CreateMapper();
            var coach = mapper.Map<Galleries>(coachDTO);
            unitOfWork.Galleries.Delete(coach.Id);
            unitOfWork.Galleries.Save();
        }
    }
}

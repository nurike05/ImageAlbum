using AutoMapper;
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
    public class WebFileService : WebFileServiceBO
    {
        UnitOfWork unitOfWork;

        public WebFileService(IMapper mapper, UnitOfWork unitOfWork, IUnityContainer container)
            : base(mapper, unitOfWork)
        {
            this.unitOfWork = new UnitOfWork();
        }
       
        public IEnumerable<WebFileDTO> LoadAll()  //из DataObj в BusinessObj
        {
            var coaches = unitOfWork.WebFiles.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<WebFiles, WebFileDTO>()).CreateMapper();
            var res = coaches.AsEnumerable().Select(c => mapper.Map<WebFileDTO>(c)).ToList();
            return res;
        }


        public WebFileDTO Load(int? id)
        {
            var coach = unitOfWork.WebFiles.GetById(id);
          
            return new WebFileDTO
            {
                Id = coach.Id,
                ContentType = coach.ContentType,
                Data = coach.Data,
                FileExt = coach.FileExt,
                FileLength = coach.FileLength,
                FileName = coach.FileName,
                IsActive = coach.IsActive,
                UpdateDate = coach.UpdateDate
            };
        }

        public void Save(WebFileDTO coachesDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<WebFiles, WebFileDTO>()).CreateMapper();
            var coach = mapper.Map<WebFiles>(coachesDTO);
            if (coachesDTO.Id == 0)
            {
                Add(coach);
            }
            else
            {
                Update(coach);
            }
            unitOfWork.WebFiles.Save();
        }
        private void Add(WebFiles coach)
        {
            unitOfWork.WebFiles.Create(coach);
        }
        private void Update(WebFiles coach)
        {
            unitOfWork.WebFiles.Update(coach);
        }

        public void AddFile(WebFileDTO coachDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<WebFiles, WebFileDTO>()).CreateMapper();
            var coach = mapper.Map<WebFiles>(coachDTO);
            unitOfWork.WebFiles.Create(coach);
        }

        public void Delete(WebFileDTO coachDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<WebFiles, WebFileDTO>()).CreateMapper();
            var coach = mapper.Map<WebFiles>(coachDTO);
            unitOfWork.WebFiles.Delete(coach.Id);
            unitOfWork.WebFiles.Save();
        }
    }
}

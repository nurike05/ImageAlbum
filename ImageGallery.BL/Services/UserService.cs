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
    public class UserService : UserServiceBO
    {
        UnitOfWork unitOfWork;
     

        public UserService(IMapper mapper, UnitOfWork unitOfWork, IUnityContainer container)
            : base(mapper, unitOfWork)
        {
            this.unitOfWork = new UnitOfWork();
        }

        public IEnumerable<UserDTO> LoadAll()  //из DataObj в BusinessObj
        {
            var coaches = unitOfWork.User.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            var res = coaches.AsEnumerable().Select(c => mapper.Map<UserDTO>(c)).ToList();
            //res.ForEach(r => System.Diagnostics.Debug.WriteLine(r.Login));
            return res;
        }


        public void Save(UserDTO coachesDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            var coach = mapper.Map<User>(coachesDTO);
            if (coachesDTO.UserId == 0)
            {
                Add(coach);
            }
            else
            {
                Update(coach);
            }
            unitOfWork.User.Save();
        }
        private void Add(User coach)
        {
            unitOfWork.User.Create(coach);
        }
        private void Update(User coach)
        {
            unitOfWork.User.Update(coach);
        }
        public void AddFile(UserDTO coachDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            var coach = mapper.Map<User>(coachDTO);
            unitOfWork.User.Create(coach);
        }
        public UserDTO Load(int? id)
        {
            var coach = unitOfWork.User.GetById(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            mapper.Map(coach, this);
            return new UserDTO
            {
                UserId = coach.UserId,
                FirstName = coach.FirstName,
                LastName = coach.LastName,
                EmailID = coach.EmailID,
                DateOfBirth = coach.DateOfBirth,
                Role = coach.Role,
                Password = coach.Password,
                ConfirmPassword = coach.ConfirmPassword
            };
        }
        public void Delete(UserDTO coachDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            var coach = mapper.Map<User>(coachDTO);
            unitOfWork.User.Delete(coach.UserId);
            unitOfWork.User.Save();
        }

    }

}


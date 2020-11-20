using AutoMapper;
using ImageGallery.BL.ModelsDTO;
using ImageGallery.DAL.Models.DAL;
using ImageGallery.ViewModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace ImageGallery.App_Start
{
    public class AutomapperConfig
    {
        public static void RegisterWithUnity(UnityContainer container)
        {
            IMapper mapper = CreateMapperConfiguration().CreateMapper();
            container.RegisterInstance<IMapper>(mapper);
        }

        public static MapperConfiguration CreateMapperConfiguration()
        {
            return new MapperConfiguration(mpr =>
            {
                mpr.CreateMap<Galleries, GalleryDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<GalleryDTO>());
                mpr.CreateMap<GalleryDTO, GalleriesVM>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<GalleriesVM>());
                mpr.CreateMap<GalleriesVM, GalleryDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<GalleryDTO>());
                mpr.CreateMap<GalleryDTO, Galleries>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<Galleries>());

                mpr.CreateMap<WebFiles, WebFileDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<WebFileDTO>());
                mpr.CreateMap<WebFileDTO, WebFilesVM>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<WebFilesVM>());
                mpr.CreateMap<WebFilesVM, WebFileDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<WebFileDTO>());
                mpr.CreateMap<WebFileDTO, WebFiles>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<WebFiles>());

                mpr.CreateMap<User, UserDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<UserDTO>());
                mpr.CreateMap<UserDTO, UserVM>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<UserVM>());
                mpr.CreateMap<UserVM, UserDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<UserDTO>());
                mpr.CreateMap<UserDTO, User>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<User>());
            });
        }
    }
}

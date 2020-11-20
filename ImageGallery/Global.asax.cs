using ImageGallery.BL.Infrastructure;
using ImageGallery.BL.Services;
//using ImageGallery.Util;
//using Ninject;
//using Ninject.Modules;
//using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ImageGallery
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());
            UnityConfig.RegisterTypes();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //NinjectModule galleryService = new GalleryModule();
           
            //NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            //var kernel = new StandardKernel(galleryService, serviceModule);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}

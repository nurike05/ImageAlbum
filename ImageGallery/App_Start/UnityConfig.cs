using ImageGallery.App_Start;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace ImageGallery
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterTypes()
        {
            var container = new UnityContainer();

            container.RegisterInstance<IUnityContainer>(container);
            AutomapperConfig.RegisterWithUnity(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));


        }
    }
}
using ImageGallery.BL.ModelsDTO;
using ImageGallery.BL.Services;
//using ImageGallery.BL.ServicesBO;
using ImageGallery.Filters;
//using ImageGallery.Models.DAL;
using ImageGallery.ViewModel;
//using ImageGallery.ViewModels.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ImageGallery.Controllers
{
    /// <summary>
    /// Класс для выставление (показа) рисунков
    /// </summary>
    //[MyAuthAttribute]
    [Authorize]
    public class GalleryController : Controller
    {
        
        GalleryService galleryService;
        public GalleryController(GalleryService serv)
        {
            galleryService = serv;
        }

        // GET: Gallery
        /// <summary>
        /// Перечисление изображения в виде коробки.
        /// </summary>

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

      
        /// <summary>
        /// Cписок изображений для отображения на странице.
        /// </summary>
        /// <param name="searching"></param>
        /// <returns>Возвращает найденный данный</returns>
        [Authorize]
        public ActionResult _List()
        {
            //ImageGalleryEntities db = new ImageGalleryEntities();
            var lists = from s in galleryService.LoadAll()
                           select s;
            var list = lists.OrderBy(x => x.OrderNo)     // must be changed
                        .Select(x => new ImageList
                        {
                            Id = x.Id,
                            IsActive = x.IsActive,
                            OrderNo = x.OrderNo,
                            WebImageId = x.WebImageId,
                            Title = x.Title,
                            post_like = x.post_like
                        }).ToList();

            return PartialView(list);
        
        }

        /// <summary>
        /// Метод для прибавление like 
        /// </summary>
        /// <param name="id">Параметр id, указанный по определенному id в БД</param>
        /// <returns>Возвращение в Action метод "Index" в данном контроллере</returns>
        [Authorize]

        // Like implementation
        public ActionResult Like(int id)
        {

            var lists = from s in galleryService.LoadAll()
                        select s;
           
            GalleryDTO update = lists.Where(x => x.Id == id).FirstOrDefault();    
            if (update.IsActive)
            {
                try
                {
                    if (update.post_like == null)
                    {
                        update.post_like = 0;
                    }
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("The problem with id in GalleriesVM");
                }

                update.Id = id;
                update.post_like++;
                update.IsActive = false;
                galleryService.Save(update);                                         
            }
            else
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
    }
}
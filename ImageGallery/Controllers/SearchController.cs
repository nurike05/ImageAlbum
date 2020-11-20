using AutoMapper;
using ImageGallery.BL.ModelsDTO;
using ImageGallery.BL.Services;
using ImageGallery.ViewModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageGallery.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        GalleryService galleryService;
        public SearchController(GalleryService serv)
        {
            galleryService = serv;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searching"></param>
        /// <returns></returns>
        public ActionResult _List(string searching)
        {
            var lists = from s in galleryService.LoadAll()
                        select s;
    
            if(searching == null)
            {
                searching = "";
            }
            var list = lists.Where(c => c.Title.Contains(searching)).ToList();   
            //if (list.Count == 0)
            //{
            //    ViewBag.Message = "There is no image with current title.";
            //    return PartialView("_List.cshtml", ViewBag.Message);
            //}

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GalleryDTO, GalleriesVM>()).CreateMapper();
            var res = list.AsEnumerable().Select(c => mapper.Map<GalleriesVM>(c)).ToList();
            
            return PartialView(res);
  
        }
        public ActionResult Like(int id)
        {
          
            GalleryDTO update = galleryService.Load(id);             // must be changed
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
            update.post_like += 1;
            galleryService.Save(update);                                                           // must be changed
            return RedirectToAction("Index");
        }
    }
}
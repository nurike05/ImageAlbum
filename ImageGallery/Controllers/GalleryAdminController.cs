using AutoMapper;
using ImageGallery.BL.ModelsDTO;
using ImageGallery.BL.Services;
using ImageGallery.ViewModel.DAL;
using ImageGallery.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageGallery.Controllers
{
    public class GalleryAdminController : Controller
    {
        WebFileService webFileService;
        GalleryService galleryService;
        public GalleryAdminController(WebFileService serv, GalleryService serv2)
        {
            webFileService = serv;
            galleryService = serv2;
        }
        // GET: GalleryAdmin

        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Метод для создания нового рисунка.
        /// </summary>
        /// <returns>Возвращаем в частичную представление со свойствами моделей ImageEditorViewModel</returns>
        [Authorize]
        public ActionResult Create()
        {
            ImageEditorViewModel vm = new ImageEditorViewModel();
            ViewBag.Action = "Create";
            return PartialView(vm);
        }


        /// <summary>
        /// Добавление метода действия в GalleryAdminController, 
        ///    чтобы сохранить эти опубликованные данные в базе данных.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult Create(ImageEditorViewModel model)
        {
            var galleryLists = from s in galleryService.LoadAll()
                        select s;
            var webFileLists = from v in webFileService.LoadAll()
                        select v;
            try
            {
                if (ModelState.IsValid)
                {

                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<WebFileDTO, WebFilesVM>()).CreateMapper();

                    var fileModel = WebFileViewModel.getEntityModel(model.FileImage);
                    var coach = mapper.Map<WebFileDTO>(fileModel);

                    webFileService.Save(coach);                                   


                    var mapper3 = new MapperConfiguration(cfg => cfg.CreateMap<GalleryDTO, GalleriesVM>()).CreateMapper();

                    var entity = ImageEditorViewModel.getEnityModel(model);
                    entity.WebImageId = webFileLists.Select(c =>c.Id).LastOrDefault();
                    entity.OrderNo = galleryLists.Count() > 0 ? galleryLists.Max(x => x.OrderNo) + 1 : 1;    // must be changed
                    entity.post_like = 0;
                    var coach3 = mapper3.Map<GalleryDTO>(entity);


                    galleryService.Save(coach3);                                

                    return Json(new { success = true, Caption = model.Caption });
                }

                return Json(new { success = false, ValidationMessage = "Please check validation messages" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, ExceptionMessage = "Some error here" });
            }
        }
        [Authorize]
        public ActionResult _List()
        {
            var lists = from s in galleryService.LoadAll()
                        select s;
          
            var list = lists.OrderBy(x => x.OrderNo)         
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

    }
}
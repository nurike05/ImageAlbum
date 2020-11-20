using AutoMapper;
using ImageGallery.BL.ModelsDTO;
using ImageGallery.BL.Services;
using ImageGallery.ViewModels;
using ImageGallery.ViewModel.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ImageGallery.Controllers
{
 
    public class UserController : Controller
    {
        UserService userService;
        GalleryService galleryService;
      
        public UserController(UserService serv, GalleryService serv2)
        {
            userService = serv;
            galleryService = serv2;
        }
        
        // registration action
        [HttpGet]
        public ActionResult Registration()
        {
           
            List<SelectListItem> list = new List<SelectListItem>();
           
            ViewBag.Roles = list;
            return View();
        }
        
        // registration POST action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserVM user)
        {
            bool Status = false;
            string message;
            //Model validation
            if (ModelState.IsValid)
            {

                #region  //Email is already exist
                var isExist = IsEmailExist(user.EmailID);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                #endregion

             


                #region //password hashing
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword); //
                #endregion



                #region  //save data to database 

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserVM>()).CreateMapper();

                
                var coach = mapper.Map<UserDTO>(user);
                
                    userService.Save(coach);                


                    Status = true;
      
                #endregion
            }
            else
            {
                message = "Invalid Request";
            }

            
            ViewBag.Status = Status;
            return View(user);
        }
 
        //Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl="")
        {
            var lists = from s in userService.LoadAll()
                        select s;
            var listsGallery = from s in galleryService.LoadAll()
                        select s;
            string message = "";


                var v = lists.Where(a => a.EmailID == login.EmailID).FirstOrDefault();    // must be changed
                if (v != null)
                {
                    if (string.Compare(Crypto.Hash(login.Password), v.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);



                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Invalid credential provided";
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                }
            
                ViewBag.Message = message;
            
            
            return View();
        }

    

        //Logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
        

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            var lists = from s in userService.LoadAll()
                        select s;
          
                var v = lists.Where(a => a.EmailID == emailID).FirstOrDefault();     
                return v != null;
    
        }


    }
}
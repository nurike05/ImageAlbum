using AutoMapper;
using ImageGallery.BL.ModelsDTO;
using ImageGallery.BL.Services;
using ImageGallery.ViewModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
//using ImageGallery.Models.DAL;

namespace ImageGallery.MyRoleProvider
{
    public class SiteRole : RoleProvider
    {
        UserService userService;
        public SiteRole()
        {

        }
        
        public SiteRole(UserService serv)
        {
            userService = serv;
        }
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string emailID)
        {

            DAL.Models.DAL.ImageGalleryEntities db = new DAL.Models.DAL.ImageGalleryEntities();
          
            string data = db.User.Where(x => x.EmailID == emailID).FirstOrDefault().Role;
            string[] result = { data };
            return result;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;

          
            DAL.Models.DAL.ImageGalleryEntities db = new DAL.Models.DAL.ImageGalleryEntities();
            var user = db.User.Where(u => u.EmailID == username).FirstOrDefault();
                if(user != null)
                {
                    var userRole = db.User.Where(u => u.Role == roleName).FirstOrDefault();
                    if (userRole != null && userRole.Role == roleName)
                        outputResult = true;
                }
          
            return outputResult;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
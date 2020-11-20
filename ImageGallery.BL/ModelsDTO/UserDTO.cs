using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.BL.ModelsDTO
{
    public partial class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

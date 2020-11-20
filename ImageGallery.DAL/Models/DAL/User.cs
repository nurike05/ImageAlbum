namespace ImageGallery.DAL.Models.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
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

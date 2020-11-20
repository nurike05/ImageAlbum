namespace ImageGallery.DAL.Models.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ImageGalleryEntities : DbContext
    {
        public ImageGalleryEntities()
            : base("name=ImageGalleryEntities")
        {
        }

        public virtual DbSet<Galleries> Galleries { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WebFiles> WebFiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}


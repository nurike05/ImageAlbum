using ImageGallery.DAL.Models.DAL;
using ImageGallery.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        ImageGalleryEntities dbContext;
        public UnitOfWork()
        {
            dbContext = new ImageGalleryEntities();
        }

        BaseRepository<Galleries> galleries;
        BaseRepository<User> user;
        BaseRepository<WebFiles> webFiles;

        public BaseRepository<Galleries> Galleries
        {
            get
            {
                if (galleries == null)
                    galleries = new BaseRepository<Galleries>(dbContext);
                return galleries;
            }
        }

        public BaseRepository<User> User
        {
            get
            {
                if (user == null)
                    user = new BaseRepository<User>(dbContext);
                return user;
            }
        }

        public BaseRepository<WebFiles> WebFiles
        {
            get
            {
                if (webFiles == null)
                    webFiles = new BaseRepository<WebFiles>(dbContext);
                return webFiles;
            }
        }




        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using ImageGallery.DAL.Models.DAL;
using ImageGallery.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        BaseRepository<Galleries> Galleries { get; }
        BaseRepository<User> User { get; }
        BaseRepository<WebFiles> WebFiles { get; }

        void Save();

    }
}

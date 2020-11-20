using ImageGallery.DAL.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int? id);
        IEnumerable<T> GetAll();
        void Create(T item);
        //void Detached(T item);
        void Update(T item); // Для обновления данных

        void Delete(int id);
        void Save();
    }
}

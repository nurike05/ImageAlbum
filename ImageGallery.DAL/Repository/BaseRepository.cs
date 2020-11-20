using ImageGallery.DAL.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.DAL.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private ImageGalleryEntities db;
        private IDbSet<T> dbSet;
        public BaseRepository(ImageGalleryEntities db)
        {
            this.db = db;
            dbSet = db.Set<T>();
        }
   

        public void Create(T item)
        {
            dbSet.Add(item);
        }

        public void Delete(int id)
        {
            T item = GetById(id);
            dbSet.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public T GetById(int? id)
        {
            return dbSet.Find(id);
        }

        

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Galleries item)
        {
            var entity = db.Galleries.Where(c => c.Id == item.Id).AsQueryable().FirstOrDefault();
            db.Entry(entity).CurrentValues.SetValues(item);
        }


        public void Update(T item)
        {
             db.Entry(item).State = EntityState.Modified;
        }

    }
}

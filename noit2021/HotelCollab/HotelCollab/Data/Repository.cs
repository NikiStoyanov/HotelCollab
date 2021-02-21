using Microsoft.EntityFrameworkCore;
using System;

namespace HotelCollab.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        ApplicationDbContext AppDbContext;
        DbSet<T> dbSet;

        public Repository(ApplicationDbContext appDbContext)
        {
            this.AppDbContext = appDbContext;
            this.dbSet = appDbContext.Set<T>();
        }

        public void Add(T model)
        {
            this.AppDbContext.Add<T>(model);
        }

        public void Delete(T model)
        {
            this.AppDbContext.Remove<T>(model);
        }

        public T Get(Guid id)
        {
            return dbSet.Find(id);
        }

        public void Update(T model)
        {
            this.AppDbContext.Update<T>(model);
        }
    }
}

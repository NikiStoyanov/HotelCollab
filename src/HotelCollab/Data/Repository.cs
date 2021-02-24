using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HotelCollab.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext AppDbContext;
        private readonly DbSet<T> dbSet;

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

        public T Get(string id)
        {
            return dbSet.Find(id);
        }

        public void Update(T model)
        {
            this.AppDbContext.Update<T>(model);
        }

        public void SaveChanges()
        {
            AppDbContext.SaveChanges();
        }
    }
}

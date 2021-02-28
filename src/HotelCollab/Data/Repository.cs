﻿using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(T model)
        {
            await this.AppDbContext.AddAsync<T>(model);

            await AppDbContext.SaveChangesAsync();
        }

        public void Delete(T model)
        {
            this.AppDbContext.Remove<T>(model);
        }

        public async Task<T> GetAsync(string id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(T model)
        {
            this.AppDbContext.Update<T>(model);
        }
    }
}

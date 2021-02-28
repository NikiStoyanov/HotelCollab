using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Data
{
    public interface IRepository<T> where T : class
    {
        public Task AddAsync(T model);

        public void Update(T model);

        public void Delete(T model);

        public Task<T> GetAsync(string id);

    }
}

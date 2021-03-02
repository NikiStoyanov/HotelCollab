using HotelCollab.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Services.Interfaces
{
    public interface IRequestService
    {
        public Task<List<Request>> GetAllRequestsAsync();
    }
}

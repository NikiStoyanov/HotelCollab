using HotelCollab.Data;
using HotelCollab.Data.Models;
using HotelCollab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<Request> requestRepo;

        public RequestService(IRepository<Request> requestRepo)
        {
            this.requestRepo = requestRepo;
        }

        public async Task<List<Request>> GetAllRequestsAsync()
        {
            var requests = await requestRepo.GetAllAsync();

            return requests;
        }
    }
}

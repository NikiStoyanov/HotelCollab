using HotelCollab.Data;
using HotelCollab.Data.Models;
using HotelCollab.Services.Interfaces;
using HotelCollab.ViewModels.Hotels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<Request> requestRepo;
        private readonly IRepository<Hotel> hotelRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public RequestService(IRepository<Request> requestRepo, IRepository<Hotel> hotelRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.requestRepo = requestRepo;
            this.hotelRepo = hotelRepo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateRequestAsync(GetHotelsViewModel model)
        {
            model.Hotels = await hotelRepo.GetAllAsync();
            var request = new Request()
            {
                Role = model.Role,
                Hotel = model.Hotels.Where(h => h.Id == model.HotelId).FirstOrDefault(),
                UserId = httpContextAccessor.HttpContext.User.FindFirst("Id").Value,
            };

            await requestRepo.AddAsync(request);
            await requestRepo.SaveChangesAsync();

        }

        public async Task<List<Request>> GetAllRequestsAsync()
        {
            var requests = await requestRepo.GetAllAsync();

            return requests;
        }
    }
}

using HotelCollab.Data;
using HotelCollab.Data.Models;
using HotelCollab.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> userRepo;

        public UserService(IRepository<ApplicationUser> userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpGet]
        public async Task<string> GetUserFirstNameAsync(string id)
        {
            var firstName = string.Empty;

            await Task.Run(() =>
            {
                firstName = userRepo.GetAsync(id).Result.FirstName;
            });
            
            return firstName;
        }
    }
}

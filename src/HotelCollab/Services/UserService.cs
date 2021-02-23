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
        public string GetUserFirstName(string id)
        {
            var firstName = userRepo.Get(id).FirstName;
            return firstName;
        }
    }
}

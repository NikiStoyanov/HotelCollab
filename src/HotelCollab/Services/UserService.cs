using HotelCollab.Data;
using HotelCollab.Data.Models;
using HotelCollab.Services.Interfaces;
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

        public void ChangeUserName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

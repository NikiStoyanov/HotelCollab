﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Services.Interfaces
{
    public interface IUserService
    {
        public Task<string> GetUserFirstNameAsync(string id);
    }
}

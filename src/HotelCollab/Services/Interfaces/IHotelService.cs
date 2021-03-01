using HotelCollab.Data.Models;
using HotelCollab.ViewModels.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Services.Interfaces
{
    public interface IHotelService
    {
        public Task AddHotelAsync(HotelRegisterViewModel model);

        public Task<List<Hotel>> GetAllHotelsAsync();
    }
}

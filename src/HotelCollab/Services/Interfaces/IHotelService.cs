using HotelCollab.ViewModels.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Services.Interfaces
{
    public interface IHotelService
    {
        public Task AddHotelAsync(HotelRegisterViewModel model);
    }
}

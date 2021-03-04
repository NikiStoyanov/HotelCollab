using HotelCollab.Areas.Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Services.Interfaces
{
    public interface IReservationService
    {
        public Task AddReservationAsync(AddReservationViewModel model);
    }
}

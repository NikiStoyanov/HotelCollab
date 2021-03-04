using HotelCollab.Areas.Manager.ViewModels;
using HotelCollab.Data;
using HotelCollab.Data.Models;
using HotelCollab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> reservationRepo;

        public ReservationService(IRepository<Reservation> reservationRepo)
        {
            this.reservationRepo = reservationRepo;
        }

        public async Task AddReservationAsync(AddReservationViewModel model)
        {
            var year = DateTime.Now.Year;
            var pass = $"defaultPassword_{year}";

            var guest = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PasswordHash = pass.GetHashCode().ToString(),
            };

            var reservation = new Reservation()
            {
                Guest = guest,
                StartDate = DateTime.Parse(model.From),
                EndDate = DateTime.Parse(model.To),
                Adults = model.Adults,
                Children = model.Children,

            };

            reservation.Room.RoomNumber = model.RoomNumber;
        }
    }
}

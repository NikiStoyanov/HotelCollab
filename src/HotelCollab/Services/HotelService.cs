namespace HotelCollab.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HotelCollab.Data;
    using HotelCollab.Data.Models;
    using HotelCollab.Services.Interfaces;

    public class HotelService : IHotelService
    {
        public HotelService(IRepository<Hotel> hotelRepo)
        {

        }

        public void AddHotel()
        {
            throw new NotImplementedException();
        }
    }
}

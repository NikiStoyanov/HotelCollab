using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelCollab.Data;
using HotelCollab.Data.Models;

namespace HotelCollab.ViewModels.Hotels
{
    public class GetHotelsViewModel
    {
        public GetHotelsViewModel()
        {
            this.RenderedHotels = new List<HotelRenderViewModel>();
            this.Hotels = new List<Hotel>();
        }

        public List<Hotel> Hotels { get; set; }
        public string HotelId { get; set; }

        public string Role { get; set; }

        public List<HotelRenderViewModel> RenderedHotels { get; set; }
    }
}

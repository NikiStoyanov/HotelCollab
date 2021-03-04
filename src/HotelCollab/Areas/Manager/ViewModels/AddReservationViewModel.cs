using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Manager.ViewModels
{
    public class AddReservationViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Email { get; set; }

        public string RoomNumber { get; set; }

        public int Adults { get; set; }

        public int Children { get; set; }
    }
}

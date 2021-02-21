namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Reservation
    {
        public Reservation()
        {
            this.ReservationId = Guid.NewGuid().ToString();

            this.Feedbacks = new HashSet<Feedback>();
        }

        public string ReservationId { get; private set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int Adults { get; set; }

        [Required]
        public int Children { get; set; }

        [Required]
        public string RoomId { get; set; }

        public Room Room { get; set; }

        [Required]
        public string HotelId { get; set; }

        public Hotel Hotel { get; set; }

        [Required]
        public string ReceptionistId { get; set; }

        public ApplicationUser Receptionist { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}

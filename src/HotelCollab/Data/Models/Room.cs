namespace HotelCollab.Data.Models
{
    using HotelCollab.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Room
    {
        public Room()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Reservations = new HashSet<Reservation>();
        }

        public string Id { get; private set; }

        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public string HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        [Required]
        public int Floor { get; set; }

        [Required]
        public RoomType RoomType { get; set; }

        public bool IsBusy { get; set; }

        public bool IsCleaned { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Cleaning> Cleanings { get; set; }
    }
}

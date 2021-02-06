﻿namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using HotelCollab.Data.Models.Enums;

    public class Room
    {
        public Room()
        {
            this.RoomId = Guid.NewGuid().ToString();
            this.Reservations = new HashSet<Reservation>();
        }

        public string RoomId { get; private set; }

        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public string HotelId { get; set; }

        public Hotel Hotel { get; set; }

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

﻿namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using HotelCollab.Data.Models.Enums;

    public class Hotel
    {
        public Hotel()
        {
            this.HotelId = Guid.NewGuid().ToString();

            this.Rooms = new HashSet<Room>();
            this.Reservations = new HashSet<Reservation>();
            this.Events = new HashSet<Event>();
        }

        public Hotel(string imageUrl)
            : this()
        {
            this.ImageUrl = imageUrl;
        }

        public string HotelId { get; private set; }

        [Required]
        [Range(10, 100)]
        public string Name { get; set; }

        public string ImageUrl { get; private set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        public string TownId { get; set; }

        public Town Town { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        public HotelStars HotelStars { get; set; }

        [Required]
        public int CleaningPeriod { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
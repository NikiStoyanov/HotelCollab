﻿namespace HotelCollab.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Request
    {
        public Request()
        {
            this.Id = Guid.NewGuid().ToString();

            this.CreatedOn = DateTime.UtcNow;
        }

        public string Id { get; private set; }

        public DateTime CreatedOn { get; private set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}

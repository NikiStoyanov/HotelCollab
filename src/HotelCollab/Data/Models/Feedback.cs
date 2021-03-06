﻿namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Feedback
    {
        public Feedback()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }

        [Required]
        public string GuestId { get; set; }

        public virtual ApplicationUser Guest { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(50)]
        public string Title { get; set; }

        [MinLength(20)]
        [MaxLength(250)]
        public string Content { get; set; }

        [Required]
        public string ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }

        public string ProcessedByEmployeeId { get; set; }

        public virtual ApplicationUser ProcessedByEmployee { get; set; }
    }
}

namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Feedback
    {
        public Feedback()
        {
            this.FeedbackId = Guid.NewGuid().ToString();
        }

        public string FeedbackId { get; private set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [Range(20, 50)]
        public string Title { get; set; }

        [Range(20, 250)]
        public string Content { get; set; }

        [Required]
        public string ReservationId { get; set; }

        public Reservation Reservation { get; set; }
    }
}

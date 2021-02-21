namespace HotelCollab.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Request
    {
        public Request()
        {
            this.RequestId = Guid.NewGuid().ToString();
        }

        public string RequestId { get; private set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}

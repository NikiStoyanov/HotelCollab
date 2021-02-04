namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Request
    {
        public Request()
        {
            this.RequestId = Guid.NewGuid().ToString();

            // createdOn
        }

        public string RequestId { get; private set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}

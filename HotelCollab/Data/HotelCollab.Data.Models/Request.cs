namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Request
    {
        public Request()
        {
            this.RequestId = Guid.NewGuid().ToString();
        }

        public string RequestId { get; private set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}

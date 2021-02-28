// ReSharper disable VirtualMemberCallInConstructor
namespace HotelCollab.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.EmailConfirmed = true;

            this.Roles = new HashSet<ApplicationUserRole>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();

            this.Requests = new HashSet<Request>();
            this.Feedbacks = new HashSet<Feedback>();
            this.Cleanings = new HashSet<Cleaning>();
            this.Reservations = new HashSet<Reservation>();
            this.ProcessedFeedbacks = new HashSet<Feedback>();
            this.UserHotels = new HashSet<UserHotels>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<ApplicationUserRole> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Request> Requests { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<Cleaning> Cleanings { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Feedback> ProcessedFeedbacks { get; set; }

        public virtual ICollection<UserHotels> UserHotels { get; set; }
    }
}

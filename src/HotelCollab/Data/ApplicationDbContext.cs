namespace HotelCollab.Data
{
    using HotelCollab.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Damage> Damages { get; set; }

        public DbSet<Cleaning> Cleanings { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();


            builder.Entity<Request>()
                .HasOne(r => r.User)
                .WithMany(u => u.Requests)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Requests)
                .WithOne(r => r.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Hotel>()
                .HasOne(h => h.Town)
                .WithMany(t => t.Hotels)
                .HasForeignKey(h => h.TownId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Town>()
                .HasMany(x => x.Hotels)
                .WithOne(x => x.Town);
                

            builder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reservation>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Reservations)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reservation>()
                .HasOne(res => res.Room)
                .WithMany(rm => rm.Reservations)
                .HasForeignKey(res => res.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reservation>()
                .HasOne(r => r.Receptionist)
                .WithMany(r => r.Reservations)
                .HasForeignKey(r => r.ReceptionistId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Event>()
                .HasOne(e => e.Hotel)
                .WithMany(h => h.Events)
                .HasForeignKey(e => e.HotelId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Feedback>()
                .HasOne(f => f.Guest)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.GuestId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Feedback>()
                .HasOne(f => f.ProcessedByEmployee)
                .WithMany(u => u.ProcessedFeedbacks)
                .HasForeignKey(f => f.ProcessedByEmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Feedback>()
                .HasOne(f => f.Reservation)
                .WithMany(r => r.Feedbacks)
                .HasForeignKey(f => f.ReservationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Cleaning>()
                .HasOne(c => c.Cleaner)
                .WithMany(c => c.Cleanings)
                .HasForeignKey(c => c.CleanerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Cleaning>()
                .HasOne(c => c.Room)
                .WithMany(r => r.Cleanings)
                .HasForeignKey(c => c.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Damage>()
                .HasOne(d => d.Cleaning)
                .WithMany(c => c.Damages)
                .HasForeignKey(d => d.CleaningId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserHotels>()
                .HasKey(uh => new { uh.UserId, uh.HotelId });

            builder.Entity<UserHotels>()
                .HasOne(uh => uh.User)
                .WithMany(u => u.UserHotels)
                .HasForeignKey(uh => uh.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserHotels>()
                .HasOne(uh => uh.Hotel)
                .WithMany(h => h.UserHotels)
                .HasForeignKey(uh => uh.HotelId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserHotels>()
                .HasOne(uh => uh.Role)
                .WithMany(r => r.UserHotels)
                .HasForeignKey(uh => uh.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                .HasMany(x => x.UserHotels)
                .WithOne(x => x.User);

            builder.Entity<Hotel>()
               .HasMany(x => x.UserHotels)
               .WithOne(x => x.Hotel);

            builder.Entity<ApplicationUserRole>()
                .HasOne(ur => ur.Hotel)
                .WithMany(h => h.UserRoles)
                .HasForeignKey(ur => ur.HotelId);

            builder.Entity<Request>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Requests)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<ApplicationUserRole>()
            //    .ToTable("AspNetUserRoles");
        }
    }
}

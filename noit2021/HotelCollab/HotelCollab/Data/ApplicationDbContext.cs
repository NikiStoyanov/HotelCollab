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

        public ApplicationDbContext()
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

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();


            builder.Entity<Request>()
                .HasOne(r => r.User)
                .WithMany(u => u.Requests)
                .HasForeignKey(r => r.UserId);

            builder.Entity<Hotel>()
                .HasOne(h => h.Town)
                .WithMany(t => t.Hotels)
                .HasForeignKey(h => h.TownId);

            builder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId);

            builder.Entity<Reservation>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Reservations)
                .HasForeignKey(r => r.HotelId);

            builder.Entity<Reservation>()
                .HasOne(res => res.Room)
                .WithMany(rm => rm.Reservations)
                .HasForeignKey(res => res.RoomId);

            builder.Entity<Reservation>()
                .HasOne(r => r.Receptionist)
                .WithMany(r => r.Reservations)
                .HasForeignKey(r => r.ReceptionistId);

            builder.Entity<Event>()
                .HasOne(e => e.Hotel)
                .WithMany(h => h.Events)
                .HasForeignKey(e => e.HotelId);

            builder.Entity<Feedback>()
                .HasOne(f => f.Guest)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.GuestId);

            builder.Entity<Feedback>()
                .HasOne(f => f.ProcessedByEmployee)
                .WithMany(u => u.ProcessedFeedbacks)
                .HasForeignKey(f => f.ProcessedByEmployeeId);

            builder.Entity<Feedback>()
                .HasOne(f => f.Reservation)
                .WithMany(r => r.Feedbacks)
                .HasForeignKey(f => f.ReservationId);

            builder.Entity<Cleaning>()
                .HasOne(c => c.Cleaner)
                .WithMany(c => c.Cleanings)
                .HasForeignKey(c => c.CleanerId);

            builder.Entity<Cleaning>()
                .HasOne(c => c.Room)
                .WithMany(r => r.Cleanings)
                .HasForeignKey(c => c.RoomId);

            builder.Entity<Damage>()
                .HasOne(d => d.Cleaning)
                .WithMany(c => c.Damages)
                .HasForeignKey(d => d.CleaningId);

            builder.Entity<ApplicationUserRole>()
                .ToTable("AspNetUserRoles");
        }
    }
}

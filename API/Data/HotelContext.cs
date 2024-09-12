using DomainModels;

using Microsoft.EntityFrameworkCore;

namespace API.Data
{
	public class HotelContext : DbContext
	{
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public HotelContext(DbContextOptions<HotelContext> dbContextOptions) : base(dbContextOptions)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=ep-lingering-darkness-a2ju0sof.eu-central-1.aws.neon.tech;Port=5432;Database=H2;Username=H2;Password=1TLNuqZtK8Yv;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Room>()
            //   .HasOne(r => r.BookingId)
            //   .WithOne(rb => rb.Room)
            //   .HasForeignKey<Room>(r => r.RoomBookingId)
            //   .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Booking>()
            //    .HasOne(rb => rb.UserId)
            //    .WithMany(u => u.RoomBookings)
            //    .HasForeignKey(rb => rb.UserId);

            //modelBuilder.Entity<RoomBooking>()
            //    .HasOne(rb => rb.Room)
            //    .WithOne(r => r.RoomBooking)
            //    .HasForeignKey<RoomBooking>(rb => rb.RoomId)
        } 

    }
}
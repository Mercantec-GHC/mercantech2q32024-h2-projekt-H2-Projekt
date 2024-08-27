using API.Models;

using Microsoft.EntityFrameworkCore;

namespace API.Data
{
	public class HotelContext : DbContext
	{
		public DbSet<User> users { get; set; }
		public DbSet<Booking> bookings { get; set; }
		public DbSet<Room> rooms { get; set; }

        public HotelContext(DbContextOptions<HotelContext> dbContextOptions) : base(dbContextOptions)
        {
			
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=ep-lingering-darkness-a2ju0sof.eu-central-1.aws.neon.tech;Port=5432;Database=H2;Username=H2;Password=1TLNuqZtK8Yv;");
		}
	}
}
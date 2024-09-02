using DomainModels;

using Microsoft.EntityFrameworkCore;

namespace API.Data
{
	public class HotelContext : DbContext
	{
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<User> Users { get; set; }

        public HotelContext(DbContextOptions<HotelContext> dbContextOptions) : base(dbContextOptions)
        {}
	}
}
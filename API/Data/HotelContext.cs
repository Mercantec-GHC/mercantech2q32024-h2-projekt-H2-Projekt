using API.Models;

using Microsoft.EntityFrameworkCore;

namespace API.Data
{
	public class HotelContext : DbContext
	{

		public DbSet<Administrator> administrators { get; set; }
		public DbSet<Booking> bookings { get; set; }
		public DbSet<Cleaning> cleaningEmployees { get; set; }
		public DbSet<Employee> employees { get; set; }
		public DbSet<Guest> guests { get; set; }
		public DbSet<Receptionist> receptionists { get; set; }
		public DbSet<Room> rooms { get; set; }
		public DbSet<User> users { get; set; }

        public HotelContext(DbContextOptions<HotelContext> dbContextOptions) : base(dbContextOptions)
        {}
	}
}
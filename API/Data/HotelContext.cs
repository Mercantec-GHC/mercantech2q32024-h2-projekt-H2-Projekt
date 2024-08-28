using DomainModels;

using Microsoft.EntityFrameworkCore;

namespace API.Data
{
	public class HotelContext : DbContext
	{

		public DbSet<Administrator> Administrators { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Cleaning> CleaningEmployees { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Guest> Guests { get; set; }
		public DbSet<Receptionist> Receptionists { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<User> Users { get; set; }

        public HotelContext(DbContextOptions<HotelContext> dbContextOptions) : base(dbContextOptions)
        {}
	}
}
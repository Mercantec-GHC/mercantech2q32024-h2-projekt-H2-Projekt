using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
	[Table("users")]
	public class User
	{
		[Column("user_id")]
        public int UserId { get; set; }
        [Column("user_name")]
        public string UserName { get; set; } = null!;
		[Column("password")]
        public string Password { get; set; } = null!;
		[Column("name")]
		public string Name { get; set; } = null!;
		[Column("user_phone")]
        public string? PhoneNr { get; set; }
		[Column("email")]
        public string? Email { get; set; }
		[Column("bookings")]
        public List<Booking> Bookings { get; set; } = new List<Booking>();

		public void DeleteOwnGuestAccount()
		{ }

		public void CreateOwnGuestAccount(string userName, string password)
		{ }

		public void AddTickets()
		{ }

		public void CreateBooking()
		{ }

		public void DeleteOwnBooking()
		{ }

		public void AddOwnBooking()
		{ }
	}
}
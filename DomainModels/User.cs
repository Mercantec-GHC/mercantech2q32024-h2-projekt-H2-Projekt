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
		[Column("user_id")]
        public string? PhoneNr { get; set; }
		[Column("email")]
        public string? Email { get; set; }
		[Column("booking_ids")]
        public List<int> BookingIds { get; set; } = new List<int>();

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
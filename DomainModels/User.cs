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

	// A DTO classes used in the API controlleres
	public class UserGetDTO
	{
		public int id { get; set; }
		public string userName { get; set; } 
		public List<Booking> bookings { get; set; } = new List<Booking>();
	}


	public class UserCreateDTO
	{
        public string userName { get; set; } = null!;
        public string password { get; set; } = null!;
        public string name { get; set; } = null!;
        public string? phoneNr { get; set; }
        public string? email { get; set; }
    }
}
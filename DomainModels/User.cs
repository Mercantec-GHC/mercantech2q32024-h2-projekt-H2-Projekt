using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
	public class User
	{
        public int UserId { get; set; }
		public string FullName { get; set; } = null!;
		public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
		public string Role { get; set; } = null!;
        public string? PhoneNr { get; set; }
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
		public int UserId { get; set; }
		public string FullName { get; set; } 
		public string Role { get; set; }
		public List<Booking> Bookings { get; set; } = new List<Booking>();
	}


	public class UserPostDTO
	{
		public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? PhoneNr { get; set; }
		public string Email { get; set; } = null!;
    }

	public class UserPutDTO
	{
		public string FullName { get; set; } = null!;
		public string Password { get; set; } = null!;
		public string? PhoneNr { get; set; }
		public string Email { get; set; } = null!;
	}
}
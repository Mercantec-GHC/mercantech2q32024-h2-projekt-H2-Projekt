using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
	public class User
	{
		public int id { get; set; }
		public string userName { get; set; } = null!;
		public string password { get; set; } = null!;
		public string name { get; set; } = null!;
		public string? phoneNr { get; set; }
		public string? email { get; set; }
		public List<int> bookingIds { get; set; } = new List<int>();

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
	internal class User
	{
		private string userName { get; set; } = null!;
		private string password { get; set; } = null!;
		public string name { get; set; } = null!;
		private string? phoneNr { get; set; }
		private string? email { get; set; }
		private List<int> bookingIds { get; set; } = new List<int>();

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

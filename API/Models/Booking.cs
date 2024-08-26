using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    internal class Booking
    {
        List<Room> rooms { get; set; } = new List<Room>();
        string guestName { get; set; }
        string guestEmail { get; set; }
        string guestPhoneNr { get; set; }
        List<DateOnly> bookingDates { get; set; } = new List<DateOnly>();

        public void GetRoomAvailability()
        {

        }
    }
}

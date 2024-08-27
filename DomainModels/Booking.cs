using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Booking
    {
        public int id { get; set; }
        public List<Room> rooms { get; set; } = new List<Room>();
        public string guestName { get; set; }
        public string guestEmail { get; set; }
        public string guestPhoneNr { get; set; }
        public List<DateOnly> bookingDates { get; set; } = new List<DateOnly>();

        public void GetRoomAvailability()
        {

        }
    }
}

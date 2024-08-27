using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Booking
    {
        public int id { get; set; }
        List<int> rooms { get; set; } = new List<int>();
        string guestName { get; set; }
        string guestEmail { get; set; }
        string guestPhoneNr { get; set; }

        public void GetRoomAvailability()
        {

        }
    }
}

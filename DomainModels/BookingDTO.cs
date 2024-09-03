using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class CreateBookingDTO
    {
        public int RoomId { get; set; }
        public int? UserId { get; set; }
        public string GuestName { get; set; } = null!;
        public string GuestEmail { get; set; } = null!;
        public string? GuestPhoneNr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class UpdateBookingDTO
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}




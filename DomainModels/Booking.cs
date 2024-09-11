using System.Text.Json.Serialization;

namespace DomainModels
{
    public class Booking
    {
        public int BookingId { get; set; }
        public Room Room { get; set; } = null!;
        public string GuestName { get; set; } = null!;
        public string GuestEmail { get; set; } = null!;
        public string? GuestPhoneNr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 


        public void GetRoomAvailability()
        {}
    }
}

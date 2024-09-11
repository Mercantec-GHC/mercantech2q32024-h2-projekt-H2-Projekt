using System.Text.Json.Serialization;

namespace DomainModels
{
    public class Booking
    {
        [JsonPropertyName("bookingId")]
        public int BookingId { get; set; }
        [JsonPropertyName("room")]
        public Room Room { get; set; } = null!;

        [JsonPropertyName("guestName")]
        public string GuestName { get; set; } = null!;
        [JsonPropertyName("guestEmail")]
        public string GuestEmail { get; set; } = null!;
        [JsonPropertyName("guestPhoneNr")]
        public string? GuestPhoneNr { get; set; }
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }
        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; } 
    }
}

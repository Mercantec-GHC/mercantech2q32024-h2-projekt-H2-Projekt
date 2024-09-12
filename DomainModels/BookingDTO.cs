using System.Data;

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
    public class GetBookingDTO
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public string GuestName { get; set; } = null!;
        public string GuestEmail { get; set; } = null!;
        public string? GuestPhoneNr { get; set; }
        public string RoomType { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<DateTime> BookedDays { get; set; } = new List<DateTime>();

        static public GetBookingDTO FromBooking(Booking booking)
        {
            List<DateTime> selectedDays = booking.Room.BookedDays.Where(d => d >= booking.StartDate && d < booking.EndDate).ToList();
            return new GetBookingDTO
            {
                BookingId = booking.BookingId,
                RoomId = booking.Room.RoomId,
                GuestName = booking.GuestName,
                GuestEmail = booking.GuestEmail,
                GuestPhoneNr = booking.GuestPhoneNr,
                RoomType = booking.Room.Type,
                BookedDays = selectedDays,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate
            };
        }
    }
    public class UpdateBookingDTO
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public string GuestName { get; set; } = null!;
        public string GuestEmail { get; set; } = null!;
        public string? GuestPhoneNr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}




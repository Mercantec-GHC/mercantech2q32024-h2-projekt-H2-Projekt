using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    [Table("bookings")]
    public class Booking
    {
        [Column("booking_id")]
        public int BookingId { get; set; }
        [Column("room_id")]
        public Room RoomId { get; set; } = null!;
        [Column("guest_name")]
        public string GuestName { get; set; } = null!;
        [Column("guest_email")]
        public string? GuestEmail { get; set; }
        [Column("guest_phone_nr")]
        public string? GuestPhoneNr { get; set; }
        [Column("booking_dates")]
        public List<DateTime> BookingDates { get; set; } = new List<DateTime>();
        //[Column("user_id")]
        //public User UserId { get; set; }


        public void GetRoomAvailability()
        {

        }
    }
}

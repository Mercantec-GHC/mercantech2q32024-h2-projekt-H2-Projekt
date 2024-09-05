﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Booking
    {
        public int BookingId { get; set; }
        public Room Room { get; set; } = null!;
        public string GuestName { get; set; } = null!;
        public string GuestEmail { get; set; } = null!;
        public string? GuestPhoneNr { get; set; }
        public List<DateTime> BookingDates { get; set; } = new List<DateTime>();
        //[Column("user_id")]
        //public User UserId { get; set; }


        public void GetRoomAvailability()
        {}
    }
}

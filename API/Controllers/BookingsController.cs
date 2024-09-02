using Microsoft.AspNetCore.Mvc;
using API.Data;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BookingsController : ControllerBase
	{
		private readonly HotelContext _hotelContext;

		public BookingsController(HotelContext hotelContext)
		{
			_hotelContext = hotelContext;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
		{
			var bookings = await _hotelContext.Bookings.ToArrayAsync();
			return Ok(bookings);
		}

		[HttpGet("id/{BookingId}")]
        public async Task<ActionResult<Booking>> GetBookingById(int BookingId)
        {
            var booking = await _hotelContext.Bookings.FindAsync(BookingId);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

		[HttpGet("name/{GuestName}")]
        public async Task<ActionResult<Booking>> GetBookingByGuestName(string GuestName)
        {
            var booking = await _hotelContext.Bookings.FindAsync(GuestName);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

		[HttpGet("email/{GuestEmail}")]
        public async Task<ActionResult<Booking>> GetBookingByGuestEmail(string GuestEmail)
        {
            var booking = await _hotelContext.Bookings.FindAsync(GuestEmail);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpGet("phone/{GuestPhoneNr}")]
        public async Task<ActionResult<Booking>> GetBookingByGuestPhoneNr(string GuestPhoneNr)
        {
            var booking = await _hotelContext.Bookings.FindAsync(GuestPhoneNr);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

       

        [HttpPost]
		public void PostBooking(Booking booking)
		{
			_hotelContext.Bookings.Add(booking);
			_hotelContext.SaveChanges();
		}
	}
}
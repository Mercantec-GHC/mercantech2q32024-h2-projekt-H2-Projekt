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

		[HttpGet("all")]
		public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
		{
			var bookings = await _hotelContext.Bookings.Include(b => b.Room).ToArrayAsync();
			return Ok(bookings);
		}

        [HttpGet("id/{BookingId}")]
        public async Task<ActionResult<Booking>> GetBookingById(int BookingId)
        {
            
            var booking = await _hotelContext.Bookings
                .Where(b => b.BookingId == BookingId)
                .Include(b => b.Room)
                .FirstOrDefaultAsync();
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

		[HttpGet("name/{GuestName}")]
        public async Task<ActionResult<Booking>> GetBookingByGuestName(string GuestName)
        {
            var booking = await _hotelContext.Bookings
                .Where(b => b.GuestName == GuestName)
                .Include(b => b.Room)
                .FirstOrDefaultAsync();
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

		[HttpGet("email/{GuestEmail}")]
        public async Task<ActionResult<Booking>> GetBookingByGuestEmail(string GuestEmail)
        {
            var booking = await _hotelContext.Bookings
                .Where(b => b.GuestEmail == GuestEmail)
                .Include(b => b.Room)
                .FirstOrDefaultAsync();
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpGet("phone/{GuestPhoneNr}")]
        public async Task<ActionResult<Booking>> GetBookingByGuestPhoneNr(string GuestPhoneNr)
        {
            var booking = await _hotelContext.Bookings
                .Where(b => b.GuestPhoneNr == GuestPhoneNr)
                .Include(b => b.Room)
                .FirstOrDefaultAsync();
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

       

        [HttpPost("add")]
		public ActionResult AddBooking(CreateBookingDTO bookingDTO)
		{
            var room = _hotelContext.Rooms.Find(bookingDTO.RoomId);
            if (room == null)
            {
                return NotFound("room not found");
            }

            //var user = _hotelContext.Users.Find(bookingDTO.UserId);
            //if (user == null)
            //{
            //    return NotFound("user not found");
            //}

            if (bookingDTO.StartDate >= bookingDTO.EndDate)
            {
                return BadRequest("Invalid date range");
            }

            if (bookingDTO.StartDate < DateTime.Now)
            {
                return BadRequest("Invalid date range");
            }


            var booking = new Booking
            {
                Room = room,
                GuestName = bookingDTO.GuestName,
                GuestEmail = bookingDTO.GuestEmail,
                GuestPhoneNr = bookingDTO.GuestPhoneNr,
                StartDate = bookingDTO.StartDate,
                EndDate = bookingDTO.EndDate
            }; 
            _hotelContext.Bookings.Add(booking);
			_hotelContext.SaveChanges();

            return Ok("Done");
        }

        [HttpPut("update")]
        [ProducesResponseType(204)]
        public ActionResult UpdateBooking(UpdateBookingDTO bookingDTO)
        {

            if (bookingDTO.BookingId <= 0)
            {
                return BadRequest("Invalid booking id");
            }

            var booking = _hotelContext.Bookings.Find(bookingDTO.BookingId);
            if (booking == null)
            {
                return NotFound("booking not found");
            }

            var room = _hotelContext.Rooms.Find(bookingDTO.RoomId);


            if (room == null)
            {
                return NotFound("room not found");
            }

            var user = _hotelContext.Users.Find(bookingDTO.UserId);
            if (user == null)
            {
                return NotFound("user not found");
            }

            if (bookingDTO.StartDate >= bookingDTO.DateTo)
            {
                return BadRequest("Invalid date range");
            }

            if (bookingDTO.StartDate < DateTime.Now)
            {
                return BadRequest("Invalid date range");
            }
            
            booking.Room = room;
            booking.GuestName = user.FullName;
            booking.GuestEmail = user.Email;
            booking.GuestPhoneNr = user.PhoneNr;
            booking.StartDate = bookingDTO.StartDate;
            booking.EndDate = bookingDTO.DateTo;
            

            _hotelContext.SaveChanges();

            return Ok("Done");
        }



        [HttpDelete("id/{BookingId}")]
        public async Task<ActionResult<Booking>> DeleteBooking(int BookingId)
        {
            var booking = await _hotelContext.Bookings.FindAsync(BookingId);
            if (booking == null)
            {
                return NotFound();
            }

            _hotelContext.Bookings.Remove(booking);
            await _hotelContext.SaveChangesAsync();

            return Ok(booking);
        }
    }
}
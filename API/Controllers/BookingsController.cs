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

		[HttpPost]
		public void PostBooking(Booking booking)
		{
			_hotelContext.Bookings.Add(booking);
			_hotelContext.SaveChanges();
		}
	}
}
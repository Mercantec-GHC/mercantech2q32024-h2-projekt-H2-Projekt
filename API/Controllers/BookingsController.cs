using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;
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
			var bookings = await _hotelContext.bookings.ToArrayAsync();
			return Ok(bookings);
		}
	}
}
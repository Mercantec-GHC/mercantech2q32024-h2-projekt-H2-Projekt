using Microsoft.AspNetCore.Mvc;
using DomainModels;
using API.Data;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RoomsController : ControllerBase
	{
		private readonly HotelContext _hotelContext;

		public RoomsController(HotelContext hotelContext)
		{
			_hotelContext = hotelContext;
		}

		[HttpGet]
		public IEnumerable<Room> GetRooms()
		{
			return _hotelContext.Rooms.ToArray();
		}

		[HttpPost]
		public void Post(Room room)
		{
			_hotelContext.Rooms.Add(room);
			_hotelContext.SaveChanges();
		}
	}
}
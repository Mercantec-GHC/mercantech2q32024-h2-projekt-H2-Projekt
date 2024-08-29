using Microsoft.AspNetCore.Mvc;
using DomainModels;
using API.Data;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            var rooms = await _hotelContext.rooms
                .ToListAsync();
            return Ok(rooms);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Room>> GetRoom(long id) 
        {
            var room = await _hotelContext.rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room); 
        }

        [HttpPost]
        public async Task<IActionResult> PostRoom([FromBody] Room room)
        {
            try
            {
                _hotelContext.rooms.Add(room);

                await _hotelContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetRoom), new { id = room.RoomId }, room);
            }
            catch (Exception ex)
            {
                // Log the exception (using your logging framework)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("id")]
		public IActionResult DeleteRoom(int id)
		{
			var room = _hotelContext.rooms.Find(id);

			if (room == null)
			{
				return NotFound();
			}

			_hotelContext.rooms.Remove(room);

			_hotelContext.SaveChanges();

			return NoContent();
		}
	}
}
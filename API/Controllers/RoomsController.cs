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
            try
            {
                var rooms = await _hotelContext.Rooms
                    .Select(r => new { r.RoomId, r.Type, r.Price, r.BookedDays })
                    .ToListAsync();

                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id) // Change long to int if RoomId is an int
        {
            try
            {
                var room = await _hotelContext.Rooms.FindAsync(id);

                if (room == null)
                {
                    return NotFound();
                }

                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostRoom([FromBody] Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Check if the RoomId already exists in the database
                var existingRoom = await _hotelContext.Rooms.FindAsync(room.RoomId);

                if (existingRoom != null)
                {
                    // If the RoomId already exists, increment the RoomId
                    var maxRoomId = await _hotelContext.Rooms.MaxAsync(r => r.RoomId);
                    room.RoomId = maxRoomId + 1;
                }

                // Add the room with the updated RoomId
                _hotelContext.Rooms.Add(room);
                await _hotelContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetRoom), new { id = room.RoomId }, room);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                var room = await _hotelContext.Rooms.FindAsync(id);

                if (room == null)
                {
                    return NotFound();
                }

                _hotelContext.Rooms.Remove(room);
                await _hotelContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
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
        public async Task<ActionResult<Room>> GetRoom(int id) 
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
        public async Task<IActionResult> PostRoom(RoomPostDTO roomDTO)
        {
            try
            {
                var room = new Room()
                {
                    Type = roomDTO.Type,
                    Price = roomDTO.Price
                };
                _hotelContext.Rooms.Add(room);
                await _hotelContext.SaveChangesAsync();

                return Ok(StatusCode(200));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, RoomPutDTO room)
        {
            var roomDTO = await _hotelContext.Rooms.FindAsync(id);

            if (roomDTO == null)
            {
                return NotFound();
            }

            roomDTO.Type = room.Type;
            roomDTO.Price = room.Price;

            _hotelContext.Entry(roomDTO).State = EntityState.Modified;

            try
            {
                await _hotelContext.SaveChangesAsync();
            }
            catch
            {
                if (!_hotelContext.Rooms.Any(r => r.RoomId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(200);
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
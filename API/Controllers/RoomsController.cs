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
                //fetches a list of rooms with specific fields only
                var rooms = await _hotelContext.Rooms
                    .Select(r => new { r.RoomId, r.Type, r.Price, r.BookedDays })
                    .ToListAsync();
                //Returns an Ok(200) response with the list of rooms
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
                //Attempts to find the room by its ID
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
                //Creates a new room object from the DTO
                var room = new Room()
                {
                    Type = roomDTO.Type,
                    Price = roomDTO.Price
                };
                //Adds the new room to the context and saves changes asynchronously
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
            //Finds the existing rooms by its ID
            var roomDTO = await _hotelContext.Rooms.FindAsync(id);


            // Returns a 404 Not Found if the room doesn't exist
            if (roomDTO == null)
            {
                return NotFound();
            }

            
            //Updates only the BookedDays property
            roomDTO.BookedDays = room.BookedDays;

            // Mark the room entity as modified in the context
            _hotelContext.Entry(roomDTO).State = EntityState.Modified;

            try
            {
                // Save the changes to the database asynchronously
                await _hotelContext.SaveChangesAsync();
            }
            catch
            {
                //Checks if the room still exists before rethrowing the exception
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

        [HttpPut("{id}Admin")]
        public async Task<IActionResult> PutRoomAdmin(int id, RoomPutAdmin room)
        {
            // Find the existing room by its ID
            var roomDTO = await _hotelContext.Rooms.FindAsync(id);

            // Return a 404 Not Found status if the room does not exist
            if (roomDTO == null)
            {
                return NotFound();
            }

            //// Update multiple properties of the room, including Type, Price, and BookedDays
            roomDTO.Type = room.Type;
            roomDTO.Price = room.Price;
            roomDTO.BookedDays = room.BookedDays;

            // Mark the room entity as modified in the context
            _hotelContext.Entry(roomDTO).State = EntityState.Modified;

            try
            {
                // Save the changes to the database asynchronously
                await _hotelContext.SaveChangesAsync();
            }
            catch
            {
                //Checks if the room still exists before rethrowing the exception
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
                //find the room by its ID.
                var room = await _hotelContext.Rooms.FindAsync(id);

                if (room == null)
                {
                    return NotFound();
                }
                //// Removes the room from the context and saves changes asynchronously
                _hotelContext.Rooms.Remove(room);
                await _hotelContext.SaveChangesAsync();

                // Returns a 204 No Content after successful deletion
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
using API.Data;
using API.DTOs;
using API.Mappers;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Endpoints
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RoomDetailsEndpoint : ControllerBase
    {
        private readonly HotelContext _context;

        public RoomDetailsEndpoint(HotelContext context)
        {
            // Fill the DB Context through Dependency Injection
            _context = context;
        }

        /// <summary>
        /// Requests data by ID
        /// </summary>
        /// <param name="id">Room</param>
        /// <returns>Status OK with roomDetails</returns>
        [HttpGet("{id}")]
        public IActionResult GetRoomDetails(int id)  
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == id);

            //Just in case null it returns not found
            if (room == null)
            {
                return NotFound($"Room with ID {id} not found.");
            }

            var roomDetails = new GetRoomDetailsDTO
            {
                Rooms = room.Rooms,
                RoomNumber = room.RoomNumber,
                Beds = room.Beds,
                Price = room.Price,
                Status = room.Status,
                Condition = room.Condition
            };

            return Ok(roomDetails);
        }
    }
}

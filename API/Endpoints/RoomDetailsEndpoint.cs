using API.Data;
using API.DTOs;
using API.Mappers;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.TEST
{
    // This class is a controller class that handles the HTTP requests for the User entity
    [ApiController]
    [Route("[controller]/[action]")]
    public class RoomDetailsEndpoint : ControllerBase
    {
        // This is a constructor for the UserController class that takes in a HotelContext object to istantiate the database context
        private readonly HotelContext _context;

        public RoomDetailsEndpoint(HotelContext context)
        {
            _context = context;
        }

        //This is a method that returns all the Room details
        [HttpGet]
        public IActionResult GetRoomDetails([FromBody] GetRoomDetailsDTO roomDTO)
        {
          
            var rooms = _context.Rooms.ToList();

            var roomDetails = rooms.Select(roomDTO => new GetRoomDetailsDTO
            {
                Rooms = roomDTO.Rooms,
                RoomNumber = roomDTO.RoomNumber,
                Beds = roomDTO.Beds,
                Price = roomDTO.Price,
                Status = roomDTO.Status,
                Condition = roomDTO.Condition
            }).ToList();

            return Ok(roomDetails);
        }
    }
}

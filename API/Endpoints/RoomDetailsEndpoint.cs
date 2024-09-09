using API.Data;
using DomainModels.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.TEST
{
    // This class is a controller class that handles the HTTP requests for the User entity
    [ApiController]
    [Route("[controller]/[action]")]
    public class RoomDetailsEndpoint : ControllerBase
    {
        // This is a constructor for the UserController class that takes in a HotelContext object to instantiate the database context
        private readonly HotelContext _context;

        public RoomDetailsEndpoint(HotelContext context)
        {
            _context = context;
        }

        // This is a method that returns all the Room details
        [HttpGet]
        public IActionResult GetRoomDetails([FromQuery] GetRoomDetailsDTO roomDTO)
        {
            var rooms = _context.Rooms.ToList();

            var roomDetails = rooms.Select(room => new GetRoomDetailsDTO
            {
                Rooms = room.Rooms,
                RoomNumber = room.RoomNumber,
                Beds = room.Beds,
                Price = room.Price,
                Status = room.Status,
                Condition = room.Condition
            }).ToList();

            return Ok(roomDetails);
        }
    }
}

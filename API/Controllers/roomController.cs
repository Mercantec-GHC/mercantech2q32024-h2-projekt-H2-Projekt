using Microsoft.AspNetCore.Mvc;
using API.Data;
using Microsoft.EntityFrameworkCore;
using DomainModels.DB;
using DomainModels.DTO;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    /// <summary>
    /// Controller for room endpoints
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly HotelContext _context;
        public RoomController(HotelContext context)
        {
            // Fill the DB Context through Dependency Injection
            _context = context;
        }

        /// <summary>
        /// Get all room
        /// </summary>
        /// <returns>Status OK with the list of rooms</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            // Currently the simplest CRUD operation
            var room = _context.Rooms.ToList();
            
            return Ok(room);
        }

        /// <summary>
        /// Get specific ID of room
        /// </summary>
        /// <param name="id">This is the id in the database of the room you want to select</param>
        /// <returns>Status OK with room</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            // Currently the simplest CRUD operation
            var room = _context.Rooms.Find(id);
            //Just in case null it returns not found
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        /// <summary>
        /// Add a new room
        /// </summary>
        /// <param name="room">Room object</param>
        /// <returns>Status OK with new room</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody]Room room) 
        {
            // Currently the simplest CRUD operation
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return Ok(room);
        }

        /// <summary>
        /// Update Room
        /// </summary>
        /// <param name="room">Room object</param>
        /// <returns>Status OK with modified Room</returns>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] Room room) 
        {
            // Currently the simplest CRUD operation
            _context.Rooms.Update(room);
            _context.SaveChanges();
            return Ok(room);
        }

        /// <summary>
        /// Delete Room by ID
        /// </summary>
        /// <param name="id">Integer ID of Room</param>
        /// <returns>Status OK</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            // Currently the simplest CRUD operation
            var room = _context.Rooms.Find(id);
            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return Ok(room);
        }


        /// <summary>
        /// Search for rooms. 
        /// </summary>
        /// <param name="query"></param>
        /// <returns>A paginated list of rooms fitting the filters</returns>
        /// <remarks>
        /// Currently supports searching by RoomType tags, sorting by any property of the Room object, and lastly non zero-based pagination
        /// </remarks>
        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] SearchRoomQuery query )
        {
            // Create the start of a request to the DB
            var rooms = _context.Rooms
                // Make sure that the RoomType is included in the result
                .Include(r => r.RoomType)
                // Check if the room type of any of the rooms contains a tag that matches the search property of the query object
                .WhereIf(!string.IsNullOrWhiteSpace(query.Search), r => r.RoomType.Tags.Any(tag => tag.ToLower().Contains(query.Search.ToLower())));

            // Check if SortBy is empty and if not then check if the entered value is a property on the Room object
            if (!string.IsNullOrWhiteSpace(query.SortBy) && typeof(Room).GetProperties().Any(p => p.Name.ToLower() == query.SortBy.ToLower()))
            {
                // Get the property name of the Room object that matches the SortBy property of the query object
                // (Just ensures capitalization and such is correct)
                string propName = typeof(Room).GetProperties().First(p => p.Name.ToLower() == query.SortBy.ToLower()).Name;

                // Check if the sort is ascending or descending
                if (query.IsSortAscending)
                {
                    // Modify the request to return the rooms ordered by the property name in ascending order
                    rooms = rooms.OrderBy(r => EF.Property<object>(r, propName));
                }
                else
                {
                    // Modify the request to return the rooms ordered by the property name in descending order
                    rooms = rooms.OrderByDescending(r => EF.Property<object>(r, propName));
                }
            }
            // Check if SortBy contains a value but it isn't a property of the Room object
            else if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                // Return a bad request with a message that the SortBy property isn't found in the Room object
                return BadRequest($"SortBy '{query.SortBy}' parameter not found in rooms object");
            }

            // Pagination
            rooms = rooms.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);

            // Return the paginated list of rooms
            return Ok(rooms.ToList());
            
        }

        /// <summary>
        /// Get the details of a room as a nice to digest DTO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("RoomDetails/{id}")]
        public async Task<IActionResult> GetRoomDetails([FromRoute] int id)
        {
            var room = _context.Rooms.Find(id);

            if (room == null)
                return NotFound();

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

        /// <summary>
        /// Provide a list of all room types
        /// </summary>
        /// <returns></returns>
        [HttpGet("RoomTypes")]
        public async Task<IActionResult> GetRoomTypes()
        {
            var roomTypes = _context.RoomTypes.ToList();
            return Ok(roomTypes);
        }
    }
}

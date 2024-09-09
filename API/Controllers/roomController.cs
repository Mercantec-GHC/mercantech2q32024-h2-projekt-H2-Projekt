using Microsoft.AspNetCore.Mvc;
using API.Data;
using Microsoft.EntityFrameworkCore;
using DomainModels.DB;
using DomainModels.DTO;

namespace API.Controllers
{
    /// <summary>
    /// Controller for room endpoints
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
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
        public IActionResult GetAll() 
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
        public IActionResult GetById([FromRoute] int id) 
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
        public IActionResult Post([FromBody]Room room) 
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
        public IActionResult Update([FromBody] Room room) 
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
        public IActionResult Delete(int id)
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
        /// Currently supports searching by RoomType, sorting by any property of the Room object, and lastly non zero-based pagination
        /// </remarks>
        [HttpGet]
        public IActionResult Search([FromQuery] SearchRoomQuery query )
        {
            // Create the start of a request to the DB
            var rooms = _context.Rooms.AsQueryable();

            // Check if search property of the query object isn't empty 
            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                // Add the condition to the db request that the returned list needs to have RoomType contain the search property
                rooms = rooms.Where(r => r.Description.ToLower().Contains(query.Search.ToLower()));
            }

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
    }
}

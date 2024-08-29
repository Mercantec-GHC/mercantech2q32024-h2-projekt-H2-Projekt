using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainModels;

namespace API.Controllers
{
    /// <summary>
    /// Controller for room endpoints
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class roomController : ControllerBase
    {
        private readonly HotelContext _context;
        public roomController(HotelContext context)
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
            var room = _context.Room.ToList();
            
            return Ok(room);
        }

        /// <summary>
        /// Get specific ID of room
        /// </summary>
        /// <param name="id">RoomType ID</param>
        /// <returns>Status OK with room</returns>
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) 
        {
            // Currently the simplest CRUD operation
            var room = _context.Room.Find(id);
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
            _context.Room.Add(room);
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
            _context.Room.Update(room);
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
    }
}

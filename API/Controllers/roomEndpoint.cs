using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainModels;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class roomEndpoint : ControllerBase
    {
        private readonly HotelContext _context;
        public roomEndpoint(HotelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            var room = _context.Room.ToList();
            
            return Ok(room);
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id) 
        {
            var room = _context.Room.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Room room) 
        {
            _context.Room.Add(room);
            _context.SaveChanges();
            return Ok(room);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Room room) 
        {
            _context.Room.Update(room);
            _context.SaveChanges();
            return Ok(room);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var room = _context.Rooms.Find(id);
            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return Ok(room);
        }
    }
}

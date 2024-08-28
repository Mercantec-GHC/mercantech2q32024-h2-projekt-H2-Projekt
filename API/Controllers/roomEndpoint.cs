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

        [HttpGet("{Id}")]

        public IActionResult GetById([FromRoute] int Id) 
        {
            var room = _context.Room.FindAsync(Id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }
    }
}

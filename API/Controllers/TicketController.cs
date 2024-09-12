using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainModels;
using API.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Query.Internal;
using DomainModels.DB;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // This class is a controller class that handles the HTTP requests for the User entity
    [ApiController]
    [Route("[controller]")]
    public class TicketController : Controller
    {
        private readonly HotelContext _context;

        public TicketController(HotelContext context)
        {
            _context = context;
        }
        //fetch all tickets
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ticket = await _context.Tickets.ToListAsync();

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }
        //fetch the id of a ticket
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            //Just in case null, returns not found
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }
        // adding a new ticket
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return Ok(ticket);
        }
        // updating an already existing ticket, this can also be a part of the message/reply feature for now
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
            return Ok(ticket);
        }
        // removing/deleting an existing ticket, may want to do so in another way in the future, where it instead stores the ticket
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
            return Ok(ticket);
        }
    }
}

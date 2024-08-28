using API.Data;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]/[action]")]
    public class ReservationsController : Controller
    {

        private readonly HotelContext _context;

        public ReservationsController(HotelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
           var reservations = _context.Reservations.ToList();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var reservation = _context.Reservations.Find(id);
            return Ok(reservation);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
            return Ok(reservation);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var reservation = _context.Reservations.Find(id);
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            return Ok();
        }
    }
}

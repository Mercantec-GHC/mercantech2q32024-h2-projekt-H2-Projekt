using API.Data;
using DomainModels.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Controller for reservation endpoints
    /// 
    /// Most likely wanna later add some more complex logic here to handle creation of reservations based off of user and room availability and such.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReservationsController : Controller
    {

        private readonly HotelContext _context;

        public ReservationsController(HotelContext context)
        {
            // Fill the DB Context through Dependency Injection
            _context = context;
        }

        /// <summary>
        /// Get all reservations
        /// </summary>
        /// <returns>Status OK with the list of reservations</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Currently the simplest CRUD operation
            var reservations = _context.Reservations.ToList();
            return Ok(reservations);
        }

        /// <summary>
        /// Get specific reservation by ID
        /// </summary>
        /// <param name="id">Reservation ID</param>
        /// <returns>Status OK with reservation</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Currently the simplest CRUD operation
            var reservation = _context.Reservations.Find(id);
            return Ok(reservation);
        }

        /// <summary>
        /// Add new reservation
        /// </summary>
        /// <param name="reservation">Reservation object</param>
        /// <returns>Status CREATED</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Reservation reservation)
        {
            // Currently the simplest CRUD operation
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return Created();
        }

        /// <summary>
        /// Update reservation
        /// </summary>
        /// <param name="reservation">Reservation object</param>
        /// <returns>Status OK with the modified reservation</returns>
        [HttpPut]
        public IActionResult Update([FromBody] Reservation reservation)
        {
            // Currently the simplest CRUD operation
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
            return Ok(reservation);
        }

        /// <summary>
        /// Delete reservation by ID
        /// </summary>
        /// <param name="id">Integer ID of reservation</param>
        /// <returns>Status OK</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Currently the simplest CRUD operation
            var reservation = _context.Reservations.Find(id);
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            return Ok();
        }
    }
}

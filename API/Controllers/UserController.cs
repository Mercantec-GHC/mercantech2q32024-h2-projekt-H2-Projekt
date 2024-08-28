using API.Data;
using API.DTOs;
using API.Mappers;
using DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        
        private readonly HotelContext _context;

        public UserController(HotelContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            if (users == null) {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] CreateUsersDTO userDTO )
        {
            var user = userDTO.toCreateUserDTO();
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] CreateUsersDTO userDTO)
        {
            var user = _context.Users.Find(id);
            if (user == null) {
                return NotFound();
            }
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            user.Permissions = userDTO.Permissions;
            _context.Users.Update(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}

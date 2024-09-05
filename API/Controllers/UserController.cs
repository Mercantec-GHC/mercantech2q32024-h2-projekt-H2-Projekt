using API.Data;
using API.DTOs;
using API.Mappers;
using DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // This class is a controller class that handles the HTTP requests for the User entity
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
     
        // This is a constructor for the UserController class that takes in a HotelContext object to istantiate the database context
        private readonly HotelContext _context;

        public UserController(HotelContext context)
        {
            _context = context;
        }



        // here we have a method that returns a user object by id
        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] string id)
        {
            var user = _context.Users.Find(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }


        // here we have a method that returns all users
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            if (users == null) {
                return NotFound();
            }
            return Ok(users);
        }



        // here we have a method that creates a user object. That is to be used by the customers to create their account
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateUsersDTO userDTO )
        {
            var user = userDTO.toCreateUserDTO();
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }



        // here we have a method that creates a user object. That is to be used by the admin to create an employee account
       [HttpPost]
        public IActionResult CreateEmployee([FromBody] CreateEmployeeDTO EmployeeDTO, string password)
        {
           var adminPassword = _context.Admins.Find(1).Password;
            if (password == adminPassword) {
                var user = EmployeeDTO.toCreateEmployeeDTO();
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok(user);
            } else {
                return Unauthorized();
            }
 
        }




        // here we have a method that updates a user object by id.
        // That is to be used by the customers or employee to update that specific customers account
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer([FromRoute] int id, [FromBody] CreateUsersDTO userDTO)
        {
            var user = _context.Users.Find(id);
            if (user == null) {
                return NotFound();
            }
            user.UserName = userDTO.Username;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.PhoneNumber = userDTO.phoneNumber;
            user.Email = userDTO.Email;
            _context.Users.Update(user);
            _context.SaveChanges();
            return Ok(user);
        }


        
        // here we have method that update the employye object by the id of the employee
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromRoute] int id, [FromBody] CreateEmployeeDTO employeeDTO, string password)
        {
            var adminPassword = _context.Admins.Find(1).Password;
            if (password == adminPassword)
            {
                var user = _context.Employees.Find(id);
                if (user == null)
                {
                    return NotFound();
                }
                user.FirstName = employeeDTO.FirstName;
                user.LastName = employeeDTO.LastName;
                user.PhoneNumber = employeeDTO.phoneNumber;
                user.EmployeePhoneNumber = employeeDTO.EmployeePhoneNumber;
                user.UPN = employeeDTO.UPN;
                user.Email = employeeDTO.Email;
                _context.Employees.Update(user);
                _context.SaveChanges();
                return Ok(user);
            }
            else
            {
                return Unauthorized();
            }
            
        }


        // here we have a method that deletes a user object by id. can be used for both customers and employees
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

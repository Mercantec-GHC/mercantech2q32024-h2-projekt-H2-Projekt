using Microsoft.AspNetCore.Mvc;
using DomainModels;
using API.Data;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly HotelContext _hotelContext;
		private readonly UserMapping _userMapping;
		public UsersController(HotelContext hotelContext, UserMapping userMapping)
		{
			_hotelContext = hotelContext;
			_userMapping = userMapping;
		}

		// Get all users.
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserGetDTO>>> GetAllUsers()
		{
			var users = await _hotelContext.Users.ToListAsync();
			List<UserGetDTO> result = new List<UserGetDTO>();

			if (users == null)
			{
				return NotFound();
			}
			/* Loops through each item in the List and maps it to a new class/type 
			 and adds it to a new List.*/
			foreach (var user in users)
			{
				result.Add(_userMapping.MapUserToUserGetDTO(user));
			}
			return Ok(result);
		}

		// Get a specific user from the UserID.
		[HttpGet("{id}")]
		public async Task<ActionResult<UserGetDTO>> GetAUserById(int id)
		{
			// Finds a user through the user id.
			var user = await _hotelContext.Users.FindAsync(id);

			if (user == null)
			{
				return NotFound();
			}
			// returns the user, after mapping it to a new class/type.
			return Ok(_userMapping.MapUserToUserGetDTO(user));
		}

		// Get User info to login
		[HttpPost("/login")]
		public async Task<ActionResult<UserLoginDTO>> Login(string email, string password)
		{
			var user = await _hotelContext.Users.Where(e => e.Email == email).FirstOrDefaultAsync(p => p.Password == password);

			if (user == null)
			{
				return NotFound();
			}
			return Ok(_userMapping.MapUserToUserLoginDTO(user));
        }

		// Create a user account
		[HttpPost]
		public async Task<ActionResult<User>> PostAUser(UserPostDTO user)
		{
			try
			{
				// Adds the user to database after mapping it to a new class/type.
				_hotelContext.Users.Add(_userMapping.MapUserPostDTOToUser(user));
				// Saves the changes to the database.
				await _hotelContext.SaveChangesAsync();

				return Ok();
			}
			catch
			{
				return NotFound();
			}
		}

		// Update a specific guest user account.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutUser(int id, UserPutDTO user)
		{
			// Finds the user by its user id.
			var userDTO = await _hotelContext.Users.FindAsync(id);

			if (userDTO == null)
			{
				return NotFound();
			}

			// Update the value stored in the variables.
			userDTO.FullName = user.FullName ?? throw new ArgumentException(nameof(user.FullName));
			userDTO.Password = user.Password ?? throw new ArgumentException(nameof(user.Password));
			userDTO.PhoneNr = user.PhoneNr ?? throw new ArgumentException(nameof(user.PhoneNr));
			userDTO.Email = user.Email ?? throw new ArgumentException(nameof(user.Email));

			// Mark the userDTO entity as modified in the change tracker.
			_hotelContext.Entry(userDTO).State = EntityState.Modified;

			// Try to save changes.
			try
			{
				await _hotelContext.SaveChangesAsync();
			}
			catch
			{
				// Checks if the user is in the database.
				if (!_hotelContext.Users.Any(u => u.UserId == id)){
					return NotFound();
				}
				else{
					throw;
				}
			}
			return StatusCode(200);
		}

		// Delete a User.
		[HttpDelete("{id}")]
		public async Task<IActionResult> UserDelete(int id)
		{
			// Find user by user id.
			var user = await _hotelContext.Users.FindAsync(id);

			if (user == null)
			{
				return NotFound();
			}

			// Removes user from Database.
			_hotelContext.Users.Remove(user);
			// Saves changes.
			await _hotelContext.SaveChangesAsync();
			return StatusCode(200);
		}


		// Loggin in a user. returns loggedin userdata
        [HttpPost("Login")]
        public async Task<ActionResult<UserGetDTO>> LoginUser(string email, string password)
        {
            try
            {
                // Fetch the user from the database asynchronously by matching email and password
                User user = await _hotelContext.Users.FirstOrDefaultAsync(u=>u.Email == email && u.Password == password);

                // Check if the user exists, if not return a 404 Not Found response
                if (user == null)
                {
                    return NotFound();
                }

                // Map the User entity to a UserGetDTO object using a mapping function
                // This ensures only required data is sent back, not sensitive information like passwords
                UserGetDTO loggedin = _userMapping.MapUserToUserGetDTO(user);

                // Return the mapped DTO object wrapped in a 200 OK response
                return Ok(loggedin);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
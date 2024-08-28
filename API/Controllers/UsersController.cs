using Microsoft.AspNetCore.Mvc;
using DomainModels;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UsersController : ControllerBase
	{

		private readonly HotelContext _hotelContext;

		public UsersController(HotelContext hotelContext)
		{
			_hotelContext = hotelContext;
		}

		// Get all users on the database.
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserGetDTO>>> GetAllUsers()
		{
			var user = await _hotelContext.users.Select(user => new UserGetDTO
			{
				id = user.id,
				userName = user.userName,
				bookings = user.bookings
			}).ToListAsync();
			return Ok(user);
		}

		// Get a specific user from its ID.
		[HttpGet("{id}")]
		public async Task<ActionResult<UserGetDTO>> GetUser(int id) {
			var user = await _hotelContext.users.FindAsync(id);

			if (user == null) {
				return NotFound();
			}
			// Mapping User to UserGetDTO.
			var userDto = new UserGetDTO {
				id = user.id,
				userName = user.userName,
				bookings = user.bookings
			};
			return Ok(userDto);
		}

		[HttpPost]
		//public async Task<UserCreateDTO> PostUser(UserCreateDTO user)
		//{
			
		//	return NoContent();
		//}

		[HttpPost]
		public void Post(User user)
		{
			_hotelContext.users.Add(user);
			_hotelContext.SaveChanges();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			var user = await _hotelContext.users.FindAsync(id);
            if (user != null)
            {
				_hotelContext.users.Remove(user);
				_hotelContext.SaveChanges();

				return NoContent();
            }
				return NoContent();
        }
	}
}
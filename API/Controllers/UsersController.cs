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
				return StatusCode(418);
			}

			foreach (var user in users)
			{
				result.Add(_userMapping.MapUserToUserGetDTO(user));
			}
			return Ok(result);
		}

		// Get a specific user from the UserID.
		[HttpGet("{id}")]
		public async Task<ActionResult<UserGetDTO>> GetAUser(int id)
		{
			var user = await _hotelContext.Users.FindAsync(id);

			if (user == null)
			{
				return StatusCode(418);
			}

			return Ok(_userMapping.MapUserToUserGetDTO(user));
		}

		// Create a user account
		[HttpPost]
		public async Task<ActionResult<User>> PostAUser(UserCreateAndUpdateDTO user)
		{
			//var userDTO = new User
			//{
			//	UserName = user.UserName,
			//	Password = user.Password,
			//	Name = user.Name,
			//	PhoneNr = user.PhoneNr,
			//	Email = user.Email
			//};

			_hotelContext.Users.Add(_userMapping.MapToUserCreateAndUpdateDTO(user));
			await _hotelContext.SaveChangesAsync();

			return Ok(StatusCode(200));
		}


		// Update a specific guest user account
	   [HttpPut("{id}")]
		public async Task<IActionResult> PutAUser(int id, UserGetDTO user)
		{
			if (id != user.UserId)
			{
				return BadRequest();
			}

			var userDTO = await _hotelContext.Users.FindAsync(id);
			if (userDTO == null)
			{
				return NotFound();
			}
			return Ok(userDTO);
		}


		//[HttpPost]
		//public void Post([FromBody] User user)
		//{
		//	_hotelContext.Users.Add(user);
		//	_hotelContext.SaveChanges();
		//}
	}
	}
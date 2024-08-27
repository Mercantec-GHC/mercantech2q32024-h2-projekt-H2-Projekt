using Microsoft.AspNetCore.Mvc;
using DomainModels;
using API.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;
        private readonly HotelContext _hotelContext;

        public UsersController(ILogger<UsersController> logger, HotelContext hotelContext)
		{
            _logger = logger;
            _hotelContext = hotelContext;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _hotelContext.users.ToArray();
        }

        [HttpPost]
        public void Post([FromBody] User user)
        {
            _hotelContext.users.Add(user);
            _hotelContext.SaveChanges();
        }
    }
}
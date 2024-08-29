using DomainModels;

namespace API.Services
{
    public class UserMapping
    {
        public UserMapping() { }

        public UserGetDTO MapUserToUserGetDTO(User user)
        {
            var userDTO = new UserGetDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Name = user.Name,
                Bookings = user.Bookings
            };

            return userDTO;
        }

        public UserCreateAndUpdateDTO MapToUserCreateAndUpdateDTO()
        {

        }
    }
}

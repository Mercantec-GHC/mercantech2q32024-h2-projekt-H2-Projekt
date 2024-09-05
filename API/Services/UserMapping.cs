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
                FullName = user.FullName,
                Role = user.Role,
                Bookings = user.Bookings
            };

            return userDTO;
        }

        public User MapToUserCreateDTO(UserPostDTO user)
        {
            var userDTO = new User
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Password = user.Password,
                Role = user.Role,
                PhoneNr = user.PhoneNr,
                Email = user.Email
            };
            return userDTO;
        }

        public UserLoginDTO MapToUserLoginDTO(User user)
        {
            var userDTO = new UserLoginDTO
            {
                UserID = user.UserId,
                Role = user.Role
            };
            return userDTO;
        }
    }
}
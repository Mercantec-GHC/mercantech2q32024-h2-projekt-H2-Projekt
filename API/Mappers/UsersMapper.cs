using API.DTOs;
using DomainModels;
using System.Runtime.CompilerServices;

namespace API.Mappers
{
    public static class UsersMapper
    {
        public static User toCreateUserDTO(this CreateUsersDTO userDTO)
        {
            return new User
            {
                Email = userDTO.Email,
                Password = userDTO.Password,
                Permissions = userDTO.Permissions
            };
        }
    }
}

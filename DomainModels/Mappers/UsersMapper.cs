using DomainModels.DTO;
using DomainModels.DB;

namespace API.Mappers
{
    // here we use a mapper. a mapper is a class that is used to map one object to another.
    public static class UsersMapper
    {
        // so for example we have a method that maps a CreateUsersDTO to a User object in the domain models folder
        public static User toCreateUserDTO(this CreateUserDTO userDTO)
        {
            return new User
            {
                UserName = userDTO.Username,
                FirstName = userDTO.Firstname,
                LastName = userDTO.Lastname,
                PhoneNumber = userDTO.PhoneNumber,
                Email = userDTO.Email,
                PasswordHash = userDTO.Password,
            };
        }

        //and here we have a method that maps a CreateEmployeeDTO to a Employee object in the domain models folder
        public static Employee toCreateEmployeeDTO(this CreateEmployeeDTO employeeDTO)
        {
            return new Employee
            {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                PhoneNumber = employeeDTO.phoneNumber,
                EmployeePhoneNumber = employeeDTO.EmployeePhoneNumber,
                Email = employeeDTO.Email,
                PasswordHash = employeeDTO.Password,
                UPN = employeeDTO.UPN,
                Department = employeeDTO.Department

            };
        }
    }
}

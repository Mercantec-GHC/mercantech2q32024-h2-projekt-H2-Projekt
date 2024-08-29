using API.DTOs;
using DomainModels;
using System.Runtime.CompilerServices;

namespace API.Mappers
{
    // here we use a mapper. a mapper is a class that is used to map one object to another.
    public static class UsersMapper
    {
        // so for example we have a method that maps a CreateUsersDTO to a User object in the domain models folder
        public static User toCreateUserDTO(this CreateUsersDTO userDTO)
        {
            return new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                phoneNumber = userDTO.phoneNumber,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Permissions = userDTO.Permissions
            };
        }

        //and here we have a method that maps a CreateEmployeeDTO to a Employee object in the domain models folder
        public static Employee toCreateEmployeeDTO(this CreateEmployeeDTO employeeDTO)
        {
            return new Employee
            {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                phoneNumber = employeeDTO.phoneNumber,
                EmployeePhoneNumber = employeeDTO.EmployeePhoneNumber,
                Email = employeeDTO.Email,
                Password = employeeDTO.Password,
                Permissions = employeeDTO.Permissions,
                UPN = employeeDTO.UPN,
                Department = employeeDTO.Department

            };
        }
    }
}

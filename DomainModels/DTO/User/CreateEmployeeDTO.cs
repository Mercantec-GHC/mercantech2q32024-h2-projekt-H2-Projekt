using DomainModels.DB;

namespace DomainModels.DTO
{
    // this class is to be used to create a employee.
    // the reason for this is not to expose the guid and id of the user when creating an employee
    // since the id and guid are auto generated in the database.
    public class CreateEmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string phoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string UPN { get; set; }
        public Department Department { get; set; }
        public string EmployeePhoneNumber { get; set; }
    }
}

namespace API.DTOs
{
    // this class is to be used to create a user.
    // the reason for this is not to expose the guid and id of the user when creating a user
    // since the id and guid are auto generated in the database.
    public class CreateUsersDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string phoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<string> Permissions { get; set; }

    }
}

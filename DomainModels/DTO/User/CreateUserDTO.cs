using System.ComponentModel.DataAnnotations;

namespace DomainModels.DTO
{
    // this class is to be used to create a user.
    // the reason for this is not to expose the guid and id of the user when creating a user
    // since the id and guid are auto generated in the database.
    public class CreateUserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}

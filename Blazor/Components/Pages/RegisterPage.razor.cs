using Blazor.Services;
using DomainModels;

namespace Blazor.Components.Pages
{
    public partial class RegisterPage
    {
        // Instance of UserService used to handle user registration
        UserService userService = new UserService();

        // Properties to hold user information
        public int UserId { get; set; }               
        public string FullName { get; set; } = null!;     
        public string Password { get; set; } = null!;    
        public string Role { get; set; } = null!;         
        public string? PhoneNr { get; set; }              
        public string Email { get; set; } = null!;   

        // This method registers a user
        public async void RegisterUser()
        {
            // Create a new UserPostDTO object and populate it with the user's details
            UserPostDTO user = new UserPostDTO();
            user.UserId = UserId;           // Set the user's unique ID
            user.FullName = FullName;       // Set the user's full name
            user.Password = Password;       // Set the user's password
            user.Role = "Customer";         // Set the role to "Customer" (default role in this case)
            user.PhoneNr = PhoneNr;         // Set the user's phone number (optional)
            user.Email = Email;             // Set the user's email address

            // Call the RegisterUser method from the UserService to send the user's data to the API
            await userService.RegisterUser(user);
        }
    }
}

using Blazor.Services;

namespace Blazor.Components.Pages
{
    public partial class Login
    {
        // Instance of UserService used to handle user login
        UserService userService = new UserService();

        // Properties to hold user's login information
        public string Email { get; set; }  
        public string Password { get; set; }  

        // Method to login the user
        void LoginUser()
        {
            // Call the LoginUser method from UserService to authenticate the user with their email and password
            userService.LoginUser(Email, Password);
        }
    }
}

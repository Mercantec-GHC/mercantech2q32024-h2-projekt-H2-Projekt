using Blazor.Services;

namespace Blazor.Components.Pages
{
    public partial class Login
    {
        UserService userService = new UserService();
        public string Email { get; set; }
        public string Password { get; set; }

        void LoginUser()
        {
            userService.LoginUser(Email, Password);

        }
    }
}

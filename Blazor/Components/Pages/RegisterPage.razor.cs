using Blazor.Services;
using DomainModels;

namespace Blazor.Components.Pages
{
    public partial class RegisterPage
    {
        UserService userService = new UserService();
        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? PhoneNr { get; set; }
        public string Email { get; set; } = null!;


        public async void ReisterUser()
        {
            UserPostDTO user = new UserPostDTO();
            user.UserId = UserId;
            user.FullName = FullName;
            user.Password = Password;
            user.Role = "Customer";
            user.PhoneNr = PhoneNr;
            user.Email = Email;

            await userService.RegisterUser(user);

        }
    }
}

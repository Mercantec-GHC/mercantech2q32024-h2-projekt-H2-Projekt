namespace API.DTOs
{
    public class CreateUsersDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public List<string> Permissions { get; set; }
    }
}

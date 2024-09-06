namespace Blazor.Auth.Contracts
{
    public record AuthResponse
    {
        public string? Id { get; init; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
        public string? Token { get; set; }
    }
}

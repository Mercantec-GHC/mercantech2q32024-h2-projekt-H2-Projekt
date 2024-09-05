using Blazor.Auth.Contracts;

namespace Blazor.Auth
{
    public class AuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<AuthResponse?> Login(AuthRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", request);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<AuthResponse>();
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/auth/register", request);
            return response.IsSuccessStatusCode;
        }

    }
}

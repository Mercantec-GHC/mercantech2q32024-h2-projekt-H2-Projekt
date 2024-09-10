using Blazor.Auth.Contracts;
using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace Blazor.Auth
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }

        public async Task SetAuthorHeader()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            if (token != null)
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<AuthResponse?> Login(AuthRequest request)
        {
            var response = await _http.PostAsJsonAsync("https://localhost:7207/Authentication/Login", request);
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

        public async Task<T?> GetFrom<T>(string url)
        {
            await SetAuthorHeader();
            return await _http.GetFromJsonAsync<T?>(url);
        }

        public HttpClient GetHttpClient() => _http;

    }
}

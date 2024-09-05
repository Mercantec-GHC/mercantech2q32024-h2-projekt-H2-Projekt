using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Session;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace Blazor.Auth
{
    public class AuthStateProvide : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _sesseionStorage;
        private readonly HttpClient _http;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public AuthStateProvide(ILocalStorageService sessionStore, HttpClient http)
        {
            _sesseionStorage = sessionStore;
            _http = http;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _sesseionStorage.GetItemAsync<string>("authToken");
            if (string.IsNullOrWhiteSpace(token))
            {
                return new AuthenticationState(_anonymous);
            }
            ClaimsIdentity identity = GetClaimsIdentity(token);
            var user = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
            return authState;
        }

        public async Task AuthenticateUser(string token)
        {
            await _sesseionStorage.SetItemAsync("authToken", token);
            var identity = GetClaimsIdentity(token);
            var user = new ClaimsPrincipal(identity);
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        public ClaimsIdentity GetClaimsIdentity(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var claims = jwtToken.Claims;
            return new ClaimsIdentity(claims, "jwt");
        }

    }
}

using Blazor.Components.Pages;
using DomainModels;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;
using System.Net.Http;
using System.Net.Http.Json;

namespace Blazor.Services
{
    public class DatabaseServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseURL = "https://localhost:7207/";

        public DatabaseServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBooking(CreateBookingDTO booking)
        {
            await _httpClient.PostAsJsonAsync(_baseURL + "Bookings/add", booking);
        }

        public async Task<List<UserGetDTO>> GetAllUsers()
        {
            return await _httpClient.GetFromJsonAsync<List<UserGetDTO>>(_baseURL + "Users");
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await _httpClient.GetFromJsonAsync<List<Room>>(_baseURL + "Rooms");
        }
    }
}

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
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
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

        public async Task InsertBookedDaysInRoomTable(Room room, int roomId)
        {
            await _httpClient.PutAsJsonAsync<Room>(_baseURL + "Rooms/" + roomId, room);
        }
        public async Task<List<DomainModels.Booking>> GetBookingList()
        {
            string url = "https://localhost:7207/Bookings/all";

            var jsonString = await _httpClient.GetStringAsync(url);
            return JsonSerializer.Deserialize<List<DomainModels.Booking>>(jsonString) ?? new();
        }
    }
}
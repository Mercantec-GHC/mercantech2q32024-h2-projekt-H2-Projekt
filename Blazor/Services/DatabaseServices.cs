using Blazor.Components.Pages;
using DomainModels;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;

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

        public async Task CreateBooking(string guestName, string guestEmail, string guestPhoneNumber, DateTime startDate, DateTime endDate, int roomId)
        {
            var booking = new CreateBookingDTO
            {
                GuestName = guestName,
                GuestEmail = guestEmail,
                GuestPhoneNr = guestPhoneNumber,
                StartDate = startDate,
                EndDate = endDate,
                RoomId = roomId
            };

            await _httpClient.PostAsJsonAsync("Bookings", booking);
        }

        public async Task<List<UserGetDTO>> GetAllUsers()
        {
            return await _httpClient.GetFromJsonAsync<List<UserGetDTO>>(_baseURL + "Users");
        }
    }
}

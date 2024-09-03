using Blazor.Components.Pages;
using DomainModels;
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

            await _httpClient.PostAsJsonAsync("https://localhost:7207/Bookings/add", booking);
        }
    }
}

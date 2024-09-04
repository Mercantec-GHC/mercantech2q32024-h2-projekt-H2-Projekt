using Blazor.Components.Pages;
using DomainModels;
using System.Diagnostics;
using System.Text.Json;

namespace Blazor.Services
{
    public class DatabaseServices
    {
        private readonly HttpClient _httpClient;

        public DatabaseServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
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

        public async Task<List<DomainModels.Booking>> GetBookingList()
        {
            string url = "https://localhost:7207/Bookings/all";

            var jsonString = await _httpClient.GetStringAsync(url);
            return JsonSerializer.Deserialize<List<DomainModels.Booking>>(jsonString) ?? new();
        }


    }
}

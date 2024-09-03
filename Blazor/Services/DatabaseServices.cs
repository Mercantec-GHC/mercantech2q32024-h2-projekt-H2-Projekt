using Blazor.Components.Pages;
using DomainModels;

namespace Blazor.Services
{
    public class DatabaseServices
    {
        private readonly HttpClient _httpClient;

        public DatabaseServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBooking(string guestName, string guestEmail, string guestPhoneNumber, DateTime startDate, DateTime endDate, int roomId)
        {
            var booking = new CreateBookingDTO
            {

            }
        }
    }
}

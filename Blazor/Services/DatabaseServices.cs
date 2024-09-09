using DomainModels;
using System.Text.Json;
using Booking = DomainModels.Booking;

namespace Blazor.Services
{
    public class DatabaseServices
    {
        // This class is used to communicate with the backend API
        private readonly HttpClient _httpClient;
        private readonly string _baseURL = "https://localhost:7207/";

        // Constructor 
        public DatabaseServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }


        // Bookings
        public async Task CreateBooking(CreateBookingDTO booking)
        {
            await _httpClient.PostAsJsonAsync(_baseURL + "Bookings/add", booking);
        }


        public async Task<Booking> GetBookingById(int bookingId)
        {
            return await _httpClient.GetFromJsonAsync<Booking>(_baseURL + $"Bookings/id/{bookingId}") ?? new();
        }

        public async Task UpdateBooking(Booking booking)
        {
            // Convert DomeinModel.Bookings to UpdateBookingDTO for using in backend API
            var bookingDTO = new UpdateBookingDTO
            {
                BookingId = booking.BookingId,
                RoomId = booking.Room.RoomId,
                UserId = 5,
                GuestName = booking.GuestName,
                GuestEmail = booking.GuestEmail,
                GuestPhoneNr = booking.GuestPhoneNr,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate
            };

            await _httpClient.PutAsJsonAsync<UpdateBookingDTO>(_baseURL + "Bookings/update", bookingDTO);
        }
        public async Task DeleteBooking(int bookingId)
        {
            await _httpClient.DeleteAsync(_baseURL + $"Bookings/id/{bookingId}");
        }

        public async Task<List<DomainModels.Booking>> GetBookingList()
        {
            string url = "https://localhost:7207/Bookings/all";

            var jsonString = await _httpClient.GetStringAsync(url);
            return JsonSerializer.Deserialize<List<DomainModels.Booking>>(jsonString) ?? new();
        }

        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            return await _httpClient.GetFromJsonAsync<List<Feedback>>(_baseURL + "Feedbacks");
        }

        public async Task CreateFeedback(Feedback feedback)
        {
            await _httpClient.PostAsJsonAsync(_baseURL + "Feedbacks", feedback);
        }

        // Method to get a user by ID
        public async Task<UserGetDTO> GetUserById(int userId)
        {
            return await _httpClient.GetFromJsonAsync<UserGetDTO>($"{_baseURL}Users/{userId}");
        }
    }
}
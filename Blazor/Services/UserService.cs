using Blazor.Components.Pages;
using DomainModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using System.Text;

namespace Blazor.Services
{
    public class UserService
    {
        // The base URL for the API connection (localhost in this case)
        string apiConnection = "https://localhost:7207/users";

        public async void LoginUser(string email, string password)
        {
            try
            {
                // Create a new instance of HttpClient to make the HTTP request
                HttpClient httpClient = new HttpClient();

                // Send a POST request to the API's login endpoint, appending email and password as query parameters
                HttpResponseMessage response = await httpClient.PostAsync(apiConnection + $"/login?email={email}&password={password}", null);
                string content = await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        public async Task<bool> RegisterUser(UserPostDTO user)
        {
            // Convert the user object (DTO) to JSON format
            string jsonData = JsonConvert.SerializeObject(user);

            // Prepare the HTTP request content with the JSON data, specifying it as JSON with UTF-8 encoding is so it can take æøå
            StringContent content1 = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Create a new instance of HttpClient to make the HTTP request
            HttpClient httpClient = new HttpClient();

            // Send a POST request to the API endpoint with the JSON content and wait for the response
            HttpResponseMessage response = await httpClient.PostAsync(apiConnection, content1);

            // If the response indicates success, return true
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

    }
}

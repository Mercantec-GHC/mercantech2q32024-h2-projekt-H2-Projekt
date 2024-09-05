using Blazor.Components.Pages;
using DomainModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using System.Text;

namespace Blazor.Services
{
    public class UserService
    {
        string apiConnection = "https://localhost:7207/users";

        public async void LoginUser(string email, string password)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
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

            string jsonData = JsonConvert.SerializeObject(user);

            StringContent content1 = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync(apiConnection, content1);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}

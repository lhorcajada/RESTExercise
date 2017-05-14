using ApplicationCore.DTOs;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleClient
{
  
    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowUser(UserDto user)
        {
            Console.WriteLine($"Name: {user.Name}\tBirthDate: {user.BirthDate}\tId: {user.Id}");
        }

        static async Task<Uri> CreateUserAsync(UserDto user)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/user", user);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<UserDto> GetUserAsync(string path)
        {
            UserDto user = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<UserDto>();
            }
            return user;
        }

        static async Task<UserDto> UpdateUserAsync(UserDto user)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/user/{user.Id}", user);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            user = await response.Content.ReadAsAsync<UserDto>();
            return user;
        }

        static async Task<HttpStatusCode> DeleteUserAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/user/{id}");
            return response.StatusCode;
        }

        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:63000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new user
                var rand = new Random().Next(1, 3000000).ToString();
                UserDto user = new UserDto
                {
                    Name = string.Format("{0}-{1}", "Mi nombre", rand),
                    BirthDate = new DateTime(1993, 8, 31)
                };
                var url = await CreateUserAsync(user);
                Console.WriteLine($"Created at {url}");

                // Get the user
                user = await GetUserAsync(url.PathAndQuery);
                ShowUser(user);

                // Update the user
                Console.WriteLine("Updating birthDate...");
                user.BirthDate = new DateTime(1976, 5,8);
                await UpdateUserAsync(user);

                // Get the updated user
                user = await GetUserAsync(url.PathAndQuery);
                ShowUser(user);

                // Delete the user
                var statusCode = await DeleteUserAsync(user.Id);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}

using System;
using System.Text;
using DefaultNamespace;
using Newtonsoft.Json;
using RestaurantClient.Interfaces;

namespace RestaurantClient.Services
{
    public class DishService : IDishService
    {
        private readonly IHttpClientFactory _client;

        public DishService(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<HttpResponseMessage> GetDishes()
        {
            var client = _client.CreateClient("RestaurantAPI");
            
            var response = await client.GetAsync(client.BaseAddress + "api/dish");

            return response;
        }

        public async Task<HttpResponseMessage> GetDish(int restaurantId, int dishId)
        {
            var client = _client.CreateClient("RestaurantAPI");
            
            var response = await client.GetAsync(client.BaseAddress + $"api/restaurant/{restaurantId}/dish/{dishId}");

            return response;
        }

        public async Task<HttpResponseMessage> AddDish(int restaurantId, CreateDish dto)
        {
            var client = _client.CreateClient("RestaurantAPI");
            var serializedDto = JsonConvert.SerializeObject(dto);
            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(client.BaseAddress + $"api/restaurant/{restaurantId}/dish/"));
            message.Content = new StringContent(serializedDto, Encoding.UTF8);
            
            var response = await client.SendAsync(message);

            return response;
        }

        public async Task<HttpResponseMessage> DeleteDish(int id)
        {
            var client = _client.CreateClient("RestaurantAPI");
            var response = await client.DeleteAsync(client.BaseAddress + $"api/restaurant/{id}");

            return response;
        }
    }
}

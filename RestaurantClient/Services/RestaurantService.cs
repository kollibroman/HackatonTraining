using System;
using DefaultNamespace;
using Newtonsoft.Json;
using RestaurantClient.Interfaces;
using System.Net.Http;
using System.Text;

namespace RestaurantClient.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IHttpClientFactory _client;

        public RestaurantService(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<HttpResponseMessage> GetRestaurants()
        {
            var client = _client.CreateClient("RestaurantAPI");
            
            var response = await client.GetAsync(client.BaseAddress + "api/restaurant");

            return response;
        }

        public async Task<HttpResponseMessage> GetRestaurant(int id)
        {
            var client = _client.CreateClient("RestaurantAPI");
            
            var response = await client.GetAsync(client.BaseAddress + $"api/restaurant/{id}");

            return response;
        }

        public async Task<HttpResponseMessage> AddRestaurant(CreateRestaurant dto)
        {
            var client = _client.CreateClient("RestaurantAPI");
            var serializedDto = JsonConvert.SerializeObject(dto);
            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(client.BaseAddress + $"api/restaurant/"));
            message.Content = new StringContent(serializedDto, Encoding.UTF8);
            
            var response = await client.SendAsync(message);

            return response;
        }

        public async Task<HttpResponseMessage> UpdateRestaurant(UpdateRestaurant dto)
        {
            var client = _client.CreateClient("RestaurantAPI");
            var serializedDto = JsonConvert.SerializeObject(dto);
            var message = new HttpRequestMessage(HttpMethod.Put, new Uri(client.BaseAddress + $"api/restaurant/"));
            message.Content = new StringContent(serializedDto, Encoding.UTF8);
            
            var response = await client.SendAsync(message);

            return response;
        }

        public async Task<HttpResponseMessage> DeleteRestaurant(int id)
        {
            var client = _client.CreateClient("RestaurantAPI");
            var response = await client.DeleteAsync(client.BaseAddress + $"api/restaurant/{id}");

            return response;
        }
    }
}

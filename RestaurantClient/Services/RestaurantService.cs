using System;
using DefaultNamespace;
using RestaurantClient.Interfaces;

namespace RestaurantClient.Services
{
    public class RestaurantService : IRestaurantService
    {
        public Task<HttpResponseMessage> GetRestaurants()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> AddRestaurant(CreateRestaurant dto)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> UpdateRestaurant(UpdateRestaurant dto)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> DeleteRestaurant(int id)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using DefaultNamespace;
using RestaurantClient.Interfaces;

namespace RestaurantClient.Services
{
    public class DishService : IDishService
    {
        public Task<HttpResponseMessage> GetDishes()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetDish(int restaurantId, int dishId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> AddDish(CreateDish dto)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> DeleteDish(int id)
        {
            throw new NotImplementedException();
        }
    }
}

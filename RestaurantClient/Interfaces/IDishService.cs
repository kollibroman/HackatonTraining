using System;
using DefaultNamespace;

namespace RestaurantClient.Interfaces
{
    public interface IDishService
    {
        Task<HttpResponseMessage> GetDishes();
        Task<HttpResponseMessage> GetDish(int restaurantId, int dishId);
        Task<HttpResponseMessage> AddDish(int restaurantId, CreateDish dto);
        Task<HttpResponseMessage> DeleteDish(int id);
    }
}

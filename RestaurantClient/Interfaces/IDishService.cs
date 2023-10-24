using System;
using DefaultNamespace;

namespace RestaurantClient.Interfaces
{
    public interface IDishService
    {
        Task<HttpResponseMessage> GetDishes();
        Task<HttpResponseMessage> GetDish(int restaurantId, int dishId);
        Task<HttpResponseMessage> AddDish(CreateDish dto);
        Task<HttpResponseMessage> DeleteDish(int id);
    }
}

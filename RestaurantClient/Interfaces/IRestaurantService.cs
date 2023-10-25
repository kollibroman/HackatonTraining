using System.Threading.Tasks;
using System.Net.Http;
using System;
using DefaultNamespace;

namespace RestaurantClient.Interfaces
{
    public interface IRestaurantService
    {
        Task<HttpResponseMessage> GetRestaurants();
        Task<HttpResponseMessage> GetRestaurant(int id);
        Task<HttpResponseMessage> AddRestaurant(CreateRestaurant dto);
        Task<HttpResponseMessage> UpdateRestaurant(UpdateRestaurant dto);
        Task<HttpResponseMessage> DeleteRestaurant(int id);
    }
}

using DefaultNamespace;

namespace RestaurantClient.Interfaces;

public interface IDataHelper
{
    Task<List<Restaurant>> AllRestaurants();
}
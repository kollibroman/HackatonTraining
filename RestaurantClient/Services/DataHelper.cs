using DefaultNamespace;
using Newtonsoft.Json;
using RestaurantClient.Interfaces;

namespace RestaurantClient.Services;

public class DataHelper : IDataHelper
{
    private readonly IRestaurantService _restaurantService;

    public DataHelper(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }
    
    public async Task<List<Restaurant>> AllRestaurants()
    {
        var data = await _restaurantService.GetRestaurants();
        return JsonConvert.DeserializeObject<List<Restaurant>>(await data.Content.ReadAsStringAsync());
    }
}
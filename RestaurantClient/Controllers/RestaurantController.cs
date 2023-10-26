using DefaultNamespace;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantClient.Interfaces;

namespace RestaurantClient.Controllers;

public class RestaurantController : Controller
{
    private readonly IRestaurantService _restaurantService;
    private readonly IDishService _dishService;

    public RestaurantController(IRestaurantService restaurantService, IDishService dishService)
    {
        _restaurantService = restaurantService;
        _dishService = dishService;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var msg = await _restaurantService.GetRestaurants();

        if (!msg.IsSuccessStatusCode)
        {
            return NotFound();
        }
        
        return View(JsonConvert.DeserializeObject<List<Restaurant>>(await msg.Content.ReadAsStringAsync()));
    }

    public async Task<IActionResult> DishDetail(int RestaurantId, int id)
    {
        var msg = await _dishService.GetDish(RestaurantId, id);

        if (!msg.IsSuccessStatusCode)
        {
            return NotFound();
        }

        return View(JsonConvert.DeserializeObject<Dish>(await msg.Content.ReadAsStringAsync()));
    }
    //[HttpGet("{id}")]
    public async Task<IActionResult> Details(int Id)
    {
        var msg = await _restaurantService.GetRestaurant(Id);
        if (!msg.IsSuccessStatusCode)
        {
            return NotFound();
        }
        
        return View(JsonConvert.DeserializeObject<Restaurant>(await msg.Content.ReadAsStringAsync()));
    }

    public async Task<IActionResult> Add()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody]CreateRestaurant dto)
    {

        var msg = await _restaurantService.AddRestaurant(dto);
        if (!msg.IsSuccessStatusCode)
        {
            return BadRequest();
        }

        return RedirectToAction("Index");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var msg = await _restaurantService.DeleteRestaurant(id);
        if (!msg.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        
        return RedirectToAction("Index");
    }
}
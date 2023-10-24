using DefaultNamespace;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantClient.Interfaces;

namespace RestaurantClient.Controllers;

public class RestaurantController : Controller
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var msg = await _restaurantService.GetRestaurants();

        if (!msg.IsSuccessStatusCode)
        {
            return NotFound();
        }
        
        return View(JsonConvert.DeserializeObject<IList<Restaurant>>(await msg.Content.ReadAsStringAsync()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int Id)
    {
        var msg = await _restaurantService.GetRestaurant(Id);
        if (!msg.IsSuccessStatusCode)
        {
            return NotFound();
        }
        
        return View(JsonConvert.DeserializeObject<Restaurant>(await msg.Content.ReadAsStringAsync()));
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
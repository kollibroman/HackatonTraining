using AspNetCoreHero.ToastNotification.Abstractions;
using DefaultNamespace;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantClient.Interfaces;

namespace RestaurantClient.Controllers;

public class RestaurantController : Controller
{
    private readonly IRestaurantService _restaurantService;
    private readonly INotyfService _notyf;

    public RestaurantController(IRestaurantService restaurantService, INotyfService notyf)
    {
        _restaurantService = restaurantService;
        _notyf = notyf;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var msg = await _restaurantService.GetRestaurants();

        if (msg.IsSuccessStatusCode)
        {
            return View(JsonConvert.DeserializeObject<List<Restaurant>>(await msg.Content.ReadAsStringAsync()));
        }
        return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int Id)
    {
        var msg = await _restaurantService.GetRestaurant(Id);
        
        if (msg.IsSuccessStatusCode)
        {
            return View(JsonConvert.DeserializeObject<Restaurant>(await msg.Content.ReadAsStringAsync()));
        }
        
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody]CreateRestaurant dto)
    {
        var msg = await _restaurantService.AddRestaurant(dto);
        if (msg.IsSuccessStatusCode)
        {
            _notyf.Success("Created Restaurant!");
            return RedirectToAction("Index");
        }
        _notyf.Error("Failed to create restaurant");
        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var msg = await _restaurantService.DeleteRestaurant(id);
        if (!msg.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        
        _notyf.Success("Successfully deleted restaurant!");
        return RedirectToAction("Index");
    }
}
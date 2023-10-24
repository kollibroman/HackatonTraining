using DefaultNamespace;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantClient.Interfaces;
using RestaurantClient.Models;

namespace RestaurantClient.Controllers;

public class DishController : Controller
{
    private readonly IDishService _service;
    public DishController(IDishService service)
    {
        _service = service;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var msg = await _service.GetDishes();

        if (!msg.IsSuccessStatusCode)
        {
            return NotFound();
        }

        var content = JsonConvert.DeserializeObject<Dish>(await msg.Content.ReadAsStringAsync());
        return View(content);
    }
}
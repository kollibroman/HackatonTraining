using DefaultNamespace;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantClient.Interfaces;

namespace RestaurantClient.Controllers;

[Route("restaurant/{restaurantId}/dish")]
public class DishController : Controller
{
    private readonly IDishService _dish;

    public DishController(IDishService service)
    {
        _dish = service;
    }
    // GET
    public async Task<IActionResult> Index()
    { 
        var msg = await _dish.GetDishes();

        if (!msg.IsSuccessStatusCode)
        {
            return NotFound();
        }

        var content = JsonConvert.DeserializeObject<Dish>(await msg.Content.ReadAsStringAsync());
        return View(content);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute]int restaurantId, [FromRoute]int id)
    {
        var msg = await _dish.GetDish(restaurantId,id);
        if (!msg.IsSuccessStatusCode)
        {
            return NotFound();
        }
        
        return View(JsonConvert.DeserializeObject<Dish>(await msg.Content.ReadAsStringAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromRoute] int restaurantId, [FromBody] CreateDish dto)
    {
        var msg = await _dish.AddDish(restaurantId, dto);
        if (!msg.IsSuccessStatusCode)
        {
            return BadRequest();
        }

        return RedirectToAction("Index");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
    {
        var msg = await _dish.DeleteDish(id);
        if (!msg.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        
        return RedirectToAction("Index");
    }
}
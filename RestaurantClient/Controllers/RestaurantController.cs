using Microsoft.AspNetCore.Mvc;

namespace RestaurantClient.Controllers;

public class RestaurantController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
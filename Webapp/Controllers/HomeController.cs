using Microsoft.AspNetCore.Mvc;

namespace Webapp.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
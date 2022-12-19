using Microsoft.AspNetCore.Mvc;

namespace Sale.Api.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

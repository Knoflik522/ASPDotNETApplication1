using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class Contacts : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

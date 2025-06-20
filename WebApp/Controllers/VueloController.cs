using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class VueloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

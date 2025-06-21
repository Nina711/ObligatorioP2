using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Administradores
{
    public class AdministradorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

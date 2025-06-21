using Dominio;
using Dominio.Entidades_abstractas;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Clientes
{
    public class VueloController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            ViewBag.Vuelos = _sistema.Vuelos;
            return View();
        }
    }
}

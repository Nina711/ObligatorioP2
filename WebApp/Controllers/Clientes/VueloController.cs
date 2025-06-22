using Dominio;
using Dominio.Entidades_abstractas;
using Dominio.Entidades_no_abst;
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

        [HttpGet]
        public IActionResult Buscador()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Buscador(string codSalida, string codLlegada)
        {
            ViewBag.YaBusco = true;
            ViewBag.MsjVacio = null;

            // esto es gpt - voy a hablar con el profe a ver que onda

            codSalida = codSalida?.ToUpper().Trim() ?? "";
            codLlegada = codLlegada?.ToUpper().Trim() ?? "";

            if (string.IsNullOrEmpty(codSalida) && string.IsNullOrEmpty(codLlegada))
            {
                ViewBag.MsjVacio = "Debe ingresar al menos un código de aeropuerto";
                return View();
            }

            List<Vuelo> auxVuelos = _sistema.BuscarVuelosPorCodigo(codSalida, codLlegada);
            return View(auxVuelos);
        }
    }
}

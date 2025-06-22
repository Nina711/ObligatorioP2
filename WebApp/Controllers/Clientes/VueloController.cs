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
            if(HttpContext.Session.GetString("correo") != null)
            ViewBag.Vuelos = _sistema.Vuelos;
            return View();
        }

        [HttpGet]
        public IActionResult Buscador()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buscador(string codSalida, string codLlegada)
        {
            ViewBag.Mensaje = null;

            try
            {
                List<Vuelo> auxVuelos = _sistema.BuscarVuelosPorCodigo(codSalida?.ToUpper(), codLlegada?.ToUpper());

                if (auxVuelos.Count == 0)
                {
                    ViewBag.Mensaje = "No se encontraron vuelos para los códigos ingresados.";
                }

                return View(auxVuelos);

            }
            catch (Exception ex)
            {

                ViewBag.Mensaje = ex.Message;
                return View(new List<Vuelo>());
            }
        }
    }
}

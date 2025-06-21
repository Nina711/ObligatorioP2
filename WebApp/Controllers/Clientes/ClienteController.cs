using Dominio;
using Dominio.Entidades_abstractas;
using Dominio.Entidades_no_abst;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Clientes
{
    public class ClienteController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            //---> La siguiente linea es para probar si funciona el controlador ahora que aun no tenemos login (le paso una cedula de un cliente que existe)
            HttpContext.Session.SetString("cedula", "5291845");
            //<-----------
            string cedula = HttpContext.Session.GetString("cedula");
            Cliente clienteActual = _sistema.BuscarClientePorCedula(cedula);

            if (clienteActual == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(clienteActual);
        }

        public IActionResult MisPasajes()
        {
            return View();
        }
    }
}


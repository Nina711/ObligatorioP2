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
            if (HttpContext.Session.GetString("correo") == null)
            {
                return RedirectToAction("Index", "Registro"); //login no esta hecho aun
            }

            string correo = HttpContext.Session.GetString("correo");
            Cliente clienteActual = _sistema.BuscarClientePorCorreo(correo);

            return View(clienteActual);
        }

        public IActionResult MisPasajes()
        {
            return View();
        }
    }
}


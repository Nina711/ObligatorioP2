using Dominio;
using Dominio.Entidades_abstractas;
using Dominio.Entidades_no_abst;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Clientes
{
    public class ClienteController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        
        public IActionResult MiPerfil()
        {
            Cliente clienteLogueado = _sistema.ObtenerClienteLogueado(HttpContext.Session.GetString("correo"));

            if (clienteLogueado == null)
            {
                return RedirectToAction("Index", "Registro"); 
            }
        
            return View(clienteLogueado);
        }
        
        public IActionResult MisPasajes()
        {
            Cliente clienteLogueado = _sistema.ObtenerClienteLogueado(HttpContext.Session.GetString("correo"));

            if (clienteLogueado == null)
            {
                return RedirectToAction("Index", "Registro"); 
            }

            List<Pasaje> _pasajesCliente = _sistema.ListarPasajesCliente(clienteLogueado);

            return View(_pasajesCliente);

        }

    }
}


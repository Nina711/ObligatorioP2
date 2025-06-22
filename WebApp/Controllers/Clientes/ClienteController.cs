using Dominio;
using Dominio.Entidades_abstractas;
using Dominio.Entidades_no_abst;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Clientes
{
    public class ClienteController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        private Cliente ObtenerClienteLogueado()
        {
            string correo = HttpContext.Session.GetString("correo");

            if (string.IsNullOrEmpty(correo)) return null; // ver

            Usuario userLogueado = _sistema.BuscarUsuarioPorCorreo(correo);
            return userLogueado as Cliente;

        }
        public IActionResult MiPerfil()
        {
            Cliente clienteLogueado = ObtenerClienteLogueado();

            if (clienteLogueado == null)
            {
                return RedirectToAction("Index", "Registro"); //login no esta hecho aun
            }
        
            return View(clienteLogueado);
        }
        
        public IActionResult MisPasajes()
        {
            Cliente clienteLogueado = ObtenerClienteLogueado();

            if (clienteLogueado == null)
            {
                return RedirectToAction("Index", "Registro"); 
            }

            List<Pasaje> _pasajesCliente = _sistema.ListarPasajesCliente(clienteLogueado);

            return View(_pasajesCliente);

        }

    }
}


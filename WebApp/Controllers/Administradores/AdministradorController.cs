using AspNetCoreGeneratedDocument;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Administradores
{
    public class AdministradorController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListarPasajes()
        {

            return View(_sistema.ListarPasajesAdmin());
        }

        public IActionResult ListaClientes()
        {

            return View();
        }

    }
}

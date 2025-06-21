using Microsoft.AspNetCore.Mvc;
using Dominio;
using Dominio.Entidades_abstractas;
using Dominio.Entidades_no_abst;
using System.Reflection.Metadata;

namespace WebApp.Controllers.Anónimos
{
    public class RegistroController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Ocasional());
        }

        [HttpPost]
        public IActionResult Index(Ocasional ocasional)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _sistema.AltaClienteOcasional(ocasional);
                    HttpContext.Session.SetString("correo", ocasional.Correo);
                    return RedirectToAction("Index", "Cliente");
                }
                else
                {
                    throw new Exception("Los datos son inválidos");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(ocasional);
            }
        }

    }
}

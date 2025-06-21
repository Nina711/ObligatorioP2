using Microsoft.AspNetCore.Mvc;
using Dominio;
using Dominio.Entidades_abstractas;
using System.Reflection.Metadata;

namespace WebApp.Controllers.Anónimos
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string correo, string contrasenia)
        {
            try
            {
                if(string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasenia))
                {
                    ViewBag.Mensaje = "Email y contraseña son obligatorios.";
                }
                else
                {
                    
                }

            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }
    }
}

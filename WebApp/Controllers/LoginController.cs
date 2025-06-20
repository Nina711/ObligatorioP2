using Microsoft.AspNetCore.Mvc;
using Dominio;
using Dominio.Entidades;
using System.Reflection.Metadata;

namespace WebApp.Controllers
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
                if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contrasenia))
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

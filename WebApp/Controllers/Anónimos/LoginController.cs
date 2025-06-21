using Microsoft.AspNetCore.Mvc;
using Dominio;
using Dominio.Entidades_abstractas;
using System.Reflection.Metadata;

namespace WebApp.Controllers.Anónimos
{
    public class LoginController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

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
                if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasenia))
                {
                    ViewBag.Mensaje = "Email y contraseña son obligatorios.";
                }
                else
                {
                    Usuario u = _sistema.BuscarClientePorCorreo(correo);
                    if (u != null)
                    {
                        if (u.Contrasenia == contrasenia)
                        {
                            HttpContext.Session.SetString("correo", u.Correo);
                            return RedirectToAction("Index", "Cliente");
                        }
                        else
                        {
                            ViewBag.Mensaje = "Contraseña incorrecta.";
                        }
                    }
                    else
                    {
                        ViewBag.Mensaje = "Usuario no encontrado.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }


        [HttpGet]

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}

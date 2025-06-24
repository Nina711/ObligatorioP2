using Microsoft.AspNetCore.Mvc;
using Dominio;
using Dominio.Entidades_abstractas;
using System.Reflection.Metadata;
using Dominio.Entidades_no_abst;

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
                    Usuario u = _sistema.UsuarioLogueado(correo, contrasenia);
                    if (u != null)
                    { 
                        HttpContext.Session.SetString("correo", u.Correo);

                        if (u is Administrador)
                        {
                            HttpContext.Session.SetString("rol", "admin");
                            return RedirectToAction("Index", "Administrador");
                        }
                        else if ( u is Cliente)
                        {
                            HttpContext.Session.SetString("rol", "cliente");
                            return RedirectToAction("Index", "Vuelo");
                        }
                    }
                    else
                    {
                        ViewBag.Mensaje = "Datos incorrectos.";
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

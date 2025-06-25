using AspNetCoreGeneratedDocument;
using Dominio;
using Dominio.Entidades_abstractas;
using Dominio.Entidades_no_abst;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Administradores
{
    public class AdministradorController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;


        [HttpGet]
        public IActionResult ListarPasajes()
        {
            string rol = HttpContext.Session.GetString("rol");

            if (rol != "admin" && rol != null)
            {
                return RedirectToAction("Index", "Vuelo");
            }
            else if (rol == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(_sistema.ListarPasajesAdmin());
        }

        [HttpGet]
        public IActionResult ListaClientes()
        {
            string rol = HttpContext.Session.GetString("rol");

            if (rol != "admin" && rol != null)
            {
                return RedirectToAction("Index", "Vuelo");
            }
            else if (rol == null)
            {
                return RedirectToAction("Index", "Login");
            }



            return View(_sistema.MostrarListadoClientes());
        }

        // Para editar los puntos del premium

        [HttpGet]
        public IActionResult EditarPuntos(string correo)
        {
            string rol = HttpContext.Session.GetString("rol");

            if (rol != "admin" && rol != null)
            {
                return RedirectToAction("Index", "Vuelo");
            }
            else if (rol == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Usuario usuario = _sistema.BuscarUsuarioPorCorreo(correo);
            Premium p = null;

            try
            {
                if (usuario != null && usuario is Cliente c)
                {
                    p = c as Premium;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }


            return View(p);
        }


        [HttpPost]
        public IActionResult EditarPuntos(int puntos, string correo)
        {
            string rol = HttpContext.Session.GetString("rol");

            if (rol != "admin" && rol != null)
            {
                return RedirectToAction("Index", "Vuelo");
            }
            else if (rol == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Usuario usuario = _sistema.BuscarUsuarioPorCorreo(correo);
            Premium p = null;

            try
            {
                if (usuario != null && usuario is Cliente c)
                {
                    p = c as Premium;

                    if (puntos < 0)
                    {
                        ViewBag.Mensaje = "La cantidad de puntos debe ser mayor a 0.";
                        return View(p);
                    }

                    _sistema.EditarPuntos(p, puntos);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }

            return RedirectToAction("ListaClientes");
        }

        //Para editar la elegibilidad de los ocasionales    

        [HttpGet]
        public IActionResult EditarElegibilidad(string correo)
        {
            string rol = HttpContext.Session.GetString("rol");

            if (rol != "admin" && rol != null)
            {
                return RedirectToAction("Index", "Vuelo");
            }
            else if (rol == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Usuario usuario = _sistema.BuscarUsuarioPorCorreo(correo);
            Ocasional o = null;

            try
            {
                if (usuario != null && usuario is Cliente c)
                {
                    o = c as Ocasional;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }

            return View(o);
        }

        [HttpPost]
        public IActionResult EditarElegibilidad(string correo, string elegibilidad)
        {
            string rol = HttpContext.Session.GetString("rol");

            if (rol != "admin" && rol != null)
            {
                return RedirectToAction("Index", "Vuelo");
            }
            else if (rol == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Usuario usuario = _sistema.BuscarUsuarioPorCorreo(correo);
            Ocasional o = null;

            try
            {
                if (usuario != null && usuario is Cliente c)
                {
                    o = c as Ocasional;

                    if (elegibilidad == "-1")
                    {
                        ViewBag.Mensaje = "Debes seleccionar una opción válida.";
                        return View(o);
                    }

                    _sistema.EditarElegibilidad(o, elegibilidad);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }

            return RedirectToAction("ListaClientes");
        }

    }
}

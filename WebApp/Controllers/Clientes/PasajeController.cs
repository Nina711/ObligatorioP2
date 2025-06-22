using Dominio;
using Dominio.Entidades_abstractas;
using Dominio.Entidades_no_abst;
using Dominio.Enumeraciones;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers.Clientes
{
    public class PasajeController : Controller

    {
        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Comprar(string numVuelo)
        {
            Vuelo vuelo = _sistema.BuscarVueloPorId(numVuelo);
            ViewBag.TiposEquipaje = Enum.GetValues(typeof(Equipaje));


            if (vuelo == null)
            {
                return RedirectToAction("Index", "Vuelo");
            }

            return View(vuelo);
        }

        [HttpPost]
        public IActionResult Comprar(string numVuelo, DateTime fechaPasaje, Equipaje equipaje)
        {
            Vuelo vuelo = _sistema.BuscarVueloPorId(numVuelo);
            string correo = HttpContext.Session.GetString("correo");
            Usuario Upasajero = _sistema.BuscarUsuarioPorCorreo(correo);
            Cliente pasajero = Upasajero as Cliente;


            if (vuelo == null)
            {
                return RedirectToAction("Index", "Vuelo");
            }

            try
            {
                decimal precioPasaje = _sistema.CalcularPrecioPasaje(vuelo, pasajero, equipaje);
                Pasaje p = new Pasaje(vuelo, fechaPasaje, pasajero, equipaje, precioPasaje);
                _sistema.AgregarPasaje(p);
                return RedirectToAction("MisPasajes", "Cliente");
            }

            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                ViewBag.TiposEquipaje = Enum.GetValues(typeof(Equipaje));
                return View(vuelo);
            }
        }
    }
}

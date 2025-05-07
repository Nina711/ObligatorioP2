using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades_no_abst;
using Dominio.Entidades_abstractas;
using Dominio.Enumeraciones;

namespace Dominio
{
    public class Sistema
    {
        private List<Cliente> _clientes = new List<Cliente>();
        private List<Avion> _aviones = new List<Avion>();
        private List<Aeropuerto> _aeropuertos = new List<Aeropuerto>();
        private List<Ruta> _rutas = new List<Ruta>();
        private List<Vuelo> _vuelos = new List<Vuelo>();
        private List<Pasaje> _pasajes = new List<Pasaje>();

        //no va a servir esto pero lo dejare por el cariño <3
        /*public decimal CalcularPrecioPasaje (Pasaje pasaje)
        {
            //obtengo el vuelo del pasaje
            Vuelo vueloDelPasaje = Pasaje.Vuelo;
            //hago la primera parte del calculo
            decimal costoPasaje = vueloDelPasaje.CostoAsiento + (vueloDelPasaje.CostoAsiento * 0.25);
            //obtengo ruta
            Ruta rutaDelPasaje = vueloDelPasaje.Ruta();
            //le sumo costo de operaciones de aeropuertos
            costoPasaje += rutaDelPasaje.CalcularCostoOperacionAeropuertos();

            costoPasaje += Pasaje.CalcularCostoEquipaje();            

            return costoPasaje;
        }*/


        //Precargar datos de prueba
        private void PrecargarDatos()
        {
            PrecargaUsuarios();
            PrecargaAviones();
            PrecargaAeropuertos();
            PrecargaRutas();
            PrecargaVuelos();
            PrecargaPasajes();
        }

        private void PrecargaUsuarios()
        {

        }

        private void PrecargaAviones()
        {

            _aviones.Add(new Avion("Boeing", "737 MAX", 200, 6570.5m, 8500.75m));
            _aviones.Add(new Avion("Airbus", "A320", 180, 6000.0m, 8000.50m));
            _aviones.Add(new Avion("Embraer", "E190", 100, 4000.0m, 5000.25m));
            _aviones.Add(new Avion("Bombardier", "CRJ900", 90, 3500.0m, 4500.00m));
        }

        private void PrecargaAeropuertos()
        {
            _aeropuertos.Add(new Aeropuerto("EZE", "Buenos Aires", 15000m, 2000m));
            _aeropuertos.Add(new Aeropuerto("MEX", "Ciudad de México", 14000m, 1800m));
            _aeropuertos.Add(new Aeropuerto("JFK", "Nueva York", 18000m, 2500m));
            _aeropuertos.Add(new Aeropuerto("LAX", "Los Ángeles", 17500m, 2400m));
            _aeropuertos.Add(new Aeropuerto("SCL", "Santiago", 13000m, 1900m));
            _aeropuertos.Add(new Aeropuerto("GRU", "São Paulo", 16000m, 2100m));
            _aeropuertos.Add(new Aeropuerto("BOG", "Bogotá", 14500m, 1700m));
            _aeropuertos.Add(new Aeropuerto("LIM", "Lima", 12500m, 1600m));
            _aeropuertos.Add(new Aeropuerto("MAD", "Madrid", 17000m, 2300m));
            _aeropuertos.Add(new Aeropuerto("CDG", "París", 18500m, 2500m));
            _aeropuertos.Add(new Aeropuerto("FRA", "Frankfurt", 17500m, 2200m));
            _aeropuertos.Add(new Aeropuerto("AMS", "Ámsterdam", 16500m, 2100m));
            _aeropuertos.Add(new Aeropuerto("BCN", "Barcelona", 16000m, 2000m));
            _aeropuertos.Add(new Aeropuerto("LHR", "Londres", 19000m, 2600m));
            _aeropuertos.Add(new Aeropuerto("ROM", "Roma", 15000m, 1900m));
            _aeropuertos.Add(new Aeropuerto("YYZ", "Toronto", 16500m, 2000m));
            _aeropuertos.Add(new Aeropuerto("MIA", "Miami", 16000m, 2100m));
            _aeropuertos.Add(new Aeropuerto("ATL", "Atlanta", 17000m, 2200m));
            _aeropuertos.Add(new Aeropuerto("DFW", "Dallas", 16800m, 2150m));
            _aeropuertos.Add(new Aeropuerto("SYD", "Sídney", 19500m, 2700m));
        }

        private void PrecargaRutas()
        {
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();
            _rutas.Add();

        }

        private void PrecargaVuelos()
        {
        }   

        private void PrecargaPasajes()
        {
        }   


        //Métodos para mostrar info en consola
        public string MostrarListadoClientes()
        {
            string listado = "";

            foreach (Cliente c in _clientes)
            {
                listado += c.ToString();
            }

            return listado;
        }

    }
}

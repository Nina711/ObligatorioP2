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
        private List<Usuario> _usuarios = new List<Usuario>();
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
        public void PrecargarDatos()
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
            _usuarios.Add(new Premium("juan.perez@example.com", "1234", "DNI001", "Juan Pérez", "Argentina"));
            _usuarios.Add(new Premium("ana.lopez@example.com", "abcd", "DNI002", "Ana López", "México"));
            _usuarios.Add(new Premium("carlos.ramos@example.com", "pass123", "DNI003", "Carlos Ramos", "Chile"));
            _usuarios.Add(new Premium("laura.mendez@example.com", "secure", "DNI004", "Laura Méndez", "Perú"));
            _usuarios.Add(new Premium("roberto.garcia@example.com", "clave", "DNI005", "Roberto García", "Uruguay"));
            _usuarios.Add(new Ocasional("maria.fernandez@example.com", "4321", "DOC001", "María Fernández", "Colombia"));
            _usuarios.Add(new Ocasional("jose.martin@example.com", "qwer", "DOC002", "José Martín", "Paraguay"));
            _usuarios.Add(new Ocasional("sofia.hernandez@example.com", "asdf", "DOC003", "Sofía Hernández", "Ecuador"));
            _usuarios.Add(new Ocasional("diego.rios@example.com", "zxcv", "DOC004", "Diego Ríos", "Bolivia"));
            _usuarios.Add(new Ocasional("valentina.sosa@example.com", "mnbv", "DOC005", "Valentina Sosa", "Venezuela"));

            _usuarios.Add(new Administrador("admin1@example.com", "adminpass1", "AdminUno"));
            _usuarios.Add(new Administrador("admin2@example.com", "adminpass2", "AdminDos"));
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
            _rutas.Add(new Ruta(_aeropuertos[0], _aeropuertos[1], 700m));
            _rutas.Add(new Ruta(_aeropuertos[1], _aeropuertos[2], 850m));
            _rutas.Add(new Ruta(_aeropuertos[2], _aeropuertos[3], 900m));
            _rutas.Add(new Ruta(_aeropuertos[3], _aeropuertos[4], 1100m));
            _rutas.Add(new Ruta(_aeropuertos[4], _aeropuertos[5], 1300m));
            _rutas.Add(new Ruta(_aeropuertos[5], _aeropuertos[6], 1600m));
            _rutas.Add(new Ruta(_aeropuertos[6], _aeropuertos[7], 1400m));
            _rutas.Add(new Ruta(_aeropuertos[7], _aeropuertos[8], 1700m));
            _rutas.Add(new Ruta(_aeropuertos[8], _aeropuertos[9], 1800m));
            _rutas.Add(new Ruta(_aeropuertos[9], _aeropuertos[10], 1900m));
            _rutas.Add(new Ruta(_aeropuertos[10], _aeropuertos[11], 2000m));
            _rutas.Add(new Ruta(_aeropuertos[11], _aeropuertos[12], 2100m));
            _rutas.Add(new Ruta(_aeropuertos[12], _aeropuertos[13], 1900m));
            _rutas.Add(new Ruta(_aeropuertos[13], _aeropuertos[14], 1750m));
            _rutas.Add(new Ruta(_aeropuertos[14], _aeropuertos[15], 1650m));
            _rutas.Add(new Ruta(_aeropuertos[15], _aeropuertos[16], 1550m));
            _rutas.Add(new Ruta(_aeropuertos[16], _aeropuertos[17], 1500m));
            _rutas.Add(new Ruta(_aeropuertos[17], _aeropuertos[18], 1700m));
            _rutas.Add(new Ruta(_aeropuertos[18], _aeropuertos[19], 2000m));
            _rutas.Add(new Ruta(_aeropuertos[19], _aeropuertos[0], 2500m));
            _rutas.Add(new Ruta(_aeropuertos[0], _aeropuertos[5], 2200m));
            _rutas.Add(new Ruta(_aeropuertos[1], _aeropuertos[6], 2100m));
            _rutas.Add(new Ruta(_aeropuertos[2], _aeropuertos[7], 2400m));
            _rutas.Add(new Ruta(_aeropuertos[3], _aeropuertos[8], 2600m));
            _rutas.Add(new Ruta(_aeropuertos[4], _aeropuertos[9], 2800m));
            _rutas.Add(new Ruta(_aeropuertos[5], _aeropuertos[10], 2900m));
            _rutas.Add(new Ruta(_aeropuertos[6], _aeropuertos[11], 3100m));
            _rutas.Add(new Ruta(_aeropuertos[7], _aeropuertos[12], 3300m));
            _rutas.Add(new Ruta(_aeropuertos[8], _aeropuertos[13], 3500m));
            _rutas.Add(new Ruta(_aeropuertos[9], _aeropuertos[14], 3600m)); ;
        }

        private void PrecargaVuelos()
        {
            _vuelos.Add(new Vuelo("V001", _rutas[0], _aviones[0], new List<Frecuencia> { Frecuencia.Lunes, Frecuencia.Viernes }));
            _vuelos.Add(new Vuelo("V002", _rutas[1], _aviones[1], new List<Frecuencia> { Frecuencia.Martes, Frecuencia.Sábado }));
            _vuelos.Add(new Vuelo("V003", _rutas[2], _aviones[2], new List<Frecuencia> { Frecuencia.Miércoles }));
            _vuelos.Add(new Vuelo("V004", _rutas[3], _aviones[3], new List<Frecuencia> { Frecuencia.Jueves, Frecuencia.Domingo }));
            _vuelos.Add(new Vuelo("V005", _rutas[4], _aviones[0], new List<Frecuencia> { Frecuencia.Lunes }));

            _vuelos.Add(new Vuelo("V006", _rutas[5], _aviones[1], new List<Frecuencia> { Frecuencia.Martes, Frecuencia.Viernes }));
            _vuelos.Add(new Vuelo("V007", _rutas[6], _aviones[2], new List<Frecuencia> { Frecuencia.Sábado }));
            _vuelos.Add(new Vuelo("V008", _rutas[7], _aviones[3], new List<Frecuencia> { Frecuencia.Jueves }));
            _vuelos.Add(new Vuelo("V009", _rutas[8], _aviones[0], new List<Frecuencia> { Frecuencia.Lunes, Frecuencia.Miércoles }));
            _vuelos.Add(new Vuelo("V010", _rutas[9], _aviones[1], new List<Frecuencia> { Frecuencia.Domingo }));

            _vuelos.Add(new Vuelo("V011", _rutas[10], _aviones[2], new List<Frecuencia> { Frecuencia.Viernes }));
            _vuelos.Add(new Vuelo("V012", _rutas[11], _aviones[3], new List<Frecuencia> { Frecuencia.Martes, Frecuencia.Sábado }));
            _vuelos.Add(new Vuelo("V013", _rutas[12], _aviones[0], new List<Frecuencia> { Frecuencia.Jueves }));
            _vuelos.Add(new Vuelo("V014", _rutas[13], _aviones[1], new List<Frecuencia> { Frecuencia.Lunes }));
            _vuelos.Add(new Vuelo("V015", _rutas[14], _aviones[2], new List<Frecuencia> { Frecuencia.Miércoles }));

            _vuelos.Add(new Vuelo("V016", _rutas[15], _aviones[3], new List<Frecuencia> { Frecuencia.Martes }));
            _vuelos.Add(new Vuelo("V017", _rutas[16], _aviones[0], new List<Frecuencia> { Frecuencia.Jueves }));
            _vuelos.Add(new Vuelo("V018", _rutas[17], _aviones[1], new List<Frecuencia> { Frecuencia.Sábado }));
            _vuelos.Add(new Vuelo("V019", _rutas[18], _aviones[2], new List<Frecuencia> { Frecuencia.Lunes, Frecuencia.Viernes }));
            _vuelos.Add(new Vuelo("V020", _rutas[19], _aviones[3], new List<Frecuencia> { Frecuencia.Domingo }));

            _vuelos.Add(new Vuelo("V021", _rutas[20], _aviones[0], new List<Frecuencia> { Frecuencia.Miércoles }));
            _vuelos.Add(new Vuelo("V022", _rutas[21], _aviones[1], new List<Frecuencia> { Frecuencia.Martes }));
            _vuelos.Add(new Vuelo("V023", _rutas[22], _aviones[2], new List<Frecuencia> { Frecuencia.Viernes, Frecuencia.Domingo }));
            _vuelos.Add(new Vuelo("V024", _rutas[23], _aviones[3], new List<Frecuencia> { Frecuencia.Sábado }));
            _vuelos.Add(new Vuelo("V025", _rutas[24], _aviones[0], new List<Frecuencia> { Frecuencia.Lunes }));

            _vuelos.Add(new Vuelo("V026", _rutas[25], _aviones[1], new List<Frecuencia> { Frecuencia.Martes, Frecuencia.Jueves }));
            _vuelos.Add(new Vuelo("V027", _rutas[26], _aviones[2], new List<Frecuencia> { Frecuencia.Miércoles }));
            _vuelos.Add(new Vuelo("V028", _rutas[27], _aviones[3], new List<Frecuencia> { Frecuencia.Viernes }));
            _vuelos.Add(new Vuelo("V029", _rutas[28], _aviones[0], new List<Frecuencia> { Frecuencia.Sábado }));
            _vuelos.Add(new Vuelo("V030", _rutas[29], _aviones[1], new List<Frecuencia> { Frecuencia.Domingo }));
        }   

        private void PrecargaPasajes()
        {
        }   


        //Métodos para mostrar info en consola
        public string MostrarListadoClientes()
        {
            string listado = "";

            foreach (Usuario u in _usuarios)
            {
                if (u is Premium || u is Ocasional)
                {
                    listado += u.ToString();
                }
            }

            return listado;
        }

        //public Aeropuerto BuscarAeropuerto(string codigo)
        //{
        //    int i = 0;
        //    Aeropuerto aeropuertoEncontrado = null;

        //    while (aeropuertoEncontrado == null && i < _aeropuertos.Count)
        //    {
        //        Aeropuerto a = _aeropuertos[i];

        //        if (codigo == a.Codigo)
        //        {
        //            aeropuertoEncontrado = a;
        //        }
        //    }

        //    return aeropuertoEncontrado;
        //}


        public string VuelosPorCodigo(string codigo)
        {
            string lista = "";

            foreach(Vuelo v in _vuelos)
            {
                if (v.ObtenerAeropuertoSalida() == codigo.ToUpper() || v.ObtenerAeropuertoLlegada() == codigo.ToUpper())
                {
                    lista += v.ToString();
                }
            }

            if (string.IsNullOrWhiteSpace(lista))
            {
                lista = "No se encontraron vuelos para el código de aeropuerto ingresado.";
            }

            return lista;
        }

    }
}

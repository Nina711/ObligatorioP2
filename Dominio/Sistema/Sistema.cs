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
            AltaClientePremium(new Premium("juan.perez@example.com", "1234", "4312003", "Juan Pérez", "Argentina"));
            AltaClientePremium(new Premium("ana.lopez@example.com", "abcd", "5291845", "Ana López", "México"));
            AltaClientePremium(new Premium("carlos.ramos@example.com", "pass123", "3289011", "Carlos Ramos", "Chile"));
            AltaClientePremium(new Premium("laura.mendez@example.com", "secure", "6102344", "Laura Méndez", "Perú"));
            AltaClientePremium(new Premium("roberto.garcia@example.com", "clave", "4721890", "Roberto García", "Uruguay"));

            AltaClienteOcasional(new Ocasional("maria.fernandez@example.com", "4321", "3851205", "María Fernández", "Colombia"));           
            AltaClienteOcasional(new Ocasional("jose.martin@example.com", "qwer", "2940312", "José Martín", "Paraguay"));
            AltaClienteOcasional(new Ocasional("sofia.hernandez@example.com", "asdf", "6372001", "Sofía Hernández", "Ecuador"));
            AltaClienteOcasional(new Ocasional("diego.rios@example.com", "zxcv", "5031943", "Diego Ríos", "Bolivia"));
            AltaClienteOcasional(new Ocasional("valentina.sosa@example.com", "mnbv", "6178432", "Valentina Sosa", "Venezuela"));

            AgregarAdministrador(new Administrador("admin1@example.com", "adminpass1", "AdminUno"));
            AgregarAdministrador(new Administrador("admin2@example.com", "adminpass2", "AdminDos"));
        }

        private void PrecargaAviones()
        {
            AgregarAvion(new Avion("Boeing", "737 MAX", 200, 6570.5m, 8500.75m));
            AgregarAvion(new Avion("Airbus", "A320", 180, 6000.0m, 8000.50m));
            AgregarAvion(new Avion("Embraer", "E190", 100, 4000.0m, 5000.25m));
            AgregarAvion(new Avion("Bombardier", "CRJ900", 90, 3500.0m, 4500.00m));
        }

        private void PrecargaAeropuertos()
        {
            AgregarAeropuerto(new Aeropuerto("EZE", "Buenos Aires", 15000m, 2000m));
            AgregarAeropuerto(new Aeropuerto("MEX", "Ciudad de México", 14000m, 1800m));
            AgregarAeropuerto(new Aeropuerto("JFK", "Nueva York", 18000m, 2500m));
            AgregarAeropuerto(new Aeropuerto("LAX", "Los Ángeles", 17500m, 2400m));
            AgregarAeropuerto(new Aeropuerto("SCL", "Santiago", 13000m, 1900m));
            AgregarAeropuerto(new Aeropuerto("GRU", "São Paulo", 16000m, 2100m));
            AgregarAeropuerto(new Aeropuerto("BOG", "Bogotá", 14500m, 1700m));
            AgregarAeropuerto(new Aeropuerto("LIM", "Lima", 12500m, 1600m));
            AgregarAeropuerto(new Aeropuerto("MAD", "Madrid", 17000m, 2300m));
            AgregarAeropuerto(new Aeropuerto("CDG", "París", 18500m, 2500m));
            AgregarAeropuerto(new Aeropuerto("FRA", "Frankfurt", 17500m, 2200m));
            AgregarAeropuerto(new Aeropuerto("AMS", "Ámsterdam", 16500m, 2100m));
            AgregarAeropuerto(new Aeropuerto("BCN", "Barcelona", 16000m, 2000m));
            AgregarAeropuerto(new Aeropuerto("LHR", "Londres", 19000m, 2600m));
            AgregarAeropuerto(new Aeropuerto("ROM", "Roma", 15000m, 1900m));
            AgregarAeropuerto(new Aeropuerto("YYZ", "Toronto", 16500m, 2000m));
            AgregarAeropuerto(new Aeropuerto("MIA", "Miami", 16000m, 2100m));
            AgregarAeropuerto(new Aeropuerto("ATL", "Atlanta", 17000m, 2200m));
            AgregarAeropuerto(new Aeropuerto("DFW", "Dallas", 16800m, 2150m));
            AgregarAeropuerto(new Aeropuerto("SYD", "Sídney", 19500m, 2700m));
        }

        private void PrecargaRutas()
        {
            AgregarRuta(new Ruta(_aeropuertos[0], _aeropuertos[1], 700m));
            AgregarRuta(new Ruta(_aeropuertos[1], _aeropuertos[2], 850m));
            AgregarRuta(new Ruta(_aeropuertos[2], _aeropuertos[3], 900m));
            AgregarRuta(new Ruta(_aeropuertos[3], _aeropuertos[4], 1100m));
            AgregarRuta(new Ruta(_aeropuertos[4], _aeropuertos[5], 1300m));
            AgregarRuta(new Ruta(_aeropuertos[5], _aeropuertos[6], 1600m));
            AgregarRuta(new Ruta(_aeropuertos[6], _aeropuertos[7], 1400m));
            AgregarRuta(new Ruta(_aeropuertos[7], _aeropuertos[8], 1700m));
            AgregarRuta(new Ruta(_aeropuertos[8], _aeropuertos[9], 1800m));
            AgregarRuta(new Ruta(_aeropuertos[9], _aeropuertos[10], 1900m));
            AgregarRuta(new Ruta(_aeropuertos[10], _aeropuertos[11], 2000m));
            AgregarRuta(new Ruta(_aeropuertos[11], _aeropuertos[12], 2100m));
            AgregarRuta(new Ruta(_aeropuertos[12], _aeropuertos[13], 1900m));
            AgregarRuta(new Ruta(_aeropuertos[13], _aeropuertos[14], 1750m));
            AgregarRuta(new Ruta(_aeropuertos[14], _aeropuertos[15], 1650m));
            AgregarRuta(new Ruta(_aeropuertos[15], _aeropuertos[16], 1550m));
            AgregarRuta(new Ruta(_aeropuertos[16], _aeropuertos[17], 1500m));
            AgregarRuta(new Ruta(_aeropuertos[17], _aeropuertos[18], 1700m));
            AgregarRuta(new Ruta(_aeropuertos[18], _aeropuertos[19], 2000m));
            AgregarRuta(new Ruta(_aeropuertos[19], _aeropuertos[0], 2500m));
            AgregarRuta(new Ruta(_aeropuertos[0], _aeropuertos[5], 2200m));
            AgregarRuta(new Ruta(_aeropuertos[1], _aeropuertos[6], 2100m));
            AgregarRuta(new Ruta(_aeropuertos[2], _aeropuertos[7], 2400m));
            AgregarRuta(new Ruta(_aeropuertos[3], _aeropuertos[8], 2600m));
            AgregarRuta(new Ruta(_aeropuertos[4], _aeropuertos[9], 2800m));
            AgregarRuta(new Ruta(_aeropuertos[5], _aeropuertos[10], 2900m));
            AgregarRuta(new Ruta(_aeropuertos[6], _aeropuertos[11], 3100m));
            AgregarRuta(new Ruta(_aeropuertos[7], _aeropuertos[12], 3300m));
            AgregarRuta(new Ruta(_aeropuertos[8], _aeropuertos[13], 3500m));
            AgregarRuta(new Ruta(_aeropuertos[9], _aeropuertos[14], 3600m));
        }

        private void PrecargaVuelos()
        {
            AgregarVuelo(new Vuelo("V001", _rutas[0], _aviones[0], new List<Frecuencia> { Frecuencia.Lunes, Frecuencia.Viernes }));
            AgregarVuelo(new Vuelo("V002", _rutas[1], _aviones[1], new List<Frecuencia> { Frecuencia.Martes, Frecuencia.Sábado }));
            AgregarVuelo(new Vuelo("V003", _rutas[2], _aviones[2], new List<Frecuencia> { Frecuencia.Miércoles }));
            AgregarVuelo(new Vuelo("V004", _rutas[3], _aviones[3], new List<Frecuencia> { Frecuencia.Jueves, Frecuencia.Domingo }));
            AgregarVuelo(new Vuelo("V005", _rutas[4], _aviones[0], new List<Frecuencia> { Frecuencia.Lunes }));
            AgregarVuelo(new Vuelo("V006", _rutas[5], _aviones[1], new List<Frecuencia> { Frecuencia.Martes, Frecuencia.Viernes }));
            AgregarVuelo(new Vuelo("V007", _rutas[6], _aviones[2], new List<Frecuencia> { Frecuencia.Sábado }));
            AgregarVuelo(new Vuelo("V008", _rutas[7], _aviones[3], new List<Frecuencia> { Frecuencia.Jueves }));
            AgregarVuelo(new Vuelo("V009", _rutas[8], _aviones[0], new List<Frecuencia> { Frecuencia.Lunes, Frecuencia.Miércoles }));
            AgregarVuelo(new Vuelo("V010", _rutas[9], _aviones[1], new List<Frecuencia> { Frecuencia.Domingo }));
            AgregarVuelo(new Vuelo("V011", _rutas[10], _aviones[2], new List<Frecuencia> { Frecuencia.Viernes }));
            AgregarVuelo(new Vuelo("V012", _rutas[11], _aviones[3], new List<Frecuencia> { Frecuencia.Martes, Frecuencia.Sábado }));
            AgregarVuelo(new Vuelo("V013", _rutas[12], _aviones[0], new List<Frecuencia> { Frecuencia.Jueves }));
            AgregarVuelo(new Vuelo("V014", _rutas[13], _aviones[1], new List<Frecuencia> { Frecuencia.Lunes }));
            AgregarVuelo(new Vuelo("V015", _rutas[14], _aviones[2], new List<Frecuencia> { Frecuencia.Miércoles }));
            AgregarVuelo(new Vuelo("V016", _rutas[15], _aviones[3], new List<Frecuencia> { Frecuencia.Martes }));
            AgregarVuelo(new Vuelo("V017", _rutas[16], _aviones[0], new List<Frecuencia> { Frecuencia.Jueves }));
            AgregarVuelo(new Vuelo("V018", _rutas[17], _aviones[1], new List<Frecuencia> { Frecuencia.Sábado }));
            AgregarVuelo(new Vuelo("V019", _rutas[18], _aviones[2], new List<Frecuencia> { Frecuencia.Lunes, Frecuencia.Viernes }));
            AgregarVuelo(new Vuelo("V020", _rutas[19], _aviones[3], new List<Frecuencia> { Frecuencia.Domingo }));
            AgregarVuelo(new Vuelo("V021", _rutas[20], _aviones[0], new List<Frecuencia> { Frecuencia.Miércoles }));
            AgregarVuelo(new Vuelo("V022", _rutas[21], _aviones[1], new List<Frecuencia> { Frecuencia.Martes }));
            AgregarVuelo(new Vuelo("V023", _rutas[22], _aviones[2], new List<Frecuencia> { Frecuencia.Viernes, Frecuencia.Domingo }));
            AgregarVuelo(new Vuelo("V024", _rutas[23], _aviones[3], new List<Frecuencia> { Frecuencia.Sábado }));
            AgregarVuelo(new Vuelo("V025", _rutas[24], _aviones[0], new List<Frecuencia> { Frecuencia.Lunes }));
            AgregarVuelo(new Vuelo("V026", _rutas[25], _aviones[1], new List<Frecuencia> { Frecuencia.Martes, Frecuencia.Jueves }));
            AgregarVuelo(new Vuelo("V027", _rutas[26], _aviones[2], new List<Frecuencia> { Frecuencia.Miércoles }));
            AgregarVuelo(new Vuelo("V028", _rutas[27], _aviones[3], new List<Frecuencia> { Frecuencia.Viernes }));
            AgregarVuelo(new Vuelo("V029", _rutas[28], _aviones[0], new List<Frecuencia> { Frecuencia.Sábado }));
            AgregarVuelo(new Vuelo("V030", _rutas[29], _aviones[1], new List<Frecuencia> { Frecuencia.Domingo }));
        }

        private void PrecargaPasajes()
        {
            AgregarPasaje(new Pasaje(_vuelos[0], DateTime.Now.AddDays(1), (Cliente)_usuarios[0], Equipaje.light, 150.50m));
            AgregarPasaje(new Pasaje(_vuelos[1], DateTime.Now.AddDays(2), (Cliente)_usuarios[1], Equipaje.cabina, 200.00m));
            AgregarPasaje(new Pasaje(_vuelos[2], DateTime.Now.AddDays(3), (Cliente)_usuarios[2], Equipaje.bodega, 300.00m));
            AgregarPasaje(new Pasaje(_vuelos[3], DateTime.Now.AddDays(4), (Cliente)_usuarios[3], Equipaje.light, 180.75m));
            AgregarPasaje(new Pasaje(_vuelos[4], DateTime.Now.AddDays(5), (Cliente)_usuarios[4], Equipaje.cabina, 220.20m));
            AgregarPasaje(new Pasaje(_vuelos[5], DateTime.Now.AddDays(1), (Cliente)_usuarios[5], Equipaje.bodega, 350.00m));
            AgregarPasaje(new Pasaje(_vuelos[6], DateTime.Now.AddDays(2), (Cliente)_usuarios[6], Equipaje.light, 120.00m));
            AgregarPasaje(new Pasaje(_vuelos[7], DateTime.Now.AddDays(3), (Cliente)_usuarios[7], Equipaje.cabina, 270.00m));
            AgregarPasaje(new Pasaje(_vuelos[8], DateTime.Now.AddDays(4), (Cliente)_usuarios[8], Equipaje.bodega, 330.00m));
            AgregarPasaje(new Pasaje(_vuelos[9], DateTime.Now.AddDays(5), (Cliente)_usuarios[9], Equipaje.light, 199.99m));
            AgregarPasaje(new Pasaje(_vuelos[10], DateTime.Now.AddDays(1), (Cliente)_usuarios[0], Equipaje.cabina, 210.10m));
            AgregarPasaje(new Pasaje(_vuelos[11], DateTime.Now.AddDays(2), (Cliente)_usuarios[1], Equipaje.bodega, 289.95m));
            AgregarPasaje(new Pasaje(_vuelos[12], DateTime.Now.AddDays(3), (Cliente)_usuarios[2], Equipaje.light, 190.00m));
            AgregarPasaje(new Pasaje(_vuelos[13], DateTime.Now.AddDays(4), (Cliente)_usuarios[3], Equipaje.cabina, 250.00m));
            AgregarPasaje(new Pasaje(_vuelos[14], DateTime.Now.AddDays(5), (Cliente)_usuarios[4], Equipaje.bodega, 310.00m));
            AgregarPasaje(new Pasaje(_vuelos[15], DateTime.Now.AddDays(1), (Cliente)_usuarios[5], Equipaje.light, 175.50m));
            AgregarPasaje(new Pasaje(_vuelos[16], DateTime.Now.AddDays(2), (Cliente)_usuarios[6], Equipaje.cabina, 240.00m));
            AgregarPasaje(new Pasaje(_vuelos[17], DateTime.Now.AddDays(3), (Cliente)_usuarios[7], Equipaje.bodega, 320.00m));
            AgregarPasaje(new Pasaje(_vuelos[18], DateTime.Now.AddDays(4), (Cliente)_usuarios[8], Equipaje.light, 160.00m));
            AgregarPasaje(new Pasaje(_vuelos[19], DateTime.Now.AddDays(5), (Cliente)_usuarios[9], Equipaje.cabina, 230.00m));
            AgregarPasaje(new Pasaje(_vuelos[20], DateTime.Now.AddDays(1), (Cliente)_usuarios[0], Equipaje.bodega, 280.00m));
            AgregarPasaje(new Pasaje(_vuelos[21], DateTime.Now.AddDays(2), (Cliente)_usuarios[1], Equipaje.light, 135.00m));
            AgregarPasaje(new Pasaje(_vuelos[22], DateTime.Now.AddDays(3), (Cliente)_usuarios[2], Equipaje.cabina, 220.00m));
            AgregarPasaje(new Pasaje(_vuelos[23], DateTime.Now.AddDays(4), (Cliente)_usuarios[3], Equipaje.bodega, 290.00m));
            AgregarPasaje(new Pasaje(_vuelos[24], DateTime.Now.AddDays(5), (Cliente)_usuarios[4], Equipaje.light, 160.00m));
        }

        // Método para listar clientes
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

            if (string.IsNullOrWhiteSpace(listado))
            {
                throw new Exception ("Aun no hay clientes registrados.");
            }

            return listado;
        }

        // Método para mostrar vuelos por código de aeropuerto en consola
        public string VuelosPorCodigo(string codigo)
        {
            string lista = "";

            foreach (Vuelo v in _vuelos)
            {
                if (v.ObtenerAeropuertoSalida().Contains(codigo.ToUpper()) || v.ObtenerAeropuertoLlegada().Contains(codigo.ToUpper()))
                {
                    lista += v.ToString();
                }
            }

            if (string.IsNullOrWhiteSpace(lista))
            {
                throw new Exception ("No se encontraron vuelos para el código de aeropuerto ingresado.");
            }

            return lista;
        }

        // Metodo para listar pasajes
        public List<Pasaje> PasajesEntreFechas(DateTime desde, DateTime hasta)
        {
            if (desde > hasta)
            {
                throw new Exception("La fecha de inicio no puede ser mayor a la de fin.");
            }

            List<Pasaje> _pasajesFiltrados = new List<Pasaje>();

            foreach (Pasaje p in _pasajes)
            {
                if (p.Fecha >= desde && p.Fecha <= hasta)
                {
                    _pasajesFiltrados.Add(p);
                }
            }

            return _pasajesFiltrados;
        }

        // ---- MÉTODOS PARA AGREGAR INSTANCIAS A LAS LISTAS

        public void AltaClienteOcasional(Ocasional ocasional)
        {
            if (ocasional == null)
            {
                throw new Exception("Debe ingresar un cliente");
            }

            ocasional.Validar();

            if (_usuarios.Contains(ocasional))
            {
                throw new Exception("Cliente no agregado. Ya existe un cliente con ese documento de identidad.");
            }

            _usuarios.Add(ocasional);
        }

        public void AltaClientePremium(Premium premium)
        {
            if (premium == null)
            {
                throw new Exception("Debe ingresar un cliente");
            }

            premium.Validar();

            if (_usuarios.Contains(premium))
            {
                throw new Exception("Ya existe un cliente con ese documento de identidad.");
            }

            _usuarios.Add(premium);
        }

        public void AgregarAdministrador(Administrador admin)
        {
            if (admin == null)
            {
                throw new Exception("Debe ingresar un administrador");
            }

            admin.Validar();

            if (_usuarios.Contains(admin))
            {
                throw new Exception("Ya existe un administrador con ese alias.");
            }

            _usuarios.Add(admin);
        }

        public void AgregarAeropuerto(Aeropuerto aerop)
        {
            if (aerop == null)
            {
                throw new Exception("Debe ingresar un aeropuerto");
            }

            aerop.Validar();

            if (_aeropuertos.Contains(aerop))
            {
                throw new Exception("Ya existe un aeropuerto con ese código.");
            }

            _aeropuertos.Add(aerop);
        }

        public void AgregarPasaje(Pasaje pasaje)
        {
            
            if (pasaje == null)
            {
                throw new Exception("Debe ingresar un pasaje");
            }

            pasaje.Validar();

            if (_pasajes.Contains(pasaje))
            {
                throw new Exception("Ya se emitió un pasaje con ese id.");
            }

            _pasajes.Add(pasaje);
            
        }

        public void AgregarRuta(Ruta ruta)
        {
            if (ruta == null)
            {
                throw new Exception("Debe ingresar una ruta");
            }

            ruta.Validar();

            if (_rutas.Contains(ruta))
            {
                throw new Exception("Ya existe una ruta con ese id.");
            }

            _rutas.Add(ruta);
        }

        public void AgregarVuelo(Vuelo vuelo)
        {
            if (vuelo == null)
            {
                throw new Exception("Debe ingresar un vuelo");
            }

            vuelo.Validar();

            if (_vuelos.Contains(vuelo))
            {
                throw new Exception("Ya existe un vuelo con ese número.");
            }

            _vuelos.Add(vuelo);
        }

        public void AgregarAvion(Avion avion)
        {
            if(avion == null)
            {
                throw new Exception("Debe ingresar un avión");
            }

            avion.Validar();

            if(_aviones.Contains(avion))
            {
                throw new Exception("Ya existe este modelo de avión.");
            }

            _aviones.Add(avion);
        }

        // Para buscar cliente por cedula (experiencia de usuario, no integralidad de datos)
        public bool ExisteCliente(string documento)
        {
            Cliente cliente = null;
            int i = 0;

            while (cliente == null && i < _usuarios.Count)
            {
                Usuario u = _usuarios[i];

                if (u is Cliente c && c.Documento == documento)
                {
                    cliente = (Cliente)u;
                }
                i++;
            }
            return cliente != null;
        }

    }
}


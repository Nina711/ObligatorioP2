using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades_no_abst;
using Dominio.Entidades_abstractas;
using Dominio.Enumeraciones;
using System.ComponentModel.Design;
using System.Net.Http;

namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios;
        private List<Avion> _aviones;
        private List<Aeropuerto> _aeropuertos;
        private List<Ruta> _rutas;
        private List<Vuelo> _vuelos;
        private List<Pasaje> _pasajes;
        private static Sistema _instancia;

        // Patrón singleton
        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new Sistema();
                return _instancia;
            }
        }

        //Properties

        public List<Usuario> Usuario { get { return new List<Usuario>(_usuarios); } }
        public List<Avion> Aviones { get { return new List<Avion>(_aviones); } }
        public List<Aeropuerto> Aeropuertos { get { return new List<Aeropuerto>(_aeropuertos); } }
        public List<Ruta> Rutas { get { return new List<Ruta>(_rutas); } }
        public List<Vuelo> Vuelos { get { return new List<Vuelo>(_vuelos); } }
        public List<Pasaje> Pasajes { get { return new List<Pasaje>(_pasajes); } }

        //Constructor para implementar el patrón singleton
        public Sistema()
        {
            _usuarios = new List<Usuario>();
            _aviones = new List<Avion>();
            _aeropuertos = new List<Aeropuerto>();
            _rutas = new List<Ruta>();
            _vuelos = new List<Vuelo>();
            _pasajes = new List<Pasaje>();
            PrecargarDatos();
        }

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
            AltaClientePremium(new Premium("juan.perez@example.com", "Abjeja1234", "4312003", "Juan Pérez", "Argentina"));
            AltaClientePremium(new Premium("ana.lopez@example.com", "abcd1234", "5291845", "Ana López", "México"));
            AltaClientePremium(new Premium("carlos.ramos@example.com", "pass1234", "3289011", "Carlos Ramos", "Chile"));
            AltaClientePremium(new Premium("laura.mendez@example.com", "secure12", "6102344", "Laura Méndez", "Perú"));
            AltaClientePremium(new Premium("roberto.garcia@example.com", "clave123", "4721890", "Roberto García", "Uruguay"));

            AltaClienteOcasional(new Ocasional("maria.fernandez@example.com", "abeja4321", "3851205", "María Fernández", "Colombia"));
            AltaClienteOcasional(new Ocasional("jose.martin@example.com", "qwerty01", "2940312", "José Martín", "Paraguay"));
            AltaClienteOcasional(new Ocasional("sofia.hernandez@example.com", "asdf1234", "6372001", "Sofía Hernández", "Ecuador"));
            AltaClienteOcasional(new Ocasional("diego.rios@example.com", "zxcv7894", "5031943", "Diego Ríos", "Bolivia"));
            AltaClienteOcasional(new Ocasional("valentina.sosa@example.com", "mnbv4561", "6178432", "Valentina Sosa", "Venezuela"));

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
            AgregarPasaje(new Pasaje(_vuelos[0], new DateTime(2025, 5, 12), (Cliente)_usuarios[0], Equipaje.Light, 150.50m));
            AgregarPasaje(new Pasaje(_vuelos[1], new DateTime(2025, 5, 13), (Cliente)_usuarios[1], Equipaje.Cabina, 200.00m));
            AgregarPasaje(new Pasaje(_vuelos[2], new DateTime(2025, 5, 14), (Cliente)_usuarios[2], Equipaje.Bodega, 300.00m));
            AgregarPasaje(new Pasaje(_vuelos[3], new DateTime(2025, 5, 15), (Cliente)_usuarios[3], Equipaje.Light, 180.75m));
            AgregarPasaje(new Pasaje(_vuelos[4], new DateTime(2025, 5, 19), (Cliente)_usuarios[4], Equipaje.Cabina, 220.20m));
            AgregarPasaje(new Pasaje(_vuelos[5], new DateTime(2025, 5, 13), (Cliente)_usuarios[5], Equipaje.Bodega, 350.00m));
            AgregarPasaje(new Pasaje(_vuelos[6], new DateTime(2025, 5, 17), (Cliente)_usuarios[6], Equipaje.Light, 120.00m));
            AgregarPasaje(new Pasaje(_vuelos[7], new DateTime(2025, 5, 15), (Cliente)_usuarios[7], Equipaje.Cabina, 270.00m));
            AgregarPasaje(new Pasaje(_vuelos[8], new DateTime(2025, 5, 14), (Cliente)_usuarios[8], Equipaje.Bodega, 330.00m));
            AgregarPasaje(new Pasaje(_vuelos[9], new DateTime(2025, 5, 18), (Cliente)_usuarios[9], Equipaje.Light, 199.99m));
            AgregarPasaje(new Pasaje(_vuelos[10], new DateTime(2025, 5, 16), (Cliente)_usuarios[0], Equipaje.Cabina, 210.10m));
            AgregarPasaje(new Pasaje(_vuelos[11], new DateTime(2025, 5, 13), (Cliente)_usuarios[1], Equipaje.Bodega, 289.95m));
            AgregarPasaje(new Pasaje(_vuelos[12], new DateTime(2025, 5, 15), (Cliente)_usuarios[2], Equipaje.Light, 190.00m));
            AgregarPasaje(new Pasaje(_vuelos[13], new DateTime(2025, 5, 19), (Cliente)_usuarios[3], Equipaje.Cabina, 250.00m));
            AgregarPasaje(new Pasaje(_vuelos[14], new DateTime(2025, 5, 14), (Cliente)_usuarios[4], Equipaje.Bodega, 310.00m));
            AgregarPasaje(new Pasaje(_vuelos[15], new DateTime(2025, 5, 13), (Cliente)_usuarios[5], Equipaje.Light, 175.50m));
            AgregarPasaje(new Pasaje(_vuelos[16], new DateTime(2025, 5, 15), (Cliente)_usuarios[6], Equipaje.Cabina, 240.00m));
            AgregarPasaje(new Pasaje(_vuelos[17], new DateTime(2025, 5, 17), (Cliente)_usuarios[7], Equipaje.Bodega, 320.00m));
            AgregarPasaje(new Pasaje(_vuelos[18], new DateTime(2025, 5, 16), (Cliente)_usuarios[8], Equipaje.Light, 160.00m));
            AgregarPasaje(new Pasaje(_vuelos[19], new DateTime(2025, 5, 18), (Cliente)_usuarios[9], Equipaje.Cabina, 230.00m));
            AgregarPasaje(new Pasaje(_vuelos[20], new DateTime(2025, 5, 14), (Cliente)_usuarios[0], Equipaje.Bodega, 280.00m));
            AgregarPasaje(new Pasaje(_vuelos[21], new DateTime(2025, 5, 13), (Cliente)_usuarios[1], Equipaje.Light, 135.00m));
            AgregarPasaje(new Pasaje(_vuelos[22], new DateTime(2025, 5, 16), (Cliente)_usuarios[2], Equipaje.Cabina, 220.00m));
            AgregarPasaje(new Pasaje(_vuelos[23], new DateTime(2025, 5, 17), (Cliente)_usuarios[3], Equipaje.Bodega, 290.00m));
            AgregarPasaje(new Pasaje(_vuelos[24], new DateTime(2025, 5, 19), (Cliente)_usuarios[4], Equipaje.Light, 160.00m));

        }

        // Método para listar clientes
        public List<Cliente> MostrarListadoClientes()
        {
            List<Cliente> aux = new List<Cliente>();


            foreach (Usuario u in _usuarios)
            {
                if (u is Cliente)
                {
                    aux.Add((Cliente)u);
                }
            }

            // ordenar la lista por numero de documento
            aux.Sort();

            return aux;
        }

        // Método para mostrar vuelos por código de aeropuerto en consola
        public List<Vuelo> VuelosPorCodigo(string codigo)
        {
            List<Vuelo> aux = new List<Vuelo>();


            foreach (Vuelo v in _vuelos)
            {
                if (v.ObtenerAeropuertoSalida().Contains(codigo) || v.ObtenerAeropuertoLlegada().Contains(codigo))
                {
                    aux.Add(v);
                }
            }

            return aux;
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
                throw new Exception("Ya existe un cliente con ese documento y/o correo electrónico.");
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
                throw new Exception("Cliente ya existe.");
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
            if (avion == null)
            {
                throw new Exception("Debe ingresar un avión");
            }

            avion.Validar();

            if (_aviones.Contains(avion))
            {
                throw new Exception("Ya existe este modelo de avión.");
            }

            _aviones.Add(avion);
        }

        // Método para buscar cliente por correo (para obtener datos de la sesion actual)

        public Usuario BuscarUsuarioPorCorreo(string correo)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u.Correo == correo)
                {
                    return u;
                }
            }
            return null;
        }


        // Metodo para buscar vuelo (para poder comprar pasajes)

        public Vuelo BuscarVueloPorId(string numeroVuelo)
        {
            foreach (Vuelo v in _vuelos)
            {
                if (v.NumVuelo == numeroVuelo)
                {
                    return v;
                }
            }
            return null;

        }

        // Métodos para cálculo de pasaje

        public decimal CalcularPrecioPasaje(Vuelo vuelo, Cliente pasajero, Equipaje equipaje)
        {

            decimal costoBase = vuelo.CostoAsiento;
            decimal margenGanancia = 0.25m;

            if (pasajero is Premium && equipaje == Equipaje.Bodega)
            {
                margenGanancia += 0.05m;
            }
            else if (pasajero is Ocasional)
            {
                if (equipaje == Equipaje.Cabina)
                {
                    margenGanancia += 0.10m;
                }
                else if (equipaje == Equipaje.Bodega)
                {
                    margenGanancia += 0.20m;
                }
            }

            Ruta rutaDelPasaje = vuelo.Ruta;

            decimal costoFinal = costoBase + (costoBase * margenGanancia) + rutaDelPasaje.CalcularCostoOperacionAeropuertos();

            return costoFinal;
        }

        //login

        public Usuario UsuarioLogueado(string correo, string contrasenia)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u.Correo == correo && u.Contrasenia == contrasenia)
                {
                    return u;
                }
                else if (u.Correo == correo && u.Contrasenia != contrasenia)
                {
                    throw new Exception("Contraseña incorrecta");
                }
            }

            return null;
        }

        // ----- MÉTODOS PARA LISTAR PASAJES

        public List<Pasaje> ListarPasajesCliente(Cliente cliente)
        {
            List<Pasaje> auxPasajes = new List<Pasaje>();

            foreach (Pasaje p in _pasajes)
            {
                if (p.Pasajero == cliente)
                {
                    auxPasajes.Add(p);
                }
            }

            auxPasajes.Sort(CompararPorPrecioDesc);
            return auxPasajes;
        }

        public List<Pasaje> ListarPasajesAdmin()
        {
            List<Pasaje> auxPasajes = new List<Pasaje>(_pasajes);
            auxPasajes.Sort(CompararPorFechaDesc);
            return auxPasajes;
        }

        // Ordenamiento descendente por precio para clientes
        private int CompararPorPrecioDesc(Pasaje p1, Pasaje p2)
        {
            return p2.PrecioPasaje.CompareTo(p1.PrecioPasaje);
        }

        // Ordenamiento descendente por fecha para admins

        private int CompararPorFechaDesc(Pasaje p1, Pasaje p2)
        {
            return p2.Fecha.CompareTo(p1.Fecha);
        }

        public List<Vuelo> BuscarVuelosPorCodigo(string codSalida, string codLlegada)
        {
            List<Vuelo> auxVuelos = new List<Vuelo>();

            if (codSalida == null && codLlegada == null)
            {
                throw new Exception("Debe ingresar al menos un código.");
            }

            foreach (Vuelo v in _vuelos)
            {

                if (v.Ruta.TieneAeropuerto(codSalida, codLlegada))
                {
                    auxVuelos.Add(v);
                }
            }

            return auxVuelos;
        }

        public Cliente ObtenerClienteLogueado(string correo)
        {

            Usuario userLogueado = BuscarUsuarioPorCorreo(correo);
            return userLogueado as Cliente;

        }

        // Para editar puntos clientes premium
        public void EditarPuntos(Cliente c, int puntos)
        {
            if (c != null && c is Premium p)
            {
                p.Puntos = puntos;
            }
        }

        // para editar elegibilidad de cliente ocasional

        public void EditarElegibilidad(Cliente c, string s)
        {
            if (c != null && c is Ocasional o)
            {
                o.Validar();
                o.EsElegible = s;
            }
            else
            {
                throw new Exception("Cliente no encontrado.");
            }
        }
    }
}


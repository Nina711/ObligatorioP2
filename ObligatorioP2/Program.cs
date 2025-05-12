using Dominio;
using Dominio.Entidades_abstractas;
using Dominio.Entidades_no_abst;

namespace ObligatorioP2
{
    internal class Program
    {
        static Sistema s = new Sistema();
        static void Main(string[] args)
        {


            // --------- MENÚ
            try
            {
                // -------- PRECARGAS
                s.PrecargarDatos();
                //--------- MENU
                int opcion;
                bool flag = false;

                while (!flag)
                {
                    MostrarMenu();
                    opcion = SolicitarNumero();

                    switch (opcion)
                    {
                        case 1:
                            ListarClientes();
                            break;
                        case 2:
                            ListarVuelosPorCodigo();
                            break;
                        case 3:
                            AltaClienteOcasional();
                            break;
                        case 4:
                            ListarPasajesPorFechas();
                            break;
                        default:
                            flag = true;
                            break;
                    }

                    if (opcion != 0)
                    {
                        Console.WriteLine("Presione cualquier tecla para volver al menú");
                        Console.ReadKey();
                    }

                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void MostrarMenu()
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1- Obtener listado de los clientes");
            Console.WriteLine("2- Obtener listado de vuelos según un código de aeropuerto");
            Console.WriteLine("3- Alta de un cliente ocasional");
            Console.WriteLine("4- Obtener listado de pasajes entre dos fechas dadas");
            Console.WriteLine("0- Salir del menú");
        }

        public static int SolicitarNumero()
        {
            int numero = 0;
            bool selecciono = false;

            Console.WriteLine("Ingrese una opción");

            while (!selecciono)
            {
                try
                {
                    numero = int.Parse(Console.ReadLine());
                    selecciono = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Error, ingrese un número válido");
                }
            }

            return numero;
        }

        // --------- Case 1: LISTAR CLIENTES 
        public static void ListarClientes()
        {
            Console.WriteLine("Listado de Clientes:");

            List<Cliente> aux = s.MostrarListadoClientes();

            if (aux.Count == 0)
            {
                Console.WriteLine("Aun no hay clientes registrados.");
            }
            else
            {
                foreach (Cliente u in aux)
                {
                    Console.WriteLine(u.ToString());
                }
            }

        }

        // --------- Case 2: LISTAR VUELOS POR CÓDIGO
        public static void ListarVuelosPorCodigo()
        {
            try
            {
                string codigo;
                bool esValido = false;

                do
                {
                    Console.WriteLine("Ingrese un código de Aeropuerto:");
                    codigo = Console.ReadLine();

                    if (codigo.Length == 3)
                    {

                        bool letra = true;

                        foreach (char c in codigo)
                        {
                            if (!char.IsLetter(c))
                            {
                                letra = false;
                                break;
                            }
                        }

                        if (!letra)
                        {
                            Console.WriteLine("El código debe contener solo letras.");
                        }
                        else
                        {
                            esValido = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("El código debe contener exactamente 3 caracteres.");
                    }

                }

                while (!esValido);

                List<Vuelo> aux = s.VuelosPorCodigo(codigo);

                if (aux.Count == 0)
                {
                    Console.WriteLine("No existen vuelos para ese codigo IATA.");
                }
                else
                {
                    foreach (Vuelo v in aux)
                    {
                        Console.WriteLine(v);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // --------- Case 3: ALTA DE CLIENTE OCASIONAL

        public static void AltaClienteOcasional()
        {
            try
            {
                string documento = "";
                do
                {
                    Console.WriteLine("Ingrese el documento de identidad:");
                    documento = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(documento))
                    {
                        Console.WriteLine("El documento no puede ser un campo vacío.");
                    }


                } while (string.IsNullOrWhiteSpace(documento));

                string nombre;
                do
                {
                    Console.WriteLine("Ingrese el nombre del cliente:");
                    nombre = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        Console.WriteLine("El nombre no puede ser un campo vacío.");
                    }
                } while (string.IsNullOrWhiteSpace(nombre));

                string nacionalidad;
                do
                {
                    Console.WriteLine("Ingrese la nacionalidad:");
                    nacionalidad = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nacionalidad))
                    {
                        Console.WriteLine("La nacionalidad no puede ser un campo vacío.");
                    }
                } while (string.IsNullOrWhiteSpace(nacionalidad));

                string correo;
                do
                {
                    Console.WriteLine("Ingrese el correo electrónico:");
                    correo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(correo))
                    {
                        Console.WriteLine("El correo no puede ser un campo vacío.");
                    }

                } while (string.IsNullOrWhiteSpace(correo));

                string contrasenia;
                do
                {
                    Console.WriteLine("Ingrese una contraseña:");
                    contrasenia = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(contrasenia))
                    {
                        Console.WriteLine("El contraseña no puede ser un campo vacío.");
                    }
                } while (string.IsNullOrWhiteSpace(contrasenia));

                Ocasional ocasional = new Ocasional(correo, contrasenia, documento, nombre, nacionalidad);
                s.AltaClienteOcasional(ocasional);
                Console.WriteLine("Cliente ocasional agregado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // ---------- Case 4: LISTAR PASAJES ENTRE DOS FECHAS 
        public static void ListarPasajesPorFechas()
        {
            try
            {
                bool fechasValidas = false;

                do
                {
                    Console.WriteLine("Ingrese la fecha desde (dd/mm/aaa):");
                    string desde = Console.ReadLine();
                    Console.WriteLine("Ingrese la fecha hasta (dd/mm/aaa):");
                    string hasta = Console.ReadLine();

                    if (ValidarFormatoFecha(desde, out DateTime fechaDesde) && ValidarFormatoFecha(hasta, out DateTime fechaHasta))
                    {
                        fechasValidas = true;
                        List<Pasaje> pasajesFiltrados = s.PasajesEntreFechas(fechaDesde, fechaHasta);

                        Console.WriteLine($"Pasajes entre {fechaDesde:dd/MM/yyyy} y {fechaHasta:dd/MM/yyyy}:");

                        if (pasajesFiltrados.Count == 0)
                        {
                            Console.WriteLine("No se encontraron pasajes en ese rango de fechas.");
                        } else 
                        { 
                            foreach (Pasaje p in pasajesFiltrados)
                            {
                                Console.WriteLine(p);
                            }
                        }                    
                     
                    }
                    else
                    {
                        Console.WriteLine("El formato de las fechas no es válido. Debe ser dd/mm/aaaa.");
                    }
                } while (!fechasValidas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        // Para validar fechas que ingresa el usuario
        public static bool ValidarFormatoFecha(string fecha, out DateTime fechaParseada)
        {
            bool esFechaValida = DateTime.TryParse(fecha, out fechaParseada);

            return esFechaValida;
        }
    }
}


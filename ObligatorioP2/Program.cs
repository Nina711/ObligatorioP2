using Dominio;
using Dominio.Entidades_no_abst;

namespace ObligatorioP2
{
    internal class Program
    {
        static Sistema s = new Sistema();
        static void Main(string[] args)
        {
            s.PrecargarDatos();
            s.ValidarPrecargas();

            try
            {
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

        public static void ListarClientes()
        {
            Console.WriteLine("Listado de Clientes:");
            Console.WriteLine(s.MostrarListadoClientes());
        }

        // -- Agregar loop para que si hay error se pueda volver a ingresar codigo
        public static void ListarVuelosPorCodigo()
        {
            try
            {
                Console.WriteLine("Ingrese un código de Aeropuerto:");
                string codigo = Console.ReadLine();
                bool letra = true;
                bool flag = false;

                foreach (char c in codigo)
                {
                    if (!char.IsLetter(c))
                    {
                        letra = false;
                        break;
                    }
                }

                if (codigo == null || codigo.Length != 3 || !letra)
                {
                    Console.WriteLine("Debe ingresar un código válido");
                }

                Console.WriteLine(s.VuelosPorCodigo(codigo.ToUpper()));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void ListarPasajesPorFechas()
        {
            try
            {
                Console.WriteLine("Ingrese la fecha desde (dd/mm/aaa):");
                string desde = Console.ReadLine();

                Console.WriteLine("Ingrese la fecha hasta (dd/mm/aaa):");
                string hasta = Console.ReadLine();

                if (ValidarFormatoFecha(desde, out DateTime fechaDesde) && ValidarFormatoFecha(hasta, out DateTime fechaHasta))
                {
                    Console.WriteLine($"Pasajes entre {desde} y {hasta}: \n {s.PasajesEntreFechas(fechaDesde, fechaHasta)}");

                }
                else
                {
                    Console.WriteLine("El formato de las fechas no es el válido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Metodo que solicita ingresar info y valida los datos. Si estan bien crea instancia de objeto y llama método de sistema
        // pasandole el objeto como parámetro.

        /* by ana ------------ voy a modificar esto para que no se pierdan los datos. si el user tiene un error al principio e ingresa luego todo, tiene que salir y volver a entrar y escribir todo de nuevo. ademas no se lanzan las excepciones de las clases, tira error generico. Tambien hay que validar que no exista un cliente con ese documento */
        public static void AltaClienteOcasional()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre del cliente:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el documento de identidad:");
                string documento = Console.ReadLine();

                Console.WriteLine("Ingrese la nacionalidad:");
                string nacionalidad = Console.ReadLine();

                Console.WriteLine("Ingrese el correo electrónico:");
                string correo = Console.ReadLine();

                Console.WriteLine("Ingrese una contraseña:");
                string contrasenia = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(documento) || string.IsNullOrWhiteSpace(nacionalidad) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contrasenia))
                {
                    throw new Exception("Los campos no pueden estar vacíos.");
                }

                Ocasional ocasional = new Ocasional(correo, contrasenia, documento, nombre, nacionalidad);

                Console.WriteLine(s.AltaClienteOcasional(ocasional));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
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


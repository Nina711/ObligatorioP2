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
            s.PrecargarDatos();
            //Habría que validar precargas supongo pero no me quedó muy claro dónde ni cómo (dudas con IValidable)

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
                            // Método que pide dos fechas y luego usa método que filtra pasajes entre esas fechas
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

        public static void ListarVuelosPorCodigo()
        {
            try
            {
                Console.WriteLine("Ingrese un código de Aeropuerto:");
                string codigo = Console.ReadLine();
                bool letra = true;

                foreach(char c in codigo)
                {
                    if (!char.IsLetter(c))
                    {
                        letra = false;
                        break;
                    }
                }

                if (codigo == null || codigo.Length != 3 || !letra)
                {
                    throw new Exception("Ingrese un código válido");
                }

                Console.WriteLine(s.VuelosPorCodigo(codigo.ToUpper()));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Metodo que solicita ingresar info y valida los datos. Si estan bien crea instancia de objeto y llama método de sistema
        // pasandole el objeto como parámetro.
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

                Cliente cliente = new Ocasional(correo, contrasenia, documento, nombre, nacionalidad);

                Console.WriteLine(s.AltaClienteOcasional(cliente));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        // Esto creo que va acá como primer filtro.
        //public bool ValidarFormatoFecha(string fecha)
        //{
        //    DateTime fechaPasaje;
        //    if (DateTime.TryParse(fecha, out fechaPasaje))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        throw new Exception("El formato de la fecha no es correcto.");
        //    }
        //}
    }
}

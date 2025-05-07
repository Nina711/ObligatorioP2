using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Ocasional
    {

        private bool _esElegible; // Le cambie el nombre para que sea más claro - yo me habia confundido con Premium

        public string EsElegible
        {
            get
            {
                string mensaje = "";

                if (_esElegible)
                {
                    mensaje = "Elegible";
                }
                else
                {
                    mensaje = "No elegible";
                }
                    return mensaje;
            }
        }

        public Ocasional(string correo, string contrasenia, string documento, string nombre, string nacionalidad, bool esElegible) : base(correo, contrasenia, documento, nombre, nacionalidad)
        {
            _esElegible = EsElegibleRandomizado(); 
        }

        private bool EsElegibleRandomizado()
        {
            Random r = new Random();   
            return r.Next(0,2) == 1;
        }

        public override string ToString()
        {
            string mensaje = base.ToString() + $"{EsElegible}\n";
            return mensaje;
        }
    }
}

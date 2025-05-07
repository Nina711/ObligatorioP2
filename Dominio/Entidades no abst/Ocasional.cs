using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Ocasional
    {

        // Le cambie el nombre para que sea más claro - yo me habia confundido con Premium

        private bool _esElegible; // seguramente aca se iguale en realidad al metodo que ve si es elegible o no... veremos o.O

        public bool EsElegible
        {
            get { return this._esElegible; }
        }

        public Ocasional(string correo, string contrasenia, string documento, string nombre, string nacionalidad, bool esElegible): base(correo, contrasenia, documento, nombre, nacionalidad)
        {
            _esElegible = esElegible; 
        }
    }
}

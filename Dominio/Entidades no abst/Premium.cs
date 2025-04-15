using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades_no_abst
{
    public class Premium : Cliente
    {
        private int _puntos;
        private bool _esElegible;

        public int Puntos
        {
            get
            {
                return this._puntos;
            }
        }

        public bool Elegible
        {
            get { return this._esElegible; }
        }

        
        public Premium(string correo, string contrasenia, string documento, string nombre, string nacionalidad, int puntos, bool esElegible) : base(correo, contrasenia, documento, nombre, nacionalidad)
        {
            _puntos = puntos;
            _esElegible = esElegible; //seguramente aca vaya el metodo que ve si es elegible o no... veremos o.O
        }
    }
    }


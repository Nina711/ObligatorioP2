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

        public int Puntos
        {
            get { return this._puntos; }

            // Agregué setter para poder editar el valor del atributo
            set
            {
                if (value < 0)
                {
                    throw new Exception("La cantidad de puntos no puede ser negativa.");
                }

                this._puntos = value;
            }
        }


        public Premium(string correo, string contrasenia, string documento, string nombre, string nacionalidad) : base(correo, contrasenia, documento, nombre, nacionalidad)
        {
            _puntos = 0;

        }

        // ToString()

        public override string ToString()
        {
            return base.ToString() + $" Cantidad de puntos: {_puntos}\n";
        }
    }
}


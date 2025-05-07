using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades_no_abst
{
    public class Premium : Cliente
    {
        private int _puntos = 0;

        public int Puntos
        {
            get
            {
                return this._puntos;
            }
        }

        
        public Premium(string correo, string contrasenia, string documento, string nombre, string nacionalidad, int puntos) : base(correo, contrasenia, documento, nombre, nacionalidad)
        {
            _puntos = puntos;
            
        }

        // ToString

        public override string ToString()
        {
            return base.ToString() + $"Cantidad de puntos: {_puntos}\n";
        }
    }
}


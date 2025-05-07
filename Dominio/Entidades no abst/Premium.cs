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
            get
            {
                return this._puntos;
            }
        }

        
        public Premium(string correo, string contrasenia, string documento, string nombre, string nacionalidad, int puntos) : base(correo, contrasenia, documento, nombre, nacionalidad)
        {
            _puntos = puntos;
            
        }

        private void ValidarPuntos()
        {
            if(_puntos < 0)
            {
                throw new Exception("Los puntos no pueden ser un número negativo");
            }
        }

        public override void ValidarUsuario()
        {
            base.ValidarUsuario();
            ValidarPuntos();
        }
    }
}


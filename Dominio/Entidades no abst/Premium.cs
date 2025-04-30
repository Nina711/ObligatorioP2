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
        private bool _programaVentajas;

        public int Puntos
        {
            get
            {
                return this._puntos;
            }
        }

        public bool ProgramaVentajas
        {
            get { return this._programaVentajas; }
        }

        
        public Premium(string correo, string contrasenia, string documento, string nombre, string nacionalidad, int puntos, bool programaVentajas) : base(correo, contrasenia, documento, nombre, nacionalidad)
        {
            _puntos = puntos;
            _programaVentajas = programaVentajas; //seguramente aca vaya el metodo que ve si es elegible o no... veremos o.O
        }
    }
    }


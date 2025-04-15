using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Dominio.Entidades_abstractas;


namespace Dominio.Entidades_no_abst
{
    public abstract class Cliente : Usuario
    {
        private string _documento;
        private string _nombre;
        private string _nacionalidad;

        public string Documento
        {
            get { return this._documento; }

        }

        public string Nombre
        {
            get { return this._nombre; }

        }

        public string Nacionalidad
        {
            get { return this._nacionalidad; }
        }

        public Cliente(string correo, string contrasenia, string documento, string nombre, string nacionalidad) : base(correo, contrasenia)
        {
            _documento = documento;
            _nombre = nombre;
            _nacionalidad = nacionalidad;
        }
    }

}

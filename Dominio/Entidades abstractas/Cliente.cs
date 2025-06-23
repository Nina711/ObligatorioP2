using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Dominio.Entidades_abstractas;


namespace Dominio.Entidades_no_abst
{
    public abstract class Cliente : Usuario, IComparable<Cliente>
    {
        private string _documento;
        private string _nombre;
        private string _nacionalidad;

        public string Documento
        {
            get { return this._documento; }
            set { this._documento = value; }    

        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }

        }

        public string Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }     
        }

        public Cliente(string correo, string contrasenia, string documento, string nombre, string nacionalidad) : base(correo, contrasenia)
        {
            _documento = documento;
            _nombre = nombre;
            _nacionalidad = nacionalidad;
        }

        public Cliente () { }

        // --- VALIDACIONES PROPIAS DE CLIENTES
        private void ValidarDocumento()
        {
            if (string.IsNullOrWhiteSpace(_documento))
            {
                throw new Exception("El documento no puede estar vacío.");
            }

            if(_documento.Length < 7 || _documento.Length > 8)
            {
                throw new Exception("El documento debe tener como minimo 7 caracteres y como maximo 8.");
            }
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(_nombre))
            {
                throw new Exception("El nombre no puede estar vacío.");
            }
        }

        private void ValidarNacionalidad()
        {
            if (string.IsNullOrWhiteSpace(_nacionalidad))
            {
                throw new Exception("La nacionalidad no puede ser vacía.");
            }
        }

        public void Validar()
        {
            base.Validar();
            ValidarNombre();
            ValidarDocumento();
            ValidarNacionalidad();
        }

        // -------- OVERRIDES

        // --Equals

        public override bool Equals(object obj)
        {
            var cliente = obj as Cliente;

            return cliente != null &&
                   (this.Documento == cliente.Documento || this.Correo == cliente.Correo);
        }

        // --ToString

        public override string ToString()
        {
            string mensaje = $"Nombre: {_nombre}, {base.ToString()}, Nacionalidad: {_nacionalidad},";
            return mensaje;
        }

        // Agregué Interfaz de comparación para ordenar los clientes por número de documento 

        public int CompareTo(Cliente c)
        {
            return _documento.CompareTo(c.Documento);
        }

    }

}

using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades_abstractas
{
    public abstract class Usuario : IValidable
    {
        private string _correo;
        private string _contrasenia;

        public string Correo
        {
            get { return this._correo; }
            set { this._correo = value; }
        }

        public string Contrasenia
        {
            get { return this._contrasenia; }
            set { this._contrasenia = value; }
        }

        public Usuario(string correo, string contrasenia)
        {
            _correo = correo;
            _contrasenia = contrasenia;
        }

        public Usuario() { }

        // ---- VALIDACIONES

        private void ValidarCorreo()
        {
            if (string.IsNullOrWhiteSpace(_correo))
            {
                throw new Exception("El campo correo electrónico no puede estar vacío.");
            }
        }

        private void ValidarContrasenia()
        {
            if (string.IsNullOrWhiteSpace(_contrasenia))
            {
                throw new Exception("La contraseña no puede ser vacía");
            }

            if (_contrasenia.Length < 8)
            {
                throw new Exception("La contraseña debe tener al menos 8 caracteres.");
            }

            if(!(_contrasenia.Any(char.IsLetter)) || !(_contrasenia.Any(char.IsDigit))){
                throw new Exception("La contraseña debe contener al menos una letra y un número.");
            }
        }

        public void Validar()
        {
            ValidarCorreo();
            ValidarContrasenia();
        }

        // --- Overrides

        public override string ToString()
        {
            string mensaje = $"Correo: {_correo}";
            return mensaje;
        }

        public override bool Equals(object obj)
        {
            var usuario = obj as Usuario;
            return usuario != null && usuario._correo == this._correo;
        }
    }
}

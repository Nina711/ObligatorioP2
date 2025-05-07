using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades_abstractas
{
    public abstract class Usuario
    {
        private string _correo;
        private string _contrasenia;

        public string Correo
        {
            get { return this._correo; }
        }

        public string Contrasenia
        {
            get { return this._contrasenia; }
        }

        public Usuario(string correo, string contrasenia)
        {
            _correo = correo;
            _contrasenia = contrasenia;
        }

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
        }

        public virtual void ValidarUsuario()
        {
            ValidarContrasenia();
            ValidarCorreo();
        }
    }
}

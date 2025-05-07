using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades_abstractas;

namespace Dominio.Entidades_no_abst
{
    public class Administrador : Usuario
    {
        private string _apodo;

        public string Apodo
        {
            get { return this._apodo; }
        }

        public Administrador(string correo, string contrasenia, string apodo) : base(correo, contrasenia)
        {
            this._apodo = apodo;
        }

        // Validaciones

        private void ValidarApodo()
        {
            if (string.IsNullOrWhiteSpace(_apodo))
            {
                throw new Exception("El campo apodo no puede estar vacío.");
            }
            {
                throw new Exception("Debe ingresar un apodo");
            }
        }

        public override void ValidarUsuario()
        {
            base.ValidarUsuario();
            ValidarApodo();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            set { this._apodo = value; }
        }

        public Administrador(string correo, string contrasenia, string apodo) : base(correo, contrasenia)
        {
            this._apodo = apodo;
        }

        public Administrador() { }

        // Validaciones

        private void ValidarApodo()
        {
            if (string.IsNullOrWhiteSpace(_apodo))
            {
                throw new Exception("Debe ingresar un apodo");
            }
        }
        public void Validar()
        {
            base.Validar();
            ValidarApodo();
        }

        public override bool Equals (object obj)
        {
            var admin = obj as Administrador;

            return admin != null && admin._apodo == this._apodo;
        }

    }
}

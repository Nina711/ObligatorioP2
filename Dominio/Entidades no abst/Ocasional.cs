using Dominio.Entidades_no_abst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades_no_abst
{
    public class Ocasional : Cliente
    {

        private bool _esElegible;

        public string EsElegible
        {
            get
            {
                string mensaje = "";

                if (_esElegible)
                {
                    mensaje = "Elegible";
                }
                else
                {
                    mensaje = "No elegible";
                }
                return mensaje;
            }

            // Agregué setter para poder editar el valor del atributo
             set
            {
                if (value == "Elegible")
                {
                    _esElegible = true;
                }
                else if (value == "No elegible")
                {
                    _esElegible = false;
                }
            }
        }
        public Ocasional(string correo, string contrasenia, string documento, string nombre, string nacionalidad) : base(correo, contrasenia, documento, nombre, nacionalidad)
        {
            EsElegibleRandomizado(); 
        }

        public Ocasional() { }

        //Validaciones
        public void Validar()
        {
            base.Validar();
        }

        // Método para determinar si es elegible o no

        private void EsElegibleRandomizado()
        {
            Random r = new Random();   
            _esElegible = r.Next(0,2) == 1;
        }

        
        // ToString
        public override string ToString()
        {
            string mensaje = base.ToString() + $" {EsElegible}\n";
            return mensaje;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Aeropuerto : IValidable
    {
        private string _codigo;
        private string _ciudad;
        private decimal _costoOperacionAeropuerto;
        private decimal _costoTasas;

        public string Codigo
        {
            get { return this._codigo; }
        }

        public string Ciudad
        {
            get { return this._ciudad; }
        }

        public decimal CostoOperacionAeropuerto
        {
            get { return this._costoOperacionAeropuerto;  }
        }

        public decimal CostoTasas
        {
            get { return this._costoTasas; }
        }

        public Aeropuerto(string codigo, string ciudad, decimal costoOperacionAeropuerto, decimal costoTasas)
        {
            _codigo = codigo;
            _ciudad = ciudad;
            _costoOperacionAeropuerto = costoOperacionAeropuerto;
            _costoTasas = costoTasas;
        }

        // Validaciones

        public void Validar()
        {
            ValidarCodigo();
            ValidarCiudad();
            ValidarCostoOperacionAeropuerto();
            ValidarCostoTasas();
        }

        private void ValidarCodigo()
        {
            if (string.IsNullOrWhiteSpace(_codigo))
            {
                throw new Exception("El código del aeropuerto no puede estar vacío");
            }

            if (_codigo.Length !=3)
            {
                throw new Exception("El código del aeropuerto debe tener exactamente 3 caracteres");
            }
        }

        private void ValidarCiudad()
        {
            if (string.IsNullOrWhiteSpace(_ciudad))
            {
                throw new Exception ("La ciudad del aeropuerto no puede estar vacía");
            }
        }

        private void ValidarCostoOperacionAeropuerto()
        {
            if (_costoOperacionAeropuerto < 0)
            {
                throw new Exception("El costo de operación del aeropuerto no puede ser negativo");
            }
        }   

        private void ValidarCostoTasas()
        {
            if (_costoTasas < 0)
            {
                throw new Exception("El costo de tasas del aeropuerto no puede ser negativo");
            }
        }   

        
    }
}

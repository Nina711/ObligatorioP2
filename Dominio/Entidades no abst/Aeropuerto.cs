using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Aeropuerto
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
    }
}

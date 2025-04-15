using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Enumeraciones;

namespace Dominio.Entidades_no_abst
{
    public class Vuelo
    {
        private string _numVuelo;
        private Ruta _ruta;
        private Avion _avion;
        private Frecuencia _frecuencia;

        public string NumVuelo
        {
            get {  return this._numVuelo; }
        }

        public Ruta Ruta
        {
            get { return this._ruta; }
        }

        public Avion Avion
        {
            get { return this._avion; }
        }

        public Frecuencia Frecuencia
        {
            get { return this._frecuencia; }
        }
    }
}

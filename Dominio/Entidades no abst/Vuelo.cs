using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Enumeraciones;
using Dominio.Interfaces;

namespace Dominio.Entidades_no_abst
{
    public class Vuelo : IValidable
    {
        private string _numVuelo;
        private Ruta _ruta;
        private Avion _avion;
        private List<Frecuencia> _frecuencia;
        private decimal _costoAsiento;

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

        public List<Frecuencia> Frecuencia
        {
            get { return this._frecuencia; }
        }

        public decimal CostoAsiento
        {
            get { return this._costoAsiento; }
        }

        public Vuelo (string numVuelo, Ruta ruta, Avion avion, List<Frecuencia> frecuencia)
        {
            this._numVuelo = numVuelo;
            this._ruta = ruta;
            this._avion = avion;
            this._frecuencia = frecuencia;
            this._costoAsiento = CalcularPrecioAsiento();
        }

        // Validaciones
        public void Validar()
        {
            ValidarNumVuelo();
            ValidarRuta();
            ValidarAvion();
            ValidarFrecuencia();
        }

        private void ValidarNumVuelo()
        {
            if (string.IsNullOrWhiteSpace(_numVuelo))
            {
                throw new Exception("El campo número de vuelo no puede estar vacío.");
            }
        }

        private void ValidarRuta()
        {
            if (_ruta == null)
            {
                throw new Exception("El campo ruta no puede estar vacío.");
            }
        }

        private void ValidarAvion()
        {
            if (_avion == null)
            {
                throw new Exception("El campo avión no puede estar vacío.");
            }
        }   

        private void ValidarFrecuencia()
        {
            if (_frecuencia == null || _frecuencia.Count < 1)
            {
                throw new Exception("El campo frecuencia no puede estar vacío.");
            }
        }

        // Método para validar si el alcance de un avión puede cubrir determinada ruta

        public void ValidarAlcance()
        {
            if (_ruta.Distancia > _avion.Alcance)
            {
                throw new Exception("El avión seleccionado no puede cubrir la distancia de esta ruta.");
            }
        }

        //Obtiene el código de los aeropuertos a partir del método en Ruta (2)
        public string ObtenerAeropuertoSalida()
        {
            return _ruta.ObtenerCodigoAeropuertoSalida();
        }
        public string ObtenerAeropuertoLlegada()
        {
            return _ruta.ObtenerCodigoAeropuertoLlegada();
        }

        //Método que calcula precio por asiento (costo base del VUELO)

        public decimal CalcularPrecioAsiento()
        {
            decimal costoAsiento = (_avion.CostoOperacionAvion * _ruta.Distancia + _ruta.CalcularCostoOperacionAeropuertos()) / _avion.CantAsientos;

            return costoAsiento;
        }

        
        public string Frecuencias()
        {
            string frec = "";

            foreach(Frecuencia f in _frecuencia)
            {
                f.ToString();
                frec += $"{f} ";
            }

            return frec;
        }

        // Overrides
        public string ToString()
        {
            string mensaje = $"Número de vuelo {_numVuelo}, Modelo del avión: {_avion.Modelo}, Ruta: {_ruta.ToString()}, Frecuencia: {Frecuencias()}\n";
            return mensaje;
        }

        public override bool Equals (object obj)
        {
            var vuelo = obj as Vuelo;
            return vuelo != null && vuelo.NumVuelo == this._numVuelo;
        }


    }
}

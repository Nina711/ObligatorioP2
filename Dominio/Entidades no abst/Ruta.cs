using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades_no_abst
{
    public class Ruta : IValidable
    {
        private int _id;
        private static int _ultimoId = 0;
        private Aeropuerto _aeropSalida;
        private Aeropuerto _aeropLlegada;
        private decimal _distancia;

        public int Id
        {
            get { return this._id; }
        }

        public static int UltimoId
        {
            get { return _ultimoId; }
        }

        public Aeropuerto AeropuertoSalida
        {
            get { return this._aeropSalida; }
        }

        public Aeropuerto AeropuertoLlegada
        {
            get { return this._aeropLlegada; }
        }

        public decimal Distancia
        {
            get { return this._distancia; }
        }

        public Ruta(Aeropuerto aeropSalida, Aeropuerto aeropLlegada, decimal distancia)
        {
            _ultimoId++;
            this._id = _ultimoId;
            this._aeropSalida = aeropSalida;
            this._aeropLlegada = aeropLlegada;
            this._distancia = distancia;
        }

        // Calculos
        public decimal CalcularCostoOperacionAeropuertos()
        {
            decimal costoRuta = _aeropLlegada.CostoOperacionAeropuerto + _aeropSalida.CostoOperacionAeropuerto;

            return costoRuta;
        }

        //Validaciones

        public void Validar()
        {
            ValidarAeropuertoSalida();
            ValidarAeropuertoLlegada();
            ValidarDiferentesAeropuertos();
            ValidarDistancia();
        }

        private void ValidarAeropuertoSalida()
        {
            if (_aeropSalida == null)
            {
                throw new Exception("El aeropuerto de salida no puede ser vacío.");
            }
        }

        private void ValidarAeropuertoLlegada()
        {
            if (_aeropLlegada == null)
            {
                throw new Exception("El aeropuerto de llegada no puede ser vacío.");
            }
        }

        private void ValidarDistancia()
        {
            if (_distancia <= 0)
            {
                throw new Exception("La distancia no puede ser menor o igual a cero.");
            }
        }

        private void ValidarDiferentesAeropuertos()
        {
            if (_aeropSalida.Equals(_aeropLlegada))
            {
                throw new Exception("Los aeropuertos de salida y llegada no pueden ser iguales.");
            }
        }

        //Obtener el código de los aeropuertos (1)
        public string ObtenerCodigoAeropuertoSalida()
        {
            string codigoSalida = _aeropSalida.Codigo;
            return codigoSalida;
        }

        public string ObtenerCodigoAeropuertoLlegada()
        {
            string codigoLlegada = _aeropLlegada.Codigo;
            return codigoLlegada;
        }

        //--- Overrides

        public string ToString()
        {
            return $"{_aeropSalida.Codigo}-{_aeropLlegada.Codigo}";
        }

        public override bool Equals(object obj)
        {
            var ruta = obj as Ruta;
            return ruta != null && ruta._id == this._id;
        }
    }
}

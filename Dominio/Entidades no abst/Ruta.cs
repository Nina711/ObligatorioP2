using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades_no_abst
{
    public class Ruta
    {
        private int _id;
        private int _ultimoId;
        private Aeropuerto _aeropSalida;
        private Aeropuerto _aeropLlegada;
        private decimal _distancia;

        public int Id
        {
            get { return this._id; }
        }

        public int UltimoId
        {
            get { return this._ultimoId; }
        }

        public Aeropuerto AeropuertoSalida
        {
            get { return this._aeropSalida; }
        }

        public Aeropuerto AeropuertoLlegada
        {
            get { return this._aeropLlegada;}
        }

        public decimal Distancia
        {
            get { return this._distancia;}
        }

        public Ruta (Aeropuerto aeropSalida, Aeropuerto aeropLlegada, decimal distancia)
        {
            this._ultimoId++;
            this._id = _ultimoId;
            this._aeropSalida = aeropSalida;
            this._aeropLlegada = aeropLlegada;
            this._distancia = distancia;
        }

        public decimal CalcularCostoOperacionAeropuertos()
        {
            decimal costoRuta = _aeropLlegada.CostoOperacionAeropuerto + _aeropSalida.CostoOperacionAeropuerto;

            return costoRuta;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Enumeraciones;


namespace Dominio.Entidades_no_abst
{
    public class Pasaje
    {
        private int _id;
        private int _ultimoId = 0;
        private Vuelo _vuelo;
        private DateTime _fecha;
        private Cliente _pasajero;
        private Equipaje _equipaje;
        private decimal _precioPasaje;

        public int Id
        {
            get { return this._id; }
        }
        public int UltimoId
        {
            get { return this._ultimoId; }
        }

        public Vuelo Vuelo
        {
            get { return this._vuelo; }
        }

        public DateTime Fecha
        {
            get { return this._fecha; }
        }

        public Cliente Pasajero
        {
            get { return this._pasajero; }
        }

        public Equipaje Equipaje
        {
            get
            {
                return this._equipaje;
            }
        }
        public decimal precioPasaje
        {
            get { return this.precioPasaje; }
        }
        
        public Pasaje(Vuelo vuelo, DateTime fecha, Cliente pasajero, Equipaje equipaje, decimal precioPasaje)
        {
            this._ultimoId++;
            this._id = _ultimoId;
            this._vuelo = vuelo;
            this._fecha = fecha;
            this._pasajero = pasajero;
            this._equipaje = equipaje;
            this._precioPasaje = precioPasaje;

        }

        public void ValidarFecha()
        {

        }

        public decimal CalcularPrecioPasaje()
        {
        }

    }
}

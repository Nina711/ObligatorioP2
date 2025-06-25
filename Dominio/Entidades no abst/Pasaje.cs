using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Enumeraciones;
using Dominio.Interfaces;
using Microsoft.VisualBasic;


namespace Dominio.Entidades_no_abst
{
    public class Pasaje : IValidable
    {
        private int _id;
        private static int _ultimoId = 0;
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
            get { return _ultimoId; }
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
        public decimal PrecioPasaje
        {
            get { return this._precioPasaje; }
        }

        public Pasaje(Vuelo vuelo, DateTime fecha, Cliente pasajero, Equipaje equipaje, decimal precioPasaje)
        {
            _ultimoId++;
            this._id = _ultimoId;
            this._vuelo = vuelo;
            this._fecha = fecha;
            this._pasajero = pasajero;
            this._equipaje = equipaje;
            this._precioPasaje = precioPasaje;

        }

        //Validaciones 

        public void Validar()
        {
            ValidarFecha();
            ValidarPasajero();
            ValidarVuelo();
            ValidarEquipaje();
        }

        private void ValidarFecha()
        {
            if (_fecha < DateTime.Today)
            {
                throw new Exception("La fecha del pasaje no puede ser menor al día de hoy.");
            }

            int fecha = (int)_fecha.DayOfWeek;
            bool esValido = false;

            foreach (Frecuencia f in _vuelo.Frecuencia)
            {
                if (((int)f) == fecha)
                {
                    esValido = true;
                    break;
                }
            }

            if (!esValido)
            {
                throw new Exception("El vuelo no opera en la fecha seleccionada.");
            }
        }


        private void ValidarVuelo()
        {
            if (_vuelo == null) 
            {
                throw new Exception("El vuelo no es correcto.");
            }
        }

        private void ValidarEquipaje()
        {
            if (!Enum.IsDefined(typeof(Equipaje), _equipaje))
            {
                throw new Exception("Debe seleccionar un tipo de equipaje válido.");
            }
        }

        private void ValidarPasajero()
        {
            if (_pasajero == null && !(_pasajero is Cliente))
            {
                throw new Exception("Los datos del pasajero no son correctos.");
            }
        }

        //Para obtener ruta

        public Ruta ObtenerRuta()
        {
            return _vuelo.Ruta;
        }

        // --- Overrides

        public override string ToString()
        {
            return $"Id: {_id}, Pasajero: {_pasajero.Nombre}, Precio: {_precioPasaje}, Fecha: {_fecha.ToString("d")}, Vuelo n°: {_vuelo.NumVuelo}.";
        }

        public override bool Equals(object obj)
        {
            var pasaje = obj as Pasaje;

            return pasaje != null && pasaje._id == this._id;
        }
    }
}

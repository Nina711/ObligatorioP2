using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Enumeraciones;
using Microsoft.VisualBasic;


namespace Dominio.Entidades_no_abst
{
    public class Pasaje : IValidable
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

        //Validaciones 

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

            if (!(_vuelo is Vuelo))
            {
                throw new Exception("El vuelo no es correcto");
            }
        }

        private void ValidarPasajero()
        {
            if (_pasajero != null && _pasajero is Cliente)
            {
                throw new Exception("Los datos del pasajero no son correctos.");
            }
        }

        // Hice método aparte del validar fecha porque este necesita que se le ingrese un parámetro idk lol a ver que pensas vos
        public bool ValidarFormatoFecha(string fecha)
        {
            DateTime fechaPasaje;
            if (DateTime.TryParse(fecha, out fechaPasaje))
            {
                return true;
            }
            else
            {
                throw new Exception("El formato de la fecha no es correcto.");
            }
        }

        public void Validar()
        {
            ValidarFecha();
            ValidarPasajero();
            ValidarVuelo();
        }



        // Creo que deberia hacerlo sistema el todo
        /*public decimal CalcularPrecioPasaje()
        {
        }*/
    
        /* TAMPOCO VA ESTO SADLY ---
         *
        public decimal CalcularCostoEquipaje()
        {
            decimal costoBase = _vuelo.CostoAsiento;
            decimal costoEquipaje = 0;

            if (_pasajero is Premium && _equipaje == Equipaje.bodega)
            {
                costoEquipaje = costoBase + (costoBase * 0.05);
            }
            else if (_pasajero is Ocasional)
            {
                if(_equipaje == Equipaje.cabina) { 
                costoEquipaje = costoBase + (costoBase * 0.10);
                } else if (_equipaje == Equipaje.bodega)
                {
                    costoEquipaje = costoBase + (costoBase * 0.20);
                }
            }

            return costoEquipaje;
        }*/
    }
}

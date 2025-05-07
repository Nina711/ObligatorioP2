using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades_no_abst;
using Dominio.Entidades_abstractas;
using Dominio.Enumeraciones;

namespace Dominio
{
    internal class Sistema
    {
        private List<Cliente> _clientes = new List<Cliente>();
        private List<Avion> _aviones = new List<Avion>();
        private List<Aeropuerto> _aeropuertos = new List<Aeropuerto>();
        private List<Ruta> _rutas = new List<Ruta>();
        private List<Vuelo> _vuelos = new List<Vuelo>();
        private List<Pasaje> _pasajes = new List<Pasaje>();

        //no va a servir esto pero lo dejare por el cariño <3
        /*public decimal CalcularPrecioPasaje (Pasaje pasaje)
        {
            //obtengo el vuelo del pasaje
            Vuelo vueloDelPasaje = Pasaje.Vuelo;
            //hago la primera parte del calculo
            decimal costoPasaje = vueloDelPasaje.CostoAsiento + (vueloDelPasaje.CostoAsiento * 0.25);
            //obtengo ruta
            Ruta rutaDelPasaje = vueloDelPasaje.Ruta();
            //le sumo costo de operaciones de aeropuertos
            costoPasaje += rutaDelPasaje.CalcularCostoOperacionAeropuertos();

            costoPasaje += Pasaje.CalcularCostoEquipaje();            

            return costoPasaje;
        }*/

    }
}

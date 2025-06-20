using Dominio.Entidades_no_abst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Entidades_no_abst;

namespace Dominio.Interfaces
{
    internal class PasajesPorPrecio : IComparer<Pasaje>
    {
        public int Compare (Pasaje? x, Pasaje? y)
        {
            return x.precioPasaje.CompareTo(y.precioPasaje) * -1;
        }
    }
}

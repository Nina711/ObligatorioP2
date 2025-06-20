using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Entidades_no_abst;

namespace Dominio.Interfaces
{
    internal class PasajesPorFecha : IComparer<Pasaje>
    {
        public int Compare(Pasaje? x, Pasaje? y)
        {
            return x.Fecha.CompareTo(y.Fecha);
        }
    }
}

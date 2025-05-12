using Dominio.Interfaces;

namespace Dominio
{
    public class Avion : IValidable
    {
        private string _fabricante;
        private string _modelo;
        private int _cantAsientos;
        private decimal _alcance;
        private decimal _costoOperacionAvion;

        public string Fabricante
        {
            get { return this._fabricante; }
        }

        public string Modelo
        {
            get { return this._modelo; }
        }

        public int CantAsientos
        {
            get { return this._cantAsientos; }
        }

        public decimal Alcance
        {
            get { return this._alcance; }
        }

        public decimal CostoOperacionAvion
        {
            get { return this._costoOperacionAvion; }
        }

        public Avion(string fabricante, string modelo, int cantAsientos, decimal alcance, decimal costoOperacionAvion)
        {
            _fabricante = fabricante;
            _modelo = modelo;
            _cantAsientos = cantAsientos;
            _alcance = alcance;
            _costoOperacionAvion = costoOperacionAvion;
        }

        // ---- Validaciones

        public void Validar()
        {
            ValidarFabricante();
            ValidarModelo();
            ValidarCantAsientos();
            ValidarAlcance();
            ValidarCostoOperacionAvion();
        }

        private void ValidarFabricante()
        {
            if(string.IsNullOrWhiteSpace(_fabricante))
            {
                throw new Exception("El campo fabricante no puede estar vacío.");
            }   
        }

        private void ValidarModelo()
        {
            if (string.IsNullOrWhiteSpace(_modelo))
            {
                throw new Exception("El campo modelo no puede estar vacío.");
            }
        }   

        private void ValidarCantAsientos()
        {
            if (_cantAsientos <= 0)
            {
                throw new Exception("El campo cantidad de asientos no puede ser menor o igual a cero.");
            }
        }   

        private void ValidarAlcance()
        {
            if (_alcance <= 0)
            {
                throw new Exception("El campo alcance no puede ser menor o igual a cero.");
            }
        }   

        private void ValidarCostoOperacionAvion()
        {
            if (_costoOperacionAvion <= 0)
            {
                throw new Exception("El campo costo de operación no puede ser menor o igual a cero.");
            }
        }

        public override bool Equals(object obj)
        {
            Avion avion = obj as Avion;
            return avion != null && avion._modelo == _modelo;
        }
    }
}

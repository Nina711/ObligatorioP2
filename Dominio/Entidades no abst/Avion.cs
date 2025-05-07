namespace Dominio
{
    public class Avion
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


        // Valida si el alcance del avion puede cubrir una ruta. Entiendo que se usaría para crear un vuelo 
        public void ValidarAlcance(int kmDistancia)
        {
            if (kmDistancia > _alcance)
            {
                throw new Exception("El avión seleccionado no puede cubrir la distancia de esta ruta.")
            }
        }
    }
}

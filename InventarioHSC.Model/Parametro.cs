namespace InventarioHSC.Model
{
    public class Parametro
    {
        private int _Par_ID;
        private string _Par_Descripcion;
        private string _Par_Valor;

        public int par_ID
        {
            get { return _Par_ID; }
            set { _Par_ID = value; }
        }

        public string par_Descripcion
        {
            get { return _Par_Descripcion; }
            set { _Par_Descripcion = value; }
        }

        public string par_Valor
        {
            get { return _Par_Valor; }
            set { _Par_Valor = value; }
        }
    }
}
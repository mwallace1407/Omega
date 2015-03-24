using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioHSC.Model
{
    public class Puesto
    {
        private int _idPuesto;
        private string _descripcion;
        private string _estatus;

        public int idPuesto
        {
            get { return _idPuesto; }
            set { _idPuesto = value; }
        }
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
    }
}

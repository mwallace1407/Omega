using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioHSC.Model
{
    public class Estado
    {
        private int _idEstado;
        private string _descripcion;

        public int idEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}

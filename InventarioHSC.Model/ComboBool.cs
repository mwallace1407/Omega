using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioHSC.Model
{
    public class ComboBool
    {
        private string _id;
        private string _descripcion;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}

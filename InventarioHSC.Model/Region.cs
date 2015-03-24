using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioHSC.Model
{
    public class Region
    {
        private int _idRegion;
        private string _nombre;
        private string _status;

        public int idRegion
        {
            get { return _idRegion; }
            set { _idRegion = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}

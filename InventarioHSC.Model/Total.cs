using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioHSC.Model
{
    public class Total
    {
        private int _Id;

        public int id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Concepto;

        public string concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }
        private int _Conteo;

        public int conteo
        {
            get { return _Conteo; }
            set { _Conteo = value; }
        }
    }
}

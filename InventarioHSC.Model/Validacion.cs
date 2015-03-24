using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioHSC.Model
{
    public class Validacion
    {
        private bool _Validate;
        private string _Message;

        public bool validate
        {
            get { return _Validate; }
            set { _Validate = value; }
        }
        public string message
        {
            get { return _Message; }
            set { _Message = value; }
        }
    }
}

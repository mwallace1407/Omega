using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//.
namespace InventarioHSC.Model
{
    public class RolSeguridad
    {
        private string _RolNombre;
        private string _RolDescripcion;

        public string RolNombre
        {
            get { return _RolNombre; }
            set { _RolNombre = value; }
        }
        public string RolDescripcion
        {
            get { return _RolDescripcion; }
            set { _RolDescripcion = value; }
        }
    }
}

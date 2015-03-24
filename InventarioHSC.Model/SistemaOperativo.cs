using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioHSC.Model
{
    public class SistemaOperativo
    {
        private int _idSistema;
        private string _descripcion;
        private bool _estatus;
        private string _version;

        public int idSistema
        {
            get { return _idSistema; }
            set { _idSistema = value; }
        }
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public bool estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
        public string version
        {
            get { return _version; }
            set { _version = value; }
        }
    }
}

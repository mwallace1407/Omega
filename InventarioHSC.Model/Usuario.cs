using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioHSC.Model
{
    public class Usuario
    {
        private int _idUsuario;
        private string _nombre;
        private int _idPuesto;
        private string _puestoDesc;
        private string _Estatus;

        public int idUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int idPuesto
        {
            get { return _idPuesto; }
            set { _idPuesto = value; }
        }
        public string puestoDesc
        {
            get { return _puestoDesc; }
            set { _puestoDesc = value; }
        }
        public string estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

    }
}

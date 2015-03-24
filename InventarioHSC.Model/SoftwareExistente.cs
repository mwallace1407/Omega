using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioHSC.Model
{
    public class SoftwareExistente
    {
        int _SWEX_Id;
        int _SW_Id;
        string _Descripcion;
        string _NoParte;
        string _Llave;
        string _Ubicacion;
        string _Observaciones;
        bool _EnExistencia;

        public int SW_Id
        {
            get { return _SW_Id; }
            set { _SW_Id = value; }
        }

        public int Id
        {
            get { return _SWEX_Id; }
            set { _SWEX_Id = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string NoParte
        {
            get { return _NoParte; }
            set { _NoParte = value; }
        }

        public string Llave
        {
            get { return _Llave; }
            set { _Llave = value; }
        }

        public string Ubicacion
        {
            get { return _Ubicacion; }
            set { _Ubicacion = value; }
        }

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        public bool EnExistencia
        {
            get { return _EnExistencia; }
            set { _EnExistencia = value; }
        }
    }
}

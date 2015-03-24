using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioHSC.Model
{
    public class CatalogoSoftware
    {
        int _id;
        int _idEmpresa;
        int _idGrupo;
        string _descripcion;
        string _version;
        bool _estatus;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int idEmpresa
        {
            get { return _idEmpresa; }
            set { _idEmpresa = value; }
        }

        public int idGrupo
        {
            get { return _idGrupo; }
            set { _idGrupo = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public bool Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
    }
}

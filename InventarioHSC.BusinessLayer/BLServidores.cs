using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using InventarioHSC.Model;
using InventarioHSC.DataLayer;

namespace InventarioHSC.BusinessLayer
{
    public class BLServidores
    {
        public string RegistrarCinta(DatosGenerales.TiposRespaldoCintas Tipo, int Obj_Id, string RC_Cinta, string RC_Observaciones, DateTime RC_FechaRespaldo)
        {
            DLServidores odlServidores = new DLServidores();

            return odlServidores.RegistrarCinta(Tipo, Obj_Id, RC_Cinta, RC_Observaciones, RC_FechaRespaldo);
        }

        public string RegistrarCinta(int Tipo, int Obj_Id, string RC_Cinta, string RC_Observaciones, DateTime RC_FechaRespaldo)
        {
            DLServidores odlServidores = new DLServidores();

            return odlServidores.RegistrarCinta(Tipo, Obj_Id, RC_Cinta, RC_Observaciones, RC_FechaRespaldo);
        }

        public DataTable BuscarObjetosRespaldo(int TR_Id)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            return DataLayerSoftware.BuscarObjetosRespaldo(TR_Id);
        }

        public string ReporteCintas(int Tipo, int Obj_Id, string RC_Cinta, string RutaArchivos)
        {
            DLServidores odlServidores = new DLServidores();
            int? TipoN = null;
            int? Obj_IdN = null;

            if (Tipo > 0)
                TipoN = Tipo;

            if (Obj_Id > 0)
                Obj_IdN = Obj_Id;

            if (RC_Cinta.Trim() == "")
                RC_Cinta = null;

            return odlServidores.ReporteCintas(TipoN, Obj_IdN, RC_Cinta, RutaArchivos);
        }

        public DataTable ObtenerTareas(string UserName, DateTime SrvT_Inicio, DateTime SrvT_Fin, int? SrvET_Id = null, int? SrvCT_Id = null, bool? SrvT_EsPrivada = null)
        {
            DLServidores odlServidores = new DLServidores();

            return odlServidores.ObtenerTareas(UserName, SrvT_Inicio, SrvT_Fin, SrvET_Id, SrvCT_Id, SrvT_EsPrivada);
        }

        public string AgregarCategoria(string UserName, string SrvCT_Descripcion)
        {
            DLServidores odlServidores = new DLServidores();

            return odlServidores.AgregarCategoria(UserName, SrvCT_Descripcion);
        }

        public string AgregarInvolucradoTarea(int SrvT_Id, string UserName)
        {
            DLServidores odlServidores = new DLServidores();

            return odlServidores.AgregarInvolucradoTarea(SrvT_Id, UserName);
        }

        public string RegistrarTarea(int SrvET_Id, int SrvCT_Id, string UserName, DateTime SrvT_Inicio, DateTime SrvT_Fin, string SrvT_Descripcion, bool SrvT_EsPrivada)
        {
            DLServidores odlServidores = new DLServidores();

            return odlServidores.RegistrarTarea(SrvET_Id, SrvCT_Id, UserName, SrvT_Inicio, SrvT_Fin, SrvT_Descripcion, SrvT_EsPrivada);
        }

        public string ActualizarTarea(int SrvT_Id, int SrvET_Id, int SrvCT_Id, DateTime SrvT_Inicio, DateTime SrvT_Fin, string SrvT_Descripcion, bool SrvT_EsPrivada, bool BorrarInvolucrados)
        {
            DLServidores odlServidores = new DLServidores();

            return odlServidores.ActualizarTarea(SrvT_Id, SrvET_Id, SrvCT_Id, SrvT_Inicio, SrvT_Fin, SrvT_Descripcion, SrvT_EsPrivada, BorrarInvolucrados);
        }

        public DataSet ObtenerDetalleTarea(int SrvT_Id)
        {
            DLServidores odlServidores = new DLServidores();

            return odlServidores.ObtenerDetalleTarea(SrvT_Id);
        }

        public string TareasAExcel(string UserName, int? SrvET_Id, int? SrvCT_Id, DateTime? SrvT_Inicio, DateTime? SrvT_Fin, bool? SrvT_EsPrivada, string RutaArchivos)
        {
            DLServidores odlServidores = new DLServidores();

            return odlServidores.TareasAExcel(UserName, SrvET_Id, SrvCT_Id, SrvT_Inicio, SrvT_Fin, SrvT_EsPrivada, RutaArchivos);
        }
    }
}

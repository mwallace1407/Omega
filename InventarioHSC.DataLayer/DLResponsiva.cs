using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using InventarioHSC.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace InventarioHSC.DataLayer
{
    public class DLResponsiva
    {
        public DLResponsiva()
        {

        }
       
        public List<Responsiva> GetDatosResponsiva(string sResponsiva)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DataSet ds = new DataSet();
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpS_ObtieneDatosResponsiva");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pResponsiva",DbType.Int64 , sResponsiva);

            List<Responsiva> lstResponsiva = new List<Responsiva>();
            try
            {
                ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables.Count > 0)
                {
                    
                    foreach (DataRow dr  in ds.Tables[0].Rows)
                    {
                        Responsiva objResponsiva = new Responsiva();
                        objResponsiva.idResponsiva = dr["Responsiva"].ToString();
                        objResponsiva.usuario = dr["usuario"].ToString();
                        objResponsiva.puesto = dr["Puesto"].ToString();
                        objResponsiva.sucursal = dr["sucursal"].ToString();
                        objResponsiva.tipoequipo = dr["tipoequipo"].ToString();
                        objResponsiva.modelo = dr["modelo"].ToString();
                        objResponsiva.noserie = dr["noserie"].ToString();
                        objResponsiva.procesador= dr["procesador"].ToString();
                        objResponsiva.memoria = dr["memoria"].ToString();
                        objResponsiva.discoduro = dr["discoduro"].ToString();
                        objResponsiva.marca = dr["marca"].ToString();
                        objResponsiva.observacion1 = dr["observacion1"].ToString();
                        objResponsiva.observacion2 = dr["observacion2"].ToString();
                        objResponsiva.ObservacionesResponsiva = dr["ObservacionesResponsiva"].ToString();
                        lstResponsiva.Add(objResponsiva);
                    }
                }
                return lstResponsiva;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }
    }

}

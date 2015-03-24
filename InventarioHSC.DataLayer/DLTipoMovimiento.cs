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
    public class DLTipoMovimiento
    {
        public DLTipoMovimiento()
        {

        }
        public TipoMovimiento getTipoMovimientoporID(int idTipoMovimiento)
        {
            TipoMovimiento oTipoMovimiento= new TipoMovimiento();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT    idTipoMovimiento ");
            sqlCommand.AppendLine("		, Descripcion ");
            sqlCommand.AppendLine("		, Estatus ");
            sqlCommand.AppendLine("FROM TipoMovimiento ");
            sqlCommand.AppendLine("WHERE Estatus = 1 ");
            sqlCommand.AppendLine("AND idTipoMovimiento = @idTipoMovimiento ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idTipoMovimiento", DbType.Int32, idTipoMovimiento);

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {

                throw ex;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    oTipoMovimiento.idTipoMovimiento = Convert.ToInt32(dr["idTipoMovimiento"]);
                    oTipoMovimiento.descripcion = dr["Descripcion"].ToString();
                    oTipoMovimiento.estatus = Convert.ToBoolean(dr["Estatus"]);                    
                }
            }
            return oTipoMovimiento;
        }

        public TipoMovimiento getTipoMovimientoporDescripcion(string ssDescripcion)
        {
            TipoMovimiento oTipoMovimiento = new TipoMovimiento();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT    idTipoMovimiento ");
            sqlCommand.AppendLine("		, Descripcion ");
            sqlCommand.AppendLine("		, Estatus ");
            sqlCommand.AppendLine("FROM TipoMovimiento ");
            sqlCommand.AppendLine("WHERE Estatus = 1 "); 
            sqlCommand.AppendLine("AND   Descripcion = @Descripcion");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@Descripcion", DbType.String, ssDescripcion);

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {

                throw ex;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    oTipoMovimiento.idTipoMovimiento = Convert.ToInt32(dr["idTipoMovimiento"]);
                    oTipoMovimiento.descripcion = dr["Descripcion"].ToString();
                    oTipoMovimiento.estatus = Convert.ToBoolean(dr["Estatus"]);

                }
            }
            return oTipoMovimiento;
        }

        public List<TipoMovimiento> getTipoMovimientoAll()
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT    idTipoMovimiento ");
            sqlCommand.AppendLine("		, Descripcion ");
            sqlCommand.AppendLine("		, Estatus ");
            sqlCommand.AppendLine("FROM TipoMovimiento ");
            sqlCommand.AppendLine("WHERE Estatus = 1 "); 

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<TipoMovimiento> lstTipoMovimiento = new List<TipoMovimiento>();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        TipoMovimiento oTipoMovimiento = new TipoMovimiento();
                        oTipoMovimiento.idTipoMovimiento = Convert.ToInt32(dr["idTipoMovimiento"]);
                        oTipoMovimiento.descripcion = dr["Descripcion"].ToString();
                        oTipoMovimiento.estatus = Convert.ToBoolean(dr["Estatus"]);
                        lstTipoMovimiento.Add(oTipoMovimiento);
                    }
                }
                return lstTipoMovimiento;
            }
            catch (DataException ex)
            {

                throw ex;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using InventarioHSC.Model;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace InventarioHSC.DataLayer
{
    public class DLEstado
    {
        public DLEstado()
        {
        }

        public Estado getEstadoporID(int idEstado)
        {
            Estado oEstado = new Estado();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT	 idEstado ");
            sqlCommand.AppendLine("	   , Descripcion ");
            sqlCommand.AppendLine("FROM	Estado ");
            sqlCommand.AppendLine("WHERE idEstado = @idEstado ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idEstado", DbType.Int32, idEstado);

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
            //db.AddInParameter("@id", DbType.Int32, idArea);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    oEstado.idEstado = Convert.ToInt32(dr["idEstado"]);
                    oEstado.descripcion = dr["Descripcion"].ToString();
                }
            }
            return oEstado;
        }

        public Estado getEstadoporDescripcion(string ssDescripcion)
        {
            Estado oEstado = new Estado();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT	 idEstado ");
            sqlCommand.AppendLine("	       , Descripcion ");
            sqlCommand.AppendLine("FROM	Estado ");
            sqlCommand.AppendLine("WHERE Descripcion = @Descripcion ");

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
            //db.AddInParameter("@id", DbType.Int32, idArea);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    oEstado.idEstado = Convert.ToInt32(dr["idEstado"]);
                    oEstado.descripcion = dr["Descripcion"].ToString();
                }
            }
            return oEstado;
        }

        public List<Estado> getEstadoAll()
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT 0 as idEstado  ");
            sqlCommand.AppendLine("	  , '' as Descripcion ");
            sqlCommand.AppendLine("UNION ");
            sqlCommand.AppendLine("SELECT	 idEstado ");
            sqlCommand.AppendLine(" 	    , Descripcion ");
            sqlCommand.AppendLine("FROM	Estado ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<Estado> lstEstado = new List<Estado>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Estado oEstado = new Estado();
                        oEstado.idEstado = Convert.ToInt32(dr["idEstado"]);
                        oEstado.descripcion = dr["Descripcion"].ToString();
                        lstEstado.Add(oEstado);
                    }
                }
                return lstEstado;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }
    }
}
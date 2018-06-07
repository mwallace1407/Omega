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
    public class DLTipoEquipo
    {
        public DLTipoEquipo()
        {
        }

        public TipoEquipo getTipoEquipoporID(int iidTipoEquipo)
        {
            TipoEquipo oTipoEquipo = new TipoEquipo();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT	 idTipoEquipo ");
            sqlCommand.AppendLine("	   , Descripcion ");
            sqlCommand.AppendLine("FROM	TipoEquipo ");
            sqlCommand.AppendLine("WHERE idTipoEquipo = @idTipoEquipo ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idTipoEquipo", DbType.Int32, iidTipoEquipo);

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
                    oTipoEquipo.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                    oTipoEquipo.descripcion = dr["Descripcion"].ToString();
                }
            }
            return oTipoEquipo;
        }

        public TipoEquipo getTipoEquipoporDescripcion(string ssDescripcion)
        {
            TipoEquipo oTipoEquipo = new TipoEquipo();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT	 idTipoEquipo ");
            sqlCommand.AppendLine("	       , Descripcion ");
            sqlCommand.AppendLine("FROM	TipoEquipo ");
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
                    oTipoEquipo.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                    oTipoEquipo.descripcion = dr["Descripcion"].ToString();
                }
            }
            return oTipoEquipo;
        }

        public List<TipoEquipo> getTipoEquipoAll()
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            //Database db = DatabaseFactory.CreateDatabase();
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT 0 AS idTipoEquipo, ");
            sqlCommand.AppendLine("	 ' ' AS Descripcion  ");
            sqlCommand.AppendLine("UNION ");
            sqlCommand.AppendLine("SELECT	 idTipoEquipo ");
            sqlCommand.AppendLine("	   , Descripcion ");
            sqlCommand.AppendLine("FROM	TipoEquipo ");
            sqlCommand.AppendLine("WHERE Estatus = 1 ");
            sqlCommand.AppendLine("order by Descripcion ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<TipoEquipo> lstTipoEquipo = new List<TipoEquipo>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        TipoEquipo oTipoEquipo = new TipoEquipo();
                        oTipoEquipo.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                        oTipoEquipo.descripcion = dr["Descripcion"].ToString();
                        lstTipoEquipo.Add(oTipoEquipo);
                    }
                }
                return lstTipoEquipo;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void InsertTipoEquipo(ref TipoEquipo oTipoEquipo)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_TipoEquipo");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pDescripcion", DbType.String, oTipoEquipo.descripcion);
            db.AddOutParameter(dbCommand, "@pidTipoEquipo", DbType.Int64, 4);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                oTipoEquipo.idTipoEquipo = Convert.ToInt32(db.GetParameterValue(dbCommand, "@pidTipoEquipo"));
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void UpdateTipoEquipo(ref TipoEquipo oTipoEquipo)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("UPDATE TipoEquipo ");
            sqlCommand.AppendLine("SET Descripcion = @pDescripcion ");
            sqlCommand.AppendLine("  , Estatus  = @pEstatus ");
            sqlCommand.AppendLine("WHERE idTipoEquipo = @pidTipoEquipo ");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pDescripcion", DbType.String, oTipoEquipo.descripcion);
            db.AddInParameter(dbCommand, "@pEstatus", DbType.Boolean, oTipoEquipo.estatus == "ACTIVO" ? 1 : 0);
            db.AddInParameter(dbCommand, "@pidTipoEquipo", DbType.Int32, oTipoEquipo.idTipoEquipo);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public int ValidarTiposAsignados(int idTipoEquipo)
        {
            int idTotal = 0;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" SELECT COUNT(*) AS Total ");
            sqlCommand.AppendLine(" FROM Articulo ");
            sqlCommand.AppendLine(" WHERE idTipoEquipo = @pidTipoEquipo ");

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pidTipoEquipo", DbType.Int32, idTipoEquipo);

            try
            {
                idTotal = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (DataException ex)
            {
                throw ex;
            }

            return idTotal;
        }
    }
}
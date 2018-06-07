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
    public class DLRegion
    {
        public DLRegion()
        {
        }

        public Region getRegionporID(int idRegion)
        {
            Region oRegion = new Region();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT    idRegion ");
            sqlCommand.AppendLine("		   , Nombre ");
            sqlCommand.AppendLine("	       , CASE Estatus ");
            sqlCommand.AppendLine("	            WHEN 1 THEN 'ACTIVO' ");
            sqlCommand.AppendLine("	            WHEN 0 THEN 'INACTIVO' ");
            sqlCommand.AppendLine("	         END AS Estatus");
            sqlCommand.AppendLine("FROM Region  ");
            sqlCommand.AppendLine("WHERE Estatus = 1 ");
            sqlCommand.AppendLine("AND	  idRegion = @idRegion ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idRegion", DbType.Int32, idRegion);

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
                    oRegion.idRegion = Convert.ToInt32(dr["idRegion"]);
                    oRegion.nombre = dr["Nombre"].ToString();
                }
            }
            return oRegion;
        }

        public Region getRegionporDescripcion(string ssDescripcion)
        {
            Region oRegion = new Region();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT    idRegion ");
            sqlCommand.AppendLine("		   , Nombre ");
            sqlCommand.AppendLine("	       , CASE Estatus ");
            sqlCommand.AppendLine("	            WHEN 1 THEN 'ACTIVO' ");
            sqlCommand.AppendLine("	            WHEN 0 THEN 'INACTIVO' ");
            sqlCommand.AppendLine("	         END AS Estatus");
            sqlCommand.AppendLine("FROM Region  ");
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
                    oRegion.idRegion = Convert.ToInt32(dr["idRegion"]);
                    oRegion.nombre = dr["Nombre"].ToString();
                }
            }
            return oRegion;
        }

        public List<Region> getRegionAll()
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" SELECT	  0 AS idRegion ");
            sqlCommand.AppendLine(" 		, '' AS Nombre ");
            sqlCommand.AppendLine(" 		, 'INACTIVO' as Estatus ");
            sqlCommand.AppendLine(" UNION ");
            sqlCommand.AppendLine("SELECT    idRegion ");
            sqlCommand.AppendLine("		   , Nombre ");
            sqlCommand.AppendLine("	       , CASE Estatus ");
            sqlCommand.AppendLine("	            WHEN 1 THEN 'ACTIVO' ");
            sqlCommand.AppendLine("	            WHEN 0 THEN 'INACTIVO' ");
            sqlCommand.AppendLine("	         END AS Estatus");
            sqlCommand.AppendLine("FROM Region  ");
            sqlCommand.AppendLine("WHERE Estatus = 1 ");
            sqlCommand.AppendLine("ORDER BY idRegion ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<Region> lstRegion = new List<Region>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Region oRegion = new Region();
                        oRegion.idRegion = Convert.ToInt32(dr["idRegion"]);
                        oRegion.nombre = dr["Nombre"].ToString();
                        lstRegion.Add(oRegion);
                    }
                }
                return lstRegion;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void InsertRegion(ref Region oRegion)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_Region");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pDescripcion", DbType.String, oRegion.nombre);
            db.AddOutParameter(dbCommand, "@pidRegion", DbType.Int64, 4);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                oRegion.idRegion = Convert.ToInt32(db.GetParameterValue(dbCommand, "@pidRegion"));
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void UpdateRegion(ref Region oRegion)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("UPDATE Region ");
            sqlCommand.AppendLine("SET Nombre = @pDescripcion ");
            sqlCommand.AppendLine("  , Estatus  = @pEstatus ");
            sqlCommand.AppendLine("WHERE idRegion = @pidRegion");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pDescripcion", DbType.String, oRegion.nombre);
            db.AddInParameter(dbCommand, "@pEstatus", DbType.Boolean, oRegion.status == "ACTIVO" ? 1 : 0);
            db.AddInParameter(dbCommand, "@pidRegion", DbType.Int32, oRegion.idRegion);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public int CountSucursalRegion(int idRegion)
        {
            int total = 0;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" SELECT  ");
            sqlCommand.AppendLine(" 	COUNT(idSucursal)  ");
            sqlCommand.AppendLine(" FROM Sucursal  ");
            sqlCommand.AppendLine(" WHERE idRegion = @pidRegion ");

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pidRegion", DbType.Int32, idRegion);

            try
            {
                total = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (DataException ex)
            {
                throw ex;
            }

            return total;
        }
    }
}
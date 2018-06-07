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
    public class DLUbicacion
    {
        public DLUbicacion()
        {
        }

        public Ubicacion getUbicacionporID(int idUbicacion)
        {
            Ubicacion oUbicacion = new Ubicacion();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT    idUbicacion ");
            sqlCommand.AppendLine("		, Descripcion ");
            sqlCommand.AppendLine("		, idRegion ");
            //sqlCommand.AppendLine("		, Estatus ");
            sqlCommand.AppendLine("FROM Ubicacion ");
            sqlCommand.AppendLine("WHERE Estatus = 1 ");
            sqlCommand.AppendLine("AND idUbicacion = @idUbicacion ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idUbicacion", DbType.Int32, idUbicacion);

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
                    oUbicacion.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                    oUbicacion.descripcion = dr["Descripcion"].ToString();
                    oUbicacion.idRegion = Convert.ToInt32(dr["idRegion"]);
                    //oUbicacion.estatus = Convert.ToBoolean(dr["Estatus"]);
                }
            }
            return oUbicacion;
        }

        public Ubicacion getUbicacionporDescripcion(string ssDescripcion)
        {
            Ubicacion oUbicacion = new Ubicacion();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT idUbicacion ");
            sqlCommand.AppendLine("		, Descripcion ");
            sqlCommand.AppendLine("		, idRegion ");
            //sqlCommand.AppendLine("		, Estatus ");
            sqlCommand.AppendLine("FROM Ubicacion ");
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
                    oUbicacion.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                    oUbicacion.descripcion = dr["Descripcion"].ToString();
                    oUbicacion.idRegion = Convert.ToInt32(dr["idRegion"]);
                    //oUbicacion.estatus = Convert.ToBoolean(dr["Estatus"]);
                }
            }
            return oUbicacion;
        }

        public List<Ubicacion> getUbicacionAll()
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" SELECT	  0 AS idUbicacion ");
            sqlCommand.AppendLine(" 		, '' AS Descripcion ");
            sqlCommand.AppendLine(" 		, 0 as idRegion ");
            sqlCommand.AppendLine(" 		, '' as descRegion ");
            sqlCommand.AppendLine(" UNION ");
            sqlCommand.AppendLine(" SELECT   U.idUbicacion ");
            sqlCommand.AppendLine("  		, U.Descripcion ");
            sqlCommand.AppendLine("  		, U.idRegion ");
            sqlCommand.AppendLine("		, R.Nombre ");
            sqlCommand.AppendLine(" FROM Ubicacion U ");
            sqlCommand.AppendLine(" INNER JOIN Region R ON U.idRegion = R.idRegion ");
            sqlCommand.AppendLine(" WHERE U.Estatus = 1 ");
            sqlCommand.AppendLine(" order by 2");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<Ubicacion> lstUbicacion = new List<Ubicacion>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Ubicacion oUbicacion = new Ubicacion();
                        oUbicacion.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                        oUbicacion.descripcion = dr["Descripcion"].ToString();
                        oUbicacion.idRegion = Convert.ToInt32(dr["idRegion"]);
                        oUbicacion.descRegion = dr["descRegion"].ToString();
                        lstUbicacion.Add(oUbicacion);
                    }
                }
                return lstUbicacion;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public List<Ubicacion> getUbicacionAll(bool VisibleAltaArticulo)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" SELECT	  0 AS idUbicacion ");
            sqlCommand.AppendLine(" 		, '' AS Descripcion ");
            sqlCommand.AppendLine(" 		, 0 as idRegion ");
            sqlCommand.AppendLine(" 		, '' as descRegion ");
            sqlCommand.AppendLine(" UNION ");
            sqlCommand.AppendLine(" SELECT   U.idUbicacion ");
            sqlCommand.AppendLine("  		, U.Descripcion ");
            sqlCommand.AppendLine("  		, U.idRegion ");
            sqlCommand.AppendLine("		, R.Nombre ");
            sqlCommand.AppendLine(" FROM Ubicacion U ");
            sqlCommand.AppendLine(" INNER JOIN Region R ON U.idRegion = R.idRegion ");

            if (VisibleAltaArticulo)
                sqlCommand.AppendLine(" WHERE U.Estatus = 1 AND U.VisibleAltaArticulos = 1");
            else
                sqlCommand.AppendLine(" WHERE U.Estatus = 1 AND U.VisibleAltaArticulos = 0");

            sqlCommand.AppendLine(" order by 2");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<Ubicacion> lstUbicacion = new List<Ubicacion>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Ubicacion oUbicacion = new Ubicacion();
                        oUbicacion.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                        oUbicacion.descripcion = dr["Descripcion"].ToString();
                        oUbicacion.idRegion = Convert.ToInt32(dr["idRegion"]);
                        oUbicacion.descRegion = dr["descRegion"].ToString();
                        lstUbicacion.Add(oUbicacion);
                    }
                }
                return lstUbicacion;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void InsertUbicacion(ref Ubicacion oUbicacion)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_Ubicacion");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pDescripcion", DbType.String, oUbicacion.descripcion);
            db.AddInParameter(dbCommand, "@pidRegion", DbType.Int64, oUbicacion.idRegion);
            db.AddOutParameter(dbCommand, "@pidUbicacion", DbType.Int64, 4);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                oUbicacion.idUbicacion = Convert.ToInt32(db.GetParameterValue(dbCommand, "@pidUbicacion"));
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void UpdateUbicacion(ref Ubicacion oUbicacion)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("UPDATE Ubicacion ");
            sqlCommand.AppendLine("SET Descripcion = @pDescripcion ");
            sqlCommand.AppendLine("  , idRegion  = @pidRegion ");
            sqlCommand.AppendLine("  , Estatus  = @pEstatus ");
            sqlCommand.AppendLine("WHERE idUbicacion = @pidUbicacion");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pDescripcion", DbType.String, oUbicacion.descripcion);
            db.AddInParameter(dbCommand, "@pidRegion", DbType.Int32, oUbicacion.idRegion);
            db.AddInParameter(dbCommand, "@pEstatus", DbType.Boolean, oUbicacion.estatus == "ACTIVO" ? 1 : 0);
            db.AddInParameter(dbCommand, "@pidUbicacion", DbType.Int32, oUbicacion.idUbicacion);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public int CountArticuloUbicacion(int idUsuario)
        {
            int total = 0;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" SELECT ");
            sqlCommand.AppendLine("   	COUNT(idUbicacion) ");
            sqlCommand.AppendLine("   FROM Articulo ");
            sqlCommand.AppendLine("   WHERE idUbicacion = @pidUbicacion ");

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pidUbicacion", DbType.Int32, idUsuario);

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
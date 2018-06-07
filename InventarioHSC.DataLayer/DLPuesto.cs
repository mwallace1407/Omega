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
    public class DLPuesto
    {
        public DLPuesto()
        {
        }

        public Puesto getPuestoporID(int idPuesto)
        {
            Puesto oPuesto = new Puesto();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT	 idPuesto ");
            sqlCommand.AppendLine("	   , Descripcion ");
            sqlCommand.AppendLine("FROM	Puesto ");
            sqlCommand.AppendLine("WHERE idPuesto = @idPuesto ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idPuesto", DbType.Int32, idPuesto);

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
                    oPuesto.idPuesto = Convert.ToInt32(dr["idPuesto"]);
                    oPuesto.descripcion = dr["Descripcion"].ToString();
                }
            }
            return oPuesto;
        }

        public Puesto getPuestoporDescripcion(string ssDescripcion)
        {
            Puesto oPuesto = new Puesto();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT	 idPuesto ");
            sqlCommand.AppendLine("	       , Descripcion ");
            sqlCommand.AppendLine("FROM	Puesto ");
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
                    oPuesto.idPuesto = Convert.ToInt32(dr["idPuesto"]);
                    oPuesto.descripcion = dr["Descripcion"].ToString();
                }
            }
            return oPuesto;
        }

        public List<Puesto> getPuestoAll()
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" SELECT    0 as idPuesto ");
            sqlCommand.AppendLine("         , ' ' AS Descripcion ");
            sqlCommand.AppendLine("         , 'ACTIVO' AS Estatus");
            sqlCommand.AppendLine(" UNION ");
            sqlCommand.AppendLine(" SELECT	 idPuesto ");
            sqlCommand.AppendLine(" 	       , Descripcion ");
            sqlCommand.AppendLine(" 	       , CASE Estatus ");
            sqlCommand.AppendLine(" 	            WHEN 1 THEN 'ACTIVO' ");
            sqlCommand.AppendLine(" 	            WHEN 0 THEN 'INACTIVO' ");
            sqlCommand.AppendLine(" 	         END AS Estatus");
            sqlCommand.AppendLine(" FROM	Puesto ");
            sqlCommand.AppendLine(" WHERE Estatus = 1 ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<Puesto> lstPuesto = new List<Puesto>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Puesto oPuesto = new Puesto();
                        oPuesto.idPuesto = Convert.ToInt32(dr["idPuesto"]);
                        oPuesto.descripcion = dr["Descripcion"].ToString();
                        oPuesto.estatus = dr["Estatus"].ToString();
                        lstPuesto.Add(oPuesto);
                    }
                }
                return lstPuesto;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void InsertPuesto(ref Puesto oPuesto)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_Puesto");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pDescripcion", DbType.String, oPuesto.descripcion);
            db.AddOutParameter(dbCommand, "@pidPuesto", DbType.Int64, 4);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                oPuesto.idPuesto = Convert.ToInt32(db.GetParameterValue(dbCommand, "@pidPuesto"));
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void UpdatePuesto(ref Puesto oPuesto)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("UPDATE pUESTO ");
            sqlCommand.AppendLine("SET Descripcion = @pDescripcion ");
            sqlCommand.AppendLine("  , Estatus  = @pEstatus ");
            sqlCommand.AppendLine("WHERE idPuesto = @pidPuesto");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pDescripcion", DbType.String, oPuesto.descripcion);
            db.AddInParameter(dbCommand, "@pEstatus", DbType.Boolean, oPuesto.estatus == "ACTIVO" ? 1 : 0);
            db.AddInParameter(dbCommand, "@pidPuesto", DbType.Int32, oPuesto.idPuesto);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public int ValidaAsignacionPuesto(int idPuesto)
        {
            int Total = 0;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" SELECT COUNT(*) ");
            sqlCommand.AppendLine(" FROM Usuario  ");
            sqlCommand.AppendLine(" WHERE idPuesto  = @pidPuesto ");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pidPuesto", DbType.Int32, idPuesto);

            try
            {
                Total = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (DataException ex)
            {
                throw ex;
            }
            return Total;
        }
    }
}
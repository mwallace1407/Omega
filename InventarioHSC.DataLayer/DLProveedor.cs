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
    public class DLProveedor
    {
        public DLProveedor()
        {

        }

        public Proveedor getProveedorID(int idProveedor)
        {
            Proveedor oProveedor = new Proveedor();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT    idProveedor ");
            sqlCommand.AppendLine("         , Descripcion ");
            sqlCommand.AppendLine("FROM  proveedor ");
            sqlCommand.AppendLine("WHERE idProveedor = @idProveedor ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idProveedor", DbType.Int32, idProveedor);

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
                    oProveedor.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                    oProveedor.descripcion = dr["Descripcion"].ToString();
                }
            }
            return oProveedor;
        }

        public Proveedor getProveedorporDescripcion(string ssDescripcion)
        {
            Proveedor oProveedor = new Proveedor();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT    idProveedor ");
            sqlCommand.AppendLine("         , Descripcion ");
            sqlCommand.AppendLine("FROM  proveedor ");
            sqlCommand.AppendLine("WHERE	Descripcion = @Descripcion");

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
                    oProveedor.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                    oProveedor.descripcion = dr["Descripcion"].ToString();
                }
            }
            return oProveedor;
        }

        public List<Proveedor> getProveedorAll()
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT 0 AS idProveedor ");
            sqlCommand.AppendLine("		, '' AS Descripcion ");
            sqlCommand.AppendLine("		, 'Activo' AS Estatus ");
            sqlCommand.AppendLine("UNION ");
            sqlCommand.AppendLine("SELECT      idProveedor  ");
            sqlCommand.AppendLine("          , Descripcion  ");
            sqlCommand.AppendLine("          , CASE Estatus  ");
            sqlCommand.AppendLine("          WHEN 1 THEN 'Activo'  ");
            sqlCommand.AppendLine("          WHEN 0 THEN 'Inactivo'  ");
            sqlCommand.AppendLine("          END AS Estatus  ");
            sqlCommand.AppendLine("FROM  proveedor  ");
            sqlCommand.AppendLine("WHERE Estatus = 1 ");
            sqlCommand.AppendLine("ORDER BY idProveedor ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<Proveedor> lstProveedor = new List<Proveedor>();
                if (ds.Tables[0].Rows.Count > 0)   
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Proveedor oProveedor = new Proveedor();
                        oProveedor.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                        oProveedor.descripcion = dr["Descripcion"].ToString();
                        lstProveedor.Add(oProveedor);
                    }
                }
                return lstProveedor;
            }
            catch (DataException ex)
            {

                throw ex;
            }
        }


        public void InsertProveedor(ref Proveedor oProveedor)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_Proveedor");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pDescripcion", DbType.String, oProveedor.descripcion);
            db.AddOutParameter(dbCommand, "@pidProveedor", DbType.Int64, 4);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                oProveedor.idProveedor = Convert.ToInt32(db.GetParameterValue(dbCommand, "@pidProveedor"));
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void UpdateProveedor(ref Proveedor oProveedor)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("UPDATE Proveedor ");
            sqlCommand.AppendLine("SET Descripcion = @pDescripcion ");
            sqlCommand.AppendLine("  , Estatus  = @pEstatus ");
            sqlCommand.AppendLine("WHERE idProveedor = @pidProveedor ");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pDescripcion", DbType.String, oProveedor.descripcion);
            db.AddInParameter(dbCommand, "@pEstatus", DbType.Boolean, oProveedor.estatus =="ACTIVO"?1:0);
            db.AddInParameter(dbCommand, "@pidProveedor", DbType.Int32, oProveedor.idProveedor);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public int ValidarProveedoresAsignados(int idProveedor)
        {
            int idTotal = 0;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" SELECT COUNT(*) AS Total ");
            sqlCommand.AppendLine(" FROM Articulo ");
            sqlCommand.AppendLine(" WHERE idProveedor = @pidProveedor ");

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pidProveedor", DbType.Int32, idProveedor);

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

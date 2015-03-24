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
    public class DLMarca
    {
        public DLMarca()
        {

        }

        public Marca getMarcaporID(int idMarca)
        {
            Marca oMarca = new Marca();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT    idMarca ");
            sqlCommand.AppendLine("		, Descripcion ");
            sqlCommand.AppendLine("FROM	Marca ");
            sqlCommand.AppendLine("WHERE	idMarca = @idMarca");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idMarca", DbType.Int32, idMarca);

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
                    oMarca.idMarca = Convert.ToInt32(dr["idMarca"]);
                    oMarca.descripcion = dr["Descripcion"].ToString();
                }
            }
            return oMarca;
        }

        public Marca getMarcaporDescripcion(string ssDescripcion)
        {
            Marca oMarca = new Marca();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT    idMarca ");
            sqlCommand.AppendLine("		, Descripcion ");
            sqlCommand.AppendLine("FROM	Marca ");
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
                    oMarca.idMarca = Convert.ToInt32(dr["idMarca"]);
                    oMarca.descripcion = dr["Descripcion"].ToString();
                }
            }
            return oMarca;
        }

        public List<Marca> getMarcaAll()
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT 0 AS idMarca, ");
            sqlCommand.AppendLine("		'' as Descripcion ");
            sqlCommand.AppendLine("	UNION ");
            sqlCommand.AppendLine("SELECT    idMarca ");
            sqlCommand.AppendLine("		, Descripcion ");
            sqlCommand.AppendLine("FROM	Marca ");
            sqlCommand.AppendLine("WHERE Estatus = 1 ");
            sqlCommand.AppendLine("ORDER BY Descripcion ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<Marca> lstMarca = new List<Marca>();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Marca oMarca = new Marca();
                        oMarca.idMarca = Convert.ToInt32(dr["idMarca"]);
                        oMarca.descripcion = dr["Descripcion"].ToString();
                        lstMarca.Add(oMarca);
                    }
                }
                return lstMarca;
            }
            catch (DataException ex)
            {

                throw ex;
            }
        }

        public void InsertMarca(ref Marca oMarca)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_Marca");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pDescripcion", DbType.String, oMarca.descripcion);
            db.AddOutParameter(dbCommand, "@pidMarca", DbType.Int64, 4);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                oMarca.idMarca = Convert.ToInt32(db.GetParameterValue(dbCommand, "@pidMarca"));
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void UpdateMarca(ref Marca oMarca)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("UPDATE Marca ");
            sqlCommand.AppendLine("SET Descripcion = @pDescripcion ");
            sqlCommand.AppendLine("  , Estatus  = @pEstatus ");
            sqlCommand.AppendLine("WHERE idMarca = @pidMarca");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pDescripcion", DbType.String, oMarca.descripcion);
            db.AddInParameter(dbCommand, "@pEstatus", DbType.Boolean, oMarca.estatus == "ACTIVO" ? 1 : 0);
            db.AddInParameter(dbCommand, "@pidMarca", DbType.Int32, oMarca.idMarca);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public int CountMarcaArticulo(int idMarca)
        {
            int total = 0;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" SELECT  ");
            sqlCommand.AppendLine(" 	COUNT(idMarca)  ");
            sqlCommand.AppendLine(" FROM Articulo  ");
            sqlCommand.AppendLine(" WHERE idMarca = @pidMarca ");

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pidMarca", DbType.Int32, idMarca);

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

        public List<Marca> getMarcaPorTipoEquipo(int idTipoEquipo)
        {
            List<Marca> listaMarca = new List<Marca>();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("select distinct t2.idMarca, t2.Descripcion as Marca from Articulo t1 ");
            sqlCommand.AppendLine("inner join Marca t2 on t1.idMarca = t2.idMarca ");
            sqlCommand.AppendLine("where t1.idTipoEquipo = @idTipoEquipo");
            sqlCommand.AppendLine("order by t2.Descripcion");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idTipoEquipo", DbType.Int32, idTipoEquipo);

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Marca oMarca = new Marca();
                oMarca.idMarca = Convert.ToInt32(dr["idMarca"]);
                oMarca.descripcion = dr["Marca"].ToString();
                listaMarca.Add(oMarca);
            }

            return listaMarca;
        }
    }
}

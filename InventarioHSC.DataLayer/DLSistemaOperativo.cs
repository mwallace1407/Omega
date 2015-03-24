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
    public class DLSistemaOperativo
    {
        public DLSistemaOperativo()
        {

        }

        public SistemaOperativo getSistemaOperativoporID(int idSistema)
        {
            SistemaOperativo oSistemaOperativo = new SistemaOperativo();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT	  idSistema ");
            sqlCommand.AppendLine("		, Descripcion ");
            sqlCommand.AppendLine("		, Version ");
            sqlCommand.AppendLine("		, Estatus ");
            sqlCommand.AppendLine("FROM SistemaOperativo ");
            sqlCommand.AppendLine("WHERE idSistema = @idSistema ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idSistema", DbType.Int32, idSistema);

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
                bool estatus;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    oSistemaOperativo.idSistema = Convert.ToInt32(dr["idSistema"]);
                    oSistemaOperativo.descripcion = dr["Descripcion"].ToString();
                    oSistemaOperativo.version = dr["Version"].ToString();
                    bool.TryParse(dr["Estatus"].ToString(), out estatus);
                    oSistemaOperativo.estatus = estatus;
                }
            }
            return oSistemaOperativo;
        }

        public SistemaOperativo getSistemaOperativoporDescripcion(string ssDescripcion)
        {
            SistemaOperativo oSistemaOperativo = new SistemaOperativo();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            //sqlCommand.AppendLine("SELECT	  idSistema ");
            //sqlCommand.AppendLine("		    , Descripcion ");
            //sqlCommand.AppendLine("FROM SistemaOperativo "); 
            //sqlCommand.AppendLine("WHERE   Descripcion = @Descripcion");
            sqlCommand.AppendLine("SELECT idSistema,");
            sqlCommand.AppendLine("       Descripcion,");
            sqlCommand.AppendLine("       Version");
            sqlCommand.AppendLine("       Estatus");
            sqlCommand.AppendLine("FROM   SistemaOperativo");
            sqlCommand.AppendLine("WHERE  Descripcion LIKE '%' + @Descripcion + '%'");
            sqlCommand.AppendLine("UNION");
            sqlCommand.AppendLine("SELECT idSistema,");
            sqlCommand.AppendLine("       Descripcion,");
            sqlCommand.AppendLine("       Version");
            sqlCommand.AppendLine("       Estatus");
            sqlCommand.AppendLine("FROM   SistemaOperativo");
            sqlCommand.AppendLine("WHERE  Version LIKE '%' + @Descripcion + '%'");

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
                bool estatus;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    oSistemaOperativo.idSistema = Convert.ToInt32(dr["idSistema"]);
                    oSistemaOperativo.descripcion = dr["Descripcion"].ToString();
                    oSistemaOperativo.version = dr["Version"].ToString();
                    bool.TryParse(dr["Estatus"].ToString(), out estatus);
                    oSistemaOperativo.estatus = estatus;
                }
            }
            return oSistemaOperativo;
        }

        public List<SistemaOperativo> getSistemaOperativoAll()
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" SELECT 0 AS idSistema ");
            sqlCommand.AppendLine("		, ' ' AS Descripcion ");
            sqlCommand.AppendLine("		, ' ' AS Version ");
            sqlCommand.AppendLine("		, ' ' AS Estatus ");
            sqlCommand.AppendLine(" UNION ");
            sqlCommand.AppendLine(" SELECT	  idSistema ");
            sqlCommand.AppendLine(" 		, Descripcion");
            sqlCommand.AppendLine(" 		, Version");
            sqlCommand.AppendLine(" 		, Estatus");
            sqlCommand.AppendLine(" FROM SistemaOperativo ");
            sqlCommand.AppendLine(" WHERE Estatus = 1 ");
            sqlCommand.AppendLine(" ORDER BY Descripcion ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<SistemaOperativo> lstSistemaOperativo = new List<SistemaOperativo>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    bool estatus;

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        SistemaOperativo oSistemaOperativo = new SistemaOperativo();
                        oSistemaOperativo.idSistema = Convert.ToInt32(dr["idSistema"]);
                        oSistemaOperativo.descripcion = dr["Descripcion"].ToString();
                        oSistemaOperativo.version = dr["Version"].ToString();
                        bool.TryParse(dr["Estatus"].ToString(), out estatus);
                        oSistemaOperativo.estatus = estatus;
                        lstSistemaOperativo.Add(oSistemaOperativo);
                    }
                }
                return lstSistemaOperativo;
            }
            catch (DataException ex)
            {

                throw ex;
            }
        }

        public void InsertSistemaOperativo(ref SistemaOperativo oSistemaOperativo)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_SistemaOperativo");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pDescripcion", DbType.String, oSistemaOperativo.descripcion);
            db.AddInParameter(dbCommand, "@pVersion", DbType.String, oSistemaOperativo.version);
            db.AddInParameter(dbCommand, "@pEstatus", DbType.Boolean, oSistemaOperativo.estatus);
            db.AddOutParameter(dbCommand, "@pidSistema", DbType.Int64, 4);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                oSistemaOperativo.idSistema = Convert.ToInt32(db.GetParameterValue(dbCommand, "@pidSistema"));
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void UpdateSistemaOperativo(ref SistemaOperativo oSistemaOperativo)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("UPDATE SistemaOperativo ");
            sqlCommand.AppendLine("SET Descripcion = @pDescripcion ");
            sqlCommand.AppendLine("  , Estatus  = @pEstatus ");
            sqlCommand.AppendLine("  , Version  = @pVersion ");
            sqlCommand.AppendLine("WHERE idSistema = @pidSistema");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pDescripcion", DbType.String, oSistemaOperativo.descripcion);
            db.AddInParameter(dbCommand, "@pEstatus", DbType.Boolean, oSistemaOperativo.estatus == true ? 1 : 0);
            db.AddInParameter(dbCommand, "@pVersion", DbType.String, oSistemaOperativo.version);
            db.AddInParameter(dbCommand, "@pidSistema", DbType.Int32, oSistemaOperativo.idSistema);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public int CountArticuloSistemaOperativo(int idSistema)
        {
            int total = 0;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" SELECT  ");
            sqlCommand.AppendLine(" 	COUNT(idItem) ");
            sqlCommand.AppendLine(" FROM Articulo ");
            sqlCommand.AppendLine(" WHERE idSistema = @pidSistema ");

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pidSistema", DbType.Int32, idSistema);

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

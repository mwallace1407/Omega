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
    public class DLParametro
    {
        public DLParametro()
        {

        }

        public Parametro getParaemetrobyID(int Par_ID)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DataSet ds = new DataSet();
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpS_ObtieneParametroporID");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pPar_ID", DbType.Int32);
            Parametro objParametro = new Parametro();
            try
            {
                ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        objParametro.par_ID = Convert.ToInt32(dr["Par_ID"]);
                        objParametro.par_Descripcion = dr["Par_Descripcion"].ToString();
                        objParametro.par_Valor = dr["Par_Valor"].ToString();

                    }
                }
                return objParametro;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public Parametro getParaemetrobyDescripcion(string Par_Descripcion)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DataSet ds = new DataSet();
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpS_ObtieneParametroporDescripcion");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pPar_Descripcion", DbType.String);
            Parametro objParametro = new Parametro();
            try
            {
                ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        objParametro.par_ID = Convert.ToInt32(dr["Par_ID"]);
                        objParametro.par_Descripcion = dr["Par_Descripcion"].ToString();
                        objParametro.par_Valor = dr["Par_Valor"].ToString();
                    }
                }
                return objParametro;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }
        public List<Parametro> getParaemetrobyDescripcionLike(string Par_Descripcion)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DataSet ds = new DataSet();
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpS_ObtieneParametroporDescripcionLike");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pPar_Descripcion", DbType.String, Par_Descripcion);
            List<Parametro> objParametros = new List<Parametro>();
            Parametro objParametro = null;
            try
            {
                ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        objParametro = new Parametro();
                        objParametro.par_ID = Convert.ToInt32(dr["Par_ID"]);
                        objParametro.par_Descripcion = dr["Par_Descripcion"].ToString();
                        objParametro.par_Valor = dr["Par_Valor"].ToString();
                        objParametros.Add(objParametro);

                    }
                }
                return objParametros;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }
    }
}

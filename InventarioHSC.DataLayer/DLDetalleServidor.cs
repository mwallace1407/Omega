using System;
using System.Data;
using System.Data.Common;
using System.Text;
using InventarioHSC.Model;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace InventarioHSC.DataLayer
{
    public class DLDetalleServidor
    {
        public DLDetalleServidor()
        {
        }

        public DetalleServidor getDetalleServidorporID(int idItem)
        {
            DetalleServidor oDetalleServidor = new DetalleServidor();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            DbCommand selectCommand = null;
            sqlCommand.Append("stpS_DetalleServidor");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;
            db.AddInParameter(selectCommand, "@pidItem", DbType.Int32, idItem);

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
                    oDetalleServidor.idItem = Convert.ToInt64(dr["idItem"]);
                    oDetalleServidor.cantidadProcesadores = Convert.ToInt32(dr["CantidadProcesadores"]);
                    oDetalleServidor.tipoProcesador = dr["TipoProcesador"].ToString();
                    oDetalleServidor.cantidadDiscos = Convert.ToInt32(dr["CantidadDiscos"]);
                    oDetalleServidor.capacidadDiscos = dr["CapacidadDiscos"].ToString();
                    oDetalleServidor.nombreServidor = dr["NombreServidor"].ToString();
                    oDetalleServidor.direccionIP = dr["DireccionIP"].ToString();
                }
            }
            return oDetalleServidor;
        }

        public void InsertDetalleServidor(ref DetalleServidor oDetalleServidor)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_DetalleServidor");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pidItem", DbType.Int64, oDetalleServidor.idItem);
            db.AddInParameter(dbCommand, "@piCantidadProcesadores", DbType.Int32, oDetalleServidor.cantidadProcesadores);
            db.AddInParameter(dbCommand, "@pcTipoProcesador", DbType.String, oDetalleServidor.tipoProcesador);
            db.AddInParameter(dbCommand, "@piCantidadDiscos", DbType.Int32, oDetalleServidor.cantidadDiscos);
            db.AddInParameter(dbCommand, "@pcCapacidadDiscos", DbType.String, oDetalleServidor.capacidadDiscos);
            db.AddInParameter(dbCommand, "@pcNombreServidor", DbType.String, oDetalleServidor.nombreServidor);
            db.AddInParameter(dbCommand, "@pcDireccionIP", DbType.String, oDetalleServidor.direccionIP);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void UpdateDetalleServidor(ref DetalleServidor oDetalleServidor)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpU_DetalleServidor");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pidItem", DbType.Int64, oDetalleServidor.idItem);
            db.AddInParameter(dbCommand, "@piCantidadProcesadores", DbType.UInt32, oDetalleServidor.cantidadProcesadores);
            db.AddInParameter(dbCommand, "@pcTipoProcesador", DbType.String, oDetalleServidor.tipoProcesador);
            db.AddInParameter(dbCommand, "@piCantidadDiscos", DbType.Int32, oDetalleServidor.cantidadDiscos);
            db.AddInParameter(dbCommand, "@pcCapacidadDiscos", DbType.String, oDetalleServidor.capacidadDiscos);
            db.AddInParameter(dbCommand, "@pcNombreServidor", DbType.String, oDetalleServidor.nombreServidor);
            db.AddInParameter(dbCommand, "@pcDireccionIP", DbType.String, oDetalleServidor.direccionIP);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }
    }
}
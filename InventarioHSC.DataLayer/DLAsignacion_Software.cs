using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using InventarioHSC.Model;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data.Common;

namespace InventarioHSC.DataLayer
{
    public class DLAsignacion_Software
    {
        public List<Asignacion_Software> getAsignacionSoftwarePorCve_Software(int cve_Software)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  Cve_Asignacion ");
            sqlCommand.AppendLine("		,Serial ");
            sqlCommand.AppendLine("		,Cve_Software ");
            sqlCommand.AppendLine("		,Nombre_Usuario");
            sqlCommand.AppendLine("		,Lenguaje");
            sqlCommand.AppendLine("		,Material");
            sqlCommand.AppendLine("		,Area_Solicita");
            sqlCommand.AppendLine("		,Sucursal");
            sqlCommand.AppendLine("		,Lote_Code");
            sqlCommand.AppendLine("		,Proveedor");
            sqlCommand.AppendLine("		,NoFactura");
            sqlCommand.AppendLine("		,Fecha_Compra");
            sqlCommand.AppendLine("		,NoRequisicion_Compra");
            sqlCommand.AppendLine("		,Centro_Costo");
            sqlCommand.AppendLine("		,Pesos");
            sqlCommand.AppendLine("		,Dolares");
            sqlCommand.AppendLine("		,Incluido_Responsiva");
            sqlCommand.AppendLine("		,Fecha_Vencimiento");
            sqlCommand.AppendLine("		,NoTarjeta");
            sqlCommand.AppendLine("		,Responsiva");
            sqlCommand.AppendLine("		,Observaciones");
            sqlCommand.AppendLine("FROM Asignacion_Software ");
            sqlCommand.AppendLine("where Cve_Software = " + cve_Software);

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {

                throw ex;
            }
            List<Asignacion_Software> lstAsignacionSoftware = new List<Asignacion_Software>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime? value = null;
                int? valueInt = null;
                decimal? valueDecimal = null;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Asignacion_Software oAsignacionSoftware = new Asignacion_Software();
                    oAsignacionSoftware.Cve_Software = Convert.ToInt32(dr["Cve_Software"]);
                    oAsignacionSoftware.Area_Solicita = dr["Area_Solicita"].ToString();
                    oAsignacionSoftware.Centro_Costo = dr["Centro_Costo"].ToString();
                    oAsignacionSoftware.Cve_Asignacion = Convert.ToInt32(dr["Cve_Asignacion"]);
                    oAsignacionSoftware.Dolares = dr["Dolares"] != DBNull.Value ? Convert.ToDecimal(dr["Dolares"]) : valueDecimal;
                    oAsignacionSoftware.Fecha_Compra = dr["Fecha_Compra"] != DBNull.Value ? Convert.ToDateTime(dr["Fecha_Compra"]) : value;
                    oAsignacionSoftware.Fecha_Vencimiento = dr["Fecha_Vencimiento"] != DBNull.Value ? Convert.ToDateTime(dr["Fecha_Vencimiento"]): value;
                    oAsignacionSoftware.Incluido_Responsiva = dr["Incluido_Responsiva"].ToString();
                    oAsignacionSoftware.Key = dr["Serial"].ToString();
                    oAsignacionSoftware.Lenguaje =dr["Lenguaje"].ToString();
                    oAsignacionSoftware.Lote_Code = dr["Lote_Code"].ToString();
                    oAsignacionSoftware.Material = dr["Material"].ToString();
                    oAsignacionSoftware.Nombre_Usuario = dr["Nombre_Usuario"].ToString();
                    oAsignacionSoftware.Numero_Factura = dr["NoFactura"] != DBNull.Value ? Convert.ToInt32(dr["NoFactura"]) : valueInt;
                    oAsignacionSoftware.Numero_Requisicion_Compra = dr["NoRequisicion_Compra"] != DBNull.Value ? Convert.ToInt32(dr["NoRequisicion_Compra"]) : valueInt;
                    oAsignacionSoftware.Numero_Taejeta = dr["NoTarjeta"].ToString();
                    oAsignacionSoftware.Observaciones = dr["Observaciones"].ToString();
                    oAsignacionSoftware.Pesos = dr["Pesos"] != DBNull.Value ? Convert.ToDecimal(dr["Pesos"]) : valueDecimal;
                    oAsignacionSoftware.Proveedor = dr["Proveedor"].ToString();
                    oAsignacionSoftware.Responsiva = dr["Responsiva"].ToString();
                    oAsignacionSoftware.Sucursal = dr["Sucursal"].ToString();
                    lstAsignacionSoftware.Add(oAsignacionSoftware);
                }
            }
            return lstAsignacionSoftware;
        }

        public List<DetalleAsignacionSoftware> getDetalleAsignacionSoftware(string NombreUsuario)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("select  ");
            sqlCommand.AppendLine("t1.Cve_Asignacion  ");
            sqlCommand.AppendLine("		,t2.Descripcion ");
            sqlCommand.AppendLine("		,t2.Version ");
            sqlCommand.AppendLine("		,t1.Serial ");
            sqlCommand.AppendLine("		,t1.Area_Solicita ");
            sqlCommand.AppendLine("from dbo.Asignacion_Software t1");
            sqlCommand.AppendLine("inner join Software t2 on t1.Cve_Software = t2.Cve_Software");
            sqlCommand.AppendLine("where Nombre_Usuario  = '" + NombreUsuario + "'");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
            List<DetalleAsignacionSoftware> lstDetalleAsignacionSoftware = new List<DetalleAsignacionSoftware>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DetalleAsignacionSoftware oDetelleAsignacionSoftware = new DetalleAsignacionSoftware();
                    oDetelleAsignacionSoftware.Cve_Asignacion = Convert.ToInt32(dr["Cve_Asignacion"].ToString());
                    oDetelleAsignacionSoftware.Descripcion = dr["Descripcion"].ToString();
                    oDetelleAsignacionSoftware.Version = dr["Version"].ToString();
                    oDetelleAsignacionSoftware.Serial = dr["Serial"].ToString();
                    oDetelleAsignacionSoftware.Area_Solicita = dr["Area_Solicita"].ToString();
                    lstDetalleAsignacionSoftware.Add(oDetelleAsignacionSoftware);
                }
            }
            return lstDetalleAsignacionSoftware;
        }

        public Asignacion_Software getAsignacionSofware(int cve_Asignacion)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  Cve_Asignacion ");
            sqlCommand.AppendLine("		,Serial ");
            sqlCommand.AppendLine("		,Cve_Software ");
            sqlCommand.AppendLine("		,Nombre_Usuario");
            sqlCommand.AppendLine("		,Lenguaje");
            sqlCommand.AppendLine("		,Material");
            sqlCommand.AppendLine("		,Area_Solicita");
            sqlCommand.AppendLine("		,Sucursal");
            sqlCommand.AppendLine("		,Lote_Code");
            sqlCommand.AppendLine("		,Proveedor");
            sqlCommand.AppendLine("		,NoFactura");
            sqlCommand.AppendLine("		,Fecha_Compra");
            sqlCommand.AppendLine("		,NoRequisicion_Compra");
            sqlCommand.AppendLine("		,Centro_Costo");
            sqlCommand.AppendLine("		,Pesos");
            sqlCommand.AppendLine("		,Dolares");
            sqlCommand.AppendLine("		,Incluido_Responsiva");
            sqlCommand.AppendLine("		,Fecha_Vencimiento");
            sqlCommand.AppendLine("		,NoTarjeta");
            sqlCommand.AppendLine("		,Responsiva");
            sqlCommand.AppendLine("		,Observaciones");
            sqlCommand.AppendLine("FROM Asignacion_Software ");
            sqlCommand.AppendLine("where Cve_Asignacion = " + cve_Asignacion);

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {

                throw ex;
            }

            Asignacion_Software oAsignacionSoftware = new Asignacion_Software();
            DateTime? value = null;
            int? valueInt = null;
            decimal? valueDecimal = null;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                oAsignacionSoftware.Cve_Software = Convert.ToInt32(dr["Cve_Software"]);
                oAsignacionSoftware.Area_Solicita = dr["Area_Solicita"].ToString();
                oAsignacionSoftware.Centro_Costo = dr["Centro_Costo"].ToString();
                oAsignacionSoftware.Cve_Asignacion = Convert.ToInt32(dr["Cve_Asignacion"]);
                oAsignacionSoftware.Dolares = dr["Dolares"] != DBNull.Value ? Convert.ToDecimal(dr["Dolares"]) : valueDecimal;
                oAsignacionSoftware.Fecha_Compra = dr["Fecha_Compra"] != DBNull.Value ? Convert.ToDateTime(dr["Fecha_Compra"]) : value;
                oAsignacionSoftware.Fecha_Vencimiento = dr["Fecha_Vencimiento"] != DBNull.Value ? Convert.ToDateTime(dr["Fecha_Vencimiento"]) : value;
                oAsignacionSoftware.Incluido_Responsiva = dr["Incluido_Responsiva"].ToString();
                oAsignacionSoftware.Key = dr["Serial"].ToString();
                oAsignacionSoftware.Lenguaje = dr["Lenguaje"].ToString();
                oAsignacionSoftware.Lote_Code = dr["Lote_Code"].ToString();
                oAsignacionSoftware.Material = dr["Material"].ToString();
                oAsignacionSoftware.Nombre_Usuario = dr["Nombre_Usuario"].ToString();
                oAsignacionSoftware.Numero_Factura = dr["NoFactura"] != DBNull.Value ? Convert.ToInt32(dr["NoFactura"]) : valueInt;
                oAsignacionSoftware.Numero_Requisicion_Compra = dr["NoRequisicion_Compra"] != DBNull.Value ? Convert.ToInt32(dr["NoRequisicion_Compra"]) : valueInt;
                oAsignacionSoftware.Numero_Taejeta = dr["NoTarjeta"].ToString();
                oAsignacionSoftware.Observaciones = dr["Observaciones"].ToString();
                oAsignacionSoftware.Pesos = dr["Pesos"] != DBNull.Value ? Convert.ToDecimal(dr["Pesos"]) : valueDecimal;
                oAsignacionSoftware.Proveedor = dr["Proveedor"].ToString();
                oAsignacionSoftware.Responsiva = dr["Responsiva"].ToString();
                oAsignacionSoftware.Sucursal = dr["Sucursal"].ToString();
            }

            return oAsignacionSoftware;
        }

        public void InsertaAsignacion_software(ref Asignacion_Software oAsignacionArticulo)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_AsignacionSofware");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@Cve_Software", DbType.String, oAsignacionArticulo.Cve_Software);
            db.AddInParameter(dbCommand, "@Nombre_Usuario", DbType.String, oAsignacionArticulo.Nombre_Usuario);
            db.AddInParameter(dbCommand, "@Serial", DbType.String, oAsignacionArticulo.Key);
            db.AddInParameter(dbCommand, "@Lenguaje", DbType.String, oAsignacionArticulo.Lenguaje);
            db.AddInParameter(dbCommand, "@Material", DbType.String, oAsignacionArticulo.Material);
            db.AddInParameter(dbCommand, "@Area_Solicita", DbType.String, oAsignacionArticulo.Area_Solicita);
            db.AddInParameter(dbCommand, "@Sucursal", DbType.String, oAsignacionArticulo.Sucursal);
            db.AddInParameter(dbCommand, "@Lote_Code", DbType.String, oAsignacionArticulo.Lote_Code);
            db.AddInParameter(dbCommand, "@Proveedor", DbType.String, oAsignacionArticulo.Proveedor);
            db.AddInParameter(dbCommand, "@NoFactura", DbType.Int32, oAsignacionArticulo.Numero_Factura);
            db.AddInParameter(dbCommand, "@Fecha_Compra", DbType.String, oAsignacionArticulo.Fecha_Compra);
            db.AddInParameter(dbCommand, "@NoRequisicion_Compra", DbType.String, oAsignacionArticulo.Numero_Requisicion_Compra);
            db.AddInParameter(dbCommand, "@Centro_Costo", DbType.String, oAsignacionArticulo.Centro_Costo);
            db.AddInParameter(dbCommand, "@Pesos", DbType.Decimal, oAsignacionArticulo.Pesos);
            db.AddInParameter(dbCommand, "@Dolares", DbType.Decimal, oAsignacionArticulo.Dolares);
            db.AddInParameter(dbCommand, "@Incluido_Responsiva", DbType.String, oAsignacionArticulo.Incluido_Responsiva);
            db.AddInParameter(dbCommand, "@Fecha_Vencimiento", DbType.String, oAsignacionArticulo.Fecha_Vencimiento);
            db.AddInParameter(dbCommand, "@NoTarjeta", DbType.String, oAsignacionArticulo.Numero_Taejeta);
            db.AddInParameter(dbCommand, "@Responsiva", DbType.String, oAsignacionArticulo.Responsiva);
            db.AddInParameter(dbCommand, "@Observaciones", DbType.String, oAsignacionArticulo.Observaciones);

            db.AddOutParameter(dbCommand, "@Cve_Asignacion", DbType.Int32, 4);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                oAsignacionArticulo.Cve_Asignacion = Convert.ToInt32(db.GetParameterValue(dbCommand, "@Cve_Asignacion"));
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public List<string> ObtenAreaAsignar()
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("select distinct Area_Solicita from Asignacion_Software ");
            sqlCommand.AppendLine("		  where Area_Solicita is not null ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {

                throw ex;
            }

            List<string> oAsignacionSoftware = new List<string>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                oAsignacionSoftware.Add(dr["Area_Solicita"].ToString());
            }

            return oAsignacionSoftware;
        }

        public void ActualizaAsignacion_software(Asignacion_Software oAsignacionArticulo)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpU_AsignacionSoftware");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@Cve_Asignacion", DbType.Int32, oAsignacionArticulo.Cve_Asignacion);
            db.AddInParameter(dbCommand, "@Cve_Software ", DbType.Int32, oAsignacionArticulo.Cve_Software);
            db.AddInParameter(dbCommand, "@Nombre_Usuario", DbType.String, oAsignacionArticulo.Nombre_Usuario);
            db.AddInParameter(dbCommand, "@Serial", DbType.String, oAsignacionArticulo.Key);
            db.AddInParameter(dbCommand, "@Lenguaje", DbType.String, oAsignacionArticulo.Lenguaje);
            db.AddInParameter(dbCommand, "@Material", DbType.String, oAsignacionArticulo.Material);
            db.AddInParameter(dbCommand, "@Area_Solicita", DbType.String, oAsignacionArticulo.Area_Solicita);
            db.AddInParameter(dbCommand, "@Sucursal", DbType.String, oAsignacionArticulo.Sucursal);
            db.AddInParameter(dbCommand, "@Lote_Code", DbType.String, oAsignacionArticulo.Lote_Code);
            db.AddInParameter(dbCommand, "@Proveedor", DbType.String, oAsignacionArticulo.Proveedor);
            db.AddInParameter(dbCommand, "@NoFactura", DbType.Int32, oAsignacionArticulo.Numero_Factura);
            db.AddInParameter(dbCommand, "@Fecha_Compra", DbType.String, oAsignacionArticulo.Fecha_Compra.HasValue ? oAsignacionArticulo.Fecha_Compra.Value.ToString("yyyy-MM-dd") : null);
            db.AddInParameter(dbCommand, "@NoRequisicion_Compra", DbType.String, oAsignacionArticulo.Numero_Requisicion_Compra);
            db.AddInParameter(dbCommand, "@Centro_Costo", DbType.String, oAsignacionArticulo.Centro_Costo);
            db.AddInParameter(dbCommand, "@Pesos", DbType.Decimal, oAsignacionArticulo.Pesos);
            db.AddInParameter(dbCommand, "@Dolares", DbType.Decimal, oAsignacionArticulo.Dolares);
            db.AddInParameter(dbCommand, "@Incluido_Responsiva", DbType.String, oAsignacionArticulo.Incluido_Responsiva);
            db.AddInParameter(dbCommand, "@Fecha_Vencimiento", DbType.String, oAsignacionArticulo.Fecha_Vencimiento.HasValue ? oAsignacionArticulo.Fecha_Vencimiento.Value.ToString("yyyy-MM-dd") : null);
            db.AddInParameter(dbCommand, "@NoTarjeta", DbType.String, oAsignacionArticulo.Numero_Taejeta);
            db.AddInParameter(dbCommand, "@Responsiva", DbType.String, oAsignacionArticulo.Responsiva);
            db.AddInParameter(dbCommand, "@Observaciones", DbType.String, oAsignacionArticulo.Observaciones);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public List<Asignacion_Software> UsuariosConAsignacionSoftware()
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT distinct ");
            sqlCommand.AppendLine("		Nombre_Usuario");
            sqlCommand.AppendLine("FROM Asignacion_Software ");
            sqlCommand.AppendLine(" where Nombre_Usuario <> 'Disponible'");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {

                throw ex;
            }
            List<Asignacion_Software> lstAsignacionSoftware = new List<Asignacion_Software>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Asignacion_Software oAsignacionSoftware = new Asignacion_Software();
                    oAsignacionSoftware.Nombre_Usuario = dr["Nombre_Usuario"].ToString();
                    lstAsignacionSoftware.Add(oAsignacionSoftware);
                }
            }
            return lstAsignacionSoftware;
        }
    }
}

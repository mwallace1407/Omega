using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using InventarioHSC.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data.SqlClient;

namespace InventarioHSC.DataLayer
{
    public class DLArticulo
    {
        public DLArticulo()
        {

        }

        #region Consultas

        public Articulo getArticulobyID(Int64 idItem)
        {
            Articulo oArticulo = new Articulo();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  t1.idItem ");
            sqlCommand.AppendLine("		, t1.NoSerie ");
            sqlCommand.AppendLine("		, t1.idTipoEquipo ");
            sqlCommand.AppendLine("		, t1.idMarca ");
            sqlCommand.AppendLine("		, t1.Modelo ");
            sqlCommand.AppendLine("		, t1.Procesador ");
            sqlCommand.AppendLine("		, t1.RAM ");
            sqlCommand.AppendLine("		, t1.DiscoDuro ");
            sqlCommand.AppendLine("		, t1.idSistema ");
            sqlCommand.AppendLine("		, t1.idProveedor ");
            sqlCommand.AppendLine("		, t1.Factura ");
            sqlCommand.AppendLine("		, t1.FechaCompra ");
            sqlCommand.AppendLine("		, t1.Requisicion ");
            sqlCommand.AppendLine("		, t1.CentroCostosAdquisicion ");
            sqlCommand.AppendLine("		, t1.Responsiva ");
            sqlCommand.AppendLine("		, t1.ValorPesos");
            sqlCommand.AppendLine("		, t1.ValorUSD");
            sqlCommand.AppendLine("		, t1.Stock ");
            sqlCommand.AppendLine("		, t1.CodigoCastor ");
            sqlCommand.AppendLine("		, t1.idUsuario ");
            sqlCommand.AppendLine("		, t1.idUbicacion ");
            sqlCommand.AppendLine("		, t1.idEstado ");
            sqlCommand.AppendLine("		, t1.Observacion1 ");
            sqlCommand.AppendLine("		, t1.Observacion2 ");
            sqlCommand.AppendLine("		, t1.Observacion3 ");
            sqlCommand.AppendLine("		, ISNULL(0, t1.PosibleFaltanteFlag) AS PosibleFaltanteFlag ");
            sqlCommand.AppendLine("		, t1.CambioRYS ");
            sqlCommand.AppendLine("		, t1.FechaMovimiento");
            sqlCommand.AppendLine("		, t2.Descripcion as TipoEquipo ");
            sqlCommand.AppendLine("		, t3.Descripcion as Marca ");
            sqlCommand.AppendLine("		, t4.Descripcion as Ubicacion ");
            sqlCommand.AppendLine("		, t1.idUsuarioAnterior ");
            sqlCommand.AppendLine("		, t1.ResponsivaAnterior ");
            sqlCommand.AppendLine("FROM Articulo t1");
            sqlCommand.AppendLine("inner join TipoEquipo t2 on t1.idTipoEquipo = t2.idTipoEquipo ");
            sqlCommand.AppendLine("inner join Marca t3 on t1.idMarca = t3.idMarca ");
            sqlCommand.AppendLine("inner join Ubicacion t4 on t1.idUbicacion = t4.idUbicacion ");
            sqlCommand.AppendLine("WHERE idItem = @idItem ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idItem", DbType.Int64, idItem);

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
                    int? respo = null;
                    oArticulo.idItem = Convert.ToInt64(dr["idItem"]);
                    oArticulo.noSerie = dr["NoSerie"].ToString();
                    oArticulo.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                    oArticulo.idMarca = Convert.ToInt32(dr["idMarca"]);
                    oArticulo.modelo = dr["Modelo"].ToString();
                    //oArticulo.procesador = dr["Procesador"].ToString();
                    //oArticulo.ram = dr["RAM"].ToString();
                    //oArticulo.discoDuro = dr["DiscoDuro"].ToString();
                    //oArticulo.idSistema = Convert.ToInt32(dr["idSistema"]);
                    //oArticulo.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                    //oArticulo.factura = dr["Factura"].ToString();
                    //oArticulo.fechaCompra = dr["FechaCompra"].ToString();
                    //oArticulo.requisicion = dr["Requisicion"].ToString();
                    //oArticulo.centroCostosAdquisicion = dr["CentroCostosAdquisicion"].ToString();
                    oArticulo.responsiva = dr["Responsiva"] == DBNull.Value ? respo : Convert.ToInt32(dr["Responsiva"]);
                    //oArticulo.valorPesos = Convert.ToDouble(dr["ValorPesos"]);
                    //oArticulo.valorUSD = Convert.ToDouble(dr["ValorUSD"]);
                    //oArticulo.stock = dr["Stock"].ToString();
                    //oArticulo.codigoCastor = dr["CodigoCastor"].ToString();
                    oArticulo.idUsuario = dr["idUsuario"] == DBNull.Value ? respo : Convert.ToInt32(dr["idUsuario"]);
                    oArticulo.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                    oArticulo.idEstado = Convert.ToInt32(dr["idEstado"]);
                    oArticulo.observacion1 = dr["Observacion1"].ToString();
                    oArticulo.observacion2 = dr["Observacion2"].ToString();
                    oArticulo.observacion3 = dr["Observacion3"].ToString();
                    //oArticulo.posibleFaltanteFlag = Convert.ToBoolean(dr["PosibleFaltanteFlag"]);
                    oArticulo.cambioRYS = dr["CambioRYS"].ToString();
                    oArticulo.TipoEquipo = dr["TipoEquipo"].ToString();
                    oArticulo.Marca = dr["Marca"].ToString();
                    oArticulo.Ubicacion = dr["Ubicacion"].ToString();
                    oArticulo.IdUsuarioAnterior = dr["idUsuarioAnterior"] == DBNull.Value ? 
                        respo : Convert.ToInt32(dr["idUsuarioAnterior"]);
                    oArticulo.ResponsivaAnterior = dr["ResponsivaAnterior"].ToString();

                    if (dr["FechaMovimiento"] != DBNull.Value)
                        oArticulo.fechaMovimiento = Convert.ToDateTime(dr["FechaMovimiento"]);
                }
            }
            return oArticulo;
        }

        public Articulo getArticulobySerie(string noSerie)
        {
            Articulo oArticulo = new Articulo();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  idItem ");
            sqlCommand.AppendLine("		, NoSerie ");
            sqlCommand.AppendLine("		, idTipoEquipo ");
            sqlCommand.AppendLine("		, idMarca ");
            sqlCommand.AppendLine("		, Modelo ");
            sqlCommand.AppendLine("		, Procesador ");
            sqlCommand.AppendLine("		, RAM ");
            sqlCommand.AppendLine("		, DiscoDuro ");
            sqlCommand.AppendLine("		, idSistema ");
            sqlCommand.AppendLine("		, idProveedor ");
            sqlCommand.AppendLine("		, Factura ");
            sqlCommand.AppendLine("		, FechaCompra ");
            sqlCommand.AppendLine("		, Requisicion ");
            sqlCommand.AppendLine("		, CentroCostosAdquisicion ");
            sqlCommand.AppendLine("		, Responsiva ");
            sqlCommand.AppendLine("		, ValorPesos");
            sqlCommand.AppendLine("		, ValorUSD");
            sqlCommand.AppendLine("		, Stock ");
            sqlCommand.AppendLine("		, CodigoCastor ");
            sqlCommand.AppendLine("		, idUsuario ");
            sqlCommand.AppendLine("		, idUbicacion ");
            sqlCommand.AppendLine("		, idEstado ");
            sqlCommand.AppendLine("		, Observacion1 ");
            sqlCommand.AppendLine("		, Observacion2 ");
            sqlCommand.AppendLine("		, Observacion3 ");
            sqlCommand.AppendLine("		, ISNULL(0, PosibleFaltanteFlag) AS PosibleFaltanteFlag ");
            sqlCommand.AppendLine("		, CambioRYS ");
            sqlCommand.AppendLine("		, FechaMovimiento");
            sqlCommand.AppendLine("		, idUsuarioAnterior ");
            sqlCommand.AppendLine("		, ResponsivaAnterior ");
            sqlCommand.AppendLine("FROM Articulo ");
            sqlCommand.AppendLine("WHERE NoSerie = @NoSerie ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@NoSerie", DbType.String, noSerie);

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
                int? respo = null;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    oArticulo.idItem = Convert.ToInt64(dr["idItem"]);
                    oArticulo.noSerie = dr["NoSerie"].ToString();
                    oArticulo.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                    oArticulo.idMarca = Convert.ToInt32(dr["idMarca"]);
                    oArticulo.modelo = dr["Modelo"].ToString();
                    //oArticulo.procesador = dr["Procesador"].ToString();
                    //oArticulo.ram = dr["RAM"].ToString();
                    //oArticulo.discoDuro = dr["DiscoDuro"].ToString();
                    //oArticulo.idSistema = Convert.ToInt32(dr["idSistema"]);
                    //oArticulo.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                    //oArticulo.factura = dr["Factura"].ToString();
                    //oArticulo.fechaCompra = dr["FechaCompra"].ToString();
                    //oArticulo.requisicion = dr["Requisicion"].ToString();
                    //oArticulo.centroCostosAdquisicion = dr["CentroCostosAdquisicion"].ToString();
                    oArticulo.responsiva = dr["Responsiva"] == DBNull.Value ? respo : Convert.ToInt32(dr["Responsiva"]);
                    //oArticulo.valorPesos = Convert.ToDouble(dr["ValorPesos"]);
                    //oArticulo.valorUSD = Convert.ToDouble(dr["ValorUSD"]);
                    //oArticulo.stock = dr["Stock"].ToString();
                    //oArticulo.codigoCastor = dr["CodigoCastor"].ToString();
                    oArticulo.idUsuario = dr["idUsuario"] == DBNull.Value ? 1186 : Convert.ToInt32(dr["idUsuario"]);
                    oArticulo.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                    oArticulo.idEstado = Convert.ToInt32(dr["idEstado"]);
                    oArticulo.observacion1 = dr["Observacion1"].ToString();
                    oArticulo.observacion2 = dr["Observacion2"].ToString();
                    oArticulo.observacion3 = dr["Observacion3"].ToString();
                    //oArticulo.posibleFaltanteFlag = Convert.ToBoolean(dr["PosibleFaltanteFlag"]);
                    oArticulo.cambioRYS = dr["CambioRYS"].ToString();

                    if (dr["FechaMovimiento"] != DBNull.Value)
                        oArticulo.fechaMovimiento = Convert.ToDateTime(dr["FechaMovimiento"]);

                    oArticulo.IdUsuarioAnterior = dr["idUsuarioAnterior"] == DBNull.Value ?
                                           respo : Convert.ToInt32(dr["idUsuarioAnterior"]);
                    oArticulo.ResponsivaAnterior = dr["ResponsivaAnterior"].ToString();
                }
            }
            return oArticulo;
        }

        public List<Articulo> getFiltroArticulo(int idTipoEquipo = 0, int idMarca = 0, int idUbicacion = 0, string Modelo = "", string NoSerie = "FALTANOSERIE"
            , bool SinNumeroSerie = false, bool Ilegible = false)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  t1.idItem ");
            sqlCommand.AppendLine("		, t1.NoSerie ");
            sqlCommand.AppendLine("		, t1.idTipoEquipo ");
            sqlCommand.AppendLine("		, t1.idMarca ");
            sqlCommand.AppendLine("		, t1.Modelo ");
            sqlCommand.AppendLine("		, t1.Procesador ");
            sqlCommand.AppendLine("		, t1.RAM ");
            sqlCommand.AppendLine("		, t1.DiscoDuro ");
            sqlCommand.AppendLine("		, t1.idSistema ");
            sqlCommand.AppendLine("		, t1.idProveedor ");
            sqlCommand.AppendLine("		, t1.Factura ");
            sqlCommand.AppendLine("		, t1.FechaCompra ");
            sqlCommand.AppendLine("		, t1.Requisicion ");
            sqlCommand.AppendLine("		, t1.CentroCostosAdquisicion ");
            sqlCommand.AppendLine("		, t1.Responsiva");
            sqlCommand.AppendLine("		, t1.ValorPesos");
            sqlCommand.AppendLine("		, t1.ValorUSD");
            sqlCommand.AppendLine("		, t1.Stock ");
            sqlCommand.AppendLine("		, t1.CodigoCastor ");
            sqlCommand.AppendLine("		, t1.idUsuario ");
            sqlCommand.AppendLine("		, t1.idUbicacion ");
            sqlCommand.AppendLine("		, t1.idEstado ");
            sqlCommand.AppendLine("		, t1.Observacion1 ");
            sqlCommand.AppendLine("		, t1.Observacion2 ");
            sqlCommand.AppendLine("		, t1.Observacion3 ");
            sqlCommand.AppendLine("		, ISNULL(0, t1.PosibleFaltanteFlag) AS PosibleFaltanteFlag ");
            sqlCommand.AppendLine("		, t1.CambioRYS ");
            sqlCommand.AppendLine("		, t1.FechaMovimiento");
            sqlCommand.AppendLine("		, t2.Descripcion as TipoEquipo ");
            sqlCommand.AppendLine("		, t3.Descripcion as Marca ");
            sqlCommand.AppendLine("		, t4.Descripcion as Ubicacion ");
            sqlCommand.AppendLine("		, t1.idUsuarioAnterior ");
            sqlCommand.AppendLine("		, t1.ResponsivaAnterior ");
            sqlCommand.AppendLine("FROM Articulo t1");
            sqlCommand.AppendLine("inner join TipoEquipo t2 on t1.idTipoEquipo = t2.idTipoEquipo ");
            sqlCommand.AppendLine("inner join Marca t3 on t1.idMarca = t3.idMarca ");
            sqlCommand.AppendLine("inner join Ubicacion t4 on t1.idUbicacion = t4.idUbicacion and t4.Estatus = 1");
            sqlCommand.AppendLine("where (t1.Responsiva = 5000) ");
            sqlCommand.AppendLine("and t1.idEstado IN (1, 3) ");
            sqlCommand.AppendLine("and t1.idUbicacion <> 71 "); //Excluir equipos en venta

            if (idTipoEquipo != 0)
                sqlCommand.AppendLine("and t1.idTipoEquipo = @idTipoEquipo");

            if (idMarca != 0)
                sqlCommand.AppendLine("and t1.idMarca = @idMarca");

            if (idUbicacion != 0)
                sqlCommand.AppendLine("and t1.idUbicacion = @idUbicacion");

            if (!string.IsNullOrEmpty(Modelo.Trim()))
                sqlCommand.AppendLine("and t1.Modelo like '%" + Modelo + "%'");

            string Consulta = sqlCommand.ToString();

            if (NoSerie != "")
                sqlCommand.AppendLine("and t1.NoSerie like '%" + NoSerie + "%'");
            else
            {
                sqlCommand.AppendLine("and t1.NoSerie <> 'S/N'");
                sqlCommand.AppendLine("and t1.NoSerie <> 'ILEGIBLE'");
            }

            if (SinNumeroSerie)
            {
                sqlCommand.AppendLine("union");
                sqlCommand.Append(Consulta);
                sqlCommand.Append("and t1.NoSerie = 'S/N'");
            }

            if(Ilegible)
            {
                sqlCommand.AppendLine("union");
                sqlCommand.Append(Consulta);
                sqlCommand.Append("and t1.NoSerie = 'ILEGIBLE'");
            }

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            
            if (idTipoEquipo != 0)
                db.AddInParameter(selectCommand, "@idTipoEquipo", DbType.Int32, idTipoEquipo);

            if (idMarca != 0)
                db.AddInParameter(selectCommand, "@idMarca", DbType.Int32, idMarca);

            if (idUbicacion != 0)
                db.AddInParameter(selectCommand, "@idUbicacion", DbType.Int32, idUbicacion);

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
            List<Articulo> lstArticulo = new List<Articulo>();

            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int? respo = null;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Articulo oArticulo = new Articulo();
                        oArticulo.idItem = Convert.ToInt64(dr["idItem"]);
                        oArticulo.noSerie = dr["NoSerie"].ToString();
                        oArticulo.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                        oArticulo.idMarca = Convert.ToInt32(dr["idMarca"]);
                        oArticulo.modelo = dr["Modelo"].ToString();
                        //oArticulo.procesador = dr["Procesador"].ToString();
                        //oArticulo.ram = dr["RAM"].ToString();
                        //oArticulo.discoDuro = dr["DiscoDuro"].ToString();
                        //oArticulo.idSistema = Convert.ToInt32(dr["idSistema"]);
                        //oArticulo.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                        //oArticulo.factura = dr["Factura"].ToString();
                        //oArticulo.fechaCompra = dr["FechaCompra"].ToString();
                        //oArticulo.requisicion = dr["Requisicion"].ToString();
                        //oArticulo.centroCostosAdquisicion = dr["CentroCostosAdquisicion"].ToString();
                        oArticulo.responsiva = dr["Responsiva"] == DBNull.Value ? respo : Convert.ToInt32(dr["Responsiva"]);
                        //oArticulo.valorPesos = Convert.ToDouble(dr["ValorPesos"]);
                        //oArticulo.valorUSD = Convert.ToDouble(dr["ValorUSD"]);
                        //oArticulo.stock = dr["Stock"].ToString();
                        //oArticulo.codigoCastor = dr["CodigoCastor"].ToString();
                        oArticulo.idUsuario = dr["idUsuario"] == DBNull.Value ? 1186 : Convert.ToInt32(dr["idUsuario"]);
                        oArticulo.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                        oArticulo.idEstado = Convert.ToInt32(dr["idEstado"]);
                        oArticulo.observacion1 = dr["Observacion1"].ToString();
                        oArticulo.observacion2 = dr["Observacion2"].ToString();
                        oArticulo.observacion3 = dr["Observacion3"].ToString();
                        //oArticulo.posibleFaltanteFlag = Convert.ToBoolean(dr["PosibleFaltanteFlag"]);
                        oArticulo.cambioRYS = dr["CambioRYS"].ToString();
                        oArticulo.TipoEquipo = dr["TipoEquipo"].ToString();
                        oArticulo.Marca = dr["Marca"].ToString();
                        oArticulo.Ubicacion = dr["Ubicacion"].ToString();

                        if (dr["FechaMovimiento"] != DBNull.Value)
                            oArticulo.fechaMovimiento = Convert.ToDateTime(dr["FechaMovimiento"]);

                        oArticulo.IdUsuarioAnterior = dr["idUsuarioAnterior"] == DBNull.Value ?
                        respo : Convert.ToInt32(dr["idUsuarioAnterior"]);


                        oArticulo.ResponsivaAnterior = dr["ResponsivaAnterior"].ToString();

                        lstArticulo.Add(oArticulo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstArticulo;
        }

        public List<Articulo> getArticuloAll()
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  idItem ");
            sqlCommand.AppendLine("		, NoSerie ");
            sqlCommand.AppendLine("		, idTipoEquipo ");
            sqlCommand.AppendLine("		, idMarca ");
            sqlCommand.AppendLine("		, Modelo ");
            sqlCommand.AppendLine("		, Procesador ");
            sqlCommand.AppendLine("		, RAM ");
            sqlCommand.AppendLine("		, DiscoDuro ");
            sqlCommand.AppendLine("		, idSistema ");
            sqlCommand.AppendLine("		, idProveedor ");
            sqlCommand.AppendLine("		, Factura ");
            sqlCommand.AppendLine("		, FechaCompra ");
            sqlCommand.AppendLine("		, Requisicion ");
            sqlCommand.AppendLine("		, CentroCostosAdquisicion ");
            sqlCommand.AppendLine("		, Responsiva ");
            sqlCommand.AppendLine("		, ISNULL('0', ValorPesos) AS ValorPesos ");
            sqlCommand.AppendLine("		, ISNULL('0', ValorUSD) AS ValorUSD ");
            sqlCommand.AppendLine("		, Stock ");
            sqlCommand.AppendLine("		, CodigoCastor ");
            sqlCommand.AppendLine("		, idUsuario ");
            sqlCommand.AppendLine("		, idUbicacion ");
            sqlCommand.AppendLine("		, idEstado ");
            sqlCommand.AppendLine("		, Observacion1 ");
            sqlCommand.AppendLine("		, Observacion2 ");
            sqlCommand.AppendLine("		, Observacion3 ");
            sqlCommand.AppendLine("		, ISNULL(0, PosibleFaltanteFlag) AS PosibleFaltanteFlag ");
            sqlCommand.AppendLine("		, CambioRYS ");
            sqlCommand.AppendLine("		, isnull('01/01/1900', FechaMovimiento) AS FechaMovimiento ");
            sqlCommand.AppendLine("FROM Articulo ");

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
            List<Articulo> lstArticulo = new List<Articulo>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                int? respo = null;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Articulo oArticulo = new Articulo();
                    oArticulo.idItem = Convert.ToInt64(dr["idItem"]);
                    oArticulo.noSerie = dr["NoSerie"].ToString();
                    oArticulo.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                    oArticulo.idMarca = Convert.ToInt32(dr["idMarca"]);
                    oArticulo.modelo = dr["Modelo"].ToString();
                    oArticulo.procesador = dr["Procesador"].ToString();
                    oArticulo.ram = dr["RAM"].ToString();
                    oArticulo.discoDuro = dr["DiscoDuro"].ToString();
                    oArticulo.idSistema = Convert.ToInt32(dr["idSistema"]);
                    oArticulo.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                    oArticulo.factura = dr["Factura"].ToString();
                    oArticulo.fechaCompra = dr["FechaCompra"].ToString();
                    oArticulo.requisicion = dr["Requisicion"].ToString();
                    oArticulo.centroCostosAdquisicion = dr["CentroCostosAdquisicion"].ToString();
                    oArticulo.responsiva = dr["Responsiva"] == DBNull.Value ? respo : Convert.ToInt32(dr["Responsiva"]);
                    oArticulo.valorPesos = Convert.ToDouble(dr["ValorPesos"]);
                    oArticulo.valorUSD = Convert.ToDouble(dr["ValorUSD"]);
                    oArticulo.stock = dr["Stock"].ToString();
                    oArticulo.codigoCastor = dr["CodigoCastor"].ToString();
                    oArticulo.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                    oArticulo.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                    oArticulo.idEstado = Convert.ToInt32(dr["idEstado"]);
                    oArticulo.observacion1 = dr["Observacion1"].ToString();
                    oArticulo.observacion2 = dr["Observacion2"].ToString();
                    oArticulo.observacion3 = dr["Observacion3"].ToString();
                    oArticulo.posibleFaltanteFlag = Convert.ToBoolean(dr["PosibleFaltanteFlag"]);
                    oArticulo.cambioRYS = dr["CambioRYS"].ToString();
                    oArticulo.fechaMovimiento = Convert.ToDateTime(dr["FechaMovimiento"]);
                    lstArticulo.Add(oArticulo);
                }
            }
            return lstArticulo;
        }

        public List<Articulo> getArticulobyResponsiva(string sResponsiva)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  idItem ");
            sqlCommand.AppendLine("		, NoSerie ");
            sqlCommand.AppendLine("		, idTipoEquipo ");
            sqlCommand.AppendLine("		, idMarca ");
            sqlCommand.AppendLine("		, Modelo ");
            sqlCommand.AppendLine("		, Procesador ");
            sqlCommand.AppendLine("		, RAM ");
            sqlCommand.AppendLine("		, DiscoDuro ");
            sqlCommand.AppendLine("		, idSistema ");
            sqlCommand.AppendLine("		, idProveedor ");
            sqlCommand.AppendLine("		, Factura ");
            sqlCommand.AppendLine("		, FechaCompra ");
            sqlCommand.AppendLine("		, Requisicion ");
            sqlCommand.AppendLine("		, CentroCostosAdquisicion ");
            sqlCommand.AppendLine("		, Responsiva ");
            sqlCommand.AppendLine("		, ValorPesos");
            sqlCommand.AppendLine("		, ValorUSD");
            sqlCommand.AppendLine("		, Stock ");
            sqlCommand.AppendLine("		, CodigoCastor ");
            sqlCommand.AppendLine("		, idUsuario ");
            sqlCommand.AppendLine("		, idUbicacion ");
            sqlCommand.AppendLine("		, idEstado ");
            sqlCommand.AppendLine("		, Observacion1 ");
            sqlCommand.AppendLine("		, Observacion2 ");
            sqlCommand.AppendLine("		, Observacion3 ");
            sqlCommand.AppendLine("		, ISNULL(0, PosibleFaltanteFlag) AS PosibleFaltanteFlag ");
            sqlCommand.AppendLine("		, CambioRYS ");
            sqlCommand.AppendLine("		, FechaMovimiento");
            sqlCommand.AppendLine("		, idUsuarioAnterior ");
            sqlCommand.AppendLine("		, ResponsivaAnterior ");
            sqlCommand.AppendLine("		, ObservacionesResponsiva ");
            sqlCommand.AppendLine("FROM Articulo ");
            sqlCommand.AppendLine("WHERE Responsiva = @Responsiva ");
            sqlCommand.AppendLine("      AND idUsuario IS NOT NULL");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@Responsiva", DbType.Int32, sResponsiva);

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {

                throw ex;
            }
            List<Articulo> lstArticulo = new List<Articulo>();

            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int? respo = null;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Articulo oArticulo = new Articulo();
                        oArticulo.idItem = Convert.ToInt64(dr["idItem"]);
                        oArticulo.noSerie = dr["NoSerie"].ToString();
                        oArticulo.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                        oArticulo.idMarca = Convert.ToInt32(dr["idMarca"]);
                        oArticulo.modelo = dr["Modelo"].ToString();
                        //oArticulo.procesador = dr["Procesador"].ToString();
                        //oArticulo.ram = dr["RAM"].ToString();
                        //oArticulo.discoDuro = dr["DiscoDuro"].ToString();
                        //oArticulo.idSistema = Convert.ToInt32(dr["idSistema"]);
                        //oArticulo.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                        //oArticulo.factura = dr["Factura"].ToString();
                        //oArticulo.fechaCompra = dr["FechaCompra"].ToString();
                        //oArticulo.requisicion = dr["Requisicion"].ToString();
                        //oArticulo.centroCostosAdquisicion = dr["CentroCostosAdquisicion"].ToString();
                        oArticulo.responsiva = dr["Responsiva"] == DBNull.Value ? respo : Convert.ToInt32(dr["Responsiva"]);
                        //oArticulo.valorPesos = Convert.ToDouble(dr["ValorPesos"]);
                        //oArticulo.valorUSD = Convert.ToDouble(dr["ValorUSD"]);
                        //oArticulo.stock = dr["Stock"].ToString();
                        //oArticulo.codigoCastor = dr["CodigoCastor"].ToString();
                        oArticulo.idUsuario = dr["idUsuario"] == DBNull.Value ? 1186 : Convert.ToInt32(dr["idUsuario"]);
                        oArticulo.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                        oArticulo.idEstado = Convert.ToInt32(dr["idEstado"]);
                        oArticulo.observacion1 = dr["Observacion1"].ToString();
                        oArticulo.observacion2 = dr["Observacion2"].ToString();
                        oArticulo.observacion3 = dr["Observacion3"].ToString();
                        //oArticulo.posibleFaltanteFlag = Convert.ToBoolean(dr["PosibleFaltanteFlag"]);
                        oArticulo.cambioRYS = dr["CambioRYS"].ToString();

                        if (dr["FechaMovimiento"] != DBNull.Value)
                            oArticulo.fechaMovimiento = Convert.ToDateTime(dr["FechaMovimiento"]);


                        oArticulo.IdUsuarioAnterior = dr["idUsuarioAnterior"] == DBNull.Value ?
                                               respo : Convert.ToInt32(dr["idUsuarioAnterior"]);
                        oArticulo.ResponsivaAnterior = dr["ResponsivaAnterior"].ToString();
                        oArticulo.ObservacionesResponsiva = dr["ObservacionesResponsiva"].ToString();

                        lstArticulo.Add(oArticulo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstArticulo;
        }

        public string getResponsivaSerie(string sSerie)
        {
            string sResponsiva = string.Empty;
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  ISNULL(Responsiva, '') AS Responsiva ");
            sqlCommand.AppendLine("FROM Articulo ");
            sqlCommand.AppendLine("WHERE NoSerie= @NoSerie ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@NoSerie", DbType.String, sSerie);

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
                    sResponsiva = dr["Responsiva"].ToString();
                }
            }

            return sResponsiva;
        }

        public bool NuevaGeneracionResponsiva()
        {
            bool respuesta = new bool();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("select Count(*) from Articulo ");
            sqlCommand.AppendLine("where Responsiva <> 5000 and Responsiva is not null ");

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

            if (!ds.Tables[0].Rows[0][0].ToString().Equals("0"))
            {
                respuesta = true;
            }
            else
            {
                respuesta = false;
            }

            return respuesta;
        }

        public string NuevaGeneracionResponsivaMax()
        {
            string generaResponsiva = string.Empty;
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("select max(Responsiva) from Articulo ");

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

            if (ds.Tables[0].Rows.Count > 0)
            {
                generaResponsiva = ds.Tables[0].Rows[0][0].ToString();
                generaResponsiva = (Convert.ToInt32(generaResponsiva) + 1).ToString();
            }

            return generaResponsiva;
        }

        public string NuevaGeneracionResponsivaMaxHistorico()
        {
            string generaResponsiva = string.Empty;
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("select max(Responsiva) from ArticuloHistorico where Responsiva <> 5000 and Responsiva is not null");

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

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0] != DBNull.Value)
                {
                    generaResponsiva = ds.Tables[0].Rows[0][0].ToString();
                    generaResponsiva = (Convert.ToInt32(generaResponsiva) + 1).ToString();
                }
                else
                {
                    generaResponsiva = "10001";
                }
            }

            return generaResponsiva;
        }

        public List<Articulo> getArticulobyUsuario(int idUsuario)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  idItem ");
            sqlCommand.AppendLine("		, NoSerie ");
            sqlCommand.AppendLine("		, idTipoEquipo ");
            sqlCommand.AppendLine("		, idMarca ");
            sqlCommand.AppendLine("		, Modelo ");
            sqlCommand.AppendLine("		, Procesador ");
            sqlCommand.AppendLine("		, RAM ");
            sqlCommand.AppendLine("		, DiscoDuro ");
            sqlCommand.AppendLine("		, idSistema ");
            sqlCommand.AppendLine("		, idProveedor ");
            sqlCommand.AppendLine("		, Factura ");
            sqlCommand.AppendLine("		, FechaCompra ");
            sqlCommand.AppendLine("		, Requisicion ");
            sqlCommand.AppendLine("		, CentroCostosAdquisicion ");
            sqlCommand.AppendLine("		, Responsiva ");
            sqlCommand.AppendLine("		, ISNULL('0', ValorPesos) AS ValorPesos ");
            sqlCommand.AppendLine("		, ISNULL('0', ValorUSD) AS ValorUSD ");
            sqlCommand.AppendLine("		, Stock ");
            sqlCommand.AppendLine("		, CodigoCastor ");
            sqlCommand.AppendLine("		, idUsuario ");
            sqlCommand.AppendLine("		, idUbicacion ");
            sqlCommand.AppendLine("		, idEstado ");
            sqlCommand.AppendLine("		, Observacion1 ");
            sqlCommand.AppendLine("		, Observacion2 ");
            sqlCommand.AppendLine("		, Observacion3 ");
            sqlCommand.AppendLine("		, ISNULL(0, PosibleFaltanteFlag) AS PosibleFaltanteFlag ");
            sqlCommand.AppendLine("		, CambioRYS ");
            sqlCommand.AppendLine("		, isnull('01/01/1900', FechaMovimiento) AS FechaMovimiento ");
            sqlCommand.AppendLine("FROM Articulo ");
            sqlCommand.AppendLine("WHERE idUsuario = @idUsuario ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idUsuario", DbType.Int32, idUsuario);

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {

                throw ex;
            }
            List<Articulo> lstArticulo = new List<Articulo>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                int? respo = null;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Articulo oArticulo = new Articulo();
                    oArticulo.idItem = Convert.ToInt64(dr["idItem"]);
                    oArticulo.noSerie = dr["NoSerie"].ToString();
                    oArticulo.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                    oArticulo.idMarca = Convert.ToInt32(dr["idMarca"]);
                    oArticulo.modelo = dr["Modelo"].ToString();
                    oArticulo.procesador = dr["Procesador"].ToString();
                    oArticulo.ram = dr["RAM"].ToString();
                    oArticulo.discoDuro = dr["DiscoDuro"].ToString();
                    oArticulo.idSistema = Convert.ToInt32(dr["idSistema"]);
                    oArticulo.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                    oArticulo.factura = dr["Factura"].ToString();
                    oArticulo.fechaCompra = dr["FechaCompra"].ToString();
                    oArticulo.requisicion = dr["Requisicion"].ToString();
                    oArticulo.centroCostosAdquisicion = dr["CentroCostosAdquisicion"].ToString();
                    oArticulo.responsiva = dr["Responsiva"] == DBNull.Value ? respo : Convert.ToInt32(dr["Responsiva"]);
                    oArticulo.valorPesos = Convert.ToDouble(dr["ValorPesos"]);
                    oArticulo.valorUSD = Convert.ToDouble(dr["ValorUSD"]);
                    oArticulo.stock = dr["Stock"].ToString();
                    oArticulo.codigoCastor = dr["CodigoCastor"].ToString();
                    oArticulo.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                    oArticulo.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                    oArticulo.idEstado = Convert.ToInt32(dr["idEstado"]);
                    oArticulo.observacion1 = dr["Observacion1"].ToString();
                    oArticulo.observacion2 = dr["Observacion2"].ToString();
                    oArticulo.observacion3 = dr["Observacion3"].ToString();
                    oArticulo.posibleFaltanteFlag = Convert.ToBoolean(dr["PosibleFaltanteFlag"]);
                    oArticulo.cambioRYS = dr["CambioRYS"].ToString();
                    oArticulo.fechaMovimiento = Convert.ToDateTime(dr["FechaMovimiento"]);
                    lstArticulo.Add(oArticulo);
                }
            }
            return lstArticulo;
        }

        public List<Articulo> getResponsivasAnteriores(int idUsuario)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            //sqlCommand.AppendLine("select distinct ResponsivaAnterior as Responsiva, 'Anterior' as Identificador from Articulo  ");
            //sqlCommand.AppendLine("	where Responsiva = 5000 and idUsuario =  @idUsuario");
            //sqlCommand.AppendLine("union ");
            sqlCommand.AppendLine("select distinct CONVERT(VARCHAR,Responsiva) as Responsiva, 'Nueva' as Identificador from Articulo ");
            sqlCommand.AppendLine("where Responsiva <> 5000 and idUsuario = @idUsuario");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idUsuario", DbType.Int32, idUsuario);

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
            List<Articulo> lstArticulo = new List<Articulo>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Articulo oArticulo = new Articulo();
                    oArticulo.Identificador = dr["Identificador"].ToString();
                    oArticulo.ResponsivaAnterior = dr["Responsiva"].ToString();
                    lstArticulo.Add(oArticulo);
                }
            }
            return lstArticulo;
        }

        public List<Articulo> getResponsivaAnterior(int responsi, int idUsuario)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  t1.idItem ");
            sqlCommand.AppendLine("		, t1.NoSerie ");
            sqlCommand.AppendLine("		, t1.idTipoEquipo ");
            sqlCommand.AppendLine("		, t1.idMarca ");
            sqlCommand.AppendLine("		, t1.Modelo ");
            sqlCommand.AppendLine("		, t1.Procesador ");
            sqlCommand.AppendLine("		, t1.RAM ");
            sqlCommand.AppendLine("		, t1.DiscoDuro ");
            sqlCommand.AppendLine("		, t1.idSistema ");
            sqlCommand.AppendLine("		, t1.idProveedor ");
            sqlCommand.AppendLine("		, t1.Factura ");
            sqlCommand.AppendLine("		, t1.FechaCompra ");
            sqlCommand.AppendLine("		, t1.Requisicion ");
            sqlCommand.AppendLine("		, t1.CentroCostosAdquisicion ");
            sqlCommand.AppendLine("		, t1.Responsiva ");
            sqlCommand.AppendLine("		, t1.ValorPesos");
            sqlCommand.AppendLine("		, t1.ValorUSD");
            sqlCommand.AppendLine("		, t1.Stock ");
            sqlCommand.AppendLine("		, t1.CodigoCastor ");
            sqlCommand.AppendLine("		, t1.idUsuario ");
            sqlCommand.AppendLine("		, t1.idUbicacion ");
            sqlCommand.AppendLine("		, t1.idEstado ");
            sqlCommand.AppendLine("		, t1.Observacion1 ");
            sqlCommand.AppendLine("		, t1.Observacion2 ");
            sqlCommand.AppendLine("		, t1.Observacion3 ");
            sqlCommand.AppendLine("		, t1.ResponsivaAnterior ");
            sqlCommand.AppendLine("		, t1.idUsuarioAnterior ");
            sqlCommand.AppendLine("		, ISNULL(0, t1.PosibleFaltanteFlag) AS PosibleFaltanteFlag ");
            sqlCommand.AppendLine("		, t1.CambioRYS ");
            sqlCommand.AppendLine("		, t1.FechaMovimiento");
            sqlCommand.AppendLine("		, t2.Descripcion as TipoEquipo ");
            sqlCommand.AppendLine("		, t3.Descripcion as Marca ");
            sqlCommand.AppendLine("		, t4.Descripcion as Ubicacion ");
            sqlCommand.AppendLine("FROM Articulo t1");
            sqlCommand.AppendLine("inner join TipoEquipo t2 on t1.idTipoEquipo = t2.idTipoEquipo ");
            sqlCommand.AppendLine("inner join Marca t3 on t1.idMarca = t3.idMarca ");
            sqlCommand.AppendLine("inner join Ubicacion t4 on t1.idUbicacion = t4.idUbicacion ");
            sqlCommand.AppendLine("WHERE t1.Responsiva = @Responsiva ");
            sqlCommand.AppendLine("and t1.idUsuario = @idUsuario ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@Responsiva", DbType.Int32, responsi);
            db.AddInParameter(selectCommand, "@idUsuario", DbType.Int32, idUsuario);

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {

                throw ex;
            }
            List<Articulo> lstArticulo = new List<Articulo>();

            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int? respo = null;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Articulo oArticulo = new Articulo();
                        oArticulo.idItem = Convert.ToInt64(dr["idItem"]);
                        oArticulo.noSerie = dr["NoSerie"].ToString();
                        oArticulo.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                        oArticulo.idMarca = Convert.ToInt32(dr["idMarca"]);
                        oArticulo.modelo = dr["Modelo"].ToString();
                        //oArticulo.procesador = dr["Procesador"].ToString();
                        //oArticulo.ram = dr["RAM"].ToString();
                        //oArticulo.discoDuro = dr["DiscoDuro"].ToString();
                        //oArticulo.idSistema = Convert.ToInt32(dr["idSistema"]);
                        //oArticulo.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                        //oArticulo.factura = dr["Factura"].ToString();
                        //oArticulo.fechaCompra = dr["FechaCompra"].ToString();
                        //oArticulo.requisicion = dr["Requisicion"].ToString();
                        //oArticulo.centroCostosAdquisicion = dr["CentroCostosAdquisicion"].ToString();
                        oArticulo.responsiva = dr["Responsiva"] == DBNull.Value ? respo : Convert.ToInt32(dr["Responsiva"]);

                        if (dr["ResponsivaAnterior"] == DBNull.Value)
                        oArticulo.ResponsivaAnterior = dr["ResponsivaAnterior"].ToString();
                        //oArticulo.valorPesos = Convert.ToDouble(dr["ValorPesos"]);
                        //oArticulo.valorUSD = Convert.ToDouble(dr["ValorUSD"]);
                        //oArticulo.stock = dr["Stock"].ToString();
                        //oArticulo.codigoCastor = dr["CodigoCastor"].ToString();
                        oArticulo.idUsuario = dr["idUsuario"] == DBNull.Value ? 1186 : Convert.ToInt32(dr["idUsuario"]);
                        oArticulo.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                        oArticulo.idEstado = Convert.ToInt32(dr["idEstado"]);
                        oArticulo.observacion1 = dr["Observacion1"].ToString();
                        oArticulo.observacion2 = dr["Observacion2"].ToString();
                        oArticulo.observacion3 = dr["Observacion3"].ToString();
                        //oArticulo.posibleFaltanteFlag = Convert.ToBoolean(dr["PosibleFaltanteFlag"]);
                        oArticulo.cambioRYS = dr["CambioRYS"].ToString();

                        if (dr["FechaMovimiento"] != DBNull.Value)
                            oArticulo.fechaMovimiento = Convert.ToDateTime(dr["FechaMovimiento"]);

                        oArticulo.IdUsuarioAnterior = dr["idUsuarioAnterior"] == DBNull.Value ?
                                              respo : Convert.ToInt32(dr["idUsuarioAnterior"]);

                        oArticulo.cambioRYS = dr["CambioRYS"].ToString();
                        oArticulo.TipoEquipo = dr["TipoEquipo"].ToString();
                        oArticulo.Marca = dr["Marca"].ToString();
                        oArticulo.Ubicacion = dr["Ubicacion"].ToString();

                        lstArticulo.Add(oArticulo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstArticulo;
        }

        public List<Articulo> getArticulobyUbicacion(int idUbicacion)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  idItem ");
            sqlCommand.AppendLine("		, NoSerie ");
            sqlCommand.AppendLine("		, idTipoEquipo ");
            sqlCommand.AppendLine("		, idMarca ");
            sqlCommand.AppendLine("		, Modelo ");
            sqlCommand.AppendLine("		, Procesador ");
            sqlCommand.AppendLine("		, RAM ");
            sqlCommand.AppendLine("		, DiscoDuro ");
            sqlCommand.AppendLine("		, idSistema ");
            sqlCommand.AppendLine("		, idProveedor ");
            sqlCommand.AppendLine("		, Factura ");
            sqlCommand.AppendLine("		, FechaCompra ");
            sqlCommand.AppendLine("		, Requisicion ");
            sqlCommand.AppendLine("		, CentroCostosAdquisicion ");
            sqlCommand.AppendLine("		, Responsiva ");
            sqlCommand.AppendLine("		, ISNULL('0', ValorPesos) AS ValorPesos ");
            sqlCommand.AppendLine("		, ISNULL('0', ValorUSD) AS ValorUSD ");
            sqlCommand.AppendLine("		, Stock ");
            sqlCommand.AppendLine("		, CodigoCastor ");
            sqlCommand.AppendLine("		, idUsuario ");
            sqlCommand.AppendLine("		, idUbicacion ");
            sqlCommand.AppendLine("		, idEstado ");
            sqlCommand.AppendLine("		, Observacion1 ");
            sqlCommand.AppendLine("		, Observacion2 ");
            sqlCommand.AppendLine("		, Observacion3 ");
            sqlCommand.AppendLine("		, ISNULL(0, PosibleFaltanteFlag) AS PosibleFaltanteFlag ");
            sqlCommand.AppendLine("		, CambioRYS ");
            sqlCommand.AppendLine("		, isnull('01/01/1900', FechaMovimiento) AS FechaMovimiento ");
            sqlCommand.AppendLine("FROM Articulo ");
            sqlCommand.AppendLine("WHERE idUbicacion = @idUbicacion ");

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
            List<Articulo> lstArticulo = new List<Articulo>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                int? respo = null;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Articulo oArticulo = new Articulo();
                    oArticulo.idItem = Convert.ToInt64(dr["idItem"]);
                    oArticulo.noSerie = dr["NoSerie"].ToString();
                    oArticulo.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                    oArticulo.idMarca = Convert.ToInt32(dr["idMarca"]);
                    oArticulo.modelo = dr["Modelo"].ToString();
                    oArticulo.procesador = dr["Procesador"].ToString();
                    oArticulo.ram = dr["RAM"].ToString();
                    oArticulo.discoDuro = dr["DiscoDuro"].ToString();
                    oArticulo.idSistema = Convert.ToInt32(dr["idSistema"]);
                    oArticulo.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                    oArticulo.factura = dr["Factura"].ToString();
                    oArticulo.fechaCompra = dr["FechaCompra"].ToString();
                    oArticulo.requisicion = dr["Requisicion"].ToString();
                    oArticulo.centroCostosAdquisicion = dr["CentroCostosAdquisicion"].ToString();
                    oArticulo.responsiva = dr["Responsiva"] == DBNull.Value ? respo : Convert.ToInt32(dr["Responsiva"]);
                    oArticulo.valorPesos = Convert.ToDouble(dr["ValorPesos"]);
                    oArticulo.valorUSD = Convert.ToDouble(dr["ValorUSD"]);
                    oArticulo.stock = dr["Stock"].ToString();
                    oArticulo.codigoCastor = dr["CodigoCastor"].ToString();
                    oArticulo.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                    oArticulo.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                    oArticulo.idEstado = Convert.ToInt32(dr["idEstado"]);
                    oArticulo.observacion1 = dr["Observacion1"].ToString();
                    oArticulo.observacion2 = dr["Observacion2"].ToString();
                    oArticulo.observacion3 = dr["Observacion3"].ToString();
                    oArticulo.posibleFaltanteFlag = Convert.ToBoolean(dr["PosibleFaltanteFlag"]);
                    oArticulo.cambioRYS = dr["CambioRYS"].ToString();
                    oArticulo.fechaMovimiento = Convert.ToDateTime(dr["FechaMovimiento"]);
                    lstArticulo.Add(oArticulo);
                }
            }
            return lstArticulo;
        }

        public List<Articulo> getArticulobyTipoEquipo(int idTipoEquipo)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  idItem ");
            sqlCommand.AppendLine("		, NoSerie ");
            sqlCommand.AppendLine("		, idTipoEquipo ");
            sqlCommand.AppendLine("		, idMarca ");
            sqlCommand.AppendLine("		, Modelo ");
            sqlCommand.AppendLine("		, Procesador ");
            sqlCommand.AppendLine("		, RAM ");
            sqlCommand.AppendLine("		, DiscoDuro ");
            sqlCommand.AppendLine("		, idSistema ");
            sqlCommand.AppendLine("		, idProveedor ");
            sqlCommand.AppendLine("		, Factura ");
            sqlCommand.AppendLine("		, FechaCompra ");
            sqlCommand.AppendLine("		, Requisicion ");
            sqlCommand.AppendLine("		, CentroCostosAdquisicion ");
            sqlCommand.AppendLine("		, Responsiva ");
            sqlCommand.AppendLine("		, ISNULL('0', ValorPesos) AS ValorPesos ");
            sqlCommand.AppendLine("		, ISNULL('0', ValorUSD) AS ValorUSD ");
            sqlCommand.AppendLine("		, Stock ");
            sqlCommand.AppendLine("		, CodigoCastor ");
            sqlCommand.AppendLine("		, idUsuario ");
            sqlCommand.AppendLine("		, idUbicacion ");
            sqlCommand.AppendLine("		, idEstado ");
            sqlCommand.AppendLine("		, Observacion1 ");
            sqlCommand.AppendLine("		, Observacion2 ");
            sqlCommand.AppendLine("		, Observacion3 ");
            sqlCommand.AppendLine("		, ISNULL(0, PosibleFaltanteFlag) AS PosibleFaltanteFlag ");
            sqlCommand.AppendLine("		, CambioRYS ");
            sqlCommand.AppendLine("		, isnull('01/01/1900', FechaMovimiento) AS FechaMovimiento ");
            sqlCommand.AppendLine("FROM Articulo ");
            sqlCommand.AppendLine("WHERE idTipoEquipo = @idTipoEquipo ");

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
            List<Articulo> lstArticulo = new List<Articulo>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                int? respo = null;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Articulo oArticulo = new Articulo();
                    oArticulo.idItem = Convert.ToInt64(dr["idItem"]);
                    oArticulo.noSerie = dr["NoSerie"].ToString();
                    oArticulo.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                    oArticulo.idMarca = Convert.ToInt32(dr["idMarca"]);
                    oArticulo.modelo = dr["Modelo"].ToString();
                    oArticulo.procesador = dr["Procesador"].ToString();
                    oArticulo.ram = dr["RAM"].ToString();
                    oArticulo.discoDuro = dr["DiscoDuro"].ToString();
                    oArticulo.idSistema = Convert.ToInt32(dr["idSistema"]);
                    oArticulo.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                    oArticulo.factura = dr["Factura"].ToString();
                    oArticulo.fechaCompra = dr["FechaCompra"].ToString();
                    oArticulo.requisicion = dr["Requisicion"].ToString();
                    oArticulo.centroCostosAdquisicion = dr["CentroCostosAdquisicion"].ToString();
                    oArticulo.responsiva = dr["Responsiva"] == DBNull.Value ? respo : Convert.ToInt32(dr["Responsiva"]);
                    oArticulo.valorPesos = Convert.ToDouble(dr["ValorPesos"]);
                    oArticulo.valorUSD = Convert.ToDouble(dr["ValorUSD"]);
                    oArticulo.stock = dr["Stock"].ToString();
                    oArticulo.codigoCastor = dr["CodigoCastor"].ToString();
                    oArticulo.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                    oArticulo.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                    oArticulo.idEstado = Convert.ToInt32(dr["idEstado"]);
                    oArticulo.observacion1 = dr["Observacion1"].ToString();
                    oArticulo.observacion2 = dr["Observacion2"].ToString();
                    oArticulo.observacion3 = dr["Observacion3"].ToString();
                    oArticulo.posibleFaltanteFlag = Convert.ToBoolean(dr["PosibleFaltanteFlag"]);
                    oArticulo.cambioRYS = dr["CambioRYS"].ToString();
                    oArticulo.fechaMovimiento = Convert.ToDateTime(dr["FechaMovimiento"]);
                    lstArticulo.Add(oArticulo);
                }
            }
            return lstArticulo;
        }

        public List<Articulo> getArticulobyPosibleFaltante(bool PosibleFaltanteFlag)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  idItem ");
            sqlCommand.AppendLine("		, NoSerie ");
            sqlCommand.AppendLine("		, idTipoEquipo ");
            sqlCommand.AppendLine("		, idMarca ");
            sqlCommand.AppendLine("		, Modelo ");
            sqlCommand.AppendLine("		, Procesador ");
            sqlCommand.AppendLine("		, RAM ");
            sqlCommand.AppendLine("		, DiscoDuro ");
            sqlCommand.AppendLine("		, idSistema ");
            sqlCommand.AppendLine("		, idProveedor ");
            sqlCommand.AppendLine("		, Factura ");
            sqlCommand.AppendLine("		, FechaCompra ");
            sqlCommand.AppendLine("		, Requisicion ");
            sqlCommand.AppendLine("		, CentroCostosAdquisicion ");
            sqlCommand.AppendLine("		, Responsiva ");
            sqlCommand.AppendLine("		, ISNULL('0', ValorPesos) AS ValorPesos ");
            sqlCommand.AppendLine("		, ISNULL('0', ValorUSD) AS ValorUSD ");
            sqlCommand.AppendLine("		, Stock ");
            sqlCommand.AppendLine("		, CodigoCastor ");
            sqlCommand.AppendLine("		, idUsuario ");
            sqlCommand.AppendLine("		, idUbicacion ");
            sqlCommand.AppendLine("		, idEstado ");
            sqlCommand.AppendLine("		, Observacion1 ");
            sqlCommand.AppendLine("		, Observacion2 ");
            sqlCommand.AppendLine("		, Observacion3 ");
            sqlCommand.AppendLine("		, ISNULL(0, PosibleFaltanteFlag) AS PosibleFaltanteFlag ");
            sqlCommand.AppendLine("		, CambioRYS ");
            sqlCommand.AppendLine("		, isnull('01/01/1900', FechaMovimiento) AS FechaMovimiento ");
            sqlCommand.AppendLine("FROM Articulo ");
            sqlCommand.AppendLine("WHERE PosibleFaltanteFlag = @PosibleFaltanteFlag ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@PosibleFaltanteFlag", DbType.Boolean, PosibleFaltanteFlag);

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {

                throw ex;
            }
            List<Articulo> lstArticulo = new List<Articulo>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                int? respo = null;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Articulo oArticulo = new Articulo();
                    oArticulo.idItem = Convert.ToInt64(dr["idItem"]);
                    oArticulo.noSerie = dr["NoSerie"].ToString();
                    oArticulo.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                    oArticulo.idMarca = Convert.ToInt32(dr["idMarca"]);
                    oArticulo.modelo = dr["Modelo"].ToString();
                    oArticulo.procesador = dr["Procesador"].ToString();
                    oArticulo.ram = dr["RAM"].ToString();
                    oArticulo.discoDuro = dr["DiscoDuro"].ToString();
                    oArticulo.idSistema = Convert.ToInt32(dr["idSistema"]);
                    oArticulo.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                    oArticulo.factura = dr["Factura"].ToString();
                    oArticulo.fechaCompra = dr["FechaCompra"].ToString();
                    oArticulo.requisicion = dr["Requisicion"].ToString();
                    oArticulo.centroCostosAdquisicion = dr["CentroCostosAdquisicion"].ToString();
                    oArticulo.responsiva = dr["Responsiva"] == DBNull.Value ? respo : Convert.ToInt32(dr["Responsiva"]);
                    oArticulo.valorPesos = Convert.ToDouble(dr["ValorPesos"]);
                    oArticulo.valorUSD = Convert.ToDouble(dr["ValorUSD"]);
                    oArticulo.stock = dr["Stock"].ToString();
                    oArticulo.codigoCastor = dr["CodigoCastor"].ToString();
                    oArticulo.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                    oArticulo.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                    oArticulo.idEstado = Convert.ToInt32(dr["idEstado"]);
                    oArticulo.observacion1 = dr["Observacion1"].ToString();
                    oArticulo.observacion2 = dr["Observacion2"].ToString();
                    oArticulo.observacion3 = dr["Observacion3"].ToString();
                    oArticulo.posibleFaltanteFlag = Convert.ToBoolean(dr["PosibleFaltanteFlag"]);
                    oArticulo.cambioRYS = dr["CambioRYS"].ToString();
                    oArticulo.fechaMovimiento = Convert.ToDateTime(dr["FechaMovimiento"]);
                    lstArticulo.Add(oArticulo);
                }
            }
            return lstArticulo;
        }

        public List<Articulo> getArticulosFilteredA(string sSerie, int? sResponsiva, int idUsuario, int idUbicacion, int idTipoEquipo)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DataSet ds = new DataSet();
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpS_BuscaArticulos");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pNoSerie", DbType.String, sSerie);
            db.AddInParameter(dbCommand, "@pResponsiva", DbType.Int32, sResponsiva);
            db.AddInParameter(dbCommand, "@pidUsuario", DbType.Int32, idUsuario);
            db.AddInParameter(dbCommand, "@pidUbicacion", DbType.Int32, idUbicacion);
            db.AddInParameter(dbCommand, "@pidTipoEquipo", DbType.Int32, idTipoEquipo);

            try
            {
                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }

            List<Articulo> lstArticuloHeader = new List<Articulo>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                int? respo = null;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Articulo oArticuloHeader = new Articulo();
                    oArticuloHeader.idItem = Convert.ToInt64(dr["idItem"]);
                    oArticuloHeader.responsiva = dr["Responsiva"] == DBNull.Value ? respo : Convert.ToInt32(dr["Responsiva"]);
                    oArticuloHeader.noSerie = dr["NoSerie"].ToString();
                    oArticuloHeader.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                    oArticuloHeader.TipoEquipo = dr["TipoEquipo"].ToString();
                    oArticuloHeader.Ubicacion = dr["Ubicacion"].ToString();
                    oArticuloHeader.UsuarioAsignado = dr["UsuarioAsignado"].ToString();
                    oArticuloHeader.Puesto = dr["Puesto"].ToString();
                    oArticuloHeader.Marca = dr["Marca"].ToString();
                    oArticuloHeader.modelo = dr["Modelo"].ToString();
                    oArticuloHeader.idMarca = Convert.ToInt32(dr["idMarca"]);
                    oArticuloHeader.idUsuario = dr["idUsuario"] == DBNull.Value ? respo : Convert.ToInt32(dr["idUsuario"]);

                    oArticuloHeader.IdUsuarioAnterior = dr["idUsuarioAnterior"] == DBNull.Value ?
                                               respo : Convert.ToInt32(dr["idUsuarioAnterior"]);

                    if (dr["ResponsivaAnterior"] != DBNull.Value)
                        oArticuloHeader.ResponsivaAnterior = dr["ResponsivaAnterior"].ToString();

                    if (dr["fechaMovimiento"] != DBNull.Value)
                        oArticuloHeader.fechaMovimiento = Convert.ToDateTime(dr["fechaMovimiento"]);

                    oArticuloHeader.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);

                    oArticuloHeader.idEstado = Convert.ToInt32(dr["idEstado"]);
                    oArticuloHeader.observacion1 = dr["Observacion1"].ToString();
                    oArticuloHeader.observacion2 = dr["Observacion2"].ToString();
                    oArticuloHeader.observacion3 = dr["Observacion3"].ToString();
                    oArticuloHeader.ObservacionesResponsiva = dr["ObservacionesResponsiva"].ToString();

                    lstArticuloHeader.Add(oArticuloHeader);
                }
            }
            return lstArticuloHeader;
        }

        public List<ArticuloHeader> getArticulosFiltered(string sSerie, int? sResponsiva, int idUsuario, int idUbicacion, int idTipoEquipo)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DataSet ds = new DataSet();
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpS_BuscaArticulos");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pNoSerie", DbType.String, sSerie);
            db.AddInParameter(dbCommand, "@pResponsiva", DbType.Int32, sResponsiva);
            db.AddInParameter(dbCommand, "@pidUsuario", DbType.Int32, idUsuario);
            db.AddInParameter(dbCommand, "@pidUbicacion", DbType.Int32, idUbicacion);
            db.AddInParameter(dbCommand, "@pidTipoEquipo", DbType.Int32, idTipoEquipo);

            try
            {

                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }

            List<ArticuloHeader> lstArticuloHeader = new List<ArticuloHeader>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                int? respo = null;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ArticuloHeader oArticuloHeader = new ArticuloHeader();
                    oArticuloHeader.idItem = Convert.ToInt64(dr["idItem"]);
                    oArticuloHeader.responsiva = dr["Responsiva"] == DBNull.Value ? respo : Convert.ToInt32(dr["Responsiva"]);
                    oArticuloHeader.noSerie = dr["NoSerie"].ToString();
                    oArticuloHeader.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                    oArticuloHeader.tipoEquipo = dr["TipoEquipo"].ToString();
                    oArticuloHeader.ubicacion = dr["Ubicacion"].ToString();
                    oArticuloHeader.usuarioAsignado = dr["UsuarioAsignado"].ToString();
                    oArticuloHeader.puesto = dr["Puesto"].ToString();
                    lstArticuloHeader.Add(oArticuloHeader);
                }
            }
            return lstArticuloHeader;
        }

        public List<Total> getTotalesFiltered(string sSerie, int? sResponsiva, int idUsuario, int idUbicacion, int idTipoEquipo, int id)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DataSet ds = new DataSet();
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpS_TotalArticulos");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pNoSerie", DbType.String, sSerie);
            db.AddInParameter(dbCommand, "@pResponsiva", DbType.Int32, sResponsiva);
            db.AddInParameter(dbCommand, "@pidUsuario", DbType.Int32, idUsuario);
            db.AddInParameter(dbCommand, "@pidUbicacion", DbType.Int32, idUbicacion);
            db.AddInParameter(dbCommand, "@pidTipoEquipo", DbType.Int32, idTipoEquipo);
            db.AddInParameter(dbCommand, "@pidTotal", DbType.Int32, id);

            try
            {

                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }

            List<Total> lstTotal = new List<Total>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Total oTotal = new Total();
                    oTotal.id = Convert.ToInt32(dr["id"]);
                    oTotal.concepto = dr["Concepto"].ToString();
                    oTotal.conteo = Convert.ToInt32(dr["Total"]);
                    lstTotal.Add(oTotal);
                }
            }
            return lstTotal;
        }

        #endregion


        #region insert


        public void InsertArticulo(ref Articulo oArticulo)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_Articulo");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pNoSerie", DbType.String, oArticulo.noSerie);
            db.AddInParameter(dbCommand, "@pidTipoEquipo", DbType.Int32, oArticulo.idTipoEquipo);
            db.AddInParameter(dbCommand, "@pidMarca", DbType.Int32, oArticulo.idMarca);
            db.AddInParameter(dbCommand, "@pModelo", DbType.String, oArticulo.modelo);
            db.AddInParameter(dbCommand, "@pProcesador", DbType.String, oArticulo.procesador);
            db.AddInParameter(dbCommand, "@pRAM", DbType.String, oArticulo.ram);
            db.AddInParameter(dbCommand, "@pDiscoDuro", DbType.String, oArticulo.discoDuro);
            db.AddInParameter(dbCommand, "@pidSistema", DbType.Int32, oArticulo.idSistema);
            db.AddInParameter(dbCommand, "@pidProveedor", DbType.Int32, oArticulo.idProveedor);
            db.AddInParameter(dbCommand, "@pFactura", DbType.String, oArticulo.factura);
            db.AddInParameter(dbCommand, "@pFechaCompra", DbType.String, oArticulo.fechaCompra);
            db.AddInParameter(dbCommand, "@pRequisicion", DbType.String, oArticulo.requisicion);
            db.AddInParameter(dbCommand, "@pCentroCostosAdquisicion", DbType.String, oArticulo.centroCostosAdquisicion);
            //db.AddInParameter(dbCommand, "@pResponsiva", DbType.Int32, oArticulo.responsiva);
            db.AddInParameter(dbCommand, "@pResponsiva", DbType.Int32, 5000);
            db.AddInParameter(dbCommand, "@pValorPesos", DbType.Double, oArticulo.valorPesos);
            db.AddInParameter(dbCommand, "@pValorUSD", DbType.Double, oArticulo.valorUSD);
            db.AddInParameter(dbCommand, "@pStock", DbType.String, oArticulo.stock);
            db.AddInParameter(dbCommand, "@pCodigoCastor", DbType.String, oArticulo.codigoCastor);
            db.AddInParameter(dbCommand, "@pidUsuario", DbType.Int32, oArticulo.idUsuario);
            db.AddInParameter(dbCommand, "@pidUbicacion", DbType.Int32, oArticulo.idUbicacion);
            db.AddInParameter(dbCommand, "@pidEstado", DbType.Int32, oArticulo.idEstado);
            db.AddInParameter(dbCommand, "@pObservacion1", DbType.String, oArticulo.observacion1);
            db.AddInParameter(dbCommand, "@pObservacion2", DbType.String, oArticulo.observacion2);
            db.AddInParameter(dbCommand, "@pObservacion3", DbType.String, oArticulo.observacion3);
            db.AddInParameter(dbCommand, "@pPosibleFaltanteFlag", DbType.Boolean, oArticulo.posibleFaltanteFlag);
            db.AddInParameter(dbCommand, "@pCambioRYS", DbType.String, oArticulo.cambioRYS);
            db.AddInParameter(dbCommand, "@pFechaMovimiento", DbType.DateTime, oArticulo.fechaMovimiento);

            db.AddOutParameter(dbCommand, "@pidItem", DbType.Int64, 4);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                oArticulo.idItem = Convert.ToInt64(db.GetParameterValue(dbCommand, "@pidItem"));
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Updates
        public void UpdateArticulo(Articulo oArticulo)
        {
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpU_Articulo");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pidItem", DbType.Int64, oArticulo.idItem);
            db.AddInParameter(dbCommand, "@pNoSerie", DbType.String, oArticulo.noSerie);
            db.AddInParameter(dbCommand, "@pidTipoEquipo", DbType.Int32, oArticulo.idTipoEquipo);
            db.AddInParameter(dbCommand, "@pidMarca", DbType.Int32, oArticulo.idMarca);
            db.AddInParameter(dbCommand, "@pModelo", DbType.String, oArticulo.modelo);
            db.AddInParameter(dbCommand, "@pProcesador", DbType.String, oArticulo.procesador);
            db.AddInParameter(dbCommand, "@pRAM", DbType.String, oArticulo.ram);
            db.AddInParameter(dbCommand, "@pDiscoDuro", DbType.String, oArticulo.discoDuro);
            db.AddInParameter(dbCommand, "@pidSistema", DbType.Int32, oArticulo.idSistema);
            db.AddInParameter(dbCommand, "@pidProveedor", DbType.Int32, oArticulo.idProveedor);
            db.AddInParameter(dbCommand, "@pFactura", DbType.String, oArticulo.factura);
            db.AddInParameter(dbCommand, "@pFechaCompra", DbType.String, oArticulo.fechaCompra);
            db.AddInParameter(dbCommand, "@pRequisicion", DbType.String, oArticulo.requisicion);
            db.AddInParameter(dbCommand, "@pCentroCostosAdquisicion", DbType.String, oArticulo.centroCostosAdquisicion);
            db.AddInParameter(dbCommand, "@pResponsiva", DbType.Int32, oArticulo.responsiva);
            db.AddInParameter(dbCommand, "@pValorPesos", DbType.Double, oArticulo.valorPesos);
            db.AddInParameter(dbCommand, "@pValorUSD", DbType.Double, oArticulo.valorUSD);
            db.AddInParameter(dbCommand, "@pStock", DbType.String, oArticulo.stock);
            db.AddInParameter(dbCommand, "@pCodigoCastor", DbType.String, oArticulo.codigoCastor);
            db.AddInParameter(dbCommand, "@pidUsuario", DbType.Int32, oArticulo.idUsuario);
            db.AddInParameter(dbCommand, "@pidUbicacion", DbType.Int32, oArticulo.idUbicacion);
            db.AddInParameter(dbCommand, "@pidEstado", DbType.Int32, oArticulo.idEstado);
            db.AddInParameter(dbCommand, "@pObservacion1", DbType.String, oArticulo.observacion1);
            db.AddInParameter(dbCommand, "@pObservacion2", DbType.String, oArticulo.observacion2);
            db.AddInParameter(dbCommand, "@pObservacion3", DbType.String, oArticulo.observacion3);
            db.AddInParameter(dbCommand, "@pPosibleFaltanteFlag", DbType.Boolean, oArticulo.posibleFaltanteFlag);
            db.AddInParameter(dbCommand, "@pCambioRYS", DbType.String, oArticulo.cambioRYS);
            db.AddInParameter(dbCommand, "@pFechaMovimiento", DbType.String, oArticulo.fechaMovimiento.Value.ToString("yyyy-MM-dd"));
            db.AddInParameter(dbCommand, "@pObservacionesResponsiva", DbType.String, oArticulo.ObservacionesResponsiva);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (DataException ex)
            {

                throw ex;
            }
        }

        #endregion



        public void InsertArticuloHistorico(Articulo oArticulo)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_ArticuloHistorico");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pidItem", DbType.Int64, oArticulo.idItem);
            db.AddInParameter(dbCommand, "@pNoSerie", DbType.String, oArticulo.noSerie);
            db.AddInParameter(dbCommand, "@pidTipoEquipo", DbType.Int32, oArticulo.idTipoEquipo);
            db.AddInParameter(dbCommand, "@pidMarca", DbType.Int32, oArticulo.idMarca);
            db.AddInParameter(dbCommand, "@pModelo", DbType.String, oArticulo.modelo);
            db.AddInParameter(dbCommand, "@pProcesador", DbType.String, oArticulo.procesador);
            db.AddInParameter(dbCommand, "@pRAM", DbType.String, oArticulo.ram);
            db.AddInParameter(dbCommand, "@pDiscoDuro", DbType.String, oArticulo.discoDuro);
            db.AddInParameter(dbCommand, "@pidSistema", DbType.Int32, oArticulo.idSistema);
            db.AddInParameter(dbCommand, "@pidProveedor", DbType.Int32, oArticulo.idProveedor);
            db.AddInParameter(dbCommand, "@pFactura", DbType.String, oArticulo.factura);
            db.AddInParameter(dbCommand, "@pFechaCompra", DbType.String, oArticulo.fechaCompra);
            db.AddInParameter(dbCommand, "@pRequisicion", DbType.String, oArticulo.requisicion);
            db.AddInParameter(dbCommand, "@pCentroCostosAdquisicion", DbType.String, oArticulo.centroCostosAdquisicion);
            db.AddInParameter(dbCommand, "@pResponsiva", DbType.Int32, oArticulo.responsiva);
            db.AddInParameter(dbCommand, "@pValorPesos", DbType.Double, oArticulo.valorPesos);
            db.AddInParameter(dbCommand, "@pValorUSD", DbType.Double, oArticulo.valorUSD);
            db.AddInParameter(dbCommand, "@pStock", DbType.String, oArticulo.stock);
            db.AddInParameter(dbCommand, "@pCodigoCastor", DbType.String, oArticulo.codigoCastor);
            db.AddInParameter(dbCommand, "@pidUsuario", DbType.Int32, oArticulo.idUsuario);
            db.AddInParameter(dbCommand, "@pidUbicacion", DbType.Int32, oArticulo.idUbicacion);
            db.AddInParameter(dbCommand, "@pidEstado", DbType.Int32, oArticulo.idEstado);
            db.AddInParameter(dbCommand, "@pObservacion1", DbType.String, oArticulo.observacion1);
            db.AddInParameter(dbCommand, "@pObservacion2", DbType.String, oArticulo.observacion2);
            db.AddInParameter(dbCommand, "@pObservacion3", DbType.String, oArticulo.observacion3);
            db.AddInParameter(dbCommand, "@pPosibleFaltanteFlag", DbType.Boolean, oArticulo.posibleFaltanteFlag);
            db.AddInParameter(dbCommand, "@pCambioRYS", DbType.String, oArticulo.cambioRYS);
            db.AddInParameter(dbCommand, "@pFechaMovimiento", DbType.DateTime, oArticulo.fechaMovimiento);
            db.AddInParameter(dbCommand, "@pResponsivaAnterior", DbType.String, oArticulo.ResponsivaAnterior);
            db.AddInParameter(dbCommand, "@pidUsuarioAnterior", DbType.Int32, oArticulo.IdUsuarioAnterior);
            db.AddInParameter(dbCommand, "@pidUsuarioNuevo", DbType.Int32, oArticulo.IdUsuarioNuevo);
            db.AddInParameter(dbCommand, "@pObservacionesResponsiva", DbType.String, oArticulo.ObservacionesResponsiva);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public List<TipoEquipo> getTiposEquipoAll(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Tipos_Equipo).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Tipos_Equipo).ToString() + ", 0, 0, 0");

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
                        oTipoEquipo.idTipoEquipo = Convert.ToInt32(dr["Valor"]);
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

        public List<Marca> getMarcasAll(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Marcas).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Marcas).ToString() + ", 0, 0, 0");

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
                        oMarca.idMarca = Convert.ToInt32(dr["Valor"]);
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

        public List<Ubicacion> getUbicacionesAll(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Ubicaciones).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Ubicaciones).ToString() + ", 0, 0, 0");

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
                        oUbicacion.idUbicacion = Convert.ToInt32(dr["Valor"]);
                        oUbicacion.descripcion = dr["Descripcion"].ToString();
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

        public List<Usuario> getUsuariosAll(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Usuarios).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Usuarios).ToString() + ", 0, 0, 0");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<Usuario> lstUsuario = new List<Usuario>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Usuario oUsuario = new Usuario();
                        oUsuario.idUsuario = Convert.ToInt32(dr["Valor"]);
                        oUsuario.nombre = dr["Descripcion"].ToString();
                        lstUsuario.Add(oUsuario);
                    }
                }

                return lstUsuario;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public DataTable getEstadosAll(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Estados_Software_Chk).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Estados_Software_Chk).ToString() + ", 0, 0, 0");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Resultados = ds.Tables[0];
                }

                return Resultados;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public DataTable InventarioEquipos(string idTipoEquipo, string idMarca, string idUbicacion, string idUsuario, string Responsiva, string Modelo, string NoSerie, DateTime? FechaMovimientoIni, DateTime? FechaMovimientoFin, string idEstado)
        {
            DataTable MensajeBD = new DataTable("Resultados");
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpR_InventarioEquipos");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@idTipoEquipo", DbType.String, idTipoEquipo);
                db.AddInParameter(selectCommand, "@idMarca", DbType.String, idMarca);
                db.AddInParameter(selectCommand, "@idUbicacion", DbType.String, idUbicacion);
                db.AddInParameter(selectCommand, "@idUsuario", DbType.String, idUsuario);
                db.AddInParameter(selectCommand, "@Responsiva", DbType.String, Responsiva);
                db.AddInParameter(selectCommand, "@Modelo", DbType.String, Modelo);
                db.AddInParameter(selectCommand, "@NoSerie", DbType.String, NoSerie);
                db.AddInParameter(selectCommand, "@FechaMovimientoIni", DbType.DateTime, FechaMovimientoIni);
                db.AddInParameter(selectCommand, "@FechaMovimientoFin", DbType.DateTime, FechaMovimientoFin);
                db.AddInParameter(selectCommand, "@idEstado", DbType.String, idEstado);

                MensajeBD = db.ExecuteDataSet(selectCommand).Tables[0];
            }
            catch (Exception ex)
            {
                MensajeBD = new DataTable("Error");
                DataRow dr;

                MensajeBD.Columns.Add("Error");
                dr = MensajeBD.NewRow();
                dr[0] = ex.Message + " StackTrace: " + ex.StackTrace;
                MensajeBD.Rows.Add(dr);
                MensajeBD.AcceptChanges();
            }

            return MensajeBD;
        }
    }
}

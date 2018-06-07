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
    public class DLReporteGeneral
    {
        public DLReporteGeneral()
        {
        }

        public List<ReporteGeneral> getReporteGeneral()
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            //Database db = DatabaseFactory.CreateDatabase();
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("	  A.idItem AS id ");
            sqlCommand.AppendLine("	, ISNULL(A.NoSerie, '') As NoSerie ");
            sqlCommand.AppendLine("	, A.idTipoEquipo  ");
            sqlCommand.AppendLine("	, TE.Descripcion As TipoEquipo ");
            sqlCommand.AppendLine("	, A.idMarca ");
            sqlCommand.AppendLine("	, M.Descripcion	AS Marca ");
            sqlCommand.AppendLine("	, ISNULL(A.Modelo, '') AS Modelo ");
            sqlCommand.AppendLine("	, ISNULL(A.Procesador, '') as Procesador ");
            sqlCommand.AppendLine("	, ISNULL(A.RAM, '') as RAM ");
            sqlCommand.AppendLine("	, ISNULL(A.DiscoDuro, '') as DiscoDuro ");
            sqlCommand.AppendLine("	, A.idSistema ");
            sqlCommand.AppendLine("	, S.Descripcion AS SistemaOperativo ");
            sqlCommand.AppendLine("	, A.idProveedor ");
            sqlCommand.AppendLine("	, P.Descripcion	as Proveedor ");
            sqlCommand.AppendLine("	, ISNULL(A.Factura, '') as Factura ");
            sqlCommand.AppendLine("	, ISNULL(A.FechaCompra, '') as FechaCompra ");
            sqlCommand.AppendLine("	, ISNULL(A.Requisicion, '') as Requisicion ");
            sqlCommand.AppendLine("	, ISNULL(A.CentroCostosAdquisicion, '') AS CentroCostosAdquisicion ");
            sqlCommand.AppendLine("	, ISNULL(A.Responsiva, '') AS Responsiva ");
            sqlCommand.AppendLine("	, ISNULL(A.ValorPesos, '') AS ValorPesos ");
            sqlCommand.AppendLine("	, ISNULL(A.ValorUSD, '') AS ValorUSD ");
            sqlCommand.AppendLine("	, ISNULL(A.Stock, '') as Stock ");
            sqlCommand.AppendLine("	, ISNULL(A.CodigoCastor, '') AS CodigoCastor ");
            sqlCommand.AppendLine("	, A.idUsuario  ");
            sqlCommand.AppendLine("	, U.Nombre			as UsuarioAsignado ");
            sqlCommand.AppendLine("	, A.idUbicacion  ");
            sqlCommand.AppendLine("	, Ub.Descripcion	AS Ubicacion ");
            sqlCommand.AppendLine("	, A.idEstado ");
            sqlCommand.AppendLine("	, E.Descripcion		AS EstadoConservacion ");
            sqlCommand.AppendLine("	, RTRIM(ISNULL(A.Observacion1, '')) AS Observacion1 ");
            sqlCommand.AppendLine("	, RTRIM(ISNULL(A.Observacion2, '')) AS Observacion2 ");
            sqlCommand.AppendLine("	, RTRIM(ISNULL(A.Observacion3, '')) AS Observacion3 ");
            sqlCommand.AppendLine("	, A.PosibleFaltanteFlag ");
            sqlCommand.AppendLine("	, ISNULL(A.CambioRYS, '') AS CambioRYS ");
            sqlCommand.AppendLine("	, ISNULL(A.FechaMovimiento, '1/1/1900') as FechaMovimiento");
            sqlCommand.AppendLine("FROM Articulo A ");
            sqlCommand.AppendLine("	INNER JOIN TipoEquipo TE WITH(NOLOCK) on A.idTipoEquipo = TE.idTipoEquipo ");
            sqlCommand.AppendLine("	INNER JOIN Marca M	WITH(NOLOCK) ON A.idMarca = M.idMarca ");
            sqlCommand.AppendLine("	INNER JOIN SistemaOperativo S WITH(NOLOCK) ON A.idSistema = S.idSistema ");
            sqlCommand.AppendLine("	INNER JOIN Proveedor P WITH(NOLOCK) ON A.idProveedor = P.idProveedor ");
            sqlCommand.AppendLine("	INNER JOIN Usuario U WITH(NOLOCK) ON A.idUsuario = U.idUsuario ");
            sqlCommand.AppendLine("	INNER JOIN Ubicacion Ub WITH(NOLOCK) ON A.idUbicacion = Ub.idUbicacion ");
            sqlCommand.AppendLine("	INNER JOIN Estado E WITH(NOLOCK) ON A.idEstado = E.idEstado ");
            sqlCommand.AppendLine("ORDER BY A.idItem ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<ReporteGeneral> lstReporteGeneral = new List<ReporteGeneral>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ReporteGeneral oReporteGeneral = new ReporteGeneral();
                        oReporteGeneral.id = Convert.ToInt32(dr["id"]);
                        oReporteGeneral.noSerie = dr["NoSerie"].ToString();
                        oReporteGeneral.idTipoEquipo = Convert.ToInt32(dr["idTipoEquipo"]);
                        oReporteGeneral.tipoEquipo = dr["TipoEquipo"].ToString();
                        oReporteGeneral.idMarca = Convert.ToInt32(dr["idMarca"]);
                        oReporteGeneral.marca = dr["Marca"].ToString();
                        oReporteGeneral.modelo = dr["Modelo"].ToString();
                        oReporteGeneral.procesador = dr["Procesador"].ToString();
                        oReporteGeneral.rAM = dr["RAM"].ToString();
                        oReporteGeneral.discoDuro = dr["DiscoDuro"].ToString();
                        oReporteGeneral.idSistema = Convert.ToInt32(dr["idSistema"]);
                        oReporteGeneral.sistemaOperativo = dr["SistemaOperativo"].ToString();
                        oReporteGeneral.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                        oReporteGeneral.proveedor = dr["Proveedor"].ToString();
                        oReporteGeneral.factura = dr["Factura"].ToString();
                        oReporteGeneral.fechaCompra = dr["FechaCompra"].ToString();
                        oReporteGeneral.requisicion = dr["Requisicion"].ToString();
                        oReporteGeneral.centroCostosAdquisicion = dr["CentroCostosAdquisicion"].ToString();
                        oReporteGeneral.responsiva = dr["Responsiva"].ToString();
                        oReporteGeneral.valorPesos = dr["ValorPesos"].ToString();
                        oReporteGeneral.valorUSD = dr["ValorUSD"].ToString();
                        oReporteGeneral.stock = dr["Stock"].ToString();
                        oReporteGeneral.codigoCastor = dr["CodigoCastor"].ToString();
                        oReporteGeneral.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                        oReporteGeneral.usuarioAsignado = dr["UsuarioAsignado"].ToString();
                        oReporteGeneral.idUbicacion = Convert.ToInt32(dr["idUbicacion"]);
                        oReporteGeneral.ubicacion = dr["Ubicacion"].ToString();
                        oReporteGeneral.idEstado = Convert.ToInt32(dr["idEstado"]);
                        oReporteGeneral.estadoConservacion = dr["EstadoConservacion"].ToString();
                        oReporteGeneral.observacion1 = dr["observacion1"].ToString();
                        oReporteGeneral.observacion2 = dr["observacion2"].ToString();
                        oReporteGeneral.observacion3 = dr["observacion3"].ToString();
                        oReporteGeneral.posibleFaltanteFlag = Convert.ToBoolean(dr["PosibleFaltanteFlag"]);
                        oReporteGeneral.cambioRYS = dr["CambioRYS"].ToString();
                        oReporteGeneral.fechaMovimiento = dr["FechaMovimiento"].ToString();

                        lstReporteGeneral.Add(oReporteGeneral);
                    }
                }
                return lstReporteGeneral;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }
    }
}
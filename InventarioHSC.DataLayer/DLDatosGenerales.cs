using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using InventarioHSC.Model;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace InventarioHSC.DataLayer
{
    public class DLDatosGenerales
    {
        public DLDatosGenerales()
        {
        }

        public List<DatosGenerales> getDatosGenerales(string[] sParametros)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            if (sParametros.Length > 1)
            {
                switch (sParametros[0].ToString())
                {
                    case "Reportes":
                        sqlCommand.AppendLine("SELECT ");
                        sqlCommand.AppendLine("		USU.Nombre Usuario, ");
                        sqlCommand.AppendLine("		CASE ");
                        sqlCommand.AppendLine("			WHEN ISNULL(AC.IdUbicacion, 0) <> 0 AND AC.IdUbicacion <> 1 THEN UBIAC.Descripcion");
                        sqlCommand.AppendLine("			WHEN ISNULL(JCB.IdUbicacion, 0) <> 0 AND JCB.IdUbicacion <> 1 THEN UBIJCB.Descripcion");
                        sqlCommand.AppendLine("			ELSE UBI.Descripcion ");
                        sqlCommand.AppendLine("		END AS Ubicacion, ");
                        sqlCommand.AppendLine("		REG.Nombre Region, ");
                        sqlCommand.AppendLine("		TEQ.Descripcion TipoActivo, ");
                        sqlCommand.AppendLine("		ART.NoSerie, ");
                        sqlCommand.AppendLine("		ART.CodigoCastor, ");
                        sqlCommand.AppendLine("		ART.Observacion1,");
                        sqlCommand.AppendLine("		ART.Observacion2, ");
                        sqlCommand.AppendLine("		ART.Observacion3, ");
                        sqlCommand.AppendLine("		CASE ");
                        sqlCommand.AppendLine("			WHEN ART.idTipoEquipo  = 1 OR ART.idTipoEquipo  = 2 OR ART.idTipoEquipo = 3 THEN ");
                        sqlCommand.AppendLine("				'MODELO:' + ISNULL(LTRIM(RTRIM(ART.Modelo)), '') + ");
                        sqlCommand.AppendLine("				', PROCESADOR: ' + ISNULL(ART.Procesador, '') + ");
                        sqlCommand.AppendLine("				', RAM: ' + ISNULL(ART.RAM, '') + ");
                        sqlCommand.AppendLine("				', DISCO DURO: ' + ISNULL(ART.DiscoDuro, '') + ");
                        sqlCommand.AppendLine("				', SISTEMA OPERATIVO: ' + ISNULL(SO.Descripcion, '') + ");
                        sqlCommand.AppendLine("				', MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                        sqlCommand.AppendLine("				', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                        sqlCommand.AppendLine("			ELSE ");
                        sqlCommand.AppendLine("				'MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                        sqlCommand.AppendLine("				', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                        sqlCommand.AppendLine("		END AS Observacion, ");
                        sqlCommand.AppendLine("		ART.Responsiva,");
                        sqlCommand.AppendLine("		CASE ");
                        sqlCommand.AppendLine("			WHEN ISNULL(JCB.NoSerie, '') = '' AND ISNULL(AC.NoSerie, '') = '' THEN 'HSC' ");
                        sqlCommand.AppendLine("			WHEN ISNULL(AC.NoSerie, '') <> '' THEN 'CORP' ");
                        sqlCommand.AppendLine("			WHEN ISNULL(JCB.NoSerie, '') <> '' THEN 'JCB' ");
                        sqlCommand.AppendLine("		END Tipo ");
                        sqlCommand.AppendLine("FROM Articulo ART ");
                        sqlCommand.AppendLine("LEFT JOIN ");
                        sqlCommand.AppendLine("	ArticuloJCB JCB ON ");
                        sqlCommand.AppendLine("	ART.NoSerie = JCB.NoSerie ");
                        sqlCommand.AppendLine("LEFT JOIN ");
                        sqlCommand.AppendLine("	ArticuloCorporativo AC ON ");
                        sqlCommand.AppendLine("	ART.NoSerie = AC.NoSerie ");
                        sqlCommand.AppendLine("INNER JOIN ");
                        sqlCommand.AppendLine("	TipoEquipo TEQ ON ");
                        sqlCommand.AppendLine("	ART.idTipoEquipo = TEQ.idTipoEquipo ");
                        sqlCommand.AppendLine("LEFT JOIN ");
                        sqlCommand.AppendLine("	Usuario USU ON ");
                        sqlCommand.AppendLine("	ART.idUsuario = USU.idUsuario	");
                        sqlCommand.AppendLine("LEFT JOIN ");
                        sqlCommand.AppendLine("	Ubicacion UBI ON");
                        sqlCommand.AppendLine("	ART.idUbicacion = UBI.idUbicacion ");
                        sqlCommand.AppendLine("AND UBI.Estatus = 1 ");
                        sqlCommand.AppendLine("LEFT JOIN ");
                        sqlCommand.AppendLine("	Ubicacion UBIJCB ON ");
                        sqlCommand.AppendLine("	JCB.idUbicacion = UBIJCB.idUbicacion ");
                        sqlCommand.AppendLine("AND UBIJCB.Estatus = 1 ");
                        sqlCommand.AppendLine("LEFT JOIN ");
                        sqlCommand.AppendLine("	Ubicacion UBIAC ON ");
                        sqlCommand.AppendLine("	AC.idUbicacion = UBIAC.idUbicacion ");
                        sqlCommand.AppendLine("AND UBIAC.Estatus = 1 ");
                        sqlCommand.AppendLine("LEFT JOIN ");
                        sqlCommand.AppendLine("	Region REG ON ");
                        sqlCommand.AppendLine("	UBI.idRegion = REG.idRegion ");
                        sqlCommand.AppendLine("AND REG.Estatus = 1 ");
                        sqlCommand.AppendLine("LEFT JOIN ");
                        sqlCommand.AppendLine("	Marca MAR ON ");
                        sqlCommand.AppendLine("	ART.idMarca = MAR.idMarca ");
                        sqlCommand.AppendLine("LEFT JOIN ");
                        sqlCommand.AppendLine("	Proveedor PRO ON ");
                        sqlCommand.AppendLine("	ART.idProveedor = PRO.idProveedor ");
                        sqlCommand.AppendLine("LEFT JOIN ");
                        sqlCommand.AppendLine("	SistemaOperativo SO ON ");
                        sqlCommand.AppendLine("	ART.idSistema = SO.idSistema ");

                        switch (sParametros[1].ToString())
                        {
                            case "1":
                                sqlCommand.AppendLine("WHERE ART.idUbicacion = @idUbicacion ");
                                sqlCommand.AppendLine("ORDER BY USU.Nombre, ART.NoSerie, JCB.NoSerie, AC.NoSerie ");
                                break;

                            case "2":
                                sqlCommand.AppendLine("WHERE USU.Nombre = @Nombre ");
                                sqlCommand.AppendLine("ORDER BY USU.Nombre, ART.NoSerie, JCB.NoSerie, AC.NoSerie ");
                                break;

                            case "3":
                                sqlCommand.AppendLine("WHERE ART.Responsiva = @Responsiva ");
                                sqlCommand.AppendLine("ORDER BY USU.Nombre, ART.NoSerie, JCB.NoSerie, AC.NoSerie");
                                break;

                            case "4":
                                sqlCommand.AppendLine("WHERE ART.idTipoEquipo = @idTipoEquipo ");
                                sqlCommand.AppendLine("AND ART.idUbicacion = @idUbicacion ");
                                sqlCommand.AppendLine("ORDER BY USU.Nombre, ART.NoSerie, JCB.NoSerie, AC.NoSerie ");
                                break;

                            case "5":
                                //sqlCommand.Remove(0, sqlCommand.Length - 1);
                                sqlCommand.AppendLine("SELECT ");
                                sqlCommand.AppendLine("		USU.Nombre Usuario, ");
                                sqlCommand.AppendLine("		CASE ");
                                sqlCommand.AppendLine("			WHEN ISNULL(AC.IdUbicacion, 0) <> 0 AND AC.IdUbicacion <> 1 THEN UBIAC.Descripcion");
                                sqlCommand.AppendLine("			WHEN ISNULL(JCB.IdUbicacion, 0) <> 0 AND JCB.IdUbicacion <> 1 THEN UBIJCB.Descripcion");
                                sqlCommand.AppendLine("			ELSE UBI.Descripcion ");
                                sqlCommand.AppendLine("		END AS Ubicacion, ");
                                sqlCommand.AppendLine("		REG.Nombre Region, ");
                                sqlCommand.AppendLine("		TEQ.Descripcion TipoActivo, ");
                                sqlCommand.AppendLine("		ART.NoSerie, ");
                                sqlCommand.AppendLine("		ART.CodigoCastor, ");
                                sqlCommand.AppendLine("		ART.Observacion1, ");
                                sqlCommand.AppendLine("		ART.Observacion2, ");
                                sqlCommand.AppendLine("		ART.Observacion3, ");
                                sqlCommand.AppendLine("		CASE ");
                                sqlCommand.AppendLine("			WHEN ART.idTipoEquipo  = 1 OR ART.idTipoEquipo  = 2 OR ART.idTipoEquipo = 3 THEN ");
                                sqlCommand.AppendLine("				'MODELO:' + ISNULL(LTRIM(RTRIM(ART.Modelo)), '') + ");
                                sqlCommand.AppendLine("				', PROCESADOR: ' + ISNULL(ART.Procesador, '') + ");
                                sqlCommand.AppendLine("				', RAM: ' + ISNULL(ART.RAM, '') + ");
                                sqlCommand.AppendLine("				', DISCO DURO: ' + ISNULL(ART.DiscoDuro, '') + ");
                                sqlCommand.AppendLine("				', SISTEMA OPERATIVO: ' + ISNULL(SO.Descripcion, '') + ");
                                sqlCommand.AppendLine("				', MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                                sqlCommand.AppendLine("				', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                                sqlCommand.AppendLine("			ELSE ");
                                sqlCommand.AppendLine("				'MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                                sqlCommand.AppendLine("				', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                                sqlCommand.AppendLine("		END AS Observacion, ");
                                sqlCommand.AppendLine("		ART.Responsiva, ");
                                sqlCommand.AppendLine("		CASE ");
                                sqlCommand.AppendLine("			WHEN ISNULL(JCB.NoSerie, '') = '' AND ISNULL(AC.NoSerie, '') = '' THEN 'HSC' ");
                                sqlCommand.AppendLine("			WHEN ISNULL(AC.NoSerie, '') <> '' THEN 'CORP' ");
                                sqlCommand.AppendLine("			WHEN ISNULL(JCB.NoSerie, '') <> '' THEN 'JCB' ");
                                sqlCommand.AppendLine("		END Tipo, ");
                                sqlCommand.AppendLine("		TM.Descripcion, ");
                                sqlCommand.AppendLine("		CONVERT(VARCHAR(10), HM.fechaMovimiento, 103) FechaMov,");
                                sqlCommand.AppendLine("		CONVERT(VARCHAR(10), HM.fechaTransaccion, 103) FechaTran");
                                sqlCommand.AppendLine("FROM Articulo ART ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	ArticuloCorporativo AC ON");
                                sqlCommand.AppendLine("	ART.NoSerie = AC.NoSerie");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	ArticuloJCB JCB ON");
                                sqlCommand.AppendLine("	ART.NoSerie = JCB.NoSerie");
                                sqlCommand.AppendLine("INNER JOIN ");
                                sqlCommand.AppendLine("	Historico_Movimiento HM ON");
                                sqlCommand.AppendLine("	HM.idItem = ART.idItem");
                                sqlCommand.AppendLine("INNER JOIN");
                                sqlCommand.AppendLine("	TipoMovimiento TM ON");
                                sqlCommand.AppendLine("	HM.idTipoMovimiento = tm.idTipoMovimiento");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	TipoEquipo TEQ ON ");
                                sqlCommand.AppendLine("	ART.idTipoEquipo = TEQ.idTipoEquipo ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	Usuario USU ON ");
                                sqlCommand.AppendLine("	ART.idUsuario = USU.idUsuario ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	Ubicacion UBI ON ");
                                sqlCommand.AppendLine("	ART.idUbicacion = UBI.idUbicacion ");
                                sqlCommand.AppendLine("AND UBI.Estatus = 1 ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	Ubicacion UBIJCB ON ");
                                sqlCommand.AppendLine("	JCB.idUbicacion = UBIJCB.idUbicacion ");
                                sqlCommand.AppendLine("AND UBIJCB.Estatus = 1 ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	Ubicacion UBIAC ON ");
                                sqlCommand.AppendLine("	AC.idUbicacion = UBIAC.idUbicacion ");
                                sqlCommand.AppendLine("AND UBIAC.Estatus = 1 ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	Region REG ON ");
                                sqlCommand.AppendLine("	UBI.idRegion = REG.idRegion ");
                                sqlCommand.AppendLine("AND REG.Estatus = 1 ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	Marca MAR ON ");
                                sqlCommand.AppendLine("	ART.idMarca = MAR.idMarca ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	Proveedor PRO ON ");
                                sqlCommand.AppendLine("	ART.idProveedor = PRO.idProveedor ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	SistemaOperativo SO ON ");
                                sqlCommand.AppendLine("	ART.idSistema = SO.idSistema");
                                sqlCommand.AppendLine("WHERE ART.NoSerie = @NoSerie");
                                break;

                            case "6":
                                //sqlCommand.Remove(0, sqlCommand.Length - 1);
                                sqlCommand.AppendLine("	SELECT ");
                                sqlCommand.AppendLine("			USU.Nombre Usuario, ");
                                sqlCommand.AppendLine("			UBI.Descripcion Ubicacion, ");
                                sqlCommand.AppendLine("			REG.Nombre Region, ");
                                sqlCommand.AppendLine("			TEQ.Descripcion TipoActivo, ");
                                sqlCommand.AppendLine("			JCB.NoSerie, ");
                                sqlCommand.AppendLine("			JCB.CodigoCastor, ");
                                sqlCommand.AppendLine("			JCB.Observacion1,");
                                sqlCommand.AppendLine("			JCB.Observacion2, ");
                                sqlCommand.AppendLine("			JCB.Observacion3, ");
                                sqlCommand.AppendLine("		    CASE ");
                                sqlCommand.AppendLine("			    WHEN JCB.idTipoEquipo  = 1 OR JCB.idTipoEquipo  = 2 OR JCB.idTipoEquipo = 3 THEN ");
                                sqlCommand.AppendLine("				    'MODELO:' + ISNULL(LTRIM(RTRIM(JCB.Modelo)), '') + ");
                                sqlCommand.AppendLine("				    ', PROCESADOR: ' + ISNULL(JCB.Procesador, '') + ");
                                sqlCommand.AppendLine("				    ', RAM: ' + ISNULL(JCB.RAM, '') + ");
                                sqlCommand.AppendLine("				    ', DISCO DURO: ' + ISNULL(JCB.DiscoDuro, '') + ");
                                sqlCommand.AppendLine("				    ', SISTEMA OPERATIVO: ' + ISNULL(SO.Descripcion, '') + ");
                                sqlCommand.AppendLine("				    ', MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                                sqlCommand.AppendLine("				    ', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                                sqlCommand.AppendLine("			    ELSE ");
                                sqlCommand.AppendLine("				    'MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                                sqlCommand.AppendLine("				    ', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                                sqlCommand.AppendLine("		    END AS Observacion, ");
                                sqlCommand.AppendLine("			JCB.Responsiva, ");
                                sqlCommand.AppendLine("			'JCB' Tipo ");
                                sqlCommand.AppendLine("	FROM Articulo ART ");
                                sqlCommand.AppendLine("	LEFT JOIN  ");
                                sqlCommand.AppendLine("		ArticuloJCB JCB ON");
                                sqlCommand.AppendLine("		ART.NoSerie = JCB.NoSerie");
                                sqlCommand.AppendLine("	LEFT JOIN ");
                                sqlCommand.AppendLine("		TipoEquipo TEQ ON ");
                                sqlCommand.AppendLine("		JCB.idTipoEquipo = TEQ.idTipoEquipo ");
                                sqlCommand.AppendLine("	LEFT JOIN ");
                                sqlCommand.AppendLine("		Usuario USU ON ");
                                sqlCommand.AppendLine("		JCB.idUsuario = USU.idUsuario ");
                                sqlCommand.AppendLine("	LEFT JOIN ");
                                sqlCommand.AppendLine("		Ubicacion UBI ON ");
                                sqlCommand.AppendLine("		JCB.idUbicacion = UBI.idUbicacion ");
                                sqlCommand.AppendLine("	AND UBI.Estatus = 1 ");
                                sqlCommand.AppendLine("	LEFT JOIN ");
                                sqlCommand.AppendLine("		Region REG ON ");
                                sqlCommand.AppendLine("		UBI.idRegion = REG.idRegion ");
                                sqlCommand.AppendLine("	AND REG.Estatus = 1 ");
                                sqlCommand.AppendLine("	LEFT JOIN ");
                                sqlCommand.AppendLine("		Marca MAR ON ");
                                sqlCommand.AppendLine("		JCB.idMarca = MAR.idMarca ");
                                sqlCommand.AppendLine("	LEFT JOIN ");
                                sqlCommand.AppendLine("		Proveedor PRO ON ");
                                sqlCommand.AppendLine("		JCB.idProveedor = PRO.idProveedor ");
                                sqlCommand.AppendLine("	LEFT JOIN ");
                                sqlCommand.AppendLine("		SistemaOperativo SO ON ");
                                sqlCommand.AppendLine("		JCB.idSistema = SO.idSistema");
                                sqlCommand.AppendLine("	WHERE JCB.NoSerie = @NoSerie");
                                sqlCommand.AppendLine("	UNION ALL ");
                                sqlCommand.AppendLine("	SELECT ");
                                sqlCommand.AppendLine("			USU.Nombre Usuario, ");
                                sqlCommand.AppendLine("			UBI.Descripcion Ubicacion, ");
                                sqlCommand.AppendLine("			REG.Nombre Region, ");
                                sqlCommand.AppendLine("			TEQ.Descripcion TipoActivo, ");
                                sqlCommand.AppendLine("			HSC.NoSerie, ");
                                sqlCommand.AppendLine("			HSC.CodigoCastor, ");
                                sqlCommand.AppendLine("			HSC.Observacion1,");
                                sqlCommand.AppendLine("			HSC.Observacion2, ");
                                sqlCommand.AppendLine("			HSC.Observacion3, ");
                                sqlCommand.AppendLine("		    CASE ");
                                sqlCommand.AppendLine("			    WHEN HSC.idTipoEquipo  = 1 OR HSC.idTipoEquipo  = 2 OR HSC.idTipoEquipo = 3 THEN ");
                                sqlCommand.AppendLine("				    'MODELO:' + ISNULL(LTRIM(RTRIM(HSC.Modelo)), '') + ");
                                sqlCommand.AppendLine("				    ', PROCESADOR: ' + ISNULL(HSC.Procesador, '') + ");
                                sqlCommand.AppendLine("				    ', RAM: ' + ISNULL(HSC.RAM, '') + ");
                                sqlCommand.AppendLine("				    ', DISCO DURO: ' + ISNULL(HSC.DiscoDuro, '') + ");
                                sqlCommand.AppendLine("				    ', SISTEMA OPERATIVO: ' + ISNULL(SO.Descripcion, '') + ");
                                sqlCommand.AppendLine("				    ', MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                                sqlCommand.AppendLine("				    ', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                                sqlCommand.AppendLine("			    ELSE ");
                                sqlCommand.AppendLine("				    'MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                                sqlCommand.AppendLine("				    ', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                                sqlCommand.AppendLine("		    END AS Observacion, ");
                                sqlCommand.AppendLine("			HSC.Responsiva, ");
                                sqlCommand.AppendLine("			'CORP' Tipo ");
                                sqlCommand.AppendLine("	FROM Articulo ART ");
                                sqlCommand.AppendLine("	LEFT JOIN  ");
                                sqlCommand.AppendLine("		ArticuloCorporativo HSC ON");
                                sqlCommand.AppendLine("		ART.NoSerie = HSC.NoSerie");
                                sqlCommand.AppendLine("	LEFT JOIN ");
                                sqlCommand.AppendLine("		TipoEquipo TEQ ON ");
                                sqlCommand.AppendLine("		HSC.idTipoEquipo = TEQ.idTipoEquipo ");
                                sqlCommand.AppendLine("	LEFT JOIN ");
                                sqlCommand.AppendLine("		Usuario USU ON ");
                                sqlCommand.AppendLine("		HSC.idUsuario = USU.idUsuario ");
                                sqlCommand.AppendLine("	LEFT JOIN ");
                                sqlCommand.AppendLine("		Ubicacion UBI ON ");
                                sqlCommand.AppendLine("		HSC.idUbicacion = UBI.idUbicacion ");
                                sqlCommand.AppendLine("	AND UBI.Estatus = 1 ");
                                sqlCommand.AppendLine("	LEFT JOIN ");
                                sqlCommand.AppendLine("		Region REG ON ");
                                sqlCommand.AppendLine("		UBI.idRegion = REG.idRegion ");
                                sqlCommand.AppendLine("	AND REG.Estatus = 1 ");
                                sqlCommand.AppendLine("	LEFT JOIN ");
                                sqlCommand.AppendLine("		Marca MAR ON ");
                                sqlCommand.AppendLine("		HSC.idMarca = MAR.idMarca ");
                                sqlCommand.AppendLine("	LEFT JOIN ");
                                sqlCommand.AppendLine("		Proveedor PRO ON ");
                                sqlCommand.AppendLine("		HSC.idProveedor = PRO.idProveedor ");
                                sqlCommand.AppendLine("	LEFT JOIN ");
                                sqlCommand.AppendLine("		SistemaOperativo SO ON ");
                                sqlCommand.AppendLine("		HSC.idSistema = SO.idSistema");
                                sqlCommand.AppendLine("	WHERE HSC.NoSerie = @NoSerie");
                                break;
                        }
                        break;

                    case "DatosGenerales":
                        if (sParametros.Length > 1)
                        {
                            if (sParametros[1].ToString() != string.Empty)
                            {
                                sqlCommand.AppendLine("SELECT ");
                                sqlCommand.AppendLine("		USU.Nombre Usuario, ");
                                sqlCommand.AppendLine("		CASE ");
                                sqlCommand.AppendLine("			WHEN ISNULL(AC.IdUbicacion, 0) <> 0 AND AC.IdUbicacion <> 1 THEN UBIAC.Descripcion");
                                sqlCommand.AppendLine("			WHEN ISNULL(JCB.IdUbicacion, 0) <> 0 AND JCB.IdUbicacion <> 1 THEN UBIJCB.Descripcion");
                                sqlCommand.AppendLine("			ELSE UBI.Descripcion ");
                                sqlCommand.AppendLine("		END AS Ubicacion, ");
                                sqlCommand.AppendLine("		REG.Nombre Region, ");
                                sqlCommand.AppendLine("		TEQ.Descripcion TipoActivo, ");
                                sqlCommand.AppendLine("		ART.NoSerie, ");
                                sqlCommand.AppendLine("		ART.CodigoCastor, ");
                                sqlCommand.AppendLine("		ART.Observacion1,");
                                sqlCommand.AppendLine("		ART.Observacion2, ");
                                sqlCommand.AppendLine("		ART.Observacion3, ");
                                sqlCommand.AppendLine("		CASE ");
                                sqlCommand.AppendLine("			WHEN ART.idTipoEquipo  = 1 OR ART.idTipoEquipo  = 2 OR ART.idTipoEquipo = 3 THEN ");
                                sqlCommand.AppendLine("				'MODELO:' + ISNULL(LTRIM(RTRIM(ART.Modelo)), '') + ");
                                sqlCommand.AppendLine("				', PROCESADOR: ' + ISNULL(ART.Procesador, '') + ");
                                sqlCommand.AppendLine("				', RAM: ' + ISNULL(ART.RAM, '') + ");
                                sqlCommand.AppendLine("				', DISCO DURO: ' + ISNULL(ART.DiscoDuro, '') + ");
                                sqlCommand.AppendLine("				', SISTEMA OPERATIVO: ' + ISNULL(SO.Descripcion, '') + ");
                                sqlCommand.AppendLine("				', MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                                sqlCommand.AppendLine("				', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                                sqlCommand.AppendLine("			ELSE ");
                                sqlCommand.AppendLine("				'MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                                sqlCommand.AppendLine("				', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                                sqlCommand.AppendLine("		END AS Observacion, ");
                                sqlCommand.AppendLine("		ART.Responsiva,");
                                sqlCommand.AppendLine("		CASE ");
                                sqlCommand.AppendLine("			WHEN ISNULL(JCB.NoSerie, '') = '' AND ISNULL(AC.NoSerie, '') = '' THEN 'HSC' ");
                                sqlCommand.AppendLine("			WHEN ISNULL(AC.NoSerie, '') <> '' THEN 'CORP' ");
                                sqlCommand.AppendLine("			WHEN ISNULL(JCB.NoSerie, '') <> '' THEN 'JCB' ");
                                sqlCommand.AppendLine("		END Tipo ");
                                sqlCommand.AppendLine("FROM Articulo ART ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	ArticuloJCB JCB ON ");
                                sqlCommand.AppendLine("	ART.NoSerie = JCB.NoSerie ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	ArticuloCorporativo AC ON ");
                                sqlCommand.AppendLine("	ART.NoSerie = AC.NoSerie ");
                                sqlCommand.AppendLine("INNER JOIN ");
                                sqlCommand.AppendLine("	TipoEquipo TEQ ON ");
                                sqlCommand.AppendLine("	ART.idTipoEquipo = TEQ.idTipoEquipo ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	Usuario USU ON ");
                                sqlCommand.AppendLine("	ART.idUsuario = USU.idUsuario	");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	Ubicacion UBI ON");
                                sqlCommand.AppendLine("	ART.idUbicacion = UBI.idUbicacion ");
                                sqlCommand.AppendLine("AND UBI.Estatus = 1 ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	Ubicacion UBIJCB ON ");
                                sqlCommand.AppendLine("	JCB.idUbicacion = UBIJCB.idUbicacion ");
                                sqlCommand.AppendLine("AND UBIJCB.Estatus = 1 ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	Ubicacion UBIAC ON ");
                                sqlCommand.AppendLine("	AC.idUbicacion = UBIAC.idUbicacion ");
                                sqlCommand.AppendLine("AND UBIAC.Estatus = 1 ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	Region REG ON ");
                                sqlCommand.AppendLine("	UBI.idRegion = REG.idRegion ");
                                sqlCommand.AppendLine("AND REG.Estatus = 1 ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	Marca MAR ON ");
                                sqlCommand.AppendLine("	ART.idMarca = MAR.idMarca ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	Proveedor PRO ON ");
                                sqlCommand.AppendLine("	ART.idProveedor = PRO.idProveedor ");
                                sqlCommand.AppendLine("LEFT JOIN ");
                                sqlCommand.AppendLine("	SistemaOperativo SO ON ");
                                sqlCommand.AppendLine("	ART.idSistema = SO.idSistema ");
                                sqlCommand.AppendLine("WHERE TEQ.Descripcion LIKE '%" + sParametros[1].ToString() + "%' ");
                                sqlCommand.AppendLine("ORDER BY USU.Nombre, ART.NoSerie, JCB.NoSerie, AC.NoSerie ");
                            }
                        }
                        break;
                }
            }

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<DatosGenerales> lstDatosGenerales = new List<DatosGenerales>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DatosGenerales oDatosGenerales = new DatosGenerales();

                        oDatosGenerales.Usuario = dr["Usuario"].ToString();
                        oDatosGenerales.Ubicacion = dr["Ubicacion"].ToString();
                        oDatosGenerales.Region = dr["Region"].ToString();
                        oDatosGenerales.TipoActivo = dr["TipoActivo"].ToString();
                        oDatosGenerales.NoSerie = dr["NoSerie"].ToString();
                        oDatosGenerales.CodigoCastor = dr["CodigoCastor"].ToString();
                        oDatosGenerales.Observacion_1 = dr["Observacion1"].ToString();
                        oDatosGenerales.Observacion_2 = dr["Observacion2"].ToString();
                        oDatosGenerales.Observacion_3 = dr["Observacion3"].ToString();
                        oDatosGenerales.Observacion = dr["Observacion"].ToString();
                        oDatosGenerales.Responsiva = dr["Responsiva"].ToString();
                        oDatosGenerales.Tipo = dr["Tipo"].ToString();
                        lstDatosGenerales.Add(oDatosGenerales);
                    }
                }
                return lstDatosGenerales;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public DataView getDatosGenerales(string sTipoActivo)
        {
            DataView dvDG = new DataView();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		USU.Nombre Usuario, ");
            sqlCommand.AppendLine("		CASE ");
            sqlCommand.AppendLine("			WHEN ISNULL(AC.IdUbicacion, 0) <> 0 AND AC.IdUbicacion <> 1 THEN UBIAC.Descripcion");
            sqlCommand.AppendLine("			WHEN ISNULL(JCB.IdUbicacion, 0) <> 0 AND JCB.IdUbicacion <> 1 THEN UBIJCB.Descripcion");
            sqlCommand.AppendLine("			ELSE UBI.Descripcion ");
            sqlCommand.AppendLine("		END AS Ubicacion, ");
            sqlCommand.AppendLine("		REG.Nombre Region, ");
            sqlCommand.AppendLine("		TEQ.Descripcion TipoActivo, ");
            sqlCommand.AppendLine("		ART.NoSerie, ");
            sqlCommand.AppendLine("		ART.CodigoCastor, ");
            sqlCommand.AppendLine("		ART.Observacion1,");
            sqlCommand.AppendLine("		ART.Observacion2, ");
            sqlCommand.AppendLine("		ART.Observacion3, ");
            sqlCommand.AppendLine("		CASE ");
            sqlCommand.AppendLine("			WHEN ART.idTipoEquipo  = 1 OR ART.idTipoEquipo  = 2 OR ART.idTipoEquipo = 3 THEN ");
            sqlCommand.AppendLine("				'MODELO:' + ISNULL(LTRIM(RTRIM(ART.Modelo)), '') + ");
            sqlCommand.AppendLine("				', PROCESADOR: ' + ISNULL(ART.Procesador, '') + ");
            sqlCommand.AppendLine("				', RAM: ' + ISNULL(ART.RAM, '') + ");
            sqlCommand.AppendLine("				', DISCO DURO: ' + ISNULL(ART.DiscoDuro, '') + ");
            sqlCommand.AppendLine("				', SISTEMA OPERATIVO: ' + ISNULL(SO.Descripcion, '') + ");
            sqlCommand.AppendLine("				', MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
            sqlCommand.AppendLine("				', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
            sqlCommand.AppendLine("			ELSE ");
            sqlCommand.AppendLine("				'MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
            sqlCommand.AppendLine("				', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
            sqlCommand.AppendLine("		END AS Observacion, ");
            sqlCommand.AppendLine("		ART.Responsiva,");
            sqlCommand.AppendLine("		CASE ");
            sqlCommand.AppendLine("			WHEN ISNULL(JCB.NoSerie, '') = '' AND ISNULL(AC.NoSerie, '') = '' THEN 'HSC' ");
            sqlCommand.AppendLine("			WHEN ISNULL(AC.NoSerie, '') <> '' THEN 'CORP' ");
            sqlCommand.AppendLine("			WHEN ISNULL(JCB.NoSerie, '') <> '' THEN 'JCB' ");
            sqlCommand.AppendLine("		END Tipo ");
            sqlCommand.AppendLine("FROM Articulo ART ");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("	ArticuloJCB JCB ON ");
            sqlCommand.AppendLine("	ART.NoSerie = JCB.NoSerie ");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("	ArticuloCorporativo AC ON ");
            sqlCommand.AppendLine("	ART.NoSerie = AC.NoSerie ");
            sqlCommand.AppendLine("INNER JOIN ");
            sqlCommand.AppendLine("	TipoEquipo TEQ ON ");
            sqlCommand.AppendLine("	ART.idTipoEquipo = TEQ.idTipoEquipo ");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("	Usuario USU ON ");
            sqlCommand.AppendLine("	ART.idUsuario = USU.idUsuario	");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("	Ubicacion UBI ON");
            sqlCommand.AppendLine("	ART.idUbicacion = UBI.idUbicacion ");
            sqlCommand.AppendLine("AND UBI.Estatus = 1 ");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("	Ubicacion UBIJCB ON ");
            sqlCommand.AppendLine("	JCB.idUbicacion = UBIJCB.idUbicacion ");
            sqlCommand.AppendLine("AND UBIJCB.Estatus = 1 ");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("	Ubicacion UBIAC ON ");
            sqlCommand.AppendLine("	AC.idUbicacion = UBIAC.idUbicacion ");
            sqlCommand.AppendLine("AND UBIAC.Estatus = 1 ");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("	Region REG ON ");
            sqlCommand.AppendLine("	UBI.idRegion = REG.idRegion ");
            sqlCommand.AppendLine("AND REG.Estatus = 1 ");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("	Marca MAR ON ");
            sqlCommand.AppendLine("	ART.idMarca = MAR.idMarca ");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("	Proveedor PRO ON ");
            sqlCommand.AppendLine("	ART.idProveedor = PRO.idProveedor ");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("	SistemaOperativo SO ON ");
            sqlCommand.AppendLine("	ART.idSistema = SO.idSistema ");
            sqlCommand.AppendLine("WHERE TEQ.Descripcion LIKE '%" + sTipoActivo + "%' ");
            sqlCommand.AppendLine("ORDER BY USU.Nombre, ART.NoSerie, JCB.NoSerie, AC.NoSerie ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                dvDG = db.ExecuteDataSet(selectCommand).Tables[0].DefaultView;

                return dvDG;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void EstablecerParametroSistema(string Parametro, string Valor)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpU_EstablecerParametroSistema");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Par_Descripcion", DbType.String, Parametro);
                db.AddInParameter(selectCommand, "@Par_Valor", DbType.String, Valor);

                db.ExecuteDataSet(selectCommand);
            }
            catch { }
        }

        public string ObtenerParametroSistema(string Parametro)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_ObtenerParametroSistema");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Parametro", DbType.String, Parametro);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0)
                {
                    if (MensajeBD.Tables[0].Rows.Count > 0)
                        MsjBD = MensajeBD.Tables[0].Rows[0][1].ToString();
                }
            }
            catch { }

            return MsjBD;
        }

        public DataTable TestScript(string Query, string Cnx)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            DataTable Tabla = new DataTable();
            SqlTransaction trans;

            try
            {
                cn = new SqlConnection(Cnx);

                cn.Open();
                trans = cn.BeginTransaction();
                cmd = new SqlCommand(Query, cn, trans);
                cmd.CommandType = CommandType.Text;
                Tabla.Load(cmd.ExecuteReader());

                trans.Rollback();
            }
            catch (Exception ex)
            {
                Tabla = new DataTable();
                DataRow dr;

                Tabla.Columns.Add("Error");
                dr = Tabla.NewRow();
                dr[0] = ex.Message;
                Tabla.Rows.Add(dr);
                Tabla.AcceptChanges();
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

            return Tabla;
        }

        #region Documentos

        public DataTable ObtenerDocumentosUsuario(string UserName, Int16 Finalizado)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_ObtenerDocumentosUsuario");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);
                db.AddInParameter(selectCommand, "@Finalizado", DbType.Int16, Finalizado);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MensajeBD = new DataSet();
                DataTable Errores = new DataTable("Error");
                DataRow dr;

                Errores.Columns.Add("Error");
                dr = Errores.NewRow();
                dr[0] = ex.Message;
                Errores.Rows.Add(dr);
                Errores.AcceptChanges();

                MensajeBD.Tables.Add(Errores);
            }

            return MensajeBD.Tables[0];
        }

        public string ActualizaArchivo(string UserName, string DocU_Nombre, bool DocU_Finalizado, bool DocU_Eliminado = false, string DocU_Observaciones = null)
        {
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;
            string MsjBD = "";

            try
            {
                if (!string.IsNullOrWhiteSpace(DocU_Observaciones) && DocU_Observaciones.Length > 500)
                    DocU_Observaciones = DocU_Observaciones.Substring(0, 500);

                selectCommand = db.GetSqlStringCommand("stpU_DocumentosUsuario");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);
                db.AddInParameter(selectCommand, "@DocU_Nombre", DbType.String, DocU_Nombre);
                db.AddInParameter(selectCommand, "@DocU_Finalizado", DbType.Boolean, DocU_Finalizado);
                db.AddInParameter(selectCommand, "@DocU_Eliminado", DbType.Boolean, DocU_Eliminado);
                db.AddInParameter(selectCommand, "@DocU_Observaciones", DbType.String, DocU_Observaciones);

                db.ExecuteNonQuery(selectCommand);
                GC.Collect();
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string EliminarArchivo(string DocU_Nombre)
        {
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;
            string MsjBD = "";

            try
            {
                selectCommand = db.GetSqlStringCommand("stpU_EliminarDocumentoUsuario");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@DocU_Nombre", DbType.String, DocU_Nombre);

                db.ExecuteNonQuery(selectCommand);
                GC.Collect();
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        #endregion Documentos
    }
}
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
    public class DLSoftware
    {
        public List<Software> getSoftware()
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  Cve_Software ");
            sqlCommand.AppendLine("		, Descripcion ");
            sqlCommand.AppendLine("		, [Version] ");
            sqlCommand.AppendLine("		, NoLicencias ");
            sqlCommand.AppendLine("FROM Software ");

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
            List<Software> lstSoftware = new List<Software>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Software oSoftware = new Software();
                    oSoftware.Cve_Software = Convert.ToInt32(dr["Cve_Software"]);
                    oSoftware.Descripcion = dr["Descripcion"].ToString();
                    oSoftware.Version = dr["Version"].ToString();
                    oSoftware.NumeroLicencias = Convert.ToInt32(dr["NoLicencias"]);
                    lstSoftware.Add(oSoftware);
                }
            }
            return lstSoftware;
        }

        public List<Software> getSoftware(string NombreLicencia = null, string version = null, int? Cantidad = null)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            string strAnd = "";

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  Cve_Software ");
            sqlCommand.AppendLine("		, Descripcion ");
            sqlCommand.AppendLine("		, [Version] ");
            sqlCommand.AppendLine("		, NoLicencias ");
            sqlCommand.AppendLine("FROM Software ");
            sqlCommand.AppendLine("where ");

            if (NombreLicencia != null)
            {
                sqlCommand.AppendLine(" Descripcion like '%" + NombreLicencia + "%'");
                strAnd = " and ";
            }
            if (version != null)
            {
                sqlCommand.AppendLine(strAnd + " version like '%" + version + "%'");
                strAnd = "and ";
            }
            if (Cantidad != null)
            {
                sqlCommand.AppendLine(strAnd + " NoLicencias = " + Cantidad);
            }

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
            List<Software> lstSoftware = new List<Software>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Software oSoftware = new Software();
                    oSoftware.Cve_Software = Convert.ToInt32(dr["Cve_Software"]);
                    oSoftware.Descripcion = dr["Descripcion"].ToString();
                    oSoftware.Version = dr["Version"].ToString();
                    oSoftware.NumeroLicencias = Convert.ToInt32(dr["NoLicencias"]);
                    lstSoftware.Add(oSoftware);
                }
            }
            return lstSoftware;
        }

        public List<Software> getSoftwareDetalle()
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  Cve_Software ");
            sqlCommand.AppendLine("		, Descripcion ");
            sqlCommand.AppendLine("		, [Version] ");
            sqlCommand.AppendLine("		, NoLicencias ");
            sqlCommand.AppendLine("FROM Software ");

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
            List<Software> lstSoftware = new List<Software>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Software oSoftware = new Software();
                    oSoftware.Cve_Software = Convert.ToInt32(dr["Cve_Software"]);
                    oSoftware.Descripcion = dr["Descripcion"].ToString();
                    oSoftware.Version = dr["Version"].ToString();
                    oSoftware.NumeroLicencias = Convert.ToInt32(dr["NoLicencias"]);
                    lstSoftware.Add(oSoftware);
                }
            }
            return lstSoftware;
        }

        public List<Software> getSoftwareDsiponible()
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		    t2.Cve_Asignacion ");
            sqlCommand.AppendLine("		,  t1.Cve_Software ");
            sqlCommand.AppendLine("		, t1.Descripcion ");
            sqlCommand.AppendLine("		, t1.Version ");
            sqlCommand.AppendLine("		, t1.NoLicencias ");
            sqlCommand.AppendLine("		, t2.Serial ");
            sqlCommand.AppendLine("FROM Software t1 ");
            sqlCommand.AppendLine("inner join Asignacion_Software t2 on t1.Cve_Software = t2.Cve_Software ");
            sqlCommand.AppendLine("where Nombre_Usuario = 'Disponible' and Serial <> 'Sin licencia'");

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
            List<Software> lstSoftware = new List<Software>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Software oSoftware = new Software();
                    oSoftware.Cve_Asignacion = Convert.ToInt32(dr["Cve_Asignacion"]);
                    oSoftware.Cve_Software = Convert.ToInt32(dr["Cve_Software"]);
                    oSoftware.Descripcion = dr["Descripcion"].ToString();
                    oSoftware.Version = dr["Version"].ToString();
                    oSoftware.NumeroLicencias = Convert.ToInt32(dr["NoLicencias"]);
                    oSoftware.Serial = dr["Serial"].ToString();
                    lstSoftware.Add(oSoftware);
                }
            }
            return lstSoftware;
        }

        public List<Software> getSoftwareDetalle(string NombreLicencia = null, string version = null, int? Cantidad = null)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            string strAnd = "";

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  Cve_Software ");
            sqlCommand.AppendLine("		, Descripcion ");
            sqlCommand.AppendLine("		, [Version] ");
            sqlCommand.AppendLine("		, NoLicencias ");
            sqlCommand.AppendLine("FROM Software ");
            sqlCommand.AppendLine("where ");

            if (NombreLicencia != null)
            {
                sqlCommand.AppendLine(" Descripcion like '%" + NombreLicencia + "%'");
                strAnd = " and ";
            }
            if (version != null)
            {
                sqlCommand.AppendLine(strAnd + " version like '%" + version + "%'");
                strAnd = "and ";
            }
            if (Cantidad != null)
            {
                sqlCommand.AppendLine(strAnd + " NoLicencias = " + Cantidad);
            }

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
            List<Software> lstSoftware = new List<Software>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Software oSoftware = new Software();
                    oSoftware.Cve_Software = Convert.ToInt32(dr["Cve_Software"]);
                    oSoftware.Descripcion = dr["Descripcion"].ToString();
                    oSoftware.Version = dr["Version"].ToString();
                    oSoftware.NumeroLicencias = Convert.ToInt32(dr["NoLicencias"]);
                    lstSoftware.Add(oSoftware);
                }
            }
            return lstSoftware;
        }

        public void InsertSoftware(ref Software oSoftware)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_Software");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@Descripcion", DbType.String, oSoftware.Descripcion);
            db.AddInParameter(dbCommand, "@Version", DbType.Int32, oSoftware.Version);
            db.AddInParameter(dbCommand, "@NoLicencias", DbType.Int32, oSoftware.NumeroLicencias);

            db.AddOutParameter(dbCommand, "@Cve_Software", DbType.Int32, 4);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                oSoftware.Cve_Software = Convert.ToInt32(db.GetParameterValue(dbCommand, "@Cve_Software"));
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void UpdateArticulo(Software oSoftware)
        {
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpU_Software");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@Cve_Software", DbType.Int64, oSoftware.Cve_Software);
            db.AddInParameter(dbCommand, "@Descripcion", DbType.String, oSoftware.Descripcion);
            db.AddInParameter(dbCommand, "@Version", DbType.Int64, oSoftware.Version);
            db.AddInParameter(dbCommand, "@NoLicencias", DbType.String, oSoftware.NumeroLicencias);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public List<TotalesSoftware> ObtieneTotalesSoftware(int cve_Software)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DataSet ds = new DataSet();
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stps_ObtieneTotalesSoftware");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@Cve_Software", DbType.Int32, cve_Software);

            try
            {
                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }

            List<TotalesSoftware> totales = new List<TotalesSoftware>();

            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                TotalesSoftware total = new TotalesSoftware();
                total.concepto = ds.Tables[0].Columns[i].ToString();
                total.conteo = Convert.ToInt32(ds.Tables[0].Rows[0][i]);
                totales.Add(total);
            }

            return totales;
        }

        public List<TotalesSoftware> ObtieneTotalesSoftware(string NombreLicencia, string version, int? Cantidad)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            //StringBuilder sqlCommand = new StringBuilder();
            string condicion = "";

            if (NombreLicencia != null)
            {
                condicion = " and Descripcion like '%" + NombreLicencia + "%'";
            }
            if (version != null)
            {
                condicion = " and version like '%" + version + "%'";
            }
            if (Cantidad != null)
            {
                condicion = " and NoLicencias = " + Cantidad;
            }

            string sqlCommand = @"select (SELECT COUNT(Cve_Asignacion)
                                  FROM [BD_INVENTARIOHSC].[dbo].[Asignacion_Software] t2
                                  inner join software t1 on t2.cve_Software = t1.Cve_Software
                                  where Nombre_Usuario = 'Disponible' and Serial = 'Sin licencia' " + condicion + @") as [Disponible Sin Licencia]
                                  ,
                                  (SELECT COUNT(Cve_Asignacion)
                                  FROM [BD_INVENTARIOHSC].[dbo].[Asignacion_Software] t2
                                  inner join software t1 on t2.cve_Software = t1.Cve_Software
                                  where Nombre_Usuario = 'Disponible' and Serial <> 'Sin licencia' " + condicion + @") as [Disponible Con Licencia]
                                  ,
                                  (SELECT COUNT(Cve_Asignacion) as [Asignado Con Licencia]
                                  FROM [BD_INVENTARIOHSC].[dbo].[Asignacion_Software] t2
                                  inner join software t1 on t2.cve_Software = t1.Cve_Software
                                  where Nombre_Usuario <> 'Disponible' and Serial <> 'Sin licencia' " + condicion + @") as [Asignado Con Licencia]
                                  ,
                                  (SELECT COUNT(Cve_Asignacion)
                                  FROM [BD_INVENTARIOHSC].[dbo].[Asignacion_Software] t2
                                  inner join software t1 on t2.cve_Software = t1.Cve_Software
                                  where Nombre_Usuario <> 'Disponible' and Serial = 'Sin licencia' " + condicion + @") as [Asignado Sin Licencia]";

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

            List<TotalesSoftware> totales = new List<TotalesSoftware>();

            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                TotalesSoftware total = new TotalesSoftware();
                total.concepto = ds.Tables[0].Columns[i].ToString();
                total.conteo = Convert.ToInt32(ds.Tables[0].Rows[0][i]);
                totales.Add(total);
            }

            return totales;
        }

        public Software Software(int cve_Software)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("		  Cve_Software ");
            sqlCommand.AppendLine("		, Descripcion ");
            sqlCommand.AppendLine("		, [Version] ");
            sqlCommand.AppendLine("		, NoLicencias ");
            sqlCommand.AppendLine("FROM Software ");
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

            Software lstSoftware = new Software();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstSoftware.Cve_Software = Convert.ToInt32(dr["Cve_Software"]);
                    lstSoftware.Descripcion = dr["Descripcion"].ToString();
                    lstSoftware.Version = dr["Version"].ToString();
                    lstSoftware.NumeroLicencias = Convert.ToInt32(dr["NoLicencias"]);
                }
            }
            return lstSoftware;
        }

        //Software
        public List<EmpresasSoftware> getEmpresasSoftwareAll(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Empresas_Software).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Empresas_Software).ToString() + ", 0, 0, 0");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<EmpresasSoftware> lstEmpresasSoftware = new List<EmpresasSoftware>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        EmpresasSoftware oEmpresasSoftware = new EmpresasSoftware();
                        oEmpresasSoftware.idEmpresasSoftware = Convert.ToInt32(dr["Valor"]);
                        oEmpresasSoftware.descripcion = dr["Descripcion"].ToString();
                        lstEmpresasSoftware.Add(oEmpresasSoftware);
                    }
                }

                return lstEmpresasSoftware;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public List<EmpresasSoftware> getEmpresasSoftwareChk(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Empresas_Software_Chk).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Empresas_Software_Chk).ToString() + ", 0, 0, 0");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<EmpresasSoftware> lstEmpresasSoftware = new List<EmpresasSoftware>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        EmpresasSoftware oEmpresasSoftware = new EmpresasSoftware();
                        oEmpresasSoftware.idEmpresasSoftware = Convert.ToInt32(dr["Valor"]);
                        oEmpresasSoftware.descripcion = dr["Descripcion"].ToString();
                        lstEmpresasSoftware.Add(oEmpresasSoftware);
                    }
                }

                return lstEmpresasSoftware;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public List<GruposSoftware> getGruposSoftwareAll(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Grupos_Software).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Grupos_Software).ToString() + ", 0, 0, 0");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<GruposSoftware> lstGruposSoftware = new List<GruposSoftware>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        GruposSoftware oGruposSoftware = new GruposSoftware();
                        oGruposSoftware.idGruposSoftware = Convert.ToInt32(dr["Valor"]);
                        oGruposSoftware.descripcion = dr["Descripcion"].ToString();
                        lstGruposSoftware.Add(oGruposSoftware);
                    }
                }

                return lstGruposSoftware;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public List<GruposSoftware> getGruposSoftwareChk(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Grupos_Software_Chk).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Grupos_Software_Chk).ToString() + ", 0, 0, 0");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<GruposSoftware> lstGruposSoftware = new List<GruposSoftware>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        GruposSoftware oGruposSoftware = new GruposSoftware();
                        oGruposSoftware.idGruposSoftware = Convert.ToInt32(dr["Valor"]);
                        oGruposSoftware.descripcion = dr["Descripcion"].ToString();
                        lstGruposSoftware.Add(oGruposSoftware);
                    }
                }

                return lstGruposSoftware;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public List<CatalogoSoftware> getCatalogoSoftware(int SWE_Id, int SWG_Id, bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Catalogo_Software).ToString() + ", 1, " + SWE_Id.ToString() + ", " + SWG_Id.ToString());
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Catalogo_Software).ToString() + ", 0, " + SWE_Id.ToString() + ", " + SWG_Id.ToString());

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<CatalogoSoftware> lstCatalogoSoftware = new List<CatalogoSoftware>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CatalogoSoftware oCatalogoSoftware = new CatalogoSoftware();

                        oCatalogoSoftware.id = Convert.ToInt32(dr["SW_Id"]);
                        oCatalogoSoftware.idEmpresa = Convert.ToInt32(dr["SWE_Id"]);
                        oCatalogoSoftware.idGrupo = Convert.ToInt32(dr["SWG_Id"].ToString());
                        oCatalogoSoftware.Descripcion = dr["SW_Descripcion"].ToString();
                        oCatalogoSoftware.Version = dr["SW_Version"].ToString();

                        if (dr["SW_Estatus"].ToString() == "1")
                            oCatalogoSoftware.Estatus = true;
                        else
                            oCatalogoSoftware.Estatus = false;

                        lstCatalogoSoftware.Add(oCatalogoSoftware);
                    }
                }

                return lstCatalogoSoftware;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public List<CatalogoSoftware> getCatalogoSoftwareCombo(int SWE_Id, int SWG_Id, bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Catalogo_Software_Combo).ToString() + ", 1, " + SWE_Id.ToString() + ", " + SWG_Id.ToString());
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Catalogo_Software_Combo).ToString() + ", 0, " + SWE_Id.ToString() + ", " + SWG_Id.ToString());

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<CatalogoSoftware> lstCatalogoSoftware = new List<CatalogoSoftware>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CatalogoSoftware oCatalogoSoftware = new CatalogoSoftware();

                        oCatalogoSoftware.id = Convert.ToInt32(dr["SW_Id"]);
                        oCatalogoSoftware.Descripcion = dr["SW_Descripcion"].ToString();

                        lstCatalogoSoftware.Add(oCatalogoSoftware);
                    }
                }

                return lstCatalogoSoftware;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public string InsertaCatalogo(ref CatalogoSoftware objSoftware)
        {
            string sMensaje = string.Empty;
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_CatalogoSoftware");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@SWE_Id", DbType.Int32, objSoftware.idEmpresa);
            db.AddInParameter(dbCommand, "@SWG_Id", DbType.Int32, objSoftware.idGrupo);
            db.AddInParameter(dbCommand, "@SW_Descripcion", DbType.String, objSoftware.Descripcion);
            db.AddInParameter(dbCommand, "@SW_Version", DbType.String, objSoftware.Version);
            db.AddInParameter(dbCommand, "@SW_Estatus", DbType.Boolean, objSoftware.Estatus);

            try
            {
                int ValorId = 0;
                //db.ExecuteNonQuery(dbCommand);
                ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables[0].Rows.Count > 0 && !ds.Tables[0].Rows[0][0].ToString().Contains("Existe"))
                {
                    int.TryParse(ds.Tables[0].Rows[0][0].ToString(), out ValorId);
                    sMensaje = "Operación completada satisfactoriamente. Id: " + ValorId.ToString();
                }
                else
                {
                    int.TryParse(ds.Tables[0].Rows[0][0].ToString().Replace("Existe", ""), out ValorId);
                    sMensaje = "Ya existía un registro con los datos proporcionados. Id: " + ValorId.ToString();
                }
            }
            catch (Exception ex)
            {
                sMensaje = ex.Message;
            }

            return sMensaje;
        }

        public string InsertaInventario(ref SoftwareExistente objSoftware)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_InventarioSoftware");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@SW_Id", DbType.Int32, objSoftware.SW_Id);
            db.AddInParameter(dbCommand, "@SW_Descripcion", DbType.String, objSoftware.Descripcion);
            db.AddInParameter(dbCommand, "@SWEx_NoParte", DbType.String, objSoftware.NoParte);
            db.AddInParameter(dbCommand, "@SWEx_Llave", DbType.String, objSoftware.Llave);
            db.AddInParameter(dbCommand, "@SWEx_Ubicacion", DbType.String, objSoftware.Ubicacion);
            db.AddInParameter(dbCommand, "@SWEx_Observaciones", DbType.String, objSoftware.Observaciones);
            db.AddInParameter(dbCommand, "@SWEx_EnExistencia", DbType.Boolean, objSoftware.EnExistencia);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                sMensaje = "Operación completada satisfactoriamente";
            }
            catch (Exception ex)
            {
                sMensaje = ex.Message;
            }

            return sMensaje;
        }

        public string InsertaEmpresaSoftware(ref EmpresasSoftware objSoftware)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_EmpresaSoftware");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@SWE_Descripcion", DbType.String, objSoftware.descripcion);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                sMensaje = "Operación completada satisfactoriamente";
            }
            catch (Exception ex)
            {
                sMensaje = ex.Message;
            }

            return sMensaje;
        }

        public string InsertaGrupoSoftware(ref GruposSoftware objSoftware)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_GrupoSoftware");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@SWG_Descripcion", DbType.String, objSoftware.descripcion);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                sMensaje = "Operación completada satisfactoriamente";
            }
            catch (Exception ex)
            {
                sMensaje = ex.Message;
            }

            return sMensaje;
        }

        public List<UbicacionSW> getUbicacionesAll(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.UbicacionesSW).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.UbicacionesSW).ToString() + ", 0, 0, 0");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<UbicacionSW> lstUbicacion = new List<UbicacionSW>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        UbicacionSW oUbicacion = new UbicacionSW();
                        oUbicacion.idUbicacion = dr["Valor"].ToString();
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

        public DataSet InventarioSW(string SWE_Id, string SWG_Id, string SW_Descripcion, string SW_Version, string SWEx_NoParte, string SWEx_Llave, string SWEx_Ubicacion, string SWEx_Observaciones, bool? SWEx_EnExistencia, bool IncluirEstadisticas)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpR_InventarioSW");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@SWE_Id", DbType.String, SWE_Id);
                db.AddInParameter(selectCommand, "@SWG_Id", DbType.String, SWG_Id);
                db.AddInParameter(selectCommand, "@SW_Descripcion", DbType.String, SW_Descripcion);
                db.AddInParameter(selectCommand, "@SW_Version", DbType.String, SW_Version);
                db.AddInParameter(selectCommand, "@SWEx_NoParte", DbType.String, SWEx_NoParte);
                db.AddInParameter(selectCommand, "@SWEx_Llave", DbType.String, SWEx_Llave);
                db.AddInParameter(selectCommand, "@SWEx_Ubicacion", DbType.String, SWEx_Ubicacion);
                db.AddInParameter(selectCommand, "@SWEx_Observaciones", DbType.String, SWEx_Observaciones);
                db.AddInParameter(selectCommand, "@SWEx_EnExistencia", DbType.Boolean, SWEx_EnExistencia);
                db.AddInParameter(selectCommand, "@IncluirEstadisticas", DbType.Boolean, IncluirEstadisticas);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MensajeBD = new DataSet();
                DataTable Errores = new DataTable("Error");
                DataRow dr;

                Errores.Columns.Add("Error");
                dr = Errores.NewRow();
                dr[0] = ex.Message + " StackTrace: " + ex.StackTrace;
                Errores.Rows.Add(dr);
                Errores.AcceptChanges();

                MensajeBD.Tables.Add(Errores);
            }

            return MensajeBD;
        }

        #region Aplicaciones

        public void HistoricoApp(string Pagina, string UserId, string HApp_Tipo, int HApp_IdModificado, int HApp_IdModificado2)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_HistoricoApp");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Pagina", DbType.String, Pagina);
                db.AddInParameter(selectCommand, "@UserId", DbType.String, UserId);
                db.AddInParameter(selectCommand, "@HApp_Tipo", DbType.String, HApp_Tipo);
                db.AddInParameter(selectCommand, "@HApp_IdModificado", DbType.Int32, HApp_IdModificado);
                db.AddInParameter(selectCommand, "@HApp_IdModificado2", DbType.Int32, HApp_IdModificado2);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }
        }

        public List<SistemaOperativo> getSistemasOperativosApp(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Sistemas_operativos_App).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Sistemas_operativos_App).ToString() + ", 0, 0, 0");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<SistemaOperativo> lstSistemasOperativos = new List<SistemaOperativo>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        SistemaOperativo oSistemasOperativos = new SistemaOperativo();
                        oSistemasOperativos.idSistema = Convert.ToInt32(dr["Valor"]);
                        oSistemasOperativos.descripcion = dr["Descripcion"].ToString();
                        lstSistemasOperativos.Add(oSistemasOperativos);
                    }
                }

                return lstSistemasOperativos;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public List<SistemaOperativo> getSistemasOperativosAppChk(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Sistemas_operativos_App_Chk).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Sistemas_operativos_App_Chk).ToString() + ", 0, 0, 0");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<SistemaOperativo> lstSistemasOperativos = new List<SistemaOperativo>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        SistemaOperativo oSistemasOperativos = new SistemaOperativo();
                        oSistemasOperativos.idSistema = Convert.ToInt32(dr["Valor"]);
                        oSistemasOperativos.descripcion = dr["Descripcion"].ToString();
                        lstSistemasOperativos.Add(oSistemasOperativos);
                    }
                }

                return lstSistemasOperativos;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public List<Servidores> getListaServidoresApp(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_Servidores_Equipo_Fisico).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_Servidores_Equipo_Fisico).ToString() + ", 0, 0, 0");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<Servidores> lstServidores = new List<Servidores>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Servidores oServidores = new Servidores();
                        oServidores.id = Convert.ToInt32(dr["Valor"]);
                        oServidores.Nombre = dr["Descripcion"].ToString();
                        lstServidores.Add(oServidores);
                    }
                }

                return lstServidores;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public DataTable getCatalogoBD(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Catalogo_BD).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Catalogo_BD).ToString() + ", 0, 0, 0");

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

        public DataTable getServidoresApp(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_Servidores_App).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_Servidores_App).ToString() + ", 0, 0, 0");

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

        public DataTable getServidoresCompletaApp(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_Servidores_Completa_App).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_Servidores_Completa_App).ToString() + ", 0, 0, 0");

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

        public DataTable getServidoresCompletaAppChk(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_Servidores_Completa_App_Chk).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_Servidores_Completa_App_Chk).ToString() + ", 0, 0, 0");

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

        public void GuardaLlave(int Srv_Id, string Srv_LlaveWin)
        {
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("UPDATE App_Servidores ");
            sqlCommand.AppendLine("SET    Srv_LlaveWin = Encryptbypassphrase(Srv_Nombre, '" + Srv_LlaveWin + "') ");
            sqlCommand.AppendLine("WHERE  Srv_Id = " + Srv_Id.ToString());

            DbCommand updateCommand = null;
            updateCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(updateCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public string BorrarDiscosServidorApp(int Srv_Id)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_AppServidores");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Accion", DbType.Int32, (int)DatosGenerales.OpcionesInsertarServidoresStored.Borrar_Todas_Unidades);
                db.AddInParameter(selectCommand, "@idSistema", DbType.Int32, Srv_Id);
                db.AddInParameter(selectCommand, "@idItem", DbType.Int32, 0);
                db.AddInParameter(selectCommand, "@Srv_Nombre", DbType.String, "");
                db.AddInParameter(selectCommand, "@Srv_Tipo", DbType.String, "");
                db.AddInParameter(selectCommand, "@Srv_EsVirtual", DbType.Boolean, false);
                db.AddInParameter(selectCommand, "@Srv_IP", DbType.String, "");
                db.AddInParameter(selectCommand, "@Srv_RAM", DbType.Int32, 0);
                db.AddInParameter(selectCommand, "@Srv_TotalHDD", DbType.Int64, 0);
                db.AddInParameter(selectCommand, "@Srv_Estado", DbType.Boolean, false);
                db.AddInParameter(selectCommand, "@Srv_Observaciones", DbType.String, "");

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string BorrarDiscosServidorApp(int Srv_Id, string SrvD_Unidad)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_AppServidores");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Accion", DbType.Int32, (int)DatosGenerales.OpcionesInsertarServidoresStored.Borrar_Unidad);
                db.AddInParameter(selectCommand, "@idSistema", DbType.Int32, Srv_Id);
                db.AddInParameter(selectCommand, "@idItem", DbType.Int32, 0);
                db.AddInParameter(selectCommand, "@Srv_Nombre", DbType.String, "");
                db.AddInParameter(selectCommand, "@Srv_Tipo", DbType.String, SrvD_Unidad);
                db.AddInParameter(selectCommand, "@Srv_EsVirtual", DbType.Boolean, false);
                db.AddInParameter(selectCommand, "@Srv_IP", DbType.String, "");
                db.AddInParameter(selectCommand, "@Srv_RAM", DbType.Int32, 0);
                db.AddInParameter(selectCommand, "@Srv_TotalHDD", DbType.Int64, 0);
                db.AddInParameter(selectCommand, "@Srv_Estado", DbType.Boolean, false);
                db.AddInParameter(selectCommand, "@Srv_Observaciones", DbType.String, "");

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string InsertarDiscoServidorApp(int Srv_Id, int SrvD_Capacidad, string SrvD_Unidad)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_AppServidores");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Accion", DbType.Int32, (int)DatosGenerales.OpcionesInsertarServidoresStored.Insertar_Disco);
                db.AddInParameter(selectCommand, "@idSistema", DbType.Int32, Srv_Id);
                db.AddInParameter(selectCommand, "@idItem", DbType.Int32, SrvD_Capacidad);
                db.AddInParameter(selectCommand, "@Srv_Nombre", DbType.String, "");
                db.AddInParameter(selectCommand, "@Srv_Tipo", DbType.String, SrvD_Unidad);
                db.AddInParameter(selectCommand, "@Srv_EsVirtual", DbType.Boolean, false);
                db.AddInParameter(selectCommand, "@Srv_IP", DbType.String, "");
                db.AddInParameter(selectCommand, "@Srv_RAM", DbType.Int32, 0);
                db.AddInParameter(selectCommand, "@Srv_TotalHDD", DbType.Int64, 0);
                db.AddInParameter(selectCommand, "@Srv_Estado", DbType.Boolean, false);
                db.AddInParameter(selectCommand, "@Srv_Observaciones", DbType.String, "");

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string InsertarDiscoServidorApp(int Srv_Id, int SrvD_Capacidad, string SrvD_Unidad, int SrvTA_Id, int SrvUD_Id, int idItem, string SrvD_Observaciones)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("sptI_ServidoresDiscos");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Srv_Id", DbType.Int32, Srv_Id);
                db.AddInParameter(selectCommand, "@SrvD_Capacidad", DbType.Int32, SrvD_Capacidad);
                db.AddInParameter(selectCommand, "@SrvD_Unidad", DbType.String, SrvD_Unidad);
                db.AddInParameter(selectCommand, "@SrvTA_Id", DbType.Int32, SrvTA_Id);
                db.AddInParameter(selectCommand, "@SrvUD_Id", DbType.Int32, SrvUD_Id);
                db.AddInParameter(selectCommand, "@idItem", DbType.Int32, idItem);
                db.AddInParameter(selectCommand, "@SrvD_Observaciones", DbType.String, SrvD_Observaciones);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string InsertarServidorApp(Servidores server, DataTable Discos, string Srv_Observaciones)
        {
            string MsjBD = "";
            int Id = 0;
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_AppServidores");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Accion", DbType.Int32, (int)DatosGenerales.OpcionesInsertarServidoresStored.Insertar_Servidor);
                db.AddInParameter(selectCommand, "@idSistema", DbType.Int32, server.idSistema);
                db.AddInParameter(selectCommand, "@idItem", DbType.Int32, server.idItem);
                db.AddInParameter(selectCommand, "@Srv_Nombre", DbType.String, server.Nombre);
                db.AddInParameter(selectCommand, "@Srv_Tipo", DbType.String, server.Tipo);
                db.AddInParameter(selectCommand, "@Srv_EsVirtual", DbType.Boolean, server.EsVirtual);
                db.AddInParameter(selectCommand, "@Srv_IP", DbType.String, server.IP);
                db.AddInParameter(selectCommand, "@Srv_RAM", DbType.Int32, server.RAM);
                db.AddInParameter(selectCommand, "@Srv_TotalHDD", DbType.Int64, server.TotalHDD);
                db.AddInParameter(selectCommand, "@Srv_Estado", DbType.Boolean, server.Estado);
                db.AddInParameter(selectCommand, "@Srv_Observaciones", DbType.String, Srv_Observaciones);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0 && MensajeBD.Tables[0].Rows.Count > 0)
                {
                    int.TryParse(MensajeBD.Tables[0].Rows[0][0].ToString(), out Id);

                    if (Id > 0)
                    {
                        server.id = Id;
                        MsjBD = Id.ToString();
                        GuardaLlave(server.id, server.Llave);
                        BorrarDiscosServidorApp(server.id);

                        for (int w = 0; w < Discos.Rows.Count; w++)
                        {
                            InsertarDiscoServidorApp(server.id, Convert.ToInt32(Discos.Rows[w]["Capacidad"].ToString()), Discos.Rows[w]["Unidad"].ToString());
                        }
                    }
                    else
                    {
                        MsjBD = "No se obtuvo Id";
                    }
                }
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string ActualizarServidorApp(Servidores server, DataTable Discos, string Srv_Observaciones)
        {
            string MsjBD = "";
            int Id = 0;
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpU_AppServidores");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Accion", DbType.Int32, (int)DatosGenerales.OpcionesActualizarServidoresStored.Actualizar_Servidor);
                db.AddInParameter(selectCommand, "@idSistema", DbType.Int32, server.idSistema);
                db.AddInParameter(selectCommand, "@idItem", DbType.Int32, server.idItem);
                db.AddInParameter(selectCommand, "@Srv_Nombre", DbType.String, server.Nombre);
                db.AddInParameter(selectCommand, "@Srv_Tipo", DbType.String, server.Tipo);
                db.AddInParameter(selectCommand, "@Srv_EsVirtual", DbType.Boolean, server.EsVirtual);
                db.AddInParameter(selectCommand, "@Srv_IP", DbType.String, server.IP);
                db.AddInParameter(selectCommand, "@Srv_RAM", DbType.Int32, server.RAM);
                db.AddInParameter(selectCommand, "@Srv_TotalHDD", DbType.Int64, server.TotalHDD);
                db.AddInParameter(selectCommand, "@Srv_Estado", DbType.Boolean, server.Estado);
                db.AddInParameter(selectCommand, "@Srv_Id", DbType.Int32, server.id);
                db.AddInParameter(selectCommand, "@Srv_Observaciones", DbType.String, Srv_Observaciones);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                Id = server.id;

                if (Id > 0)
                {
                    server.id = Id;
                    MsjBD = Id.ToString();

                    if (server.Llave.Trim() != "")
                        GuardaLlave(server.id, server.Llave);

                    //BorrarDiscosServidorApp(server.id);

                    //for (int w = 0; w < Discos.Rows.Count; w++)
                    //{
                    //    InsertarDiscoServidorApp(server.id, Convert.ToInt32(Discos.Rows[w]["Capacidad"].ToString()), Discos.Rows[w]["Unidad"].ToString());
                    //}
                }
                else
                {
                    MsjBD = "No se obtuvo Id";
                }
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string InsertarInstanciaBD(int Srv_Id, int BD_Id, string AppSB_Nombre)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_AppInstanciaBD");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Srv_Id", DbType.Int32, Srv_Id);
                db.AddInParameter(selectCommand, "@BD_Id", DbType.Int32, BD_Id);
                db.AddInParameter(selectCommand, "@AppSB_Nombre", DbType.String, AppSB_Nombre);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0 && MensajeBD.Tables[0].Rows.Count > 0)
                    MsjBD = MensajeBD.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string ActualizarInstanciaBD(int AppSB_Id, int Srv_Id, int BD_Id, string AppSB_Nombre)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpU_AppInstanciaBD");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@AppSB_Id", DbType.Int32, AppSB_Id);
                db.AddInParameter(selectCommand, "@Srv_Id", DbType.Int32, Srv_Id);
                db.AddInParameter(selectCommand, "@BD_Id", DbType.Int32, BD_Id);
                db.AddInParameter(selectCommand, "@AppSB_Nombre", DbType.String, AppSB_Nombre);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public DataTable ObtenerInstanciaBD(int Srv_Id)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_AppServidores");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Accion", DbType.Int32, DatosGenerales.OpcionesAppServidoresStored.Instancias_BD_servidor);
                db.AddInParameter(selectCommand, "@Srv_Id", DbType.Int32, Srv_Id);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }

            return MensajeBD.Tables[0];
        }

        public DataTable ObtenerBDServidor(int Srv_Id)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_AppServidores");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Accion", DbType.Int32, DatosGenerales.OpcionesAppServidoresStored.BD_de_servidor);
                db.AddInParameter(selectCommand, "@Srv_Id", DbType.Int32, Srv_Id);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }

            return MensajeBD.Tables[0];
        }

        public string InsertarBDServidor(int AppSB_Id, string AppBD_Nombre, bool AppBD_Activa, bool AppBD_Productiva)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("sptI_ServidorBD");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@AppSB_Id", DbType.Int32, AppSB_Id);
                db.AddInParameter(selectCommand, "@AppBD_Nombre", DbType.String, AppBD_Nombre);
                db.AddInParameter(selectCommand, "@AppBD_Activa", DbType.Boolean, AppBD_Activa);
                db.AddInParameter(selectCommand, "@AppBD_Productiva", DbType.Boolean, AppBD_Productiva);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0 && MensajeBD.Tables[0].Rows.Count > 0)
                    MsjBD = MensajeBD.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public DataTable ListaEstadosApp(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Estados_App).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Estados_App).ToString() + ", 0, 0, 0");

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

        public DataTable ListaInstanciasBD(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_instancias_BD).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_instancias_BD).ToString() + ", 0, 0, 0");

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

        public DataTable ListaTiposApp(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Tipos_App).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Tipos_App).ToString() + ", 0, 0, 0");

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

        public string InsertarAplicacion(int AppSt_Id, int AppT_Id, string App_Nombre, string App_Descripcion, bool App_EnTFS, bool App_Productiva, string App_Observaciones, string App_Ubicacion, int Srv_Id, bool Srv_EsPropietaria, int AppBD_Id, bool BD_EsPropietaria)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_Aplicaciones");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@AppSt_Id", DbType.Int32, AppSt_Id);
                db.AddInParameter(selectCommand, "@AppT_Id", DbType.Int32, AppT_Id);
                db.AddInParameter(selectCommand, "@App_Nombre", DbType.String, App_Nombre);
                db.AddInParameter(selectCommand, "@App_Descripcion", DbType.String, App_Descripcion);
                db.AddInParameter(selectCommand, "@App_EnTFS", DbType.Boolean, App_EnTFS);
                db.AddInParameter(selectCommand, "@App_Productiva", DbType.Boolean, App_Productiva);
                db.AddInParameter(selectCommand, "@App_Observaciones", DbType.String, App_Observaciones);
                db.AddInParameter(selectCommand, "@App_Ubicacion", DbType.String, App_Ubicacion);
                db.AddInParameter(selectCommand, "@Srv_Id", DbType.Int32, Srv_Id);
                db.AddInParameter(selectCommand, "@Srv_EsPropietaria", DbType.Boolean, Srv_EsPropietaria);
                db.AddInParameter(selectCommand, "@AppBD_Id", DbType.Int32, AppBD_Id);
                db.AddInParameter(selectCommand, "@BD_EsPropietaria", DbType.Boolean, BD_EsPropietaria);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0 && MensajeBD.Tables[0].Rows.Count > 0)
                    MsjBD = MensajeBD.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public DataTable ListaAppConServer(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_Aplicaciones_con_Servidor).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_Aplicaciones_con_Servidor).ToString() + ", 0, 0, 0");

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

        public DataTable ListaServidoresExclusionApp(int App_Id, bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_Servidores_con_Exclusion_por_App).ToString() + ", 1, " + App_Id.ToString() + ", 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_Servidores_con_Exclusion_por_App).ToString() + ", 0, " + App_Id.ToString() + ", 0");

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

        public DataTable ListaBDPorServidorApp(int Srv_Id, int App_Id, bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_BD_por_Servidor_y_Aplicacion).ToString() + ", 1, " + Srv_Id.ToString() + ", " + App_Id.ToString());
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_BD_por_Servidor_y_Aplicacion).ToString() + ", 0, " + Srv_Id.ToString() + ", " + App_Id.ToString());

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

        public DataTable ListaBDConServidor(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_BD_con_Servidor_CHK).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_BD_con_Servidor_CHK).ToString() + ", 0, 0, 0");

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

        public string InsertarAppRelServer(int App_Id, int Srv_Id, bool EsPropietaria)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_AppRelServer");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@App_Id", DbType.Int32, App_Id);
                db.AddInParameter(selectCommand, "@Srv_Id", DbType.Int32, Srv_Id);
                db.AddInParameter(selectCommand, "@EsPropietaria", DbType.Boolean, EsPropietaria);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0 && MensajeBD.Tables[0].Rows.Count > 0)
                    MsjBD = MensajeBD.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string BorrarAppRelServer(int App_Id)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpD_AppRelServer");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@App_Id", DbType.Int32, App_Id);

                db.ExecuteDataSet(selectCommand);
                MsjBD = "OK";
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string BorrarAppRelBD(int App_Id)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpD_AppRelBD");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@App_Id", DbType.Int32, App_Id);

                db.ExecuteDataSet(selectCommand);
                MsjBD = "OK";
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string InsertarAppRelBD(int App_Id, int AppBD_Id, bool EsPropietaria)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_AppRelBD");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@App_Id", DbType.Int32, App_Id);
                db.AddInParameter(selectCommand, "@AppBD_Id", DbType.Int32, AppBD_Id);
                db.AddInParameter(selectCommand, "@EsPropietaria", DbType.Boolean, EsPropietaria);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0 && MensajeBD.Tables[0].Rows.Count > 0)
                    MsjBD = MensajeBD.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public DataTable getTiposServidorAppChk(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Tipos_de_Servidor).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Tipos_de_Servidor).ToString() + ", 0, 0, 0");

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

        public DataTable ListaTiposAppChk(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Tipos_App_Chk).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Tipos_App_Chk).ToString() + ", 0, 0, 0");

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

        public DataTable ListaEstadosAppChk(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Estados_App_Chk).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Estados_App_Chk).ToString() + ", 0, 0, 0");

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

        public DataSet ReporteGeneralServidores(string idSO, string idEquipo, string Srv_Tipo, bool? Srv_EsVirtual, bool? Srv_Estado)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpR_GeneralServidores");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@idSistemaOperativo", DbType.String, idSO);
                db.AddInParameter(selectCommand, "@idEquipo", DbType.String, idEquipo);
                db.AddInParameter(selectCommand, "@Srv_Tipo", DbType.String, Srv_Tipo);
                db.AddInParameter(selectCommand, "@Srv_EsVirtual", DbType.Boolean, Srv_EsVirtual);
                db.AddInParameter(selectCommand, "@Srv_Estado", DbType.Boolean, Srv_Estado);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MensajeBD = new DataSet();
                DataTable Errores = new DataTable("Error");
                DataRow dr;

                Errores.Columns.Add("Error");
                dr = Errores.NewRow();
                dr[0] = ex.Message + " StackTrace: " + ex.StackTrace;
                Errores.Rows.Add(dr);
                Errores.AcceptChanges();

                MensajeBD.Tables.Add(Errores);
            }

            return MensajeBD;
        }

        public DataSet ReporteGeneralAplicaciones(string AppSt_Id, string AppT_Id, bool? App_EnTFS, bool? App_Productiva)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpR_GeneralAplicaciones");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@AppSt_Id", DbType.String, AppSt_Id);
                db.AddInParameter(selectCommand, "@AppT_Id", DbType.String, AppT_Id);
                db.AddInParameter(selectCommand, "@App_EnTFS", DbType.Boolean, App_EnTFS);
                db.AddInParameter(selectCommand, "@App_Productiva", DbType.Boolean, App_Productiva);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MensajeBD = new DataSet();
                DataTable Errores = new DataTable("Error");
                DataRow dr;

                Errores.Columns.Add("Error");
                dr = Errores.NewRow();
                dr[0] = ex.Message + " StackTrace: " + ex.StackTrace;
                Errores.Rows.Add(dr);
                Errores.AcceptChanges();

                MensajeBD.Tables.Add(Errores);
            }

            return MensajeBD;
        }

        public string ReporteRelSrvApp(string Srv_Id, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;
            DLExportar exportar = new DLExportar();

            try
            {
                selectCommand = db.GetSqlStringCommand("stpR_RelSrv");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Srv_Id", DbType.String, Srv_Id);

                MsjBD = exportar.GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string ReporteRelBDApp(string AppBD_Id, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;
            DLExportar exportar = new DLExportar();

            try
            {
                selectCommand = db.GetSqlStringCommand("stpR_RelBD");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@AppBD_Id", DbType.String, AppBD_Id);

                MsjBD = exportar.GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string ReporteRelSrvBD(string Srv_Id, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;
            DLExportar exportar = new DLExportar();

            try
            {
                selectCommand = db.GetSqlStringCommand("stpR_RelSrvBD");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Srv_Id", DbType.String, Srv_Id);

                MsjBD = exportar.GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string ReporteDiscosSrv(string Srv_Id, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;
            DLExportar exportar = new DLExportar();

            try
            {
                selectCommand = db.GetSqlStringCommand("stpR_DiscosSrv");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Srv_Id", DbType.String, Srv_Id);

                MsjBD = exportar.GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public DataSet InformacionGeneralServidor(int Srv_Id)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_AppServidores");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Accion", DbType.Int32, DatosGenerales.OpcionesAppServidoresStored.Informacion_general_servidor);
                db.AddInParameter(selectCommand, "@Srv_Id", DbType.Int32, Srv_Id);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }

            return MensajeBD;
        }

        public DataSet InformacionCompletaDiscos(int Srv_Id)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_AppServidores");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Accion", DbType.Int32, DatosGenerales.OpcionesAppServidoresStored.Informacion_completa_discos);
                db.AddInParameter(selectCommand, "@Srv_Id", DbType.Int32, Srv_Id);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }

            return MensajeBD;
        }

        public DataTable ObtenerEquipos(int Srv_Id, bool Exclusion)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_AppServidores");
                selectCommand.CommandType = CommandType.StoredProcedure;

                if (Exclusion)
                    db.AddInParameter(selectCommand, "@Accion", DbType.Int32, DatosGenerales.OpcionesAppServidoresStored.Obtener_lista_equipos_por_tipo_exclusion);
                else
                    db.AddInParameter(selectCommand, "@Accion", DbType.Int32, DatosGenerales.OpcionesAppServidoresStored.Obtener_lista_equipos_por_tipo);

                db.AddInParameter(selectCommand, "@Srv_Id", DbType.Int32, Srv_Id);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }

            if (MensajeBD.Tables.Count > 0)
                return MensajeBD.Tables[0];
            else
                return new DataTable();
        }

        public DataSet InformacionGeneralInstancia(int AppSB_Id)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_AppInstancias");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@AppSB_Id", DbType.Int32, AppSB_Id);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }

            return MensajeBD;
        }

        public DataTable ListaBDConServerInstancia(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_BD_con_Servidor_Instancia).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_BD_con_Servidor_Instancia).ToString() + ", 0, 0, 0");

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

        public DataTable ListaBDConServerInstanciaRel(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_BD_con_Servidor_Instancia_Rel).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_BD_con_Servidor_Instancia_Rel).ToString() + ", 0, 0, 0");

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

        public DataSet InformacionGeneralBD(int AppBD_Id)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_AppBD");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@AppBD_Id", DbType.Int32, AppBD_Id);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }

            return MensajeBD;
        }

        public DataTable ObtenerUltimaCinta(int TR_Id, int Obj_Id)
        {
            DataTable MensajeBD = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_ObtenerUltimaCinta");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@TR_Id", DbType.Int32, TR_Id);
                db.AddInParameter(selectCommand, "@Obj_Id", DbType.Int32, Obj_Id);

                MensajeBD.Load(db.ExecuteReader(selectCommand));
            }
            catch { }

            return MensajeBD;
        }

        public string ActualizarBD(int AppBD_Id, int AppSB_Id, string AppBD_Nombre, bool AppBD_Activa, bool AppBD_Productiva, DateTime? AppBD_FechaBaja)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("sptU_ServidorBD");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@AppBD_Id", DbType.Int32, AppBD_Id);
                db.AddInParameter(selectCommand, "@AppSB_Id", DbType.Int32, AppSB_Id);
                db.AddInParameter(selectCommand, "@AppBD_Nombre", DbType.String, AppBD_Nombre);
                db.AddInParameter(selectCommand, "@AppBD_Activa", DbType.Boolean, AppBD_Activa);
                db.AddInParameter(selectCommand, "@AppBD_Productiva", DbType.Boolean, AppBD_Productiva);
                db.AddInParameter(selectCommand, "@AppBD_FechaBaja", DbType.DateTime, AppBD_FechaBaja);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public DataSet InformacionGeneralApp(int App_Id)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_Aplicaciones");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@App_Id", DbType.Int32, App_Id);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }

            return MensajeBD;
        }

        public string ActualizarApp(int App_Id, int AppSt_Id, int AppT_Id, string App_Nombre, string App_Descripcion,
                                    bool App_EnTFS, bool App_Productiva, string App_Observaciones, string App_Ubicacion)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpU_Aplicaciones");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@App_Id", DbType.Int32, App_Id);
                db.AddInParameter(selectCommand, "@AppSt_Id", DbType.Int32, AppSt_Id);
                db.AddInParameter(selectCommand, "@AppT_Id", DbType.Int32, AppT_Id);
                db.AddInParameter(selectCommand, "@App_Nombre", DbType.String, App_Nombre);
                db.AddInParameter(selectCommand, "@App_Descripcion", DbType.String, App_Descripcion);
                db.AddInParameter(selectCommand, "@App_EnTFS", DbType.Boolean, App_EnTFS);
                db.AddInParameter(selectCommand, "@App_Productiva", DbType.Boolean, App_Productiva);
                db.AddInParameter(selectCommand, "@App_Observaciones", DbType.String, App_Observaciones);
                db.AddInParameter(selectCommand, "@App_Ubicacion", DbType.String, App_Ubicacion);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public DataSet InformacionRelAppSrv(int App_Id)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_RelSrv");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@App_Id", DbType.Int32, App_Id);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }

            return MensajeBD;
        }

        public DataSet InformacionRelAppBD(int App_Id)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_RelBD");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@App_Id", DbType.Int32, App_Id);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }

            return MensajeBD;
        }

        public DataTable ListaTiposAlmacenamiento(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_tipos_almacenamiento).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_tipos_almacenamiento).ToString() + ", 0, 0, 0");

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

        public DataTable ListaUsosDisco(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_usos_disco).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_usos_disco).ToString() + ", 0, 0, 0");

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

        #endregion Aplicaciones

        #region MaxImage

        public DataTable ListaTiposFiltroMaxI(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Catalogo_Tipos_Busqueda_Maximage).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Catalogo_Tipos_Busqueda_Maximage).ToString() + ", 0, 0, 0");

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

        public DataTable BuscarDocumentoMI(string Tipo, int Numero_Prestamo, int Codigo_Cliente, string Numero_Jit, string Nombre)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_BuscarDocumentoMaxImage");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Tipo", DbType.String, Tipo);
                db.AddInParameter(selectCommand, "@Numero_Prestamo", DbType.Int32, Numero_Prestamo);
                db.AddInParameter(selectCommand, "@Codigo_Cliente", DbType.Int32, Codigo_Cliente);
                db.AddInParameter(selectCommand, "@Numero_Jit", DbType.String, Numero_Jit);
                db.AddInParameter(selectCommand, "@Nombre", DbType.String, Nombre);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }

            return MensajeBD.Tables[0];
        }

        #endregion MaxImage

        #region Servidores

        public DataTable ListaTiposRespaldo(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Tipos_respaldo).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Tipos_respaldo).ToString() + ", 0, 0, 0");

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

        public DataTable BuscarObjetosRespaldo(int TR_Id)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_ObjetosRespaldo");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@TR_Id", DbType.Int32, TR_Id);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }

            return MensajeBD.Tables[0];
        }

        #endregion Servidores
    }
}
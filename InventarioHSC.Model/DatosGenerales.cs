using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections;

namespace InventarioHSC.Model
{
    public class DatosGenerales
    {
        public string Usuario { get; set; }
        public string Ubicacion { get; set; }
        public string Region { get; set; }
        public string TipoActivo { get; set; }
        public string NoSerie { get; set; }
        public string CodigoCastor { get; set; }
        public string Observacion_1 { get; set; }
        public string Observacion_2 { get; set; }
        public string Observacion_3 { get; set; }
        public string Observacion { get; set; }
        public string Responsiva { get; set; }
        public string Tipo { get; set; }

        public enum OpcionesCatalogosStored
        {
            Empresas_Software = 1,
            Grupos_Software = 2,
            Catalogo_Software = 3,
            Catalogo_Software_Combo = 4,
            Tipos_Equipo = 5,
            Marcas = 6,
            Ubicaciones = 7,
            Usuarios = 8,
            UbicacionesSW = 9,
            Empresas_Software_Chk = 10,
            Grupos_Software_Chk = 11,
            Sistemas_operativos_App = 12,
            Lista_Servidores_Equipo_Fisico = 13,
            Catalogo_BD = 14,
            Lista_Servidores_App = 15,
            Estados_App = 16,
            Tipos_App = 17,
            Lista_Servidores_Completa_App = 18,
            Lista_Aplicaciones_con_Servidor = 19,
            Estados_Software_Chk = 20,
            Lista_Servidores_con_Exclusion_por_App = 21,
            Lista_BD_por_Servidor_y_Aplicacion = 22,
            Catalogo_Tipos_Busqueda_Maximage = 23,
            Sistemas_operativos_App_Chk = 24,
            Lista_Servidores_Completa_App_Chk = 25,
            Tipos_de_Servidor = 26,
            Tipos_App_Chk = 27,
            Estados_App_Chk = 28,
            Lista_BD_con_Servidor_CHK = 29,
            Lista_instancias_BD = 30,
            Lista_BD_con_Servidor_Instancia = 31,
            Lista_BD_con_Servidor_Instancia_Rel = 32,
            Tipos_respaldo = 33,
            Catalogo_Usuarios_Sistema = 34,
            Lista_estados_tareas = 35,
            Lista_tipos_almacenamiento = 36,
            Lista_usos_disco = 37,
            Lista_monedas_Abanks = 38,
            Lista_tipos_script = 39
        }

        public enum OpcionesCatalogosSAP
        {
            Catalogo_Ejercicios = 1,
            Catalogo_Ejercicios_CHK = 2,
            Catalogo_Sociedades = 3,
            Catalogo_Sociedades_CHK = 4,
            Catalogo_Cuentas_Balanza = 5,
            Catalogo_Cuentas_Balanza_CHK = 6,
            Catalogo_Sociedades_Grid = 7,
            Catalogo_Cuentas_CHK = 8,
            Catalogo_Empleados_CHK = 9,
            Catalogo_ConceptosNomina_CHK = 10,
            Catalogo_TipoDocSAP = 11,
            Catalogo_SubTipoDocSAP = 12,
            Catalogo_PeriodoDocSAP = 13,
            Catalogo_AnioDocSAP = 14
        }

        public enum ReportesSAP
        {
            Acumulados_RH = 1,
            Auxiliares_Acumulados = 2,
            Balanzas = 3,
            Polizas = 4,
            Auxiliares_Detalle = 5
        }

        public enum TiposRespaldoCintas
        {
            Aplicacion = 1,
            Base_Datos = 2,
            Servidor = 3
        }

        public enum EstadosDocumentos
        {
            Finalizados = 1,
            Pendientes = 2,
            Eliminados = 3,
            Vigentes = 4
        }

        public enum TiposDocumentos
        {
            Reporte_Polizas_Abanks = 1,
            Reporte_Acumulados_SAP = 2,
            Reporte_AplicacionesEnServidor = 3,
            Reporte_AplicacionesEnBD = 4,
            Reporte_BDEnServidor = 5,
            Reporte_DiscosEnServidor = 6,
            Reporte_GeneralDeAplicaciones = 7,
            Reporte_GeneralDeServidores = 8,
            Reporte_InventarioEquipos = 9,
            Reporte_InventarioSW = 10,
            Reporte_AuxiliaresContables = 11,
            Reporte_BalanzasContables = 12,
            Reporte_CuentasContables = 13,
            Reporte_DetalleAuxiliaresContables = 14,
            Reporte_AsignacionOrganizativa = 15,
            Reporte_ContratosLaborales = 16,
            Reporte_DatosBancarios = 17,
            Reporte_DatosPersonales = 18,
            Reporte_Direcciones = 19,
            Reporte_HorariosLaborales = 20,
            Reporte_IngresoEmpleados = 21,
            Reporte_MedidasRH = 22,
            Reporte_NumAntEmp = 23,
            Reporte_RemuneracionEconomica = 24,
            Reporte_CintasRespaldo = 25,
            Cartero_Cartas = 26,
            Constancias = 27,
            Reporte_MonitoreoSW = 28,
            Reportes_Dinamicos = 29
        }

        public enum EstiloReportesDinamicos
        {
            eDropDownList = 1,
            eCheckBoxList = 2
        }

        public enum TiposScript
        {
            Texto = 1,
            Stored = 2,
            Paquete = 3
        }

        public enum BovedaAcciones
        {
            Generar_llave = 1,
            Insertar_contrasenna = 2,
            Modificar_contrasenna = 3
        }

        public enum BovedaTipos
        {
            Aplicaciones = 1,
            Servidores = 2,
            Bases_de_Datos = 3,
            Sitios_Web = 4,
            Dispositivos_Electrónicos = 5,
            Otros = 6
        }

        public static string RutaLocalReportesDinamicos = "TmpFiles";
        public static string RutaLocalReportesGeneral = "Docs/Export";

        public static string RutaReportesFijos = System.Web.Configuration.WebConfigurationManager.AppSettings["RutaReportesFijos"].ToString();
        public static string RutaReportesDinamicos = System.Web.Configuration.WebConfigurationManager.AppSettings["RutaReportesDinamicos"].ToString();

        public static string ParamMtto = "UltimoMantenimiento";
        public static string StandardKey = "HSC941011SU6";

        public static int VigenciaEstandarDocumentos = 3;

        public static string QueryStored = "SELECT specific_name AS Valor, specific_name AS Descripcion FROM information_schema.routines WHERE routine_type = 'PROCEDURE' AND specific_name NOT IN (SELECT DISTINCT specific_name FROM information_schema.parameters WHERE parameter_mode <> 'IN') ORDER BY specific_name";
        public static string QueryDetalleStored = "SELECT parameter_name as Nombre, parameter_mode AS Tipo, data_Type AS TipoDato, character_maximum_length AS Longitud FROM information_schema.parameters WHERE specific_name = @Stored";
        public static string QueryScriptStored = "SELECT t.TEXT FROM sysobjects o JOIN syscomments t ON t.id = o.id WHERE o.NAME = @Stored";
        public static string QueryTiposDato = "SELECT NAME AS Valor, NAME AS Descripcion FROM systypes ORDER BY NAME ";
        public static int LongitudBaseCampo = 50;

        public static int LongitudLlaveBoveda = 1024;
        
        public enum OpcionesInsertarServidoresStored
        {
            Insertar_Servidor = 1,
            Insertar_Disco = 2,
            Borrar_Unidad = 3,
            Borrar_Todas_Unidades = 4
        }

        public enum OpcionesActualizarServidoresStored
        {
            Actualizar_Servidor = 1,
            Insertar_Disco = 2,
            Borrar_Todas_Unidades = 3
        }

        public enum OpcionesAppServidoresStored
        {
            Lista_SO_y_Equipos = 1,
            Lista_AppServidores = 2,
            Informacion_general_servidor = 3,
            Instancias_BD_servidor = 4,
            BD_de_servidor = 5,
            Informacion_completa_discos = 6,
            Obtener_lista_equipos_por_tipo = 7,
            Obtener_lista_equipos_por_tipo_exclusion = 8
        }

        public static void ComboBooleano(ref DropDownList oddl, bool IncluirValorInicial = true)
        {
            List<ComboBool> lstCombo = new List<ComboBool>();

            ComboBool oCombo = new ComboBool();

            if (IncluirValorInicial == true)
            {
                oCombo.id = "null";
                oCombo.descripcion = " -TODO- ";
                lstCombo.Add(oCombo);
            }

            oCombo = new ComboBool();
            oCombo.id = "NO";
            oCombo.descripcion = " NO ";
            lstCombo.Add(oCombo);

            oCombo = new ComboBool();
            oCombo.id = "SI";
            oCombo.descripcion = " SI ";
            lstCombo.Add(oCombo);

            oddl.DataSource = lstCombo;
            oddl.DataValueField = "id";
            oddl.DataTextField = "descripcion";
        }

        public static void ComboAnnosConstancia(ref DropDownList oddl, bool IncluirValorInicial = true)
        {
            List<ComboBool> lstCombo = new List<ComboBool>();

            ComboBool oCombo = new ComboBool();

            if (IncluirValorInicial == true)
            {
                oCombo.id = "0";
                oCombo.descripcion = " -Seleccionar año- ";
                lstCombo.Add(oCombo);
            }

            oCombo = new ComboBool();
            oCombo.id = "2008";
            oCombo.descripcion = " 2008 ";
            lstCombo.Add(oCombo);

            oCombo = new ComboBool();
            oCombo.id = "2009";
            oCombo.descripcion = " 2009 ";
            lstCombo.Add(oCombo);

            oCombo = new ComboBool();
            oCombo.id = "2010";
            oCombo.descripcion = " 2010 ";
            lstCombo.Add(oCombo);

            oCombo = new ComboBool();
            oCombo.id = "2011";
            oCombo.descripcion = " 2011 ";
            lstCombo.Add(oCombo);

            oCombo = new ComboBool();
            oCombo.id = "2012";
            oCombo.descripcion = " 2012 ";
            lstCombo.Add(oCombo);

            oddl.DataSource = lstCombo;
            oddl.DataValueField = "id";
            oddl.DataTextField = "descripcion";
        }

        public enum TiposMensaje
        {
            Advertencia,
            Error,
            Informacion
        }

        public static void TipoEquipo(ref DropDownList ddl)
        {
            System.Data.DataTable Combo = new System.Data.DataTable();
            System.Data.DataRow row;

            Combo.Columns.Add("Id");
            Combo.Columns.Add("Descripcion");
            Combo.AcceptChanges();

            row = Combo.NewRow();
            row[0] = "";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "App";
            row[1] = "Aplicación";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "BD";
            row[1] = "Base de datos";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "Mixto";
            row[1] = "Mixto";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "FileServer";
            row[1] = "FileServer";
            Combo.Rows.Add(row);

            Combo.AcceptChanges();
            ddl.DataValueField = "Id";
            ddl.DataTextField = "Descripcion";
            ddl.DataSource = Combo;
            ddl.DataBind();
        }

        public static void EnviaMensaje(string Descripcion, string Titulo, TiposMensaje Tipo)
        {
            Titulo = Convert.ToBase64String(Encoding.Unicode.GetBytes(Titulo));
            Descripcion = Convert.ToBase64String(Encoding.Unicode.GetBytes(Descripcion));

            switch (Tipo)
            {
                case TiposMensaje.Advertencia:
                    HttpContext.Current.Response.Redirect("../Mensaje.aspx?Tipo=" + "A" + "&Titulo=" + HttpContext.Current.Server.UrlEncode(Titulo) + "&Mensaje=" + HttpContext.Current.Server.UrlEncode(Descripcion), false);
                    break;
                case TiposMensaje.Error:
                    HttpContext.Current.Response.Redirect("../Mensaje.aspx?Tipo=" + "E" + "&Titulo=" + HttpContext.Current.Server.UrlEncode(Titulo) + "&Mensaje=" + HttpContext.Current.Server.UrlEncode(Descripcion), false);
                    break;
                case TiposMensaje.Informacion:
                    HttpContext.Current.Response.Redirect("../Mensaje.aspx?Tipo=" + "I" + "&Titulo=" + HttpContext.Current.Server.UrlEncode(Titulo) + "&Mensaje=" + HttpContext.Current.Server.UrlEncode(Descripcion), false);
                    break;
            }
        }

        public static void DescargarArchivo(string Archivo)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = @"application\octet-stream";
            System.IO.FileInfo file = new System.IO.FileInfo(Archivo);
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.WriteFile(file.FullName);
            HttpContext.Current.Response.Flush();
        }

        public static void EnviaMensajeH(string Descripcion, string Titulo, TiposMensaje Tipo)
        {
            Titulo = Convert.ToBase64String(Encoding.Unicode.GetBytes(Titulo));
            Descripcion = Convert.ToBase64String(Encoding.Unicode.GetBytes(Descripcion));

            switch (Tipo)
            {
                case TiposMensaje.Advertencia:
                    HttpContext.Current.Response.Redirect("Mensaje.aspx?Tipo=" + "A" + "&Titulo=" + HttpContext.Current.Server.UrlEncode(Titulo) + "&Mensaje=" + HttpContext.Current.Server.UrlEncode(Descripcion), false);
                    break;
                case TiposMensaje.Error:
                    HttpContext.Current.Response.Redirect("Mensaje.aspx?Tipo=" + "E" + "&Titulo=" + HttpContext.Current.Server.UrlEncode(Titulo) + "&Mensaje=" + HttpContext.Current.Server.UrlEncode(Descripcion), false);
                    break;
                case TiposMensaje.Informacion:
                    HttpContext.Current.Response.Redirect("Mensaje.aspx?Tipo=" + "I" + "&Titulo=" + HttpContext.Current.Server.UrlEncode(Titulo) + "&Mensaje=" + HttpContext.Current.Server.UrlEncode(Descripcion), false);
                    break;
            }
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();

            Array.Reverse(arr);

            return new string(arr);
        }

        public static string GeneraReferencia(string Credito, string Concepto = "333")
        {
            string v_referencia = "629" + Concepto.PadLeft(3, Convert.ToChar("0")) + Credito.PadLeft(9, Convert.ToChar("0"));
            string v_ponderacion = "21212121212121212";
            double n_suma = 0;
            double n_res1 = 0;
            double n_acum_dig = 0;

            for (int w = 0; w < v_referencia.Length; w++)
            {
                n_res1 = Convert.ToDouble(v_referencia.Substring(w, 1)) * Convert.ToDouble(v_ponderacion.Substring(w, 1));

                if (n_res1 > 9)
                {
                    n_acum_dig = 0;

                    for (int w2 = 0; w2 < n_res1.ToString().Length; w2++)
                    {
                        n_acum_dig = n_acum_dig + Convert.ToDouble(n_res1.ToString().Substring(w2, 1));
                    }

                    n_suma = n_suma + n_acum_dig;
                }
                else
                {
                    n_suma = n_suma + n_res1;
                }
            }

            double n_res2 = 0;
            double n_dv = 0;

            n_res2 = 10 - Convert.ToDouble(ReverseString(n_suma.ToString()).Substring(0, 1));

            if (n_res2 == 10)
                n_dv = 0;
            else
                n_dv = n_res2;

            v_referencia = v_referencia + n_dv.ToString();

            return v_referencia;
        }

        public static string GeneraNombreArchivoRnd(string Prefijo, string Extension)
        {
            Random rnd = new Random();
            string Nombre = "";

            if (string.IsNullOrEmpty(Prefijo))
                Prefijo = "";

            if (string.IsNullOrEmpty(Extension))
                Extension = "";

            Extension = Extension.Replace(".", "");

            Nombre = Prefijo + DateTime.Now.ToString("yyyyMMddHHmmss") + rnd.Next(1000).ToString().PadLeft(4, Convert.ToChar("0")) + "." + Extension;

            return Nombre;
        }

        public static void OrdenarDDL(ref DropDownList objDDL)
        {
            ArrayList textList = new ArrayList();
            ArrayList valueList = new ArrayList();

            foreach (ListItem li in objDDL.Items)
            {
                textList.Add(li.Text);
            }

            textList.Sort();

            foreach (object item in textList)
            {
                string value = objDDL.Items.FindByText(item.ToString()).Value;
                valueList.Add(value);
            }

            objDDL.Items.Clear();

            for (int i = 0; i < textList.Count; i++)
            {
                ListItem objItem = new ListItem(textList[i].ToString(), valueList[i].ToString());
                objDDL.Items.Add(objItem);
            }
        }

        public static string Equivalencia_SQLDotNet(string SQLDataType)
        {
            string Equivalente = "";

            switch(SQLDataType)
            {
                case "bigint":
                    Equivalente = "Int64";
                    break;
                case "binary":
                    Equivalente = "Byte[]";
                    break;
                case "bit":
                    Equivalente = "Boolean";
                    break;
                case "char":
                    Equivalente = "String";
                    break;
                case "date":
                    Equivalente = "DateTime";
                    break;
                case "datetime":
                    Equivalente = "DateTime";
                    break;
                case "datetime2":
                    Equivalente = "DateTime";
                    break;
                case "datetimeoffset":
                    Equivalente = "DateTimeOffset";
                    break;
                case "decimal":
                    Equivalente = "Decimal";
                    break;
                case "float":
                    Equivalente = "Double";
                    break;
                case "image":
                    Equivalente = "Byte[]";
                    break;
                case "int":
                    Equivalente = "Int32";
                    break;
                case "money":
                    Equivalente = "Decimal";
                    break;
                case "nchar":
                    Equivalente = "String";
                    break;
                case "ntext":
                    Equivalente = "String";
                    break;
                case "numeric":
                    Equivalente = "Decimal";
                    break;
                case "nvarchar":
                    Equivalente = "String";
                    break;
                case "real":
                    Equivalente = "Single";
                    break;
                case "rowversion":
                    Equivalente = "Byte[]";
                    break;
                case "smalldatetime":
                    Equivalente = "DateTime";
                    break;
                case "smallint":
                    Equivalente = "Int16";
                    break;
                case "smallmoney":
                    Equivalente = "Decimal";
                    break;
                case "sql_variant":
                    Equivalente = "Object";
                    break;
                case "text":
                    Equivalente = "String";
                    break;
                case "time":
                    Equivalente = "TimeSpan";
                    break;
                case "timestamp":
                    Equivalente = "Byte[]";
                    break;
                case "tinyint":
                    Equivalente = "Byte";
                    break;
                case "uniqueidentifier":
                    Equivalente = "Guid";
                    break;
                case "varbinary":
                    Equivalente = "Byte[]";
                    break;
                case "varchar":
                    Equivalente = "String";
                    break;
                case "xml":
                    Equivalente = "Xml";
                    break;
                default:
                    Equivalente = "String";
                    break;
            }

            return Equivalente;
        }

        public static System.Data.SqlDbType Equivalencia_SQL_SQLDBType(string SQLDataType)
        {
            System.Data.SqlDbType Tipo;

            Tipo = System.Data.SqlDbType.Variant;

            switch (SQLDataType)
            {
                case "bigint":
                    Tipo = System.Data.SqlDbType.BigInt;
                    break;
                case "binary":
                    Tipo = System.Data.SqlDbType.Binary;
                    break;
                case "bit":
                    Tipo = System.Data.SqlDbType.Bit;
                    break;
                case "char":
                    Tipo = System.Data.SqlDbType.Char;
                    break;
                case "date":
                    Tipo = System.Data.SqlDbType.Date;
                    break;
                case "datetime":
                    Tipo = System.Data.SqlDbType.DateTime;
                    break;
                case "datetime2":
                    Tipo = System.Data.SqlDbType.DateTime2;
                    break;
                case "datetimeoffset":
                    Tipo = System.Data.SqlDbType.DateTimeOffset;
                    break;
                case "decimal":
                    Tipo = System.Data.SqlDbType.Decimal;
                    break;
                case "float":
                    Tipo = System.Data.SqlDbType.Float;
                    break;
                case "image":
                    Tipo = System.Data.SqlDbType.Image;
                    break;
                case "int":
                    Tipo = System.Data.SqlDbType.Int;
                    break;
                case "money":
                    Tipo = System.Data.SqlDbType.Money;
                    break;
                case "nchar":
                    Tipo = System.Data.SqlDbType.NChar;
                    break;
                case "ntext":
                    Tipo = System.Data.SqlDbType.NText;
                    break;
                case "numeric":
                    Tipo = System.Data.SqlDbType.Decimal;
                    break;
                case "nvarchar":
                    Tipo = System.Data.SqlDbType.NVarChar;
                    break;
                case "real":
                    Tipo = System.Data.SqlDbType.Real;
                    break;
                case "rowversion":
                    Tipo = System.Data.SqlDbType.Timestamp;
                    break;
                case "smalldatetime":
                    Tipo = System.Data.SqlDbType.SmallDateTime;
                    break;
                case "smallint":
                    Tipo = System.Data.SqlDbType.SmallInt;
                    break;
                case "smallmoney":
                    Tipo = System.Data.SqlDbType.SmallMoney;
                    break;
                case "sql_variant":
                    Tipo = System.Data.SqlDbType.Variant;
                    break;
                case "text":
                    Tipo = System.Data.SqlDbType.Text;
                    break;
                case "time":
                    Tipo = System.Data.SqlDbType.Time;
                    break;
                case "timestamp":
                    Tipo = System.Data.SqlDbType.Timestamp;
                    break;
                case "tinyint":
                    Tipo = System.Data.SqlDbType.TinyInt;
                    break;
                case "uniqueidentifier":
                    Tipo = System.Data.SqlDbType.UniqueIdentifier;
                    break;
                case "varbinary":
                    Tipo = System.Data.SqlDbType.VarBinary;
                    break;
                case "varchar":
                    Tipo = System.Data.SqlDbType.VarChar;
                    break;
                case "xml":
                    Tipo = System.Data.SqlDbType.Xml;
                    break;
                default:
                    Tipo = System.Data.SqlDbType.Variant;
                    break;
            }

            return Tipo;
        }

        public static void TipoCatalogoRpt(ref DropDownList ddl)
        {
            System.Data.DataTable Combo = new System.Data.DataTable();
            System.Data.DataRow row;

            Combo.Columns.Add("Valor");
            Combo.Columns.Add("Descripcion");
            Combo.AcceptChanges();

            row = Combo.NewRow();
            row[0] = "";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "txt";
            row[1] = "Caja de texto";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "txtm";
            row[1] = "Caja de texto multilínea";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "chk";
            row[1] = "Casilla de verificación";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "lchk";
            row[1] = "Lista de selección múltiple";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "lst";
            row[1] = "Lista desplegable";
            Combo.Rows.Add(row);

            Combo.AcceptChanges();
            ddl.DataValueField = "Valor";
            ddl.DataTextField = "Descripcion";
            ddl.DataSource = Combo;
            ddl.DataBind();
        }

        public static string GenerarLlaveUnica(int Tamanno)
        {
            string Llave = "";
            int Iteraciones = (Tamanno / 8) + 3;

            for (int w = 0; w <= Iteraciones; w++)
            {
                Llave += Guid.NewGuid().ToString().GetHashCode().ToString("x");
            }

            Llave = Llave.Substring(0, Tamanno);

            return Llave;
        }

        public static string ObtenerHashCadena(string Cadena)
        {
            string hash = "";

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                hash = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(Cadena))).Replace("-", String.Empty);
            }

            return hash;
        }

        public static System.Data.DataTable GenerateTransposedTable(System.Data.DataTable inputTable)
        {
            System.Data.DataTable outputTable = new System.Data.DataTable();

            // Add columns by looping rows

            // Header row's first column is same as in inputTable
            outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

            // Header row's second column onwards, 'inputTable's first column taken
            foreach (System.Data.DataRow inRow in inputTable.Rows)
            {
                string newColName = inRow[0].ToString();
                outputTable.Columns.Add(newColName);
            }

            // Add rows by looping columns        
            for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
            {
                System.Data.DataRow newRow = outputTable.NewRow();

                // First column is inputTable's Header row's second column
                newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();

                for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                {
                    string colValue = inputTable.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }

                outputTable.Rows.Add(newRow);
            }

            return outputTable;
        }

        private static bool EmailInvalido = false;

        public static bool EsEmail(string strIn)
        {
            EmailInvalido = false;

            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            strIn = System.Text.RegularExpressions.Regex.Replace(strIn, @"(@)(.+)$", DomainMapper);
            if (EmailInvalido)
                return false;

            // Return true if strIn is in valid e-mail format.
            return System.Text.RegularExpressions.Regex.IsMatch(strIn,
                   @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                   System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        private static string DomainMapper(System.Text.RegularExpressions.Match match)
        {
            // IdnMapping class with default property values.
            System.Globalization.IdnMapping idn = new System.Globalization.IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                EmailInvalido = true;
            }
            return match.Groups[1].Value + domainName;
        }

        public static System.Data.DataTable ConvertirExcelADataTable(string Archivo, bool TieneEncabezados)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = System.IO.File.OpenRead(Archivo))
                {
                    pck.Load(stream);
                }

                var ws = pck.Workbook.Worksheets.First();
                System.Data.DataTable Tabla = new System.Data.DataTable();

                foreach (var PrimeraFila in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    Tabla.Columns.Add(TieneEncabezados ? PrimeraFila.Text : string.Format("Column {0}", PrimeraFila.Start.Column));
                }

                var FilaInicial = TieneEncabezados ? 2 : 1;

                for (var rowNum = FilaInicial; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsFila = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    var Fila = Tabla.NewRow();

                    foreach (var celda in wsFila)
                    {
                        Fila[celda.Start.Column - 1] = celda.Text;
                    }

                    Tabla.Rows.Add(Fila);
                }

                return Tabla;
            }
        }

        #region ManejoFechas
        public static DateTime? ValidaFecha(string Fecha)
        {
            DateTime Test = new DateTime();

            if (DateTime.TryParse(Fecha, out Test))
                return Test;
            else
                return null;
        }

        public static DateTime? ConvierteFecha(string Fecha)
        {
            try
            {
                DateTime Test = new DateTime(Convert.ToInt32(Fecha.Substring(6, 4)), Convert.ToInt32(Fecha.Substring(3, 2)), Convert.ToInt32(Fecha.Substring(0, 2)));

                return Test;
            }
            catch
            {
                return null;
            }
        }

        public static DateTime FechaInicioSemana(DateTime Fecha, DayOfWeek DiaInicial)
        {
            int dif = Fecha.DayOfWeek - DiaInicial;

            if (dif < 0)
                dif += 7;

            return Fecha.AddDays(-1 * dif).Date;
        }

        public static DateTime ObtieneFecha(string Fecha)
        {
            DateTime f;

            if (DateTime.TryParseExact(Fecha, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out f))
                return f;
            else
                return new DateTime(1900, 1, 1);
        }

        public static DateTime ObtieneFechaHora(string Fecha)
        {
            DateTime f;

            if (DateTime.TryParseExact(Fecha, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out f))
                return f;
            else
                return new DateTime(1900, 1, 1);
        }

        public enum FormatosFecha
        {
            Dianum_Mestxt_Anno,
            Diatxt_Dianum_Mestxt_Anno
        }

        public static string CrearFechas(string sFecha, FormatosFecha ff)
        {
            string fFecha = "";
            DateTime Fecha = ObtieneFecha(sFecha);

            if (Fecha.ToString("yyyyMMdd") != "19000101")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-MX");

                switch (ff)
                {
                    case FormatosFecha.Dianum_Mestxt_Anno:
                        fFecha = Fecha.ToString("dd") + " de " + Fecha.ToString("MMMM") + " de " + Fecha.ToString("yyyy");
                        break;
                    case FormatosFecha.Diatxt_Dianum_Mestxt_Anno:
                        fFecha = Fecha.ToString("dddd") + ", " + Fecha.ToString("dd") + " de " + Fecha.ToString("MMMM") + " de " + Fecha.ToString("yyyy");
                        break;
                    default:
                        fFecha = "";
                        break;
                }
            }
            else
            {
                fFecha = "ErrorEnFecha";
            }

            return fFecha;
        }

        public static bool EsFecha(string Fecha)
        {
            DateTime f;

            if (DateTime.TryParseExact(Fecha, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out f))
                return true;
            else
                return false;
        }

        public static TimeSpan CalculateDateDiff(DateTime ini, DateTime fin)
        {
            TimeSpan diff = (fin - ini);
            return diff;
        }
        #endregion ManejoFechas

    }
}

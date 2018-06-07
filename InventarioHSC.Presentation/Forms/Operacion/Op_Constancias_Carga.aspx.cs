using System;
using System.Linq;
using System.Web.UI;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Operacion
{
    public partial class Op_Constancias_Carga : System.Web.UI.Page
    {
        #region Variables

        private BLConstancias objCon = new BLConstancias();

        #endregion Variables

        #region Metodos

        protected bool ExisteConstanciaPrevia(int ConA_Id, int ConP_Id, DateTime Fecha)
        {
            bool Res;
            string MensajeBD = objCon.VerificarExistencia(ConA_Id, ConP_Id, Fecha);

            if (MensajeBD == "Existe")
            {
                Res = true;
                hddIgnorarValidacion.Value = "1";
                lblExistente.Text = "Ya existe una constancia cargada para el portafolio y año seleccionados.<br/>Si desea continuar, cargue nuevamente el archivo y de clic en el botón 'Cargar datos'";
            }
            else if (MensajeBD.Contains("Error"))
            {
                Res = true;
                hddIgnorarValidacion.Value = "0";
                lblExistente.Text = MensajeBD;
            }
            else
            {
                Res = false;
                hddIgnorarValidacion.Value = "0";
                lblExistente.Text = "";
            }

            return Res;
        }

        protected string ValidaCabecera(string Linea)
        {
            const int CTipoReg = 0;
            const int CConReg = 1;
            const int CConArc = 2;
            const int CFecha = 3;
            const int CEjercicio = 4;
            const int CRFC = 5;
            const int CUsoFuturo = 6;

            const int LongitudCabecera = 8;
            const int TipoRegistro = 1;
            const int AnioMinimo = 2005;
            const int LongitudRFC = 12;

            string Validaciones = "";
            string[] DatosCabecera = Linea.Split(new char[] { '|' }, StringSplitOptions.None);

            if (DatosCabecera.Length == LongitudCabecera)
            {
                int Entero = 0;

                //Tipo de registro
                int.TryParse(DatosCabecera[CTipoReg], out Entero);
                if (Entero != TipoRegistro) { Validaciones += "Encabezado\tTipo de registro incorrecto.\t1" + Environment.NewLine; }

                //Consecutivo de registro
                Entero = 0;
                int.TryParse(DatosCabecera[CConReg], out Entero);
                if (Entero != 1) { Validaciones += "Encabezado\tConsecutivo de registro incorrecto.\t1" + Environment.NewLine; }

                //Consecutivo de archivo
                Entero = 0;
                int.TryParse(DatosCabecera[CConArc], out Entero);
                if (Entero < 1) { Validaciones += "Encabezado\tConsecutivo de archivo incorrecto.\t1" + Environment.NewLine; }

                //Fecha
                if (!DatosGenerales.EsFecha(DatosCabecera[CFecha].Substring(6, 2) + "/" + DatosCabecera[CFecha].Substring(4, 2) + "/" + DatosCabecera[CFecha].Substring(0, 4)))
                    Validaciones += "Encabezado\tFecha de presentación incorrecta: " + DatosCabecera[CFecha].Substring(6, 2) + "/" + DatosCabecera[CFecha].Substring(4, 2) + "/" + DatosCabecera[CFecha].Substring(0, 4) + ".\t1" + Environment.NewLine;

                //Ejercicio
                Entero = 0;
                int.TryParse(DatosCabecera[CEjercicio], out Entero);
                if (Entero < AnioMinimo || Entero > DateTime.Now.Year) { Validaciones += "Encabezado\tEjercicio incorrecto, se espera un valor mayor a " + AnioMinimo.ToString() + " y menor a " + DateTime.Now.AddYears(1).Year.ToString() + ".\t1" + Environment.NewLine; }

                //RFC
                if (DatosCabecera[CRFC].Trim().Length != LongitudRFC) { Validaciones += "Encabezado\tRFC incorrecto.\t1" + Environment.NewLine; }

                //UsoFuturo (Campo vacío)
                if (DatosCabecera[CUsoFuturo].Trim().Length != 0) { Validaciones += "Encabezado\tCampo reservado para uso futuro, debe estar vacío.\t1" + Environment.NewLine; }
            }
            else
            {
                Validaciones += "Encabezado\tEl número de elementos actuales (" + DatosCabecera.Length.ToString() + ") no coincide con la cantidad deseada (" + LongitudCabecera.ToString() + ").\t1" + Environment.NewLine;
            }

            return Validaciones;
        }

        protected string ValidaDetalle(string Linea, int NoLinea)
        {
            const int CTipoReg = 0;
            const int CConReg = 1;
            const int CClaveId = 2;
            const int CRFC = 3;
            const int CCURP = 4;
            const int CNombre = 5;
            const int CDomicilio = 6;
            const int CRefNumContr = 7;
            const int CNumRegFid = 8;
            const int CIntNomDev = 9;
            const int CIntNomPag = 10;
            const int CIntMorDev = 11;
            const int CIntMorPag = 12;
            const int CIntReal = 13;
            const int CSaldCred = 14;
            const int CMontoOrig = 15;
            const int CFechaContr = 16;
            const int CPropDed = 17;
            const int CDomInm = 18;
            const int CCredDerFide = 19;
            const int CCredDestino = 20;
            const int CCredCofi = 21;

            const int LongitudDetalle = 23;
            const int TipoRegistro = 2;
            int[] CatIdEstrReg = new int[] { 1, 2 };
            int[] LongitudRFC = new int[] { 9, 10, 12, 13 };
            //int[] LongitudCURP = new int[] { 0, 18 };
            int MaxLongitudCURP = 18;
            const int MaxNombre = 150;
            const int MaxDomicilio = 295;
            const int MaxRefNumContr = 40;
            const int MaxNumRegFid = 40;
            const decimal MaxValorMontos = 99999999.99M;
            const int PropDedMin = 0;
            const int PropDedMax = 100;
            const int MaxDomInm = 295;

            string Validaciones = "";
            string[] DatosDetalle = Linea.Split(new char[] { '|' }, StringSplitOptions.None);

            if (DatosDetalle.Length == LongitudDetalle)
            {
                int Entero = 0;
                decimal vDecimal = 0;

                //Tipo de registro
                int.TryParse(DatosDetalle[CTipoReg], out Entero);
                if (Entero != TipoRegistro) { Validaciones += "Detalle\tTipo de registro incorrecto." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Consecutivo de registro
                Entero = 0;
                int.TryParse(DatosDetalle[CConReg], out Entero);
                if (Entero < 1) { Validaciones += "Detalle\tConsecutivo de registro incorrecto." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Clave de identificador
                Entero = 0;
                int.TryParse(DatosDetalle[CClaveId], out Entero);
                if (!CatIdEstrReg.Contains(Entero)) { Validaciones += "Detalle\tClave de identificador incorrecta." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //RFC
                if (!LongitudRFC.Contains(DatosDetalle[CRFC].Trim().Length)) { Validaciones += "Detalle\tRFC incorrecto." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //CURP
                //if (!LongitudCURP.Contains(DatosDetalle[CCURP].Trim().Length)) { Validaciones += "Detalle\tCURP incorrecto." + "\t" + NoLinea.ToString() + Environment.NewLine; }
                if (DatosDetalle[CCURP].Trim().Length > MaxLongitudCURP) { Validaciones += "Detalle\tCURP incorrecto." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Nombre
                if (DatosDetalle[CNombre].Trim().Length > MaxNombre || DatosDetalle[CNombre].Trim().Length < 1) { Validaciones += "Detalle\tNombre con longitud incorrecta." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Domicilio
                if (DatosDetalle[CDomicilio].Trim().Length > MaxDomicilio || DatosDetalle[CDomicilio].Trim().Length < 1) { Validaciones += "Detalle\tDomicilio con longitud incorrecta." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Número de referencia Número de Contrato
                if (DatosDetalle[CRefNumContr].Trim().Length > MaxRefNumContr) { Validaciones += "Detalle\tNúmero de referencia/contrato con longitud incorrecta." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Número de registro del fideicomiso
                if (DatosDetalle[CNumRegFid].Trim().Length > MaxNumRegFid) { Validaciones += "Detalle\tNúmero de registro del fideicomiso con longitud incorrecta." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Interés nominal devengado en el ejercicio
                vDecimal = 0;
                if (decimal.TryParse(DatosDetalle[CIntNomDev], out vDecimal) == false || vDecimal > MaxValorMontos) { Validaciones += "Detalle\tInterés nominal devengado en el ejercicio incorrecto." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Interés nominal pagado en el ejercicio
                vDecimal = 0;
                if (decimal.TryParse(DatosDetalle[CIntNomPag], out vDecimal) == false || vDecimal > MaxValorMontos) { Validaciones += "Detalle\tInterés nominal pagado en el ejercicio incorrecto." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Interés moratorio devengado en el ejercicio
                vDecimal = 0;
                if (decimal.TryParse(DatosDetalle[CIntMorDev], out vDecimal) == false || vDecimal > MaxValorMontos) { Validaciones += "Detalle\tInterés moratorio devengado en el ejercicio incorrecto." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Interés moratorio pagado en el ejercicio
                vDecimal = 0;
                if (decimal.TryParse(DatosDetalle[CIntMorPag], out vDecimal) == false || vDecimal > MaxValorMontos) { Validaciones += "Detalle\tInterés moratorio pagado en el ejercicio incorrecto." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Interés real
                vDecimal = 0;
                if (decimal.TryParse(DatosDetalle[CIntReal], out vDecimal) == false || vDecimal > MaxValorMontos) { Validaciones += "Detalle\tInterés real incorrecto." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Saldo del crédito al 31 de diciembre del periodo reportado
                vDecimal = 0;
                if (decimal.TryParse(DatosDetalle[CSaldCred], out vDecimal) == false || vDecimal > MaxValorMontos) { Validaciones += "Detalle\tSaldo del crédito al 31 de diciembre del periodo reportado incorrecto." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Monto original del crédito hipotecario a la fecha de contratación
                vDecimal = 0;
                if (decimal.TryParse(DatosDetalle[CMontoOrig], out vDecimal) == false || vDecimal > MaxValorMontos) { Validaciones += "Detalle\tMonto original del crédito hipotecario a la fecha de contratación incorrecto." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Fecha de contratación
                if (!DatosGenerales.EsFecha(DatosDetalle[CFechaContr].Substring(6, 2) + "/" + DatosDetalle[CFechaContr].Substring(4, 2) + "/" + DatosDetalle[CFechaContr].Substring(0, 4)))
                    Validaciones += "Encabezado\tFecha de contratación incorrecta: " + DatosDetalle[CFechaContr].Substring(6, 2) + "/" + DatosDetalle[CFechaContr].Substring(4, 2) + "/" + DatosDetalle[CFechaContr].Substring(0, 4) + "." + Environment.NewLine;

                //Proporción deducible
                Entero = 0;
                int.TryParse(DatosDetalle[CPropDed], out Entero);
                if (Entero < PropDedMin || Entero > PropDedMax) { Validaciones += "Detalle\tProporción deducible incorrecta." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Domicilio del inmueble hipotecado
                if (DatosDetalle[CDomInm].Trim().Length > MaxDomInm || DatosDetalle[CDomInm].Trim().Length < 1) { Validaciones += "Detalle\tDomicilio del inmueble hipotecado con longitud incorrecta." + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Crédito derivado de fideicomiso (S|N)
                if (DatosDetalle[CCredDerFide].Trim().Length > 1) { Validaciones += "Detalle\tCrédito derivado de fideicomiso incorrecto" + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Destino del credito (A|C|R|P|O)
                if (DatosDetalle[CCredDestino].Trim().Length > 1) { Validaciones += "Detalle\tDestino del credito incorrecto" + "\t" + NoLinea.ToString() + Environment.NewLine; }

                //Crédito en cofinanciamiento (S|N)
                if (DatosDetalle[CCredCofi].Trim().Length > 1) { Validaciones += "Detalle\tCrédito en cofinanciamiento" + "\t" + NoLinea.ToString() + Environment.NewLine; }
            }
            else
            {
                Validaciones += "Detalle\tEl número de elementos actuales (" + DatosDetalle.Length.ToString() + ") no coincide con la cantidad deseada (" + LongitudDetalle.ToString() + ")." + Environment.NewLine;
            }

            return Validaciones;
        }

        protected void ValidaDatos(string Archivo)
        {
            int NoLinea = 0;
            //string Validaciones = "";
            int TotalLineas = System.IO.File.ReadLines(Archivo).Count();
            System.IO.TextWriter tw;

            tw = new System.IO.StreamWriter(Archivo + ".log", false, System.Text.Encoding.UTF8);

            foreach (string linea in System.IO.File.ReadLines(Archivo))
            {
                NoLinea++;

                if (NoLinea > 1 && NoLinea < TotalLineas)
                {
                    tw.Write(ValidaDetalle(linea, NoLinea));
                }
                else if (NoLinea == 1)
                {
                    tw.Write(ValidaCabecera(linea));
                }
            }

            //CrearArchivo(Validaciones);
            tw.Close();
            TotalLineas = System.IO.File.ReadLines(Archivo + ".log").Count();
            lblMsjCarga.ForeColor = System.Drawing.Color.Red;
            lnkLog.Visible = false;

            if (TotalLineas == 0)
            {
                //lblMsjCarga.Text = "El archivo ha superado satisfactoriamente las validaciones.";
                //lblMsjCarga.ForeColor = System.Drawing.Color.Black;
                btnCargar.Enabled = true;
                hddArchivoCorrecto.Value = "1";
                lblCarga.Text = "El archivo " + System.IO.Path.GetFileName(hddArchivoOriginal.Value) + " ha superado satisfactoriamente las validaciones.";
                pnlCarga.Visible = false;
            }
            else
            {
                lblMsjCarga.Text = "El archivo no superó las validaciones puede descargar el";
                lnkLog.NavigateUrl = DatosGenerales.RutaReportesDinamicos + System.IO.Path.GetFileName(Archivo) + ".log";
                btnCargar.Enabled = false;
                lnkLog.Visible = true;
                hddArchivoCorrecto.Value = "0";
                hddArchivo.Value = "";
            }
        }

        protected void Procesar(int ConA_Id, int ConP_Id, DateTime ConL_Fecha, string ConL_NombreArchivo, string ConL_Identificador)
        {
            string ResLote = objCon.InsertarLote(ConA_Id, ConP_Id, ConL_Fecha, ConL_NombreArchivo, ConL_Identificador);
            int ConL_Id = 0;
            int NoLinea = 0;
            string Resultados = "";
            string Archivo = hddArchivo.Value;

            int.TryParse(ResLote, out ConL_Id);

            if (ConL_Id > 0)
            {
                int TotalLineas = System.IO.File.ReadLines(Archivo).Count();

                foreach (string linea in System.IO.File.ReadLines(Archivo))
                {
                    NoLinea++;

                    if (NoLinea > 1 && NoLinea < TotalLineas)
                    {
                        string ResLinea = objCon.InsertarDetalle(ConL_Id, linea);

                        if (ResLinea.Contains("Error"))
                            Resultados += NoLinea + "\t" + ResLinea + Environment.NewLine;
                    }
                }

                if (Resultados == "")
                {
                    DatosGenerales.EnviaMensaje("Ha finalizado la carga del archivo", "Carga de datos para constancias", DatosGenerales.TiposMensaje.Informacion);
                }
                else
                {
                    string ArchivoErr = Server.MapPath("../Reportes/TmpFiles/") + DatosGenerales.GeneraNombreArchivoRnd("Const_", "log");

                    System.IO.File.WriteAllText(ArchivoErr, Resultados);
                    DatosGenerales.EnviaMensaje("Finalizó la carga con algunos errores. Descargue el archivo con el detalle de los mismos.", "Carga de datos para constancias", System.IO.Path.GetFileName(ArchivoErr), DatosGenerales.TiposMensaje.Error);
                }
            }
            else
            {
                DatosGenerales.EnviaMensaje(ResLote, "Error al insertar el lote", DatosGenerales.TiposMensaje.Error);
            }
        }

        #endregion Metodos

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                objCon.ObtenerCatalogos(ref ddlAdministradora, (int)DatosGenerales.ConstanciasCatalogos.Administradoras, 0, true, "Seleccionar administradora");
            }

            if (IsPostBack)
            {
                bool fileOK = false;
                string path = Server.MapPath("../Reportes/TmpFiles/");

                if (upFile.HasFile && hddArchivo.Value == "")
                {
                    string fileExtension = System.IO.Path.GetExtension(upFile.FileName).ToLower();
                    string[] allowedExtensions = { ".txt" };

                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                            fileOK = true;
                    }

                    if (fileOK)
                    {
                        try
                        {
                            BLBovedaContra objBov = new BLBovedaContra();
                            string Archivo = path + DatosGenerales.GeneraNombreArchivoRnd("Const_", "txt");

                            hddArchivoOriginal.Value = upFile.FileName;
                            upFile.PostedFile.SaveAs(Archivo);
                            hddArchivo.Value = Archivo;

                            ValidaDatos(Archivo);
                        }
                        catch (Exception ex)
                        {
                            lblMsjCarga.Text = "No se pudo cargar el archivo: " + ex.Message;
                        }
                    }
                    else
                    {
                        lblMsjCarga.Text = "Tipo de archivo incorrecto.";
                    }
                }
            }
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            int Administradora = 0;
            int Portafolio = 0;
            int ArchivoCorrecto = 0;
            DateTime Fecha;
            bool HayError = false;

            int.TryParse(ddlAdministradora.SelectedValue, out Administradora);
            int.TryParse(ddlPortafolio.SelectedValue, out Portafolio);
            lblReqAdmin.Text = "";
            lblReqFecha.Text = "";
            lblReqPort.Text = "";
            lblMsjCarga.Text = "";
            lblExistente.Text = "";

            Fecha = DatosGenerales.ObtieneFecha(txtFecha.Text);

            if (DatosGenerales.EsFecha(txtFecha.Text))
            {
                imgReqFecha.ImageUrl = "~/App_Themes/Imagenes/ico_check.gif";
            }
            else
            {
                HayError = true;
                lblReqFecha.Text = "Fecha incorrecta";
                imgReqFecha.ImageUrl = "~/App_Themes/Imagenes/ico_uncheck.gif";
            }

            if (Administradora <= 0)
            {
                HayError = true;
                lblReqAdmin.Text = "Campo requerido";
                imgReqAdmin.ImageUrl = "~/App_Themes/Imagenes/ico_uncheck.gif";
            }
            else
            {
                imgReqAdmin.ImageUrl = "~/App_Themes/Imagenes/ico_check.gif";
            }

            if (Portafolio <= 0)
            {
                HayError = true;
                lblReqPort.Text = "Campo requerido";
                imgReqPort.ImageUrl = "~/App_Themes/Imagenes/ico_uncheck.gif";
            }
            else
            {
                imgReqPort.ImageUrl = "~/App_Themes/Imagenes/ico_check.gif";
            }

            int.TryParse(hddArchivoCorrecto.Value, out ArchivoCorrecto);

            if (ArchivoCorrecto != 1)
            {
                HayError = true;
                lblExistente.Text = "El archivo no cumple con el formato requerido";
            }

            if (!HayError)
            {
                int IgnorarValidacion = 0;

                int.TryParse(hddIgnorarValidacion.Value, out IgnorarValidacion);

                if (IgnorarValidacion > 0)
                {
                    Procesar(Administradora, Portafolio, DatosGenerales.ObtieneFecha(txtFecha.Text), System.IO.Path.GetFileName(hddArchivoOriginal.Value), txtIdentificador.Text.Trim());
                }
                else
                {
                    if (!ExisteConstanciaPrevia(Administradora, Portafolio, Fecha))
                    {
                        Procesar(Administradora, Portafolio, DatosGenerales.ObtieneFecha(txtFecha.Text), System.IO.Path.GetFileName(hddArchivoOriginal.Value), txtIdentificador.Text.Trim());
                    }
                }
            }
        }

        protected void ddlAdministradora_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Administradora = 0;

            int.TryParse(ddlAdministradora.SelectedValue, out Administradora);

            if (Administradora > 0)
            {
                objCon.ObtenerCatalogos(ref ddlPortafolio, (int)DatosGenerales.ConstanciasCatalogos.Portafolios_por_administradora, Administradora, true, "Seleccionar portafolio");
                lblReqAdmin.Text = "";
                imgReqAdmin.ImageUrl = "~/App_Themes/Imagenes/ico_check.gif";
            }
            else
            {
                objCon.ObtenerCatalogos(ref ddlPortafolio, (int)DatosGenerales.ConstanciasCatalogos.Portafolios_por_administradora, -1, true, "Seleccionar portafolio");
                lblReqAdmin.Text = "Campo requerido";
                imgReqAdmin.ImageUrl = "~/App_Themes/Imagenes/ico_uncheck.gif";
            }

            if (ddlPortafolio.Items.Count == 2)
            {
                ddlPortafolio.SelectedIndex = 1;
                imgReqPort.ImageUrl = "~/App_Themes/Imagenes/ico_check.gif";
            }
            else
            {
                imgReqPort.ImageUrl = "~/App_Themes/Imagenes/ico_uncheck.gif";
            }
        }

        protected void ddlPortafolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Portafolio = 0;

            int.TryParse(ddlPortafolio.SelectedValue, out Portafolio);

            if (Portafolio > 0)
            {
                lblReqPort.Text = "";
                imgReqPort.ImageUrl = "~/App_Themes/Imagenes/ico_check.gif";
            }
            else
            {
                lblReqPort.Text = "Campo requerido";
                imgReqPort.ImageUrl = "~/App_Themes/Imagenes/ico_uncheck.gif";
            }
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
        }

        #endregion Eventos
    }
}
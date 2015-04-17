using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Servidores
{
    public partial class AltaBoveda : System.Web.UI.Page
    {
        #region Metodos
        protected string IngresarContrasenna(string Hash, int Tipo, string UserName, string Objeto, string vLogin, string Pass)
        {
            BLBovedaContra objBov = new BLBovedaContra();
            De_CryptDLL.De_Crypt crypto = new De_CryptDLL.De_Crypt();
            string Errores = "";

            Pass = crypto.Encriptar(Pass, Objeto + vLogin + hddKey.Value, true);
            Errores = objBov.IngresarContrasenna(Hash, Tipo, UserName, Objeto, vLogin, Pass);

            return Errores;
        }

        protected string ValidarExcel(System.Data.DataTable Tabla)
        {
            string Errores = "";

            if (Tabla.Columns.Contains("Tipo") && Tabla.Columns.Contains("Objeto") && Tabla.Columns.Contains("Usuario") && Tabla.Columns.Contains("Contraseña"))
            {
                if (Tabla.Rows.Count > 0)
                {
                    //Validar registro por registro la integridad de los datos
                    for (int w = 0; w < Tabla.Rows.Count; w++)
                    {
                        bool EstaEnEnum = false;
                        int Tipo = 0;

                        int.TryParse(Tabla.Rows[w]["Tipo"].ToString(), out Tipo);

                        foreach (DatosGenerales.BovedaTipos vTipo in Enum.GetValues(typeof(DatosGenerales.BovedaTipos)))
                        {
                            if (Tipo == (int)vTipo)
                            {
                                EstaEnEnum = true;
                                break;
                            }
                        }

                        if (!EstaEnEnum)
                        {
                            Errores = "El registro " + (w + 1).ToString() + " tiene un valor incorrecto para el campo Tipo" + "<br />";
                            break;
                        }

                        if (string.IsNullOrWhiteSpace(Tabla.Rows[w]["Objeto"].ToString()))
                        {
                            Errores = "El registro " + (w + 1).ToString() + " tiene un valor incorrecto para el campo Objeto" + "<br />";
                            break;
                        }

                        if (string.IsNullOrWhiteSpace(Tabla.Rows[w]["Usuario"].ToString()))
                        {
                            Errores = "El registro " + (w + 1).ToString() + " tiene un valor incorrecto para el campo Usuario" + "<br />";
                            break;
                        }

                        if (string.IsNullOrWhiteSpace(Tabla.Rows[w]["Contraseña"].ToString()))
                        {
                            Errores = "El registro " + (w + 1).ToString() + " tiene un valor incorrecto para el campo Contraseña" + "<br />";
                            break;
                        }

                        Tabla.Rows[w]["Objeto"] = Tabla.Rows[w]["Objeto"].ToString().Trim();
                        Tabla.Rows[w]["Usuario"] = Tabla.Rows[w]["Usuario"].ToString().Trim();
                        Tabla.Rows[w]["Contraseña"] = Tabla.Rows[w]["Contraseña"].ToString().Trim();
                    }
                }
                else
                {
                    Errores = "El archivo no contiene registros";
                }
            }
            else
            {
                Errores = "El archivo no contiene el formato correcto";
            }

            return Errores;
        }
        #endregion Metodos

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string script = "$(document).ready(function () { $('[id*=btnSubmit]').click(); });";
                ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);

                BLBovedaContra objBov = new BLBovedaContra();

                grdDatos.DataSource = objBov.ObtenerListaTipos();
                grdDatos.DataBind();
            }

            if (IsPostBack && hddKey.Value == "")
            {
                bool fileOK = false;
                bool fileOKM = false;
                string path = Server.MapPath("../Reportes/TmpFiles/");

                pnlDatos.Visible = false;
                pnlDatosM.Visible = false;

                if (upFile.HasFile)
                {
                    string fileExtension = System.IO.Path.GetExtension(upFile.FileName).ToLower();
                    string[] allowedExtensions = { ".bkey" };

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
                            string Archivo = path + DatosGenerales.GeneraNombreArchivoRnd("Bov_", "bkey");

                            upFile.PostedFile.SaveAs(Archivo);
                            hddKey.Value = System.IO.File.ReadAllText(Archivo);
                            System.IO.File.Delete(Archivo);

                            if (objBov.VerificarHash(DatosGenerales.ObtenerHashCadena(hddKey.Value)) > 0)
                            {
                                pnlCarga.Visible = false;
                                hddHash.Value = DatosGenerales.ObtenerHashCadena(hddKey.Value);
                                objBov.ObtenerListaTipos(ref ddlTipos);

                                if (rbMultiple.Checked)
                                    pnlDatosM.Visible = true;
                                else
                                    pnlDatos.Visible = true;
                            }
                            else
                            {
                                lblMsjCarga.Text = "No se encontró el Hash suministrado.";
                            }
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

                if (upFileM.HasFile)
                {
                    string fileExtension = System.IO.Path.GetExtension(upFileM.FileName).ToLower();
                    string[] allowedExtensions = { ".xlsx" };

                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                            fileOKM = true;
                    }

                    if (fileOKM)
                    {
                        try
                        {
                            BLBovedaContra objBov = new BLBovedaContra();
                            string Archivo = path + DatosGenerales.GeneraNombreArchivoRnd("Bov_", "xlsx");

                            upFileM.PostedFile.SaveAs(Archivo);
                            hddArchivoExcel.Value = Archivo;
                            pnlCargaExcel.Visible = false;
                            pnlPostCargaExcel.Visible = true;
                            lblExcel.Text = "Archivo de excel cargado.";
                        }
                        catch (Exception ex)
                        {
                            lblMsjCargaM.Text = "No se pudo cargar el archivo: " + ex.Message;
                        }
                    }
                    else
                    {
                        lblMsjCargaM.Text = "Tipo de archivo incorrecto.";
                    }
                }
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            string Errores = "";

            txtObjeto.Text = txtObjeto.Text.Trim();
            txtUsuario.Text = txtUsuario.Text.Trim();
            txtPass.Text = txtPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtObjeto.Text))
                Errores = "Nombre de objeto incorrecto<br />";

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                Errores = "Usuario incorrecto<br />";

            if (string.IsNullOrWhiteSpace(txtPass.Text))
                Errores = "Contraseña incorrecta<br />";

            if (ddlTipos.SelectedValue == "0")
                Errores = "Tipo incorrecto<br />";

            if (Errores == "")
            {
                int Tipo = 0;

                int.TryParse(ddlTipos.SelectedValue, out Tipo);
                Errores = IngresarContrasenna(hddHash.Value, Tipo, Session["UserNameLogin"].ToString(), txtObjeto.Text, txtUsuario.Text, txtPass.Text);

                if (Errores == "")
                {
                    DatosGenerales.EnviaMensaje("Proceso finalizado correctamente", "Ingreso de contraseña", DatosGenerales.TiposMensaje.Informacion);
                }
                else
                {
                    MsgBox.AddMessage(Errores, YaBu.MessageBox.uscMsgBox.enmMessageType.Error);
                }
            }
            else
            {
                MsgBox.AddMessage(Errores, YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
            }
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            pnlCarga.Visible = true;
            pnlOpciones.Visible = false;
        }

        protected void btnProcesarM_Click(object sender, EventArgs e)
        {
            string Errores = "";
            System.Data.DataTable Tabla = new System.Data.DataTable();

            Tabla = DatosGenerales.ConvertirExcelADataTable(hddArchivoExcel.Value, true);
            Errores = ValidarExcel(Tabla);

            if (Errores == "")
            {
                for (int w = 0; w < Tabla.Rows.Count; w++)
                {
                    int Tipo = 0;

                    int.TryParse(Tabla.Rows[w]["Tipo"].ToString(), out Tipo);
                    Errores = IngresarContrasenna(hddHash.Value, Tipo, Session["UserNameLogin"].ToString(), Tabla.Rows[w]["Objeto"].ToString(), Tabla.Rows[w]["Usuario"].ToString(), Tabla.Rows[w]["Contraseña"].ToString());
                }

                if (Errores == "")
                    DatosGenerales.EnviaMensaje("Proceso finalizado correctamente", "Ingreso de contraseñas", DatosGenerales.TiposMensaje.Informacion);
                else
                    DatosGenerales.EnviaMensaje(Errores, "Error al insertar contraseña", DatosGenerales.TiposMensaje.Error);
            }
            else
            {
                DatosGenerales.EnviaMensaje(Errores, "Validación de Excel", DatosGenerales.TiposMensaje.Advertencia);
            }
        }

        protected void btnCargar2_Click(object sender, EventArgs e)
        {
            pnlDatosM.Visible = true;
        }
        #endregion Eventos
    }
}
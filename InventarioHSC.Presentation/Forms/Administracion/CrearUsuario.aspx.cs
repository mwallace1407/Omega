using System;
using System.Web.UI;
using InventarioHSC.BusinessLayer;

namespace InventarioHSC.Forms.Administracion
{
    public partial class CrearUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                txtUsuario.Focus();
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BLSeguridad objSeg = new BLSeguridad();
                string Res = "";

                Res = objSeg.CrearUsuario(txtUsuario.Text.Trim(), txtEMail.Text.Trim(), txtNombre.Text.Trim());

                if (Res == "OK")
                    Model.DatosGenerales.EnviaMensaje("Se ha creado el usuario", "Operación satisfactoria", Model.DatosGenerales.TiposMensaje.Informacion);
                else if (Res.Contains("Error"))
                    Model.DatosGenerales.EnviaMensaje(Res, "Error al crear el usuario", Model.DatosGenerales.TiposMensaje.Error);
                else
                    Model.DatosGenerales.EnviaMensaje("El usuario ya existe", "Error operativo", Model.DatosGenerales.TiposMensaje.Advertencia);
            }
        }
    }
}
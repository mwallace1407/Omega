using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Catalogos
{
    public partial class CatalogoGruposSoftware : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            BLSoftware objGrupoSoftware = new BLSoftware();

            if (txtDescripcion.Text.Trim() != "")
            {
                MsgBox.AddMessage(objGrupoSoftware.InsertaGrupoSoftware(txtDescripcion.Text.Trim()), YaBu.MessageBox.uscMsgBox.enmMessageType.Info);
            }
            else
            {
                MsgBox.AddMessage("Debe introducir un texto válido en el campo descripción.", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }
    }
}
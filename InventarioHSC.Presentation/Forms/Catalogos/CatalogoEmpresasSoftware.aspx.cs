﻿using System;
using InventarioHSC.BusinessLayer;

namespace InventarioHSC.Forms.Catalogos
{
    public partial class CatalogoEmpresasSoftware : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            BLSoftware objEmpresaSoftware = new BLSoftware();

            if (txtDescripcion.Text.Trim() != "")
            {
                MsgBox.AddMessage(objEmpresaSoftware.InsertaEmpresaSoftware(txtDescripcion.Text.Trim()), YaBu.MessageBox.uscMsgBox.enmMessageType.Info);
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
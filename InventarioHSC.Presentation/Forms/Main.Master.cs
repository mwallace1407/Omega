using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms
{
    public partial class Main : System.Web.UI.MasterPage
    {
        /*
         Agregando una nueva carpeta de módulos.
         *
         * Main.Master.cs:
         *              Page_Load, agregar en el switch cuidando la cantidad de caracteres
         * BLSeguridad.cs:
         *              AccesoPermitido, agregar en la lista de texto a remover
         *stpI_HistoricoApp: agregar en la lista de texto a remover
         *
         * El menú inicio se crea en InventarioHSC.BusinessLayer.TextWriter
         */
        protected const string PaginaInicio = "default.aspx";
        protected const int MinimoCadena = 14;

        #region Eventos

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.ClientScript.IsStartupScriptRegistered(GetType(), "MaskedEditFix"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "MaskedEditFix", String.Format("<script type='text/javascript' src='{0}'></script>", Page.ResolveUrl("~/Scripts/MaskedEditFix.js")), false);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string NivelRuta = "";

            string PaginaActual = (this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx").Trim().ToLower();

            if (PaginaActual.Length >= MinimoCadena)
            {
                switch (PaginaActual.Substring(0, 14))
                {
                    case "forms_articulo":
                        NivelRuta = "../";
                        break;

                    case "forms_catalogo":
                        NivelRuta = "../";
                        break;

                    case "forms_software":
                        NivelRuta = "../";
                        break;

                    case "forms_reportes":
                        NivelRuta = "../";
                        break;

                    case "forms_aplicaci":
                        NivelRuta = "../";
                        break;

                    case "forms_administ":
                        NivelRuta = "../";
                        break;

                    case "forms_maximage":
                        NivelRuta = "../";
                        break;

                    case "forms_servidor":
                        NivelRuta = "../";
                        break;

                    case "forms_operacio":
                        NivelRuta = "../";
                        break;
                }

                AplicaEstilo(NivelRuta);
            }

            if (Request.IsAuthenticated)
            {
                if (Session["NombreCompletoUsuario"] != null)
                {
                    ((Label)LoginView3.FindControl("lblNombreCompletoUsuario")).Text = Session["NombreCompletoUsuario"].ToString();
                    //((Label)LoginView3.FindControl("lblNombreCompletoRol")).Text = Session["NombreCompletoRol"].ToString();

                    if (sender.ToString() == "ASP.forms_main_master")
                    {
                        CreaMenu(NivelRuta);
                    }
                }
                else
                {
                    try
                    {
                        Session.Clear();
                        System.Web.Security.FormsAuthentication.SignOut();

                        if ((this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx").Trim().ToLower() != PaginaInicio)
                            Response.Redirect("~/Forms/sessionTimeout.html");
                    }
                    catch { Response.Redirect("~/Forms/sessionTimeout.html"); }
                }
            }
            else
            {
                try
                {
                    Session.Clear();
                    System.Web.Security.FormsAuthentication.SignOut();

                    if ((this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx").Trim().ToLower() != PaginaInicio)
                        Response.Redirect("~/Forms/sessionTimeout.html");
                }
                catch { Response.Redirect("~/Forms/sessionTimeout.html"); }
            }

            if (!Page.IsPostBack && !Page.IsCallback)
            {
                if (Session["UserNameLogin"] != null && Session["UserNameLogin"].ToString() != "")
                {
                    if (!BLSeguridad.AccesoPermitido(Session["UserNameLogin"].ToString(), this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx"))
                        Model.DatosGenerales.EnviaMensaje("No tiene autorización para ingresar a la página solicitada: " + this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx", "Permisos insuficientes", Model.DatosGenerales.TiposMensaje.Advertencia);
                }
            }
        }

        protected void LoginStatus3_LoggedOut(object sender, EventArgs e)
        {
        }

        #endregion Eventos

        #region Menu

        private void CreaMenu(string NivelRuta)
        {
            BLMenu oBLMenu = new BLMenu();
            List<sysMenu> lMenu = new List<sysMenu>();
            Literal lit = new Literal();

            if (Session["UserNameLogin"] != null && Session["UserNameLogin"].ToString() != "")
                lMenu = oBLMenu.ObtieneHijosPorIDN(Session["UserNameLogin"].ToString(), 1, true, NivelRuta);
            else
                Response.Redirect("~/Forms/sessionTimeout.html", false);

            PlaceHolder MainPlaceHolder = new PlaceHolder();
            MainPlaceHolder = (PlaceHolder)this.LoginView2.Controls[0].FindControl("MainPlaceHolder");

            lit = new Literal();
            lit.Text += TextWriter.MakeOpenUlWithClassAndId("topmenu", "css3menu1");
            lit.Text += TextWriter.MakeHomeNew(NivelRuta);
            lit.Text += TextWriter.MakeCloseli();
            Session["Cadenota"] += lit.Text;
            MainPlaceHolder.Controls.Add(lit);

            foreach (sysMenu oMenu in lMenu)
                fnGeneraOpcionMenu(1, oMenu, false, NivelRuta);

            lit = new Literal();
            lit.Text = TextWriter.MakeULCloseTag();
            MainPlaceHolder.Controls.Add(lit);
        }

        private static Literal DivOpenMenu(Literal lit, PlaceHolder MainPlaceHolder1)
        {
            lit = new Literal();
            lit.Text = TextWriter.MakeOpenULNoClass();
            MainPlaceHolder1.Controls.Add(lit);
            return lit;
        }

        private static Literal DivCloseMenu(Literal lit, PlaceHolder MainPlaceHolder1)
        {
            lit = new Literal();
            lit.Text = TextWriter.MakeULCloseTag();
            MainPlaceHolder1.Controls.Add(lit);
            return lit;
        }

        protected void fnGeneraOpcionMenu(int idrolv, sysMenu oItemMenu, bool EsTopMenu, string NivelRuta)
        {
            Literal lit = new Literal();
            List<sysMenu> lstMenuItem = new List<sysMenu>();
            BLMenu oBLMenu = new BLMenu();
            PlaceHolder MainPlaceHolder1 = new PlaceHolder();

            if (Session["UserNameLogin"] != null && Session["UserNameLogin"].ToString() != "")
                lstMenuItem = oBLMenu.ObtieneHijosPorIDN(Session["UserNameLogin"].ToString(), oItemMenu.idMenu, EsTopMenu, NivelRuta);
            else
                Response.Redirect("~/Forms/sessionTimeout.html", false);

            MainPlaceHolder1 = (PlaceHolder)this.LoginView2.Controls[0].FindControl("MainPlaceHolder");

            if (oItemMenu.fcCss.Contains("parent"))
            {
                lit = new Literal();
                lit.Text = oItemMenu.fcHtml;
                MainPlaceHolder1.Controls.Add(lit);
                lit = DivOpenMenu(lit, MainPlaceHolder1);
            }

            foreach (sysMenu itemMenu in lstMenuItem)
            {
                if (itemMenu.fcCss.Contains("parent"))
                {
                    fnGeneraOpcionMenu(1, itemMenu, false, NivelRuta);
                }
                else
                {
                    lit = new Literal();
                    lit.Text = itemMenu.fcHtml;
                    MainPlaceHolder1.Controls.Add(lit);
                }
            }
            lit = DivCloseMenu(lit, MainPlaceHolder1);
            return;
        }

        #endregion Menu

        #region Diseño

        public string RutaFondoPagina = "";
        public string RutaLogoPagina = "";

        protected void AplicaEstilo(string NivelRuta)
        {
            RutaFondoPagina = NivelRuta + "../App_Themes/Imagenes/SuCasitaWater.png";
            RutaLogoPagina = NivelRuta + "../App_Themes/Imagenes/logo_horizontal.png";
        }

        protected string ObtenerMenuGenerado(PlaceHolder MainPlaceHolder)
        {
            string mnu = "";

            foreach (Control ctrl in MainPlaceHolder.Controls)
            {
                try
                {
                    Literal lit = new Literal();

                    lit = (Literal)ctrl;
                    mnu += lit.Text;
                }
                catch { }
            }

            return mnu;
        }

        #endregion Diseño
    }
}
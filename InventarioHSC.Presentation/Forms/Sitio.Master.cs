using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms
{
    public partial class Sitio : System.Web.UI.MasterPage
    {
        public string imgPath = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                imgPath = System.Web.VirtualPathUtility.ToAbsolute("~/App_Themes/imagenes/pistol.jpg");

                if (Session["NombreCompletoUsuario"] != null)
                {
                    ((Label)LoginView3.FindControl("lblNombreCompletoUsuario")).Text = Session["NombreCompletoUsuario"].ToString();
                    ((Label)LoginView3.FindControl("lblNombreCompletoRol")).Text = Session["NombreCompletoRol"].ToString();
                    if (sender.ToString() == "ASP.forms_sitio_master")
                    {
                        CreaMenu();
                    }
                }
                else
                {
                    try
                    {
                        Session.Clear();
                        System.Web.Security.FormsAuthentication.SignOut();

                        if ((this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx").Trim().ToLower() != "acceso.aspx")
                            Response.Redirect("~/Forms/sessionTimeout.html");
                    }
                    catch { Response.Redirect("~/Forms/sessionTimeout.html"); }
                }
            }
            else
            {
                //imgPath = System.Web.VirtualPathUtility.ToAbsolute("~/App_Themes/imagenes/FondoCastor_50.png");
            }
        }

        private void CreaMenu()
        {
            BLMenu oBLMenu = new BLMenu();
            List<sysMenu> lMenu = new List<sysMenu>();
            Literal lit = new Literal();

            lMenu = oBLMenu.ObtieneHijosPorID(1, 1);

            PlaceHolder MainPlaceHolder = new PlaceHolder();
            MainPlaceHolder = (PlaceHolder)this.LoginView2.Controls[0].FindControl("MainPlaceHolder");

            lit = new Literal();
            lit.Text = TextWriter.MakeOpenDivid("menu");
            lit.Text += TextWriter.MakeOpenUlWithClass("menu");
            lit.Text += TextWriter.MakeHome();
            lit.Text += TextWriter.MakeCloseli();
            Session["Cadenota"] += lit.Text;
            MainPlaceHolder.Controls.Add(lit);

            foreach (sysMenu oMenu in lMenu)
            {
                fnGeneraOpcionMenu(1, oMenu);
            }

            //lit = new Literal();
            //lit.Text = TextWriter.MakeLogout();
            //lit.Text += TextWriter.MakeCloseli();
            //Session["Cadenota"] += lit.Text;
            //MainPlaceHolder.Controls.Add(lit);

            lit = new Literal();
            lit.Text = TextWriter.MakeULCloseTag();
            lit.Text += TextWriter.MakeCloseDiv();
            MainPlaceHolder.Controls.Add(lit);
        }

        protected void LoginStatus3_LoggedOut(object sender, EventArgs e)
        {
        }

        protected void fnGeneraOpcionMenu(int idrolv, sysMenu oItemMenu)
        {
            Literal lit = new Literal();
            List<sysMenu> lstMenuItem = new List<sysMenu>();
            BLMenu oBLMenu = new BLMenu();
            lstMenuItem = oBLMenu.ObtieneHijosPorID(1, oItemMenu.idMenu);
            PlaceHolder MainPlaceHolder1 = new PlaceHolder();
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
                    fnGeneraOpcionMenu(1, itemMenu);
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

        private static Literal DivCloseMenu(Literal lit, PlaceHolder MainPlaceHolder1)
        {
            lit = new Literal();
            lit.Text = TextWriter.MakeULCloseTag();
            lit.Text += TextWriter.MakeCloseDiv();
            MainPlaceHolder1.Controls.Add(lit);
            return lit;
        }

        private static Literal DivOpenMenu(Literal lit, PlaceHolder MainPlaceHolder1)
        {
            lit = new Literal();
            lit.Text = TextWriter.MakeOpenDiv();
            lit.Text += TextWriter.MakeOpenULNoClass();
            MainPlaceHolder1.Controls.Add(lit);
            return lit;
        }
    }
}
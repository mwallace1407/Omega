namespace InventarioHSC.Presentacion.General
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Web.SessionState;
	using System.Text;

    //using sucasita.modelo;
    //using sucasita.modelo.Principales;
    //using sucasita.Private.modelo.Seguridad;
    using System.Data.SqlClient;

	/// <summary>
	///		Summary description for bnrGeneral.
	/// </summary>
	public partial class bnrGeneral : System.Web.UI.UserControl
	{
		public string urlSitio;
		public string menuprincipal;
		public string menuInmueble;
		protected SqlConnection MysqlCnn;
		protected SqlCommand cmdMySQLCommand;
		protected System.Web.UI.WebControls.Label Label1;
		protected SqlDataReader rdrDatascipter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
			}

			if (Session["UserNombre"] == null) //Si la sesión ha caducado
			{
				Response.Redirect("~/acceso.aspx?endSession=1",true);
			}
			else
				this.LabelUser.Text = Session["UserNombre"].ToString();

			if(Request["controles"]==null)
			{

				urlSitio = "http://"+HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
				if (HttpContext.Current.Request.ApplicationPath!="/")
				{
					urlSitio = urlSitio+HttpContext.Current.Request.ApplicationPath;
				}
				
                creaMenu();
                creaSubMenus();

				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				sb.Append("<script language=Javascript>\n");
				sb.Append("fixMozillaZIndex=true;  \n");
				sb.Append("_menuCloseDelay=500; \n");
				sb.Append("_menuOpenDelay=150; \n");
				sb.Append("_subOffsetTop=2; \n");
				sb.Append("_subOffsetLeft=-2; \n");
				sb.Append("with(mainmenuStyle=new mm_style()){  \n");
				sb.Append("styleid=1;  \n");
				sb.Append("bordercolor=\"#296488\";  \n");
				sb.Append("borderstyle=\"solid\";  \n");
				sb.Append("borderwidth=1;  \n");
				sb.Append("fontfamily=\"Trebuchet MS, Verdana, Tahoma, Arial\";  \n");
				sb.Append("fontsize=\"100%\";  \n");
				sb.Append("fontstyle=\"normal\";  \n");
				sb.Append("imagepadding=3;  \n");
				sb.Append("offbgcolor=\"#2255AA\";  \n");
				sb.Append("offcolor=\"#FFFFFF\";  \n");
				sb.Append("onbgcolor=\"#ffffff\";  \n");
				sb.Append("oncolor=\"#000000\";  \n");
				sb.Append("onsubimage=\"" + this.urlSitio + "/Scripts/bob_arrow.gif\";  \n");
				sb.Append("padding=5;  \n");
				sb.Append("subimage=\"" + this.urlSitio + "/Scripts/bob_arrow1.gif\";  \n");
				sb.Append("subimagepadding=6;  \n");
				sb.Append("itemwidth=90;}  \n");
				sb.Append("with(menuStyle=new mm_style()){  \n");
				sb.Append("bordercolor=\"#6D6E72\";  \n");
				sb.Append("borderstyle=\"dotted\";  \n");
				sb.Append("borderwidth=1;  \n");
				sb.Append("fontfamily=\"Trebuchet MS, Verdana, Tahoma, Arial\";  \n");
				sb.Append("fontsize=\"100%\";  \n");
				sb.Append("fontstyle=\"normal\";  \n");
				sb.Append("headerbgcolor=\"#ffffff\";  \n");
				sb.Append("headercolor=\"#000000\";  \n");
				sb.Append("offbgcolor=\"#ffffff\";  \n");
				sb.Append("offcolor=\"#000000\";  \n");
				sb.Append("onbgcolor=\"#A4C5F1\";  \n");
				sb.Append("oncolor=\"#000000\";  \n");
				sb.Append("onsubimage=\"" + this.urlSitio + "/Scripts/bob_left.gif\";  \n");
				sb.Append("padding=5;  \n");
				sb.Append("subimage=\"" + this.urlSitio + "/Scripts/bob_left1.gif\";  \n");
				sb.Append("subimagepadding=6;}  \n");
				sb.Append("with(menuStyle2=new mm_style()){  \n");
				sb.Append("bordercolor=\"#6D6E72\";  \n");
				sb.Append("borderstyle=\"dotted\";  \n");
				sb.Append("borderwidth=1;  \n");
				sb.Append("fontfamily=\"Trebuchet MS, Verdana, Tahoma, Arial\";  \n");
				sb.Append("fontsize=\"100%\";  \n");
				sb.Append("fontstyle=\"normal\";  \n");
				sb.Append("headerbgcolor=\"#E9838D\";  \n");
				sb.Append("headercolor=\"#000000\";  \n");
				sb.Append("offbgcolor=\"#E9838D\";  \n");
				sb.Append("offcolor=\"#FFFFFF\";  \n");
				sb.Append("onbgcolor=\"#A4C5F1\";  \n");
				sb.Append("oncolor=\"#000000\";  \n");
				sb.Append("onsubimage=\"" + this.urlSitio + "/Scripts/bob_left.gif\";  \n");
				sb.Append("padding=5;  \n");
				sb.Append("subimage=\"" + this.urlSitio + "/Scripts/bob_left1.gif\";  \n");
				sb.Append("subimagepadding=6;}  \n");
				sb.Append("with(milonic=new menuname(\"Main Menu\")){  \n");
				sb.Append("alwaysvisible=1;  \n");
				sb.Append("left=0;  \n");
				sb.Append("orientation=\"horizontal\";  \n");
				sb.Append("style=mainmenuStyle;  \n");
				sb.Append("top=55;  \n");
				sb.Append(menuprincipal+"; } \n");
				sb.Append(menuInmueble+"; \n");
				sb.Append("drawMenus(); \n");
				sb.Append("</script>");

				string script = sb.ToString();

				Page.RegisterStartupScript("script",sb.ToString()) ; 
			}

		}

        /// <summary>
        /// Crea el menú superior de la aplicación, nivel 0
        /// </summary>
		private void creaMenu()
		{
			try
			{
				this.MysqlCnn = new SqlConnection();			
				this.MysqlCnn.ConnectionString = System.Configuration.ConfigurationSettings.AppSettings.Get("Inventario");
				if(this.MysqlCnn.State == System.Data.ConnectionState.Closed) 
					this.MysqlCnn.Open();		// Corregido

				SqlCommand cmdMySQLCommand = new  SqlCommand();
				cmdMySQLCommand.CommandType = CommandType.StoredProcedure;
				cmdMySQLCommand.CommandText = "SELECCIONA_OPCIONES_PRINCIPAL";
				cmdMySQLCommand.Connection = MysqlCnn;

				
				cmdMySQLCommand.Parameters.Add("@idResponsable", SqlDbType.BigInt);
				cmdMySQLCommand.Parameters["@idResponsable"].Value = Session["UserId"].ToString();

				SqlDataReader rdrDatascipter = cmdMySQLCommand.ExecuteReader();
				menuprincipal = "";
				if (rdrDatascipter.HasRows)
				{
                    while (rdrDatascipter.Read())
                    {
                        //Si el menu principal no tiene nodos hijos se pinta de manera normal de lo contrario, se agrega un submenu.
                        if (Convert.ToInt32(rdrDatascipter.GetSqlValue(5).ToString()) > 0)
                        {
                            menuprincipal = menuprincipal + " aI(\"showmenu=" + rdrDatascipter.GetSqlValue(0).ToString().Trim() + "SubMenu" + ";align=center;text=" + Convert.ToString(rdrDatascipter.GetSqlValue(1).ToString().Trim()) + ";\"); ";
                        }
                        else
                        {
                            menuprincipal = menuprincipal + " aI(\"align=center;text=" + Convert.ToString(rdrDatascipter.GetSqlValue(1).ToString().Trim()) + ";url=" + urlSitio + Convert.ToString(rdrDatascipter.GetSqlValue(2).ToString().Trim()) + "\"); ";
                        }
                    } 
				}

				rdrDatascipter.Close();
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
			}
			finally
			{
				if(this.MysqlCnn.State != System.Data.ConnectionState.Closed) 
					this.MysqlCnn.Close();	
			}	 

		}

        /// <summary>
        /// Crea los menús de nivel N
        /// </summary>
        private void creaSubMenus()
        {
            try
            {
                this.MysqlCnn = new SqlConnection();
                this.MysqlCnn.ConnectionString = System.Configuration.ConfigurationSettings.AppSettings.Get("ConSqlString");
                if (this.MysqlCnn.State == System.Data.ConnectionState.Closed)
                    this.MysqlCnn.Open();		// Corregido

                SqlCommand cmdMySQLCommand = new SqlCommand();
                cmdMySQLCommand.CommandType = CommandType.StoredProcedure;
                cmdMySQLCommand.CommandText = "Selecciona_Opciones_Submenu";
                cmdMySQLCommand.Connection = MysqlCnn;

                SqlParameter sqlParam1 = cmdMySQLCommand.Parameters.Add("@idRol", SqlDbType.Int);
                sqlParam1.Direction = ParameterDirection.Input;
                sqlParam1.Value = Convert.ToInt16(Session["CveRol"]);
        

                SqlDataReader rdrDatascipter = cmdMySQLCommand.ExecuteReader();

                int BanderaMenu = 0;
                int NumeroMenu = 0;

                if (rdrDatascipter.HasRows)
                {
                    while (rdrDatascipter.Read())
                    {
                        if (BanderaMenu == 0)
                        {
                            if (Convert.ToBoolean(rdrDatascipter.GetSqlValue(7).ToString()))
                                menuInmueble = menuInmueble + " with(milonic=new menuname(\"" + rdrDatascipter.GetSqlValue(5).ToString().Trim() + "SubMenuN\")) { overflow=\"scroll\"; style=menuStyle;";
                            else
                                menuInmueble = menuInmueble + " with(milonic=new menuname(\"" + rdrDatascipter.GetSqlValue(5).ToString().Trim() + "SubMenu\")) { overflow=\"scroll\"; style=menuStyle;";

                            BanderaMenu = 1;
                            NumeroMenu = Convert.ToInt32(rdrDatascipter.GetSqlValue(5).ToString());
                        }

                        int NumeroMenuItera = Convert.ToInt32(rdrDatascipter.GetSqlValue(5).ToString());

                        if (NumeroMenuItera == NumeroMenu)
                        {
                            //si el menu no tiene hijos se pinta normal
                            if (Convert.ToInt32(rdrDatascipter.GetSqlValue(6).ToString()) > 0)
                                menuInmueble = menuInmueble + " aI(\"showmenu=" +  rdrDatascipter.GetSqlValue(0).ToString().Trim() + "SubMenuN" + ";text=" + Convert.ToString(rdrDatascipter.GetSqlValue(1).ToString().Trim()) + ";\"); ";
                            else
                                menuInmueble = menuInmueble + " aI(\"text=" + Convert.ToString(rdrDatascipter.GetSqlValue(1).ToString().Trim()) + ";url=" + urlSitio + Convert.ToString(rdrDatascipter.GetSqlValue(2).ToString().Trim()) + "\"); ";
                        }
                        else
                        {
                            menuInmueble = menuInmueble + " } ; \n";

                            if (Convert.ToBoolean(rdrDatascipter.GetSqlValue(7).ToString()))
                                menuInmueble = menuInmueble + " with(milonic=new menuname(\"" + rdrDatascipter.GetSqlValue(5).ToString().Trim() + "SubMenuN\")) { overflow=\"scroll\"; style=menuStyle;";
                            else
                                menuInmueble = menuInmueble + " with(milonic=new menuname(\"" + rdrDatascipter.GetSqlValue(5).ToString().Trim() + "SubMenu\")) { overflow=\"scroll\"; style=menuStyle;";

                            //si el menu no tiene hijos se pinta normal
                            if (Convert.ToInt32(rdrDatascipter.GetSqlValue(6).ToString()) > 0)
                                menuInmueble = menuInmueble + " aI(\"showmenu=" +  rdrDatascipter.GetSqlValue(0).ToString().Trim() + "SubMenuN" + ";text=" + Convert.ToString(rdrDatascipter.GetSqlValue(1).ToString().Trim()) + ";\"); ";
                            else
                                menuInmueble = menuInmueble + " aI(\"text=" + Convert.ToString(rdrDatascipter.GetSqlValue(1).ToString().Trim()) + ";url=" + urlSitio + Convert.ToString(rdrDatascipter.GetSqlValue(2).ToString().Trim()) + "\"); ";
        
                            BanderaMenu = 1;
                            NumeroMenu = Convert.ToInt32(rdrDatascipter.GetSqlValue(5).ToString());                          
                        }
                    }

                    //cierra el ultimo menu creado
                    menuInmueble = menuInmueble + " } ; \n"; 
                }
                rdrDatascipter.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (this.MysqlCnn.State != System.Data.ConnectionState.Closed)
                    this.MysqlCnn.Close();
            }
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion
	}
}

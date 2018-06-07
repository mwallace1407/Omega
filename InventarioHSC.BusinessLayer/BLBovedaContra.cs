using System;
using System.Data;
using System.Web.UI.WebControls;
using InventarioHSC.DataLayer;
using InventarioHSC.Model;

namespace InventarioHSC.BusinessLayer
{
    public class BLBovedaContra
    {
        #region Correo

        private Mailer.ArrayOfString CorreosCC = new Mailer.ArrayOfString();
        private string CorreoTo = "";

        private void ParseMailAcc(string Correos)
        {
            Mailer.ArrayOfString CorreoLista = new Mailer.ArrayOfString();

            try
            {
                string[] Separador = { "|" };
                CorreoLista.AddRange(Correos.Split(Separador, StringSplitOptions.RemoveEmptyEntries));

                if (CorreoLista.Count > 0)
                {
                    CorreoTo = CorreoLista[0];

                    if (CorreoLista.Count == 1)
                    {
                        CorreosCC = null;
                    }
                    else
                    {
                        for (int w = 1; w < CorreoLista.Count; w++)
                        {
                            CorreosCC.Add(CorreoLista[w]);
                        }
                    }
                }
            }
            catch
            {
                CorreoLista = null;
            }
        }

        #endregion Correo

        public string GuardarLlave(string UserName)
        {
            string Errores = "";

            try
            {
                DLBovedaContra objBov = new DLBovedaContra();
                string Llave = DatosGenerales.GenerarLlaveUnica(DatosGenerales.LongitudLlaveBoveda);

                DataTable Parametros = new DataTable();

                Parametros = DatosGenerales.GenerateTransposedTable(objBov.ObtenerParametros());

                if (Parametros.TableName != "Error")
                {
                    string To = Parametros.Rows[0]["To"].ToString();
                    string UsarProxy = Parametros.Rows[0]["UsarProxy"].ToString();
                    string ProxyIP = Parametros.Rows[0]["ProxyIP"].ToString();
                    string ProxyU = Parametros.Rows[0]["ProxyU"].ToString();
                    string ProxyP = Parametros.Rows[0]["ProxyP"].ToString();

                    System.Net.WebProxy proxyObj = System.Net.WebProxy.GetDefaultProxy();
                    proxyObj.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;

                    if (UsarProxy == "S")
                    {
                        System.Net.WebProxy proxyObject = new System.Net.WebProxy(ProxyIP, true);
                        proxyObject.Credentials = new System.Net.NetworkCredential(ProxyU, ProxyP);
                        System.Net.WebRequest.DefaultWebProxy = proxyObject;
                    }

                    Mailer.MailerServiceSoapClient mail = new Mailer.MailerServiceSoapClient();

                    ParseMailAcc(To);

                    Errores = mail.SendMailAttTxt("", CorreoTo, CorreosCC, "Bóveda contraseñas - " + Environment.MachineName, "El usuario " + UserName + " ha solicitado una nueva llave.", true, Llave, DatosGenerales.GeneraNombreArchivoRnd("Bov_", ".bkey"));

                    System.Net.WebRequest.DefaultWebProxy = proxyObj;

                    if (Errores == "")
                        objBov.GuardarLlave(UserName, DatosGenerales.ObtenerHashCadena(Llave));
                }
                else
                {
                    Errores = Parametros.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
            }

            return Errores;
        }

        public string GuardarLlave(string UserName, string CorreoEspecial)
        {
            string Errores = "";

            try
            {
                DLBovedaContra objBov = new DLBovedaContra();
                string Llave = DatosGenerales.GenerarLlaveUnica(DatosGenerales.LongitudLlaveBoveda);

                DataTable Parametros = new DataTable();

                Parametros = DatosGenerales.GenerateTransposedTable(objBov.ObtenerParametros());

                if (Parametros.TableName != "Error")
                {
                    string UsarProxy = Parametros.Rows[0]["UsarProxy"].ToString();
                    string ProxyIP = Parametros.Rows[0]["ProxyIP"].ToString();
                    string ProxyU = Parametros.Rows[0]["ProxyU"].ToString();
                    string ProxyP = Parametros.Rows[0]["ProxyP"].ToString();

                    System.Net.WebProxy proxyObj = System.Net.WebProxy.GetDefaultProxy();
                    proxyObj.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;

                    if (UsarProxy == "S")
                    {
                        System.Net.WebProxy proxyObject = new System.Net.WebProxy(ProxyIP, true);
                        proxyObject.Credentials = new System.Net.NetworkCredential(ProxyU, ProxyP);
                        System.Net.WebRequest.DefaultWebProxy = proxyObject;
                    }

                    Mailer.MailerServiceSoapClient mail = new Mailer.MailerServiceSoapClient();

                    Errores = mail.SendMailAttTxt("", CorreoEspecial, null, "Bóveda contraseñas - " + Environment.MachineName, "El usuario " + UserName + " ha solicitado una nueva llave.", true, Llave, DatosGenerales.GeneraNombreArchivoRnd("Bov_", ".bkey"));

                    System.Net.WebRequest.DefaultWebProxy = proxyObj;

                    if (Errores == "")
                    {
                        IngresarLog(DatosGenerales.BovedaAcciones.Generar_llave, 0, UserName, "");
                        objBov.GuardarLlave(UserName, DatosGenerales.ObtenerHashCadena(Llave));
                    }
                }
                else
                {
                    Errores = Parametros.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
            }

            return Errores;
        }

        public int VerificarHash(string Hash)
        {
            DLBovedaContra objBov = new DLBovedaContra();

            return objBov.VerificarHash(Hash);
        }

        public void ObtenerListaTipos(ref DropDownList ddl, bool IncluirValorInicial = true)
        {
            DLBovedaContra objBov = new DLBovedaContra();

            ddl.DataValueField = "Valor";
            ddl.DataTextField = "Descripcion";
            ddl.DataSource = objBov.ObtenerListaTipos();
            ddl.DataBind();

            if (IncluirValorInicial)
                ddl.Items.Insert(0, new ListItem("Seleccionar tipo", "0"));
        }

        public DataTable ObtenerListaTipos()
        {
            DLBovedaContra objBov = new DLBovedaContra();

            return objBov.ObtenerListaTipos();
        }

        public string IngresarLog(DatosGenerales.BovedaAcciones Accion, int Id, string UserName, string Observaciones)
        {
            DLBovedaContra objBov = new DLBovedaContra();

            return objBov.IngresarLog((int)Accion, Id, UserName, Observaciones);
        }

        public string IngresarContrasenna(string Hash, int Tipo, string UserName, string Objeto, string Login, string Pass)
        {
            DLBovedaContra objBov = new DLBovedaContra();

            return objBov.IngresarContrasenna(Hash, Tipo, UserName, Objeto, Login, Pass);
        }

        public void ObtenerListaP(ref DropDownList ddl, string Hash, int Tipo, bool IncluirValorInicial = true)
        {
            DLBovedaContra objBov = new DLBovedaContra();

            ddl.DataValueField = "Valor";
            ddl.DataTextField = "Descripcion";
            ddl.DataSource = objBov.ObtenerListaP(Hash, Tipo);
            ddl.DataBind();

            if (IncluirValorInicial)
                ddl.Items.Insert(0, new ListItem("Seleccionar elemento", "0"));
        }

        public struct DatosPass
        {
            public string Pass;
            public string Objeto;
            public string Login;

            public DatosPass(int Id)
            {
                DLBovedaContra objBov = new DLBovedaContra();
                DataTable MensajeBD = new DataTable();

                MensajeBD = objBov.ObtenerPassEncriptado(Id);

                Pass = "";
                Objeto = "";
                Login = "";

                try
                {
                    if (MensajeBD.Rows.Count > 0)
                    {
                        Pass = MensajeBD.Rows[0]["BC_Pass"].ToString();
                        Objeto = MensajeBD.Rows[0]["BC_Objeto"].ToString();
                        Login = MensajeBD.Rows[0]["BC_Login"].ToString();
                    }
                }
                catch { }
            }
        }
    }
}
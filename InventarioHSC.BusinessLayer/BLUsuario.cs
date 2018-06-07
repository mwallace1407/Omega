using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using InventarioHSC.DataLayer;
using InventarioHSC.Model;

namespace InventarioHSC.BusinessLayer
{
    public class BLUsuario
    {
        public BLUsuario()
        {
        }

        public List<Usuario> ObtieneUsuarioAll()
        {
            DLUsuario odlUsuario = new DLUsuario();
            List<Usuario> lstUsu = new List<Usuario>();
            List<Usuario> lstretUsuario = new List<Usuario>();

            try
            {
                lstUsu = odlUsuario.getUsuarioAll();
                lstUsu.RemoveAll(x => x.idUsuario == 0);
                lstretUsuario = lstUsu.OrderBy(x => x.idUsuario).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstretUsuario;
        }

        public int InsertaUsuario(int i_idUsuario, string s_nombre, int i_idPuesto, string s_estatus)
        {
            Usuario objUsuario = new Usuario();
            DLUsuario odlUsuario = new DLUsuario();

            objUsuario.idUsuario = i_idUsuario;
            objUsuario.nombre = s_nombre;
            objUsuario.idPuesto = i_idPuesto;
            objUsuario.puestoDesc = string.Empty;
            objUsuario.estatus = s_estatus;

            try
            {
                odlUsuario.InsertUsuario(ref objUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objUsuario.idUsuario;
        }

        public int ActualizaUsuario(int i_idUsuario, string s_nombre, int i_idPuesto, string s_estatus)
        {
            Usuario objUsuario = new Usuario();
            DLUsuario odlUsuario = new DLUsuario();

            objUsuario.idUsuario = i_idUsuario;
            objUsuario.nombre = s_nombre;
            objUsuario.idPuesto = i_idPuesto;
            objUsuario.estatus = s_estatus;

            try
            {
                odlUsuario.UpdateUsuario(ref objUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUsuario.idUsuario;
        }

        public Usuario ObtenUsuario(int id_Usuario)
        {
            DLUsuario usu = new DLUsuario();

            return usu.getUsuarioporID(id_Usuario);
        }

        public int EliminaUsuario(int i_idUsuario)
        {
            Usuario objUsuario = new Usuario();
            DLUsuario odlUsuario = new DLUsuario();

            int TotalArticulos;
            objUsuario = odlUsuario.getUsuarioporID(i_idUsuario);
            objUsuario.idPuesto = 176;
            objUsuario.estatus = "INACTIVO";

            try
            {
                TotalArticulos = odlUsuario.CountArticuloUsuario(i_idUsuario);
                if (TotalArticulos == 0)
                {
                    odlUsuario.UpdateUsuario(ref objUsuario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TotalArticulos;
        }

        public int ValidaSistemaAsignado(int i_idSistema)
        {
            int TotalArticulos;
            DLSistemaOperativo odlSis = new DLSistemaOperativo();

            try
            {
                TotalArticulos = odlSis.CountArticuloSistemaOperativo(i_idSistema);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TotalArticulos;
        }

        #region Permisos_Usuarios

        public void BuscarUsuarioPermisos(ref DropDownList oddlUsu, string strBusqueda)
        {
            DLUsuario odlUsuario = new DLUsuario();

            oddlUsu.DataValueField = "puestoDesc";
            oddlUsu.DataTextField = "nombre";
            oddlUsu.DataSource = odlUsuario.BuscarUsuarioPermisos(strBusqueda);
        }

        public System.Data.DataTable LeePermisosUsuario(string UserId)
        {
            DLUsuario odlUsuario = new DLUsuario();

            return odlUsuario.LeePermisosUsuario(UserId);
        }

        public System.Data.DataTable ActualizaPermisosUsuario(string UserId, int idMenu, bool Usu_Autorizado)
        {
            DLUsuario odlUsuario = new DLUsuario();

            return odlUsuario.ActualizaPermisosUsuario(UserId, idMenu, Usu_Autorizado);
        }

        #endregion Permisos_Usuarios
    }
}
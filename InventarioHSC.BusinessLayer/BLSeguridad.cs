using System.Collections.Generic;
using System.Linq;
using InventarioHSC.DataLayer;
using InventarioHSC.Model;

namespace InventarioHSC.BusinessLayer
{
    public class BLSeguridad
    {
        private DLSeguridad objSeg = new DLSeguridad();

        public bool ValidaUsuario(string sNombre, string sContraseña)
        {
            return objSeg.ValidaUsuario(sNombre, sContraseña);
        }

        public string DatosDelUsuario(string UsuarioId)
        {
            UsuarioSeguridad oUsuario = new UsuarioSeguridad();

            oUsuario = objSeg.getUserByID(UsuarioId);

            return oUsuario.nombreCompleto;
        }

        public string RolDelUsuario(string UsuarioId)
        {
            List<RolSeguridad> lstRoles = new List<RolSeguridad>();

            lstRoles = objSeg.getRolesUserByID(UsuarioId);

            return lstRoles.First().RolDescripcion.ToString();
        }

        public List<RolSeguridad> RolesDelUsuario(string UsuarioId)
        {
            List<RolSeguridad> lstRoles = new List<RolSeguridad>();

            lstRoles = objSeg.getRolesUserByID(UsuarioId);

            return lstRoles;
        }

        public string GrupoDelUsuario(string UsuarioId)
        {
            return objSeg.getGrupoByUserID(UsuarioId);
        }

        public static bool AccesoPermitido(string UserId, string Pagina)
        {
            DLSeguridad dlSeg = new DLSeguridad();

            //Remover rutas
            Pagina = Pagina.Replace("forms_", "");
            Pagina = Pagina.Replace("administracion_", "");
            Pagina = Pagina.Replace("aplicaciones_", "");
            Pagina = Pagina.Replace("articulos_", "");
            Pagina = Pagina.Replace("catalogos_", "");
            Pagina = Pagina.Replace("controles_", "");
            Pagina = Pagina.Replace("docs_", "");
            Pagina = Pagina.Replace("general_", "");
            Pagina = Pagina.Replace("reportes_", "");
            Pagina = Pagina.Replace("software_", "");
            Pagina = Pagina.Replace("maximage_", "");
            Pagina = Pagina.Replace("servidores_", "");
            Pagina = Pagina.Replace("operacion_", "");

            return dlSeg.VerificaAccesoPaginaUsuario(UserId, Pagina);
        }

        public static System.Data.DataTable Top10PaginasUsuario(string UserId)
        {
            DLSeguridad dlSeg = new DLSeguridad();

            return dlSeg.Top10PaginasUsuario(UserId);
        }

        public string CrearUsuario(string Usuario, string Email, string Nombre)
        {
            DLSeguridad dlSeg = new DLSeguridad();

            return dlSeg.CrearUsuario(Usuario, Email, Nombre);
        }
    }
}
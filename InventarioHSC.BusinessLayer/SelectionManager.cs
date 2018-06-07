using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace InventarioHSC.BusinessLayer
{
    public class SelectionManager
    {
        public static void KeepSelection(GridView grid)
        {
            //
            // se obtienen los id checkeados de la pagina actual
            //
            List<int> checkedProd = (from item in grid.Rows.Cast<GridViewRow>()
                                     let check = (CheckBox)item.FindControl("chkSelecciona")
                                     where check.Checked
                                     select Convert.ToInt32(grid.DataKeys[item.RowIndex].Value)).ToList();

            //
            // se recupera de session la lista de seleccionados previamente
            //
            List<int> idSelected = HttpContext.Current.Session["idSelectedSess"] as List<int>;

            if (idSelected == null)
                idSelected = new List<int>();

            //
            // se cruzan todos los registros de la pagina actual del gridview con la lista de seleccionados,
            // si algun item de esa pagina fue marcado previamente no se devuelve
            //
            idSelected = (from item in idSelected
                          join item2 in grid.Rows.Cast<GridViewRow>()
                             on item equals Convert.ToInt32(grid.DataKeys[item2.RowIndex].Value) into g
                          where !g.Any()
                          select item).ToList();

            //
            // se agregan los seleccionados
            //
            idSelected.AddRange(checkedProd);

            HttpContext.Current.Session["idSelectedSess"] = idSelected;
        }

        public static void RestoreSelection(GridView grid)
        {
            List<int> idSelected = HttpContext.Current.Session["idSelectedSess"] as List<int>;

            if (idSelected == null)
                return;

            //
            // se comparan los registros de la pagina del grid con los recuperados de la Session
            // los coincidentes se devuelven para ser seleccionados
            //
            List<GridViewRow> result = (from item in grid.Rows.Cast<GridViewRow>()
                                        join item2 in idSelected
                                        on Convert.ToInt32(grid.DataKeys[item.RowIndex].Value) equals item2 into g
                                        where g.Any()
                                        select item).ToList();

            //
            // se recorre cada item para marcarlo
            //
            result.ForEach(x => ((CheckBox)x.FindControl("chkSelecciona")).Checked = true);
        }
    }
}
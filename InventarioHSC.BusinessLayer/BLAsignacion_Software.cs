using System;
using System.Collections.Generic;
using InventarioHSC.DataLayer;
using InventarioHSC.Model;

namespace InventarioHSC.BusinessLayer
{
    public class BLAsignacion_Software
    {
        private int cve_AsignacionSoftware;

        public int Cve_AsignacionSoftware
        {
            get { return cve_AsignacionSoftware; }
        }

        private Asignacion_Software objectAsignacionSoftware = new Asignacion_Software();
        public DLAsignacion_Software DataLayerAsignacionSoftware = new DLAsignacion_Software();

        public BLAsignacion_Software()
        { }

        public BLAsignacion_Software(Asignacion_Software asignacionSoftware)
        {
            objectAsignacionSoftware = asignacionSoftware;
        }

        public List<Asignacion_Software> ObtieneAsignacionSoftware(int cve_Software)
        {
            List<Asignacion_Software> asignacionSoftware;
            asignacionSoftware =
                DataLayerAsignacionSoftware.getAsignacionSoftwarePorCve_Software(cve_Software);

            return asignacionSoftware;
        }

        public List<string> ObtenAreaAsignada()
        {
            return DataLayerAsignacionSoftware.ObtenAreaAsignar();
        }

        public Asignacion_Software ObtenAsignacionSoftware()
        {
            return DataLayerAsignacionSoftware.getAsignacionSofware(objectAsignacionSoftware.Cve_Asignacion);
        }

        public string insertaAsignacionSoftwareNuevo()
        {
            string Resultado = "OK";
            string SalidaMensaje = string.Empty;

            if (Resultado == "OK")
            {
                try
                {
                    DataLayerAsignacionSoftware.InsertaAsignacion_software(ref objectAsignacionSoftware);
                    cve_AsignacionSoftware = objectAsignacionSoftware.Cve_Asignacion;
                    SalidaMensaje = "La asignacion de software fue agregado correctamente";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                SalidaMensaje = Resultado;
            }

            return SalidaMensaje;
        }

        public string ActualiaAsignacionSoftware()
        {
            string SalidaMensaje = string.Empty;

            try
            {
                DataLayerAsignacionSoftware.ActualizaAsignacion_software(objectAsignacionSoftware);
                SalidaMensaje = "La Asignacion de software fue actualizado correctamente";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return SalidaMensaje;
        }

        public List<Asignacion_Software> UsuariosConAsignacionSoftware()
        {
            DLAsignacion_Software dlAsignacionSofgtware = new DLAsignacion_Software();
            return dlAsignacionSofgtware.UsuariosConAsignacionSoftware();
        }

        public List<DetalleAsignacionSoftware> DetalleAsignacionSoftware(string nombreUsuario)
        {
            DLAsignacion_Software dlAsignacionSofgtware = new DLAsignacion_Software();
            return dlAsignacionSofgtware.getDetalleAsignacionSoftware(nombreUsuario);
        }
    }
}
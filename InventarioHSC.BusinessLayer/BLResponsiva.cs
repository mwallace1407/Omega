using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventarioHSC.Model;
using InventarioHSC.DataLayer;

namespace InventarioHSC.BusinessLayer
{
    public class BLResponsiva
    {
        private DLResponsiva objectResposiva = new DLResponsiva();
        private DLParametro objectParametro = new DLParametro();

        public BLResponsiva()
        {

        }

        public List<Responsiva> ObtieneDatosResponsiva(string sResponsive)
        {
            List<Responsiva> lstoResponsive = objectResposiva.GetDatosResponsiva(sResponsive);

            return lstoResponsive;
        }

        public List<Parametro> ObtieneResponsivaValoresFijos()
        {
            return objectParametro.getParaemetrobyDescripcionLike("Responsiva");
        }

        public List<Parametro> ObtieneResponsivaValorEncabezado()
        {
            List<Parametro> lstParametro = new List<Parametro>();
            Parametro oParametro = objectParametro.getParaemetrobyDescripcion("Responsiva Encabezado");
            lstParametro.Add(oParametro);
            return lstParametro;
        }
        public List<Parametro> ObtieneResponsivaValorClausula1()
        {
            List<Parametro> lstParametro = new List<Parametro>();
            Parametro oParametro = objectParametro.getParaemetrobyDescripcion("Responsiva Clausula 1");
            lstParametro.Add(oParametro);
            return lstParametro;
        }

        public List<Parametro> ObtieneResponsivaValorClausula2()
        {
            List<Parametro> lstParametro = new List<Parametro>();
            Parametro oParametro = objectParametro.getParaemetrobyDescripcion("Responsiva Clausula 2");
            lstParametro.Add(oParametro);
            return lstParametro;
        }

        public List<Parametro> ObtieneResponsivaValorClausula3()
        {
            List<Parametro> lstParametro = new List<Parametro>();
            Parametro oParametro = objectParametro.getParaemetrobyDescripcion("Responsiva Clausula 3");
            lstParametro.Add(oParametro);
            return lstParametro;
        }

        public List<Parametro> ObtieneResponsivaValorClausula4()
        {
            List<Parametro> lstParametro = new List<Parametro>();
            Parametro oParametro = objectParametro.getParaemetrobyDescripcion("Responsiva Clausula 4");
            lstParametro.Add(oParametro);
            return lstParametro;
        }

        public List<Parametro> ObtieneResponsivaValorFirma()
        {
            List<Parametro> lstParametro = new List<Parametro>();
            Parametro oParametro = objectParametro.getParaemetrobyDescripcion("Responsiva Autoriza");
            lstParametro.Add(oParametro);
            return lstParametro;
        }

        public string GeneraNoResponsiva()
        {
            BLArticulo blArtTicuo = new BLArticulo();

            return blArtTicuo.NuevaGeneracionResponsiva();
        }
    }
}

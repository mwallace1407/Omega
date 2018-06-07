namespace InventarioHSC.BusinessLayer
{
    public class TextWriter
    {
        static public string MakeHome()
        {
            return "<li><a href= \"#\" class=\"parent\"><span>Inicio</span></a>";
        }

        static public string MakeHomeNew(string NivelRuta)
        {
            return "<li class=\"topmenu\"><a href=\"" + NivelRuta + "../Forms/Home.aspx\" style=\"height:16px;line-height:16px;\">Inicio</a>" + "<ul><li class=\"\"><a href=\"" + NivelRuta + "../Forms/Reportes/DocumentosUsuario.aspx\">Mis Documentos</a></li></ul>";
        }

        static public string MakeLogout()
        {
            return "<li><a href= \"#\" class=\"parent\"><span>Log Out</span></a>";
        }

        static public string MakeOpenUlWithClass(string strClassName)
        {
            return "<ul class=\"" + strClassName + "\">";
        }

        static public string MakeOpenUlWithClassAndId(string strClassName, string strId)
        {
            return "<ul id=\"" + strId + "\" class=\"" + strClassName + "\">";
        }

        static public string MakeOpenULNoClass()
        {
            return "<ul>";
        }

        static public string MakeULCloseTag()
        {
            return "</ul>";
        }

        static public string MakeOpenDiv()
        {
            return "<div>";
        }

        static public string MakeOpenDivid(string id)
        {
            return "<div id=" + "\"" + id + "\">";
        }

        static public string MakeCloseDiv()
        {
            return "</div>";
        }

        static public string MakeCloseli()
        {
            return "</li>";
        }

        //          <li><a href="#" class="parent"><span>Sub Item 1</span></a>
        //          <li><a href="#"><span>Sub Item 1.1.1</span></a></li>

        static public string MakeMenuOption(string strNombreOpcion, string strCss, string strRuta)
        {
            string sOutput = string.Empty;

            sOutput = "<li><a href=" + "\"" + strRuta + "\"";

            if (strCss != null)
            {
                sOutput += " class=" + "\"" + strCss + "\"";
            }

            sOutput += " >";
            sOutput += "<span>" + strNombreOpcion + "</span></a>";

            return sOutput;
        }

        static public string MakeParagraph(string s)
        {
            return "<p>" + s + "</p>";
        }

        static public string MakeLine(string s)
        {
            return s + "<br />";
        }

        static public string Span(string strClass, string strText)
        {
            return "<span class=\"" + strClass + "\">" + strText + "</span>";
        }

        static public string Div(string strClass, string strText)
        {
            return "<div class=\"" + strClass + "\">" + strText + "</div>";
        }

        static public string MakeH1Text(string s)
        {
            return "<h1>" + s + "</h1>";
        }

        static public string MakeH2Text(string s)
        {
            return "<h2>" + s + "</h2>";
        }

        static public string MakeH3Text(string s)
        {
            return "<h3>" + s + "</h3>";
        }

        static public string MakeH4Text(string s)
        {
            return "<h4>" + s + "</h4>";
        }

        static public string MakeH5Text(string s)
        {
            return "<h5>" + s + "</h5>";
        }

        static public string MakeH6Text(string s)
        {
            return "<h6>" + s + "</h6>";
        }

        static public string MakeItalicText(string s)
        {
            return "<i>" + s + "</i>";
        }

        static public string MakeBoldText(string s)
        {
            return "<b>" + s + "</b>";
        }
    } // end of class declaration
}
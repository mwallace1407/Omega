using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;

namespace InventarioHSC
{
    public partial class Monitor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dt;
            CultureInfo culture = CultureInfo.GetCultureInfoByIetfLanguageTag("es-MX");
            DateTimeStyles styles = DateTimeStyles.None;
            DateTime.TryParse(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), culture, styles, out dt);

            lblFecha.Text = dt.ToLongDateString() + " a las " + dt.ToLongTimeString();
            lblSrv.Text = Environment.MachineName;
            GenerarGraficoRAM();
            GenerarGraficoProcesador();
            GenerarGraficoDiscoPrincipal();
            GenerarGraficoActividadDisco();
        }

        protected void GenerarGraficoRAM()
        {
            PerformanceCounter objMemperf = new PerformanceCounter("Memory", "Available Bytes");
            PerformanceCounter objMemTot = new PerformanceCounter("Memory", "Committed Bytes");

            double RAMDisponible = Convert.ToDouble((objMemperf.NextValue() / 1024) / 1024) / 1024;
            double RAMUtilizada = Convert.ToDouble(((objMemTot.RawValue / 1024) / 1024) / 1024);
            double RAMTotal = RAMDisponible + RAMUtilizada;

            double PorcentajeRAMUtilizada = Math.Round((RAMUtilizada * 100) / RAMTotal, 2);
            double PorcentajeRAMLibre = 100 - PorcentajeRAMUtilizada;

            lblRAM.Text = "(Aprox. " + Math.Round(RAMTotal, 0, MidpointRounding.AwayFromZero) + " GB)";

            double[] yValues = { PorcentajeRAMUtilizada, PorcentajeRAMLibre };
            string[] xValues = { "Utilizado: " + PorcentajeRAMUtilizada.ToString() + "%", "Disponible: " + PorcentajeRAMLibre.ToString() + "%" };

            chartRAM.Series["Default"].Points.DataBindXY(xValues, yValues);

            chartRAM.Series["Default"].Points[0].Color = Color.DarkGoldenrod;
            chartRAM.Series["Default"].Points[1].Color = Color.PaleGoldenrod;

            chartRAM.Series["Default"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;

            chartRAM.Series["Default"]["PieLabelStyle"] = "Disabled";

            chartRAM.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            chartRAM.Legends[0].Enabled = true;
        }

        protected void GenerarGraficoProcesador()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            CounterSample cs1 = cpuCounter.NextSample();
            System.Threading.Thread.Sleep(100);
            CounterSample cs2 = cpuCounter.NextSample();
            double PorcentajeUtilizado = Math.Round(CounterSample.Calculate(cs1, cs2), 2);
            double PorcentajeLibre = 100 - PorcentajeUtilizado;

            double[] yValues = { PorcentajeUtilizado, PorcentajeLibre };
            string[] xValues = { "Utilizado: " + PorcentajeUtilizado.ToString() + "%", "Disponible: " + PorcentajeLibre.ToString() + "%" };

            chartProc.Series["Default"].Points.DataBindXY(xValues, yValues);

            chartProc.Series["Default"].Points[0].Color = Color.DarkGoldenrod;
            chartProc.Series["Default"].Points[1].Color = Color.PaleGoldenrod;

            chartProc.Series["Default"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;

            chartProc.Series["Default"]["PieLabelStyle"] = "Disabled";

            chartProc.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            chartProc.Legends[0].Enabled = true;
        }

        protected void GenerarGraficoActividadDisco()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
            CounterSample cs1 = cpuCounter.NextSample();
            System.Threading.Thread.Sleep(100);
            CounterSample cs2 = cpuCounter.NextSample();
            double PorcentajeUtilizado = Math.Round(CounterSample.Calculate(cs1, cs2), 2);
            double PorcentajeLibre = 100 - PorcentajeUtilizado;

            double[] yValues = { PorcentajeUtilizado, PorcentajeLibre };
            string[] xValues = { "Utilizado: " + PorcentajeUtilizado.ToString() + "%", "Disponible: " + PorcentajeLibre.ToString() + "%" };

            chartDiscoAc.Series["Default"].Points.DataBindXY(xValues, yValues);

            chartDiscoAc.Series["Default"].Points[0].Color = Color.DarkGoldenrod;
            chartDiscoAc.Series["Default"].Points[1].Color = Color.PaleGoldenrod;

            chartDiscoAc.Series["Default"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;

            chartDiscoAc.Series["Default"]["PieLabelStyle"] = "Disabled";

            chartDiscoAc.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            chartDiscoAc.Legends[0].Enabled = false;
        }

        protected void GenerarGraficoDiscoPrincipal()
        {
            double EspacioLibre = 0;
            double EspacioUtilizado = 0;

            try
            {
                string Unidad = Server.MapPath("").Substring(0, 2);
                System.IO.DriveInfo driveInfo = new System.IO.DriveInfo(Unidad);

                EspacioLibre = driveInfo.AvailableFreeSpace;
                EspacioUtilizado = Math.Round(((Convert.ToDouble(driveInfo.TotalSize - EspacioLibre) / 1024) / 1024) / 1024, 2);
                EspacioLibre = Math.Round(((EspacioLibre / 1024) / 1024) / 1024, 2);
            }
            catch (System.IO.IOException errorMesage)
            {
                Console.WriteLine(errorMesage);
            }

            if (EspacioLibre > 0)
            {
                string Libre = "";
                string Utilizado = "";

                if (EspacioLibre < 1024)
                    Libre = "Disponible: " + EspacioLibre.ToString() + " GB";
                else
                    Libre = "Disponible: " + Math.Round(EspacioLibre / 1024, 2).ToString() + " TB";

                if (EspacioUtilizado < 1024)
                    Utilizado = "Utilizado: " + EspacioUtilizado.ToString() + " GB";
                else
                    Utilizado = "Utilizado: " + Math.Round(EspacioUtilizado / 1024, 2).ToString() + " TB";

                double[] yValues = { EspacioUtilizado, EspacioLibre };
                string[] xValues = { Utilizado, Libre };

                chartDiscoP.Series["Default"].Points.DataBindXY(xValues, yValues);

                chartDiscoP.Series["Default"].Points[0].Color = Color.DarkGoldenrod;
                chartDiscoP.Series["Default"].Points[1].Color = Color.PaleGoldenrod;

                chartDiscoP.Series["Default"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;

                chartDiscoP.Series["Default"]["PieLabelStyle"] = "Disabled";

                chartDiscoP.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

                chartDiscoP.Legends[0].Enabled = true;
            }
            else
            {
                chartDiscoP.Visible = false;
            }
        }
    }
}
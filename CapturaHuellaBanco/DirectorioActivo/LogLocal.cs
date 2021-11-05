using System;
using System.Configuration;
using System.IO;

namespace Utilidades
{
    public class LogLocal
    {
        private static string sFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogORS.txt");
        public static void GuardarLog(string mensaje)
        {
            //Log en disco
            try
            {
                int th;
                if (int.TryParse(ConfigurationManager.AppSettings["DebugCaptor"], out th))
                {
                    if (th == 0)
                        return;
                }
                else
                    return;


                System.Diagnostics.Trace.WriteLine("ORS1: " + mensaje);
                //string sFile = string.Format(@"{0}\LogORS.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                StreamWriter writer = new StreamWriter(sFile, true);
                string sLineaDetalle = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " " + mensaje;
                writer.WriteLine(sLineaDetalle);
                writer.Close();
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Trace.WriteLine("ORS2: " + Ex.ToString());
            }
        }
    }
}
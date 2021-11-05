using System;
using System.IO;

namespace SignalRHubs
{
    public static class CustomHubLogger
    {
        private static string sFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogSignalR.txt");
        public static void LogException(string message)
        {
            //string sFile = string.Format(@"{0}\LogSignalR.txt",
            //    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            StreamWriter writer = new StreamWriter(sFile, true);
            string sLineaDetalle =string.Format(@"[ERROR] {0} {1}",
                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), message);
            writer.WriteLine(sLineaDetalle);
            writer.Close();
        }
        public static void LogInformation(string message)
        {
            //string sFile = string.Format(@"{0}\LogSignalR.txt",
            //    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            StreamWriter writer = new StreamWriter(sFile, true);
            string sLineaDetalle = string.Format(@"[INFO] {0} {1}",
                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), message);
            writer.WriteLine(sLineaDetalle);
            writer.Close();
        }
    }
}

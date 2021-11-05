using System;
using System.Diagnostics;
using System.ServiceProcess;
using Serilog;

namespace ReconoserWinService
{
    static class Program
    {

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main(string[] args)
        {
            Configurar();
            if (Environment.UserInteractive)
            {
                ReconoserService service1 = new ReconoserService();
                service1.TestStartupAndStop(args);
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new ReconoserService()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }

        static void Configurar()
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.AppSettings().CreateLogger();
            Serilog.Debugging.SelfLog.Enable(msg => Trace.WriteLine(msg));
        }

        //private static void RegistrarDll()
        //{
        //    try
        //    {
        //        Process p = new Process();
        //        p.StartInfo.FileName = "regsvr32.exe";
        //        p.StartInfo.Arguments = "wgssSTU.dll";
        //        p.Start();
        //        p.WaitForExit();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("No se pudo registrar" + ex.Message);
        //    }
        //}
    }
}

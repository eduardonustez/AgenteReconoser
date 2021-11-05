using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;

namespace WCFServicioReconoser
{
    public static class WacomDevice
    {
        public static void EscribirEnLog(string log, EventLogEntryType eventLogEntryType = EventLogEntryType.Information)
        {
            EventLog eventLog1 = new EventLog();
            if (!EventLog.SourceExists("ReconoSerServiceSource"))
            {
                EventLog.CreateEventSource("ReconoSerServiceSource", "ReconoSerServiceLog");
            }
            eventLog1.Source = "ReconoSerServiceSource";
            eventLog1.Log = "ReconoSerServiceLog";
            eventLog1.WriteEntry(log, eventLogEntryType);
        }

        public static void ComprobarServiciosWacom()
        {
            string route = ConfigurationManager.AppSettings["WacomInstallationRoute"];
            string serviceName = ConfigurationManager.AppSettings["WacomServiceName"]; 
            string processName = route.Split('\\').Last().Split('.').First();
            ServiceController sc = new ServiceController(serviceName);
            Process[] processFound = Process.GetProcessesByName(processName);
            if (sc.Status == ServiceControllerStatus.Running && processFound.Length != 0)
            {
                EscribirEnLog($"{serviceName} service and {processName} process are running ...");
            }
            else
            {
                if (sc.Status != ServiceControllerStatus.Running)
                {
                    sc.Start();
                    EscribirEnLog($"{serviceName} service is started");
                }
                else
                {
                    EscribirEnLog($"{serviceName} service is already running");
                }
                foreach (Process aProcess in processFound)
                {
                    aProcess.Kill();
                    EscribirEnLog($"{aProcess.ProcessName} is killed");
                }

                EscribirEnLog("(Re)starting process...");
                Process.Start(route);
                Process[] processList = Process.GetProcessesByName(processName);
                EscribirEnLog(processList.Length > 0 ? "Process started" : "Process cannot start");
            }
        }
    }
}
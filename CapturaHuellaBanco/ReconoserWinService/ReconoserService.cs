using Microsoft.Owin.Hosting;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceProcess;
using System.Timers;
using WCFServicioReconoser;
using wyDay.Controls;

namespace ReconoserWinService
{
    public partial class ReconoserService : ServiceBase
    {
        private ServiceHost oServiceHost = null;

        static AutomaticUpdaterBackend auBackend;
        private readonly EventLog eventLog1;
        private int eventId = 1;
        private IDisposable siteHost;

        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            //this.OnStop();
        }

        protected override void OnStart(string[] args)
        {
            LevantarHost();
            try
            {
                siteHost = WebApp.Start<Startup>("http://localhost:8899");
            }
            catch (Exception ex)
            {
                EscribirEnLog($"Error al lanzar host signalR: {ex.ToString()}", EventLogEntryType.Warning);
            }

            auBackend = new AutomaticUpdaterBackend
            {
                GUID = "reconoser-servicio-agente",
                UpdateType = UpdateType.Automatic,
                ServiceName = this.ServiceName
            };
            auBackend.wyUpdateCommandline = $"-urlargs:\"{ObtenerPKeyForUpdates()}\"";
            auBackend.ReadyToBeInstalled += AuBackend_ReadyToBeInstalled;
            auBackend.UpdateSuccessful += AuBackend_UpdateSuccessful;

            auBackend.CheckingFailed += AuBackend_CheckingFailed;
            auBackend.DownloadingFailed += AuBackend_DownloadingFailed;
            auBackend.ExtractingFailed += AuBackend_ExtractingFailed;
            auBackend.UpdateFailed += AuBackend_UpdateFailed;

            // Initialize() and AppLoaded() must be called after events have been set.
            // Note: If there's a pending update to be installed, wyUpdate will be
            //       started, then it will talk back and say "ready to install,
            //       you can close now" at which point your app will be closed.
            auBackend.Initialize();
            auBackend.AppLoaded();

//#if !DEBUG
            // Set up a timer that triggers every minute.
            Timer timer = new Timer();
            timer.Interval = ObtenerTiempoActualizaciones(); // 60 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
//#endif
            //Note: Also, since this will be a service you should call
            //      CheckEvery10Days() from an another thread (rather
            //      than just at startup)            
        }

        private string ObtenerPKeyForUpdates()
        {
            try
            {
                var po = RestWCFReconososer.ObtenerParametrosArchivo();

                return $"{RestWCFReconososer.IdCliente}|{po.Oficina.Codigo}"; 
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"DFZ OPU Err: {ex}");
                return "*";
            }
        }

        private void AuBackend_UpdateFailed(object sender, FailArgs e)
        {
            EscribirEnLog($"Error al actualizar: {e.ErrorMessage}", EventLogEntryType.Warning);
        }

        private void AuBackend_ExtractingFailed(object sender, FailArgs e)
        {
            EscribirEnLog($"Error al extraer actualizaciones: {e.ErrorMessage}", EventLogEntryType.Warning);
        }

        private void AuBackend_DownloadingFailed(object sender, FailArgs e)
        {
            EscribirEnLog($"Error al descargar actualizaciones: {e.ErrorMessage}", EventLogEntryType.Warning);
        }

        private void AuBackend_CheckingFailed(object sender, FailArgs e)
        {
            EscribirEnLog($"Error al buscar actualizaciones: {e.ErrorMessage}", EventLogEntryType.Warning);
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            CheckTimeForUpdate();
        }

        private void AuBackend_UpdateSuccessful(object sender, SuccessArgs e)
        {
            EscribirEnLog("auBackend_UpdateSuccessful");
        }

        private void CheckTimeForUpdate()
        {
            //EscribirEnLog("Buscando Actualizaciones");
            auBackend.ForceCheckForUpdate(true);
        }

        private int ObtenerTiempoActualizaciones()
        {
            int tiempo = 60;
            if (int.TryParse(ConfigurationManager.AppSettings["SegundosActualizaciones"], out tiempo))
                return tiempo * 1000;
            else
                return 60000;
        }

        private void AuBackend_ReadyToBeInstalled(object sender, EventArgs e)
        {
            // ReadyToBeInstalled event is called when
            // either the UpdateStepOn == UpdateDownloaded or UpdateReadyToInstall

            if (auBackend.UpdateStepOn == UpdateStepOn.UpdateReadyToInstall)
            {
                EscribirEnLog("Updating app...");
                auBackend.InstallNow();
            }
            else
            {
                EscribirEnLog("Se han descargado la actualizaciones ...");
            }
        }

        public ReconoserService()
        {
            InitializeComponent();

            eventLog1 = new EventLog();
            if (!EventLog.SourceExists("ReconoSerServiceSource"))
            {
                EventLog.CreateEventSource("ReconoSerServiceSource", "ReconoSerServiceLog");
            }
            eventLog1.Source = "ReconoSerServiceSource";
            eventLog1.Log = "ReconoSerServiceLog";
        }

        protected override void OnStop()
        {
            try
            {
                if (oServiceHost != null)
                {
                    if (oServiceHost.State == CommunicationState.Opened)
                    {
                        oServiceHost.Close();
                        oServiceHost = null;
                    }
                }
                if(siteHost != null)
                {
                    siteHost.Dispose();
                    siteHost = null;
                }
            }
            catch (Exception Ex)
            {
                Trace.WriteLine("RSF99E: " + Ex.ToString());
                InsertarLogError(Ex, "Deteniendo Servicio");
            }
        }

        protected string Estado
        {
            get;
            private set;
        }

        private string sFileProcess = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogProcess.log");
        private void EscribirEnLog(string mensaje, EventLogEntryType type = EventLogEntryType.Information)
        {

            eventLog1.WriteEntry($"{DateTime.Now}: {mensaje}", EventLogEntryType.Information, eventId++);
            using (var writer = new StreamWriter(sFileProcess, true))
            {
                writer.WriteLine(mensaje);
            }
        }

        string sFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogReconoser.log");
        private void InsertarLogError(Exception Ex, string metodo)
        {
            //Log en disco

            eventLog1.WriteEntry("Monitoring: " + Ex.Message, EventLogEntryType.Error, eventId++);

            using (var writer = new StreamWriter(sFile, true))
            {
                writer.WriteLine("ERROR NO REPORTADO:");
                writer.WriteLine("\t" + Ex.ToString());
                writer.WriteLine("\tFecha:\t" + DateTime.Now.ToString());
                writer.WriteLine("\tCapa:\t" + "Formulario Local");
                writer.WriteLine("\tMetodo:\t" + metodo);
                writer.WriteLine("\tDescripcion:\t" + Ex.Message);
            }
        }

        private void LevantarHost()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (oServiceHost != null && oServiceHost.State == CommunicationState.Opened)
            {
                Trace.WriteLine("RSF10E1: ");
                EscribirEnLog("Host ya se encontraba levantado");
                return;
            }

            try
            {
                oServiceHost = new ServiceHost(typeof(WCFServicioReconoser.RestWCFReconososer));
                oServiceHost.Open();

                Trace.WriteLine($"RSF10E1: host Levantado {oServiceHost.State} : {oServiceHost.BaseAddresses[0]}");
                Trace.WriteLine($"RSF10E2: {AppDomain.CurrentDomain.BaseDirectory}");
                EscribirEnLog("Host levantado correctamente");
                Estado = "Listo";
            }
            catch (AddressAccessDeniedException Ex0)
            {
                Trace.WriteLine("RSF10E1: " + Ex0.ToString());
                InsertarLogError(Ex0, "LevantarHost");
                Estado = "Error Permisos";
            }
            catch (AddressAlreadyInUseException Ex1)
            {
                Trace.WriteLine("RSF10E2: " + Ex1.ToString());
                InsertarLogError(Ex1, "LevantarHost");
                Estado = "Error - Puerto en uso";
            }
            catch (Exception Ex)
            {
                Trace.WriteLine("RSF10E3: " + Ex.ToString());
                InsertarLogError(Ex, "LevantarHost");
                Estado = "Error Desconocido";
            }
        }
    }
}

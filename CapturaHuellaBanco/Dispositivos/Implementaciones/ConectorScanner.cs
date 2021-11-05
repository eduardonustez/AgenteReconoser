using Dispositivos.Scanner.Helpers;
using Dispositivos.Scanner.Models;
using NTwain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dispositivos.Implementaciones
{
    public class ConectorScanner
    {
        static TwainSession _twain;

        public static List<string> ObtenerDispositivosWIA(Action<string> action)
        {
            List<string> dispositivos = new List<string>();
            foreach(var dispositivoEncontrado in WIAScanner.GetDevices())
            {
                dispositivos.Add(dispositivoEncontrado.Name);
            }
            return dispositivos;
        }

        public static DatosPersonaDocumento ScanWIA(OpcionesScanner opcionesScanner, Action<string> action)
        {
            InformacionBarcode.TipoDocumentoSeleccionado = (int)TiposDocumento.Cedula;
            List<WIADeviceInfo> devices = WIAScanner.GetDevices().ToList();
            if (devices.Count > 0)
            {
                WIADeviceInfo device = WIAScanner.GetDevices().Where(x => x.Name == opcionesScanner.NombreDispositivo).First();
                var pages_to_scan = 1;
                var test = WIAScanner.Scan(device.DeviceID, pages_to_scan, WIAScanQuality.Preview, WIAPageSize.Epson510, opcionesScanner.Dpi).First();
                return InformacionBarcode.ObtenerInformacionBarcode(test, action);
            }
            else
            {
                throw new ScannerIntegrationException("Compruebe que el escáner esté encendido y conectado al equipo");
            }
        }

        public static List<string> ObtenerDispositivosTwain(Action<string> action)
        {
            _twain = TwainScanner.InitTwain(action);
            List<string> scanner = TwainScanner.ObtenerScanners(ref _twain);
            TwainScanner.CleanupTwain(_twain);
            return scanner;
        }

        public static DatosPersonaDocumento ScanTwain(OpcionesScanner opcionesScanner, Action<string> action)
        {
            try
            {
                InformacionBarcode.TipoDocumentoSeleccionado = (int)TiposDocumento.Cedula;
                _twain = TwainScanner.InitTwain(action);
                TwainScanner.ObtenerArquitectura();
                TwainScanner.EscanearDesdeDispositivo(_twain, opcionesScanner);
                int count = 0;

                do
                {
                    Thread.Sleep(1000);
                    count++;
                } while (_twain.State != (int)State.DsmLoaded && count < 60);

                TwainScanner.CleanupTwain(_twain);
                return TwainScanner.DatosPersonaDocumento;
            }
            catch (Exception ex)
            {
                throw new ScannerIntegrationException(ex.Message);
            }

        }
    }
}

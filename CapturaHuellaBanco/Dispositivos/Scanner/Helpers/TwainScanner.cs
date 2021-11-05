using Dispositivos.Scanner.Helpers;
using Dispositivos.Scanner.Models;
using NTwain;
using NTwain.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Dispositivos.Implementaciones
{
    public static class TwainScanner
    {

        public static DatosPersonaDocumento DatosPersonaDocumento { get; set; }

        public static TwainSession InitTwain(Action<string> action)
        {
            var appId = TWIdentity.CreateFromAssembly(DataGroups.Image, Assembly.GetExecutingAssembly());
            var twain = new TwainSession(appId);

            twain.DataTransferred += (s, e) => ObtenerImagen(e, action);

            twain.SourceDisabled += (s, e) =>
            {
                var rc = twain.CurrentSource.Close();
                rc = twain.Close();
            };

            return twain;
        }

        private static void ObtenerImagen(DataTransferredEventArgs e, Action<string> action)
        {
            var infos = e.GetExtImageInfo(ExtendedImageInfo.Camera).Where(it => it.ReturnCode == ReturnCode.Success);
            foreach (var it in infos)
            {
                var values = it.ReadValues();
                PlatformInfo.Current.Log.Info(string.Format("{0} = {1}", it.InfoID, values.FirstOrDefault()));
                break;
            }

            Image img = null;
            if (e.NativeData != IntPtr.Zero)
            {
                var stream = e.GetNativeImageStream();
                if (stream != null)
                {
                    img = Image.FromStream(stream);
                }
            }
            else if (!string.IsNullOrEmpty(e.FileDataPath))
            {
                img = new Bitmap(e.FileDataPath);
            }
            if (img != null)
            {
                DatosPersonaDocumento = InformacionBarcode.ObtenerInformacionBarcode(img, action);
            }
            else
            {
                action.Invoke("No se procesó ninguna imagen");
            }
        }

        public static void CleanupTwain(TwainSession _twain)
        {
            if (_twain.State == (int)State.SourceOpened)
            {
                _twain.CurrentSource.Close();
            }
            if (_twain.State == (int)State.DsmOpened)
            {
                _twain.Close();
            }

            if (_twain.State > (int)State.DsmLoaded)
            {
                // normal close down didn't work, do hard kill
                _twain.ForceStepDown((int)State.DsmLoaded);
            }
        }

        public static void EscanearDesdeDispositivo(TwainSession _twain, OpcionesScanner opcionesScanner)
        {
            DatosPersonaDocumento = null;
            Thread.Sleep(1000);

            var rc = _twain.Open();

            if (rc == ReturnCode.Success)
            {
                var deviceSource = opcionesScanner.NombreDispositivo;
                var hit = _twain.FirstOrDefault(s => string.Equals(s.Name, deviceSource));
                if (hit == null)
                {
                    _twain.Close();
                    throw new ScannerIntegrationException("El dispositivo \"" + deviceSource + "\" no está instalado");
                }
                else
                {
                    rc = hit.Open();

                    if (!hit.IsOpen)
                    {
                        throw new ScannerIntegrationException("El escáner no se encuentra encendido o está siendo utilizado por otro programa. Cierre el programa y vuelva a intentarlo.");
                    }

                    if (rc == ReturnCode.Success)
                    {
                        ConfigurarParametrosDeScanner(_twain, opcionesScanner);
                        rc = hit.Enable(SourceEnableMode.NoUI, false, IntPtr.Zero);
                    }
                    else
                    {
                        _twain.Close();
                        throw new ScannerIntegrationException(ReturnCodeDescriptor.ReturnCodeDescriptorList.Where(x => x.Key == rc).FirstOrDefault().Value);
                    }
                }
            }
            else
            {
                throw new ScannerIntegrationException(ReturnCodeDescriptor.ReturnCodeDescriptorList.Where(x => x.Key == rc).FirstOrDefault().Value);
            }
        }

        private static void ConfigurarParametrosDeScanner(TwainSession _twain, OpcionesScanner opcionesScanner)
        {
            var dpi = opcionesScanner.Dpi;
            _twain.CurrentSource.Capabilities.ICapXResolution.SetValue(dpi);
            _twain.CurrentSource.Capabilities.ICapYResolution.SetValue(dpi);
            _twain.CurrentSource.Capabilities.ICapPixelType.SetValue(PixelType.Gray);
            _twain.CurrentSource.Capabilities.CapDuplexEnabled.SetValue(BoolType.False);
            _twain.CurrentSource.Capabilities.ICapAutomaticDeskew.SetValue(BoolType.True);
            _twain.CurrentSource.Capabilities.ICapAutoSize.SetValue(AutoSize.None);
            _twain.CurrentSource.Capabilities.ICapAutomaticBorderDetection.SetValue(BoolType.False);
            _twain.CurrentSource.Capabilities.ICapOverScan.SetValue(OverScan.None);
            _twain.CurrentSource.Capabilities.ICapUndefinedImageSize.SetValue(BoolType.False);
            TWFrame tWFrame = new TWFrame
            {
                Left = 0,
                Top = 0,
                Right = 3.370071F,
                Bottom = 2.125977F
            };
            _twain.CurrentSource.Capabilities.ICapFrames.SetValue(tWFrame);
            //_twain.CurrentSource.Capabilities.CapDoubleFeedDetection.SetValue(new TWArray()
            //{
            //    ItemList = new object[0]
            //});
        }

        public static List<string> ObtenerScanners(ref TwainSession _twain)
        {
            List<string> scanners = new List<string>();
            _twain.Open();
            if (_twain.State >= 3)
            {
                foreach (var item in _twain)
                {
                    scanners.Add(item.Name);
                }
            }
            _twain.Close();
            return scanners;
        }



        public static string ObtenerArquitectura()
        {
            return PlatformInfo.Current.IsApp64Bit ? "[64bit]" : "[32bit]";
        }
    }
}

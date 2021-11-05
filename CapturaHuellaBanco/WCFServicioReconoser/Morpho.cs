using Dispositivos;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace WCFServicioReconoser
{
    internal class Morpho
    {
        public static bool CapturaCancelada = false;

        public int Calidad = 0;

        public Bitmap Imagen = null;

        public byte[] Template = null;

        //private IDispositivo ID;
        private static IDispositivo ID;

        private byte[] _CA;
        private string _DK;
        private byte[] _HC;
        private byte[] _HK;
        private string _Marca;
        private string _Modelo;
        private string _Serial;

        private int _Tipo;

        public Morpho(byte[] HC, byte[] HK, byte[] CA, string DK)
        {
            if (HC != null)
            {
                _HC = HC;
            }

            if (CA != null)
            {
                _CA = CA;
            }

            if (HK != null)
            {
                _HK = HK;
            }

            if (!string.IsNullOrEmpty(DK))
            {
                _DK = DK;
            }
        }

        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }

        public string Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        public string Serial
        {
            get { return _Serial; }
            set { _Serial = value; }
        }
        public int Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static byte[] ImageToPng(Image img)
        {
            byte[] result = null;
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Png);
                result = stream.ToArray();
            }

            return result;
        }

        public void CancelarCaptura()
        {
            System.Diagnostics.Trace.WriteLine("DFZCC1");
            if (ID != null)
            {
                System.Diagnostics.Trace.WriteLine("DFZCC10");
                CapturaCancelada = true;
                ID.CancelarCaptura();
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("DFZCC2 - NULLO");
            }
        }

        public string Capturar()
        {
            Template = null;
            Calidad = 0;

            System.Diagnostics.Trace.WriteLine("DFZ10");
            Utilidades.LogLocal.GuardarLog("DFZ10A");

            try
            {
                ID = Base.ObtenerDispositivo(Base.DeviceType.MorphoSinVentana, 0);

                if (_HC != null)
                {
                    Utilidades.LogLocal.GuardarLog("DFZ11A");
                    ID.HostCert = _HC;
                    ID.CaCert = _CA;
                    ID.HostKey = _HK;

                    try
                    {
                        ID.EstablecerLlave(_DK);
                        ID.CifrarHuella = true;
                    }
                    catch
                    {
                        ID.CifrarHuella = false;
                    }
                }
                else
                {
                    Utilidades.LogLocal.GuardarLog("DFZ11B NO TC");
                }

                if (ID == null)
                {
                    Utilidades.LogLocal.GuardarLog("DFZ12");
                }
            }
            catch (Exception Ex)
            {
                Utilidades.LogLocal.GuardarLog("MC1 " + Ex.ToString());
                return "";
            }

            System.Diagnostics.Trace.WriteLine("DFZ20");
            Utilidades.LogLocal.GuardarLog("DFZ20A");

            ID.HuellaViva = true;

            ID.Capturar();

            Template = ID.Template;
            Calidad = ID.Calidad;
            Imagen = ID.Imagen;
            _Serial = ID.Serial;
            _Marca = ID.Marca;
            _Modelo = ID.Nombre;
            _Tipo = ID.Tipo;

            if (ID.Imagen != null)
            {
                return Convert.ToBase64String(ImageToPng(ID.Imagen));
            }
            else
            {
                return "";
            }
        }

        public Bitmap CapturarBitmap()
        {
            Template = null;
            Calidad = 0;

            System.Diagnostics.Trace.WriteLine("DFZ10");
            try
            {
                ID = Base.ObtenerDispositivo(Base.DeviceType.MorphoSinVentana, 0);

                if (_HC != null)
                {
                    ID.HostCert = _HC;
                    ID.CaCert = _CA;
                    ID.HostKey = _HK;

                    try
                    {
                        ID.EstablecerLlave(_DK);
                        ID.CifrarHuella = true;
                    }
                    catch
                    {
                        ID.CifrarHuella = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                Utilidades.LogLocal.GuardarLog("MC2 " + Ex.ToString());
                return null;
            }

            System.Diagnostics.Trace.WriteLine("DFZ20");

            ID.HuellaViva = true;

            ID.Capturar();

            Template = ID.Template;
            Calidad = ID.Calidad;
            Serial = ID.Serial;

            return ID.Imagen;
        }
        private void GuardarArchivo(string texto)
        {
            try
            {
                string sFile = string.Format(@"{0}\LogTS.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                StreamWriter writer = new StreamWriter(sFile, true);
                string sLineaDetalle = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + texto;
                writer.WriteLine(sLineaDetalle);
                writer.Close();
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Trace.WriteLine("Error:" + texto + " | " + Ex.ToString());
            }
        }
    }
}
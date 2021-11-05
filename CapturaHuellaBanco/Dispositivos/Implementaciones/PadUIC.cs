using Olimpia.UIC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dispositivos.Implementaciones
{
    public class PadUIC : IDispositivo
    {
        private int _Calidad;

        private bool _HuellaViva = false;

        private Bitmap _Imagen;

        private string _Marca;

        private string _Nombre;

        private PictureBox _Pb;

        private int _Puerto;

        private string _Serial;

        private Byte[] _Template;

        private UICPinPad PinPad = null;

        public PadUIC()
        {
            _Pb = new PictureBox();
            _Pb.SizeMode = PictureBoxSizeMode.StretchImage;
            _Pb.Dock = DockStyle.Fill;
        }

        ~PadUIC()
        {
            if (PinPad.Status == PinPadStatus.Opened)
                PinPad.Close();
        }

        public event msgChanged OnmsgChanged;

        public event QChanged OnQChanged;
        public Byte[] CaCert
        {
            set { }
        }

        public int Calidad
        {
            get { return 100; }
            set { }
        }

        public bool CifrarHuella
        {
            get { return false; }
            set { }
        }

        public Byte[] HostCert
        {
            set { }
        }

        public Byte[] HostKey
        {
            set { }
        }

        public bool HuellaViva
        {
            get { return false; }
            set { }
        }

        public Bitmap Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public PictureBox Pb
        {
            get { return _Pb; }
        }

        public int PuertoCom
        {
            get { return _Puerto; }
            set { _Puerto = value; }
        }

        public string Serial
        {
            get { return _Serial; }
            set { _Serial = value; }
        }

        public Byte[] Template
        {
            get { return _Template; }
            set { _Template = value; }
        }

        public int Tipo
        {
            get { return 1; }
            set { }
        }
        public void CancelarCaptura()
        {
            throw new NotImplementedException();
        }

        public void Capturar()
        {
            try
            {
                guardararchivo("DFZ10");

                if (PinPad.Status != PinPadStatus.Opened)
                    PinPad.Open();

                guardararchivo("DFZ20");
                PinPad.onCaptureFinished = OnCaptureFinished;

                guardararchivo("DFZ30");
                PinPad.StartSigCapture().Wait();

                guardararchivo("DFZ40");
            }
            catch (Exception ex)
            {
                guardararchivo("DFZ10E: " + ex.ToString());

                _Pb.Image = null;
                _Imagen = null;
                _Template = null;
                throw new Exception(ex.Message);
            }
        }

        public bool DetectarDispositivo()
        {
            try
            {
                guardararchivo("DFZ2");
                PinPad = new UICPinPad();
                PinPad.ComPort = PuertoCom;

                guardararchivo("DFZ4");
                PinPad.Open();
                guardararchivo("DFZ6");
                _Nombre = "UIC PinPad";
                _Serial = "NA";
                if (PinPad.Status == PinPadStatus.Opened)
                {
                    guardararchivo("DFZ7");
                    return true;
                }
                guardararchivo("DFZ8");
                return false;
            }
            catch (Exception ex)
            {
                guardararchivo("DFZ2E: " + ex.ToString());
                return false;
            }
        }
        public void EstablecerLlave(string llave)
        {
            throw new ArgumentException("El dispositivo no soporta llave de cifrado");
        }

        private void guardararchivo(string text)
        {
            try
            {
                string sFile = string.Format(@"{0}\ErrorUIC.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                StreamWriter writer = new StreamWriter(sFile, true);
                string sLineaDetalle = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ms") + ": " + text;
                writer.WriteLine(sLineaDetalle);
                writer.Close();
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Trace.WriteLine("WCFBanco EIGA: " + Ex.ToString());
            }
        }

        private void OnCaptureFinished(Bitmap firma)
        {
            if (firma != null)
            {
                _Pb.Image = (Image)firma.Clone();
                _Imagen = (Bitmap)firma.Clone();
            }
            else
            {
                throw new Exception("No ha sido posible completar la captura.");
            }
            PinPad.Close();
        }
    }
}
using Morpho.MorphoAcquisition;
using Olimpia.MorphoSmart;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dispositivos.Implementaciones
{
    public class MorphoSmart : IDispositivo
    {
        private Byte[] _caCert;
        private int _Calidad;
        private bool _CifrarHuella;
        private MorphoSmartDevice _device;

        private Byte[] _hostCert;

        private Byte[] _hostKey;

        private bool _HuellaViva = true;

        private Bitmap _Imagen;

        private string _Marca;

        private string _Nombre;

        private PictureBox _Pb;

        private int _Puerto;

        private string _Serial;

        private Byte[] _Template;

        public MorphoSmart()
        {
            _Pb = new PictureBox();
            _Pb.SizeMode = PictureBoxSizeMode.StretchImage;
            _Pb.Dock = DockStyle.Fill;

            _device = new MorphoSmartDevice();
            MorphoSmartDevice.FingerEvent += new FingerEventHandler(device_FingerEvent);
            MorphoSmartDevice.EnrolmentEvent += device_EnrolmentEvent;
            MorphoSmartDevice.QualityEvent += new QualityEventHandler(_device_QualityEvent);
            MorphoSmartDevice.ImageEvent += new ImageEventHandler(device_ImageEvent);
        }

        public event msgChanged OnmsgChanged;

        public event QChanged OnQChanged;

        public Byte[] CaCert
        {
            private get { return _caCert; }
            set { _caCert = value; }
        }

        public int Calidad
        {
            get { return _Calidad; }
            set { _Calidad = value; }
        }

        public bool CifrarHuella
        {
            get { return _CifrarHuella; }
            set { _CifrarHuella = value; }
        }

        public Byte[] HostCert
        {
            private get { return _hostCert; }
            set { _hostCert = value; }
        }

        public Byte[] HostKey
        {
            private get { return _hostKey; }
            set { _hostKey = value; }
        }

        public bool HuellaViva
        {
            get { return _HuellaViva; }
            set { _HuellaViva = value; }
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
            if (_device != null)
            {
                _device.CancelAcquisition();
            }
        }

        public void Capturar()
        {
            Utilidades.LogLocal.GuardarLog("DFZ50A");
            if (DetectarDispositivo())
            {
                Utilidades.LogLocal.GuardarLog("DFZ60A");
                try
                {
                    Utilidades.LogLocal.GuardarLog("DFZ70A");
                    if (HuellaViva)
                    {
                        int th;
                        if (int.TryParse(System.Configuration.ConfigurationManager.AppSettings["Threeshold"], out th))
                            _device.SetLiveQualityThreshold(th);
                        else
                            _device.SetLiveQualityThreshold(70);
                        _device.SetExtendedSecurityLevel(ExtendedSecurityLevel.HIGH);
                        //_device.SetExtendedSecurityLevel(ExtendedSecurityLevel.CRITICAL);
                    }
                    else
                    {
                        _device.SetLiveQualityThreshold(50);
                        _device.SetExtendedSecurityLevel(ExtendedSecurityLevel.MEDIUM);
                    }

                    ushort to;
                    if (ushort.TryParse(System.Configuration.ConfigurationManager.AppSettings["CaptorTimeOut"], out to))
                    {
                        Utilidades.LogLocal.GuardarLog("DFZ70B");
                        _device.SetTimeout(to);
                    }
                    else
                    {
                        Utilidades.LogLocal.GuardarLog("DFZ70C SIN CTO");
                        _device.SetTimeout(30);
                    }
                    if (CifrarHuella)
                    {
                        _device.EnableEncription(null, true);
                    }
                    else
                    {
                        _device.EnableEncription(null, false);
                    }
                    // call the Acquire method
                    _device.SetTemplateFormat(TemplateFormat.ISO_19794_2_FMR);
                    Utilidades.LogLocal.GuardarLog("DFZ71A");
                    if (_hostCert != null)
                        _device.SetHostCertif(_hostCert);
                    if (_hostKey != null)
                        _device.SetHostKey(_hostKey);
                    if (_caCert != null)
                        _device.SetCACertif(_caCert);
                    var result = _device.Enroll();

                    Utilidades.LogLocal.GuardarLog("DFZ72A: " + result.Status.ToString());

                    ErrorCodes l_e_AcquisitionError = ErrorCodes.IED_ERR_UNKOWN;

                    if (Enum.IsDefined(typeof(ErrorCodes), result.Status))
                        l_e_AcquisitionError = (ErrorCodes)result.Status;
                    if ((int)result.Status == -26)
                        l_e_AcquisitionError = ErrorCodes.IED_ERR_CANCEL_ACQUISITION;

                    if (l_e_AcquisitionError == ErrorCodes.IED_NO_ERROR)
                    {
                        Utilidades.LogLocal.GuardarLog("DFZ80A");
                        // update our PictureBox
                        ImageBuffer im = result.ImageList[0];
                        _Pb.Image = CreateGreyscaleBitmap(im.Image, im.Width, im.Height);
                        _Imagen = (Bitmap)_Pb.Image;
                        _Calidad = result.TemplateQuality;

                        _Template = result.Template;

                        if (OnmsgChanged != null)
                            OnmsgChanged("Capturra OK, Calidad: " + _Calidad, false);

                        _device.Dispose();
                    }
                    else
                    {
                        Utilidades.LogLocal.GuardarLog("DFZ90A");
                        switch (l_e_AcquisitionError)
                        {
                            case ErrorCodes.IED_ERR_FALSE_FINGER_DETECTED:
                            case ErrorCodes.IED_ERR_MOIST_FINGER:
                            case ErrorCodes.IED_ERR_UNKOWN:
                                throw new FalseFingerDetectedException(l_e_AcquisitionError.ToString());
                                break;

                            case ErrorCodes.IED_ERR_CANCEL_ACQUISITION:
                                throw new OperationCanceledException("Captura cancelada");
                        }
                        _Pb.Image = null;
                        _Imagen = null;

                        if (OnmsgChanged != null)
                            OnmsgChanged("Se ha agotado el tiempo de captura, intente de nuevo.", true);

                        if (_device != null)
                            _device.Dispose();
                    }
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (FalseFingerDetectedException)
                {
                    throw;
                }
                catch (Exception exc)
                {
                    Utilidades.LogLocal.GuardarLog("DFZ99A: " + exc.ToString());
                    _Pb.Image = null;
                    _Imagen = null;

                    if (_device != null)
                        _device.Dispose();

                    if (OnmsgChanged != null)
                        OnmsgChanged("Ocurrió un problema con el dispositivo, intente de nuevo.", true);
                }
            }
        }

        public bool DetectarDispositivo()
        {
            try
            {
                var deviceInfos = _device.GetConnectedDevices();
                int numberOfDevices = deviceInfos.Length;
                if (numberOfDevices == 0)
                {
                    return false;
                }

                if (deviceInfos.Count() > 0)
                {
                    _Marca = "Morpho";
                    _Serial = deviceInfos[0];
                    _device.SetActiveDevice(deviceInfos[0]);
                    _Nombre = _device.GetModel();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible comunicarse con el dispositivo.");
            }
        }

        public void EstablecerLlave(string llave)
        {
            if (DetectarDispositivo())
            {
                byte[] llaveClaro = Convert.FromBase64String(llave);

                if (_hostCert != null)
                    _device.SetHostCertif(_hostCert);
                if (_hostKey != null)
                    _device.SetHostKey(_hostKey);
                if (_caCert != null)
                    _device.SetCACertif(_caCert);
                _device.SetEncriptionKey(llaveClaro);
            }
        }

        private void _device_QualityEvent(byte quality)
        {
            _Calidad = quality;

            if (OnQChanged != null)
                OnQChanged(Convert.ToInt32(_Calidad));
        }

        private Bitmap CreateGreyscaleBitmap(byte[] buffer, int width, int height)
        {
            int bpp = buffer.Length * 8 / (width * height);
            PixelFormat format = PixelFormat.Format8bppIndexed;
            switch (bpp)
            {
                case 8:
                    format = PixelFormat.Format8bppIndexed;
                    break;

                case 4:
                    format = PixelFormat.Format4bppIndexed;
                    break;
            }
            Bitmap bmp = new Bitmap(width, height, format);
            // copy the acquire image data to our bitmap
            // this works because the width of all MSO images is a multiple of 4
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, format);
            System.Runtime.InteropServices.Marshal.Copy(buffer, 0, bmpData.Scan0, width * height * bpp / 8);
            bmp.UnlockBits(bmpData);

            // set up a greyscale palette
            ColorPalette pal = bmp.Palette;
            int m = 256 / pal.Entries.Length;
            for (int i = 0; i < pal.Entries.Length; i++)
            {
                pal.Entries[i] = Color.FromArgb(i * m, i * m, i * m);
            }
            bmp.Palette = pal;
            return bmp;
        }

        private void device_EnrolmentEvent(int captureIndex)
        {
            if (OnmsgChanged != null)
                OnmsgChanged("Dispositivo Listo...", false); ;
        }

        private void device_FingerEvent(int status)
        {
            FingerEventStatus l_e_FingerEventStatus = FingerEventStatus.UNKNOWN;

            if (Enum.IsDefined(typeof(FingerEventStatus), status))
                l_e_FingerEventStatus = (FingerEventStatus)status;

            String msg = "";
            bool esError = false;

            switch (l_e_FingerEventStatus)
            {
                case FingerEventStatus.NO_FINGER_DETECTED: msg = "Apoye el dedo"; esError = true; break;
                case FingerEventStatus.MOVE_FINGER_UP: msg = "Mover dedo hacia arriba"; esError = true; break;
                case FingerEventStatus.MOVE_FINGER_DOWN: msg = "Mover dedo hacia abajo"; esError = true; break;
                case FingerEventStatus.MOVE_FINGER_LEFT: msg = "Mover dedo a la izquierda"; esError = true; break;
                case FingerEventStatus.MOVE_FINGER_RIGHT: msg = "Mover dedo a la derecha"; esError = true; break;
                case FingerEventStatus.PRESS_FINGER_HARDER: msg = "Presione más fuerte"; esError = true; break;
                case FingerEventStatus.LATENT: msg = "Dedo latente"; esError = true; break;
                case FingerEventStatus.REMOVE_FINGER: msg = "Retire el dedo"; esError = true; break;
                case FingerEventStatus.FINGER_OK: msg = "Captura Exitosa"; esError = false; break;
                case FingerEventStatus.FINGER_DETECTED: msg = "Dedo detectado"; esError = true; break;
                case FingerEventStatus.FINGER_MISPLACED: msg = "Dedo fuera de lugar"; esError = true; break;
                case FingerEventStatus.LIVE_OK: msg = "No retire el dedo"; esError = true; break;
                default: msg = "Apoye el dedo"; break;
            }

            if (OnmsgChanged != null)
                OnmsgChanged(msg, esError);
        }

        private void device_ImageEvent(byte[] buffer, int height, int width, int resolution)
        {
            _Pb.Image = (Bitmap)CreateGreyscaleBitmap(buffer, width, height);
        }
    }
}
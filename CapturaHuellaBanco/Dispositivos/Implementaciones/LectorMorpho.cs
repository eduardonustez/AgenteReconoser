using Morpho.MorphoAcquisition;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dispositivos.Implementaciones
{
    public class LectorMorpho : IDispositivo
    {
        private int _Calidad;
        private bool _HuellaViva = true;
        private Bitmap _Imagen;
        private string _Marca;
        private string _Nombre;
        private PictureBox _Pb;
        private int _Puerto;
        private string _Serial;
        private Byte[] _Template;
        private DeviceType CurrentComponentType = DeviceType.NO_DEVICE;
        private MorphoAcquisitionComponent GenericAcqComponent = null;
        public LectorMorpho()
        {
            _Pb = new PictureBox();
            _Pb.SizeMode = PictureBoxSizeMode.StretchImage;
            _Pb.Dock = DockStyle.Fill;
        }

        public event msgChanged OnmsgChanged;

        public event QChanged OnQChanged;
        public Byte[] CaCert
        {
            set { }
        }

        public int Calidad
        {
            get { return _Calidad; }
            set { _Calidad = value; }
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
            throw new NotImplementedException();
        }

        public void Capturar()
        {
            if (DetectarDispositivo())
            {
                try
                {
                    GenericAcqComponent.DeviceName = _Serial;
                    GenericAcqComponent.AcceptBadQualityEnrollment = false;
                    GenericAcqComponent.ShowLiveQualityBar = false;
                    GenericAcqComponent.ShowLiveQualityThreshold = false;
                    GenericAcqComponent.Timeout = 60;

                    if (_HuellaViva)
                        GenericAcqComponent.SecurityLevel = SecurityLevel.HIGH;
                    else
                        GenericAcqComponent.SecurityLevel = SecurityLevel.STANDARD;

                    GenericAcqComponent.LiveImage = true;
                    GenericAcqComponent.SetCulture("es-ES");
                    GenericAcqComponent.Consolidation = false;

                    byte[] b = null;

                    EnrollmentResult result = GenericAcqComponent.RunEnroll();

                    if (result == null)
                        throw new Exception("No ha sido posible completar la captura.");

                    if ((result.Status != ErrorCodes.IED_NO_ERROR) && (result.Status != ErrorCodes.WARNING_BAD_QUALITY_ACCEPTED))
                        throw new Exception("La calidad de la imágen no es óptima.");

                    _Pb.Image = BmpFromData(result.ImageList[0].Width, result.ImageList[0].Height, result.ImageList[0].Image, false);
                    _Imagen = (Bitmap)_Pb.Image;
                    _Calidad = result.TemplateQuality;

                    result.TemplateFormat = TemplateFormat.ISO_19794_2_FMR;
                    _Template = result.Template;
                }
                catch (Exception ex)
                {
                    _Pb.Image = null;
                    _Imagen = null;
                    _Template = null;
                    throw new Exception(ex.Message);
                }
            }
        }

        public bool DetectarDispositivo()
        {
            try
            {
                Morpho.MorphoSmart.MorphoSmartDevice _device = new Morpho.MorphoSmart.MorphoSmartDevice();
                var info = _device.GetConnectedDevices();
                int numberOfDevices = info.Count();

                if (numberOfDevices == 0)
                {
                    return false;
                }
                else
                {
                    _Nombre = "Morpho";
                    _Serial = info.FirstOrDefault();
                    _device.SetActiveDevice(_Serial);
                    _device.SetTemplateFormat(TemplateFormat.ISO_19794_2_FMR);

                    GenericAcqComponent = new MorphoAcquisitionComponent(_device);
                    string Device = GenericAcqComponent.GetConnectedDevices().FirstOrDefault();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EstablecerLlave(string llave)
        {
            throw new ArgumentException("El dispositivo no soporta llave de cifrado");
        }
        private Bitmap BmpFromData(int nWidth, int nHeight, byte[] pImage, bool invert)
        {
            try
            {
                System.IO.MemoryStream mem = new System.IO.MemoryStream();
                System.IO.BinaryWriter bw = new System.IO.BinaryWriter(mem);

                uint length = (uint)(5 * Marshal.SizeOf(typeof(ushort)) + 7 * Marshal.SizeOf(typeof(uint)) + 4 * Marshal.SizeOf(typeof(int)) + 1024 * Marshal.SizeOf(typeof(byte)) + nWidth * nHeight);

                bw.Write((ushort)('B' + 'M' * 0x100));
                bw.Write(length);
                bw.Write((ushort)0);
                bw.Write((ushort)0);
                bw.Write((uint)(5 * Marshal.SizeOf(typeof(ushort)) + 7 * Marshal.SizeOf(typeof(uint)) + 4 * Marshal.SizeOf(typeof(int)) + 1024 * Marshal.SizeOf(typeof(byte))));
                bw.Write((uint)(2 * Marshal.SizeOf(typeof(ushort)) + 5 * Marshal.SizeOf(typeof(uint)) + 4 * Marshal.SizeOf(typeof(int))));
                bw.Write(nWidth);
                bw.Write(nHeight);
                bw.Write((ushort)1);
                bw.Write((ushort)8);
                bw.Write((uint)0);
                bw.Write((uint)0);
                bw.Write((int)0x4CE6);
                bw.Write((int)0x4CE6);
                bw.Write((uint)0);
                bw.Write((uint)0);
                for (int i = 0; i < 256; i++)
                {
                    bw.Write((byte)(i));
                    bw.Write((byte)(i));
                    bw.Write((byte)(i));
                    bw.Write((byte)0);
                }
                for (int iCyc = 0; iCyc < nHeight; iCyc++)
                {
                    for (int iCxc = 0; iCxc < nWidth; iCxc++)
                        bw.Write((byte)(invert ? 255 - pImage[(nHeight - iCyc - 1) * nWidth + iCxc] : pImage[(nHeight - iCyc - 1) * nWidth + iCxc]));
                }
                return new Bitmap(mem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
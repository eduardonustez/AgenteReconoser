using Entidades;
using Futronic.MfAPIHelper;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Utilidades;

namespace Dispositivos.Implementaciones
{
    public class LectorFutronic : IDispositivo
    {
        private Device _Scanner;
        private bool HuellaValida;

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Serial;
        public string Serial
        {
            get { return _Serial; }
            set { _Serial = value; }
        }

        private bool _HuellaViva = true;
        public bool HuellaViva
        {
            get { return _HuellaViva; }
            set { _HuellaViva = value; }
        }

        private Bitmap _Imagen;
        public Bitmap Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        private int _Calidad;
        public int Calidad
        {
            get { return _Calidad; }
            set { _Calidad = value; }
        }

        private PictureBox _Pb;
        public PictureBox Pb
        {
            get { return _Pb; }
        }

        public LectorFutronic()
        {
            _Pb = new PictureBox();
            _Pb.SizeMode = PictureBoxSizeMode.StretchImage;
            _Pb.Dock = DockStyle.Fill;
        }

        public bool DetectarDispositivo()
        {
            _Scanner = null;

            FTRSCAN_INTERFACE_STATUS[] status = Device.GetInterfaces();

            for (int i = 0; i < status.Length; i++)
            {
                if (status[i] == FTRSCAN_INTERFACE_STATUS.FTRSCAN_INTERFACE_STATUS_CONNECTED)
                {
                    _Scanner = new Device();
                    _Scanner.Open(i);
                    _Nombre = "Futronic" + _Scanner.DeviceName;
                    _Serial = _Scanner.SerialNumber;
                    _Scanner.Close();
                    return true;
                }
            }

            return false;
        }

        public void Capturar()
        {
            _Scanner = null;
            byte[] image;
            int count = 0;
            Bitmap imagebitmap;
            HuellaValida = false;
            _Imagen = null;

            try
            {
                //Verificar si esta conectado
                FTRSCAN_INTERFACE_STATUS[] status = Device.GetInterfaces();

                for (int i = 0; i < status.Length; i++)
                {
                    if (status[i] == FTRSCAN_INTERFACE_STATUS.FTRSCAN_INTERFACE_STATUS_CONNECTED)
                    {
                        _Scanner = new Device();
                        _Scanner.Open(i);
                        _Scanner.DetectFakeFinger = _HuellaViva;
                        _Nombre = "Futronic" + _Scanner.DeviceName;
                        _Serial = _Scanner.SerialNumber;
                    }
                }
                if (_Scanner == null)
                    throw new Exception("Verifique que su dispositivo este conectado antes de iniciar");

                while (!HuellaValida)
                {
                    try
                    {
                        image = _Scanner.GetFrame();
                        imagebitmap = BmpFromData(_Scanner.ImageSize.Width, _Scanner.ImageSize.Height, image, true);
                        _Pb.Image = imagebitmap;
                        count++;

                        //Hace un Mapeo antes de capturar la huella definitiva
                        if (count == 3)
                        {
                            _Imagen = imagebitmap;
                            _Pb.Image = imagebitmap;
                            HuellaValida = true;
                            _Scanner.Close();
                        }
                    }
                    catch (MfAPIException ex)
                    {
                        count = 0;
                        image = null;
                        imagebitmap = null;
                        _Imagen = null;
                        _Pb.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
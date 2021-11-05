using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dispositivos
{
    public delegate void msgChanged(string _txt, bool esError);

    public delegate void QChanged(int Q);

    public interface IDispositivo
    {
        event msgChanged OnmsgChanged;

        event QChanged OnQChanged;

        Byte[] CaCert { set; }
        int Calidad { get; set; }
        bool CifrarHuella { get; set; }
        Byte[] HostCert { set; }
        Byte[] HostKey { set; }
        bool HuellaViva { get; set; }
        Bitmap Imagen { get; set; }
        string Marca { get; set; }
        string Nombre { get; set; }
        PictureBox Pb { get; }
        int PuertoCom { get; set; }
        string Serial { get; set; }
        Byte[] Template { get; set; }
        int Tipo { get; set; } // 1: USB - 2: Wifi - 3: Movil integrado
        void CancelarCaptura();

        void Capturar();

        bool DetectarDispositivo();
        void EstablecerLlave(string llave);
    }
}
using System.Drawing;

namespace Entidades
{
    public class DocVSHuellas
    {
        public string Documento { get; set; }
        public string Huella { get; set; }
    }

    public class HuellaAFI
    {
        public string Error { get; set; }
        public Bitmap ImgDedo { get; set; }
        public string NombreDedo { get; set; }
        public int NumeroDedo { get; set; }
        public string RespuestaAFI { get; set; }
        public int Score { get; set; }
        public string Template { get; set; }
    }
}
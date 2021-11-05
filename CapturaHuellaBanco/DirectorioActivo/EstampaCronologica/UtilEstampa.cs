using System.IO;
using iText.Kernel.Pdf;
using iText.Signatures;

namespace Utilidades.EstampaCronologica
{
    public static class UtilEstampa
    {
        public static byte[] AgregarEstampaCronologica(byte[] archivo)
            => AgregarEstampaCronologica(archivo, Configuracion.ConfiguracionDefecto);

        public static byte[] AgregarEstampaCronologica(byte[] archivo, Configuracion tsaConfig)
        {
            using (var inStream = new MemoryStream(archivo))
            using (var reader = new PdfReader(inStream))
            {
                var tsc = new TSAClientBouncyCastle(
                    tsaConfig.Url,
                    tsaConfig.Usuario,
                    tsaConfig.Contrasena,
                    TSAClientBouncyCastle.DEFAULTTOKENSIZE,
                    tsaConfig.Hash);
                using (MemoryStream ms = new MemoryStream())
                {
                    PdfSigner ps = new PdfSigner(reader, ms, new StampingProperties().UseAppendMode());
                    ps.Timestamp(tsc, tsaConfig.NombreFirma);

                    return ms.ToArray();
                }
            }
        }
    }
}

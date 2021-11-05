using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace Utilidades
{
    public class UtilidadesHuellas
    {
        public static string ConvertirBitmapToB64(Bitmap _Bit)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(_Bit, typeof(byte[]));

            return Convert.ToBase64String(xByte);
        }

        public static string ConvertirTemplateToB64(byte[] _b)
        {
            return Convert.ToBase64String(_b);
        }

        public static string NombreDedo(int _dedo)
        {
            try
            {
                string sDedo = string.Empty;

                switch (_dedo)
                {
                    case 1:
                        sDedo = "PULGAR, MANO DERECHA";
                        break;

                    case 2:
                        sDedo = "ÍNDICE, MANO DERECHA";
                        break;

                    case 3:
                        sDedo = "MEDIO, MANO DERECHA";
                        break;

                    case 4:
                        sDedo = "ANULAR, MANO DERECHA";
                        break;

                    case 5:
                        sDedo = "MEÑIQUE, MANO DERECHA";
                        break;

                    case 6:
                        sDedo = "PULGAR, MANO IZQUIERDA";
                        break;

                    case 7:
                        sDedo = "ÍNDICE, MANO IZQUIERDA";
                        break;

                    case 8:
                        sDedo = "MEDIO, MANO IZQUIERDA";
                        break;

                    case 9:
                        sDedo = "ANULAR, MANO IZQUIERDA";
                        break;

                    case 10:
                        sDedo = "MEÑIQUE, MANO IZQUIERDA";
                        break;

                    case 0:
                        sDedo = "MEÑIQUE, MANO IZQUIERDA";
                        break;
                }

                return sDedo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }
            }

            return Sb.ToString();
        }
    }
}
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Security;
using Newtonsoft.Json;

namespace Utilidades
{
    public class Cifrado
    {
        public static void Encrypt2File(string fileName, object o)
        {
            string data = JsonConvert.SerializeObject(o);
            File.WriteAllText(fileName, EncryptS(data));
        }

        public static T DecryptFromFile<T>(string fileName)
        {
            return JsonConvert.DeserializeObject<T>(DecryptS(File.ReadAllText(fileName)));
        }


        private static string keyString = "Olimpia999111";

        private static byte[] salt = Encoding.ASCII.GetBytes("Reconoser123321");

        public static string CifrarB64(string b64)
        {
            var certPublic = getPublicKey();
            var resp = Encrypt(certPublic, b64);
            return resp;
        }

        public static string DecryptS(string base64Text)
        {
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(keyString, salt);

            ICryptoTransform d = new RijndaelManaged().CreateDecryptor(key.GetBytes(32), key.GetBytes(16));
            byte[] bytes = Convert.FromBase64String(base64Text);
            return new StreamReader(new CryptoStream(new MemoryStream(bytes), d, CryptoStreamMode.Read)).ReadToEnd();
        }

        public static string Encrypt(X509Certificate2 x509, string stringToEncrypt)
        {
            if (x509 == null || string.IsNullOrEmpty(stringToEncrypt))
            {
                throw new Exception("A x509 certificate and string for encryption must be provided");
            }

            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)x509.PublicKey.Key;
            byte[] bytestoEncrypt = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt);
            byte[] encryptedBytes = rsa.Encrypt(bytestoEncrypt, false);
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string EncryptS(string plainText)
        {
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(keyString, salt);

            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(new CryptoStream(ms, new RijndaelManaged().CreateEncryptor(key.GetBytes(32), key.GetBytes(16)), CryptoStreamMode.Write));
            sw.Write(plainText);
            sw.Close();
            ms.Close();
            return Convert.ToBase64String(ms.ToArray());
        }

        public static X509Certificate2 getPublicKey()
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            string path = string.Format(@"{0}Olimpia.dll", AppDomain.CurrentDomain.BaseDirectory);
            X509Certificate2 cert2 = new X509Certificate2(path);
            return cert2;
        }
    }
}
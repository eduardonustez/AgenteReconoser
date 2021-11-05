using System;
using System.IO;
using System.Security.Cryptography;

namespace Utilidades
{
    public class SimpleAES
    {
        private ICryptoTransform EncryptorTransform, DecryptorTransform;

        // Change these keys
        private byte[] Key = { 230, 120, 8, 85, 12, 96, 50, 120, 88, 52, 12, 85, 52, 213, 56, 105, 103, 69, 15, 1, 23, 78, 86, 74, 41, 16, 85, 225, 223, 12, 75, 69 };

        private System.Text.UTF8Encoding UTFEncoder;
        private byte[] Vector = { 1, 34, 12, 76, 89, 221, 32, 84, 63, 152, 213, 113, 89, 69, 147, 240 };
        public SimpleAES()
        {
            //This is our encryption method
            RijndaelManaged rm = new RijndaelManaged();

            //Create an encryptor and a decryptor using our encryption method, key, and vector.
            EncryptorTransform = rm.CreateEncryptor(this.Key, this.Vector);
            DecryptorTransform = rm.CreateDecryptor(this.Key, this.Vector);

            //Used to translate bytes to text and vice versa
            UTFEncoder = new System.Text.UTF8Encoding();
        }

        /// -------------- Two Utility Methods (not used but may be useful) -----------
        /// Generates an encryption key.
        static public byte[] GenerateEncryptionKey()
        {
            //Generate a Key.
            RijndaelManaged rm = new RijndaelManaged();
            rm.GenerateKey();
            return rm.Key;
        }

        /// Generates a unique encryption vector
        static public byte[] GenerateEncryptionVector()
        {
            //Generate a Vector
            RijndaelManaged rm = new RijndaelManaged();
            rm.GenerateIV();
            return rm.IV;
        }

        // Same comment as above.  Normally the conversion would use an ASCII encoding in the other direction:
        //      System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
        //      return enc.GetString(byteArr);
        public string ByteArrToString(byte[] byteArr)
        {
            byte val;
            string tempStr = "";
            for (int i = 0; i <= byteArr.GetUpperBound(0); i++)
            {
                val = byteArr[i];
                if (val < (byte)10)
                {
                    tempStr += "00" + val.ToString();
                }
                else if (val < (byte)100)
                {
                    tempStr += "0" + val.ToString();
                }
                else
                {
                    tempStr += val.ToString();
                }
            }
            return tempStr;
        }

        /// Decryption when working with byte arrays.
        public string Decrypt(byte[] EncryptedValue)
        {
            return UTFEncoder.GetString(DecryptBytes(EncryptedValue));
        }

        /// Decryption when working with byte arrays.
        public byte[] DecryptBytes(byte[] EncryptedValue)
        {
            #region Write the encrypted value to the decryption stream

            using (MemoryStream encryptedStream = new MemoryStream())
            {
                using (CryptoStream decryptStream = new CryptoStream(encryptedStream, DecryptorTransform, CryptoStreamMode.Write))
                {
                    decryptStream.Write(EncryptedValue, 0, EncryptedValue.Length);
                    decryptStream.FlushFinalBlock();

                    #endregion Write the encrypted value to the decryption stream

                    #region Read the decrypted value from the stream.

                    encryptedStream.Position = 0;
                    byte[] decryptedBytes = new byte[encryptedStream.Length];
                    encryptedStream.Read(decryptedBytes, 0, decryptedBytes.Length);

                    return decryptedBytes;
                }
            }

            #endregion Read the decrypted value from the stream.
            
        }

        /// The other side: Decryption methods
        public string DecryptString(string EncryptedString)
        {
            return Decrypt(StrToByteArray(EncryptedString));
        }

        /// Encrypt some byte array and return an encrypted byte array.
        public byte[] Encrypt(byte[] bytes)
        {
            //Used to stream the data in and out of the CryptoStream.
            using (MemoryStream memoryStream = new MemoryStream())
            {
                /*
                 * We will have to write the unencrypted bytes to the stream,
                 * then read the encrypted result back from the stream.
                 */

                #region Write the decrypted value to the encryption stream

                using (CryptoStream cs = new CryptoStream(memoryStream, EncryptorTransform, CryptoStreamMode.Write))
                {
                    cs.Write(bytes, 0, bytes.Length);
                    cs.FlushFinalBlock();

                    #endregion Write the decrypted value to the encryption stream

                    #region Read encrypted value back out of the stream

                    memoryStream.Position = 0;
                    byte[] encrypted = new byte[memoryStream.Length];
                    memoryStream.Read(encrypted, 0, encrypted.Length);

                    #endregion Read encrypted value back out of the stream

                    return encrypted;
                }
            }
        }

        /// Encrypt some text and return an encrypted byte array.
        public byte[] Encrypt(string TextValue)
        {
            //Translates our text value into a byte array.
            byte[] bytes = UTFEncoder.GetBytes(TextValue);

            return Encrypt(bytes);
        }

        /// ----------- The commonly used methods ------------------------------
        /// Encrypt some text and return a string suitable for passing in a URL.
        public string EncryptToString(string TextValue)
        {
            return ByteArrToString(Encrypt(TextValue));
        }
        /// Convert a string to a byte array.  NOTE: Normally we'd create a Byte Array from a string using an ASCII encoding (like so).
        //      System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        //      return encoding.GetBytes(str);
        // However, this results in character values that cannot be passed in a URL.  So, instead, I just
        // lay out all of the byte values in a long string of numbers (three per - must pad numbers less than 100).
        public byte[] StrToByteArray(string str)
        {
            if (str.Length == 0)
            {
                throw new Exception("Invalid string value in StrToByteArray");
            }

            byte val;
            byte[] byteArr = new byte[str.Length / 3];
            int i = 0;
            int j = 0;
            do
            {
                val = byte.Parse(str.Substring(i, 3));
                byteArr[j++] = val;
                i += 3;
            }
            while (i < str.Length);
            return byteArr;
        }
    }
}
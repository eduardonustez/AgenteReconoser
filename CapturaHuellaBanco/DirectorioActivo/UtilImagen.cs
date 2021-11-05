using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Utilidades
{
    public class UtilImagen
    {
        public static Image ConvertirImagen(byte[] array)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(array))
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    return new Bitmap(System.Drawing.Image.FromStream(ms));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static byte[] GetBytes(string str)
        {
            try
            {
                byte[] bytes = new byte[str.Length * sizeof(char)];
                System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
                return bytes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static byte[] ImagenAByteArray(Image imageIn)
        {
            try
            {
                ImageConverter _imageConverter = new ImageConverter();
                byte[] xByte = (byte[])_imageConverter.ConvertTo(imageIn, typeof(byte[]));
                return xByte;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Image ObtenerImagen(byte[] array)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                stream.Write(array, 0, array.Length);
                Image img = new Bitmap(stream);

                return img;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Bitmap Redimensionar(Image img, int resizedW, int resizedH)
        {
            try
            {
                int originalW = img.Width;
                int originalH = img.Height;
                Bitmap bmp = new Bitmap(resizedW, resizedH);
                bmp.SetResolution(600, 600);
                Graphics graphic = Graphics.FromImage((Image)bmp);
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.DrawImage(img, 0, 0, resizedW, resizedH);
                graphic.Dispose();
                return bmp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Bitmap Redimensionar(byte[] array, int resizedW, int resizedH)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                stream.Write(array, 0, array.Length);
                Image img = new Bitmap(stream);

                int originalW = img.Width;
                int originalH = img.Height;
                Bitmap bmp = new Bitmap(resizedW, resizedH);
                bmp.SetResolution(600, 600);
                Graphics graphic = Graphics.FromImage((Image)bmp);
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.DrawImage(img, 0, 0, resizedW, resizedH);
                graphic.Dispose();
                return bmp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            try
            {
                var ratioX = (double)maxWidth / image.Width;
                var ratioY = (double)maxHeight / image.Height;
                var ratio = Math.Min(ratioX, ratioY);

                var newWidth = (int)(image.Width * ratio);
                var newHeight = (int)(image.Height * ratio);

                var newImage = new Bitmap(newWidth, newHeight);

                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.DrawImage(image, newWidth, newHeight, newWidth, newHeight);
                }

                return (Image)newImage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
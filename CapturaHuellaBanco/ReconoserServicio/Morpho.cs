//using Dispositivos;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Drawing;
//using System.IO;
//using System.ComponentModel;
//using System.Drawing.Imaging;

//namespace ReconoserServicio
//{
//    class Morpho
//    {
//        private IDispositivo ID;
//        private Bitmap _ImagenCapturada;

//        public string Capturar()
//        {
//            System.Text.StringBuilder sbTexto = new StringBuilder();

//            sbTexto.Append("DFZ10" + Environment.NewLine);
//            System.Diagnostics.Trace.WriteLine("DFZ10");


//            ID = Base.ObtenerDispositivo(Base.DeviceType.MorphoSinVentana, 0);
//            ID.TunnelingCert = null;

//            System.Diagnostics.Trace.WriteLine("DFZ20");

//            ID.HuellaViva = true;


//            //BackgroundWorker Capturar = new BackgroundWorker();
//            //Capturar.DoWork += new DoWorkEventHandler(Capturar_DoWork);
//            //Capturar.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Capturar_RunWorkerCompleted);
//            //Capturar.RunWorkerAsync();

//            ID.Capturar();

//            return Convert.ToBase64String(ImageToPng(ID.Imagen));


//            //sbTexto.Append("DFZ20" + Environment.NewLine);

//            //GuardarArchivo(sbTexto.ToString());

//        }

//        public static byte[] ImageToByte(Image img)
//        {
//            ImageConverter converter = new ImageConverter();  
//            return (byte[])converter.ConvertTo(img, typeof(byte[]));
//        }

//        public static byte[] ImageToPng(Image img)
//        {
//            byte[] result = null;
//            using (MemoryStream stream = new MemoryStream())
//            {
//                img.Save(stream, ImageFormat.Png);
//                result = stream.ToArray();
//            }

//            return result;

//        }


//        private void GuardarArchivo(string texto)
//        {
//            try
//            {
//                string sFile = string.Format(@"{0}\LogTS.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
//                StreamWriter writer = new StreamWriter(sFile, true);
//                string sLineaDetalle = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + texto;
//                writer.WriteLine(sLineaDetalle);
//                writer.Close();

//            }
//            catch (Exception Ex)
//            {
//                System.Diagnostics.Trace.WriteLine("Error:" + texto + " | " + Ex.ToString());

//            }


//        }

//        private void Capturar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
//        {
//            string res = e.Result.ToString();

//            if (res != "OK")
//            {
//                GuardarArchivo(res);

//                //rtbres.ForeColor = Color.Red;
//                //rtbres.Text = res;
//                //btnAcepta.Enabled = true;
//                //btnNoAcepta.Enabled = true;
//                //rbAcepta.Enabled = true;
//                //rdNoAcepta.Enabled = true;
//            }
//            else
//            {
//                GuardarArchivo("Captura Ok");
//                //btnFinalizar.Visible = true;
//                //rbAcepta.Enabled = true;
//                //rdNoAcepta.Enabled = true;
//                //btnAcepta.Enabled = true;
//                //btnNoAcepta.Enabled = true;

//                //rtbres.ForeColor = Color.Green;
//                //rtbres.Text = "Captura OK. Calidad: " + ID.Calidad.ToString();
//            }
//        }

//        private void Capturar_DoWork(object sender, DoWorkEventArgs e)
//        {
//            ID.Capturar();
//            if (ID.Imagen != null)
//            {
//                _ImagenCapturada = ID.Imagen;
//                e.Result = "OK";
//            }
//            else
//            {
//                e.Result = "Error en la captura, intente de nuevo";
//            }
//        }




//    }
//}

using Entidades;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.ServiceProcess;
using System.Text;
using System.Web.Security;
using System.Windows.Forms;

namespace ReconoserEstado
{
    public partial class Form1 : Form
    {

        //Se encuentran definidos en RestWCFReconoser
        private static string sParametrosFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamLog.dat");
        private static int _IdCliente =

#if DEBUG
        //3019
        1338;
#else
           1338;
#endif

        private NotifyIcon mynotifyicon;

        ServiceController controller = new ServiceController(ServiceName);


        public Form1()
        {
            this.Resize += Form1_Resize1;
            InitializeComponent();
        }

        private void Form1_Resize1(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                ActualizarEstado();
        }

        private void ActualizarEstado()
        {
            LimpiarEstado();
            Application.DoEvents();
            textBox1.Text = "Actualizando Estado...";
            Application.DoEvents();

            try
            {
                textBox1.Text = "";
                ActualizarEstadoServicio();

                ActualizarEstadoHost();

                if (string.IsNullOrEmpty(textBox1.Text))
                    textBox1.Text = "Estado del servicio actualizado correctamente";

            }
            catch (Exception ex)
            {
                textBox1.Text += $"{Environment.NewLine}Error al consultar el estado: {ex}";
            }
        }


        private void ActualizarEstadoHost()
        {
            var request = new RestRequest("ConsultarEstado", Method.GET);
            RestClient client = new RestClient(ServiceURL);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = response.Content;
                var respuesta = LeerConsulta(content);


                lbEstadoHost.Text = respuesta.Estado;
                if (respuesta.Estado.ToUpper() == "OK")
                    lbEstadoHost.BackColor = Color.Green;
                else
                    lbEstadoHost.BackColor = Color.Orange;

                lbVersion.Text = respuesta.Version;
                textBox1.Text += $"Propiedades del servicio:{Environment.NewLine}";
                if (respuesta.Propiedades != null)
                    foreach (var prop in respuesta.Propiedades)
                    {
                        switch (prop.Key.ToLower())
                        {
                            case "captordetectado":
                                textBox1.Text += $"\tCaptor Biométrico: {(prop.Value.ToLower() == "true" ? "Conectado" : "No detectado")}{Environment.NewLine}";
                                break;
                            case "wacomstusigcaptx":
                                textBox1.Text += $"\tServicio WacomSTUSigCaptX: {VerificarSTUEstado(prop.Value)}{Environment.NewLine}";
                                break;
                            case "iswacomdllregistered":
                                textBox1.Text += $"\tDll wgssSTU: {VerificarRegistroDllWgssSTu(prop.Value)} {Environment.NewLine}";
                                break;
                            default:
                                textBox1.Text += $"\t{prop.Key}: {prop.Value}{Environment.NewLine}";
                                break;
                        }
                    }
            }
            else
            {
                lbVersion.Text = "No es posible obtener la versión del servicio.";
                lbEstadoHost.Text = "No se pudo establecer comunicación con el servicio.";
                lbEstadoHost.BackColor = Color.Red;
                if (string.IsNullOrEmpty(response.ErrorMessage))
                    textBox1.Text += $"Error al consultar el estado del servicio - Error: {response.Content}{Environment.NewLine}";
                else
                    textBox1.Text += $"Error al obterner respuesta del estado del servicio - Error: {response.ErrorMessage}{Environment.NewLine}";
            }
        }
        private string VerificarSTUEstado(string value)
        {
            string EstadoWacomSTUSigCaptX = "Consultando...";
            switch (value)
            {
                case "NotInstalled":
                    EstadoWacomSTUSigCaptX = "No Instalado";
                    break;
                case "Stopped":
                    EstadoWacomSTUSigCaptX = "Detenido";
                    break;
                case "Running":
                    EstadoWacomSTUSigCaptX = "En Ejecución";
                    break;
                default:
                    EstadoWacomSTUSigCaptX = "No se puede consultar";
                    break;
            }
            return EstadoWacomSTUSigCaptX;
        }
        private string VerificarRegistroDllWgssSTu(string value)
        {
            string EstadoDll = "Consultando...";
            if (value == "1")
            {
                EstadoDll = "Registrada";
                lnkRegisterDll.Visible = false;
            }
            else
            {
                EstadoDll = "No Registrada";
                lnkRegisterDll.Visible = true;
            }
            return EstadoDll;
        }
        
        private RespuestaConsultaEstado LeerConsulta(string content)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                {
                    sw.Write(content);
                    sw.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
                    var ser = new DataContractJsonSerializer(typeof(RespuestaConsultaEstado));
                    return (RespuestaConsultaEstado)ser.ReadObject(ms);
                }
            }
        }



        private void LimpiarEstado()
        {
            lbEstadoHost.Text = "Estado del Host No disponible";
            lbEstadoHost.BackColor = Color.Black;
            lbEstadoServicio.Text = "Estado del Servicio No disponible";
            lbEstadoServicio.BackColor = Color.Black;
            lbVersion.Text = "Versión del Servicio No disponible";
            lbVersion.ForeColor = Color.Black;
            textBox1.Text = string.Empty;
        }

        private void ActualizarEstadoServicio()
        {
            if (string.IsNullOrEmpty(ServiceName))
            {
                textBox1.Text += $"Nombre de Servicio no válido. Revise Configuración de la aplicación.{Environment.NewLine}";
            }
            else
            {
                controller.Refresh();
                lbEstadoServicio.Text = controller.Status.ToString();
                if (controller.Status == ServiceControllerStatus.Running)
                {
                    lbEstadoServicio.BackColor = Color.Green;
                    btIniciarServicio.Text = "Reiniciar Servicio";
                    btIniciarServicio.ForeColor = Color.Green;
                }
                else
                {
                    lbEstadoServicio.BackColor = Color.Red;
                    btIniciarServicio.Text = "Iniciar Servicio";
                    btIniciarServicio.ForeColor = Color.Orange;
                }
            }
        }

        private static string ServiceName
        {
            get
            {
                return string.IsNullOrEmpty(ConfigurationManager.AppSettings["ServiceName"]) ? "" : ConfigurationManager.AppSettings["ServiceName"];
            }
        }

        private static string ServiceURL
        {
            get
            {
                return string.IsNullOrEmpty(ConfigurationManager.AppSettings["ServiceURL"]) ? "" : ConfigurationManager.AppSettings["ServiceURL"];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActualizarEstado();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    e.Cancel = true;
            //    this.WindowState = FormWindowState.Minimized;
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += (resender, certificate, chain, sslPolicyErrors) => true;
            try
            {
                lbVersionEstado.Text = Application.ProductVersion;
                this.Icon = Resource1.icon_olimpia_2;
                mynotifyicon = new NotifyIcon();
                mynotifyicon.Icon = Resource1.icon_olimpia_2;
                mynotifyicon.Click += mynotifyicon_Click;
                this.Text = "Reconoser Servicio v" + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            }
            catch (Exception Ex)
            {
                InsertarLogError(Ex, "Form1_Load");
            }
        }

        public void InsertarLogError(Exception Ex, string metodo)
        {
            //Log en disco
            string sFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogReconoserApp.log");
            using (var writer = new StreamWriter(sFile, true))
            {
                writer.WriteLine("ERROR NO REPORTADO:");
                writer.WriteLine("\t" + Ex.ToString());
                writer.WriteLine("\tCapa:\t" + "Formulario Local");
                writer.WriteLine("\tMetodo:\t" + metodo);
                writer.WriteLine("\tDescripcion:\t" + Ex.Message);
                writer.WriteLine("\tFecha:\t" + DateTime.Now.ToString());
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            try
            {

                mynotifyicon.BalloonTipText = lbEstadoHost.Text;
                mynotifyicon.Text = lbEstadoServicio.Text;
                if (FormWindowState.Minimized == this.WindowState)
                {
                    mynotifyicon.Visible = true;
                    this.Hide();
                }
                else if (FormWindowState.Normal == this.WindowState)
                {
                    mynotifyicon.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                InsertarLogError(Ex, "Form1_Resize");
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ActualizarEstado();
            //to minimize window
            //this.WindowState = FormWindowState.Minimized;

            //to hide from taskbar
            //this.Hide();
        }

        private void mynotifyicon_Click(object sender, EventArgs e)
        {
            ActualizarEstado();
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar la aplicación?", "Consulta Estado Reconoser", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Application.Exit();
        }

        private ParametrosOperacion ObtenerParametrosArchivo()
        {
            if (!File.Exists(sParametrosFile))
                throw new ApplicationException("No hay información de parametrización para operar en contingencia");
            else
            {
                try
                {
                    ParametrosOperacion po = DecryptFromFile<ParametrosOperacion>(sParametrosFile);
                    int days = 0;
                    int.TryParse(ConfigurationManager.AppSettings["DiasParametrosCt"], out days);

                    if (days > 0 && (DateTime.Now - po.FechaRegistro).TotalDays > days)
                        throw new ApplicationException("La parametrización para operar en contingencia ha expirado");
                    else
                        return po;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al consultar parametrización para operar en contingencia", ex);
                }
            }
        }

        private  T DecryptFromFile<T>(string fileName)
        {
            return JsonConvert.DeserializeObject<T>(DecryptS(File.ReadAllText(fileName)));
        }

        private static string keyString = "Olimpia999111";

        private static byte[] salt = Encoding.ASCII.GetBytes("Reconoser123321");

        private string DecryptS(string base64Text)
        {
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(keyString, salt);

            ICryptoTransform d = new RijndaelManaged().CreateDecryptor(key.GetBytes(32), key.GetBytes(16));
            byte[] bytes = Convert.FromBase64String(base64Text);
            return new StreamReader(new CryptoStream(new MemoryStream(bytes), d, CryptoStreamMode.Read)).ReadToEnd();
        }

        private string ObtenerPKeyForUpdates()
        {
            try
            {
                var po = ObtenerParametrosArchivo();

                return $"{_IdCliente}|{po.Oficina.Codigo}";
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"DFZ OPU Err: {ex}");
                return "*";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo procStartInfo = new ProcessStartInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WyUpdate.exe"));
                procStartInfo.Arguments = $"-urlargs:{ObtenerPKeyForUpdates()}";
                Process proc = new Process
                {
                    StartInfo = procStartInfo
                };
                proc.Start();
            }
            catch (Exception ex)
            {
                textBox1.Text = $"Ocurrió un error al buscar la actualización. Error: {ex}";
            }
        }

        private void lnkRegisterDll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strPath = @"C:\Program Files (x86)\Olimpia IT\ReconoserServicio\wgssSTU.dll";
            if (!Environment.Is64BitOperatingSystem)
            {
                strPath = @"C:\Program Files\Olimpia IT\ReconoserServicio\wgssSTU.dll";
            }
            try
            {
                string arg_fileinfo = " " + "\"" + strPath + "\"";
                Process reg = new Process();
                //This file registers .dll files as command components in the registry.
                reg.StartInfo.FileName = "regsvr32.exe";
                reg.StartInfo.Arguments = arg_fileinfo;
                reg.StartInfo.UseShellExecute = true;
                reg.StartInfo.CreateNoWindow = true;
                //reg.StartInfo.RedirectStandardOutput = true;
                reg.StartInfo.Verb = "runas";
                reg.Start();
                reg.WaitForExit();
                reg.Close();
                ActualizarEstado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btIniciarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (controller.Status != ServiceControllerStatus.Stopped)
                {
                    controller.Stop();
                    controller.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 1, 0));
                }

                controller.Start();
                controller.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 1, 0));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al tratar de iniciar el servicio\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActualizarEstado();
        }
    }
}
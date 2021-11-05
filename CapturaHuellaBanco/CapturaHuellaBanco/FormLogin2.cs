using CapturaHuellaBanco.ControlesWF;
using CapturaHuellaBanco.Properties;
using Entidades;
using Olimpia.Servicios;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Resources;
using System.ServiceModel.Configuration;
using System.Windows.Forms;
using Utilidades;

namespace CapturaHuellaBanco
{
    public partial class FormLogin2 : Form
    {
        private ConsumirServicio servicios;

        private frmBase _Base;
        private LogErrores error = null;
        private ObtenerIP ObtenerIP = new ObtenerIP();
        private ObtenerMac ObtenerMac = new ObtenerMac();
        private bool _EsSerfinansas = false;

        public FormLogin2()
        {
            try
            {
                InitializeComponent();
                var MV = ConfigurationManager.AppSettings["ModoVentana"];
                if (MV == "1")
                {
                    this.FormBorderStyle = FormBorderStyle.Fixed3D;
                }

                try
                {
                    ResourceManager myManager = new ResourceManager(typeof(Resources));
                    Bitmap logo = (Bitmap)myManager.GetObject(ConfigurationManager.AppSettings["Logo"].ToString());
                    this.pbLogoColpatria.Image = logo;
                }
                catch
                {
                    this.pbLogoColpatria.Image = Resources.logo_Image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMinimizar_EventoClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_EventoClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarConexion()
        {
            try
            {
                ClientSection clientSection = (ClientSection)ConfigurationManager.GetSection("system.serviceModel/client");
                var el = clientSection.Endpoints[0];
                string strAddr = el.Address.ToString();
                Uri uriServicio = new Uri(strAddr);

                TcpClient client = new TcpClient();

                IPAddress ip = IPAddress.Parse("127.1.1.1");

                if (IPAddress.TryParse(uriServicio.Host, out ip))
                {
                    client.Connect(new IPEndPoint(IPAddress.Parse(uriServicio.Host), uriServicio.Port));
                }
                else
                {
                    client.Connect(Dns.GetHostEntry(uriServicio.Host).HostName, uriServicio.Port);
                }
                client.Close();
                return true;
            }
            catch (Exception Ex)
            {
                //Log en disco
                string sFile = string.Format(@"{0}\LogReconoser.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                StreamWriter writer = new StreamWriter(sFile, true);
                string sLineaDetalle = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "Error ValidarConexion. Ex: " + Ex.ToString();
                writer.WriteLine(sLineaDetalle);
                writer.Close();

                return false;
            }
        }

        private void FormLogin2_Load(object sender, EventArgs e)
        {
            try
            {
                //Validacion Conexion
                //if(ValidarConexion() == false)
                //{
                //    MessageBox.Show("No se pudo  establecer conexión al servicio de la aplicación.\nContacte al Administrador del Sistema.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    btnLogin.Enabled = false;
                //    return;

                //}

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                //Carga Info control
                txbDominio.Text = Environment.UserDomainName;
                txbUsuario.Focus();

                lblVersion.Text = "Versión: " + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            }
            catch (Exception ex)
            {
                try
                {
                    //Log en disco
                    string sFile = string.Format(@"{0}\LogReconoser.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                    StreamWriter writer = new StreamWriter(sFile, true);
                    string sLineaDetalle = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "Error Load1. Ex: " + ex.ToString();
                    writer.WriteLine(sLineaDetalle);
                    writer.Close();
                }
                catch (Exception Ex3)
                {
                    System.Diagnostics.Trace.WriteLine("DFZ722: " + Ex3.ToString());
                }

                error = new LogErrores();
                error.UsuarioLogin = txbUsuario.Text;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlLogin : ctrlLogin_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                error.Ip = ObtenerIP.GetIP();
                error.Mac = ObtenerMac.GetMac();

                if (servicios == null)
                {
                    servicios = new ConsumirServicio();
                }

                try
                {
                    servicios.InsertarLogError(error);
                }
                catch (Exception Ex2)
                {
                    try
                    {
                        System.Diagnostics.Trace.WriteLine("DFZ724 " + string.Format(@"{0}\Log.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)));
                        //Log en disco
                        string sFile = string.Format(@"{0}\LogReconoser.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                        StreamWriter writer = new StreamWriter(sFile, true);
                        string sLineaDetalle = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "Error Load2. Ex: " + Ex2.ToString();
                        writer.WriteLine(sLineaDetalle);
                        writer.Close();
                    }
                    catch (Exception Ex3)
                    {
                        System.Diagnostics.Trace.WriteLine("DFZ726: " + Ex3.ToString());
                    }
                }

                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                //Solo para desarrollo
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Trace.WriteLine("ErrorAAC: " + Ex.ToString());
            }
        }

        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private void txbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnLogin.Imagen = Resources.continuarSobre;
                Application.DoEvents();
                btnLogin_EventoClick(null, null);
            }
        }

        private void btnLogin_EventoClick(object sender, EventArgs e)
        {
            frmBase.ULEH = "";
            servicios = null;

            UsuarioLogin UL;

            if (txbUsuario.Text == string.Empty)
            {
                MessageBox.Show("Ingrese su usuario antes de iniciar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txbPassword.Text == string.Empty)
            {
                MessageBox.Show("Ingrese su password antes de iniciar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txbDominio.Text == string.Empty)
            {
                MessageBox.Show("Ingrese su dominio antes de iniciar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmBase.ULEH = txbUsuario.Text.Trim();
            frmBase.PLEH = Cifrado.EncryptS(txbPassword.Text.Trim());
            frmBase.DLEH = txbDominio.Text.Trim();

            Form frm = new Form();
            frm.AutoSize = true;
            frm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            frm.Controls.Add(new ctrlEspera());
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.BringToFront();
            frm.Show();
            frm.Refresh();
            Application.DoEvents();
            //System.Threading.Thread.Sleep(5000);

            //DFZ Primera Conexion al Banco se presenta un error generico
            RespuestaListas<Entidades.Parametrizacion.Parametros> p = null;
            try
            {
                if (servicios == null)
                {
                    servicios = new ConsumirServicio();
                }

                p = Parametrizacion.ConsultarTodosParametros(false);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && (ex.InnerException.Message.Contains("401") || ex.InnerException.Message.Contains("403")))
                {
                    try
                    {
                        System.Diagnostics.Trace.WriteLine("DFZ750 " + string.Format(@"{0}\Log.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)));
                        //Log en disco
                        string sFile = string.Format(@"{0}\LogReconoser.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                        StreamWriter writer = new StreamWriter(sFile, true);
                        string sLineaDetalle = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " Error consultando parámetros. Ex: " + ex.ToString();
                        writer.WriteLine(sLineaDetalle);
                        writer.Close();
                    }
                    catch (Exception eX)
                    {
                        System.Diagnostics.Trace.WriteLine("DFZ752: " + eX.ToString());
                    }

                    frm.Hide();
                    MessageBox.Show("Error de autenticación, valide sus credenciales y que su cuenta no esté bloqueada. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Hay problemas técnicos contáctese con el administrador del sistema.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                try
                {
                    System.Diagnostics.Trace.WriteLine("DFZ750 " + string.Format(@"{0}\Log.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)));
                    //Log en disco
                    string sFile = string.Format(@"{0}\LogReconoser.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                    StreamWriter writer = new StreamWriter(sFile, true);
                    string sLineaDetalle = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " Error consultando parámetros. Ex: " + ex.ToString();
                    writer.WriteLine(sLineaDetalle);
                    writer.Close();
                }
                catch (Exception eX)
                {
                    System.Diagnostics.Trace.WriteLine("DFZ752: " + eX.ToString());
                }

                frm.Hide();
                return;
            }

            if (p.Estado != Estado.Ok)
            {
                MessageBox.Show("No se pudieron obtener los parámetros de inicio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frm.Hide();
                return;
            }

            string sInicio = "";

            if (p.Lista.FirstOrDefault(x => x.Parametro == "HoraInicioOperacion") != null)
            {
                sInicio = p.Lista.FirstOrDefault(x => x.Parametro == "HoraInicioOperacion").Valor.ToString();
            }
            else if (p.Lista.FirstOrDefault(x => x.Parametro == "HoraInicionOperacion") != null)
            {
                sInicio = p.Lista.FirstOrDefault(x => x.Parametro == "HoraInicionOperacion").Valor.ToString();
            }

            string sFin = p.Lista.FirstOrDefault(x => x.Parametro == "HorafinOperacion").Valor.ToString();

            DateTime inicioOperacion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(sInicio.Substring(0, 2)), Convert.ToInt32(sInicio.Substring(3, 2)), Convert.ToInt32(sInicio.Substring(6, 2)));
            DateTime finOperacion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(sFin.Substring(0, 2)), Convert.ToInt32(sFin.Substring(3, 2)), Convert.ToInt32(sFin.Substring(6, 2)));
            DateTime Ya = DateTime.Now;

            if (!(Ya >= inicioOperacion && Ya <= finOperacion))
            {
                MessageBox.Show("La aplicación no puede iniciar, debido a que está por fuera del horario de operación", "Horario de Operación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                frm.Hide();
                this.Close();
                return;
            }

            try
            {
                UL = servicios.IsAuthenticated(txbDominio.Text, txbUsuario.Text, txbPassword.Text, ObtenerMac.GetMac());
            }
            catch (Exception ex)
            {
                try
                {
                    System.Diagnostics.Trace.WriteLine("DFZ754 " + string.Format(@"{0}\Log.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)));
                    //Log en disco
                    string sFile = string.Format(@"{0}\LogReconoser.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                    StreamWriter writer = new StreamWriter(sFile, true);
                    string sLineaDetalle = "Error Login. Ex: " + ex.ToString();
                    writer.WriteLine(sLineaDetalle);
                    writer.Close();
                }
                catch (Exception eX)
                {
                    System.Diagnostics.Trace.WriteLine("DFZ756: " + eX.ToString());
                }

                error = new LogErrores();
                error.UsuarioLogin = txbUsuario.Text;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlLogin : btnLogin_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                error.Ip = ObtenerIP.GetIP();
                error.Mac = ObtenerMac.GetMac();
                servicios.InsertarLogError(error);

                frm.Hide();
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (UL.EsValido)
            {
                try
                {
                    _Base = new frmBase();
                    _Base.Usuario = UL.Usuario.ToUpper();
                    _Base.IdRol = UL.IdRol;
                    _Base.ImagenUsuario = UL.Imagen;
                    _Base.DisplayName = UL.DisplayName;
                    _Base.Title = UL.Title;
                    _Base.Mail = UL.Mail;
                    _Base.Par = p.Lista;
                    _Base.Oficina = UL.IdOficina;
                    _Base.IdAutenticacion = UL.IdAutenticacion;

                    //TODO: Serfinansas
                    //if (_EsSerfinansas)
                    //{
                    //    _Base.CargarControl(new ctrlCapturaHuella());
                    //}
                    //else
                    //{
                    _Base.CargarControl(new ctrlDashboard());
                    //}

                    frm.Hide();
                    this.Opacity = 0;
                    this.Hide();
                    this.ShowInTaskbar = false;
                    _Base.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = txbUsuario.Text;
                    error.Capa = "CapturaHuellaBanco";
                    error.Metodo = "ctrlLogin : btnLogin_EventoClick";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    error.Ip = ObtenerIP.GetIP();
                    error.Mac = ObtenerMac.GetMac();
                    servicios.InsertarLogError(error);

                    frm.Hide();
                }
            }
            else
            {
                MessageBox.Show("Error de autenticación, valide sus credenciales y que su cuenta no esté bloqueada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frm.Hide();
                return;
            }
        }

        private void btnHelp_EventoClick(object sender, EventArgs e)
        {
            try
            {
                Form frm = new Form();
                frm.AutoSize = true;
                frm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                frm.Controls.Add(new ctrlVideo(1));
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.BringToFront();
                frm.ShowDialog();
                frm.Refresh();
                Application.DoEvents();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }
    }
}
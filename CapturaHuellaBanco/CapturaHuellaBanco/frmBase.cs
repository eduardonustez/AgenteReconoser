using CapturaHuellaBanco.ControlesWF;
using CapturaHuellaBanco.Properties;
using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;

namespace CapturaHuellaBanco
{
    public partial class frmBase : Form
    {
        #region Propiedades

        private Timer _timer;

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        public Form frmFondo;
        public Form frmPopUp;

        private string _Usuario;

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        private string _Dominio;

        public string Dominio
        {
            get { return _Dominio; }
            set { _Dominio = value; }
        }

        private string _DisplayName;

        public string DisplayName
        {
            get { return _DisplayName; }
            set
            {
                _DisplayName = value;
                lblNombre.Text = value;
            }
        }

        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Mail;

        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; }
        }

        private int _IdRol = 0;

        public int IdRol
        {
            get { return _IdRol; }
            set { _IdRol = value; }
        }

        public string Titulo
        {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value; }
        }

        public Image ImagenUsuario
        {
            get { return pbImgUsu.Image; }
            set { pbImgUsu.Image = value; }
        }

        private long _IdAutenticacion;

        public long IdAutenticacion
        {
            get { return _IdAutenticacion; }
            set { _IdAutenticacion = value; }
        }

        public ParametrosBiometria_TiposDoc PBTD
        {
            get;
            set;
        }

        private RespuestaFormatos _FormatoProteccion;

        public RespuestaFormatos FormatoProteccion
        {
            get { return _FormatoProteccion; }
            set { _FormatoProteccion = value; }
        }

        private int _Inactividad;

        public int Inactividad
        {
            get { return _Inactividad; }
            set { _Inactividad = value; }
        }

        private List<Entidades.Parametrizacion.Parametros> _Par;

        public List<Entidades.Parametrizacion.Parametros> Par
        {
            get { return _Par; }
            set { _Par = value; }
        }

        private int _IdCliente;

        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        private Guid _IdConvenioAutenticacion;

        public Guid IdConvenioAutenticacion
        {
            get { return _IdConvenioAutenticacion; }
            set { _IdConvenioAutenticacion = value; }
        }

        public string _OficinaOrigen;
        private List<Entidades.Parametrizacion.Oficina> _Oficinas;

        public List<Entidades.Parametrizacion.Oficina> Oficinas
        {
            get { return _Oficinas; }
            set { _Oficinas = value; }
        }

        private List<Entidades.Parametrizacion.Oficina> _OficinasAll;

        public List<Entidades.Parametrizacion.Oficina> OficinasAll
        {
            get { return _OficinasAll; }
            set { _OficinasAll = value; }
        }

        private string _Oficina;

        public string Oficina
        {
            get { return _Oficina; }
            set { _Oficina = value; }
        }

        private List<Entidades.Parametrizacion.Producto> _Productos;

        public List<Entidades.Parametrizacion.Producto> Productos
        {
            get { return _Productos; }
            set { _Productos = value; }
        }

        private List<Entidades.Parametrizacion.Producto> _ProductosAll;

        public List<Entidades.Parametrizacion.Producto> ProductosAll
        {
            get { return _ProductosAll; }
            set { _ProductosAll = value; }
        }

        private static string _ULEH;

        public static string ULEH
        {
            get { return _ULEH; }
            set { _ULEH = value; }
        }

        private static string _PLEH;

        public static string PLEH
        {
            get { return _PLEH; }
            set { _PLEH = value; }
        }

        private static string _DLEH;

        public static string DLEH
        {
            get { return _DLEH; }
            set { _DLEH = value; }
        }

        ///TODO: Serfinansas
        private bool _ModoIntegrado = false;

        public bool ModoIntegrado
        {
            get { return _ModoIntegrado; }
            set { _ModoIntegrado = value; }
        }

        private int _PuertoUIC = -1;

        public int PuertoUIC
        {
            get { return _PuertoUIC; }
            set { _PuertoUIC = value; }
        }

        #endregion Propiedades

        private Olimpia.Servicios.ConsumirServicio sb = new Olimpia.Servicios.ConsumirServicio();
        private LogErrores error = null;
        private bool esMinimi = false;
        private bool esInactivo = false;

        //Req
        private static string applicationFolder = "Reconoser";

        private static string companyFolder = "Olimpia";
        private static readonly string directory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

        #region INACTVIDAD

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (esMinimi)
            {
                _timer.Stop();
                DisableControls();
                return;
            }

            if (GetIdleTime() >= Inactividad)
            {
                _timer.Stop();
                DisableControls();
                return;
            }
        }

        public static uint GetIdleTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)Marshal.SizeOf(lastInPut);
            GetLastInputInfo(ref lastInPut);

            return ((uint)Environment.TickCount - lastInPut.dwTime);
        }

        protected virtual void DisableControls()
        {
            esInactivo = true;
            MessageBox.Show("La aplicación ha superado el tiempo de inactividad y debe cerrarse", "Inactividad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Application.Restart();
        }

        #endregion INACTVIDAD

        private void frmBase_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    _IdCliente = Convert.ToInt32(Par.FirstOrDefault(x => x.Parametro == "Cliente").Valor.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo cargar el Cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try
                {
                    _IdConvenioAutenticacion = new Guid(Par.FirstOrDefault(x => x.Parametro == "Convenio").Valor.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo cargar el Convenio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try
                {
                    _ModoIntegrado = bool.Parse(Par.FirstOrDefault(x => x.Parametro == "ModoIntegrado").Valor);
                    Global.ModoIntegrado = _ModoIntegrado;

                    if (_ModoIntegrado == true)
                    {
                        try
                        {
                            Global.IdentificadorMaq = Par.FirstOrDefault(x => x.Parametro == "IdentificadorMaq").Valor.ToString();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se pudo cargar el Identificador de la maquina.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo cargar el Modo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try
                {
                    Inactividad = Convert.ToInt32(Par.FirstOrDefault(x => x.Parametro == "TiempoLogOut").Valor.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo cargar el tiempo de inactividad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try
                {
                    Global.DispositivoHuella = Par.FirstOrDefault(x => x.Parametro == "DispositivoHuella").Valor.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo cargar el Dispositivo para tomar Huellas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try
                {
                    Global.DispositivoFirma = Par.FirstOrDefault(x => x.Parametro == "DispositivoFirma").Valor.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo cargar el Dispositivo para tomar Huellas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try
                {
                    if (Global.DispositivoHuella == "MORPHO2")
                    {
                        var cert = Olimpia.Servicios.Biometria.ObtenerCertificado();
                        if (cert != null)
                        {
                            Global.TunnelingCert = (byte[])cert.Certificado.Clone();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo cargar la configuracion del Dispositivo para tomar Huellas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                _timer = new Timer();
                _timer.Interval = 10000;
                _timer.Tick += new EventHandler(_timer_Tick);
                _timer.Start();

                ObtenerBiometrias();
                ObtenerFormatos();
                ObtenerOficinas();
                ObtenerProductos();

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

                if (!OficinaRegistrada())
                {
                    PopUp(new ctrlOficinaInicio(_Oficinas));
                }

                _OficinaOrigen = CodigoOficina();

                var OficinaOrigenVal = OficinasAll.Where(x => x.IdOficina == _OficinaOrigen).FirstOrDefault();
                if (OficinaOrigenVal == null)
                {
                    PopUp(new ctrlOficinaInicio(_Oficinas));
                    _OficinaOrigen = CodigoOficina();
                }
                else
                {
                    if (OficinaOrigenVal.Habilitado == false)
                    {
                        PopUp(new ctrlOficinaInicio(_Oficinas));
                        _OficinaOrigen = CodigoOficina();
                    }
                }

                this.Text = "ReconoSer   Versión: " + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo cargar el tiempo de inactividad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool OficinaRegistrada()
        {
            string sFile = string.Format(@"{0}\Oficina.txt", ApplicationFolderPath);
            return File.Exists(sFile);

            //using (RegistryKey root = Registry.CurrentUser.OpenSubKey(@"Software\ReconoSer", false))
            //{
            //    if (root == null)
            //        return false;
            //    return root.GetValue("Sucursal") != null;
            //}
        }

        public static void RegistrarOficina(string codigo)
        {
            string sFile = string.Format(@"{0}\Oficina.txt", ApplicationFolderPath);
            CreateFolders(false);
            StreamWriter writer = new StreamWriter(sFile, false);
            string sLineaDetalle = codigo;
            writer.Write(sLineaDetalle);
            writer.Close();

            //using (RegistryKey RK = Registry.CurrentUser.OpenSubKey("Software", true))
            //{
            //    if (RK.OpenSubKey("ReconoSer") == null)
            //        RK.CreateSubKey("ReconoSer");
            //    using (RegistryKey RK2 = RK.OpenSubKey("ReconoSer", true))
            //        RK2.SetValue("Sucursal", codigo, RegistryValueKind.String);
            //}
        }

        public string CodigoOficina()
        {
            string sFile = string.Format(@"{0}\Oficina.txt", ApplicationFolderPath);
            return File.ReadAllText(sFile);

            //using (RegistryKey RK = Registry.CurrentUser.OpenSubKey(@"Software\ReconoSer", false))

            //    return RK.GetValue("Sucursal").ToString();
        }

        public static string ApplicationFolderPath
        {
            get { return Path.Combine(CompanyFolderPath, applicationFolder); }
        }

        public static string CompanyFolderPath
        {
            get { return Path.Combine(directory, companyFolder); }
        }

        private static void CreateFolders(bool allUsers)
        {
            DirectoryInfo directoryInfo;
            DirectorySecurity directorySecurity;
            AccessRule rule;
            SecurityIdentifier securityIdentifier = new SecurityIdentifier
                (WellKnownSidType.BuiltinUsersSid, null);
            if (!Directory.Exists(CompanyFolderPath))
            {
                directoryInfo = Directory.CreateDirectory(CompanyFolderPath);
                bool modified;
                directorySecurity = directoryInfo.GetAccessControl();
                rule = new FileSystemAccessRule(
                        securityIdentifier,
                        FileSystemRights.Write |
                        FileSystemRights.ReadAndExecute |
                        FileSystemRights.Modify,
                        AccessControlType.Allow);
                directorySecurity.ModifyAccessRule(AccessControlModification.Add, rule, out modified);
                directoryInfo.SetAccessControl(directorySecurity);
            }
            if (!Directory.Exists(ApplicationFolderPath))
            {
                directoryInfo = Directory.CreateDirectory(ApplicationFolderPath);
                if (allUsers)
                {
                    bool modified;
                    directorySecurity = directoryInfo.GetAccessControl();
                    rule = new FileSystemAccessRule(
                        securityIdentifier,
                        FileSystemRights.Write |
                        FileSystemRights.ReadAndExecute |
                        FileSystemRights.Modify,
                        InheritanceFlags.ContainerInherit |
                        InheritanceFlags.ObjectInherit,
                        PropagationFlags.InheritOnly,
                        AccessControlType.Allow);
                    directorySecurity.ModifyAccessRule(AccessControlModification.Add, rule, out modified);
                    directoryInfo.SetAccessControl(directorySecurity);
                }
            }
        }

        public frmBase()
        {
            try
            {
                InitializeComponent();

                ///TODO: Serfinansas
                //_EsSerfinansas = (bool)Convert.ToBoolean(ConfigurationManager.AppSettings["Serfinansas"].ToString());
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "frmBase : frmBase";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        public frmBase(Control ctrl)
        {
            try
            {
                InitializeComponent();
                CargarControl(ctrl);
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "frmBase : frmBase";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        public void ObtenerOficinas()
        {
            if (_Oficinas == null)
            {
                var resConsultarOF = Olimpia.Servicios.Parametrizacion.ConsultarTodosOficinas(false);
                if (resConsultarOF.Estado == Estado.Ok)
                {
                    _Oficinas = resConsultarOF.Lista;
                    _Oficinas.ForEach(x => x.Codigo = x.Codigo + "-" + x.IdOficina); //Precaucion cambiando el guion
                }
            }

            if (_OficinasAll == null)
            {
                var resConsultarOFAll = Olimpia.Servicios.Parametrizacion.ConsultarTodosOficinas(true);
                if (resConsultarOFAll.Estado == Estado.Ok)
                {
                    _OficinasAll = resConsultarOFAll.Lista;
                    _OficinasAll.ForEach(x => x.Codigo = x.Codigo + "-" + x.IdOficina); //Precaucion cambiando el guion
                }
            }
        }

        public void ObtenerProductos()
        {
            if (_Productos == null)
            {
                var resProd = Olimpia.Servicios.Parametrizacion.ConsultarTodosProductos(false);
                if (resProd.Estado == Estado.Ok)
                {
                    _Productos = resProd.Lista;
                }
            }

            if (_ProductosAll == null)
            {
                var resProd = Olimpia.Servicios.Parametrizacion.ConsultarTodosProductos(true);
                if (resProd.Estado == Estado.Ok)
                {
                    _ProductosAll = resProd.Lista;
                }
            }
        }

        private void ObtenerFormatos()
        {
            try
            {
                if (_FormatoProteccion == null)
                {
                    _FormatoProteccion = sb.ObtenerFormatoProteccionDatos(_IdCliente, _IdConvenioAutenticacion);
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "frmBase : CargarControl";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void ObtenerBiometrias()
        {
            if (PBTD == null)
            {
                PBTD = sb.ObtenerBiometrias(_IdCliente, _IdConvenioAutenticacion);
            }
        }

        public void CargarControl(Control ctrl)
        {
            try
            {
                _IdCliente = Convert.ToInt32(Par.FirstOrDefault(x => x.Parametro == "Cliente").Valor.ToString());
                _IdConvenioAutenticacion = new Guid(Par.FirstOrDefault(x => x.Parametro == "Convenio").Valor.ToString());
                _ModoIntegrado = bool.Parse(Par.FirstOrDefault(x => x.Parametro == "ModoIntegrado").Valor);

                ObtenerProductos();
                ObtenerOficinas();
                ObtenerFormatos();
                ObtenerBiometrias();

                pnlFotoNombre.AutoSize = true;
                pnlFotoNombre.AutoSizeMode = AutoSizeMode.GrowOnly;

                pnlContenido.Controls.Clear();
                ctrl.Dock = DockStyle.Fill;
                pnlContenido.Controls.Add(ctrl);
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "frmBase : CargarControl";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        public void ActivarPaneles(bool act)
        {
            try
            {
                //MenuActivo = act;
                lblTitulo.Visible = act;
                pbImgUsu.Visible = act;
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "frmBase : ActivarPaneles";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                CargarControl(new ctrlInformeTransaccional());
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "frmBase : toolStripMenuItem1_Click";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }

        private void validarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CargarControl(new ctrlCapturaHuella());
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "frmBase : validarClienteToolStripMenuItem_Click";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }

        private void btnMinimizar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "frmBase : btnMinimizar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }

        public DialogResult PopUp(UserControl ctrl)
        {
            DialogResult res = new DialogResult();

            try
            {
                /*frmFondo = new Form();
                frmFondo.Size = new Size(970, 550);
                frmFondo.WindowState = FormWindowState.Maximized;
                frmFondo.FormBorderStyle = FormBorderStyle.None;
                frmFondo.StartPosition = FormStartPosition.CenterScreen;
                frmFondo.BackColor = Color.White;
                frmFondo.Opacity = .75;
                frmFondo.ShowDialog(this);*/

                //Form frmPopUp = new Form();
                //frmPopUp.AutoSize = true;
                //frmPopUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                //frmPopUp.Controls.Add(ctrl);
                //frmPopUp.StartPosition = FormStartPosition.CenterScreen;
                //frmPopUp.FormBorderStyle = FormBorderStyle.None;
                //frmPopUp.BringToFront();
                //res = frmPopUp.ShowDialog(this);

                using (Form frmPopUp = new Form())
                {
                    frmPopUp.AutoSize = true;
                    frmPopUp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    frmPopUp.Controls.Add(ctrl);
                    frmPopUp.StartPosition = FormStartPosition.CenterScreen;
                    frmPopUp.FormBorderStyle = FormBorderStyle.None;
                    frmPopUp.BringToFront();
                    res = frmPopUp.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "frmBase : PopUp";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
            return res;
        }

        public void ExportarExcel(DataGridView dgv)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "xls|*.xls|xlsx|*.xlsx";
                sfd.Title = "Save an Image File";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FileName != string.Empty)
                    {
                        Utilidades.Excel.ExportarExcel(dgv, sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "frmBase : ExportarExcel";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }

        public void CargarBotonNumerico(string numero, bool b)
        {
            btnNumerico.Visible = b;
            btnNumerico.Texto = numero;
            btnNumerico.Activar();
        }

        private void BtnDashboard_EventoClick(object sender, EventArgs e)
        {
            try
            {
                CargarControl(new ctrlDashboard());
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "frmBase : BtnDashboard_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }

        public void OcultarIconoDashboard()
        {
            BtnDashboard.Visible = false;
        }

        public void MostrarIconoDashboard()
        {
            BtnDashboard.Visible = true;
        }

        public void MostrarIconoDashboard(string Tooltip)
        {
            BtnDashboard.Visible = true;
            BtnDashboard.Tooltip = Tooltip;
        }

        private void frmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                long id = this.IdAutenticacion;
                sb.ActualizarSalidaAplicacion(id, Usuario);
                pnlContenido.Controls.Clear();
                if (!string.IsNullOrEmpty(Global.ArchivoFormatoProtDatos))
                {
                    if (File.Exists(Global.ArchivoFormatoProtDatos))
                    {
                        BorrarTmp(Global.ArchivoFormatoProtDatos);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "frmBase : btnCerrar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void BorrarTmp(string ArchivoTemporal)
        {
            try
            {
                File.Delete(ArchivoTemporal);
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Trace.WriteLine("EBAT: " + Ex.ToString());
            }
        }

        private void btnCerrar_EventoClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBase_Activated(object sender, EventArgs e)
        {
            if (!esInactivo)
            {
                esMinimi = false;
                try
                {
                    _timer.Stop();
                    _timer.Interval = 10000;
                    _timer.Start();
                }
                catch (Exception) { }
            }
        }

        private void frmBase_Deactivate(object sender, EventArgs e)
        {
            if (!esInactivo)
            {
                esMinimi = true;
                try
                {
                    _timer.Stop();
                    _timer.Interval = Inactividad;
                    _timer.Start();
                }
                catch (Exception) { }
            }
        }

        private void boton1_EventoClick(object sender, EventArgs e)
        {
            var ctrl = pnlContenido.Controls[0];

            if (ctrl.Name == "ctrlInformeTransaccional")
            {
                PopUp(new ctrlVideo(2));
            }
            else
            {
                PopUp(new ctrlVideo(3));
            }

            //string sourcePath = Directory.GetCurrentDirectory();
            //string fileName = "ManualReconoser.pdf";
            //string sourceFile = System.IO.Path.Combine(sourcePath, fileName);

            //if (!System.IO.File.Exists(sourceFile))
            //{
            //    return;
            //}

            //var ayuda = System.IO.File.ReadAllBytes(sourceFile);

            //SaveFileDialog sfd = new SaveFileDialog();

            //sfd.Filter = "PDF files (*.pdf)|*.pdf";
            //sfd.FileName = "ManualReconoser.pdf";
            //sfd.RestoreDirectory = true;

            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    File.WriteAllBytes(sfd.FileName, ayuda);
            //}
        }
    }
}
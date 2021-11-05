using CapturaHuellaBanco.Properties;
using Dispositivos;
using Entidades;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CapturaHuellaBanco.ControlesWF
{
    public partial class ctrlHuella : UserControl
    {
        private static LogErrores error = null;
        private Bitmap _ImagenCapturada;
        private string _Serial;
        private byte[] _Template;
        private IDispositivo ID;
        private Olimpia.Servicios.ConsumirServicio sb = new Olimpia.Servicios.ConsumirServicio();
        public ctrlHuella()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlHuella : ctrlHuella";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        public ctrlHuella(int iDedo)
        {
            try
            {
                InitializeComponent();
                lblIndicadorDedo.Text = Utilidades.UtilidadesHuellas.NombreDedo(iDedo);
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlHuella : ctrlHuella";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        public Bitmap ImagenCapturada
        {
            get { return _ImagenCapturada; }
        }
        public string Serial
        {
            get { return _Serial; }
            set { _Serial = value; }
        }

        public byte[] Template
        {
            get { return _Template; }
            set { _Template = value; }
        }
        private void btnBorrar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                btnHuellaValida.Imagen = Resources.end_vacio;
                Capturar();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlHuella : btnBorrar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnCerrar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                _ImagenCapturada = null;
                _Template = null;
                this.ParentForm.Close();
                this.Hide();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlHuella : btnCerrar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnGuardar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                this.ParentForm.Close();
                this.Hide();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlHuella : btnGuardar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void Capturar()
        {
            try
            {
                _Serial = null;
                _ImagenCapturada = null;
                _Template = null;
                pbHuella.Controls.Clear();

                btnGuardar.Enabled = false;

                switch (Global.DispositivoHuella)
                {
                    case "MORPHO1":
                        ID = Base.ObtenerDispositivo(Base.DeviceType.Morpho, 0);
                        break;

                    case "MORPHO2":
                        ID = Base.ObtenerDispositivo(Base.DeviceType.MorphoSinVentana, 0);
                        ID.TunnelingCert = Global.TunnelingCert;
                        break;

                    default:
                        ID = Base.ObtenerDispositivo(Base.DeviceType.Morpho, 0);
                        break;
                }

                if (ID == null)
                {
                    _ImagenCapturada = null;
                    _Template = null;
                    rtbEstado.ForeColor = Color.Red;
                    rtbEstado.Text = "Dispositivo no encontrado.";
                    rtbEstado.SelectionAlignment = HorizontalAlignment.Center;
                    return;
                }

                rtbEstado.ForeColor = Color.Green;
                rtbEstado.Text = "Dispositivo listo...";
                rtbEstado.SelectionAlignment = HorizontalAlignment.Center;

                pbHuella.Controls.Add(ID.Pb);
                ID.HuellaViva = true;
                BackgroundWorker Capturar = new BackgroundWorker();
                Capturar.DoWork += new DoWorkEventHandler(Capturar_DoWork);
                Capturar.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Capturar_RunWorkerCompleted);
                Capturar.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                _ImagenCapturada = null;
                _Template = null;
                rtbEstado.ForeColor = Color.Red;
                rtbEstado.Text = ex.Message;
                rtbEstado.SelectionAlignment = HorizontalAlignment.Center;

                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlHuella : Capturar";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.ToString();
                sb.InsertarLogError(error);
            }
        }

        private void Capturar_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ID.Capturar();
                _ImagenCapturada = ID.Imagen;
                _Template = ID.Template;
                _Serial = ID.Serial;
                e.Result = "OK";
                btnHuellaValida.Imagen = Resources.end;
            }
            catch (Exception ex)
            {
                _ImagenCapturada = null;
                _Template = null;
                e.Result = ex.Message;

                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlHuella : Capturar_DoWork";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void Capturar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                string res = e.Result.ToString();

                if (res != "OK")
                {
                    _ImagenCapturada = null;
                    _Template = null;
                    rtbEstado.ForeColor = Color.Red;
                    rtbEstado.Text = res;
                    rtbEstado.SelectionAlignment = HorizontalAlignment.Center;
                }
                else
                {
                    rtbEstado.ForeColor = Color.Green;
                    rtbEstado.Text = "Huella capturada con éxito. Calidad:" + ID.Calidad.ToString();
                    rtbEstado.SelectionAlignment = HorizontalAlignment.Center;
                    btnGuardar.Visible = true;
                    btnGuardar.Enabled = true;
                }
                btnBorrar.Enabled = true;
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlHuella : Capturar_RunWorkerCompleted";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void ctrlHuella_Load(object sender, EventArgs e)
        {
            try
            {
                Capturar();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlHuella : ctrlHuella_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }
    }
}
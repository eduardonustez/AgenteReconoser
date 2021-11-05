using Controles;
using Dispositivos;
using Entidades;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilidades;

namespace CapturaHuellaBanco.ControlesWF
{
    public partial class ctrlFormatoProteccionDatos : UserControl
    {
        private static LogErrores error = null;
        private frmBase _Base;
        private string _Ciudad;
        private string _Cod_ID_Oficina;
        private string _CodProducto;
        private string _Documento;
        private RespuestaFormatos _Formato;
        private long _IdAutorizacion;
        private string _IdOficina;
        private int _IdProducto;
        private Bitmap _ImagenCapturada;
        private string _Producto;
        private string _Sigla;
        private string _Usuario;
        private bool acepta;
        private string archivotmp = "";
        private IDispositivo ID;
        private System.Drawing.Image imagenCheck = Properties.Resources.end;
        private System.Drawing.Image imagenNoCheck = Properties.Resources.end_vacio;
        private Olimpia.Servicios.ConsumirServicio sb = new Olimpia.Servicios.ConsumirServicio();
        private WebBrowser visorFormato = new WebBrowser();
        public ctrlFormatoProteccionDatos()
        {
            try
            {
                InitializeComponent();
                CargarvisorFormato();
                var COMPorts = UtilidadesCOM.ObtenerDispositvosCOM();
                cboPtoSig.DataSource = SerialPort.GetPortNames();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "FormatoProteccionDatos";
                error.Metodo = "ctrlFormatoProteccionDatos : ctrlFormatoProteccionDatos";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        public ctrlFormatoProteccionDatos(string IdOficina, string Cod_ID_Oficina, int IdProducto, string codProducto, string Producto, string Usuario, string Documento, string Sigla, RespuestaFormatos Formato, string Ciudad)
        {
            try
            {
                InitializeComponent();

                _IdOficina = IdOficina;
                _IdProducto = IdProducto;
                _Usuario = Usuario;
                _Documento = Documento;
                _Sigla = Sigla;
                _Formato = Formato;
                _CodProducto = codProducto;
                _Producto = Producto;
                _Cod_ID_Oficina = Cod_ID_Oficina;
                CargarvisorFormato();
                _Ciudad = Ciudad;

                if (Global.DispositivoFirma == "UIC1")
                {
                    var COMPorts = UtilidadesCOM.ObtenerDispositvosCOM();
                    Global.PuertoUIC = COMPorts.FirstOrDefault((x) => { return x.descripcionBus == "Signature PIN Pad PP795"; }).puerto;
                    cboPtoSig.DataSource = SerialPort.GetPortNames();
                    cboPtoSig.SelectedItem = Global.PuertoUIC;
                    lblPto.Visible = true;
                    cboPtoSig.Visible = true;
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "FormatoProteccionDatos";
                error.Metodo = "ctrlFormatoProteccionDatos : ctrlFormatoProteccionDatos";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        public bool Acepta
        {
            get { return acepta; }
            set { acepta = value; }
        }

        public string ArchivoTemporal
        {
            get { return archivotmp; }
            set { archivotmp = value; }
        }
        public long IdAutorizacion
        {
            get { return _IdAutorizacion; }
            set { _IdAutorizacion = value; }
        }
        private void AceptaFormato()
        {
            ImagenConCheck(this.btnAcepta, this.btnNoAcepta);

            //toma la huella en el reporte
            lblFirma.Visible = true;
            pbHuella.Visible = true;
            btnFinalizar.Visible = false;
            rtbres.Visible = true;

            rbAcepta.Enabled = false;
            rdNoAcepta.Enabled = false;
            btnAcepta.Enabled = false;
            btnNoAcepta.Enabled = false;

            Capturar();
        }

        private byte[] AgregarInfo(byte[] b, string _Documento, string _IdOficina, string _CodProducto, string _Producto, string _Usuario)
        {
            using (var ms = new MemoryStream())
            {
                //Bind a reader to the bytes that we created above
                using (var reader = new PdfReader(b))
                {
                    //Store our page count
                    var pageCount = reader.NumberOfPages;

                    //Bind a stamper to our reader
                    using (var stamper = new PdfStamper(reader, ms))
                    {
                        //Setup a font to use
                        var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                        var Calibri8 = FontFactory.GetFont("Calibri", 10, BaseColor.BLACK);

                        //Loop through each page
                        for (var i = 1; i <= pageCount; i++)
                        {
                            //Get the raw PDF stream "on top" of the existing content
                            var cb = stamper.GetUnderContent(i);

                            List<string> Valores = new List<string>();
                            Valores.Add("Documento: " + _Documento);
                            Valores.Add("Oficina: " + _Cod_ID_Oficina.Replace("-", " - "));
                            Valores.Add("Producto: " + _CodProducto + " - " + _Producto);
                            Valores.Add("Asesor: " + _Usuario);
                            Valores.Add("Ciudad: " + _Ciudad);

                            StringBuilder NuevaFrase = new StringBuilder();

                            for (int intCont = 0; intCont < Valores.Count; intCont++)
                            {
                                string Valor = Valores[intCont];
                                NuevaFrase.Append(Valor);
                                if (intCont != Valores.Count - 1)
                                {
                                    NuevaFrase.Append("\n");
                                }
                            }

                            PdfPTable table = new PdfPTable(1);
                            table.SetTotalWidth(new float[] { 460 });
                            Phrase phrase = new Phrase();

                            phrase.Add(new Chunk(NuevaFrase.ToString(), Calibri8));

                            PdfPCell cell = new PdfPCell(phrase);
                            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            table.AddCell(cell);
                            table.WriteSelectedRows(0, 1, 80, 250, cb);
                        }
                    }
                }

                //Once again, grab the bytes before closing things out
                b = ms.ToArray();
            }

            //Just to see the final results I'm writing these bytes to disk but you could do whatever
            return b;
        }

        private void btnAcepta_EventoClick(object sender, EventArgs e)
        {
            if (visorFormato.Document != null)
            {
                if ((Convert.ToDouble(visorFormato.Document.Body.ScrollTop) / (visorFormato.Document.Body.ScrollRectangle.Height - visorFormato.Document.Body.ClientRectangle.Height)) < 0.5)
                {
                    MessageBox.Show("Asegurese que haya leido todo el documento, desplace la barra vertical (scrollbar).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            AceptaFormato();
        }

        private void btNContinuar_EventoClick(object sender, EventArgs e)
        {
            this.ParentForm.Close();
            this.Hide();
        }

        private void btnFinalizar_EventoClick(object sender, EventArgs e)
        {
            Form frm = new Form();
            try
            {
                frm.AutoSize = true;
                frm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                frm.Controls.Add(new ctrlEspera());
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.BringToFront();
                frm.Show();

                Application.DoEvents();

                acepta = true;

                ObtenerIP OI = new ObtenerIP();

                byte[] img = UtilImagen.ImagenAByteArray(_ImagenCapturada);
                string _Ip = OI.GetIP();

                byte[] pdfConInfo = AgregarInfo(_Formato.Archivo, _Documento, _IdOficina, _CodProducto, _Producto, _Usuario);

                if (acepta == true)
                {
                    _IdAutorizacion = sb.CrearAutorizacionCandidato(acepta, pdfConInfo, _IdOficina, _IdProducto, img, _Ip, _Usuario, _Documento, _Sigla, null);
                }

                if (_IdAutorizacion == -1)
                {
                    frm.Hide();
                    img = null;
                    MessageBox.Show("La imágen es inválida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                pnlVisor.Controls.Clear();
                Application.DoEvents();

                frm.Hide();
                this.ParentForm.Close();
                this.Hide();
                img = null;
            }
            catch (Exception ex)
            {
                acepta = false;
                rtbres.ForeColor = Color.Red;
                rtbres.Text = ex.Message;
                frm.Hide();

                btnAcepta.Enabled = true;
                btnNoAcepta.Enabled = true;
                rbAcepta.Enabled = true;
                rdNoAcepta.Enabled = true;
            }
        }

        private void btnNoAcepta_EventoClick(object sender, EventArgs e)
        {
            pnlVisor.Controls.Clear();
            Application.DoEvents();

            NoAceptaFormato();
        }

        private void Capturar()
        {
            _ImagenCapturada = null;

            if (Global.DispositivoFirma == "UIC1")
            {
                pbHuella.Location = new Point(380, 350);
                pbHuella.Size = new Size(190, 77);
            }

            pbHuella.Controls.Clear();

            try
            {
                switch (Global.DispositivoFirma)
                {
                    case "MORPHO1":
                        ID = Base.ObtenerDispositivo(Base.DeviceType.Morpho, 0);
                        break;

                    case "MORPHO2":
                        ID = Base.ObtenerDispositivo(Base.DeviceType.MorphoSinVentana, 0);
                        ID.TunnelingCert = Global.TunnelingCert;
                        break;

                    case "UIC1":
                        Global.PuertoUIC = cboPtoSig.SelectedItem.ToString();
                        ID = Base.ObtenerDispositivo(Base.DeviceType.PadUIC, int.Parse(cboPtoSig.SelectedItem.ToString().Substring(3)));
                        break;

                    default:
                        ID = Base.ObtenerDispositivo(Base.DeviceType.Morpho, 0);
                        break;
                }

                if (ID == null)
                {
                    rtbres.ForeColor = Color.Red;
                    rtbres.Text = "Dispositivo no encontrado.";
                    rtbres.SelectionAlignment = HorizontalAlignment.Center;
                    btnAcepta.Enabled = true;
                    btnNoAcepta.Enabled = true;
                    rbAcepta.Enabled = true;
                    rdNoAcepta.Enabled = true;
                    return;
                }

                rtbres.ForeColor = Color.Green;
                rtbres.Text = "Dispositivo Listo...";

                pbHuella.Controls.Add(ID.Pb);
                ID.HuellaViva = true;
                BackgroundWorker Capturar = new BackgroundWorker();
                Capturar.DoWork += new DoWorkEventHandler(Capturar_DoWork);
                Capturar.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Capturar_RunWorkerCompleted);
                Capturar.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlHuella : Capturar";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.ToString();
                sb.InsertarLogError(error);

                rtbres.ForeColor = Color.Red;
                rtbres.Text = ex.Message;
                btnAcepta.Enabled = true;
                btnNoAcepta.Enabled = true;
                rbAcepta.Enabled = true;
                rdNoAcepta.Enabled = true;
            }
        }

        private void Capturar_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ID.Capturar();
                if (ID.Imagen != null)
                {
                    _ImagenCapturada = ID.Imagen;
                    e.Result = "OK";
                }
                else
                {
                    e.Result = "Error en la captura, intente de nuevo";
                }
            }
            catch (Exception ex)
            {
                _ImagenCapturada = null;
                e.Result = ex.Message;

                rtbres.ForeColor = Color.Red;
                rtbres.Text = ex.Message;
                btnAcepta.Enabled = true;
                btnNoAcepta.Enabled = true;
                rbAcepta.Enabled = true;
                rdNoAcepta.Enabled = true;

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
                    rtbres.ForeColor = Color.Red;
                    rtbres.Text = res;
                    btnAcepta.Enabled = true;
                    btnNoAcepta.Enabled = true;
                    rbAcepta.Enabled = true;
                    rdNoAcepta.Enabled = true;
                }
                else
                {
                    btnFinalizar.Visible = true;
                    rbAcepta.Enabled = true;
                    rdNoAcepta.Enabled = true;
                    btnAcepta.Enabled = true;
                    btnNoAcepta.Enabled = true;

                    rtbres.ForeColor = Color.Green;
                    rtbres.Text = "Captura OK. Calidad: " + ID.Calidad.ToString();
                }
            }
            catch (Exception ex)
            {
                rtbres.ForeColor = Color.Red;
                rtbres.Text = ex.Message;
                btnAcepta.Enabled = true;
                btnNoAcepta.Enabled = true;
                rbAcepta.Enabled = true;
                rdNoAcepta.Enabled = true;

                error = new LogErrores();
                error.UsuarioLogin = "System";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlHuella : Capturar_RunWorkerCompleted";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void CargarvisorFormato()
        {
            try
            {
                if (!string.IsNullOrEmpty(Global.ArchivoFormatoProtDatos))
                {
                    if (File.Exists(Global.ArchivoFormatoProtDatos))
                    {
                        archivotmp = Global.ArchivoFormatoProtDatos;
                    }
                }

                pnlVisor.Controls.Clear();
                if (string.IsNullOrEmpty(archivotmp)) //Si no existe se crea
                {
                    archivotmp = Path.GetTempFileName();
                    archivotmp = Path.ChangeExtension(archivotmp, "pdf");
                    Global.ArchivoFormatoProtDatos = archivotmp;
                    File.WriteAllBytes(archivotmp, _Formato.Archivo);
                }
                var uri = new Uri(archivotmp);
                var converted = uri.AbsoluteUri;
                visorFormato.DocumentText = "<iframe src='" + @archivotmp + "#toolbar=0&navpanes=0&scrollbar=0&view=FitH' width='1000' height='1150' style='border: 0;'></iframe>";
                visorFormato.Dock = DockStyle.Fill;
                pnlVisor.Controls.Add(visorFormato);
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "FormatoProteccionDatos";
                error.Metodo = "ctrlFormatoProteccionDatos : FormatoProteccionDatos_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void CargarvisorFormatoDenegado()
        {
            try
            {
                pnlVisor.Controls.Clear();
                string archivotmp = Path.GetTempFileName();
                archivotmp = Path.ChangeExtension(archivotmp, "pdf");
                Global.ArchivoFormatoProtDatos = archivotmp;

                File.WriteAllBytes(archivotmp, _Formato.ArchivoRechazo);
                var uri = new Uri(archivotmp);
                var converted = uri.AbsoluteUri;
                visorFormato.DocumentText = "<iframe src='" + @archivotmp + "#toolbar=0&navpanes=0&scrollbar=0&view=FitH' width='1000' height='1150' style='border: 0;'></iframe>";
                visorFormato.Dock = DockStyle.Fill;
                pnlVisor.Controls.Add(visorFormato);
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "FormatoProteccionDatos";
                error.Metodo = "ctrlFormatoProteccionDatos : FormatoProteccionDatos_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void cboPtoSig_DropDown(object sender, EventArgs e)
        {
        }

        private void cboPtoSig_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ctrlFormatoProteccionDatos_Load(object sender, EventArgs e)
        {
            _Base = (frmBase)this.ParentForm.Owner;
            if (Global.DispositivoFirma == "UIC1")
            {
                if (Global.PuertoUIC != string.Empty)
                {
                    try
                    {
                        cboPtoSig.SelectedItem = Global.PuertoUIC;
                    }
                    catch
                    {
                        Global.PuertoUIC = string.Empty;
                    }
                }
                if (Global.PuertoUIC == string.Empty)
                {
                    var COMPorts = UtilidadesCOM.ObtenerDispositvosCOM();
                    Global.PuertoUIC = COMPorts.FirstOrDefault((x) => { return x.descripcionBus == "Signature PIN Pad PP795"; }).puerto;
                    cboPtoSig.DataSource = SerialPort.GetPortNames();
                    cboPtoSig.SelectedItem = Global.PuertoUIC;
                }
            }
        }
        private void ImagenConCheck(Boton botonChek, Boton botonNoChek)
        {
            if (acepta != null)
            {
                botonChek.Imagen = botonChek.ImagenVisitada = this.imagenCheck;
                botonNoChek.Imagen = botonNoChek.ImagenVisitada = this.imagenNoCheck;
            }
            else
            {
                botonChek.Imagen = botonChek.ImagenVisitada = this.imagenNoCheck;
                botonNoChek.Imagen = botonNoChek.ImagenVisitada = this.imagenNoCheck;
            }
        }

        private void NoAceptaFormato()
        {
            //Esconde el panel de captura huela, en caso de que lo hayan desplegado            
            this.ParentForm.Close();
            this.Hide();
        }

        private void rbAcepta_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rdNoAcepta_CheckedChanged(object sender, EventArgs e)
        {
            visorFormato.Stop();
            Application.DoEvents();

            NoAceptaFormato();
        }
    }
}
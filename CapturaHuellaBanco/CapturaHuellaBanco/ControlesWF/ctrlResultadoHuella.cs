using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Utilidades;

namespace CapturaHuellaBanco.ControlesWF
{
    public partial class ctrlResultadoHuella : UserControl
    {
        static LogErrores error = null;
        Banco.ServicioBanco sb = new Banco.ServicioBanco();


        private void ctrlResultadoHuella_Load(object sender, EventArgs e)
        {
            frmBase _Base = (frmBase)this.ParentForm;
            _Base.Titulo = "RESULTADOS DE AUTENTICACIÓN";
            _Base.MostrarIconoDashboard();

            //_Base.CargarBotonNumerico("2", true);
        }

        public ctrlResultadoHuella()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlResultadoHuella : ctrlResultadoHuella";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        public ctrlResultadoHuella(LogOperaciones LO)
        {
            try
            {
                InitializeComponent();
                CargarCtrl(LO);
                EstructuraGrid();
                dgvResultadoDedos.DataSource = LO.HA;
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlResultadoHuella : ctrlResultadoHuella";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }

        private void EstructuraGrid()
        {
            try
            {
                Func<string, string, bool, DataGridViewTextBoxColumn> ColTxb = (name, header, visible) =>
                     new DataGridViewTextBoxColumn { Name = name, DataPropertyName = name, HeaderText = header, Visible = visible };

                Func<string, string, DataGridViewCheckBoxColumn> ColChb = (name, header) =>
                     new DataGridViewCheckBoxColumn { Name = name, DataPropertyName = name, HeaderText = header };

                Func<string, string, bool, DataGridViewImageColumn> ColImg = (name, header, visible) =>
                     new DataGridViewImageColumn { Name = name, DataPropertyName = name, HeaderText = header, Visible = visible };

                dgvResultadoDedos.Columns.Add(ColTxb("NumeroDedo", "Número Dedo", false));
                dgvResultadoDedos.Columns.Add(ColImg("ImgDedo", "Huella Capturada", false));
                dgvResultadoDedos.Columns.Add(ColTxb("NombreDedo", "NOMBRE DEDO", true));
                dgvResultadoDedos.Columns.Add(ColTxb("RespuestaAFI", "RESULTADO", true));
                dgvResultadoDedos.Columns.Add(ColTxb("Score", "Score", true));
                dgvResultadoDedos.Columns.Add(ColTxb("Error", "Detalle", true));

                dgvResultadoDedos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvResultadoDedos.ClearSelection();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlResultadoHuella : EstructuraGrid";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }

        private void CargarCtrl(LogOperaciones LO)
        {
            try
            {
                rtbResultado.SelectionColor = Color.DimGray;
                rtbResultado.AppendText("LA SOLICITUD DEL CIUDADANO HA SIDO: ");

                string fecha = string.Empty;
                if (LO.FechaExpedicion != DateTime.MinValue)
                {
                    fecha = LO.FechaExpedicion.ToString("dd/MM/yyyy");
                }

                txbNumeroDocumento.Text = LO.TipoDocumento;
                txbPrimerNombre.Text = LO.PrimerNombre;
                txbSegundoNombre.Text = LO.SegundoNombre;
                txbPrimerApellido.Text = LO.PrimerApellido;
                txbSegundoApellido.Text = LO.SegundoApellido;
                txbTipoDocumento.Text = LO.TipoDocumento;
                txbNumeroDocumento.Text = LO.Documento;
                txbFechaExpedicion.Text = fecha;
                txbServicio.Text = LO.NombreServicio;
                txbVigencia.Text = LO.Vigencia;

                if (LO.RespuestaAFI == "HIT")
                {
                    rtbResultado.SelectionColor = Color.Green;
                    rtbResultado.AppendText(LO.RespuestaAFI);
                }
                else
                {
                    rtbResultado.SelectionColor = Color.Red;
                    rtbResultado.AppendText(LO.RespuestaAFI);
                }


                rtbResultado.SelectionAlignment = HorizontalAlignment.Center;
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlResultadoHuella : CargarCtrl";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnAtras_EventoClick(object sender, EventArgs e)
        {
            try
            {
                frmBase _Base = (frmBase)this.ParentForm;
                _Base.CargarControl(new ctrlDashboard());
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlResultadoHuella : btnAceptar_Click";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }
    }
}
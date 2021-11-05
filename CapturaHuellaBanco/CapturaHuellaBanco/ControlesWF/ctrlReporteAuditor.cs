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
    public partial class ctrlReporteAuditor : UserControl
    {
        frmBase _Base;
        static LogErrores error = null;
        Bitmap bmp = new Bitmap(1, 1);
        string LogoAfi;
        string estado;

        private Banco.ServicioBanco sb = new Banco.ServicioBanco();

        public ctrlReporteAuditor()
        {
            InitializeComponent();
            cmbEstado.SelectedIndex = 0;
            dgvInforme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ctrlReporteAuditor_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "Resumen de consultas";
                _Base.MostrarIconoDashboard();

                if (_Base.IdRol == 1)//si es Asesor
                {
                    txbUsuario.Text = _Base.Usuario;
                    txbUsuario.ReadOnly = true;
                }

                //Hace consulta de datos
                CosultarGrid();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlInformeTransaccional : ctrlInformeSupervisor_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void CosultarGrid()
        {
            bool b = UtilidadesFecha.EsmayorAB(dtpFechaInicio.Value, dtpFechaFin.Value);

            if (b)
            {
                dtpFechaInicio.Value = dtpFechaFin.Value;
                MessageBox.Show("La fecha de inicio no debe ser mayor a la fecha final", "Rango de fechas incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool cantDias = UtilidadesFecha.CantidadDias(dtpFechaInicio.Value, dtpFechaFin.Value);

            if (cantDias)
            {
                dtpFechaInicio.Value = dtpFechaFin.Value;
                MessageBox.Show("La cantidad de días que desea filtrar no es permitida, validé que el rango de días entre fechas no sea mayor a 31 días", "Rango de días incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime fechaConsultaI = new DateTime(dtpFechaInicio.Value.Year, dtpFechaInicio.Value.Month, dtpFechaInicio.Value.Day, 0, 0, 0);
            DateTime fechaConsultaF = new DateTime(dtpFechaFin.Value.Year, dtpFechaFin.Value.Month, dtpFechaFin.Value.Day, 23, 59, 59);

            if (cmbEstado.Text == "Exitoso")
                estado = "HIT";
            else if (cmbEstado.Text == "No Exitoso")
                estado = "NOHIT";

            string IdOficina = txbOficina.Text.Trim() == string.Empty ? null : txbOficina.Text.Trim();

            var v = sb.SeleccionarLogOperaciones(null, fechaConsultaI, fechaConsultaF, txbDocumento.Text, txbUsuario.Text, estado, IdOficina);

            foreach (var item in v)
            {
                if (item.RespuestaAFI != "HIT")
                {
                    bmp = new Bitmap(CapturaHuellaBanco.Properties.Resources.Recurso_8_1);
                    bmp.Tag = "No Exitoso";
                }
                else
                {
                    bmp = new Bitmap(CapturaHuellaBanco.Properties.Resources.Recurso_9);
                    bmp.Tag = "Exitoso";
                }

                item.Respuesta = bmp;

                item.Nombre = string.Format("{0} {1} {2} {3}", item.PrimerApellido, item.SegundoApellido, item.PrimerNombre, item.SegundoNombre);
            }

            Func<string, string> GetCodigo = (x) =>
            {
                string codofi = _Base.OficinasAll.FirstOrDefault(y => y.IdOficina == x).Codigo ?? "";
                codofi = codofi.Substring(0, codofi.IndexOf('-'));
                return codofi;
            };


            var res = v.Select(x => new
            {
                x.Respuesta,

                IdOficina = GetCodigo(x.IdOficina),
                //x.IdOficina,

                Usuario = x.UsuarioLogin,
                x.Nombre,
                x.RespuestaAFI,
                x.PrimerNombre,
                x.SegundoNombre,
                x.PrimerApellido,
                x.SegundoApellido,
                x.TipoDocumento,
                x.Documento,
                Fecha = x.Fecha.ToString(),
                //x.NombreServicio,
                FechaExpedicion = x.FechaExpedicion.ToString(),
                x.Vigencia,

                x.IdProducto,
                CodProducto = _Base.ProductosAll.FirstOrDefault(y => y.IdProducto == x.IdProducto).Codigo ?? "",
                Descripción = _Base.ProductosAll.FirstOrDefault(y => y.IdProducto == x.IdProducto).Descripcion ?? "",

                NombreDedo = x.NumeroDedo > 10 ? UtilidadesHuellas.NombreDedo(Convert.ToInt32(x.NumeroDedo.ToString().Replace("10", "0").Substring(0, 1))) + "; " + UtilidadesHuellas.NombreDedo(Convert.ToInt32(x.NumeroDedo.ToString().Replace("10", "0").Substring(1, 1))) : UtilidadesHuellas.NombreDedo(x.NumeroDedo),
                x.IP,
                x.MAC,
                x.Serial,
                x.Rol,
                x.Zona
            }).ToList();

            dgvInforme.DataSource = res;

            lblCantidadRegistros.Text = "N° registros: " + dgvInforme.RowCount.ToString();

            if (dgvInforme.RowCount == 0)
                BtnExportar.Enabled = false;
            else
                BtnExportar.Enabled = true;

            //dgvInforme.Columns["RespuestaAFI"].Visible = false;
            //dgvInforme.Columns["NombreServicio"].Visible = false;
            dgvInforme.Columns["PrimerApellido"].Visible = false;
            dgvInforme.Columns["SegundoApellido"].Visible = false;
            dgvInforme.Columns["PrimerNombre"].Visible = false;
            dgvInforme.Columns["SegundoNombre"].Visible = false;
            dgvInforme.Columns["FechaExpedicion"].Visible = false;
            dgvInforme.Columns["IdOficina"].Visible = false;
            dgvInforme.Columns["RespuestaAFI"].Visible = false;
            dgvInforme.Columns["Fecha"].Visible = false;
            dgvInforme.Columns["Vigencia"].Visible = false;

            dgvInforme.Columns["IdProducto"].Visible = false;
            dgvInforme.Columns["Descripción"].Visible = false;
            dgvInforme.Columns["CodProducto"].Visible = false;
            dgvInforme.Columns["CodProducto"].HeaderText = "Producto";

            dgvInforme.Columns["NombreDedo"].Visible = false;
            dgvInforme.Columns["Serial"].Visible = false;

            dgvInforme.Columns["Vigencia"].HeaderText = "Resultado";
            dgvInforme.Columns["TipoDocumento"].HeaderText = "Tipo";
        }

        private void dgvInforme_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BtnLogoEstado.BackgroundImage = null;
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                //Cargar combo de Productos
                int p = Convert.ToInt32(row.Cells["IdProducto"].Value == null ? 0 : row.Cells["IdProducto"].Value);
                lblIdProducto.Text = _Base.ProductosAll.FirstOrDefault(x => x.IdProducto == p).Descripcion;

                LblFechaTrans.Text = row.Cells["Fecha"].Value.ToString();
                LblOficina.Text = row.Cells["IdOficina"].Value == null ? "" : row.Cells["IdOficina"].Value.ToString();

                //LblVigencia.Text = row.Cells["Vigencia"].Value.ToString();
                //LblFormato.Text = row.Cells["Documento"].Value.ToString();

                if (row.Cells["Vigencia"].Value != null)
                    LblTextoEstado.Text = row.Cells["Vigencia"].Value.ToString();
                else
                    LblTextoEstado.Text = "";

                LogoAfi = row.Cells["RespuestaAFI"].Value.ToString();

                if (LogoAfi != "HIT")
                {
                    BtnLogoEstado.BackgroundImage = Properties.Resources.error_detalle;
                }
                else
                {
                    BtnLogoEstado.BackgroundImage = Properties.Resources.icon_detalle;
                }

                lblDedos.Text = row.Cells["NombreDedo"].Value.ToString().Replace(';', ' ');
                if (row.Cells["Serial"].Value != null)
                {
                    lblSerial.Text = row.Cells["Serial"].Value.ToString();
                }
                else
                {
                    lblSerial.Text = "";
                }

                lblCodigo.Text = row.Cells["CodProducto"].Value != null ? row.Cells["CodProducto"].Value.ToString() : "";

                panelDetalle.Visible = true;
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlInformeTransaccional : dgvInforme_RowEnter";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void BtnBuscar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                CosultarGrid();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlInformeTransaccional : BtnBuscar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void BtnExportar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                //frmBase _Base = (frmBase)this.ParentForm;
                //_Base.ExportarExcel(dgvInforme);

                DataGridView dgv = Utilidades.CopyDataGridView.CopyDGV(dgvInforme);
                if (dgv.Rows.Count > 0)
                {
                    dgv.Columns.Remove("RespuestaAFI");
                    dgv.Columns.Remove("IdProducto");
                    frmBase _Base = (frmBase)this.ParentForm;
                    _Base.ExportarExcel(dgv);
                }

            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlInformeTransaccional : BtnExportar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void BtnLimpiar_EventoClick(object sender, EventArgs e)
        {
            txbUsuario.Text = string.Empty;
            txbDocumento.Text = string.Empty;

            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = dtpFechaInicio.Value;


            DateTime fechaConsultaI = new DateTime(dtpFechaInicio.Value.Year, dtpFechaInicio.Value.Month, dtpFechaInicio.Value.Day, 0, 0, 0);
            DateTime fechaConsultaF = new DateTime(dtpFechaFin.Value.Year, dtpFechaFin.Value.Month, dtpFechaFin.Value.Day, 23, 59, 59);

            if (cmbEstado.Text == "Exitoso")
                estado = "HIT";
            else if (cmbEstado.Text == "No Exitoso")
                estado = "NO HIT";

            txbOficina.Text = string.Empty;

            //dgvInforme.DataSource = null;

            //lblCantidadRegistros.Text = "N° registros: 0";

            //LblOficina.Text = string.Empty;
            //LblFechaTrans.Text = string.Empty;
            //lblIdProducto.Text = string.Empty;
            //LblFormato.Text = string.Empty;
            //lblDedos.Text = string.Empty;
            //LblTextoEstado.Text = string.Empty;
            //BtnLogoEstado.BackgroundImage = null;
        }
    }
}

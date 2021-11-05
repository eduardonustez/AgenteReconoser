using Entidades;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilidades;

namespace CapturaHuellaBanco.ControlesWF
{
    public partial class ctrlInformeTransaccional : UserControl
    {
        private static LogErrores error = null;
        private frmBase _Base;
        private Bitmap bmp = new Bitmap(1, 1);
        private string estado;
        private string LogoAfi;
        private Olimpia.Servicios.ConsumirServicio sb = new Olimpia.Servicios.ConsumirServicio();

        public ctrlInformeTransaccional()
        {
            try
            {
                InitializeComponent();
                cmbEstado.SelectedIndex = 0;
                dgvInforme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlInformeTransaccional : ctrlInformeTransaccional";
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
                DataGridView dgv = CopyDataGridView.CopyDGV(dgvInforme);
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
                throw;
            }
        }

        private void BtnLimpiar_EventoClick(object sender, EventArgs e)
        {
            if (txbUsuario.ReadOnly == false)
            {
                txbUsuario.Text = string.Empty;
            }
            if (txbOficina.ReadOnly == false)
            {
                txbOficina.Text = string.Empty;
            }
            txbDocumento.Text = string.Empty;

            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = dtpFechaInicio.Value;

            DateTime fechaConsultaI = new DateTime(dtpFechaInicio.Value.Year, dtpFechaInicio.Value.Month, dtpFechaInicio.Value.Day, 0, 0, 0);
            DateTime fechaConsultaF = new DateTime(dtpFechaFin.Value.Year, dtpFechaFin.Value.Month, dtpFechaFin.Value.Day, 23, 59, 59);

            if (cmbEstado.Text == "Exitoso")
            {
                estado = "HIT";
            }
            else if (cmbEstado.Text == "No Exitoso")
            {
                estado = "NO HIT";
            }

            dgvInforme.DataSource = null;

            lblCantidadRegistros.Text = "N° registros: 0";

            LblNombreCompleto.Text = string.Empty;
            LblUsuario.Text = string.Empty;
            LblNumeroDoc.Text = string.Empty;
            lblCodigo.Text = string.Empty;
            LblFechaTrans.Text = string.Empty;
            lblIdProducto.Text = string.Empty;
            LblOficina.Text = string.Empty;
            LblTextoEstado.Text = string.Empty;
            BtnLogoEstado.BackgroundImage = new Bitmap(1, 1);
            Application.DoEvents();
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
            {
                estado = "HIT";
            }
            else if (cmbEstado.Text == "No Exitoso")
            {
                estado = "NOHIT";
            }

            string IdOficina = txbOficina.Text.Trim() == string.Empty ? null : txbOficina.Text.Trim();

            var v = sb.SeleccionarLogOperaciones(null, fechaConsultaI, fechaConsultaF, txbDocumento.Text, txbUsuario.Text, estado, IdOficina);

            foreach (var item in v)
            {
                if (item.RespuestaAFI != "HIT")
                {
                    bmp = new Bitmap(Properties.Resources.Recurso_8_1);
                    bmp.Tag = "No Exitoso";
                }
                else
                {
                    bmp = new Bitmap(Properties.Resources.Recurso_9);
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
                Usuario = x.UsuarioLogin,
                x.Nombre,
                x.RespuestaAFI,

                IdOficina = GetCodigo(x.IdOficina),
                x.IdProducto,
                CodProducto = _Base.ProductosAll.FirstOrDefault(y => y.IdProducto == x.IdProducto).Codigo ?? "",
                Descripcion = _Base.ProductosAll.FirstOrDefault(y => y.IdProducto == x.IdProducto).Descripcion ?? "",

                x.PrimerNombre,
                x.SegundoNombre,
                x.PrimerApellido,
                x.SegundoApellido,
                x.TipoDocumento,
                x.Documento,
                Fecha = x.Fecha.ToString(),
                FechaExpedicion = x.FechaExpedicion.ToString(),
                x.Vigencia,
                NombreDedo = x.NumeroDedo > 10 ? UtilidadesHuellas.NombreDedo(Convert.ToInt32(x.NumeroDedo.ToString().Replace("10", "0").Substring(0, 1))) + "; " + UtilidadesHuellas.NombreDedo(Convert.ToInt32(x.NumeroDedo.ToString().Replace("10", "0").Substring(1, 1))) : UtilidadesHuellas.NombreDedo(x.NumeroDedo)
            }).ToList();

            dgvInforme.DataSource = res;

            lblCantidadRegistros.Text = "N° registros: " + dgvInforme.RowCount.ToString();

            if (dgvInforme.RowCount == 0)
            {
                BtnExportar.Enabled = false;
            }
            else
            {
                BtnExportar.Enabled = true;
            }

            dgvInforme.Columns["RespuestaAFI"].Visible = false;
            dgvInforme.Columns["NombreDedo"].Visible = false;
            dgvInforme.Columns["PrimerApellido"].Visible = false;
            dgvInforme.Columns["SegundoApellido"].Visible = false;
            dgvInforme.Columns["PrimerNombre"].Visible = false;
            dgvInforme.Columns["SegundoNombre"].Visible = false;
            dgvInforme.Columns["FechaExpedicion"].Visible = false;
            dgvInforme.Columns["IdOficina"].Visible = false;
            dgvInforme.Columns["IdProducto"].Visible = false;
            dgvInforme.Columns["CodProducto"].Visible = false;
            dgvInforme.Columns["Descripcion"].Visible = false;

            dgvInforme.Columns["Vigencia"].HeaderText = "Resultado";
            dgvInforme.Columns["TipoDocumento"].HeaderText = "Tipo";
        }

        private void ctrlInformeSupervisor_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "Resumen de consulta";
                _Base.MostrarIconoDashboard();

                txbUsuario.Text = _Base.Usuario;
                txbUsuario.ReadOnly = true;

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

        private void dgvInforme_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BtnLogoEstado.BackgroundImage = null;
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                LblNombreCompleto.Text = row.Cells["Nombre"].Value.ToString();
                LblUsuario.Text = row.Cells["Usuario"].Value.ToString();
                LblNumeroDoc.Text = row.Cells["Documento"].Value.ToString();
                LblFechaTrans.Text = row.Cells["Fecha"].Value.ToString();

                if (row.Cells["Vigencia"].Value != null)
                {
                    LblTextoEstado.Text = row.Cells["Vigencia"].Value.ToString();
                }
                else
                {
                    LblTextoEstado.Text = "";
                }

                LogoAfi = row.Cells["RespuestaAFI"].Value.ToString();

                if (LogoAfi != "HIT")
                {
                    BtnLogoEstado.BackgroundImage = Properties.Resources.error_detalle;
                }
                else
                {
                    BtnLogoEstado.BackgroundImage = Properties.Resources.icon_detalle;
                }

                //Cargar combo de Productos
                int p = Convert.ToInt32(row.Cells["IdProducto"].Value == null ? 0 : row.Cells["IdProducto"].Value);
                lblIdProducto.Text = _Base.ProductosAll.FirstOrDefault(x => x.IdProducto == p).Descripcion;
                lblCodigo.Text = _Base.ProductosAll.FirstOrDefault(x => x.IdProducto == p).Codigo;

                LblOficina.Text = row.Cells["IdOficina"].Value == null ? "" : row.Cells["IdOficina"].Value.ToString();

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
    }
}
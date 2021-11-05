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
    public partial class ctrlReporteFacturacion : UserControl
    {
        frmBase _Base;

        static LogErrores error = null;
        Bitmap bmp = new Bitmap(1, 1);
        string LogoAfi;

        private Banco.ServicioBanco sb = new Banco.ServicioBanco();

        private void ctrlReporteFacturacion_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "REPORTE FACTURACIÓN";
                _Base.MostrarIconoDashboard();
                //Hace consulta de datos
                CosultarGrid();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteFacturacion : ctrlReporteFacturacion_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }

        }
        public ctrlReporteFacturacion()
        {
            try
            {
                InitializeComponent();
                dgvInforme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteFacturacion : ctrlReporteFacturacion";
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
                error.Metodo = "ctrlReporteFacturacion : BtnBuscar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void BtnExportar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                frmBase _Base = (frmBase)this.ParentForm;
                _Base.ExportarExcel(dgvInforme);
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteFacturacion : BtnExportar_EventoClick";
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
            //CosultarGrid();
        }

        private void dgvInforme_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                LblOficina.Text = row.Cells["Oficina"].Value.ToString();

                string p = row.Cells["Producto"].Value == null ? "" : row.Cells["Producto"].Value.ToString();
                lblIdProducto.Text = _Base.ProductosAll.FirstOrDefault(x => x.Codigo == p).Descripcion;


                LblValor.Text = row.Cells["Valor_unitario"].Value.ToString();
                LblAprobados.Text = row.Cells["Aprobados"].Value.ToString();
                LblNoAprobados.Text = row.Cells["No_Aprobados"].Value.ToString();
                lblValorTotal.Text = row.Cells["ValorTotal"].Value.ToString();

                panelDetalle.Visible = true;
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteFacturacion : dgvInforme_RowEnter";
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

            var v = sb.SeleccionarLogTransacciones(null, fechaConsultaI, fechaConsultaF, txbDocumento.Text, txbUsuario.Text, null);


            Func<string, string> GetCodigo = (x) =>
            {
                string codofi = _Base.OficinasAll.FirstOrDefault(y => y.IdOficina == x).Codigo ?? "";
                codofi = codofi.Substring(0, codofi.IndexOf('-'));
                return codofi;
            };

            var res = v.Select(x => new
            {
                //Oficina = x.OficinaField,
                Oficina = GetCodigo(x.OficinaField),

                Producto = x.Producto,
                Descripción = _Base.ProductosAll.FirstOrDefault(p => p.Codigo == x.Producto).Descripcion,
                Aprobados = x.AprobadosField,
                No_aprobados = x.NoAprobadosField,
                Valor_unitario = "$ " + (x.ValorUnitarioField).ToString(),
                ValorTotal = "$ " + ((x.AprobadosField + x.NoAprobadosField) * x.ValorUnitarioField).ToString(),
                FechaInicial = fechaConsultaI,
                FechaFinal = fechaConsultaF
            }).ToList();

            dgvInforme.DataSource = res;

            lblCantidadRegistros.Text = "N° registros: " + dgvInforme.RowCount.ToString();

            if (dgvInforme.RowCount == 0)
                BtnExportar.Enabled = false;
            else
                BtnExportar.Enabled = true;

            dgvInforme.Columns["Aprobados"].HeaderText = "Aprobados";
            dgvInforme.Columns["Aprobados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInforme.Columns["No_aprobados"].HeaderText = "No Aprobados";
            dgvInforme.Columns["No_aprobados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInforme.Columns["Valor_unitario"].HeaderText = "Valor Unitario";
            dgvInforme.Columns["Valor_unitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInforme.Columns["ValorTotal"].HeaderText = "Valor Total";
            dgvInforme.Columns["ValorTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInforme.Columns["FechaInicial"].HeaderText = "Fecha Incial";
            dgvInforme.Columns["FechaInicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInforme.Columns["FechaFinal"].HeaderText = "Fecha Final";
            dgvInforme.Columns["FechaFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvInforme.Columns["Descripción"].Visible = false;



        }
    }
}

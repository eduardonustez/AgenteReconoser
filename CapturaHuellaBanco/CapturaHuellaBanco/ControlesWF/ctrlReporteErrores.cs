using System;
using System.Windows.Forms;
using Entidades;
using Utilidades;
using System.Collections.Generic;

namespace CapturaHuellaBanco.ControlesWF
{
    public partial class ctrlReporteErrores : UserControl
    {

        frmBase _Base;


        static LogErrores error = null;

        List<LogErrores> Data = new List<LogErrores>();

        Banco.ServicioBanco sb = new Banco.ServicioBanco();

        private void ctrlReporteErrores_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "REPORTE DE ERRORES";
                _Base.MostrarIconoDashboard();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteErrores : ctrlReporteErrores_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        public ctrlReporteErrores()
        {
            try
            {

                InitializeComponent();
                dtpFechaIngreso.Value = DateTime.Now;
                dtpFechaFinal.Value = DateTime.Now;

                dgvReporteErrores.ReadOnly = true;
                dgvReporteErrores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



                string fechaInicio = dtpFechaIngreso.Value.Date.ToString("yyyy/MM/dd");
                fechaInicio = fechaInicio + " 00:00:00.000";

                string fechaFin = dtpFechaFinal.Value.Date.ToString("yyyy/MM/dd");
                fechaFin = fechaFin + " 23:59:59.999";

                string usuario = txtUsuario.Text;

                Data = sb.ObtenerLogErrores(fechaInicio, fechaFin, usuario);
                dgvReporteErrores.DataSource = Data;

                dgvReporteErrores.Columns["Metodo"].Visible = false;
                dgvReporteErrores.Columns["Mac"].Visible = false;
                dgvReporteErrores.Columns["Ip"].Visible = false;

                lblCantidadRegistros.Text = "N° registros: " + dgvReporteErrores.RowCount.ToString();

                if (dgvReporteErrores.RowCount == 0)
                    BtnExportar.Enabled = false;
                else
                    BtnExportar.Enabled = true;
            }
            catch (Exception ex)
            {
                error.UsuarioLogin = "";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteErrores : ctrlReporteErrores";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void BtnBuscar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (dtpFechaIngreso.Text != null && dtpFechaFinal.Text != null)
                {
                    string fechaInicio = dtpFechaIngreso.Value.Date.ToString("yyyy/MM/dd");
                    fechaInicio = fechaInicio + " 00:00:00.000";

                    string fechaFin = dtpFechaFinal.Value.Date.ToString("yyyy/MM/dd");
                    fechaFin = fechaFin + " 23:59:59.999";
                    string usuario = txtUsuario.Text;

                    DateTime ini = Convert.ToDateTime(fechaInicio);
                    DateTime fn = Convert.ToDateTime(fechaFin);

                    if (ini > fn)
                    {
                        dtpFechaIngreso.Value = dtpFechaFinal.Value;
                        MessageBox.Show("La fecha de inicio no debe ser mayor a la fecha final", "Rango de fechas incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        Data.Clear();
                        Data = sb.ObtenerLogErrores(fechaInicio, fechaFin, usuario);
                        dgvReporteErrores.DataSource = Data;
                        lblCantidadRegistros.Text = "N° registros: " + dgvReporteErrores.RowCount.ToString();

                        if (dgvReporteErrores.RowCount == 0)
                            BtnExportar.Enabled = false;
                        else
                            BtnExportar.Enabled = true;
                    }


                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteErrores : btnEnviar_Click";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }

        private void BtnExportar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                frmBase _Base = (frmBase)this.ParentForm;
                _Base.ExportarExcel(dgvReporteErrores);
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteErrores : BtnExportar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }

        private void BtnLimpiar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                txtUsuario.Text = null;
                dtpFechaIngreso.Value = DateTime.Now;
                dtpFechaFinal.Value = dtpFechaIngreso.Value;



                string fechaInicio = dtpFechaIngreso.Value.Date.ToString("yyyy/MM/dd");
                fechaInicio = fechaInicio + " 00:00:00.000";

                string fechaFin = dtpFechaFinal.Value.Date.ToString("yyyy/MM/dd");
                fechaFin = fechaFin + " 23:59:59.999";

                string usuario = txtUsuario.Text;

                Data = sb.ObtenerLogErrores(fechaInicio, fechaFin, usuario);
                dgvReporteErrores.DataSource = Data;

                lblCantidadRegistros.Text = "N° registros: " + dgvReporteErrores.RowCount.ToString();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteErrores : BtnLimpiar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }

        }

        private void dgvReporteErrores_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow row = dgv.Rows[e.RowIndex];


                LblUsuario.Text = row.Cells["UsuarioLogin"].Value.ToString();
                LblCapa.Text = row.Cells["Capa"].Value.ToString();
                LblDesc.Text = row.Cells["Descripcion"].Value.ToString();
                LblFechaInc.Text = row.Cells["Fecha"].Value.ToString();
                LblOficina.Text = (string)row.Cells["IdOficina"].Value;



                // GrvDetalle.DataSource = detalle;
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteErrores : dgvReporteErrores_RowEnter";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }
    }
}

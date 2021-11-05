using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Utilidades;
using System.Linq;


namespace CapturaHuellaBanco.ControlesWF
{
    public partial class ctrlReporteIngresos : UserControl
    {
        frmBase _Base;

        static LogErrores error = null;
        Bitmap bmp = new Bitmap(1, 1);
        List<NewLogIngresos> Data = new List<NewLogIngresos>();

        Banco.ServicioBanco sb = new Banco.ServicioBanco();

        private void ctrlReporteIngresos_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "REPORTE DE ACCESOS AL SISTEMA";
                _Base.MostrarIconoDashboard();

                ObtenerData();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteIngresos : ctrlReporteIngresos_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        public ctrlReporteIngresos()
        {
            try
            {
                InitializeComponent();
                cmbEstado.SelectedIndex = 0;
                dtpFechaIngreso.Value = DateTime.Now;
                dtpFechaFinal.Value = DateTime.Now;
                dgvReporteIngresos.ReadOnly = true;
                dgvReporteIngresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //ObtenerData();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteIngresos : ctrlReporteIngresos";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void BtnBuscar_EventoClick(object sender, EventArgs e)
        {
            ObtenerData();
        }

        private void BtnExportar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = Utilidades.CopyDataGridView.CopyDGV(dgvReporteIngresos);
                if (dgv.Rows.Count > 0)
                {
                    dgv.Columns.Remove("FechaFin");
                    //dgv.Columns.Remove("IdSucursal");
                    //dgv.Columns.Remove("NombreSucursal");
                    dgv.Columns.Remove("Exitoso2");
                    //x.IdOficina
                    frmBase _Base = (frmBase)this.ParentForm;
                    _Base.ExportarExcel(dgv);
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteIngresos : BtnExportar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void BtnLimpiar_EventoClick(object sender, EventArgs e)
        {

            txtUsuario.Text = null;
            txtIp.Text = null;
            dtpFechaIngreso.Value = DateTime.Now;
            dtpFechaFinal.Value = dtpFechaIngreso.Value;

            //ObtenerData();
        }

        private void dgvReporteIngresos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow row = dgv.Rows[e.RowIndex];


                LblUsuario.Text = row.Cells["UsuarioLogin"].Value.ToString();
                LblFechaIngreso.Text = row.Cells["Fecha"].Value.ToString();                
                LblExitoso.Text = row.Cells["Exitoso2"].Value.ToString();
                LblIp.Text = row.Cells["Ip"].Value.ToString();
                
                //lblCodigo.Text = row.Cells["Código"].Value.ToString();
                //LblOficina.Text = row.Cells["IdOficina"].Value.ToString();

                panelDetalle.Visible = true;
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteIngresos : dgvReporteIngresos_RowEnter";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void ObtenerData()
        {
            try
            {
                bool? estado;

                string fechaInicio = dtpFechaIngreso.Value.Date.ToString("yyyy/MM/dd");
                fechaInicio = fechaInicio + " 00:00:00.000";

                string fechaFin = dtpFechaFinal.Value.Date.ToString("yyyy/MM/dd");
                fechaFin = fechaFin + " 23:59:59.999";

                DateTime ini = Convert.ToDateTime(fechaInicio);
                DateTime fn = Convert.ToDateTime(fechaFin);

                bool b = UtilidadesFecha.EsmayorAB(ini, fn);

                if (b)
                {
                    dtpFechaIngreso.Value = dtpFechaFinal.Value;
                    MessageBox.Show("La fecha de inicio no debe ser mayor a la fecha final", "Rango de fechas incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                bool cantDias = UtilidadesFecha.CantidadDias(dtpFechaIngreso.Value, dtpFechaFinal.Value);

                if (cantDias)
                {
                    dtpFechaIngreso.Value = dtpFechaFinal.Value;
                    MessageBox.Show("La cantidad de días que desea filtrar no es permitida, validé que el rango de días entre fechas no sea mayor a 31 días", "Rango de días incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (cmbEstado.Text == "Exitoso")
                    estado = true;
                else if (cmbEstado.Text == "No Exitoso")
                {
                    estado = false;
                }
                else
                {
                    estado = null;
                }

                Data = sb.ObtenerIngresosAplicacion(fechaInicio, fechaFin, txtUsuario.Text.Trim(), txtIp.Text.Trim(), estado);

                foreach (var item in Data)
                {
                    if (item.Exitoso2 != "SI")
                    {
                        bmp = new Bitmap(CapturaHuellaBanco.Properties.Resources.Recurso_8_1);
                        bmp.Tag = "NO";
                    }
                    else
                    {
                        bmp = new Bitmap(CapturaHuellaBanco.Properties.Resources.Recurso_9);
                        bmp.Tag = "SI";
                    }

                    item.Exitoso = bmp;
                }

                //Func<string, string> GetCodigo = (x) =>
                //{
                //    string codofi = _Base.OficinasAll.FirstOrDefault(y => y.IdOficina == x).Codigo ?? "";
                //    codofi = codofi.Substring(0, codofi.IndexOf('-'));
                //    return codofi;
                //};

                var res = Data.Select(x => new
                {
                    UsuarioLogin = x.UsuarioLogin,
                    IP = x.Ip,
                    MAC = x.Mac,
                    Fecha = x.Fecha,
                    FechaFin = x.FechaFin,
                    //IdOficina = x.IdOficina,
                    //Código = GetCodigo(x.IdOficina),
                    Exitoso = x.Exitoso,
                    Exitoso2 = x.Exitoso2
                    //,IdSucursal = x.IdSucursal,
                    //NombreSucursal = x.NombreSucursal
                }).ToList();

                dgvReporteIngresos.DataSource = res;

                lblCantidadRegistros.Text = "N° registros: " + dgvReporteIngresos.RowCount.ToString();

                if (dgvReporteIngresos.RowCount == 0)
                    BtnExportar.Enabled = false;
                else
                    BtnExportar.Enabled = true;


                dgvReporteIngresos.Columns["FechaFin"].Visible = false;
                //dgvReporteIngresos.Columns["Mac"].Visible = false;
                //dgvReporteIngresos.Columns["IdSucursal"].Visible = false;
                //dgvReporteIngresos.Columns["NombreSucursal"].Visible = false;
                dgvReporteIngresos.Columns["Exitoso2"].Visible = false;
                //dgvReporteIngresos.Columns["IdOficina"].Visible = false;
                //dgvReporteIngresos.Columns["IdOficina"].HeaderText = "Oficina";
                //dgvReporteIngresos.Columns["Código"].Visible = false;
                //dgvReporteIngresos.Columns["Código"].HeaderText = "Código Oficina";
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteIngresos : BtnBuscar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }
    }
}

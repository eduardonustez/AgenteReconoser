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
using CapturaHuellaBanco.Properties;
using System.IO;

namespace CapturaHuellaBanco.ControlesWF
{
    public partial class ctrlReporteAceptoFormato : UserControl
    {
        frmBase _Base;
        LogErrores error = null;

        private Banco.ServicioBanco sb = new Banco.ServicioBanco();

        public ctrlReporteAceptoFormato()
        {
            try
            {
                InitializeComponent();
                dgvInforme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
            }
        }

        private void ctrlReporteAceptoFormato_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "Reporte de Autorizaciones";
                _Base.MostrarIconoDashboard();

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

            var v = sb.ConsultarAceptaNoAcepta(fechaConsultaI, fechaConsultaF, txbUsuario.Text, txbOficina.Text.Trim(), txbDocumento.Text, _Base.Oficina);

            Bitmap bmpOK = Resources.Recurso_9;
            bmpOK.Tag = "Aceptado";
            Bitmap bmpNO = Resources.Recurso_8_1;
            bmpNO.Tag = "Rechazado";

            Func<string, string> GetCodigo = (x) =>
            {
                string codofi = _Base.OficinasAll.FirstOrDefault(y => y.IdOficina == x).Codigo ?? "";
                codofi = codofi.Substring(0, codofi.IndexOf('-'));
                return codofi;
            };


            var res = v.Select(x => new
            {
                Aceptacion = x.Aceptacion ? bmpOK : bmpNO,
                Usuario = x.Login,
                Sigla = x.Sigla,
                NumeroDocumento = x.NumeroDocumento,
                CodProducto = x.Producto,
                FechaIngreso = x.FechaIngreso,
                //Oficina = x.IdOficina,
                Oficina = GetCodigo(x.IdOficina),
                IpTerminal = x.IpTerminal,
                Descarga = "Descargar",
                DocumentoAutorizacion = x.DocumentoAutorizacion
            }).ToList();

            dgvInforme.DataSource = res;

            lblCantidadRegistros.Text = "N° registros: " + dgvInforme.RowCount.ToString();

            if (dgvInforme.RowCount == 0)
                BtnExportar.Enabled = false;
            else
                BtnExportar.Enabled = true;


            //dgvInforme.Columns["DocumentoAutorizacion"].Visible = false;

            dgvInforme.Columns["NumeroDocumento"].HeaderText = "Documento";
            dgvInforme.Columns["FechaIngreso"].HeaderText = "Fecha Ingreso";
            //dgvInforme.Columns["IdOficina"].HeaderText = "Oficina";
            dgvInforme.Columns["IpTerminal"].HeaderText = "Terminal";
            dgvInforme.Columns["Sigla"].HeaderText = "Tipo Documento";
            dgvInforme.Columns["DocumentoAutorizacion"].Visible = false;
            //dgvInforme.Columns["Descarga"].HeaderText = "";
            //dgvInforme.Columns["Descarga"].DefaultHeaderCellType = 
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
                frmBase _Base = (frmBase)this.ParentForm;
                _Base.ExportarExcel(dgvInforme);
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
            txbOficina.Text = string.Empty;

            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = dtpFechaInicio.Value;

            DateTime fechaConsultaI = new DateTime(dtpFechaInicio.Value.Year, dtpFechaInicio.Value.Month, dtpFechaInicio.Value.Day, 0, 0, 0);
            DateTime fechaConsultaF = new DateTime(dtpFechaFin.Value.Year, dtpFechaFin.Value.Month, dtpFechaFin.Value.Day, 23, 59, 59);

            //dgvInforme.DataSource = null;

            //lblCantidadRegistros.Text = "N° registros: 0";

            //BtnExportar.Enabled = false;
        }

        private void dgvInforme_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                System.Diagnostics.Trace.WriteLine("DFZ750");

                var gv = (DataGridView)sender;
                var val = gv.Rows[e.RowIndex].Cells[e.ColumnIndex];


                System.Diagnostics.Trace.WriteLine("DFZ752");

                if (val.Value.ToString() == "Descargar")
                {
                    System.Diagnostics.Trace.WriteLine("DFZ754");

                    var doc = (string)gv.Rows[e.RowIndex].Cells["NumeroDocumento"].Value;
                    var fechaIng = (DateTime)gv.Rows[e.RowIndex].Cells["FechaIngreso"].Value;
                    var res = sb.ConsultarAceptaNoAcepta(fechaIng.AddSeconds(-1), fechaIng.AddSeconds(+1), "", "", doc, _Base.Oficina).ToList();
                    byte[] b = res[0].DocumentoAutorizacion;

                    System.Diagnostics.Trace.WriteLine("DFZ756");

                    //byte[] b = (byte[])gv.Rows[e.RowIndex].Cells["DocumentoAutorizacion"].Value;

                    if (b == null)
                    {
                        MessageBox.Show("No existe formato de autorización para este registro", "Formato inexistente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    System.Diagnostics.Trace.WriteLine("DFZ758");

                    SaveFileDialog sfd = new SaveFileDialog();

                    sfd.Filter = "PDF files (*.pdf)|*.pdf";
                    sfd.RestoreDirectory = true;

                    System.Diagnostics.Trace.WriteLine("DFZ760");


                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        System.Diagnostics.Trace.WriteLine("DFZ762");

                        File.WriteAllBytes(sfd.FileName, b);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fué posible encontrar el formato de aceptación para este registro", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

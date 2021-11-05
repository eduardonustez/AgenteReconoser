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
using Entidades.Parametrizacion;

namespace CapturaHuellaBanco.ControlesParametrizacion
{
    public partial class ctrlParametros : UserControl
    {
        static LogErrores error = null;
        public List<Parametros> parametro = new List<Parametros>();
        private frmBase _Base;
        private int idParametro = 0;

        private bool incluirNoHab = true;
        private Banco.ServicioParametrizacion Sp = new Banco.ServicioParametrizacion();
        Banco.ServicioBanco sb = new Banco.ServicioBanco();

        public ctrlParametros()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            RespuestaListas<Parametros> Rl = Sp.ConsultarTodosParametros(incluirNoHab);
            if (Rl.Estado == Estado.Ok)
            {
                parametro = Rl.Lista;
                dgvParametro.DataSource = parametro;
            }
            else
            {
                MessageBox.Show(/*Rl.CodigoError + ": " +*/ Rl.DescripcionError, "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlParametros_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "PARÁMETROS";
                _Base.ActivarPaneles(true);
                //_Base.CargarBotonNumerico("1", true);
                //_Base.MostrarIconoDashboard("Parametrización");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Parámetro";
                error.Metodo = "ctrlParametro : ctrlParametros_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void dgvParametro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    int columnIndex = e.ColumnIndex;
                    DataGridView dgv = (DataGridView)sender;
                    DataGridViewRow row = dgv.Rows[e.RowIndex];

                    if (columnIndex == 0)
                    {
                        if (row.Cells["Parametros"].Value.ToString().ToLower() == "convenio" || row.Cells["Parametros"].Value.ToString().ToLower() == "cliente")
                        {
                            MessageBox.Show("El parámetro no es editable", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtParametroEdicon.Text = null;
                            txtValorEdicion.Text = null;
                            return;
                        }
                        gbEdicion.Visible = true;
                        gbEdicion.Focus();
                        txtParametroEdicon.Text = (string)row.Cells["Parametros"].Value;
                        txtValorEdicion.Text = (string)row.Cells["Valor"].Value;
                        idParametro = (int)row.Cells["IdParametros"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Parámetro";
                error.Metodo = "ctrlParametro : dgvParametro_CellContentClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnActualizar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtValorEdicion.Text))
                {
                    MessageBox.Show("Debe ingresar todos los campos del formulario", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Parametros _parametros = new Parametros()
                    {
                        IdParametro = idParametro,
                        Parametro = txtParametroEdicon.Text,
                        Valor = txtValorEdicion.Text,
                        UsuarioModificacion = _Base.Usuario
                    };
                    long Result = Sp.ActualizarParametro(_parametros);
                    if (Result > 0)
                    {
                        txtParametroEdicon.Text = null;
                        txtValorEdicion.Text = null;
                        CargarDatos();
                        MessageBox.Show("Registro actualizado con éxito", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sucedio un error al actualizar el registro", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Parámetro";
                error.Metodo = "ctrlParametro : btnActualizar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnCancelar_EventoClick(object sender, EventArgs e)
        {
            txtParametroEdicon.Text = null;
            txtValorEdicion.Text = null;
        }

        private void BtnExportar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = Utilidades.CopyDataGridView.CopyDGV(dgvParametro);
                if (dgv.Rows.Count > 0)
                {
                    dgv.Columns.Remove("Editar");
                    dgv.Columns.Remove("IdParametros");
                    frmBase _Base = (frmBase)this.ParentForm;
                    _Base.ExportarExcel(dgv);
                }
                else
                {
                    MessageBox.Show("No existen registros para exportar", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Zona";
                error.Metodo = "ctrlZona : BtnExportar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }
    }
}

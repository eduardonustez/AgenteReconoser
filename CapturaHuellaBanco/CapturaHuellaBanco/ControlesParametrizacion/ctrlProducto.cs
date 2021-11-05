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
using Entidades.Parametrizacion;

namespace CapturaHuellaBanco.ControlesParametrizacion
{
    public partial class ctrlProducto : UserControl
    {
        static LogErrores error = null;
        public List<Producto> producto = new List<Producto>();
        private frmBase _Base;
        private int idProducto = 0;

        private bool incluirNoHab = true;
        private Banco.ServicioParametrizacion Sp = new Banco.ServicioParametrizacion();
        Banco.ServicioBanco sb = new Banco.ServicioBanco();

        public ctrlProducto()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            RespuestaListas<Producto> Rl = Sp.ConsultarTodosProductos(incluirNoHab);
            if (Rl.Estado == Estado.Ok)
            {
                producto = Rl.Lista;
                dgvProducto.DataSource = producto;
            }
            else
            {
                MessageBox.Show(/*Rl.CodigoError + ": " +*/ Rl.DescripcionError, "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlProducto_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "PRODUCTOS";
                _Base.ActivarPaneles(true);
                //_Base.CargarBotonNumerico("1", true);
                //_Base.MostrarIconoDashboard("Parametrización");

                gbCreacion.Visible = true;
                gbEdicion.Visible = false;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Productos";
                error.Metodo = "ctrlProducto : ctrlProducto_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void dgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                        gbCreacion.Visible = false;
                        gbEdicion.Visible = true;
                        gbEdicion.Focus();
                        txtCodigoEdicion.Text = (string)row.Cells["Codigo"].Value;
                        chbHabilitadoEdicion.Checked = (bool)row.Cells["Habilitado"].Value;
                        idProducto = (int)row.Cells["ProductoId"].Value;
                        txtDescripcionEdicion.Text = (string)row.Cells["Descripcion"].Value;
                    }

                    if (columnIndex == 6)
                    {
                        Sp.CambiarEstadoProducto((int)row.Cells["ProductoId"].Value);
                        CargarDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Productos";
                error.Metodo = "ctrlProducto : dgvProducto_CellContentClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void BtnBuscar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProductoBusqueda.Text))
                {
                    MessageBox.Show("Debe ingresar un filtro de búsqueda", "Filtro de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvProducto.DataSource = (from p in producto
                                              where p.Codigo.ToLower().Contains(txtProductoBusqueda.Text.ToLower())
                                              select new { p.IdProducto, p.IdServicio, p.Servicio, p.Codigo, p.Descripcion, p.Habilitado }).ToList();
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Productos";
                error.Metodo = "ctrlProducto : BtnBuscar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnLimpiar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                txtProductoBusqueda.Text = null;
                CargarDatos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Productos";
                error.Metodo = "ctrlProducto : btnLimpiar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnGuardar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    MessageBox.Show("Debe ingresar todos los campos del formulario", "Creación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Producto _producto = new Producto()
                    {
                        IdProducto = 0,
                        IdServicio = 1,
                        Servicio = "GEN",
                        Codigo = txtCodigo.Text,
                        Descripcion = txtDescripcion.Text,
                        Habilitado = chbHabilitado.Checked
                    };
                    long Result = Sp.CrearActualizarProducto(_producto);
                    if (Result > 0)
                    {
                        txtCodigo.Text = null;
                        txtDescripcion.Text = null;
                        chbHabilitado.Checked = false;
                        gbCreacion.Visible = true;
                        gbEdicion.Visible = false;
                        CargarDatos();
                        MessageBox.Show("Registro creado con éxito", "Creación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sucedio un error al crear el registro", "Creación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Productos";
                error.Metodo = "ctrlProducto : btnGuardar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnActualizar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigoEdicion.Text) || string.IsNullOrEmpty(txtDescripcionEdicion.Text))
                {
                    MessageBox.Show("Debe ingresar todos los campos del formulario", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Producto _producto = new Producto()
                    {
                        IdProducto = idProducto,
                        IdServicio = 1,
                        Servicio = "GEN",
                        Codigo = txtCodigoEdicion.Text,
                        Descripcion = txtDescripcionEdicion.Text,
                        Habilitado = chbHabilitado.Checked
                    };
                    long Result = Sp.CrearActualizarProducto(_producto);
                    if (Result > 0)
                    {
                        txtCodigoEdicion.Text = null;
                        txtDescripcionEdicion.Text = null;
                        chbHabilitadoEdicion.Checked = false;
                        gbCreacion.Visible = true;
                        gbEdicion.Visible = false;
                        CargarDatos();
                        MessageBox.Show("Registro actualizado con éxito", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sucedio un error al actualizar el registro", "Creación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Productos";
                error.Metodo = "ctrlProducto : btnActualizar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void gbCreacion_Leave(object sender, EventArgs e)
        {
            txtCodigo.Text = null;
            txtDescripcion.Text = null;
            chbHabilitado.Checked = false;
            gbCreacion.Visible = true;
            gbEdicion.Visible = false;
        }

        private void gbEdicion_Leave(object sender, EventArgs e)
        {
            txtCodigoEdicion.Text = null;
            txtDescripcionEdicion.Text = null;
            chbHabilitado.Checked = false;
            gbCreacion.Visible = true;
            gbEdicion.Visible = false;
        }

        private void btnCancelar_EventoClick(object sender, EventArgs e)
        {
            txtCodigoEdicion.Text = null;
            txtDescripcionEdicion.Text = null;
            chbHabilitado.Checked = false;
            gbCreacion.Visible = true;
            gbEdicion.Visible = false;
        }

        private void btnImportarExcel_EventoClick(object sender, EventArgs e)
        {
            using (ctrlImportarExcel control = new ctrlImportarExcel())
            {
                control.Parametro = this.Name;
                control.Base = _Base;
                _Base.PopUp(control);
                _Base.CargarControl(new ctrlProducto());
            }
            CargarDatos();
        }

        private void BtnExportar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = Utilidades.CopyDataGridView.CopyDGV(dgvProducto);
                if (dgv.Rows.Count > 0)
                {
                    dgv.Columns.Remove("Editar");
                    dgv.Columns.Remove("ProductoId");
                    dgv.Columns.Remove("IdServicio");
                    dgv.Columns.Remove("Servicio");
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


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
    public partial class ctrlRol : UserControl
    {
        static LogErrores error = null;
        public List<Rol> rol = new List<Rol>();
        private frmBase _Base;
        private int IdRol = 0;

        private bool incluirNoHab = true;
        private Banco.ServicioParametrizacion Sp = new Banco.ServicioParametrizacion();
        Banco.ServicioBanco sb = new Banco.ServicioBanco();

        public ctrlRol()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            RespuestaListas<Rol> Rl = Sp.ConsultarTodosRoles(incluirNoHab);
            if (Rl.Estado == Estado.Ok)
            {
                rol = Rl.Lista;
                dgvRol.DataSource = rol;
            }
            else
            {
                MessageBox.Show(/*Rl.CodigoError + ": " +*/ Rl.DescripcionError, "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlRol_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "ROLES";
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
                error.Capa = "Roles";
                error.Metodo = "ctrlRol : ctrlRol_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void dgvOficina_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                        txtDescripcionEdicion.Text = (string)row.Cells["Descripcion"].Value;
                        chbHabilitadoEdicion.Checked = (bool)row.Cells["Habilitado"].Value;
                        IdRol = (int)row.Cells["Id"].Value;
                    }

                    if (columnIndex == 4)
                    {
                        Sp.CambiarEstadoRol((int)row.Cells["Id"].Value);
                        CargarDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Roles";
                error.Metodo = "ctrlRol : dgvOficina_CellContentClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void BtnBuscar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigoBusqueda.Text))
                {
                    MessageBox.Show("Debe ingresar un filtro de búsqueda", "Filtro de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvRol.DataSource = (from r in rol
                                         where r.Codigo.ToLower().Contains(txtCodigoBusqueda.Text.ToLower())
                                         select new { r.IdRol, r.Codigo, r.Descripcion, r.Habilitado }).ToList();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Roles";
                error.Metodo = "ctrlRol : BtnBuscar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnLimpiar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                txtCodigoBusqueda.Text = null;
                CargarDatos();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Roles";
                error.Metodo = "ctrlRol : btnLimpiar_EventoClick";
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
                    Rol _rol = new Rol()
                    {
                        IdRol = 0,
                        Codigo = txtCodigo.Text,
                        Descripcion = txtDescripcion.Text,
                        Habilitado = chbHabilitado.Checked
                    };
                    long Result = Sp.CrearActualizarRol(_rol);
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
                error.Capa = "Roles";
                error.Metodo = "ctrlRol : btnGuardar_EventoClick";
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
                    Rol _rol = new Rol()
                    {
                        IdRol = IdRol,
                        Codigo = txtCodigoEdicion.Text,
                        Descripcion = txtDescripcionEdicion.Text,
                        Habilitado = chbHabilitadoEdicion.Checked
                    };
                    long Result = Sp.CrearActualizarRol(_rol);
                    if (Result > 0)
                    {
                        txtCodigoEdicion.Text = null;
                        txtDescripcionEdicion.Text = null;
                        chbHabilitadoEdicion.Checked = false;
                        gbCreacion.Visible = true;
                        gbCreacion.Visible = true;
                        gbEdicion.Visible = false;
                        IdRol = 0;
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
                error.Capa = "Roles";
                error.Metodo = "ctrlRol : btnActualizar_EventoClick";
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
            chbHabilitadoEdicion.Checked = false;
            gbCreacion.Visible = true;
            gbEdicion.Visible = false;
        }

        private void btnCancelar_EventoClick(object sender, EventArgs e)
        {
            txtCodigoEdicion.Text = null;
            txtDescripcionEdicion.Text = null;
            chbHabilitadoEdicion.Checked = false;
            gbCreacion.Visible = true;
            gbEdicion.Visible = false;
        }

        private void BtnExportar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = Utilidades.CopyDataGridView.CopyDGV(dgvRol);
                if (dgv.Rows.Count > 0)
                {
                    dgv.Columns.Remove("Editar"); 
                    dgv.Columns.Remove("Id");
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


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilidades;
using Entidades.Parametrizacion;
using Entidades;

namespace CapturaHuellaBanco.ControlesParametrizacion
{
    public partial class ctrlServicio : UserControl
    {
        static LogErrores error = null;
        public List<Entidades.Parametrizacion.Servicio> servicio = new List<Entidades.Parametrizacion.Servicio>();
        private frmBase _Base;
        Banco.ServicioBanco sb = new Banco.ServicioBanco();

        public ctrlServicio()
        {
            InitializeComponent();
            /* para borrar */
            dgvServicio.DataSource = CargarDatos();
        }

        private List<Entidades.Parametrizacion.Servicio> CargarDatos()
        {
            /* para borrar */
            servicio.Clear();
            Entidades.Parametrizacion.Servicio _servicio = new Entidades.Parametrizacion.Servicio();
            _servicio.IdServicio = 1;
            _servicio.Codigo = "RRHH";
            _servicio.Descripcion = "Registro de prueba";
            _servicio.Habilitado = true;
            servicio.Add(_servicio);

            Entidades.Parametrizacion.Servicio _rol2 = new Entidades.Parametrizacion.Servicio();
            _rol2.IdServicio = 2;
            _rol2.Codigo = "IT";
            _rol2.Descripcion = "Registro de prueba2";
            _rol2.Habilitado = false;
            servicio.Add(_rol2);

            return servicio;
        }

        private void ctrlServicio_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "SERVICIOS";
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
                error.Capa = "Servicio";
                error.Metodo = "ctrlServicio : ctrlServicio_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void dgvServicio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Servicio";
                error.Metodo = "ctrlServicio : dgvServicio_CellContentClick";
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
                    MessageBox.Show("Debe ingresar un filtro de busqueda", "Filtro de Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvServicio.DataSource = servicio.Where(p => p.Codigo.Contains(txtCodigoBusqueda.Text));
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Servicio";
                error.Metodo = "ctrlServicio : BtnBuscar_EventoClick";
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
                dgvServicio.DataSource = CargarDatos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Servicio";
                error.Metodo = "ctrlServicio : btnLimpiar_EventoClick";
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
                    MessageBox.Show("Debe ingresar todos los campos del formulario", "Crearción", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    txtCodigo.Text = null;
                    txtDescripcion.Text = null;
                    chbHabilitado.Checked = false;
                    gbCreacion.Visible = true;
                    gbEdicion.Visible = false;
                    dgvServicio.DataSource = CargarDatos();
                    MessageBox.Show("Registro creado con exito", "Crearción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Servicio";
                error.Metodo = "ctrlServicio : btnGuardar_EventoClick";
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
                    txtCodigoEdicion.Text = null;
                    txtDescripcionEdicion.Text = null;
                    chbHabilitadoEdicion.Checked = false;
                    gbCreacion.Visible = true;
                    gbEdicion.Visible = false;
                    dgvServicio.DataSource = CargarDatos();
                    MessageBox.Show("Registro actualizado con exito", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Servicio";
                error.Metodo = "ctrlServicio : btnActualizar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void gbCreacion_Leave(object sender, EventArgs e)
        {
            txtCodigo.Text = null;
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

        private void btnCancelar_Load(object sender, EventArgs e)
        {
            txtCodigoEdicion.Text = null;
            txtDescripcionEdicion.Text = null;
            chbHabilitadoEdicion.Checked = false;
            gbCreacion.Visible = true;
            gbEdicion.Visible = false;
        }
    }
}


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
    public partial class ctrlOficina : UserControl
    {
        static LogErrores error = null;
        public List<Oficina> oficina = new List<Oficina>();
        public List<Zona> zona = new List<Zona>();
        private frmBase _Base;

        private bool incluirNoHab = true;
        private Banco.ServicioParametrizacion Sp = new Banco.ServicioParametrizacion();
        Banco.ServicioBanco sb = new Banco.ServicioBanco();

        public ctrlOficina()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            RespuestaListas<Oficina> Rl = Sp.ConsultarTodosOficinas(incluirNoHab);
            if (Rl.Estado == Estado.Ok)
            {
                oficina = Rl.Lista;
                dgvOficina.DataSource = oficina;
            }
            else
            {
                MessageBox.Show(/*Rl.CodigoError + ": " +*/ Rl.DescripcionError, "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarComboZona(cbxZonaBusqueda);
            CargarComboZona(cbxZona);
            CargarComboZona(cbxZonaEdicion);
        }

        private void ctrlOficina_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "OFICINAS";
                _Base.ActivarPaneles(true);
                //_Base.CargarBotonNumerico("1", true);
                //_Base.MostrarIconoDashboard("Parametrización");

                gbCreacion.Visible = true;
                gbEdicion.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //error = new LogErrores();
                //error.UsuarioLogin = _Base.Usuario;
                //error.Capa = "Oficina";
                //error.Metodo = "ctrlOficina : ctrlOficina_Load";
                //error.Fecha = DateTime.Now;
                //error.Descripcion = ex.Message;
                //registro.InsertarLogError(error);
            }
        }

        private void CargarComboZona(ComboBox combo)
        {
            Zona _item = new Zona()
            {
                IdZona = "Selecccione",
                Descripcion = "Selecccione"
            };

            RespuestaListas<Zona> Rl = Sp.ConsultarTodosZonas(incluirNoHab);
            if (Rl.Estado == Estado.Ok)
            {
                zona = Rl.Lista;
            }
            else
            {
                MessageBox.Show(/*Rl.CodigoError + ": " +*/ Rl.DescripcionError, "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            zona.Add(_item);

            combo.DataSource = null;
            combo.DataSource = zona;
            combo.DisplayMember = "IdZona";
            combo.ValueMember = "IdZona";
            combo.SelectedValue = "Selecccione";
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
                        txtOficinaEdicion.Text = (string)row.Cells["IdOficina"].Value;
                        cbxZonaEdicion.SelectedValue = (string)row.Cells["IdZona"].Value;
                        txtCodigoEdicion.Text = (string)row.Cells["Codigo"].Value;
                        txtDireccionEdicion.Text = (string)row.Cells["Direccion"].Value;
                        txtCiudadEdicion.Text = (string)row.Cells["Ciudad"].Value;
                        chbHabilitadoEdicion.Checked = (bool)row.Cells["Habilitado"].Value;
                    }

                    if (columnIndex == 6)
                    {
                        Sp.CambiarEstadoOficina((string)row.Cells["IdOficina"].Value);
                        CargarDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Oficina";
                error.Metodo = "ctrlOficina : dgvOficina_CellContentClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void BtnBuscar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtOficinaBusqueda.Text) && cbxZonaBusqueda.SelectedValue.ToString() == "Selecccione")
                {
                    MessageBox.Show("Debe ingresar un filtro de búsqueda", "Filtro de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var Result = oficina;
                    if (!string.IsNullOrEmpty(txtOficinaBusqueda.Text))
                    {
                        Result = Result.Where(r => r.IdOficina.ToLower().Contains(txtOficinaBusqueda.Text.ToLower())).ToList();
                    }

                    if (cbxZonaBusqueda.SelectedValue.ToString() != "Selecccione")
                    {
                        Result = Result.Where(r => r.IdZona.ToLower().Equals(cbxZonaBusqueda.SelectedValue.ToString().ToLower(), StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    dgvOficina.DataSource = Result;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Oficina";
                error.Metodo = "ctrlOficina : BtnBuscar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnLimpiar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                txtOficinaBusqueda.Text = null;
                CargarDatos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Oficina";
                error.Metodo = "ctrlOficina : btnLimpiar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnGuardar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtOficina.Text) || string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtCiudad.Text) || cbxZona.SelectedValue == "Selecccione")
                {
                    MessageBox.Show("Debe ingresar todos los campos del formulario", "Creación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Oficina _oficina = new Oficina()
                    {
                        IdZona = cbxZona.SelectedValue.ToString(),
                        IdOficina = txtOficina.Text,
                        Codigo = txtCodigo.Text,
                        Direccion = txtDireccion.Text,
                        Ciudad = txtCiudad.Text,
                        Habilitado = chbHabilitado.Checked
                    };
                    long Result = Sp.CrearActualizarOficina(_oficina);
                    if (Result == 1)
                    {
                        cbxZona.SelectedValue = "Seleccione";
                        txtOficina.Text = null;
                        txtCodigo.Text = null;
                        txtDireccion.Text = null;
                        txtCiudad.Text = null;
                        chbHabilitado.Checked = false;
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
                error.Capa = "Oficina";
                error.Metodo = "ctrlOficina : btnGuardar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnActualizar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtOficinaEdicion.Text) || string.IsNullOrEmpty(txtDireccionEdicion.Text) || string.IsNullOrEmpty(txtCodigoEdicion.Text) || string.IsNullOrEmpty(txtCiudadEdicion.Text) || cbxZonaEdicion.SelectedValue == "Selecccione")
                {
                    MessageBox.Show("Debe ingresar todos los campos del formulario", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Oficina _oficina = new Oficina()
                   {
                       IdZona = cbxZonaEdicion.SelectedValue.ToString(),
                       IdOficina = txtOficinaEdicion.Text,
                       Codigo = txtCodigoEdicion.Text,
                       Direccion = txtDireccionEdicion.Text,
                       Ciudad = txtCiudadEdicion.Text,
                       Habilitado = chbHabilitadoEdicion.Checked
                   };
                    long Result = Sp.CrearActualizarOficina(_oficina);
                    if (Result == 1)
                    {
                        txtOficinaEdicion.Text = null;
                        cbxZonaEdicion.SelectedValue = "Seleccione";
                        txtCodigoEdicion.Text = null;
                        txtDireccionEdicion.Text = null;
                        txtCiudadEdicion.Text = null;
                        chbHabilitadoEdicion.Checked = false;
                        gbCreacion.Visible = true;
                        gbEdicion.Visible = false;
                        CargarDatos();
                        MessageBox.Show("Registro actualizado con éxito", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sucedio un error al actializar el registro", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Oficina";
                error.Metodo = "ctrlOficina : btnActualizar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void gbCreacion_Leave(object sender, EventArgs e)
        {
            txtOficina.Text = null;
            cbxZona.SelectedValue = "Selecccione";
            txtDireccion.Text = null;
            txtCodigo.Text = null;
            txtCiudad.Text = null;
            chbHabilitado.Checked = false;
            gbCreacion.Visible = true;
            gbEdicion.Visible = false;
        }

        private void gbEdicion_Leave(object sender, EventArgs e)
        {
            txtOficinaEdicion.Text = null;
            cbxZonaEdicion.SelectedValue = "Selecccione";
            txtDireccionEdicion.Text = null;
            txtCodigoEdicion.Text = null;
            txtCiudadEdicion.Text = null;
            chbHabilitadoEdicion.Checked = false;
            gbCreacion.Visible = true;
            gbEdicion.Visible = false;
        }

        private void Cancelar_EventoClick(object sender, EventArgs e)
        {
            txtOficinaEdicion.Text = null;
            cbxZonaEdicion.SelectedValue = "Selecccione";
            txtDireccionEdicion.Text = null;
            txtCiudadEdicion.Text = null;
            txtCodigoEdicion.Text = null;
            chbHabilitadoEdicion.Checked = false;
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
                _Base.CargarControl(new ctrlOficina());
            }
            CargarDatos();
        }

        private void BtnExportar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = Utilidades.CopyDataGridView.CopyDGV(dgvOficina);
                if (dgv.Rows.Count > 0)
                {
                    dgv.Columns.Remove("Editar");
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




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
    public partial class ctrlUsuario : UserControl
    {
        static LogErrores error = null;
        public List<Usuario> usuario = new List<Usuario>();
        public List<Oficina> oficina = new List<Oficina>();
        public List<Rol> rol = new List<Rol>();
        private frmBase _Base;

        private bool incluirNoHab = true;
        private Banco.ServicioParametrizacion Sp = new Banco.ServicioParametrizacion();
        Banco.ServicioBanco sb = new Banco.ServicioBanco();

        public ctrlUsuario()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            RespuestaListas<Usuario> Rl = Sp.ConsultarTodosUsuarios(incluirNoHab);
            if (Rl.Estado == Estado.Ok)
            {
                usuario = Rl.Lista;
                dgvUsuario.DataSource = usuario;
            }
            else
            {
                MessageBox.Show(/*Rl.CodigoError + ": " +*/ Rl.DescripcionError, "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarComboRol(cbxRolBusqueda);
            CargarComboRol(cbxRol);
            CargarComboRol(cbxRolEdicion);

            CargarComboOficina(cbxOficinaBusqueda);
            CargarComboOficina(cbxOficina);
            CargarComboOficina(cbxOficinaEdicion);

            CargarComboTipoIdentificacion(cbxTipoIdentificacion);
            CargarComboTipoIdentificacion(cbxTipoIdentificacionEdicion);
        }

        private void CargarComboTipoIdentificacion(ComboBox combo)
        {
            combo.DataSource = null;
            combo.DataSource = Enum.GetValues(typeof(EnumParametrizacion.TipoIdentificacion));
            combo.SelectedItem = EnumParametrizacion.TipoIdentificacion.Seleccione;
        }

        private void CargarComboOficina(ComboBox combo)
        {
            Oficina _item = new Oficina()
            {
                IdOficina = "Selecccione"
            };
            RespuestaListas<Oficina> Rl = Sp.ConsultarTodosOficinas(false);
            if (Rl.Estado == Estado.Ok)
            {
                oficina = Rl.Lista;
            }
            else
            {
                MessageBox.Show(/*Rl.CodigoError + ": " +*/ Rl.DescripcionError, "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            oficina.Add(_item);

            combo.DataSource = null;
            combo.DataSource = oficina;
            combo.DisplayMember = "IdOficina";
            combo.ValueMember = "IdOficina";
            combo.SelectedValue = "Selecccione";
        }

        private void CargarComboRol(ComboBox combo)
        {
            Rol _item = new Rol()
            {
                IdRol = 0,
                Codigo = "Selecccione"
            };
            RespuestaListas<Rol> Rl = Sp.ConsultarTodosRoles(false);
            if (Rl.Estado == Estado.Ok)
            {
                rol = Rl.Lista;
            }
            else
            {
                MessageBox.Show(/*Rl.CodigoError + ": " +*/ Rl.DescripcionError, "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            rol.Add(_item);

            combo.DataSource = null;
            combo.DataSource = rol;
            combo.DisplayMember = "Codigo";
            combo.ValueMember = "IdRol";
            combo.SelectedValue = 0;
        }

        private void ctrlUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "USUARIOS";
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
                error.Capa = "Usuario";
                error.Metodo = "ctrlUsuario : ctrlUsuario_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                        txtLoginEdicion.Text = (string)row.Cells["IdUsuario"].Value;
                        cbxRolEdicion.SelectedValue = (int)row.Cells["IdRol"].Value;
                        txtNombreEdicion.Text = (string)row.Cells["Nombre"].Value;
                        cbxTipoIdentificacionEdicion.Text = (string)row.Cells["IdTipoIdentificacion"].Value;
                        txtNumeroIdentificacionEdicion.Text = (string)row.Cells["NumeroIdentificacion"].Value;
                        cbxOficinaEdicion.Text = (string)row.Cells["IdOficina"].Value;
                        chbHabilitadoEdicion.Checked = (bool)row.Cells["Habilitado"].Value;
                        txtAreaEdicion.Text = (string)row.Cells["Area"].Value;
                        txtCargoEdicion.Text = (string)row.Cells["Cargo"].Value;
                    }
                    
                    if (columnIndex == 18)
                    {
                        Sp.CambiarEstadoUsuario((string)row.Cells["IdUsuario"].Value);
                        CargarDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Usuario";
                error.Metodo = "ctrlUsuario : dgvUsuario_CellContentClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void BtnBuscar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLoginBusqueda.Text) && cbxRolBusqueda.Text == "Seleccione" && string.IsNullOrEmpty(txtNombreBusqueda.Text) && cbxOficinaBusqueda.Text == "Seleccione")
                {
                    MessageBox.Show("Debe ingresar un filtro de búsqueda", "Filtro de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var Result = usuario;
                    if (!string.IsNullOrEmpty(txtLoginBusqueda.Text))
                    {
                        Result = Result.Where(r => r.IdUsuario.ToLower().Contains(txtLoginBusqueda.Text.ToLower())).ToList();
                    }

                    if (cbxRolBusqueda.Text != "Selecccione")
                    {
                        Result = Result.Where(r => r.Rol.Equals(cbxRolBusqueda.Text)).ToList();
                    }

                    if (!string.IsNullOrEmpty(txtNombreBusqueda.Text))
                    {
                        Result = Result.Where(r => r.Nombre.ToLower().Contains(txtNombreBusqueda.Text.ToLower())).ToList();
                    }

                    if (cbxOficinaBusqueda.Text != "Selecccione")
                    {
                        Result = Result.Where(r => r.IdOficina.Equals(cbxOficinaBusqueda.Text)).ToList();
                    }

                    dgvUsuario.DataSource = Result;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Usuario";
                error.Metodo = "ctrlUsuario : BtnBuscar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnLimpiar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                txtLoginBusqueda.Text = null;
                cbxRolBusqueda.SelectedValue = "Seleccione";
                txtNombreBusqueda.Text = null;
                cbxOficinaBusqueda.SelectedValue = "Seleccione";
                CargarDatos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Usuario";
                error.Metodo = "ctrlUsuario : btnLimpiar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnGuardar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtNombre.Text) ||
                    string.IsNullOrEmpty(txtArea.Text) || string.IsNullOrEmpty(txtCargo.Text) ||
                    string.IsNullOrEmpty(txtNumeroIdentificacion.Text) || cbxRol.SelectedValue.ToString() == "0" ||
                    cbxTipoIdentificacion.SelectedValue.ToString() == "Seleccione" || cbxOficina.SelectedValue.ToString() == "Seleccione")
                {
                    MessageBox.Show("Debe ingresar todos los campos del formulario", "Creación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Usuario _usuario = new Usuario()
                    {
                        IdUsuario = txtLogin.Text,
                        IdRol = (int)cbxRol.SelectedValue,
                        Rol = cbxRol.Text,
                        Nombre = txtNombre.Text,
                        IdTipoIdentificacion = cbxTipoIdentificacion.Text,
                        TipoIdentificacion = cbxTipoIdentificacion.Text,
                        NumeroIdentificacion = txtNumeroIdentificacion.Text,
                        IdOficina = cbxOficina.Text,
                        Habilitado = chbHabilitado.Checked, 
                        usuario = _Base.Usuario, 
                        TipoAutenticacion = 1,
                        Area = txtArea.Text,
                        Cargo = txtCargo.Text
                    };
                    long Result = Sp.CrearActualizarUsuario(_usuario);
                    if (Result > 0)
                    {
                        txtLogin.Text = null;
                        txtNombre.Text = null;                        
                        txtNumeroIdentificacion.Text = null;
                        txtArea.Text = null;
                        txtCargo.Text = null;
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
                error.Capa = "Usuario";
                error.Metodo = "ctrlUsuario : btnGuardar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnActualizar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLoginEdicion.Text) || string.IsNullOrEmpty(txtNombreEdicion.Text) ||
                    string.IsNullOrEmpty(txtAreaEdicion.Text) || string.IsNullOrEmpty(txtCargoEdicion.Text) ||
                    string.IsNullOrEmpty(txtNumeroIdentificacionEdicion.Text) || cbxRolEdicion.SelectedValue.ToString() == "Seleccione" ||
                   cbxTipoIdentificacionEdicion.SelectedValue.ToString() == "Seleccione" || cbxOficinaEdicion.SelectedValue.ToString() == "Seleccione")
                {
                    MessageBox.Show("Debe ingresar todos los campos del formulario", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    int idTipoIdentificacion = 0;
                    foreach (var value in Enum.GetValues(typeof(EnumParametrizacion.TipoIdentificacion))) 
                    {
                        if (Enum.GetName(typeof(EnumParametrizacion.TipoIdentificacion), value) == cbxTipoIdentificacionEdicion.SelectedValue.ToString())
                        {
                            idTipoIdentificacion = (int)value;
                        }
                        
                    }

                    Usuario _usuario = new Usuario()
                    {
                        IdUsuario = txtLoginEdicion.Text,
                        IdRol = (int)cbxRolEdicion.SelectedValue,
                        Rol = cbxRolEdicion.Text,
                        Nombre = txtNombreEdicion.Text,
                        IdTipoIdentificacion = cbxTipoIdentificacionEdicion.Text,
                        TipoIdentificacion = cbxTipoIdentificacionEdicion.Text,
                        NumeroIdentificacion = txtNumeroIdentificacionEdicion.Text,
                        IdOficina = cbxOficinaEdicion.Text,
                        Habilitado = chbHabilitadoEdicion.Checked,
                        UsuarioModificacion = _Base.Usuario,
                        TipoAutenticacion = 1,
                        Area = txtAreaEdicion.Text,
                        Cargo = txtCargoEdicion.Text
                    };

                    long Result = Sp.CrearActualizarUsuario(_usuario);
                    if (Result > 0)
                    {
                        txtLoginEdicion.Text = null;
                        txtNombreEdicion.Text = null;
                        txtNumeroIdentificacionEdicion.Text = null;
                        chbHabilitadoEdicion.Checked = false;
                        txtAreaEdicion.Text = null;
                        txtCargoEdicion.Text = null;
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
                error.Capa = "Usuario";
                error.Metodo = "ctrlUsuario : btnActualizar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void gbCreacion_Leave(object sender, EventArgs e)
        {
            CargarDatos();
            txtLogin.Text = null;
            txtNombre.Text = null;
            txtNumeroIdentificacion.Text = null;
            chbHabilitado.Checked = false;
            gbCreacion.Visible = true;
            gbEdicion.Visible = false;
            txtArea.Text = null;
            txtCargo.Text = null;
        }

        private void gbEdicion_Leave(object sender, EventArgs e)
        {
            CargarDatos();
            txtLoginEdicion.Text = null;
            txtNombreEdicion.Text = null;
            txtNumeroIdentificacionEdicion.Text = null;
            chbHabilitadoEdicion.Checked = false;
            txtAreaEdicion.Text = null;
            txtCargoEdicion.Text = null;
            gbCreacion.Visible = true;
            gbEdicion.Visible = false;
        }

        private void Cancelar_EventoClick(object sender, EventArgs e)
        {
            CargarDatos();
            txtLoginEdicion.Text = null;
            txtNombreEdicion.Text = null;
            txtNumeroIdentificacionEdicion.Text = null;
            chbHabilitadoEdicion.Checked = false;
            txtAreaEdicion.Text = null;
            txtCargoEdicion.Text = null;
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
                _Base.CargarControl(new ctrlUsuario());
            }
            CargarDatos();
        }

        private void txtNumeroIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNumeroIdentificacionEdicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void BtnExportar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = Utilidades.CopyDataGridView.CopyDGV(dgvUsuario);
                if (dgv.Rows.Count > 0)
                {
                    dgv.Columns.Remove("Editar");
                    dgv.Columns.Remove("IdRol");
                    dgv.Columns.Remove("IdTipoIdentificacion");
                    dgv.Columns.Remove("UsuarioCreacion");
                    dgv.Columns.Remove("FechaModificacion");
                    dgv.Columns.Remove("UsuarioModificacion");
                    dgv.Columns.Remove("TipoAutenticacion");
                    dgv.Columns.Remove("usuarios");
                    dgv.Columns.Remove("Password");
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

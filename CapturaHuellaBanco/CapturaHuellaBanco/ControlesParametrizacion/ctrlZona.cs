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
    public partial class ctrlZona : UserControl
    {
        static LogErrores error = null;
        public List<Zona> zona = new List<Zona>();
        private frmBase _Base;

        private bool incluirNoHab = true;
        private Banco.ServicioParametrizacion Sp = new Banco.ServicioParametrizacion();
        Banco.ServicioBanco sb = new Banco.ServicioBanco();

        public ctrlZona()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            RespuestaListas<Zona> Rl = Sp.ConsultarTodosZonas(incluirNoHab);
            if (Rl.Estado == Estado.Ok)
            {
                zona = Rl.Lista;
                dgvZona.DataSource = zona;
            }
            else
            {
                MessageBox.Show(/*Rl.CodigoError + ": " +*/ Rl.DescripcionError, "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlZona_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "ZONA";
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
                error.Capa = "Zona";
                error.Metodo = "ctrlZona : ctrlZona_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void dgvZona_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                        txtZonaEdicion.Text = (string)row.Cells["IdZona"].Value;
                        txtDescripcionEdicion.Text = (string)row.Cells["Descripcion"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Zona";
                error.Metodo = "ctrlZona : dgvZona_CellContentClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }

        }

        private void BtnBuscar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtZonaBusqueda.Text))
                {
                    MessageBox.Show("Debe ingresar un filtro de búsqueda", "Filtro de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvZona.DataSource = (from z in zona
                                          where z.IdZona.ToLower().Contains(txtZonaBusqueda.Text.ToLower())
                                          select new { z.IdZona, z.Descripcion }).ToList();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Zona";
                error.Metodo = "ctrlZona : BtnBuscar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnLimpiar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                txtZonaBusqueda.Text = null;
                CargarDatos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "Zona";
                error.Metodo = "ctrlZona : btnLimpiar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnGuardar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtZona.Text) || string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    MessageBox.Show("Debe ingresar todos los campos del formulario", "Creación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    Zona _zona = new Zona()
                    {
                        IdZona = txtZona.Text,
                        Descripcion = txtDescripcion.Text
                    };
                    long Result = Sp.CrearActualizarZona(_zona);
                    if (Result == 1)
                    {
                        txtZona.Text = null;
                        txtDescripcion.Text = null;
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
                error.Capa = "Zona";
                error.Metodo = "ctrlZona : btnGuardar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnActualizar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtZonaEdicion.Text) && string.IsNullOrEmpty(txtDescripcionEdicion.Text))
                {
                    MessageBox.Show("Debe ingresar todos los campos del formulario", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Zona _zona = new Zona()
                    {
                        IdZona = txtZonaEdicion.Text,
                        Descripcion = txtDescripcionEdicion.Text
                    };
                    long Result = Sp.CrearActualizarZona(_zona);
                    if (Result == 1)
                    {
                        txtZonaEdicion.Text = null;
                        txtDescripcionEdicion.Text = null;
                        gbCreacion.Visible = true;
                        gbEdicion.Visible = false;
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
                error.Capa = "Zona";
                error.Metodo = "ctrlZona : btnActualizar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void gbCreacion_Leave(object sender, EventArgs e)
        {
            txtZona.Text = null;
            txtDescripcion.Text = null;
            gbCreacion.Visible = true;
            gbEdicion.Visible = false;
        }

        private void gbEdicion_Leave(object sender, EventArgs e)
        {
            txtZonaEdicion.Text = null;
            txtDescripcionEdicion.Text = null;
            gbCreacion.Visible = true;
            gbEdicion.Visible = false;
        }

        private void Cancelar_EventoClick(object sender, EventArgs e)
        {
            txtZonaEdicion.Text = null;
            txtDescripcionEdicion.Text = null;
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
                _Base.CargarControl(new ctrlZona());
            }
            CargarDatos();
        }

        private void BtnExportar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = Utilidades.CopyDataGridView.CopyDGV(dgvZona);
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

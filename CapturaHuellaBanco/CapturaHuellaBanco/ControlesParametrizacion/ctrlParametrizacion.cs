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

namespace CapturaHuellaBanco.ControlesParametrizacion
{
    public partial class ctrlParametrizacion : UserControl
    {
        static LogErrores error = null;
        Banco.ServicioBanco sb = new Banco.ServicioBanco();
        private frmBase _Base;

        public ctrlParametrizacion()
        {
            InitializeComponent();
        }

        private void ctrlParametrizacion_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.ActivoParametrizacion = false;
                _Base.Titulo = "PARAMETRIZACIÓN";
                _Base.ActivarPaneles(true);
                //_Base.CargarBotonNumerico("1", true);
                AsignarControlXRol(_Base.IdRol);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AsignarControlXRol(int IdRol)
        {
            switch (IdRol)
            {
                case 3://Riesgos
                    gbPermisos.Enabled = false;
                    _Base.MostrarIconoDashboard();
                    //home
                    break;
                case 4://Control Acceso
                    gbEmpresa.Enabled = false;
                    gbServicios.Enabled = false;
                    gbConfiguracion.Enabled = false;
                    _Base.OcultarIconoDashboard();
                    break;
            }
        }

        private void btnZona_EventoClick(object sender, EventArgs e)
        {
            try
            {
                _Base.ActivoParametrizacion = true;
                _Base.CargarControl(new ctrlZona());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnOficina_EventoClick(object sender, EventArgs e)
        {
            try
            {
                _Base.ActivoParametrizacion = true;
                _Base.CargarControl(new ctrlOficina());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnRol_EventoClick(object sender, EventArgs e)
        {
            try
            {
                _Base.ActivoParametrizacion = true;
                _Base.CargarControl(new ctrlRol());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnUsuario_EventoClick(object sender, EventArgs e)
        {
            try
            {
                _Base.ActivoParametrizacion = true;
                _Base.CargarControl(new ctrlUsuario());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnProducto_EventoClick(object sender, EventArgs e)
        {
            try
            {
                _Base.ActivoParametrizacion = true;
                _Base.CargarControl(new ctrlProducto());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnServicio_EventoClick(object sender, EventArgs e)
        {
            try
            {
                _Base.ActivoParametrizacion = true;
                _Base.CargarControl(new ctrlServicio());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnParametros_EventoClick(object sender, EventArgs e)
        {
            try
            {
                _Base.ActivoParametrizacion = true;
                _Base.CargarControl(new ctrlParametros());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

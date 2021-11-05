using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Controles
{
    public partial class VentanaConfirmacion : UserControl
    {
        public VentanaConfirmacion()
        {
            try
            {
                InitializeComponent();
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public delegate void EventoDelegadoAceptar(object sender, EventArgs e);

        public delegate void EventoDelegadoCancelar(object sender, EventArgs e);

        [Category("Ventana confirmacion")]
        [Description("Ocurre cuando el botón aceptar es presionado.")]
        public event EventoDelegadoAceptar EventoAceptaProceso;

        [Category("Ventana confirmacion")]
        [Description("Ocurre cuando el botón cancelar es presionado.")]
        public event EventoDelegadoCancelar EventoCancelarProceso;

        public bool esConfirmado { get; set; }

        [Category("Ventana confirmacion")]
        [Description("Texto confirmacion")]
        public string TextoMostrar
        {
            get
            {
                return this.lblMensaje.Text;
            }
            set
            {
                this.lblMensaje.Text = value;
            }
        }

        [Category("Ventana confirmacion")]
        [Description("Título de la ventana")]
        public string TituloVentana
        {
            get
            {
                return this.lblTituloVentana.Text;
            }
            set
            {
                this.lblTituloVentana.Text = value;
            }
        }
        private void botonAceptar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (EventoAceptaProceso != null)
                {
                    Application.DoEvents();
                    EventoAceptaProceso(this, e);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void botonCancelar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (EventoCancelarProceso != null)
                {
                    Application.DoEvents();
                    EventoCancelarProceso(this, e);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
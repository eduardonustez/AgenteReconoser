using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Controles
{
    public partial class VentanaInformativa : UserControl
    {
        public VentanaInformativa()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public delegate void ClickEventHandler(object sender, EventArgs e);

        public delegate void EventoDelegado(object sender, EventArgs e);

        [Category("Ventana informativa")]
        [Description("Ocurre cuando el botón es presionado.")]
        public event EventoDelegado EventoCerrarVentana;

        [Category("Ventana informativa")]
        [Description("Ocurre cuando el botón es presionado.")]
        public event ClickEventHandler EventoClick;

        [Category("Ventana informativa")]
        [Description("Texto informativo")]
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

        [Category("Ventana informativa")]
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
                if (EventoClick != null)
                {
                    Application.DoEvents();
                    EventoClick(this, e);
                }

                if (EventoCerrarVentana != null)
                {
                    Application.DoEvents();
                    EventoCerrarVentana(this, e);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
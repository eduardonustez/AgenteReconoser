using System;
using System.Windows.Forms;

namespace Controles
{
    public static class VentanaMensajeInformativo
    {
        public static void Show(string titulo, string mensaje)
        {
            try
            {
                // using construct ensures the resources are freed when form is closed
                using (var form = new MensajeInformativo(titulo, mensaje))
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    internal partial class MensajeInformativo : Form
    {
        public MensajeInformativo(string titulo, string mensaje)
        {
            try
            {
                InitializeComponent();
                this.lblMensaje.Text = mensaje;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void botonAceptar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
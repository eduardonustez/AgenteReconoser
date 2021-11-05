using System;
using System.Windows.Forms;

namespace Controles
{
    public partial class frmPrecarga : Form
    {
        public frmPrecarga()
        {
            try
            {
                InitializeComponent();
                this.ShowInTaskbar = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public frmPrecarga(string textoMensaje)
        {
            try
            {
                InitializeComponent();
                this.lblTextoMostrar.Text = textoMensaje;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public delegate void CerrarCallback();
    }
}
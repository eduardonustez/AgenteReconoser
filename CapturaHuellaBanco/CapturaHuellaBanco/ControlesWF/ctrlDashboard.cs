using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CapturaHuellaBanco.ControlesWF
{
    public partial class ctrlDashboard : UserControl
    {
        private static LogErrores error = null;
        private string _Asesor = null;
        private frmBase _Base;
        private List<LogErrores> Data = new List<LogErrores>();
        private Legend legend1 = new Legend() { BackColor = Color.White, ForeColor = Color.Black, Title = "Resultados" };
        private Olimpia.Servicios.ConsumirServicio sb = new Olimpia.Servicios.ConsumirServicio();

        public ctrlDashboard()
        {
            InitializeComponent();
        }

        private void AsignarControlXRol(int IdRol)
        {
            _Asesor = _Base.Usuario;
        }

        private void BtnReporteTransacciones_EventoClick(object sender, EventArgs e)
        {
            _Base.CargarControl(new ctrlInformeTransaccional());
        }

        private void BtnValidacion_EventoClick(object sender, EventArgs e)
        {
            _Base.CargarControl(new ctrlCapturaHuella());
        }

        private void ctrlDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "DASHBOARD";
                _Base.ActivarPaneles(true);
                _Base.OcultarIconoDashboard();

                AsignarControlXRol(_Base.IdRol);

                pnlNewPanel.Visible = true;

                pnlNewPanel.Left = (this.ClientSize.Width - pnlNewPanel.Width) / 2;
                pnlNewPanel.Top = 10;
                pnlNewPanel.Anchor = AnchorStyles.Top;
                pnlNewPanel.Visible = true;
                pnlNewPanel.BringToFront();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlDashboard : ctrlDashboard_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }
    }
}
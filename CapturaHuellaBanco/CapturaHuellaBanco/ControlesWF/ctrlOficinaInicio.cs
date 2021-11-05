using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapturaHuellaBanco.ControlesWF
{
    public partial class ctrlOficinaInicio : UserControl
    {
        private frmBase _Base;
        private List<Entidades.Parametrizacion.Oficina> _Oficinas;

        public ctrlOficinaInicio()
        {
            InitializeComponent();
        }

        public ctrlOficinaInicio(List<Entidades.Parametrizacion.Oficina> _Of)
        {
            InitializeComponent();
            _Oficinas = _Of;
        }

        public List<Entidades.Parametrizacion.Oficina> Oficinas
        {
            get { return _Oficinas; }
            set { _Oficinas = value; }
        }
        private void btnGuardar_EventoClick(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Confirma que la oficina es " + cbOficina.SelectedValue.ToString() + " ?",
                                     "Confirmar Oficina",
                                     MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                frmBase.RegistrarOficina(cbOficina.SelectedValue.ToString());
                this.ParentForm.Close();
                this.Hide();
            }
        }

        private void ctrlOficina_Load(object sender, EventArgs e)
        {
            cbOficina.DataSource = _Oficinas;
            cbOficina.DisplayMember = "Codigo";
            cbOficina.ValueMember = "IdOficina";
        }
    }
}
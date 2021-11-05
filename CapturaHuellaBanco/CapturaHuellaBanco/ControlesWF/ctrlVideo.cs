using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CapturaHuellaBanco.ControlesWF
{
    public partial class ctrlVideo : UserControl
    {
        public ctrlVideo(int v)
        {
            InitializeComponent();

            string _Path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            switch (v)
            {
                case 1:
                    wmpVideo.URL = Path.Combine(_Path, @"Plantillas\reconoser-inicio-sesion.mp4");
                    break;

                case 2:
                    wmpVideo.URL = Path.Combine(_Path, @"Plantillas\consulta-reportes.mp4");
                    break;

                case 3:
                    wmpVideo.URL = Path.Combine(_Path, @"Plantillas\reconoser-validacion-cliente.mp4");
                    break;
            }
        }

        private void btnCerrar_EventoClick(object sender, EventArgs e)
        {
            wmpVideo.stretchToFit = true;
            wmpVideo.close();
            this.ParentForm.Close();
            this.Hide();
        }
    }
}
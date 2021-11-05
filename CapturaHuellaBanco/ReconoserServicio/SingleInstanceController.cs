using Microsoft.VisualBasic.ApplicationServices;

namespace ReconoserEstado
{
    public class SingleInstanceController : WindowsFormsApplicationBase
    {        
        public SingleInstanceController()
        {
            IsSingleInstance = true;
            StartupNextInstance += SingleInstanceController_StartupNextInstance;
        }

        private void SingleInstanceController_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            if (MainForm != null)
            {
                MainForm.Show();
                MainForm.Focus();
            }
        }

        protected override void OnCreateMainForm()
        {
            MainForm = new Form1();            
        }
    }
}

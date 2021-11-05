using System;
using System.Windows.Forms;

namespace CapturaHuellaBanco
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Dispositivos.Base.CheckDependencies();
            }
            catch (System.IO.FileNotFoundException ex)
            {
                if (ex.FileName == "UICWrapper.dll")
                {
                    if (MessageBox.Show("Las librerías de visual c++ 2015 no están instaladas y son necesarias para ejecutar la aplicación. ¿Desea descargarlas ahora?", "Dependencias faltantes!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://download.microsoft.com/download/9/3/F/93FCF1E7-E6A4-478B-96E7-D4B285925B00/vc_redist.x86.exe");
                    }
                }
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin2());
        }
    }
}
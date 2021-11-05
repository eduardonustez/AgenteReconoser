using System.Windows.Forms;

namespace ReconoserEstado
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SingleInstanceController controller = new SingleInstanceController();
            controller.Run(args);            
        }
    }
}
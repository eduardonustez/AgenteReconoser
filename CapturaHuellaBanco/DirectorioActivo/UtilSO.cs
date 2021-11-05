using System.Management;

namespace Utilidades
{
    public static class UtilSO
    {
        public static string ObtenerSOCliente()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
            }
            return result;
        }
    }
}

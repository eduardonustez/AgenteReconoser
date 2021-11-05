using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DevicesValidator
{
    public class WacomValidator
    {
        [DllImport("kernel32")]
        private extern static bool FreeLibrary(int hLibModule);

        [DllImport("kernel32")]
        private extern static int LoadLibrary(string lpLibFileName);

        public static EnumSTUStatus GetEstadoServicioWacomSTU()
        {
            //ServiceController[] scServices;
            //scServices = ServiceController.GetServices();
            //ServiceController wacomService = scServices.FirstOrDefault(s => s.ServiceName == "WacomSTUSigCaptX");

            ServiceController wacomService;
            wacomService = new ServiceController("WacomSTUSigCaptX");
            try
            {
                string serviceName = wacomService.ServiceName;
            }
            catch {
                wacomService = null;
            }
            if (wacomService==null)
            {
                return EnumSTUStatus.NotInstalled;
            }
            else if (wacomService.Status != ServiceControllerStatus.Running)
            {
                return EnumSTUStatus.Stopped;
            }
            else
            {
                return EnumSTUStatus.Running;
            }
        }
        public static bool IsWacomDllRegistered()
        {
            using (var classesRootKey = Microsoft.Win32.RegistryKey.OpenBaseKey(
                   Microsoft.Win32.RegistryHive.ClassesRoot, Microsoft.Win32.RegistryView.Default))
            {
                const string clsid = "{2000D7A5-64F7-4826-B56E-85ACC618E4D6}";

                var clsIdKey = classesRootKey.OpenSubKey(@"Wow6432Node\CLSID\" + clsid) ??
                                classesRootKey.OpenSubKey(@"CLSID\" + clsid);

                if (clsIdKey != null)
                {
                    clsIdKey.Dispose();
                    return true;
                }
                return false;
            }
        }
    }
}

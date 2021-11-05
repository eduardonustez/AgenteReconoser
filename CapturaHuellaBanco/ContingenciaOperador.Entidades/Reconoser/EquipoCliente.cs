using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace ContingenciaOperador.Entidades.Reconoser
{
    public class EquipoCliente
    {
        private string IP { get; set; }
        private string MAC { get; set; }
        private string NombreEquipo { get; set; }

        public string ConsultaMAC()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up && !nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo"))
                {
                    if (nic.GetPhysicalAddress().ToString() != "")
                    {
                        MAC = string.Join("-", from z in nic.GetPhysicalAddress().GetAddressBytes()
                                               select z.ToString("X2"));
                    }
                }
            }
            return MAC;
        }

        public string ConsultaIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    IP = ip.ToString();
                    break;
                }
            }
            return IP;
        }

        public string ConsultaNombreEquipo()
        {
            NombreEquipo = Dns.GetHostName();
            return NombreEquipo;
        }
    }
}

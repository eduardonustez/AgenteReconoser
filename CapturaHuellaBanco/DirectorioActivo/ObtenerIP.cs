using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Utilidades
{
    public class ObtenerIP
    {
        public static string GetIP2()
        {
            try
            {
                IPHostEntry host;
                string localIP = "";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
                return localIP;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetIP()
        {
            try
            {
                IPHostEntry host;
                string localIP = "";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
                return localIP;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string GetIpSolicitud()
        {
            try
            {
                OperationContext context = OperationContext.Current;
                MessageProperties prop = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                string ip = endpoint.Address;
                return ip;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
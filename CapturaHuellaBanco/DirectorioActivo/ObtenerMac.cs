using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Utilidades
{
    public class ObtenerMac
    {
        public static string GetMac2()
        {
            try
            {
                var regex = "(.{2})(.{2})(.{2})(.{2})(.{2})(.{2})";
                var replace = "$1-$2-$3-$4-$5-$6";

                string mac = "";
                string macApp = "";
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
                    {
                        if (nic.GetPhysicalAddress().ToString() != "")
                        {
                            mac = nic.GetPhysicalAddress().ToString();

                            if (mac == "00000000000000E0")
                            {
                                continue;
                            }

                            string newformat = "";

                            try
                            {
                                newformat = Regex.Replace(mac, regex, replace);
                            }
                            catch
                            {
                                newformat = string.Join("-", Enumerable.Range(0, 6).Select(i => mac.Substring(i * 2, 2)));
                            }
                            mac = newformat.ToString();

                            if (mac == "00 - 00 - 00 - 00 - 00 - 0000E0")
                            {
                                continue;
                            }

                            macApp = mac;
                            break;
                        }
                    }
                }

                return macApp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetMac()
        {
            try
            {
                var regex = "(.{2})(.{2})(.{2})(.{2})(.{2})(.{2})";
                var replace = "$1-$2-$3-$4-$5-$6";

                string mac = "";
                string macApp = "";
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
                    {
                        if (nic.GetPhysicalAddress().ToString() != "")
                        {
                            mac = nic.GetPhysicalAddress().ToString();

                            if (mac == "00000000000000E0")
                            {
                                continue;
                            }

                            string newformat = "";

                            try
                            {
                                newformat = Regex.Replace(mac, regex, replace);
                            }
                            catch
                            {
                                newformat = string.Join("-", Enumerable.Range(0, 6).Select(i => mac.Substring(i * 2, 2)));
                            }
                            mac = newformat.ToString();

                            if (mac == "00 - 00 - 00 - 00 - 00 - 0000E0")
                            {
                                continue;
                            }

                            macApp = mac;
                            break;
                        }
                    }
                }

                return macApp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
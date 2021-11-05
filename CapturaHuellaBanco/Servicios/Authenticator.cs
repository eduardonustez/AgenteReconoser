using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.Configuration;
using Utilidades;

namespace Banco
{
    public class Authenticator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            bool Validar = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("Validar"));

            if (Validar)
            {
                string strUsuarioVal = HttpUtility.HtmlDecode(ConfigurationManager.AppSettings.Get("UsuarioIIS"));
                string strPasswordVal = HttpUtility.HtmlDecode(ConfigurationManager.AppSettings.Get("PasswordIIS"));

                if (userName != strUsuarioVal && password != strPasswordVal)
                {
                    throw new FaultException("Invalid user and/or password");
                }
            }


            string IpPermitida = ConfigurationManager.AppSettings.Get("IpPermitida");

            if (!string.IsNullOrEmpty(IpPermitida))
            {
                ObtenerIP ObtenerIP = new ObtenerIP();

                string IpCliente = ObtenerIP.GetIP();
                System.Diagnostics.Trace.WriteLine("dirCliente:" + IpCliente);

                if (IpPermitida != IpCliente)
                {
                    throw new FaultException("Acceso Denegado");
                }
            }



        }
    }

}
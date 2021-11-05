using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WCFBanco
{
    public class Global : System.Web.HttpApplication
    {
        static RateLimiter _rateLimiter;

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("BEGIN REQUEST");
            if (_rateLimiter == null)
            {
                IniciarRateLimiting();
            }

            HttpApplication application = (HttpApplication)sender;
            string ip = application.Context.Request.GetClientIp();
            if (_rateLimiter.ShouldLimit(ip))
            {
                TerminateRequest(application.Context.Response);
            }
        }

        private void TerminateRequest(HttpResponse httpResponse)
        {
            httpResponse.StatusCode = (int)_rateLimiter.LimitStatusCode;
            httpResponse.SuppressContent = true;
            httpResponse.End();
        }

        private void IniciarRateLimiting()
        {
            RateLimiterConfiguration rlConf = new RateLimiterConfiguration();

            int Entero = 0;
            int RLSeconds = 120;
            if (int.TryParse(ConfigurationManager.AppSettings.Get("RL_TimePeriod"), out Entero))
            {
                RLSeconds = Entero;
            }


            int RLTreshhold = 50;
            if (int.TryParse(ConfigurationManager.AppSettings.Get("RL_Treshhold"), out Entero))
            {
                RLTreshhold = Entero;
            }


            rlConf.TimePeriod = new TimeSpan(0, 0, RLSeconds);
            rlConf.Treshhold = RLTreshhold;
            rlConf.RateLimiterType = typeof(RateLimiter);

            _rateLimiter = new RateLimiter(rlConf);

        }



        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
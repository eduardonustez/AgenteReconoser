using System;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serilog;
using Utilidades;

namespace ContingenciaOperador.Switch
{
    /// <summary>
    /// Implementa las operaciones disponibles contra el switch de contingencia. 
    /// </summary>
    public class SwitchContingencia : ISwitchContingencia
    {
        private const string XAPIKEY = "nd9csAzFwmeT03TcjVDdu/KJtdkjFlLfvCxZe9nWQdo+V1omROCr49DHzI4RFNmU";

        /// <summary>
        /// Cliente de consumo del servicio. 
        /// </summary>
        static HttpClient client = new HttpClient();

        /// <summary>
        /// Mantiene la URL base en la que esta disponible el servicio Switch. 
        /// </summary>
        static string url_base { get; set; }

        /// <summary>
        /// Mantiene la llave de consulta del switch. 
        /// </summary>
        static string header_xapikey { get; set; }

        /// <summary>
        /// Tiempo en segundos en los que se vuelve a consultar directamente al Switch. 
        /// </summary>
        public int IntervaloConsultaSwitch
        {
            get { return SwitchContingencia.switch_periodicity_in_seconds; }
        }

        /// <summary>
        /// Mantiene el tiempo en segundos en los que se vuelve a consultar directamente al Switch. 
        /// </summary>
        static int periodicity;

        /// <summary>
        /// Mantiene el tiempo en segundos en los que se vuelve a consultar directamente al Switch. 
        /// </summary>
        static int switch_periodicity_in_seconds
        {
            get { return SwitchContingencia.periodicity; }
            set
            {
                if (value > 0)
                {
                    SwitchContingencia.periodicity = value;
                }
            }
        }

        /// <summary>
        /// Logger
        /// </summary>
        private ILogger _logger;
        
        #region "Constructores"
        public SwitchContingencia(ILogger logger)
        {
            this._logger = logger;
        }

        static SwitchContingencia()
        {
            try
            {
                
                SwitchContingencia.url_base = ConfigurationManager.AppSettings["url_switch_contingencia"].ToString();
                //SwitchContingencia.header_xapikey = ConfigurationManager.AppSettings["switch_header_xapikey"].ToString();
                header_xapikey = Cifrado.DecryptS(XAPIKEY);
                //SwitchContingencia.switch_periodicity_in_seconds = int.Parse(ConfigurationManager.AppSettings["switch_periodicity_in_seconds"].ToString());

                client.BaseAddress = new Uri(SwitchContingencia.url_base);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-api-key", SwitchContingencia.header_xapikey);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {nameof(SwitchContingencia)}.{nameof(SwitchContingencia)} {ex.ToString()}");
                Log.Logger.Error("IP: {@IP} Aplicación: {@Aplicacion} Método: {@Metodo} Nuip: {@Nuip} NUT: {@NUT} Excepción: {@Excepcion}",
                    ConsultaIP(), SwitchContingenciaUtil.NombreAplicacion, $"{nameof(SwitchContingencia)}.{nameof(SwitchContingencia)}", string.Empty, string.Empty,
                    ex.ToString());
            }
        }

        #endregion "Constructores"

        /// <summary>
        /// Obtiene y retorna el consumo del switch para determinar el operador activo actualmente. 
        /// </summary>
        public OperatorContingency ObtenerOperadorContingencia()
        {
            var operadorContingencia = new OperatorContingency();
            int periodicity = 0;

            try
            {
                operadorContingencia = SwitchContingenciaUtil.RunSync(() => ObtenerOperador(string.Empty));
                
                if (operadorContingencia != null)
                {
                    if (int.TryParse(operadorContingencia.periodicity, out periodicity))
                    {
                        SwitchContingencia.switch_periodicity_in_seconds = periodicity * 60;
                    }
                }
            }
            catch (Exception ex)
            {
                this._logger.Error("IP: {@IP} Aplicación: {@Aplicacion} Método: {@Metodo} Nuip: {@Nuip} NUT: {@NUT} Excepción: {@Excepcion}",
                    ConsultaIP(), SwitchContingenciaUtil.NombreAplicacion, $"{nameof(SwitchContingencia)}.{nameof(ObtenerOperadorContingencia)}", string.Empty, string.Empty,
                    ex.ToString());
            }

            return operadorContingencia;
        }


        /// <summary>
        /// Realiza el consumo al switch y retorna el resultado. 
        /// </summary>
        static async Task<OperatorContingency> ObtenerOperador(string path)
        {
            var operadorContingencia = new OperatorContingency();
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                //operadorContingencia = await response.Content.ReadAsAsync<OperatorContingency>();
                string json = await response.Content.ReadAsStringAsync();
                operadorContingencia = JsonConvert.DeserializeObject<OperatorContingency>(json);
            }

            return operadorContingencia;
        }

        /// <summary>
        /// Obtiene y retorna la IP de la máquina en que se ejecuta el componente. 
        /// </summary>
        private static string ConsultaIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string IP = string.Empty;

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
    }
}

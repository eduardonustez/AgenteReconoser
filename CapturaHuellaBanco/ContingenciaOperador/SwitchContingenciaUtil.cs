using System;
using System.Configuration;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using ContingenciaOperador.Switch;
using Serilog;
using Utilidades;

namespace ContingenciaOperador
{
    public static class SwitchContingenciaUtil
    {
        private static bool _validarContingencia;
        private static ILogger _logger;

        /// <summary>
        /// Nombre de la aplicación. 
        /// </summary>
        public static string NombreAplicacion
        {
            get { return $"Servicio Notarias: {Assembly.GetEntryAssembly().GetName().Version}"; }
        }

        /// <summary>
        /// Indica Si se debe consultar el switch de contingencia para determinar el operador activo
        /// </summary>
        public static bool IntegracionOperadorAliadoActiva
        {
            get { return _validarContingencia; }
        }

        /// <summary>
        /// Determina si el operador aliado es el que esta activo o no. 
        /// </summary>
        /// <returns>Verdadero si el operador aliado esta activo. Falso si es Olimpia.</returns>
        public static bool OperadorAliadoActivo()
        {
            if (IntegracionOperadorAliadoActiva)
            {
                bool operadorAliadoActivo = false;
                try
                {
                    var operadorActivo = ObtenerOperadorContingencia();

                    if (operadorActivo != null && operadorActivo.operatorActive != null)
                    {
                        operadorAliadoActivo = (operadorActivo.operatorActive.operatorName.ToLower().Equals("olimpia") &&
                            operadorActivo.operatorActive.active.Equals("1")) ? false : true;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("IP: {@IP} Aplicación: {@Aplicacion} Método: {@Metodo} Nuip: {@Nuip} NUT: {@NUT} Excepción: {@Excepcion}",
                        ObtenerIP.GetIP2(), NombreAplicacion, "SwitchContingenciaUtil.OperadorAliadoActivo", string.Empty, string.Empty,
                        ex.ToString());
                }
                return operadorAliadoActivo;
            }
            else
                return false;
        }

        static SwitchContingenciaUtil()
        {
            _validarContingencia = ValidarContingencia();
            _logger = Log.Logger;
        }

        private static ISwitchContingencia GetInstance()
        {
#if DEBUG
            //HACK: En produccion debereia deshabilitarse la opcion de archivo|
            bool.TryParse(ConfigurationManager.AppSettings["ArchivoContingencia"], out bool usarArchivo);
            if (usarArchivo)
                return new SwitchContingenciaDummy();
            else
#endif
            return new SwitchContingencia(Log.Logger);
        }

        private static bool ValidarContingencia()
        {
            bool ch;
            if (bool.TryParse(ConfigurationManager.AppSettings["ValidarContingencia"], out ch))
                return ch;
            else
                return false;
        }

        /// <summary>
        /// Realiza la consulta del operador aliado activo en el switch. 
        /// </summary>
        private static OperatorContingency ObtenerOperadorContingencia()
        {
            ISwitchContingencia _servicioSwitchContingencia = GetInstance();
            return _servicioSwitchContingencia.ObtenerOperadorContingencia();
        }

        private static readonly TaskFactory _taskFactory = new
            TaskFactory(CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskContinuationOptions.None,
                    TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        public static void RunSync(Func<Task> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
    }
}

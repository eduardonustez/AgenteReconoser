using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using ContingenciaOperador;
using ContingenciaOperador.Entidades;
using Dispositivos;
using Entidades;
using Entidades.Parametrizacion;
using Olimpia.Servicios;
using Serilog;
using Utilidades;
using WCFServicioReconoser.RequestEntities;

namespace WCFServicioReconoser
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class RestWCFReconososer : IRestWCFReconososer
    {
        private static string _habilitarGET = string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["EnableGET"]) ? "true" : System.Configuration.ConfigurationManager.AppSettings["EnableGET"];
        private static string[] ips_locales = { "::1", "0.0.0.1", "127.0.0.1", "...1", "localhost", "local" };
        private static string origen = string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["Origen"]) ? "*" : System.Configuration.ConfigurationManager.AppSettings["Origen"];

        private static int _IdCliente =

#if DEBUG
        //3019
        1338
#else
           1338
#endif
;
        private static ParametrosOperacion Parametros { get; set; }
        private static List<Convenio> _convenios = null;

        private string _Serial;
        private string _Marca;
        private string _Modelo;
        private int _TipoBiometrico;

        private List<HuellaAFI> Dedos = new List<HuellaAFI>();

        private static int Dedo1 = 0;
        private static byte[] Template1 = null;
        private static DateTime HoraCaptura1 = DateTime.Now.AddDays(-1);
        private static int Dedo2 = 0;
        private static byte[] Template2 = null;
        private static DateTime HoraCaptura2 = DateTime.Now.AddDays(-1);

        private static bool Capturando = false;
        private static Bitmap ImagenFirma = null;
        private bool blnRegistraSistema = true;

        private ILogger _logger;

        static RestWCFReconososer()
        {
            Parametros = new ParametrosOperacion();
            Parametros.ConvenioCliente = Guid.Empty;
            Parametros.FechaRegistro = DateTime.MinValue;
        }

        public RestWCFReconososer()
        {
            _logger = Log.Logger;
        }

        #region Metodos Publicos        
        public RespuestaCaptura CapturarHuella(string cedula, string dedo, string captura, string ticks)
        {
            try
            {
                bool getHabilitado = false;
                if (bool.TryParse(_habilitarGET, out getHabilitado) && !getHabilitado)
                {
                    Cors();
                    Trace.WriteLine("Peticion prohibida - Verbo GET deshabilitado");
                    RespuestaCaptura resp = new RespuestaCaptura
                    {
                        Respuesta = "Error",
                        Detalle = string.Format("Prohibido por politica - Verbo GET deshabilitado")
                    };
                    return resp;
                }

                CapturarHuellaRequest request = new CapturarHuellaRequest()
                {
                    cedula = cedula,
                    dedo = dedo,
                    captura = captura,
                    ticks = ticks
                };
                return CapturarHuellaP(request);
            }
            catch (Exception Ex)
            {
                Trace.WriteLine("Error CapturarHuella: " + Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "CapturarHuella",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);
                RespuestaCaptura resp = new RespuestaCaptura
                {
                    Respuesta = "Error",
                    Detalle = string.Format("Error al capturar huella")
                };
                return resp;
            }
        }

        public RespuestaCaptura CapturarHuellaP(CapturarHuellaRequest request)
        {
            string cedula = request.cedula;
            string dedo = request.dedo;
            string captura = request.captura;
            string ticks = request.ticks;

            Cors();

            RespuestaCaptura resp = new RespuestaCaptura
            {
                Respuesta = "Ok",
                Detalle = "",
                Calidad = 0
            };

            //Cargar Parametros
            try
            {
                IniciarVariablesGlobales();
            }
            catch (Exception ex)
            {
                resp.Respuesta = "Error";
                resp.Detalle = "Error al cargar parámetros";
                return resp;
            }

            Trace.WriteLine("DFZM 10CH: " + cedula + " | " + dedo + " | " + captura + " | " + ticks + '|' + Parametros.ConvenioCliente.ToString());

            //Validacion
            Trace.WriteLine("DFZM 11CH: " + Capturando.ToString());
            string ip = ObtenerIpSolicitante();
            if (!Parametros.IPsPermitidas.Contains(ip))
            {
                Utilidades.LogLocal.GuardarLog("Peticion prohibida - acceso remoto deshabilitado: " + ip);
                resp.Respuesta = "Error";
                resp.Detalle = string.Format("Prohibido por politica - Ip Solicitante {0}", ip);
                return resp;
            }

            Trace.WriteLine("DFZM 11aCH: " + Capturando.ToString());
            if (Capturando == true)
            {
                resp.Respuesta = "Error";
                resp.Detalle = string.Format("Captura de Huella Pendiente", cedula);
                return resp;
            }
            long numeroIdentificacion = 0;

            if (!long.TryParse(cedula, out numeroIdentificacion))
            {
                resp.Respuesta = "Error";
                resp.Detalle = string.Format("La cedula '{0}' no es un valor valido", cedula);
                return resp;
            }
            cedula = numeroIdentificacion.ToString(); //Se limpia el valor (posibles ceros al principio)

            int numeroDedo = 0;
            if (!int.TryParse(dedo, out numeroDedo))
            {
                resp.Respuesta = "Error";
                resp.Detalle = string.Format("El dedo '{0}' no es un valor valido", dedo);
                return resp;
            }
            else
            {
                if (numeroDedo < 1 || numeroDedo > 10)
                {
                    resp.Respuesta = "Error";
                    resp.Detalle = string.Format("El dedo '{0}' no es valido (1-10)", dedo);
                    return resp;
                }
            }

            int numeroCaptura = 0;
            if (!int.TryParse(captura, out numeroCaptura))
            {
                resp.Respuesta = "Error";
                resp.Detalle = string.Format("El número de captura '{0}' no es un valor valido", captura);
                return resp;
            }
            else
            {
                if (numeroCaptura < 1 || numeroCaptura > 2)
                {
                    resp.Respuesta = "Error";
                    resp.Detalle = string.Format("El número de captura '{0}' no es valido (1 ó 2)", captura);
                    return resp;
                }
            }

            if (numeroCaptura == 1 && Dedo2 == numeroDedo)
            {
                resp.Respuesta = "Error";
                resp.Detalle = string.Format("El dedo '{0}' ya fue capturado", captura);
                return resp;
            }

            if (numeroCaptura == 2 && Dedo1 == numeroDedo)
            {
                resp.Respuesta = "Error";
                resp.Detalle = string.Format("El dedo '{0}' ya fue capturado", captura);
                return resp;
            }

            //Fin Validaciones

            try
            {
                if (captura == "1")
                    HoraCaptura1 = DateTime.Now;
                else if (captura == "2")
                    HoraCaptura2 = DateTime.Now;

                Morpho CapturaM = new Morpho(Parametros.HC, Parametros.HK, Parametros.CA, Parametros.DK);
                Capturando = true;
                Trace.WriteLine("DFZM 11bCH: " + Capturando.ToString());
                var imagenHuella = CapturaM.Capturar();

                if (string.IsNullOrEmpty(imagenHuella))
                {
                    resp.Respuesta = "Error";
                    resp.Detalle = "Error en la captura, intente de nuevo";
                    if (CapturaM.Serial != null)
                        resp.Calidad = CapturaM.Calidad;
                    else
                        resp.Calidad = -1;
                }
                else
                {
                    _Serial = CapturaM.Serial;
                    _Marca = CapturaM.Marca;
                    _Modelo = CapturaM.Modelo;
                    _TipoBiometrico = CapturaM.Tipo;
                    resp.Calidad = CapturaM.Calidad;

                    if (numeroCaptura == 1)
                    {
                        Dedo1 = numeroDedo;
                        Template1 = CapturaM.Template;
                        ImagenFirma = CapturaM.Imagen;
                    }
                    else if (numeroCaptura == 2)
                    {
                        Dedo2 = numeroDedo;
                        Template2 = CapturaM.Template;
                    }
                }

                CapturaM = null;
            }
            catch (EndpointNotFoundException Ex)
            {
                LogLocal.GuardarLog(Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "CapturarHuellaP",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);
                resp.Respuesta = "Error";
                resp.Detalle = "No se pudo  establecer conexión al servicio de la aplicación";
            }
            catch (OperationCanceledException Ex)
            {
                Utilidades.LogLocal.GuardarLog("DFZM CCAN: " + Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "CapturarHuellaP",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);
                resp.Respuesta = "Cancelado";
                resp.Detalle = "Captura Cancelada por el usuario";
                resp.Calidad = 0;
            }
            catch (Exception Ex)
            {
                Utilidades.LogLocal.GuardarLog("DFZM CH: " + Ex.ToString());

                if (Ex.Message.Contains("IED_ERR_"))
                {
                    ObtenerIP OI = new ObtenerIP();
                    ObtenerMac OM = new ObtenerMac();
                    LogHallazgoBiometrico lh = new LogHallazgoBiometrico()
                    {
                        Descripcion = Ex.ToString(),
                        Fecha = DateTime.Now,
                        Ip = OI.GetIP(),
                        Mac = OM.GetMac(),
                        Metodo = "CapturarHuella",
                        UsuarioLogin = "RS"
                    };

                    var servicios = new ConsumirServicio();
                    servicios.InsertarHallazgoBiometrico(lh, _IdCliente);

                    resp.Respuesta = "Error";
                    resp.Detalle = "Error en la captura, intente de nuevo";
                    resp.Calidad = 0;
                }
                else
                {
                    LogErrores logErrores = new LogErrores
                    {
                        UsuarioLogin = null,
                        //Capa = "Servicio Local",
                        Metodo = "CapturarHuellaP",
                        Fecha = DateTime.Now,
                        Descripcion = Ex.ToString(),
                        Ip = ObtenerIP.GetIP2(),
                        Mac = ObtenerMac.GetMac2(),
                        IdOficina = null
                    };
                    InsertarLogError(logErrores);
                    resp.Respuesta = "Error";
                    resp.Detalle = Ex.ToString();
                    resp.Calidad = 0;
                }
            }
            finally
            {
                Capturando = false;
            }

            return resp;
        }

        public RespuestaValidacion ValidarIdentidad(string cedula, string asesor, string oficina, string producto, string ticks, string idConvenio)
        {
            try
            {
                Cors();
                bool getHabilitado = false;
                if (bool.TryParse(_habilitarGET, out getHabilitado) && !getHabilitado)
                {
                    Trace.WriteLine("Peticion prohibida - Verbo GET deshabilitado");
                    RespuestaValidacion resp = new RespuestaValidacion
                    {
                        Respuesta = "Error",
                        Detalle = string.Format("Prohibido por politica - Verbo GET deshabilitado")
                    };
                    return resp;
                }
                ValidarIdentidadRequest request = new ValidarIdentidadRequest()
                {
                    cedula = cedula,
                    asesor = asesor,
                    oficina = oficina,
                    producto = producto,
                    ticks = ticks,
                    idConvenio = null
                };
                Guid c = Guid.Empty;
                if (Guid.TryParse(idConvenio, out c))
                {
                    request.idConvenio = c;
                }
                return ValidarIdentidadP(request);
            }
            catch (Exception Ex)
            {
                try
                {
                    Trace.WriteLine("Error ValidarIdentidad: " + Ex.ToString());
                    LogErrores logErrores = new LogErrores
                    {
                        UsuarioLogin = null,
                        //Capa = "Servicio Local",
                        Metodo = "ValidarIdentidad",
                        Fecha = DateTime.Now,
                        Descripcion = Ex.ToString(),
                        Ip = ObtenerIP.GetIP2(),
                        Mac = ObtenerMac.GetMac2(),
                        IdOficina = null
                    };
                    InsertarLogError(logErrores);

                    RespuestaValidacion resp = new RespuestaValidacion
                    {
                        Respuesta = "Error",
                        Detalle = string.Format("Error al Validar Identidad")
                    };
                    return resp;
                }
                catch (Exception ex2)
                {
                    Trace.WriteLine("Error ValidarIdentidad - InsertarLogError: " + ex2.ToString());
                    RespuestaValidacion resp = new RespuestaValidacion
                    {
                        Respuesta = "Error",
                        Detalle = string.Format("Error al registrar el error")
                    };
                    return resp;
                }
            }
        }
        public RespuestaValidacion ValidarIdentidadP(ValidarIdentidadRequest request)
        {
            if (blnRegistraSistema)
            {
                string strNombreSO = obtenerSOCliente();
                this._logger.Information("Notaría: {@Notaria} | Convenio: {@Convenio} | Nombre SO: {@SO} | Version Agente: {@Version}", request.oficina, request.idConvenio, strNombreSO, Assembly.GetEntryAssembly().GetName().Version.ToString());
                blnRegistraSistema = false;
            }

            Trace.WriteLine($"DFZM 10VI: {request.cedula} | {request.asesor} | {request.oficina} | {request.producto} | {request.ticks}");

            Cors();

            try
            {
                IniciarVariablesGlobales();
            }
            catch (Exception ex)
            {
                return new RespuestaValidacion
                {
                    Respuesta = "Error",
                    Detalle = "Error al cargar parámetros",
                    Validado = false
                };
            }

            RespuestaValidacion resp = new RespuestaValidacion
            {
                Respuesta = "Ok",
                Detalle = "",
                Validado = false
            };

            try
            {
                //Validaciones
                Trace.WriteLine("DFZM 10VII: " + Capturando.ToString());
                string ip = ObtenerIpSolicitante();
                if (!Parametros.IPsPermitidas.Contains(ip))
                {
                    Trace.WriteLine("Peticion prohibida - acceso remoto deshabilitado: " + ip);
                    resp.Respuesta = "Error";
                    resp.Detalle = string.Format("Prohibido por politica - Ip Solicitante {0}", ip);
                    return resp;
                }

                if (_IdCliente == 0 || Parametros.ConvenioCliente == Guid.Empty)
                {
                    resp.Respuesta = "Error";
                    resp.Detalle = string.Format("Error Carga Variables Globales", request.cedula);
                    return resp;
                }

                if (Dedo1 == 0 || Dedo2 == 0)
                {
                    resp.Respuesta = "Error";
                    resp.Detalle = string.Format("No se han capturado las huellas", request.cedula);
                    return resp;
                }

                long numeroIdentificacion = 0;
                if (!long.TryParse(request.cedula, out numeroIdentificacion))
                {
                    resp.Respuesta = "Error";
                    resp.Detalle = string.Format("La cedula '{0}' no es un valor valido", request.cedula);
                    return resp;
                }
                //Se limpia el valor (posibles ceros al principio)
                request.cedula = numeroIdentificacion.ToString();

                //GTC - Se deja que por lo menos alguna de las huellas se encuentre dentro de los ultimos 5 minutos
                if ((DateTime.Now - HoraCaptura1) >= TimeSpan.FromMinutes(5) && (DateTime.Now - HoraCaptura2) >= TimeSpan.FromMinutes(5))
                //if ((DateTime.Now - HoraCaptura1) >= TimeSpan.FromMinutes(2) || (DateTime.Now - HoraCaptura2) >= TimeSpan.FromMinutes(2))
                {
                    resp.Respuesta = "Warning";
                    resp.Detalle = string.Format("El tiempo de vida de una o ambas huellas para el proceso expiró");
                    return resp;
                }

                if (Parametrizacion.ConsultarInyeccionHuellas(Dedos, request.cedula))
                {
                    resp.Respuesta = "Error";
                    resp.Detalle = "Error de inyección de huella";
                    return resp;
                }

                if (ValidarFueraHorarioOperacion())
                {
                    resp.Respuesta = "Error";
                    resp.Detalle = "La aplicación se encuentra por fuera del horario de operación";
                    return resp;
                }
                Guid IdPeticionVer = Guid.NewGuid();

                LogOperaciones LO;
                if (SwitchContingenciaUtil.OperadorAliadoActivo())
                    LO = ValidarIdentidadPContingencia(request, IdPeticionVer);
                else
                    LO = ValidarIdentidadPRS(request, IdPeticionVer);

                try
                {
                    if (blnRegistraSistema)
                    {
                        string strNombreSO = UtilSO.ObtenerSOCliente();
                        var version = Assembly.GetEntryAssembly().GetName().Version.ToString();
                        this._logger.Information("Notaría: {@Notaria} | Convenio: {@Convenio} | Nombre SO: {@SO} | Version Agente: {version}", request.oficina, request.idConvenio, strNombreSO, version);
                        blnRegistraSistema = false;
                    }
                }
                catch
                {
                }

                Trace.WriteLine("DFZM 18VI ce :" + LO.CodigoError);
                Trace.WriteLine("DFZM 18VI de :" + LO.DescripcionError);
                Trace.WriteLine("DFZM 18VI io :" + LO.IdOperacion);

                if (LO.IdOperacion != 0) //La transaccion fue exitosa
                {
                    resp.Respuesta = "Ok";
                    resp.NutValidacion = LO.IdOperacion;
                    resp.IdPeticion = IdPeticionVer;
                    if (LO.RespuestaAFI == "HIT")
                    {
                        resp.Validado = true;
                    }
                    else
                    {
                        resp.Validado = false;
                    }

                    resp.Documento = LO.Documento;
                    resp.TipoDocumento = LO.TipoDocumento;
                    resp.PrimerNombre = LO.PrimerNombre;
                    resp.SegundoNombre = LO.SegundoNombre;
                    resp.PrimerApellido = LO.PrimerApellido;
                    resp.SegundoApellido = LO.SegundoApellido;
                    resp.FechaExpedicion = LO.FechaExpedicion;

                    if (ConfigurationManager.AppSettings["VigenciaNombre"] != null)
                    {
                        resp.Vigencia = LO.Vigencia;
                    }
                    else
                    {
                        if (LO != null && LO.Vigencia != null)
                        {
                            resp.Vigencia = DevolverCodigoVigencia(LO.Vigencia);
                        }
                        else
                        {
                            resp.Vigencia = LO.Vigencia;
                        }
                    }

                    resp.Huellas = LO.HA;
                    LimpiarVariablesProceso();
                    Trace.WriteLine("DFZM 22VI");
                }
                else
                {
                    Trace.WriteLine("DFZM 22VII");
                    resp.Respuesta = "Error";
                    resp.Detalle = LO.DescripcionError;
                }
            }
            catch (EndpointNotFoundException Ex)
            {
                Trace.WriteLine($"DFZM 22VIII Err: {Ex}");
                LogLocal.GuardarLog(Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "ValidarIdentidadP",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);
                resp.Respuesta = "Error";
                resp.Detalle = "No se pudo  establecer conexión al servicio de la aplicación";
            }
            catch (ApplicationException ex)
            {
                Trace.WriteLine($"DFZM 22IX Err: {ex}");
                resp.Respuesta = "Error";
                resp.Detalle = ex.Message;
            }
            catch (Exception Ex)
            {
                Trace.WriteLine("DFZM 22X: " + Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "ValidarIdentidadP",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);
                resp.Respuesta = "Error";
                resp.Detalle = Ex.ToString();
            }
            return resp;
        }

        public RespuestaValidacion ValidarIdentidadSecu(string cedula, string asesor, string oficina, string producto, string ticks, string idConvenio)
        {
            try
            {
                bool getHabilitado = false;
                if (bool.TryParse(_habilitarGET, out getHabilitado) && !getHabilitado)
                {
                    Cors();
                    Trace.WriteLine("Peticion prohibida - Verbo GET deshabilitado");
                    RespuestaValidacion resp = new RespuestaValidacion
                    {
                        Respuesta = "Error",
                        Detalle = string.Format("Prohibido por politica - Verbo GET deshabilitado")
                    };
                    return resp;
                }
                ValidarIdentidadSecuRequest request = new ValidarIdentidadSecuRequest()
                {
                    cedula = cedula,
                    asesor = asesor,
                    oficina = oficina,
                    producto = producto,
                    token = WebOperationContext.Current.IncomingRequest.Headers["token"],
                    ticks = ticks,
                    idConvenio = null
                };
                Guid c;
                if (Guid.TryParse(idConvenio, out c))
                {
                    request.idConvenio = c;
                }
                return ValidarIdentidadSecuP(request);
            }
            catch (Exception Ex)
            {
                Trace.WriteLine("Error ValidarIdentidadSecu: " + Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "ValidarIdentidadSecu",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);

                RespuestaValidacion resp = new RespuestaValidacion
                {
                    Respuesta = "Error",
                    Detalle = string.Format("Error al Validar Identidad")
                };
                return resp;
            }
        }

        public RespuestaValidacion ValidarIdentidadSecuP(ValidarIdentidadSecuRequest request)
        {
            string cedula = request.cedula;
            string asesor = request.asesor;
            string oficina = request.oficina;
            string producto = request.producto;
            string ticks = request.ticks;
            string token = request.token;

            Cors();

            RespuestaValidacion resp = new RespuestaValidacion
            {
                Respuesta = "Ok",
                Detalle = "",
                Validado = false
            };

            try
            {
                //Cargar Parametros
                IniciarVariablesGlobales();
            }
            catch
            {
                resp.Respuesta = "Error";
                resp.Detalle = string.Format("Error al cargar los parametros");
                return resp;
            }


            //Validaciones
            Trace.WriteLine("DFZM 10VII: " + Capturando.ToString());
            string ip = ObtenerIpSolicitante();
            if (!Parametros.IPsPermitidas.Contains(ip))
            {
                Trace.WriteLine("Peticion prohibida - acceso remoto deshabilitado: " + ip);
                resp.Respuesta = "Error";
                resp.Detalle = string.Format("Prohibido por politica - Ip Solicitante {0}", ip);
                return resp;
            }

            if (_IdCliente == 0 || Parametros.ConvenioCliente == Guid.Empty)
            {
                resp.Respuesta = "Error";
                resp.Detalle = string.Format("Error Carga Variables Globales", cedula);
                return resp;
            }

            if (Dedo1 == 0 || Dedo2 == 0)
            {
                resp.Respuesta = "Error";
                resp.Detalle = string.Format("No se han capturado las huellas", cedula);
                return resp;
            }

            long numeroIdentificacion = 0;
            if (!long.TryParse(cedula, out numeroIdentificacion))
            {
                resp.Respuesta = "Error";
                resp.Detalle = string.Format("La cedula '{0}' no es un valor valido", cedula);
                return resp;
            }

            //GTC - Se deja que po lo menos alguna de las huellas se encuentre dentro de los ultimos 5 minutos
            if ((DateTime.Now - HoraCaptura1) >= TimeSpan.FromMinutes(5) && (DateTime.Now - HoraCaptura2) >= TimeSpan.FromMinutes(5))
            //if ((DateTime.Now - HoraCaptura1) >= TimeSpan.FromMinutes(2) || (DateTime.Now - HoraCaptura2) >= TimeSpan.FromMinutes(2))
            {
                resp.Respuesta = "Warning";
                resp.Detalle = string.Format("El tiempo de vida de una o ambas huellas para el proceso expiró");
                return resp;
            }

            cedula = numeroIdentificacion.ToString(); //Se limpia el valor (posibles ceros al principio)

            try
            {
                Trace.WriteLine("DFZM 10VIS: " + cedula + " | " + asesor + " | " + token + " | " + oficina + " | " + producto + " | " + ticks);

                var servicios = new ConsumirServicio();
                Olimpia.Servicios.ServicioFachadaZeus.RespuestaUsuario ru = servicios.ValidarToken(asesor, token, _IdCliente);

                if (ru != null)
                {
                    var usuarioSistema = servicios.ValidarUsuario(asesor, _IdCliente);
                    long res = 0;

                    if (!ru.Habilitado)
                    {
                        if (usuarioSistema != null)
                        {
                            //deshabilitar usuario
                            Usuario usuario = new Usuario()
                            {
                                Area = usuarioSistema.Area == null ? "Atencion al cliente" : usuarioSistema.Area,
                                Cargo = usuarioSistema.Cargo == null ? "Asesor" : usuarioSistema.Cargo,
                                usuario = asesor,
                                Habilitado = false,
                                IdOficina = usuarioSistema.IdOficina,
                                TipoIdentificacion = usuarioSistema.TipoIdentificacion,
                                Nombre = ru.Nombre,
                                NumeroIdentificacion = ru.NumeroIdentificacion
                            };
                            res = servicios.CrearActualizarUsuario(usuario, _IdCliente);
                        }
                    }
                    else
                    {
                        if (usuarioSistema == null)
                        {
                            // crear/habilitar usuario
                            Usuario usuario = new Usuario()
                            {
                                Area = "Atencion al cliente",
                                Cargo = "Asesor",
                                usuario = asesor,
                                Habilitado = true,
                                IdOficina = oficina,
                                TipoIdentificacion = "CC",
                                Nombre = ru.Nombre,
                                NumeroIdentificacion = ru.NumeroIdentificacion
                            };
                            res = servicios.CrearActualizarUsuario(usuario, _IdCliente);
                        }
                        if (res == 0)
                        {
                            ValidarIdentidadRequest nRequest = new ValidarIdentidadRequest()
                            {
                                cedula = cedula,
                                asesor = asesor,
                                oficina = oficina,
                                producto = producto,
                                ticks = ticks,
                            };
                            return ValidarIdentidadP(nRequest);
                        }
                        resp.Detalle = "Fallo al crear el usuario, verifique la oficina";
                    }
                }
                else
                {
                    resp.Detalle = "Falló verificación usuario o token.";
                }

                Trace.WriteLine("Falló verificación usuario o token");
                resp.Respuesta = "Error";
                return resp;
            }
            catch (Exception Ex)
            {
                Trace.WriteLine("DFZM VIS: " + Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "ValidarIdentidadSecuP",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);
                resp.Respuesta = "Error";
                resp.Detalle = Ex.ToString();
                return resp;
            }
        }

        public RespuestaObtenerFormato ObtenerFormatoAutorizacion(string cedula, string ticks, string idConvenio)
        {
            try
            {
                bool getHabilitado = false;
                if (bool.TryParse(_habilitarGET, out getHabilitado) && !getHabilitado)
                {
                    Cors();
                    Trace.WriteLine("Peticion prohibida - Verbo GET deshabilitado");
                    RespuestaObtenerFormato resp = new RespuestaObtenerFormato
                    {
                        Respuesta = "Error",
                        Detalle = string.Format("Prohibido por politica - Verbo GET deshabilitado")
                    };
                    return resp;
                }
                ObtenerFormatoAutorizacionRequest request = new ObtenerFormatoAutorizacionRequest()
                {
                    cedula = cedula,
                    ticks = ticks,
                    idConvenio = null
                };
                Guid c;
                if (Guid.TryParse(idConvenio, out c))
                {
                    request.idConvenio = c;
                }
                return ObtenerFormatoAutorizacionP(request);
            }
            catch (Exception Ex)
            {
                Trace.WriteLine("Error ObtenerFormatoAutorizacion: " + Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "ObtenerFormatoAutorizacion",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);

                RespuestaObtenerFormato resp = new RespuestaObtenerFormato
                {
                    Respuesta = "Error",
                    Detalle = string.Format("Error al Obtener Formato Autorizacion")
                };
                return resp;
            }
        }

        public RespuestaObtenerFormato ObtenerFormatoAutorizacionP(ObtenerFormatoAutorizacionRequest request)
        {
            string cedula = request.cedula;
            string ticks = request.ticks;
            Guid? convenio = request.idConvenio;
            Trace.WriteLine("DFZM 10FA: " + cedula + " | " + ticks);

            Cors();

            RespuestaObtenerFormato resp = new RespuestaObtenerFormato
            {
                Respuesta = "Ok",
                Detalle = "",
                TextoFormato = ""
            };

            try
            {
                //Cargar Parametros
                IniciarVariablesGlobales();
            }
            catch
            {
                resp.Respuesta = "Error";
                resp.Detalle = "Error al cargar los parámetros";
                return resp;
            }

            try
            {
                Trace.WriteLine("DFZM 10FB: " + Capturando.ToString());
                string ip = ObtenerIpSolicitante();
                if (Parametros.IPsPermitidas != null && !Parametros.IPsPermitidas.Contains(ip))
                {
                    Trace.WriteLine("Peticion prohibida - acceso remoto deshabilitado: " + ip);
                    resp.Respuesta = "Error";
                    resp.Detalle = string.Format("Prohibido por politica - Ip Solicitante {0}", ip);
                    return resp;
                }

                resp.TextoFormato = _convenios.Where(c => c.idConvenio == (convenio ?? Parametros.ConvenioCliente)).Select(c => c.textoAutorizacion).FirstOrDefault();
                if (string.IsNullOrEmpty(resp.TextoFormato))
                {
                    resp.Respuesta = "Error";
                    resp.Detalle = "No se encontró texto";
                }
            }
            catch (EndpointNotFoundException Ex)
            {
                Trace.WriteLine("DFZM F: " + Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "ObtenerFormatoAutorizacionP",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);
                LogLocal.GuardarLog(Ex.ToString());
                resp.Respuesta = "Error";
                resp.Detalle = "No se pudo establecer conexión al servicio de la aplicación";
            }
            catch (Exception Ex)
            {
                Trace.WriteLine("DFZM F: " + Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "ObtenerFormatoAutorizacionP",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);
                LogLocal.GuardarLog(Ex.ToString());
                resp.Respuesta = "Error";
                resp.Detalle = Ex.ToString();
            }

            return resp;
        }

        public RespuestaGenerarAutorizacion GenerarAutorizacion(string cedula, string asesor, string oficina, string producto, string ticks, string idConvenio)
        {
            try
            {
                bool getHabilitado = false;
                if (bool.TryParse(_habilitarGET, out getHabilitado) && !getHabilitado)
                {
                    Cors();
                    Utilidades.LogLocal.GuardarLog("Peticion prohibida - Verbo GET deshabilitado");
                    RespuestaGenerarAutorizacion resp = new RespuestaGenerarAutorizacion
                    {
                        Respuesta = "Error",
                        Detalle = string.Format("Prohibido por politica - Verbo GET deshabilitado")
                    };
                    return resp;
                }
                GenerarAutorizacionRequest request = new GenerarAutorizacionRequest()
                {
                    cedula = cedula,
                    asesor = asesor,
                    oficina = oficina,
                    producto = producto,
                    ticks = ticks,
                    idConvenio = null
                };
                Guid c;
                if (Guid.TryParse(idConvenio, out c))
                {
                    request.idConvenio = c;
                }
                return GenerarAutorizacionP(request);
            }
            catch (Exception Ex)
            {
                Utilidades.LogLocal.GuardarLog("Error RespuestaGenerarAutorizacion: " + Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "RespuestaGenerarAutorizacion",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);

                RespuestaGenerarAutorizacion resp = new RespuestaGenerarAutorizacion
                {
                    Respuesta = "Error",
                    Detalle = string.Format("Error al Obtener Respuesta Generar Autorizacion")
                };
                return resp;
            }
        }

        public RespuestaGenerarAutorizacion GenerarAutorizacionP(GenerarAutorizacionRequest request)
        {
            try
            {
                string cedula = request.cedula;
                string asesor = request.asesor;
                string oficina = request.oficina;
                string producto = request.producto;
                string ticks = request.ticks;

                Utilidades.LogLocal.GuardarLog("DFZM 10GA: " + cedula + " | " + asesor + " | " + oficina + " | " + producto + " | " + ticks);

                Cors();
                RespuestaGenerarAutorizacion resp = new RespuestaGenerarAutorizacion
                {
                    Respuesta = "Ok",
                    Detalle = "",
                    Calidad = 0,
                    NutFormato = 0
                };

                try
                {
                    //Cargar Parametros
                    IniciarVariablesGlobales();
                }
                catch
                {
                    resp.Respuesta = "Error";
                    resp.Detalle = "Error al obtener parámetros";
                    return resp;
                }

                //Un nuevo formato es un nuevo proceso
                LimpiarVariablesProceso();



                Utilidades.LogLocal.GuardarLog("DFZM 10GB: " + Capturando.ToString());
                string ip = ObtenerIpSolicitante();
                if (!Parametros.IPsPermitidas.Contains(ip))
                {
                    Utilidades.LogLocal.GuardarLog("Peticion prohibida - acceso remoto deshabilitado: " + ip);
                    resp.Respuesta = "Error";
                    resp.Detalle = string.Format("Prohibido por politica - Ip Solicitante {0}", ip);
                    return resp;
                }

                //No se esta firmando
                //[SinFirma]
                return resp;
            }
            catch (Exception Ex)
            {
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "GenerarAutorizacionP",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);

                RespuestaGenerarAutorizacion resp = new RespuestaGenerarAutorizacion
                {
                    Respuesta = "Ok",
                    Detalle = "",
                    Calidad = 0,
                    NutFormato = 0
                };

                Utilidades.LogLocal.GuardarLog("Error GenerarAutorizacionP: " + Ex.ToString());
                resp.Respuesta = "Error";
                resp.Detalle = string.Format("Error en Generar Autorización");
                return resp;
            }
        }

        public void CancelarCaptura(string ticks)
        {
            try
            {
                bool getHabilitado = false;
                if (bool.TryParse(_habilitarGET, out getHabilitado) && !getHabilitado)
                {
                    Cors();
                    Trace.WriteLine("Peticion prohibida - Verbo GET deshabilitado");
                    return;
                }
                CancelarCapturaRequest request = new CancelarCapturaRequest()
                {
                    ticks = ticks
                };
                CancelarCapturaP(request);
            }
            catch (Exception Ex)
            {
                Trace.WriteLine("Error CancelarCaptura: " + Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "CancelarCaptura",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);
            }
        }
        public void CancelarCapturaP(CancelarCapturaRequest request)
        {
            try
            {
                string ticks = request.ticks;
                Trace.WriteLine("DFZM 10CC: " + ticks);

                Cors();

                Trace.WriteLine("DFZM 10FB: " + Capturando.ToString());
                /*string ip = ObtenerIpSolicitante();
                if (!ips_permitidas.Contains(ip))
                {
                    Trace.WriteLine("Peticion prohibida - acceso remoto deshabilitado: " + ip);
                    return;
                }*/

                Morpho CapturaM = new Morpho(Parametros.HC, Parametros.HK, Parametros.CA, Parametros.DK);
                CapturaM.CancelarCaptura();
                CapturaM = null;
            }
            catch (Exception Ex)
            {
                Trace.WriteLine("DFZM 11CC: " + Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "CancelarCapturaP",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);
            }
        }

        public RespuestaConsultaEstado ConsultarEstado()
        {
            Cors();
            RespuestaConsultaEstado estado = new RespuestaConsultaEstado();
            estado.Estado = "OK";
            estado.Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
            estado.Propiedades = new Dictionary<string, string>();
            try
            {
                estado.Propiedades.Add("IPLocal", ObtenerIP.GetIP2());
            }
            catch
            {
                estado.Propiedades.Add("IPLocal", "ERROR");
            }

            try
            {
                estado.Propiedades.Add("MacAddress", ObtenerMac.GetMac2());
            }
            catch
            {
                estado.Propiedades.Add("MacAddress", "ERROR");
            }

            try
            {
                WacomDevice.ComprobarServiciosWacom();
            }
            catch (Exception ex)
            {
                WacomDevice.EscribirEnLog($"WacomCheckProcessException: {ex.Message}", EventLogEntryType.Error);
            }

            try
            {
                IDispositivo dev = Base.ObtenerDispositivo(Base.DeviceType.MorphoSinVentana);
                if (dev == null)
                    estado.Propiedades.Add("CaptorDetectado", "null");
                else
                    estado.Propiedades.Add("CaptorDetectado", dev.DetectarDispositivo().ToString().ToLower());
            }
            catch (Exception ex)
            {
                estado.Propiedades.Add("CaptorDetectado", "ERROR");
            }
            try
            {
                estado.Propiedades.Add("WacomSTUSigCaptX", DevicesValidator.WacomValidator.GetEstadoServicioWacomSTU().ToString());
            }
            catch
            {
                estado.Propiedades.Add("WacomSTUSigCaptX", "ERROR");
            }
            try
            {
                estado.Propiedades.Add("IsWacomDllRegistered", DevicesValidator.WacomValidator.IsWacomDllRegistered() == true ? "1" : "0");
            }
            catch
            {
                estado.Propiedades.Add("IsWacomDllRegistered", "0");
            }
            try
            {
                estado.Propiedades.Add("OperadorActivo", SwitchContingenciaUtil.OperadorAliadoActivo() ? "Contingencia" : "Olimpia");
            }
            catch (Exception ex)
            {
                estado.Propiedades.Add("OperadorActivo", $"Error al consultar el operador: {ex}");
            }

            Utilidades.LogLocal.GuardarLog("Estado COnsultado OK");
            return estado;
        }

        public void GetOptions()
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", origen);
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "POST, GET, OPTIONS");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Cache-Control, Token");
        }
        #endregion

        private LogOperaciones ValidarIdentidadPRS(ValidarIdentidadRequest request, Guid IdPeticionVer)
        {
            string cedula = request.cedula;
            string asesor = request.asesor;
            string oficina = request.oficina;
            string producto = request.producto;
            string ticks = request.ticks;
            string grafo = request.grafo;
            Guid? convenio = request.idConvenio;

            RespuestaValidacion resp = new RespuestaValidacion
            {
                Respuesta = "Ok",
                Detalle = "",
                Validado = false
            };
            Trace.WriteLine("DFZ 11RS");

            var servicios = new ConsumirServicio();

            asesor = asesor.Trim();
            var usuarioSistema = servicios.ValidarUsuario(asesor, _IdCliente);

            if (usuarioSistema == null)
                throw new ApplicationException(string.Format("El usuario '{0}' no se encuentra registrado / activo en el sistema", asesor));


            Trace.WriteLine("DFZM 12e:");
            var oficinasSistema = Parametrizacion.ConsultarTodosOficinas(false, _IdCliente);

            if (oficinasSistema == null || oficinasSistema.Lista == null || oficinasSistema.Lista.Count == 0)
                throw new ApplicationException(string.Format("No se encontraron oficinas en el sistema", asesor));


            Trace.WriteLine("DFZM 13e:");

            var oficinaPeticion = oficinasSistema.Lista.Where(x => x.IdOficina == oficina).FirstOrDefault();

            if (oficinaPeticion == null)
                throw new ApplicationException(string.Format("La oficina '{0}' no se encuentra registrada en el sistema", oficina));

            Parametros.Oficina = oficinaPeticion;

            Trace.WriteLine("DFZM 12e 2 :" + oficinaPeticion.IdOficina);
            Trace.WriteLine("DFZM 12e 3 :" + oficinaPeticion.Codigo);

            Trace.WriteLine("DFZM 14e:");
            var productosSistema = Parametrizacion.ConsultarTodosProductos(false, _IdCliente);

            if (productosSistema == null || productosSistema.Lista == null || productosSistema.Lista.Count == 0)
                throw new ApplicationException(string.Format("No se encontraron productos en el sistema", asesor));

            Parametros.Productos = productosSistema;

            Trace.WriteLine("DFZM 15e:");

            var productoPeticion = productosSistema.Lista.Where(x => x.Codigo == producto).FirstOrDefault();
            if (productoPeticion == null)
                throw new ApplicationException(string.Format("El producto '{0}' no se encuentra registrado en el sistema", producto));

            Trace.WriteLine("DFZM 16VI cod :" + productoPeticion.Codigo);
            Trace.WriteLine("DFZM 16VI des :" + productoPeticion.Descripcion);
            Trace.WriteLine("DFZM 16VI idser :" + productoPeticion.IdServicio);
            Trace.WriteLine($"DFZM 17VI CC: {Parametros.ConvenioCliente} C: {convenio}");

            //Fin Validaciones

            //Firma Documento Autorizacion
            //[SinFirma]
            Trace.WriteLine("DFZM 17VI COnv :" + convenio);
            Trace.WriteLine("DFZM 17VI COnvCC :" + Parametros.ConvenioCliente);

            RespuestaFormatos formatoAut = servicios.ObtenerFormatoProteccionDatos(_IdCliente, convenio ?? Parametros.ConvenioCliente);
            if (formatoAut.Archivo == null)
                throw new ApplicationException(string.Format("No se encontró formato de protección de datos para ese convenio"));

            Parametros.ATDP = formatoAut.Archivo;

            Trace.WriteLine("DFZM 18VI if :" + formatoAut.Archivo.Length);
            Trace.WriteLine("DFZM 18VI if1 :" + oficinaPeticion.IdOficina);
            Trace.WriteLine("DFZM 18VI if2 :" + productoPeticion.IdProducto);
            Trace.WriteLine("DFZM 18VI if3 :" + asesor);


            long IdAutorizacion = 0;

            if (string.IsNullOrEmpty(grafo) || grafo == "null")
            {
                IdAutorizacion = servicios.CrearAutorizacionCandidato(true, formatoAut.Archivo, oficinaPeticion.IdOficina, productoPeticion.IdProducto,
                 null, ObtenerIP.GetIP2(), asesor, cedula, "CC", new byte[0], _IdCliente, convenio ?? Parametros.ConvenioCliente, IdPeticionVer);
            }
            else
            {
                var archivo = UtilFormato.AgregarInfo(formatoAut.Archivo, cedula, string.Format("{0} - {1}", oficinaPeticion.Codigo, oficina), string.Format("{0} - {1}", productoPeticion.Codigo, productoPeticion.Descripcion), asesor, oficinaPeticion.Ciudad);

                IdAutorizacion = servicios.CrearAutorizacionCandidato(true, archivo, oficinaPeticion.IdOficina, productoPeticion.IdProducto,
                 Convert.FromBase64String(grafo), ObtenerIP.GetIP2(), asesor, cedula, "CC", null, _IdCliente, convenio ?? Parametros.ConvenioCliente, IdPeticionVer);
            }

            //Fin Firma Documento

            string tramite = productoPeticion.Codigo + "|" + oficinaPeticion.Codigo;

            GuardarDedos();

            string auxSerial = ObtenerSerial();

            Trace.WriteLine("DFZM 20VI");

            var LO = servicios.VerificarIdentidad(_IdCliente, convenio ?? Parametros.ConvenioCliente, asesor, oficinaPeticion.IdOficina,
                  productoPeticion.IdProducto, tramite, "CC", cedula, Dedos, ObtenerIP.GetIP2(), ObtenerMac.GetMac2(),
                  auxSerial, _Marca, _Modelo, _TipoBiometrico, IdAutorizacion, productoPeticion.IdServicio, IdPeticionVer);

            Trace.WriteLine($"DFZM 21VI: {LO.CodigoError}");

            GuardarParametros();

            return LO;
        }

        private string ObtenerSerial()
        {
            string auxSerial = _Serial;
            int idx = auxSerial.IndexOf('=');
            if (idx != -1)
            {
                auxSerial = auxSerial.Remove(0, auxSerial.IndexOf('=') + 1);
            }

            idx = auxSerial.IndexOf(';');
            if (idx != -1)
            {
                auxSerial = auxSerial.Remove(auxSerial.IndexOf(';'));
            }

            auxSerial = "P/N: " + auxSerial.Replace("-", " S/N: ");
            return auxSerial;
        }


        private string obtenerSOCliente()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
            }
            return result;
        }


        private LogOperaciones ValidarIdentidadPContingencia(ValidarIdentidadRequest request, Guid IdPeticionVer)
        {
            Trace.WriteLine("DFZ CT11:");
            string cedula = request.cedula;
            string asesor = request.asesor;
            string oficina = request.oficina;
            string producto = request.producto;
            string ticks = request.ticks;
            string grafo = request.grafo;
            Guid? convenio = request.idConvenio;

            IniciarVariablesGlobalesContingencia();

            RespuestaValidacion resp = new RespuestaValidacion
            {
                Respuesta = "Ok",
                Detalle = "",
                Validado = false
            };

            var servicios = new ServicioContingencia(_logger);

            asesor = asesor.Trim();
            if (!servicios.ValidarUsuario(asesor, _IdCliente))
                throw new ApplicationException(string.Format("El usuario '{0}' no se encuentra habilitado para contingencia en este equipo", asesor));

            Trace.WriteLine("DFZM CT13e:");

            var oficinaPeticion = Parametros.Oficina;
            if (oficinaPeticion == null || oficinaPeticion.IdOficina != oficina)
                throw new ApplicationException(string.Format("La oficina '{0}' no se encuentra habilitado para contingencia en este equipo", oficina));

            Trace.WriteLine("DFZM CT12e 2 :" + oficinaPeticion.IdOficina);
            Trace.WriteLine("DFZM CT12e 3 :" + oficinaPeticion.Codigo);

            Trace.WriteLine("DFZM CT14e:");
            var productosSistema = Parametros.Productos;

            if (productosSistema == null || productosSistema.Lista == null || productosSistema.Lista.Count == 0)
                throw new ApplicationException(string.Format("No se encontraron productos en el sistema para contingencia"));

            Parametros.Productos = productosSistema;

            Trace.WriteLine("DFZM CT15e:");

            var productoPeticion = productosSistema.Lista.Where(x => x.Codigo == producto).FirstOrDefault();
            if (productoPeticion == null)
                throw new ApplicationException(string.Format("El producto '{0}' no se encuentra registrado en el sistema", producto));

            Trace.WriteLine("DFZM CT16VI cod :" + productoPeticion.Codigo);
            Trace.WriteLine("DFZM CT16VI des :" + productoPeticion.Descripcion);
            Trace.WriteLine("DFZM CT16VI idser :" + productoPeticion.IdServicio);
            Trace.WriteLine($"DFZM CT17VI CC: {Parametros.ConvenioCliente} C: {convenio}");

            //Fin Validaciones

            //Firma Documento Autorizacion
            if (Parametros.ATDP == null)
                throw new ApplicationException(string.Format("No se encontró formato de protección de datos para ese convenio en contingencia"));

            Trace.WriteLine("DFZM CT18VI if :" + Parametros.ATDP.Length);
            Trace.WriteLine("DFZM CT18VI if1 :" + oficinaPeticion.IdOficina);
            Trace.WriteLine("DFZM CT18VI if2 :" + productoPeticion.IdProducto);
            Trace.WriteLine("DFZM CT18VI if3 :" + asesor);

            byte[] bGrafo;
            if (!string.IsNullOrEmpty(grafo))
                bGrafo = Convert.FromBase64String(grafo);
            else
                bGrafo = null;

            var mATDP = (byte[])Parametros.ATDP.Clone();
            mATDP = servicios.FirmarATDP(true, mATDP, oficinaPeticion, productoPeticion,
                bGrafo, asesor, cedula, IdPeticionVer, Parametros);

            Trace.WriteLine("DFZM CT19VI atdp :" + mATDP.Length);

            string tramite = productoPeticion.Codigo + "|" + oficinaPeticion.Codigo;

            GuardarDedos();

            string auxSerial = ObtenerSerial();

            DatosPeticionRS datos = new DatosPeticionRS()
            {
                Asesor = asesor,
                Convenio = convenio ?? Parametros.ConvenioCliente,
                Documento = cedula,
                IdCliente = _IdCliente,
                IdOficina = oficinaPeticion.IdOficina,
                IdPeticion = IdPeticionVer,
                IdProducto = productoPeticion.IdProducto,
                IdServicio = productoPeticion.IdServicio,
                IP = ObtenerIP.GetIP2(),
                Mac = ObtenerMac.GetMac2(),
                Serial = auxSerial,
                Tramite = tramite,
                Marca = _Marca,
                Modelo = _Modelo,
                TipoBiometrico = _TipoBiometrico,
                TipoDocumento = "CC"
            };

            var LO = servicios.VerificarIdentidad(_IdCliente, convenio ?? Parametros.ConvenioCliente, asesor, oficinaPeticion,
                  productoPeticion, "CC", cedula, Dedos, ObtenerIP.GetIP2(), ObtenerMac.GetMac2(), auxSerial, IdPeticionVer, Parametros);

            Trace.WriteLine($"DFZM CT21VI: {LO.CodigoError}");
            servicios.GuardarPeticionAzure(datos, LO, mATDP, Parametros);
            Trace.WriteLine($"DFZM CT22VI:");
            return LO;
        }


        private void GuardarDedos()
        {
            SimpleAES SAE = new SimpleAES();
            Dedos.Clear();

            string t1, t2;
            if (string.IsNullOrEmpty(Parametros.DK))
            {
                t1 = SAE.EncryptToString(UtilidadesHuellas.ConvertirTemplateToB64(Template1));
                t2 = SAE.EncryptToString(UtilidadesHuellas.ConvertirTemplateToB64(Template2));
            }
            else
            {
                t1 = Convert.ToBase64String(SAE.Encrypt(Template1));
                t2 = Convert.ToBase64String(SAE.Encrypt(Template2));
            }
            Dedos.Add(new HuellaAFI
            {
                NumeroDedo = Dedo1,
                NombreDedo = UtilidadesHuellas.NombreDedo(Dedo1),
                Template = t1,
                RespuestaAFI = "APROBADA"
            });

            Dedos.Add(new HuellaAFI
            {
                NumeroDedo = Dedo2,
                NombreDedo = UtilidadesHuellas.NombreDedo(Dedo2),
                Template = t2,
                RespuestaAFI = "APROBADA"
            });

            if (!string.IsNullOrEmpty(Parametros.DK))
            {
                Biometria.Format = "ISO-FMR-1EN";
            }
        }

        private void InsertarLogError(LogErrores logErrores)
        {
            var servicios = new ConsumirServicio();
            servicios.InsertarLogError(logErrores, _IdCliente);
        }

        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        #region Fixed para Contingencia

        private string ObtenerIpSolicitante()
        {
            string address = string.Empty;

            try
            {
                OperationContext context = OperationContext.Current;
                MessageProperties properties = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

                if (properties.Keys.Contains(HttpRequestMessageProperty.Name))
                {
                    HttpRequestMessageProperty endpointLoadBalancer = properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                    if (endpointLoadBalancer != null && endpointLoadBalancer.Headers["X-Forwarded-For"] != null)
                    {
                        address = endpointLoadBalancer.Headers["X-Forwarded-For"];
                    }
                }
                if (string.IsNullOrEmpty(address))
                {
                    address = endpoint.Address;
                }

                return address;
            }
            catch (Exception Ex)
            {
                Trace.WriteLine("DFZM OIS: " + Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "ObtenerIpSolicitante",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);
                return address;
            }
        }

        private void IniciarVariablesGlobales()
        {
            if (_IdCliente != 0 && Parametros.ConvenioCliente != Guid.Empty && (DateTime.Now - Parametros.FechaRegistro).TotalDays < 1)
                return;

            try
            {
                if (!SwitchContingenciaUtil.IntegracionOperadorAliadoActiva || !SwitchContingenciaUtil.OperadorAliadoActivo())
                    IniciarVariablesGlobalesRS();
                else
                    IniciarVariablesGlobalesContingencia();
            }
            catch (CommunicationObjectFaultedException ExCom)
            {
                Parametros.ConvenioCliente = Guid.Empty;
                Trace.WriteLine("DFZM IVG: Error de comunicacion: " + ExCom.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "IniciarVariablesGlobales",
                    Fecha = DateTime.Now,
                    Descripcion = "Error de comunicacion: " + ExCom.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);
                throw new Exception("Error de comunicacion: " + ExCom.ToString());
            }
            catch (Exception Ex)
            {
                Parametros.ConvenioCliente = Guid.Empty;
                Trace.WriteLine("DFZM IVG: " + Ex.ToString());
                LogErrores logErrores = new LogErrores
                {
                    UsuarioLogin = null,
                    //Capa = "Servicio Local",
                    Metodo = "IniciarVariablesGlobales",
                    Fecha = DateTime.Now,
                    Descripcion = Ex.ToString(),
                    Ip = ObtenerIP.GetIP2(),
                    Mac = ObtenerMac.GetMac2(),
                    IdOficina = null
                };
                InsertarLogError(logErrores);
                throw new Exception("Error general: " + Ex.ToString());
            }
        }

        public static ParametrosOperacion ObtenerParametrosArchivo()
        {
            if (!File.Exists(sParametrosFile))
                throw new ApplicationException("No hay información de parametrización para operar en contingencia");
            else
            {
                try
                {
                    ParametrosOperacion po = Cifrado.DecryptFromFile<ParametrosOperacion>(sParametrosFile);
                    int days = 0;
                    int.TryParse(ConfigurationManager.AppSettings["DiasParametrosCt"], out days);

                    if (days > 0 && (DateTime.Now - po.FechaRegistro).TotalDays > days)
                        throw new ApplicationException("La parametrización para operar en contingencia ha expirado");
                    else
                        return po;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al consultar parametrización para operar en contingencia", ex);
                }
            }
        }

        public static int IdCliente => _IdCliente;

        private void IniciarVariablesGlobalesContingencia()
        {
            Parametros = ObtenerParametrosArchivo();
        }

        private void IniciarVariablesGlobalesRS()
        {

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;// | SecurityProtocolType.Tls;

            var p = Parametrizacion.ConsultarTodosParametros(false, _IdCliente);

            Trace.WriteLine("DFZM IVG");

            if (p.Lista.FirstOrDefault(x => x.Parametro == "Convenio") != null)
                Parametros.ConvenioCliente = Guid.Parse(p.Lista.FirstOrDefault(x => x.Parametro == "Convenio").Valor);

            if (p.Lista.FirstOrDefault(x => x.Parametro == "Convenio") != null)
                Parametros.ConvenioCliente = Guid.Parse(p.Lista.FirstOrDefault(x => x.Parametro == "Convenio").Valor);

            //Parametros para operacion en contingencia
            if (p.Lista.FirstOrDefault(x => x.Parametro == "Score") != null)
                Parametros.Score = int.Parse(p.Lista.FirstOrDefault(x => x.Parametro == "Score").Valor);
            else
                Parametros.Score = 27;
            if (p.Lista.FirstOrDefault(x => x.Parametro == "DedosHit") != null)
                Parametros.DedosHit = int.Parse(p.Lista.FirstOrDefault(x => x.Parametro == "DedosHit").Valor);
            else
                Parametros.DedosHit = 1;
            if (p.Lista.FirstOrDefault(x => x.Parametro == "IdOperadorContingencia") != null)
                Parametros.IdOperadorContingencia = p.Lista.FirstOrDefault(x => x.Parametro == "IdOperadorContingencia").Valor;
            else
                Parametros.IdOperadorContingencia = "OPOLIM02";
            if (p.Lista.FirstOrDefault(x => x.Parametro == "CadenaDeConexionArchivos") != null)
                Parametros.CadenaConexionAzure = p.Lista.FirstOrDefault(x => x.Parametro == "CadenaDeConexionArchivos").Valor;
            if (p.Lista.FirstOrDefault(x => x.Parametro == "URLEstampado") != null)
                Parametros.URLEstampa = p.Lista.FirstOrDefault(x => x.Parametro == "URLEstampado").Valor;
            if (p.Lista.FirstOrDefault(x => x.Parametro == "UserEstampado") != null)
                Parametros.UsuarioEstampa = p.Lista.FirstOrDefault(x => x.Parametro == "UserEstampado").Valor;
            if (p.Lista.FirstOrDefault(x => x.Parametro == "PwdEstampado") != null)
            {
                SimpleAES aes = new SimpleAES();
                Parametros.ClaveEstampa = aes.DecryptString(p.Lista.FirstOrDefault(x => x.Parametro == "PwdEstampado").Valor);
            }

            var cert = Biometria.ObtenerCertificado(_IdCliente);
            if (cert != null)
            {
                Parametros.HC = (byte[])cert.Certificado.Clone();
                Parametros.HK = Convert.FromBase64String(p.Lista.FirstOrDefault(x => x.Parametro == "HK").Valor);
                Parametros.CA = Convert.FromBase64String(p.Lista.FirstOrDefault(x => x.Parametro == "CA").Valor);
            }

            var encKey = p.Lista.FirstOrDefault(x => x.Parametro == "Llave1EN");
            if (encKey != null)
                Parametros.DK = encKey.Valor;


            var ipsPermitidas = p.Lista.Where(x => x.Parametro == "ipsPermitidas").Select(x => x.Valor).FirstOrDefault();

            Parametros.IPsPermitidas = new List<string>(ips_locales);

            if (!string.IsNullOrEmpty(ipsPermitidas))
                Parametros.IPsPermitidas.AddRange(ipsPermitidas.Split(new char[] { ';' }));

            Parametros.HoraInicioOperacion = p.Lista.FirstOrDefault(x => x.Parametro == "HoraInicionOperacion").Valor.ToString();
            Parametros.HoraFinOperacion = p.Lista.FirstOrDefault(x => x.Parametro == "HorafinOperacion").Valor.ToString();



            //try
            //{
            //    _convenios = Parametrizacion.ConsultarConvenios(_IdCliente);
            //}
            //catch (Exception Ex)
            //{
            //    Trace.WriteLine("DFZM IVGII: " + Ex.ToString());
            //    LogErrores logErrores = new LogErrores
            //    {
            //        UsuarioLogin = null,
            //        Capa = "Servicio Local",
            //        Metodo = "IniciarVariablesGlobales",
            //        Fecha = DateTime.Now,
            //        Descripcion = Ex.ToString(),
            //        Ip = ObtenerIP.GetIP2(),
            //        Mac = ObtenerMac.GetMac2(),
            //        IdOficina = null
            //    };
            //    InsertarLogError(logErrores);
            //}
        }

        private static string sParametrosFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamLog.dat");
        private void GuardarParametros()
        {
            Parametros.FechaRegistro = DateTime.Now;
            Cifrado.Encrypt2File(sParametrosFile, Parametros);
        }

        private bool ValidarFueraHorarioOperacion()
        {
            try
            {
                DateTime Ya = DateTime.Now;
                string sInicio = Parametros.HoraInicioOperacion;
                string sFin = Parametros.HoraFinOperacion;

                DateTime inicioOperacion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(sInicio.Substring(0, 2)), Convert.ToInt32(sInicio.Substring(3, 2)), Convert.ToInt32(sInicio.Substring(6, 2)));
                DateTime finOperacion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(sFin.Substring(0, 2)), Convert.ToInt32(sFin.Substring(3, 2)), Convert.ToInt32(sFin.Substring(6, 2)));

                if (!(Ya >= inicioOperacion && Ya <= finOperacion))
                    return true;

                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        #endregion
        private void LimpiarVariablesProceso()
        {
            Dedo1 = 0;
            Template1 = null;
            HoraCaptura1 = DateTime.MinValue;
            Dedo2 = 0;
            Template2 = null;
            HoraCaptura2 = DateTime.MinValue;
        }

        private void Cors()
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Remove("Access-Control-Allow-Origin");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", origen);
            WebOperationContext.Current.OutgoingResponse.Headers.Remove("Access-Control-Allow-Methods");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "POST, GET, OPTIONS");
            WebOperationContext.Current.OutgoingResponse.Headers.Remove("Access-Control-Allow-Headers");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Cache-Control, Token");
        }

        private string DevolverCodigoVigencia(string DescVigencia)
        {
            DescVigencia = DescVigencia.ToUpperInvariant().Trim();
            DescVigencia = RemoveDiacritics(DescVigencia);

            string vig1 = "VIGENTE";
            if (string.Compare(RemoveDiacritics(vig1), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "0";
            }

            //              BAJA POR PERDIDA O SUSPENCION DE LOS DERECHOS POLITICOS
            string vig12a = "Baja por Pérdida o Suspensión de los Derechos Políticos";
            if (string.Compare(RemoveDiacritics(vig12a), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "12";
            }

            string vig12b = "BAJA POR PERDIDA O SUSPENCION DE LOS DERECHOS POLITICOS";
            if (string.Compare(RemoveDiacritics(vig12b), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "12";
            }

            string vig14 = "Baja por Interdicción Judicial por Demencia ";
            if (string.Compare(RemoveDiacritics(vig14), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "14";
            }

            //              CANCELADA POR MUERTE
            string vig21 = "Cancelada por Muerte";
            if (string.Compare(RemoveDiacritics(vig21), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "21";
            }

            //              CANCELADA POR DOBLE CEDULACION
            string vig22 = "Cancelada por Doble Cedulación";
            if (string.Compare(RemoveDiacritics(vig22), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "22";
            }

            string vig23 = "Cancelada por Suplantación o Falsa Identidad";
            if (string.Compare(RemoveDiacritics(vig23), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "23";
            }

            string vig24 = "Cancelada por Menoría de Edad";
            if (string.Compare(RemoveDiacritics(vig24), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "24";
            }

            //              CANCELADA POR EXTRANJERIA
            string vig25 = "Cancelada por Extranjería";
            if (string.Compare(RemoveDiacritics(vig25), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "25";
            }

            string vig26 = "Cancelada por Mala Elaboración";
            if (string.Compare(RemoveDiacritics(vig26), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "26";
            }

            string vig27 = "Cancelada por Reasignación o cambio de sexo";
            if (string.Compare(RemoveDiacritics(vig27), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "27";
            }

            string vig51 = "Cancelada por Muerte Facultad Ley 1365 2009";
            if (string.Compare(RemoveDiacritics(vig51), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "51";
            }

            string vig52 = "Cancelada por Intento de Doble Cedulación NO Expedida";
            if (string.Compare(RemoveDiacritics(vig52), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "52";
            }

            //              CANCELADA POR FALSA IDENTIDAD - NO EXPEDIDA
            string vig53a = "Cancelada por Falsa Identidad o Suplantación NO Expedida";
            if (string.Compare(RemoveDiacritics(vig53a), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "53";
            }

            string vig53b = "CANCELADA POR FALSA IDENTIDAD - NO EXPEDIDA";
            if (string.Compare(RemoveDiacritics(vig53b), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "53";
            }

            string vig54 = "Cancelada por Menoría de Edad NO Expedida";
            if (string.Compare(RemoveDiacritics(vig54), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "54";
            }

            string vig55 = "Cancelada por Extranjería NO Expedida";
            if (string.Compare(RemoveDiacritics(vig55), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "55";
            }

            //              CANCELADA POR MALA ELABORACION
            string vig56a = "Cancelada por Mala Elaboración No Expedida";
            if (string.Compare(RemoveDiacritics(vig56a), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "56";
            }

            string vig56b = "CANCELADA POR MALA ELABORACION";
            if (string.Compare(RemoveDiacritics(vig56b), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "56";
            }

            string vig88 = "PENDIENTE POR ESTAR EN PROCESO";
            if (string.Compare(RemoveDiacritics(vig88), DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "88";
            }

            string vig99 = "EN PROCESO DE ELABORACION";
            if (string.Compare(vig99, DescVigencia, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return "99";
            }

            if (DescVigencia.Contains("MUERTE".ToUpperInvariant()))
            {
                return "21";
            }

            if (DescVigencia.Contains("DOBLE".ToUpperInvariant()))
            {
                return "22";
            }

            if (DescVigencia.Contains("MALA".ToUpperInvariant()))
            {
                return "26";
            }

            if (DescVigencia.Contains("PROCESO".ToUpperInvariant()))
            {
                return "88";
            }

            return "99";
        }

        private static string RemoveDiacritics(string text)
        {
            string formD = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char ch in formD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private List<HuellaAFI> CambiarScore(List<HuellaAFI> huellas)
        {
            if (huellas != null)
            {
                foreach (var huella in huellas)
                {
                    huella.Score = NuevoScore(huella.Score);
                }
            }
            return huellas;
        }

        private int NuevoScore(int oldScore)
        {
            if (oldScore == 0)
            {
                return 0;
            }

            if (oldScore <= 4)
            {
                return 10;
            }
            else if (oldScore > 4 && oldScore <= 9)
            {
                return 25;
            }
            else if (oldScore > 9 && oldScore <= 14)
            {
                return 50;
            }
            else if (oldScore > 14 && oldScore <= 18)
            {
                return 75;
            }
            else if (oldScore > 18 && oldScore <= 21)
            {
                return 90;
            }
            else
            {
                return 100;
            }
        }

        private string Data(string id)
        {
            // logic
            return "Data: " + id;
        }

        private string DataSrc(string id)
        {
            return @"data:image/png;base64," + id;
        }
    }

    [DataContract]
    public class RespuestaValidacion2
    {
        [DataMember]
        internal bool Validado;

        [DataMember]
        internal string Error;

        [DataMember]
        internal string NombreCandidato;
    }

    public class RespuestaCaptura
    {
        public string Respuesta { get; set; }
        public string Detalle { get; set; }
        public int Calidad { get; set; }
    }

    public class RespuestaObtenerFormato
    {
        public string Respuesta { get; set; }
        public string Detalle { get; set; }
        public string TextoFormato { get; set; }
    }

    public class RespuestaGenerarAutorizacion
    {
        public string Respuesta { get; set; }
        public string Detalle { get; set; }
        public int Calidad { get; set; }
        public long NutFormato { get; set; }
    }

    public class RespuestaValidacion
    {
        public string Respuesta { get; set; }
        public string Detalle { get; set; }

        public bool Validado { get; set; }
        public long NutValidacion { get; set; }
        public Guid? IdPeticion { get; set; }
        public string Documento { get; set; }
        public string TipoDocumento { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Vigencia { get; set; }
        public List<HuellaAFI> Huellas { get; set; }
    }

    public class RespuestaConsultaEstado
    {
        public string Estado { get; set; }
        public string Version { get; set; }
        public Dictionary<string, string> Propiedades { get; set; }
    }
}
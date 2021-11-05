using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ContingenciaOperador;
using ContingenciaOperador.AzureStorage;
using ContingenciaOperador.AzureStorage.AppConfig;
using ContingenciaOperador.Entidades;
using ContingenciaOperador.Entidades.Reconoser;
using ContingenciaOperador.WSSecurIDMatcher;
using Entidades;
using Entidades.Parametrizacion;
using Serilog;
using Utilidades;
using Utilidades.EstampaCronologica;

namespace Olimpia.Servicios
{
    public class ServicioContingencia
    {
        private ILogger _logger;
        private AuthenticatePersonPmt2Response _matcherResponse;
        private WSSecurIDMatcherEntry _matcherRequest;

        private static WSSecurIDMatcherSoap ServicioContingenciaAliado = new WSSecurIDMatcherSoapClient();

        public ServicioContingencia(ILogger logger)
        {
            _logger = logger;
        }

        public bool ValidarUsuario(string usuario, int idCliente)
        {
            // se deja esta validación para el operador de contingencia
            return true;
        }

        public byte[] FirmarATDP(bool acepta, byte[] documentoAutorizacion, Oficina oficina, Producto producto, byte[] imagenHuella,
            string usuario, string numeroDocumento, Guid idPeticion, ParametrosOperacion parametros)
        {
            Trace.WriteLine("DFZM CT19FA AI");
            var atdp = UtilFormato.AgregarInfo(documentoAutorizacion, numeroDocumento, $"{oficina.Codigo} - {oficina.IdOficina}",
                $"{producto.Codigo} - {producto.Descripcion}", usuario, oficina.Ciudad, imagenHuella);

            Dictionary<String, String> info = new Dictionary<string, string>();
            info.Add("Olimpia", idPeticion.ToString());
            info.Add("NUT Reconoser", idPeticion.ToString());

            Trace.WriteLine("DFZM CT19FA AM");
            atdp = UtilFormato.AgregarMetadata(atdp, info);

            try
            {
                if (!string.IsNullOrEmpty(parametros.URLEstampa))
                {
                    var config = new Utilidades.EstampaCronologica.Configuracion()
                    {
                        Url = parametros.URLEstampa,
                        Usuario = parametros.UsuarioEstampa,
                        Contrasena = parametros.ClaveEstampa,
                        Hash = "SHA256",
                        NombreFirma = "Reconoser"
                    };
                    Trace.WriteLine("DFZM CT19FA EC1");
                    atdp = UtilEstampa.AgregarEstampaCronologica(atdp, config);
                }
                else
                {
                    Trace.WriteLine("DFZM CT19FA EC2");
                    atdp = UtilEstampa.AgregarEstampaCronologica(atdp);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"DFZM CT19FA EC Error: {ex}");
                _logger.Error("Oficina: {@Oficina} Aplicación: {@Aplicacion} Método: {@Metodo} Nuip: {@Nuip} NUT: {@NUT} Excepción: {@Excepcion}",
                                oficina.IdOficina, SwitchContingenciaUtil.NombreAplicacion, $"{nameof(ServicioContingencia)}.{nameof(FirmarATDP)}",
                                numeroDocumento, idPeticion, ex.ToString());
            }
            Trace.WriteLine("DFZM CT19FA EC3");
            return atdp;
        }



        public LogOperaciones VerificarIdentidad(int idCliente, Guid idConvenioAutenticacion, string usuarioLogin, Oficina oficina, Producto producto, string sigla,
            string numeroDocumento, List<HuellaAFI> dedos, string ip, string mac, string serial, Guid idPeticion, ParametrosOperacion parametros)
        {
            var operadorAliado = new OperadorAliado(ServicioContingenciaAliado, _logger);
            var configuracion = ObtenerConfiguracionAdicional(parametros);
            var lstTemplatesCotejo = ObtenerTemplates(dedos, idPeticion);
            var cliente = ObtenerDatosCliente(producto, oficina, idConvenioAutenticacion, idPeticion, usuarioLogin, ip, mac);
            var operador = ObtenerOperador(parametros);

            Trace.WriteLine("DFZM CTSCVI");

            var resCt = operadorAliado.RealizarCotejo(numeroDocumento, lstTemplatesCotejo, cliente, operador,
                configuracion, out _matcherRequest, out _matcherResponse);

            Trace.WriteLine($"DFZM CTSCVI ep: {resCt.EstadoProceso}");
            LogOperaciones LO = new LogOperaciones();

            LO.Fecha = DateTime.Now;

            LO.IdProducto = producto.IdProducto;
            LO.IdServicio = producto.IdServicio;
            LO.TipoDocumento = sigla;
            LO.Sigla = sigla;
            LO.UsuarioLogin = usuarioLogin;
            LO.IdOficina = oficina.IdOficina;
            LO.Documento = numeroDocumento;
            LO.IP = ip;
            LO.MAC = mac;
            LO.Serial = serial;
            LO.IdAutorizacion = -1;
            LO.IdPeticion = idPeticion;
            LO.IdOperacion = resCt.NUT;

            if (resCt.EstadoProceso == CodigoRespuestaRNEC.candidatefound || resCt.EstadoProceso == CodigoRespuestaRNEC.candidatefoundpartialfingers)
            {
                if (resCt.Candidato != null)
                    LO.RespuestaAFI = resCt.Candidato.ResultadoCotejo.ToString();
                else
                    LO.RespuestaAFI = "ERROR";

                //HACK: Se recalcula el hit global ya que estaba llegando mal del servicio de contingencia
                /*
                if (resCt.Candidato != null && resCt.lstResultadoCotejo != null)
                {
                    if (resCt.lstResultadoCotejo.Count(x => x.IdResultadoCotejo == ResultadosCotejo.HIT) >= parametros.DedosHit)
                        LO.RespuestaAFI = "HIT";
                    else
                        LO.RespuestaAFI = "NOHIT";
                }
                else
                    LO.RespuestaAFI = "ERROR";
                */

                if (LO.RespuestaAFI == "HIT")
                {
                    LO.Accion = "Validación de huella";
                    try
                    {
                        LO.FechaExpedicion = resCt.Candidato.FechaExpedicion.Value;
                    }
                    catch (Exception)
                    {
                        LO.FechaExpedicion = new DateTime(2000, 1, 1);
                    }

                    LO.PrimerApellido = resCt.Candidato.PrimerApellido;
                    LO.PrimerNombre = resCt.Candidato.PrimerNombre;
                    LO.SegundoApellido = resCt.Candidato.SegundoApellido;
                    LO.SegundoNombre = resCt.Candidato.SegundoNombre;
                    LO.Vigencia = resCt.Candidato.Vigencia;

                    //Campos adicionales

                    if (resCt.lstResultadoCotejo != null)
                    {
                        Trace.WriteLine($"DFZM CTSCVI LR: {resCt.lstResultadoCotejo.Count()}");
                        LO.HA = new List<HuellaAFI>();

                        foreach (var x in resCt.lstResultadoCotejo)
                        {
                            LO.HA.Add(new HuellaAFI
                            {
                                NumeroDedo = x.Dedo,
                                NombreDedo = UtilidadesHuellas.NombreDedo(x.Dedo),
                                RespuestaAFI = x.MensajeCotejo,
                                Score = x.Score,
                                Error = x.MensajeCotejo
                            });
                        }
                    }
                }
                else
                {
                    LO.Accion = "Validación de huella";
                    LO.FechaExpedicion = DateTime.MinValue;

                    if (resCt.lstResultadoCotejo != null)
                    {
                        Trace.WriteLine($"DFZM CTSCVI LR: {resCt.lstResultadoCotejo.Count()}");
                        LO.HA = new List<HuellaAFI>();

                        foreach (var x in resCt.lstResultadoCotejo)
                        {
                            LO.HA.Add(new HuellaAFI
                            {
                                NumeroDedo = x.Dedo,
                                NombreDedo = UtilidadesHuellas.NombreDedo(x.Dedo),
                                RespuestaAFI = x.MensajeCotejo,
                                Score = x.Score,
                                Error = x.MensajeCotejo,
                                Template = dedos.Single(y => y.NumeroDedo == x.Dedo).Template
                            });
                        }
                    }
                    LO.CodigoError = resCt.EstadoProceso.ToString();
                    LO.DescripcionError = resCt.Mensaje;
                }
            }
            else
            {
                LO.CodigoError = resCt.EstadoProceso.ToString();
                LO.DescripcionError = resCt.Mensaje;
            }
            if (LO.HA == null)
                Trace.WriteLine($"DFZM CTSCVI HA: null");
            else
                Trace.WriteLine($"DFZM CTSCVI HA: {LO.HA.Count()}");

            return LO;

            /*
            string estadoProceso = string.Empty;
            string mensajeProceso = string.Empty;

            if (respuestaCotejoOperadorAliado.EstadoProceso != CodigoRespuestaRNEC.candidatefound &&
                respuestaCotejoOperadorAliado.EstadoProceso != CodigoRespuestaRNEC.candidatenotfound &&
                respuestaCotejoOperadorAliado.EstadoProceso != CodigoRespuestaRNEC.candidatefoundpartialfingers)
            {
                CodigoRespuestaRNEC codigoRespuestaRNEC = CodigoRespuestaRNEC.unknownerror;
                estadoProceso = codigoRespuestaRNEC.ToString();
                mensajeProceso = respuestaCotejoOperadorAliado.Mensaje;
            }*/

        }

        private Operador ObtenerOperador(ParametrosOperacion parametros)
        {
            return new Operador()
            {
                IdOperadorRNEC = parametros.IdOperadorContingencia,
                NombreOperador = "OLIMPIA"
            };
        }

        private Dictionary<string, string> ObtenerConfiguracionAdicional(ParametrosOperacion parametros)
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            info.Add("NumeroHuellasCotejamiento", parametros.DedosHit.ToString());
            info.Add("ScoreReferencia", parametros.Score.ToString());
            info.Add("FormatoHuellaConsultaRNEC", "ISO-FMR");
            info.Add("OrigenTransaccion", "AgenteClienteNotarias");

            return info;
        }

        private DatosCliente ObtenerDatosCliente(Producto tramite, Oficina oficina, Guid idConvenio, Guid idProceso, string usuario, string ip, string mac)
        {
            DatosCliente cliente = new DatosCliente()
            {
                ConsultaMovil = false,
                CodigoTramite = tramite.Codigo,
                IdClienteRnec = oficina.ClienteRNEC,
                IdProcesoCliente = idProceso.ToString(),
                IdSucursal = int.Parse(oficina.Codigo),
                IP = ip,
                MAC = mac,
                Usuario = usuario
            };
            return cliente;
        }

        private List<TemplateHuella> ObtenerTemplates(List<HuellaAFI> dedos, Guid idProceso)
        {
            List<TemplateHuella> huellas = new List<TemplateHuella>();
            foreach (var dedo in dedos)
            {
                huellas.Add(new TemplateHuella()
                {
                    Formato = "ISO-FMR",
                    IdProceso = idProceso,
                    Valor = Convert.FromBase64String(dedo.Template),
                    Nombre = Enum.GetName(typeof(Dedos), (Dedos)dedo.NumeroDedo)
                });
            }

            return huellas;
        }

        public void GuardarPeticionAzure(DatosPeticionRS datos, LogOperaciones LO, byte[] atdp, ParametrosOperacion parametros)
        {
            var config = Obtener.Configuracion;
            config.CadenaDeConexionArchivos = parametros.CadenaConexionAzure;
            config.CadenaDeConexionTablas = parametros.CadenaConexionAzure;
            IAlmacenamientoContingencia almacen = new FabricaAlmacenamiento().Obtener(config);
            var res = SwitchContingenciaUtil.RunSync(() => almacen.Agregar(datos, CopiarAContingencia(LO), _matcherRequest, _matcherResponse, atdp));
        }

        private LogOperacionesContingencia CopiarAContingencia(LogOperaciones origen)
        {
            return new LogOperacionesContingencia()
            {
                Accion = origen.Accion,
                CodigoError = origen.CodigoError,
                DescripcionError = origen.DescripcionError,
                Documento = origen.Documento,
                Fecha = origen.Fecha,
                FechaExpedicion = origen.FechaExpedicion,
                HA = new List<HuellaAFIContingencia>(
                    origen.HA.Select(h => new HuellaAFIContingencia()
                    {
                        Error = h.Error,
                        NombreDedo = h.NombreDedo,
                        NumeroDedo = h.NumeroDedo,
                        RespuestaAFI = h.RespuestaAFI,
                        Score = h.Score,
                        Template = h.Template
                    })),
                IdAutorizacion = origen.IdAutorizacion,
                IdOficina = origen.IdOficina,
                IdOperacion = origen.IdOperacion,
                IdPeticion = origen.IdPeticion,
                IdProducto = origen.IdProducto,
                IdServicio = origen.IdServicio,
                IdTipoDocumento = origen.IdTipoDocumento,
                IP = origen.IP,
                MAC = origen.MAC,
                Nombre = origen.Nombre,
                NombreDedo = origen.NombreDedo,
                NombreServicio = origen.NombreServicio,
                NumeroDedo = origen.NumeroDedo,
                PrimerApellido = origen.PrimerApellido,
                PrimerNombre = origen.PrimerNombre,
                RespuestaAFI = origen.RespuestaAFI,
                Rol = origen.Rol,
                SegundoApellido = origen.SegundoApellido,
                SegundoNombre = origen.SegundoNombre,
                Serial = origen.Serial,
                Sigla = origen.Sigla,
                TipoDocumento = origen.TipoDocumento,
                UsuarioLogin = origen.UsuarioLogin,
                Vigencia = origen.Vigencia,
                Zona = origen.Zona
            };
        }
    }
}

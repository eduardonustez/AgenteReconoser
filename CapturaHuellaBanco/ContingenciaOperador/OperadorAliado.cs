using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ContingenciaOperador.Entidades.Reconoser;
using ContingenciaOperador.WSSecurIDMatcher;
using Serilog;

namespace ContingenciaOperador
{
    /// <summary>
    /// Expone las operaciones disponibles en el operador aliado. 
    /// </summary>
    public class OperadorAliado
    {
        /// <summary>
        /// Mantiene una referencia al servicio del operador aliado. 
        /// </summary>
        WSSecurIDMatcherSoap _servicioOperadorAliado;

        /// <summary>
        /// Mantiene referencia al log de eventos. 
        /// </summary>
        private ILogger _logger;



        /// <summary>
        /// Controla la creación de la instancia para que únicamente se pueda crear una, suministrando una 
        /// instancia del servicio del operador aliado. 
        /// </summary>
        /// <param name="servicioOperadorAliado">Instancia al servicio del operador aliado.</param>
        public OperadorAliado(WSSecurIDMatcherSoap servicioOperadorAliado, ILogger logger)
        {
            this._servicioOperadorAliado = servicioOperadorAliado;
            this._logger = logger;
        }

        /// <summary>
        /// Consume el servicio del operador aliado, en el cual se emplea la replica RNEC de ese operador aliado y se realiza 
        /// cotejamiento. 
        /// </summary>
        public RespuestaCotejo RealizarCotejo(string nuip, List<TemplateHuella> templatesHuella, DatosCliente cliente, Operador operador,
            Dictionary<string, string> additionalInfo, out WSSecurIDMatcherEntry matcherEntry, out AuthenticatePersonPmt2Response response)
        {
            MatcherInfo matcherInfo;
            response = null;
            matcherEntry = null;
            try
            {
                matcherEntry = this.ObtenerMatcherEntry(nuip, templatesHuella, cliente, operador,
                   additionalInfo);
                response = this._servicioOperadorAliado.MatcherServices_V0R1(matcherEntry);
                return this.ObtenerRespuestaCotejo(response, out matcherInfo);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"DFZM CTRC ERR: {ex}");
                EquipoCliente equipoServidor = new EquipoCliente();

                this._logger.Error("IP: {@IP} Aplicación: {@Aplicacion} Método: {@Metodo} Nuip: {@Nuip} NUT: {@NUT} Excepción: {@Excepcion}",
                    equipoServidor.ConsultaIP(), SwitchContingenciaUtil.NombreAplicacion, $"{nameof(OperadorAliado)}.{nameof(RealizarCotejo)}", nuip, cliente.IdProcesoCliente,
                    ex.ToString());

                return new RespuestaCotejo()
                {
                    EstadoProceso = CodigoRespuestaRNEC.communicationerror,
                    Mensaje = $"{ex.Message}."
                };
            }
        }

        /// <summary>
        /// Genera con los parametros de entrada, el objeto requerido en el consumo del servicio del operador aliado. 
        /// </summary>
        private WSSecurIDMatcherEntry ObtenerMatcherEntry(string nuip, List<TemplateHuella> templatesHuella, DatosCliente cliente, Operador operador,
            Dictionary<string, string> additionalInfo)
        {
            var matcherEntry = new WSSecurIDMatcherEntry()
            {
                AplicantId = nuip,
                ClientId = cliente.IdClienteRnec,
                OperatorId = operador.IdOperadorRNEC,
                NUT = cliente.IdProcesoCliente
            };

            matcherEntry.FingerGroup = templatesHuella.Select(x => new FingerPrintGroup()
            {
                FingerId = (int)(Enum.Parse(typeof(Entidades.Reconoser.Dedos), x.Nombre)),
                FormatPrint = x.Formato,
                FingerBuffer = Convert.ToBase64String(x.Valor)
            }).ToArray();

            matcherEntry.UserInfo = new UserInfoGroup()
            {
                BranchId = cliente.IdSucursal.ToString(),
                TransactionId = cliente.CodigoTramite,
                UserCode = cliente.Usuario,
                UserIP = cliente.IP,
                UserMac = cliente.MAC
            };

            matcherEntry.Posicion = this.ObtenerPosicionGroup(cliente);
            matcherEntry.Diccionarioolimpia = this.ObtenerAdditionalInfo(additionalInfo);

            return matcherEntry;
        }

        /// <summary>
        /// Determina si la consulta se realiza desde un dispositivo movil y de serlo, confecciona y retorna un objeto Posicion. 
        /// </summary>
        private PosicionGroup ObtenerPosicionGroup(DatosCliente cliente)
        {
            return new PosicionGroup()
            {
                DPMovil = cliente.ConsultaMovil ? 1 : 0,
                GdLatitud = "0",
                GdLongitud = "0"
            };
        }

        /// <summary>
        /// Obtiene la información adicional requerida para desarrollar el proceso de cotejamiento en el Operador Aliado. 
        /// </summary>
        private KeyValueOfstringstring[] ObtenerAdditionalInfo(Dictionary<string, string> additionalInfo)
        {
            var info = new KeyValueOfstringstring[additionalInfo.Count];
            int index = 0;

            foreach (var item in additionalInfo)
            {
                info[index] = new KeyValueOfstringstring()
                {
                    Key = item.Key,
                    Value = item.Value
                };

                index++;
            }

            return info;
        }

        /// <summary>
        /// Genera para el parámetro de entrada la respuesta a retornar al servicio que invoca a Apolo. 
        /// </summary>
        private RespuestaCotejo ObtenerRespuestaCotejo(AuthenticatePersonPmt2Response response, out MatcherInfo matcherInfo)
        {
            var respuestaCotejo = new RespuestaCotejo()
            {
                EstadoProceso = CodigoRespuestaRNEC.candidatefound,
                Mensaje = RecursosContingencia.ok,
                NUT = 0
            };
            matcherInfo = null;

            if (response != null && response.AuthenticatePmt2Response != null &&
                response.AuthenticatePmt2Response.BasicHeaderResponse != null)
            {
                if (response.AuthenticatePmt2Response.BasicHeaderResponse.Result.ToString().Equals("SUCCESS") ||
                    response.AuthenticatePmt2Response.BasicHeaderResponse.Result.ToString().Equals("FAILURE"))
                {
                    if (response.AuthenticatePmt2Response.BasicHeaderResponse.AuthenticationNumber != null &&
                        (response.AuthenticatePmt2Response.BasicHeaderResponse.AuthenticationNumber.SearchCandidateId.ToString().ToLower().Equals("candidatefound") ||
                        response.AuthenticatePmt2Response.BasicHeaderResponse.AuthenticationNumber.SearchCandidateId.ToString().ToLower().Equals("candidatefoundpartialfingers")))
                    {
                        if (response.AuthenticatePmt2Response.BasicHeaderResponse.Info != null)
                        {
                            respuestaCotejo.lstResultadoCotejo = this.ObtenerResultadoCotejo(response.AuthenticatePmt2Response.BasicHeaderResponse);
                            matcherInfo = this.ObtenerMatcherInfo(response.AuthenticatePmt2Response.BasicHeaderResponse.Info);
                        }

                        if (response.AuthenticatePmt2Response.CandidateList != null &&
                            response.AuthenticatePmt2Response.CandidateList.Count() > 0 &&
                            response.AuthenticatePmt2Response.CandidateList[0].CandidateAlphaList != null)
                        {
                            respuestaCotejo.Candidato = this.ObtenerCandidato(response.AuthenticatePmt2Response.CandidateList[0].CandidateAlphaList);
                            switch (response.AuthenticatePmt2Response.CandidateList[0].Decision)
                            {
                                case DecisionType.HIT:
                                    respuestaCotejo.Candidato.ResultadoCotejo = ResultadosCotejo.HIT;
                                    break;
                                case DecisionType.NO_HIT:
                                    respuestaCotejo.Candidato.ResultadoCotejo = ResultadosCotejo.NOHIT;
                                    break;
                                default:
                                    respuestaCotejo.Candidato.ResultadoCotejo = ResultadosCotejo.ERROR;
                                    break;
                            }
                        }
                    }
                    else if (response.AuthenticatePmt2Response.BasicHeaderResponse.AuthenticationNumber != null &&
                        response.AuthenticatePmt2Response.BasicHeaderResponse.AuthenticationNumber.SearchCandidateId.ToString().ToLower().Equals("candidatenotfound"))
                    {
                        respuestaCotejo.EstadoProceso = CodigoRespuestaRNEC.candidatenotfound;
                        respuestaCotejo.Mensaje = RecursosContingencia.MensajeCandidateNotFound;
                        matcherInfo = this.ObtenerMatcherInfo(response.AuthenticatePmt2Response.BasicHeaderResponse.Info);
                    }
                    else if (response.AuthenticatePmt2Response.BasicHeaderResponse.AuthenticationNumber != null)
                    {
                        CodigoRespuestaRNEC codigoRespuestaRNEC = CodigoRespuestaRNEC.unknownerror;

                        if (!Enum.TryParse(response.AuthenticatePmt2Response.BasicHeaderResponse.AuthenticationNumber.SearchCandidateId, out codigoRespuestaRNEC))
                        {
                            codigoRespuestaRNEC = CodigoRespuestaRNEC.unknownerror;
                        }

                        respuestaCotejo.EstadoProceso = codigoRespuestaRNEC;
                        respuestaCotejo.Mensaje = codigoRespuestaRNEC.ToString();
                    }
                    else
                    {
                        respuestaCotejo.EstadoProceso = CodigoRespuestaRNEC.communicationerror;
                        respuestaCotejo.Mensaje = $"Se detecta respuesta [{"BAD AuthenticationNumber"}] en consumo servicio operador aliado.";
                    }

                    if (!string.IsNullOrEmpty(response.AuthenticatePmt2Response.BasicHeaderResponse.RequestId))
                    {
                        long.TryParse(response.AuthenticatePmt2Response.BasicHeaderResponse.RequestId, out long nutOperadorAliado);
                        respuestaCotejo.NUT = nutOperadorAliado;
                    }
                }
                else
                {
                    respuestaCotejo.EstadoProceso = CodigoRespuestaRNEC.communicationerror;
                    respuestaCotejo.Mensaje = $"Se detecta respuesta [{response.AuthenticatePmt2Response.BasicHeaderResponse.Result}] en consumo servicio operador aliado.";
                }
            }
            else
            {
                respuestaCotejo.EstadoProceso = CodigoRespuestaRNEC.communicationerror;
                respuestaCotejo.Mensaje = $"{"Posible Candidato No encontrado. No se detecta respuesta en consumo servicio operador aliado."}";
            }

            return respuestaCotejo;
        }

        /// <summary>
        /// Genera para el parámetro de entrada el resultado del proceso de cotejamiento muestra a muestra. 
        /// </summary>
        private List<ResultadoCotejoDedo> ObtenerResultadoCotejo(BasicHeaderPmt2ResponseType basicHeader)
        {
            List<ResultadoCotejoDedo> resultados = new List<ResultadoCotejoDedo>();
            long nut = 0;

            if (!string.IsNullOrEmpty(basicHeader.RequestId))
                long.TryParse(basicHeader.RequestId, out nut);

            foreach (var dedoSolicitado in (Enum.GetValues(typeof(OperadorAliado.Dedos))))
            {
                if (basicHeader.Info.ToList().Where(x => x.Key.Equals(ObtenerNombreDedo((OperadorAliado.Dedos)dedoSolicitado))).Count() > 0)
                    resultados.Add(this.ObtenerResultadoDedo(basicHeader.Info, (OperadorAliado.Dedos)dedoSolicitado, nut));                
            }

            return resultados;
        }

        //Debido al ofuscamiento se debe hacer esto
        private string ObtenerNombreDedo(OperadorAliado.Dedos dedo)
        {
            switch (dedo)
            {
                case Dedos.RIGHT_THUMB:
                    return "RIGHT_THUMB";
                case Dedos.RIGHT_INDEX:
                    return "RIGHT_INDEX";
                case Dedos.RIGHT_MIDDLE:
                    return "RIGHT_MIDDLE";
                case Dedos.RIGHT_RING:
                    return "RIGHT_RING";
                case Dedos.RIGHT_LITTLE:
                    return "RIGHT_LITTLE";
                case Dedos.LEFT_THUMB:
                    return "LEFT_THUMB";
                case Dedos.LEFT_INDEX:
                    return "LEFT_INDEX";
                case Dedos.LEFT_MIDDLE:
                    return "LEFT_MIDDLE";
                case Dedos.LEFT_RING:
                    return "LEFT_RING";
                case Dedos.LEFT_LITTLE:
                    return "LEFT_LITTLE";
            }
            return null;
        }

        /// <summary>
        /// Intenta generar para la muestra solicitada el resultado del proceso de cotejamiento (si existe). 
        /// </summary>
        private ResultadoCotejoDedo ObtenerResultadoDedo(InfoType[] info, OperadorAliado.Dedos dedoSolicitado, long nut)
        {
            ResultadoCotejoDedo resultadoCotejoDedo = new ResultadoCotejoDedo();
            //var nombreDedoSolicitado = dedoSolicitado.ToString();

            var nombreDedoSolicitado = ObtenerNombreDedo((OperadorAliado.Dedos)dedoSolicitado);

            if (info.ToList().Where(x => x.Key.Equals(ObtenerNombreDedo((OperadorAliado.Dedos)dedoSolicitado))).Count() > 0)
            {
                var resultadoCotejo = info.ToList().Where(x => x.Key.Equals(ObtenerNombreDedo((OperadorAliado.Dedos)dedoSolicitado)) && x.Value.Equals("HIT")).Count() > 0;

                resultadoCotejoDedo = new ResultadoCotejoDedo()
                {
                    Score = (int)info.Select(x => x.Key.Equals($"{nombreDedoSolicitado}_SCORE")).Count() > 0 ?
                        info.Where(x => x.Key.Equals($"{nombreDedoSolicitado}_SCORE")).Select(x => int.Parse(x.Value)).FirstOrDefault() : 0,
                    NUT = nut,
                    Dedo = (int)dedoSolicitado,
                    IdResultadoCotejo = resultadoCotejo ? ResultadosCotejo.HIT : ResultadosCotejo.NOHIT,
                    MensajeCotejo = (resultadoCotejo ? ResultadosCotejo.HIT.ToString() : ResultadosCotejo.NOHIT.ToString())
                };
            }

            return resultadoCotejoDedo;
        }

        /// <summary>
        /// Genera para el parámetro de entrada la identificación del matcher en el que se realizó el cotejamiento. 
        /// </summary>
        private MatcherInfo ObtenerMatcherInfo(InfoType[] info)
        {
            MatcherInfo matcherInfo = null;

            if (info.ToList().Where(x => x.Key.Equals("Mac")).Count() > 0 &&
                info.ToList().Where(x => x.Key.Equals("Ip")).Count() > 0 &&
                info.ToList().Where(x => x.Key.Equals("MachineName")).Count() > 0)
            {
                matcherInfo = new MatcherInfo()
                {
                    MAC = info.ToList().Where(x => x.Key.Equals("Mac")).Select(x => x.Value).FirstOrDefault(),
                    IP = info.ToList().Where(x => x.Key.Equals("Ip")).Select(x => x.Value).FirstOrDefault(),
                    NombreServidor = info.ToList().Where(x => x.Key.Equals("MachineName")).Select(x => x.Value).FirstOrDefault(),
                };
            }

            return matcherInfo;
        }

        /// <summary>
        /// Genera para el parámetro de entrada un objeto Candidate con la información del aplicante. 
        /// </summary>
        private Candidato ObtenerCandidato(CandidateAlphaType[] candidateAlpha)
        {
            var candidato = new Candidato()
            {
                Nuip = candidateAlpha.Where(x => x.AlphaId.Equals("NuipNip")).Count() > 0 ?
                    candidateAlpha.Where(x => x.AlphaId.Equals("NuipNip")).Select(x => x.AlphaValue).FirstOrDefault() : string.Empty,
                PrimerApellido = candidateAlpha.Where(x => x.AlphaId.Equals("LastName1")).Count() > 0 ?
                    candidateAlpha.Where(x => x.AlphaId.Equals("LastName1")).Select(x => x.AlphaValue).FirstOrDefault() : string.Empty,
                SegundoApellido = candidateAlpha.Where(x => x.AlphaId.Equals("LastName2")).Count() > 0 ?
                    candidateAlpha.Where(x => x.AlphaId.Equals("LastName2")).Select(x => x.AlphaValue).FirstOrDefault() : string.Empty,
                PrimerNombre = candidateAlpha.Where(x => x.AlphaId.Equals("FirstName1")).Count() > 0 ?
                    candidateAlpha.Where(x => x.AlphaId.Equals("FirstName1")).Select(x => x.AlphaValue).FirstOrDefault() : string.Empty,
                SegundoNombre = candidateAlpha.Where(x => x.AlphaId.Equals("FirstName2")).Count() > 0 ?
                    candidateAlpha.Where(x => x.AlphaId.Equals("FirstName2")).Select(x => x.AlphaValue).FirstOrDefault() : string.Empty,
                Particula = candidateAlpha.Where(x => x.AlphaId.Equals("Particle")).Count() > 0 ?
                    candidateAlpha.Where(x => x.AlphaId.Equals("Particle")).Select(x => x.AlphaValue).FirstOrDefault() : string.Empty,
                CodigoParticula = candidateAlpha.Where(x => x.AlphaId.Equals("ParticleCode")).Count() > 0 ?
                    candidateAlpha.Where(x => x.AlphaId.Equals("ParticleCode")).Select(x => int.Parse(x.AlphaValue)).FirstOrDefault() : 0,
                FechaExpedicion = null,
                LugarExpedicion = candidateAlpha.Where(x => x.AlphaId.Equals("ExpeditionPlace")).Count() > 0 ?
                    candidateAlpha.Where(x => x.AlphaId.Equals("ExpeditionPlace")).Select(x => x.AlphaValue).FirstOrDefault() : string.Empty,
                Vigencia = candidateAlpha.Where(x => x.AlphaId.Equals("Validity")).Count() > 0 ?
                    candidateAlpha.Where(x => x.AlphaId.Equals("Validity")).Select(x => x.AlphaValue).FirstOrDefault() : string.Empty,
                CodigoVigencia = candidateAlpha.Where(x => x.AlphaId.Equals("ValidityCode")).Count() > 0 ?
                    candidateAlpha.Where(x => x.AlphaId.Equals("ValidityCode")).Select(x => int.Parse(x.AlphaValue)).FirstOrDefault() : 0,
            };

            if (!string.IsNullOrEmpty(candidato.Particula) &&
                !string.IsNullOrEmpty(candidato.SegundoApellido) &&
                !candidato.Particula.Trim().ToLower().Equals("ninguna"))
            {
                candidato.SegundoApellido = $"{candidato.Particula.Trim()} {candidato.SegundoApellido.Trim()}";
            }

            var textofechaExpedicion = candidateAlpha.Where(x => x.AlphaId.Equals("ExpeditionDate")).Select(x => x.AlphaValue).FirstOrDefault();
            DateTime fechaExpedicion = new DateTime();

            if (textofechaExpedicion != null && DateTime.TryParse(textofechaExpedicion, out fechaExpedicion))
                candidato.FechaExpedicion = fechaExpedicion;

            return candidato;
        }

        /// <summary>
        /// Nombres de los dedos de la mano, según el operador aliado. 
        /// </summary>
        /// <remarks>El orden (número) de los dedos coincide con el orden Olimpia. </remarks>
        private enum Dedos : int
        {
            RIGHT_THUMB = 1,
            RIGHT_INDEX,
            RIGHT_MIDDLE,
            RIGHT_RING,
            RIGHT_LITTLE,
            LEFT_THUMB,
            LEFT_INDEX,
            LEFT_MIDDLE,
            LEFT_RING,
            LEFT_LITTLE
        }
    }
}

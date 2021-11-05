using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFBanco.ServicioFachadaOlimpia;
using Utilidades;

namespace WCFBanco
{
    public class Biometria
    {
        private static IServicioColpatria ServicioFachada = new ServicioColpatriaClient();

        public static Entidades.ParametrosBiometria_TiposDoc ObtenerBiometrias(int _IdCliente, Guid _IdConvenioAutenticacion)
        {
            Entidades.ParametrosBiometria_TiposDoc PBTD = null;
            BiometriasEnrtada BE = new BiometriasEnrtada();

            BE.IdCliente = _IdCliente;
            BE.IdConvenioautenticacion = _IdConvenioAutenticacion;

            RespuestaBiometrias RB = ServicioFachada.ObtenerBiometrias(BE);

            if (RB.Estado == RespuestaEstadoRespuesta.Ok)
            {
                PBTD = new Entidades.ParametrosBiometria_TiposDoc();

                //Obtiene las biometrias de huellas
                var resBiometrias = RB.Biometrias.FirstOrDefault(x => x.idTipoBiometria == 2);

                if (resBiometrias != null)
                {
                    PBTD._Biometrias = new Entidades.Biometrias();
                    PBTD._Biometrias.HuellasObligatorias = resBiometrias.MuestrasPreferidas.ToList();
                    PBTD._Biometrias.HuellasOpcionales = resBiometrias.MuestrasHabilitadas.ToList();
                    PBTD._Biometrias.NumeroMuestras = resBiometrias.NumeroMuestras;

                    //Obtiene los tipos de documento permitidos
                    PBTD._ListDocs = new List<Entidades.TipoDocumento>();
                    var resDocumentos = RB.Documentos.ToList();

                    resDocumentos.ForEach(x => PBTD._ListDocs.Add(
                        new Entidades.TipoDocumento
                        {
                            NombreTipoDocumento = x.Descripcion,
                            Sigla = x.Valor
                        }
                        ));
                }
            }

            return PBTD;
        }

        public static RespuestaProceso VerificarIdentidad(int _IdCliente, Guid _IdConvenioAutenticacion, string UsuarioLogin, int IdProducto, string _Tramite, string Sigla, string NumeroDocumento, List<Entidades.HuellaAFI> Dedos, string IP, string MAC, long _IdAutorizacion)
        {
            ProcesoEntrada PE = new ProcesoEntrada();
            List<BiometriaProceso> B = new List<BiometriaProceso>();

            int i = 0;
            foreach (Entidades.HuellaAFI HAAux in Dedos)
            {
                B.Add(new BiometriaProceso()
                {
                    Consecutivo = i,
                    Buffer = HAAux.Template,
                    Formato = "ISO-FMR-ENC",
                    IdSubtipo = HAAux.NumeroDedo,
                    IdTipo = 2
                });
                i++;
            }

            PE.BiometriasProceso = B.ToArray();
            PE.FechaPeticion = DateTime.Now;
            PE.IdCliente = _IdCliente;
            PE.IdConvenioautenticacion = _IdConvenioAutenticacion;
            PE.IdPeticion = Guid.NewGuid();
            PE.IdTerminal = Environment.MachineName;
            PE.IpTerminal = IP;
            PE.MacTerminal = MAC;
            PE.NumeroBiometrias = Dedos.Count();
            PE.NumeroIdentificacion = NumeroDocumento;
            PE.TipoIdentificacion = Sigla;
            PE.Tramite = _Tramite;
            PE.UsuarioTerminal = UsuarioLogin;
            PE.IdTransaccion = _IdAutorizacion.ToString();

            return ServicioFachada.VerificarIdentidad(PE);
        }

        public static long CrearAutorizacionCandidato(bool acepta, byte[] DocumentoAutorizacion, string _IdOficina, int _IdProducto, byte[] ImagenHuella, string _Ip, string _Usuario, string _Documento, string _Sigla, byte[] TemplateHuella)
        {
            AutorizacionCandidatoVM ACV = new AutorizacionCandidatoVM();
            ACV.Aceptacion = acepta;
            ACV.DocumentoAutorizacion = DocumentoAutorizacion;
            ACV.IdOficina = _IdOficina;
            ACV.IdPeticion = null;
            ACV.IdProducto = _IdProducto;
            ACV.ImagenHuella = ImagenHuella;
            ACV.IpTerminal = _Ip;
            ACV.Login = _Usuario;
            ACV.NumeroDocumento = _Documento;
            ACV.Sigla = _Sigla;
            ACV.TemplateHuella = TemplateHuella;

            return ServicioFachada.CrearAutorizacionCandidato(ACV);
        }
    }
}
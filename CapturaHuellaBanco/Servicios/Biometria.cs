using Olimpia.Servicios.ServicioFachadaZeus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Olimpia.Servicios
{
    public class Biometria
    {
        private static string _format = null;
        private static RSACryptoServiceProvider cert = (RSACryptoServiceProvider)new X509Certificate2(Properties.Resources.client, "Olimpia.2017").PrivateKey;
        private static IServicioFachadaZeus ServicioFachada = new ServicioFachadaZeusClient();
        public static string Format
        {
            get { return _format; }
            set { _format = value; }
        }

        public static long CrearAutorizacionCandidato(bool acepta, byte[] DocumentoAutorizacion, string _IdOficina, int _IdProducto, byte[] ImagenHuella, string _Ip, string _Usuario, string _Documento, string _Sigla, byte[] TemplateHuella, int idCliente, Guid idConvenio, Guid? IdPeticion)
        {
            AutorizacionAppEntrada ACV = new AutorizacionAppEntrada();
            ACV.Aceptacion = acepta;
            ACV.DocumentoAutorizacion = DocumentoAutorizacion;
            ACV.IdOficina = _IdOficina;
            ACV.IdPeticion = IdPeticion;
            ACV.IdProducto = _IdProducto;
            ACV.ImagenHuella = ImagenHuella;
            ACV.IpTerminal = _Ip;
            ACV.Login = _Usuario;
            ACV.NumeroDocumento = _Documento;
            ACV.Sigla = _Sigla;
            ACV.TemplateHuella = TemplateHuella;

            string metodo = "crearAutorizacionCandidato";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            var ss = Newtonsoft.Json.JsonConvert.SerializeObject(ACV).OrderBy(x => x).ToArray();
            byte[] data = Encoding.UTF8.GetBytes(new string(ss))
                .Concat(BitConverter.GetBytes(idCliente))
                .Concat(Encoding.UTF8.GetBytes(idConvenio.ToString()))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

            return ServicioFachada.crearAutorizacionCandidato(ACV, idCliente, idConvenio, ticks, firma);
        }

        public static Entidades.ParametrosBiometria_TiposDoc ObtenerBiometrias(int _IdCliente, Guid _IdConvenioAutenticacion)
        {
            Entidades.ParametrosBiometria_TiposDoc PBTD = null;
            BiometriasEnrtada BE = new BiometriasEnrtada();

            BE.IdCliente = _IdCliente;
            BE.IdConvenioautenticacion = _IdConvenioAutenticacion;

            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;

            string metodo = "ObtenerBiometrias";
            var ss = Newtonsoft.Json.JsonConvert.SerializeObject(BE).OrderBy(x => x).ToArray();
            byte[] data = Encoding.UTF8.GetBytes(new string(ss))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

            RespuestaBiometrias RB = ServicioFachada.ObtenerBiometrias(BE, ticks, firma);

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

        public static RespuestaCertificado ObtenerCertificado(int idCliente)
        {
            string metodo = "obtenerCertificado";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = BitConverter.GetBytes(idCliente)
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

            return ServicioFachada.obtenerCertificado(idCliente, ticks, firma);
        }

        public static RespuestaProceso VerificarIdentidad(int _IdCliente, Guid _IdConvenioAutenticacion, string UsuarioLogin, int IdProducto, string _Tramite, string Sigla, string NumeroDocumento, List<Entidades.HuellaAFI> Dedos, string IP, string MAC, long _IdAutorizacion, Guid IdPeticion)
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
                    Formato = _format == null ? "ISO-FMR-ENC" : _format,
                    IdSubtipo = HAAux.NumeroDedo,
                    IdTipo = 2
                });
                i++;
            }

            PE.BiometriasProceso = B.ToArray();
            PE.FechaPeticion = DateTime.Now;
            PE.IdCliente = _IdCliente;
            PE.IdConvenioautenticacion = _IdConvenioAutenticacion;
            PE.IdPeticion = IdPeticion;
            PE.IdTerminal = Environment.MachineName;
            PE.IpTerminal = IP;
            PE.MacTerminal = MAC;
            PE.NumeroBiometrias = Dedos.Count();
            PE.NumeroIdentificacion = NumeroDocumento;
            PE.TipoIdentificacion = Sigla;
            PE.Tramite = _Tramite;
            PE.UsuarioTerminal = UsuarioLogin;
            PE.IdTransaccion = _IdAutorizacion.ToString();

            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            string metodo = "VerificarIdentidad";
            DateTimeOffset dto = new DateTimeOffset(PE.FechaPeticion.ToUniversalTime().AddHours(-5).Ticks, TimeSpan.FromHours(-5.0));
            var seri = Newtonsoft.Json.JsonConvert.SerializeObject(PE).Replace(
                Newtonsoft.Json.JsonConvert.SerializeObject(PE.FechaPeticion),
                Newtonsoft.Json.JsonConvert.SerializeObject(dto));
            var ss = seri.OrderBy(x => x).ToArray();
            byte[] data = Encoding.UTF8.GetBytes(new string(ss))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

            return ServicioFachada.VerificarIdentidad(PE, ticks, firma);
        }
    }
}
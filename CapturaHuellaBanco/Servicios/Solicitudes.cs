using Entidades;
using Olimpia.Servicios.ServicioFachadaZeus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Olimpia.Servicios
{
    public class Solicitudes
    {
        private static RSACryptoServiceProvider cert = (RSACryptoServiceProvider)new X509Certificate2(Properties.Resources.client, "Olimpia.2017").PrivateKey;
        private static IServicioFachadaZeus ServicioFachada = new ServicioFachadaZeusClient();
        public static RespuestaActualizarSolicitudTerminada ActualizarSolicitudTerminada(Guid idPeticion, int idCliente)
        {
            RespuestaActualizarSolicitudTerminada RST = new RespuestaActualizarSolicitudTerminada();
            string metodo = "ActualizarSolicitudTerminada";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = Encoding.UTF8.GetBytes(idPeticion.ToString())
                .Concat(BitConverter.GetBytes(idCliente))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));
            var res = ServicioFachada.ActualizarSolicitudTerminada(idPeticion, idCliente, ticks, firma);

            if (res != null)
            {
                RST.CodigoError = res.CodigoError;
                RST.DescripcionError = res.DescripcionError;
                RST.Estado = res.Estado;
            }

            return RST;
        }

        public static RespuestaCancelacion cancelarSolicitud(Guid idPeticion, int idCliente, Guid idConvenio)
        {
            RespuestaCancelacion RCS = new RespuestaCancelacion();
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            string metodo = "cancelarSolicitud";
            byte[] data = Encoding.UTF8.GetBytes(idPeticion.ToString())
                .Concat(BitConverter.GetBytes(idCliente))
                .Concat(Encoding.UTF8.GetBytes(idConvenio.ToString()))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));
            var res = ServicioFachada.cancelarSolicitud(idPeticion, idCliente, idConvenio, ticks, firma);

            if (res != null)
            {
                RCS.CodigoError = res.CodigoError;
                RCS.DescripcionError = res.DescripcionError;
                RCS.Estado = res.Estado;
            }

            return RCS;
        }

        public static RespuestaListas<RespuestasSolicitudConvenioRNEC> consultarSolicitudAplicacion(string maquina, int tipoIdentidadMaquina, int idCliente, Guid idConvenio)
        {
            RespuestaListas<RespuestasSolicitudConvenioRNEC> Rl = new RespuestaListas<RespuestasSolicitudConvenioRNEC>();
            string metodo = "consultarSolicitudAplicacion";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = Encoding.UTF8.GetBytes(maquina)
                .Concat(BitConverter.GetBytes(tipoIdentidadMaquina))
                .Concat(BitConverter.GetBytes(idCliente))
                .Concat(Encoding.UTF8.GetBytes(idConvenio.ToString()))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));
            var Todos = ServicioFachada.consultarSolicitudAplicacion(maquina, tipoIdentidadMaquina, idCliente, idConvenio, ticks, firma);

            if (Todos != null)
            {
                Rl.CodigoError = Todos.CodigoError;
                Rl.DescripcionError = Todos.DescripcionError;
                Rl.Estado = Todos.Estado == RespuestaEstadoRespuesta.Ok ? Estado.Ok : Estado.Error;

                if (Todos.Estado == RespuestaEstadoRespuesta.Ok)
                {
                    List<RespuestasSolicitudConvenioRNEC> Result = Todos.Solicitudes.ToList();
                    Rl.Lista = new List<RespuestasSolicitudConvenioRNEC>();
                    Result.ForEach(x =>
                        Rl.Lista.Add(new RespuestasSolicitudConvenioRNEC
                        {
                            Candidato = x.Candidato,
                            EstadoSolicitud = x.EstadoSolicitud,
                            FechaSolicitud = x.FechaSolicitud,
                            IdConvenioAutenticacion = x.IdConvenioAutenticacion,
                            IdMaquina = x.IdMaquina,
                            IdOficina = x.IdOficina,
                            IdPeticion = x.IdPeticion,
                            IdProducto = x.IdProducto,
                            IdSolicitudCliente = x.IdSolicitudCliente,
                            IdSolicitudConvenioRNEC = x.IdSolicitudConvenioRNEC,
                            TiempoValidez = x.TiempoValidez,
                            TipoIdentidadMaquina = x.TipoIdentidadMaquina,
                            TipoIdentificacionCandidato = x.TipoIdentificacionCandidato,
                            UsuarioCreacion = x.UsuarioCreacion
                        }));
                }
            }

            return Rl;
        }
    }
}
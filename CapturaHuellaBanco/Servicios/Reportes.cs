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
    public class Reportes
    {
        private static RSACryptoServiceProvider cert = (RSACryptoServiceProvider)new X509Certificate2(Properties.Resources.client, "Olimpia.2017").PrivateKey;
        private static IServicioFachadaZeus ServicioFachada = new ServicioFachadaZeusClient();

        #region Reporte Operaciones huella

        public static long InsertarLogOperaciones(LogOperaciones LO, string strUnionDedos, int idCliente)
        {
            long IdLogOperaciones = 0;

            DateTime fecha = DateTime.Now;

            if (LO.FechaExpedicion != DateTime.MinValue)
            {
                fecha = LO.FechaExpedicion;
            }

            OperacionAppEntrada objLogOperacionVM = new OperacionAppEntrada();
            objLogOperacionVM.Accion = LO.Accion;
            objLogOperacionVM.Fecha = LO.Fecha;
            objLogOperacionVM.FechaExpedicion = fecha;
            objLogOperacionVM.IdOficina = LO.IdOficina;
            objLogOperacionVM.IdProducto = LO.IdProducto;
            objLogOperacionVM.IdServicio = LO.IdServicio;
            objLogOperacionVM.Ip = LO.IP;
            objLogOperacionVM.Mac = LO.MAC;
            objLogOperacionVM.Serial = LO.Serial;
            objLogOperacionVM.IdAutorizacion = LO.IdAutorizacion;
            objLogOperacionVM.IdPeticion = LO.IdPeticion;

            try
            {
                objLogOperacionVM.NumeroDedo = Convert.ToInt16(strUnionDedos);
            }
            catch
            {
                objLogOperacionVM.NumeroDedo = (short)LO.NumeroDedo;
            }
            objLogOperacionVM.NumeroDocumento = LO.Documento;
            objLogOperacionVM.PrimerApellido = LO.PrimerApellido;
            objLogOperacionVM.PrimerNombre = LO.PrimerNombre;
            objLogOperacionVM.RespuestaAFI = LO.RespuestaAFI;
            objLogOperacionVM.SegundoApellido = LO.SegundoApellido;
            objLogOperacionVM.SegundoNombre = LO.SegundoNombre;
            objLogOperacionVM.Sigla = LO.Sigla;
            objLogOperacionVM.UsuarioLogin = LO.UsuarioLogin;
            objLogOperacionVM.Vigencia = LO.Vigencia;

            string metodo = "crearOperacionApp";
            var ss = Newtonsoft.Json.JsonConvert.SerializeObject(objLogOperacionVM).OrderBy(x => x).ToArray();
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = Encoding.UTF8.GetBytes(new string(ss))
                .Concat(BitConverter.GetBytes(idCliente))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

            IdLogOperaciones = ServicioFachada.crearOperacionApp(objLogOperacionVM, idCliente, ticks, firma);
            return IdLogOperaciones;
        }

        public static List<LogOperaciones> SeleccionarLogOperaciones(long? IdOperacion, DateTime? FechaInicio, DateTime? FechaFin, string Documento, string UsuarioLogin, string RespuestaAFI, string IdOficina, int idCliente)
        {
            List<LogOperaciones> LLO = new List<LogOperaciones>();
            string metodo = "reporteOperaciones";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = BitConverter.GetBytes(IdOperacion ?? 0)
                .Concat(BitConverter.GetBytes(FechaInicio == null ? 0 : FechaInicio.Value.Ticks))
                .Concat(BitConverter.GetBytes(FechaFin == null ? 0 : FechaFin.Value.Ticks))
                .Concat(Encoding.UTF8.GetBytes(Documento ?? ""))
                .Concat(Encoding.UTF8.GetBytes(UsuarioLogin ?? ""))
                .Concat(Encoding.UTF8.GetBytes(RespuestaAFI ?? ""))
                .Concat(BitConverter.GetBytes(0))
                .Concat(BitConverter.GetBytes(0))
                .Concat(Encoding.UTF8.GetBytes(IdOficina ?? ""))
                .Concat(BitConverter.GetBytes(true))
                .Concat(BitConverter.GetBytes(0))
                .Concat(BitConverter.GetBytes(0))
                .Concat(BitConverter.GetBytes(idCliente))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

            var res = ServicioFachada.reporteOperaciones(IdOperacion, FechaInicio, FechaFin, Documento, UsuarioLogin, RespuestaAFI, null, null, IdOficina, true, 0, 0, idCliente, ticks, firma);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                res.Lista.ToList().ForEach(x => LLO.Add(new LogOperaciones
                {
                    Accion = x.Accion,
                    Fecha = Convert.ToDateTime(x.Fecha),
                    FechaExpedicion = x.FechaExpedicion,
                    IdProducto = x.IdProducto,
                    IdServicio = x.IdServicio,
                    Sigla = x.Sigla,
                    NombreDedo = Utilidades.UtilidadesHuellas.NombreDedo(x.NumeroDedo),
                    NombreServicio = x.IdServicio.ToString(),
                    TipoDocumento = x.Sigla,
                    NumeroDedo = x.NumeroDedo,
                    Documento = x.NumeroDocumento,
                    PrimerApellido = x.PrimerApellido,
                    PrimerNombre = x.PrimerNombre,
                    RespuestaAFI = x.RespuestaAFI,
                    SegundoApellido = x.SegundoApellido,
                    SegundoNombre = x.SegundoNombre,
                    UsuarioLogin = x.UsuarioLogin,
                    Vigencia = x.Vigencia,
                    Respuesta = null,
                    IdOficina = x.IdOficina,
                    IP = x.Ip,
                    MAC = x.Mac,
                    Serial = x.Serial,
                    Rol = x.Rol,
                    Zona = x.Zona
                }));
            }

            return LLO;
        }

        #endregion Reporte Operaciones huella

        #region ReporteIngresos

        public static void ActualizarSalidaAplicacion(long idAutenticacion, int idCliente)
        {
            string metodo = "actualizarSalidaApp";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = BitConverter.GetBytes(idAutenticacion)
                .Concat(BitConverter.GetBytes(idCliente))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));
            ServicioFachada.actualizarSalidaApp(idAutenticacion, idCliente, ticks, firma);
        }

        public static long InsertarLogIngresos(IngresoAppEntrada LI, int idCliente)
        {
            string metodo = "crearIngresoApp";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            var ss = Newtonsoft.Json.JsonConvert.SerializeObject(LI).OrderBy(x => x).ToArray();
            byte[] data = Encoding.UTF8.GetBytes(new string(ss))
                .Concat(BitConverter.GetBytes(idCliente))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));
            return ServicioFachada.crearIngresoApp(LI, idCliente, ticks, firma);
        }

        #endregion ReporteIngresos

        public static void InsertarLogError(ErrorAppEntrada Error, int idCliente)
        {
            string metodo = "crearErrorApp";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            var ss = Newtonsoft.Json.JsonConvert.SerializeObject(Error).OrderBy(x => x).ToArray();
            byte[] data = Encoding.UTF8.GetBytes(new string(ss))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));
            var res = ServicioFachada.crearErrorApp(Error, idCliente, ticks, firma);
        }

        public static void InsertarLogHallazgoBiometrico(HallazgoBiometrico hallazgo, int idCliente)
        {
            string metodo = "crearHallazgoBiometrico";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            var ss = Newtonsoft.Json.JsonConvert.SerializeObject(hallazgo).OrderBy(x => x).ToArray();
            byte[] data = Encoding.UTF8.GetBytes(new string(ss))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));
            var res = ServicioFachada.crearHallazgoBiometrico(hallazgo, idCliente, ticks, firma);
        }
    }
}
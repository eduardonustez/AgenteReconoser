using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using WCFBanco.ServicioFachadaOlimpia;

namespace WCFBanco
{
    public class Reportes
    {
        private static IServicioColpatria ServicioFachada = new ServicioColpatriaClient();

        #region Reporte Operaciones huella

        public static long InsertarLogOperaciones(LogOperaciones LO, string strUnionDedos)
        {
            long IdLogOperaciones = 0;

            DateTime fecha = DateTime.Now;

            if (LO.FechaExpedicion != DateTime.MinValue)
            {
                fecha = LO.FechaExpedicion;
            }

            LogOperacionVM objLogOperacionVM = new LogOperacionVM();
            objLogOperacionVM.Accion = LO.Accion;
            objLogOperacionVM.Fecha = LO.Fecha;
            objLogOperacionVM.FechaExpedicion = fecha;
            objLogOperacionVM.IdOficina = LO.IdOficina;
            objLogOperacionVM.IdProducto = LO.IdProducto;
            objLogOperacionVM.IdServicio = 1;
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

            IdLogOperaciones = ServicioFachada.CrearLogOperacion(objLogOperacionVM);
            return IdLogOperaciones;
        }

        public static List<Entidades.TransaccionesOficina> SeleccionarLogOperacionesTransaccion(long? IdOperacion, DateTime? FechaInicio, DateTime? FechaFin, string Documento, string UsuarioLogin, string RespuestaAFI)
        {
            List<Entidades.TransaccionesOficina> LLO = new List<Entidades.TransaccionesOficina>();

            var res = ServicioFachada.ConsultarLogOperacionTransaccion(IdOperacion, FechaInicio, FechaFin, Documento, UsuarioLogin, RespuestaAFI, null, null, null, true);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                res.Lista.ToList().ForEach(x => LLO.Add(new Entidades.TransaccionesOficina
                {
                    AprobadosField = x.Aprobados,
                    NoAprobadosField = x.NoAprobados,
                    OficinaField = x.Oficina,
                    ValorUnitarioField = x.ValorUnitario,
                    Producto = x.Producto,
                    IdProducto = x.IdProducto
                }));
            }

            return LLO;
        }

        public static List<LogOperaciones> SeleccionarLogOperaciones(long? IdOperacion, DateTime? FechaInicio, DateTime? FechaFin, string Documento, string UsuarioLogin, string RespuestaAFI, string IdOficina)
        {
            List<LogOperaciones> LLO = new List<LogOperaciones>();

            var res = ServicioFachada.ConsultarLogOperacion(IdOperacion, FechaInicio, FechaFin, Documento, UsuarioLogin, RespuestaAFI, null, null, IdOficina, true);

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
        #endregion

        #region ReporteIngresos

        public static long InsertarLogIngresos(LogAutenticacionVM LI)
        {
            return ServicioFachada.CrearLogAutenticacion(LI);
        }

        public static List<NewLogIngresos> ObtenerLogIngresos(string fechaIngreso, string fechaFin, string usuario, string ip, bool? estado)
        {
            List<NewLogIngresos> LI = new List<NewLogIngresos>();
            var res = ServicioFachada.ConsultarLogAutenticacion(Convert.ToDateTime(fechaIngreso), Convert.ToDateTime(fechaFin), usuario, ip, estado, true);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                res.Lista.ToList().ForEach(x => LI.Add(new NewLogIngresos()
                {
                    Exitoso2 = x.Exitoso ? "SI" : "NO",
                    Fecha = x.FechaIngreso,
                    //FechaFin = Convert.ToDateTime(x.),
                    IdOficina = x.IdOficina,
                    Ip = x.IpTerminal,
                    Mac = x.MacTerminal,
                    UsuarioLogin = x.UsuarioLogin,
                    Exitoso = null
                }));
            }
            return LI;
        }

        public static void ActualizarSalidaAplicacion(long idAutenticacion)
        {
            ServicioFachada.ActualizarFechaLogAutenticacion(idAutenticacion);
        }

        #endregion

        #region LogTiemposRespuesta

        public static void ProcessDataAsync(LogTiempoRespuesta Log)
        {
            //ServicioFachada 
        }

        public static List<LogTiempoRespuesta> ObtenerTiemposRespuesta(string fechaIngreso, string fechaFin)
        {
            List<LogTiempoRespuesta> LTR = new List<LogTiempoRespuesta>();
            var res = ServicioFachada.ConsultarLogTiemposRespuesta(Convert.ToDateTime(fechaIngreso), Convert.ToDateTime(fechaFin), true);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                res.Lista.ToList().ForEach(x => LTR.Add(new LogTiempoRespuesta()
                {
                    Capa = x.Capa,
                    Duracion = x.Duracion,
                    FechaFin = x.FechaFin,
                    FechaInicio = x.FechaInicio,
                    Grupo = x.Grupo,
                    Ip = x.IpTerminal,
                    Metodo = x.Metodo,
                    Parametros = x.Parametros
                }));
            }
            return LTR;
        }
        #endregion

        #region LogErrores

        public static List<LogErrores> ObtenerLogErrores(string fechaIngreso, string fechaFin, string usuario)
        {
            List<LogErrores> LE = new List<LogErrores>();
            var res = ServicioFachada.ConsultarLogError(Convert.ToDateTime(fechaIngreso), Convert.ToDateTime(fechaFin), usuario, false);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                res.Lista.ToList().ForEach(x => LE.Add(new LogErrores()
                {
                    Capa = x.Capa,
                    Descripcion = x.Descripcion,
                    Fecha = (DateTime)x.Fecha,
                    Ip = x.IpTerminal,
                    Mac = x.MacTerminal,
                    Metodo = x.Metodo,
                    UsuarioLogin = x.UsuarioLogin
                }));
            }

            return LE;
        }

        public static void InsertarLogError(LogErrorVM Error)
        {
            var res = ServicioFachada.CrearLogError(Error);
        }
        #endregion

        #region FormatoProteccion
        public static List<Entidades.FormatoProteccion> ConsultarAceptaNoAcepta(DateTime fechaInicio, DateTime fechaFin, string usuario, string Oficina, string numeroDocumento, string oficinaOrigen)
        {
            List<Entidades.FormatoProteccion> FP = new List<FormatoProteccion>();
            var res = ServicioFachada.ConsultarAceptaNoAcepta(fechaInicio, fechaFin, usuario, Oficina, numeroDocumento, oficinaOrigen);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                res.Lista.ToList().ForEach(x => FP.Add(new FormatoProteccion
                {
                    Aceptacion = x.Aceptacion,
                    DocumentoAutorizacion = x.DocumentoAutorizacion,
                    FechaIngreso = x.FechaIngreso,
                    IdOficina = x.IdOficina,
                    IpTerminal = x.IpTerminal,
                    Login = x.Login,
                    NumeroDocumento = x.NumeroDocumento,
                    Producto = x.Producto,
                    Sigla = x.Sigla
                }));
            }
            return FP;
        }

        #endregion
    }
}
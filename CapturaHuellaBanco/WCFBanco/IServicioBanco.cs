using Entidades;
using Entidades.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFBanco
{
    [ServiceContract]
    public interface IServicioBanco
    {
        #region Biometria
        [OperationContract(Name = "ObtenerBiometrias")]
        ParametrosBiometria_TiposDoc ObtenerBiometrias(int _IdCliente, Guid _IdConvenioAutenticacion);

        [OperationContract(Name = "VerificarIdentidad")]
        LogOperaciones VerificarIdentidad(int _IdCliente, Guid _IdConvenioAutenticacion, string UsuarioLogin, string IdOficina, int IdProducto, string _Tramite, string Sigla, string NumeroDocumento, List<HuellaAFI> Dedos, string IP, string MAC, string _Serial, long _IdAutorizacion);

        [OperationContract(Name = "CrearAutorizacionCandidato")]
        long CrearAutorizacionCandidato(bool acepta, byte[] DocumentoAutorizacion, string _IdOficina, int _IdProducto, byte[] ImagenHuella, string _Ip, string _Usuario, string _Documento, string _Sigla, byte[] TemplateHuella);
        #endregion

        [OperationContract(Name = "SeleccionarLogTransacciones")]
        List<Entidades.TransaccionesOficina> SeleccionarLogTransacciones(long? IdOperacion, DateTime? FechaInicio, DateTime? FechaFin, string Documento, string UsuarioLogin, string RespuestaAFI);

        [OperationContract(Name = "SeleccionarLogOperaciones")]
        List<Entidades.LogOperaciones> SeleccionarLogOperaciones(long? IdOperacion, DateTime? FechaInicio, DateTime? FechaFin, string Documento, string UsuarioLogin, string RespuestaAFI, string IdOficina);

        [OperationContract(Name = "IsAuthenticated")]
        UsuarioLogin IsAuthenticated(string Dominio, string Usuario, string Password, string MAC);

        #region LogIngresos
        [OperationContract(Name = "InsertarIngreso")]
        long InsertarIngreso(string usuarioLogin, DateTime fecha, string ip, string mac, long idSucursal, Boolean exitoso);

        [OperationContract(Name = "ObtenerIngresosAplicacion")]
        List<NewLogIngresos> ObtenerIngresosAplicacion(string fechaIngreso, string fechaFin, string usuario, string ip, bool? estado);

        [OperationContract(Name = "ActualizarSalidaAplicacion")]
        void ActualizarSalidaAplicacion(long idAutenticacion, string usuario);

        #endregion

        #region LogReporteTiemposRespuesta

        [OperationContract(Name = "ObtenerTiemposRespuesta")]
        List<LogTiempoRespuesta> ObtenerTiemposRespuesta(string fechaIngreso, string fechaFin);

        #endregion

        #region LogErrores

        [OperationContract(Name = "ObtenerLogErrores")]
        List<LogErrores> ObtenerLogErrores(string fechaIngreso, string fechaFin, string usuario);

        [OperationContract(Name = "InsertarLogError")]
        void InsertarLogError(LogErrores Error);

        #endregion

        #region Dashboard
        //[OperationContract(Name = "ObtenerSolicitudesXAccion")]
        //List<CantidadSolicitudes> ObtenerSolicitudesXAccion();

        //[OperationContract(Name = "RespuestaXsolicitud")]
        //List<RespuestaXsolicitud> RespuestaXsolicitud();

        //[OperationContract(Name = "TiemposDentroYFuera")]
        //List<TiemposDentroYFuera> TiemposDentroYFuera();

        //[OperationContract(Name = "SolicitudesAprobadassXServicio")]
        //List<SolicitudesAprobadassXServicio> SolicitudesAprobadassXServicio(string fechaInicio, string fechaFin);

        [OperationContract(Name = "SolicitudesAprobadassVSNoAprobadas")]
        List<SolicitudesAprobadassVSNoAprobadas> SolicitudesAprobadassVSNoAprobadas(string fechaInicio, string fechaFin);

        [OperationContract(Name = "HitsVSNoHitsXDias")]
        List<HitsVSNoHitsXDias> HitsVSNoHitsXDias(int dias);

        [OperationContract(Name = "AprobadosHoy")]
        int AprobadosHoy(string fechaInicio, string fechaFin);

        [OperationContract(Name = "NoAprobadosHoy")]
        int NoAprobadosHoy(string fechaInicio, string fechaFin);

        [OperationContract(Name = "AprobadosHoyAsesor")]
        int AprobadosHoyAsesor(string fechaInicio, string fechaFin, string _Asesor);

        [OperationContract(Name = "NoAprobadosHoyAsesor")]
        int NoAprobadosHoyAsesor(string fechaInicio, string fechaFin, string _Asesor);

        [OperationContract(Name = "HitsVSNoHitsXDiasAsesor")]
        List<HitsVSNoHitsXDias> HitsVSNoHitsXDiasAsesor(int dias, string _Asesor);
        #endregion

        #region FormatoProteccionDatos
        [OperationContract(Name = "ObtenerFormatoProteccionDatos")]
        RespuestaFormatos ObtenerFormatoProteccionDatos(int idCliente, Guid idConvenioautenticacion);

        [OperationContract(Name = "ConsultarAceptaNoAcepta")]
        List<Entidades.FormatoProteccion> ConsultarAceptaNoAcepta(DateTime fechaInicio, DateTime fechaFin, string usuario, string Oficina, string numeroDocumento, string oficinaOrigen);
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using WCFBanco.ServicioFachadaOlimpia;

namespace WCFBanco
{
    public class DashBoard
    {
        private static IServicioColpatria ServicioFachada = new ServicioColpatriaClient();

        public static List<CantidadSolicitudes> ObtenerSolicitudesXAccion()
        {
            List<CantidadSolicitudes> LCS = new List<CantidadSolicitudes>();
            var res = ServicioFachada.ConsultarCantidadSolicitudesXAccion(false);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                res.Lista.ToList().ForEach(x => LCS.Add(new CantidadSolicitudes()
                    {
                        Accion = x.Accion,
                        Cantidad = x.Cantidad
                    }));
            }
            return LCS;
        }

        public static List<RespuestaXsolicitud> RespuestaXsolicitud()
        {
            List<RespuestaXsolicitud> LRS = new List<RespuestaXsolicitud>();
            var res = ServicioFachada.ConsultarCantidadEstadosXSolicitud(false);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                res.Lista.ToList().ForEach(x => LRS.Add(new RespuestaXsolicitud()
                    {
                        Accion = x.Accion,
                        Cantidad = x.Cantidad,
                        RespuestaAFI = x.RespuestaAFI,
                    }));
            }
            return LRS;
        }

        public static List<TiemposDentroYFuera> TiemposDentroYFuera()
        {
            List<TiemposDentroYFuera> LTR = new List<TiemposDentroYFuera>();
            var res = ServicioFachada.ConsultarCantidadTiemposDentroFuera(false);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                res.Lista.ToList().ForEach(x => LTR.Add(new TiemposDentroYFuera()
                {
                    Dentro = x.Dentro,
                    Fuera = x.Fuera
                }));
            }
            return LTR;
        }

        public static List<SolicitudesAprobadassXServicio> SolicitudesAprobadassXServicio(string fechaInicio, string fechaFin)
        {
            List<SolicitudesAprobadassXServicio> LSAS = new List<SolicitudesAprobadassXServicio>();
            var res = ServicioFachada.ConsultarSolicitudesAprobadasXServicio(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin), false);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                res.Lista.ToList().ForEach(x => LSAS.Add(new SolicitudesAprobadassXServicio()
                {
                    Accion = x.Accion,
                    Cantidad = x.Cantidad
                }));
            }
            return LSAS;
        }

        public static List<SolicitudesAprobadassVSNoAprobadas> SolicitudesAprobadassVSNoAprobadas(string fechaInicio, string fechaFin)
        {
            List<SolicitudesAprobadassVSNoAprobadas> Entidad = new List<SolicitudesAprobadassVSNoAprobadas>();
            var res = ServicioFachada.ConsultarSolicitudesAprobadasNoAprobadas(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin), false);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                res.Lista.ToList().ForEach(x => Entidad.Add(new SolicitudesAprobadassVSNoAprobadas()
                {
                    Accion = x.Accion,
                    Cantidad = x.Cantidad
                }));
            }
            return Entidad;
        }

        public static List<HitsVSNoHitsXDias> HitsVSNoHitsXDias(int dias)
        {
            List<HitsVSNoHitsXDias> Entidad = new List<HitsVSNoHitsXDias>();
            var res = ServicioFachada.ConsultarAprobadosNoAprobadosXDias(dias, true);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                res.Lista.ToList().ForEach(x => Entidad.Add(new HitsVSNoHitsXDias()
                {
                    Aprobado = x.Aprobado,
                    Fecha = x.Fecha.ToString("dd/MM/yyyy"),
                    No_aprobado = x.NoAprobado
                }));
            }
            return Entidad;
        }

        public static int AprobadosHoy(string fechaInicio, string fechaFin)
        {
            int r = 0;
            var res = ServicioFachada.ConsultarAprobadosNoAprobadosXDias(1, false);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                r = res.Lista[0].Aprobado;
            }
            return r;
        }

        public static int NoAprobadosHoy(string fechaInicio, string fechaFin)
        {
            int r = 0;
            var res = ServicioFachada.ConsultarAprobadosNoAprobadosXDias(1, false);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                r = res.Lista[0].NoAprobado;
            }
            return r;
        }

        public static int AprobadosHoyAsesor(string fechaInicio, string fechaFin, string _Asesor)
        {
            int r = 0;
            var res = ServicioFachada.ConsultarAprobadosNoAprobadosXDiasAsesor(1, _Asesor, false);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                r = res.Lista[0].Aprobado;
            }
            return r;
        }

        public static int NoAprobadosHoyAsesor(string fechaInicio, string fechaFin, string _Asesor)
        {
            int r = 0;
            var res = ServicioFachada.ConsultarAprobadosNoAprobadosXDiasAsesor(1, _Asesor, false);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                r = res.Lista[0].NoAprobado;
            }
            return r;
        }

        public static List<HitsVSNoHitsXDias> HitsVSNoHitsXDiasAsesor(int dias, string _Asesor)
        {
            List<HitsVSNoHitsXDias> Entidad = new List<HitsVSNoHitsXDias>();
            var res = ServicioFachada.ConsultarAprobadosNoAprobadosXDiasAsesor(dias, _Asesor, true);

            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                res.Lista.ToList().ForEach(x => Entidad.Add(new HitsVSNoHitsXDias()
                {
                    Aprobado = x.Aprobado,
                    Fecha = x.Fecha.ToString("dd/MM/yyyy"),
                    No_aprobado = x.NoAprobado
                }));
            }
            return Entidad;
        }
    }
}
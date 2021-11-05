namespace Entidades
{
    public class CantidadSolicitudes : Estadisticas
    {
    }

    public class Estadisticas
    {
        public string Accion { get; set; }
        public int Cantidad { get; set; }
    }
    public class HitsVSNoHitsXDias
    {
        public int Aprobado { get; set; }
        public string Fecha { get; set; }
        public int No_aprobado { get; set; }
    }

    public class RespuestaXsolicitud : Estadisticas
    {
        public string RespuestaAFI { get; set; }
    }

    public class SolicitudesAprobadassVSNoAprobadas : Estadisticas
    {
    }

    public class SolicitudesAprobadassXServicio : Estadisticas
    {
    }

    public class TiemposDentroYFuera
    {
        public int Dentro { get; set; }
        public int Fuera { get; set; }
    }
}
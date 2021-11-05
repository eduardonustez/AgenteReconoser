using System;

namespace Entidades
{
    public class LogTiempoRespuesta
    {
        public string Capa { get; set; }
        public string Duracion { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaInicio { get; set; }
        public Guid? Grupo { get; set; }
        public string Ip { get; set; }
        public string Metodo { get; set; }
        public string Parametros { get; set; }
    }

    public class NewLogTiempoRespuesta
    {
        public string Capa { get; set; }
        public string Duracion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public string Metodo { get; set; }
    }
}
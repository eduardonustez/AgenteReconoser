using System;

namespace Entidades
{
    public class RespuestaSolicitudAPI
    {
        public string Candidato { get; set; }
        public int EstadoSolicitud { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int IdConvenioAutenticacion { get; set; }
        public string IdMaquina { get; set; }
        public int IdOficina { get; set; }
        public Guid IdPeticion { get; set; }
        public int IdProducto { get; set; }
        public string IdSolicitudCliente { get; set; }
        public int IdSolicitudConvenioRNEC { get; set; }
        public int TiempoValidez { get; set; }
        public string TipoIdentificacionCandidato { get; set; }
        public string UsuarioCreacion { get; set; }
        private int TipoIdentidadMaquina { get; set; }
    }
}
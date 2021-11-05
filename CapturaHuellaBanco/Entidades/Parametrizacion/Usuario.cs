using System;

namespace Entidades.Parametrizacion
{
    public class Usuario
    {
        public string Area { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool Habilitado { get; set; }
        public string IdOficina { get; set; }
        public int IdRol { get; set; }
        public string IdTipoIdentificacion { get; set; }
        public string IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public short TipoAutenticacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string usuario { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
using System;

namespace Entidades.Parametrizacion
{
    public class Parametros
    {
        public DateTime? FechaModificacion { get; set; }
        public int IdParametro { get; set; }
        public string Parametro { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Valor { get; set; }
    }
}
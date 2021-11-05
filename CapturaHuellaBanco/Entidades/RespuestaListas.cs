using System.Collections.Generic;

namespace Entidades
{
    public enum Estado
    {
        Ok,
        Error
    }

    public class RespuestaListas<T> : RespuestaServicio
    {
        public List<T> Lista { get; set; }
        public int Total { get; set; }
    }

    public class RespuestaServicio
    {
        public string CodigoError { get; set; }
        public string DescripcionError { get; set; }
        public Estado Estado { get; set; }
    }
}
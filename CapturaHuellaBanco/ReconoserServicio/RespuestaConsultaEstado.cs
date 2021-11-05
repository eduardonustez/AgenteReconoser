using System.Collections.Generic;

namespace ReconoserEstado
{
    public class RespuestaConsultaEstado
    {
        public string Estado { get; set; }
        public string Version { get; set; }
        public Dictionary<string, string> Propiedades { get; set; }
    }
}

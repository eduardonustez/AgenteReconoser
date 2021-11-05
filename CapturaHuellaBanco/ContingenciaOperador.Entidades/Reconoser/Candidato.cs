using System;

namespace ContingenciaOperador.Entidades.Reconoser
{
    public class Candidato
    {
        public ResultadosCotejo ResultadoCotejo { get; set; }
        public string Nuip { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int CodigoParticula { get; set; }
        public string Particula { get; set; }
        public string LugarExpedicion { get; set; }
        public DateTime? FechaExpedicion { get; set; }
        public int CodigoVigencia { get; set; }
        public string Vigencia { get; set; }
    }

    public enum ResultadosCotejo : byte
    {
        NOHIT = 0,
        HIT = 1,
        ERROR = 2
    }
}

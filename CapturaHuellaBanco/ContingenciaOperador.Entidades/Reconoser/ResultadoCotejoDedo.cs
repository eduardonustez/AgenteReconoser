using System;

namespace ContingenciaOperador.Entidades.Reconoser
{
    public struct ResultadoCotejoDedo
    {
        public long NUT { get; set; }
        public ResultadosCotejo IdResultadoCotejo { get; set; }
        public int Dedo { get; set; }
        public int Score { get; set; }
        public string MensajeCotejo { get; set; }
    }
}

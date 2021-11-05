using System;

namespace Entidades.Parametrizacion
{
    public class Convenio
    {
        public ParametrosBiometria_TiposDoc Biometrias { get; set; }
        //public RespuestaFormatos FormatoAutorizacion { get; set; }
        public Guid idConvenio { get; set; }
        public string Nombre { get; set; }
        public string textoAutorizacion { get; set; }
    }
}
using System.Collections.Generic;

namespace ContingenciaOperador.Entidades.Reconoser
{
    public class RespuestaCotejo
    {
        public List<ResultadoCotejoDedo> lstResultadoCotejo { get; set; }
        public Candidato Candidato { get; set; }
        public CodigoRespuestaRNEC EstadoProceso { get; set; }//se llena con la informacion de estado ok si finalizo el proceso
        public string Mensaje { get; set; }
        public long NUT { get; set; }
    }
}

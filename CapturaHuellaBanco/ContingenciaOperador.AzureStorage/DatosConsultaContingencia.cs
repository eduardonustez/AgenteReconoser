using ContingenciaOperador.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContingenciaOperador.AzureStorage
{
    public class DatosConsultaContingencia
    {
        public DatosPeticionRS DatosPeticionRS { get; set; }
        public LogOperacionesContingencia LogOperacionRS { get; set; }
        public dynamic PeticionOperadorAliado { get; set; }
        public dynamic RespuestaOperadorAliado { get; set; }
        public byte[] Atdp { get; set; }
        public bool Migrado { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Entidades.Parametrizacion;

namespace Entidades
{
    [Serializable]
    public class ParametrosOperacion
    {
        public Guid ConvenioCliente { get; set; }

        public byte[] HC { get; set; }

        public byte[] HK { get; set; }

        public byte[] CA { get; set; }

        public string DK { get; set; }

        public int Score { get; set; }

        public int DedosHit { get; set; }

        public string IdOperadorContingencia { get; set; }

        public byte[] ATDP { get; set; }

        public RespuestaListas<Producto> Productos { get; set; }

        public Oficina Oficina { get; set; }

        public DateTime FechaRegistro { get; set; }

        public List<string> IPsPermitidas { get; set; }

        public string HoraInicioOperacion { get; set; }

        public string HoraFinOperacion { get; set; }

        public string URLEstampa { get; set; }

        public string UsuarioEstampa { get; set; }

        public string ClaveEstampa { get; set; }

        public string CadenaConexionAzure { get; set; }
        /*
        IdClienteRnec
IdProcesoCliente*/
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispositivos.Scanner.Models
{
    public class DatosPersonaDocumento
    {
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Genero { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string RH { get; set; }
        public long Cedula { get; set; }
    }
}

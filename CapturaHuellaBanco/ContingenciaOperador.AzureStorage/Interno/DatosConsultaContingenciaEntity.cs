using ContingenciaOperador.Entidades;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContingenciaOperador.AzureStorage.Interno
{
    internal class DatosConsultaContingenciaEntity : TableEntity
    {
        public DatosConsultaContingenciaEntity()
        {
        }

        public DatosConsultaContingenciaEntity(DatosPeticionRS datosPeticionRS,
            object logOperacionRS,
            object peticionOperadorAliado,
            object respuestaOperadorAliado)
        {
            PartitionKey = DateTime.UtcNow.ToString("yyyyMMdd");
            RowKey = datosPeticionRS?.IdPeticion.ToString()
                ?? throw new ArgumentNullException(nameof(datosPeticionRS.IdPeticion));
            DatosPeticionRS = JsonSerializer.Serialize(datosPeticionRS);
            LogOperacionRS = JsonSerializer.Serialize(logOperacionRS);
            PeticionOperadorAliado = JsonSerializer.Serialize(peticionOperadorAliado);
            RespuestaOperadorAliado = JsonSerializer.Serialize(respuestaOperadorAliado);
            Migrado = false;
        }
        public string DatosPeticionRS { get; set; }
        public string LogOperacionRS { get; set; }
        public string PeticionOperadorAliado { get; set; }
        public string RespuestaOperadorAliado { get; set; }
        public bool Migrado { get; set; }
    }
}

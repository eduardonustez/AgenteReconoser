using ContingenciaOperador.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContingenciaOperador.AzureStorage
{
    public interface IAlmacenamientoContingencia
    {
        Task<bool> Agregar(DatosPeticionRS datosPeticionRS,
            LogOperacionesContingencia logOperacionesRS,
            object peticionOperadorAliado,
            object respuestaOperadorAliado,
            byte[] atdp);

        Task<DatosConsultaContingencia> Consultar(Guid idPeticion, bool incluirATDP = false);
        IAsyncEnumerable<DatosConsultaContingencia> ConsultarPendientes(
            DateTime? fechaInicio,
            DateTime? fechaFin,
            int? paralelismoMaximo = null,
            int bufferMaximo = 0,
            int reintentosMaximos = 0,
            Action<Exception> enExcepcion = null);
        Task MarcarMigrado(Guid idPeticion);
    }
}
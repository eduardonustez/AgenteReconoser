using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ContingenciaOperador.AzureStorage.Interno;
using ContingenciaOperador.Entidades;
using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;
using Olimpia.Utilidades.Paralelismo;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ContingenciaOperador.AzureStorage
{
    public class AlmacenamientoContingencia : IAlmacenamientoContingencia
    {
        bool _tablaCreada = false;
        bool _contenedorCreado = false;
        internal CloudTable Tabla { get; private set; }
        internal BlobContainerClient Contenedor { get; private set; }
        public AlmacenamientoContingencia(CloudTable tabla, BlobContainerClient contenedor)
        {
            Tabla = tabla ??
                throw new ArgumentNullException(nameof(tabla));
            Contenedor = contenedor ??
                throw new ArgumentNullException(nameof(contenedor));
        }

        protected async Task CrearTablaSiNoExiste()
        {
            if (_tablaCreada)
                return;

            await Tabla.CreateIfNotExistsAsync();
            _tablaCreada = true;
        }

        protected async Task CrearContenedorSiNoExiste()
        {
            if (_contenedorCreado)
                return;

            await Contenedor.CreateIfNotExistsAsync();
            _contenedorCreado = true;
        }

        public async Task<bool> Agregar(DatosPeticionRS datosPeticionRS,
            LogOperacionesContingencia logOperaciones,
            object peticionOperadorAliado,
            object respuestaOperadorAliado,
            byte[] atdp)
        {
            await CrearTablaSiNoExiste();
            await CrearContenedorSiNoExiste();
            var fila = new DatosConsultaContingenciaEntity(datosPeticionRS,
                            logOperaciones,
                            peticionOperadorAliado,
                            respuestaOperadorAliado);

            TableResult resultado =
                await Tabla.ExecuteAsync(
                    TableOperation.Insert(fila));

            if (resultado.Result is DatosConsultaContingenciaEntity)
            {
                var blobClient = Contenedor.GetBlobClient($"{datosPeticionRS.IdPeticion}.pdf");

                var resultadoAtdp
                    = await blobClient.UploadAsync(new BinaryData(atdp));

                var blobHttpHeaders = new BlobHttpHeaders
                {
                    ContentType = "application/pdf"
                };
                await blobClient.SetHttpHeadersAsync(blobHttpHeaders);

                return resultadoAtdp.Value != null;
            }
            return false;
        }

        public async Task<DatosConsultaContingencia> Consultar(Guid idPeticion, bool incluirATDP = false)
        {
            var fila = await ObtenerFila(idPeticion);

            return fila == null ? null :
            new DatosConsultaContingencia()
            {
                DatosPeticionRS = JsonConvert.DeserializeObject<DatosPeticionRS>(fila.DatosPeticionRS),
                LogOperacionRS = JsonConvert.DeserializeObject<LogOperacionesContingencia>(fila.LogOperacionRS),
                PeticionOperadorAliado = JsonConvert.DeserializeObject(fila.PeticionOperadorAliado),
                RespuestaOperadorAliado = JsonConvert.DeserializeObject(fila.RespuestaOperadorAliado),
                Migrado = fila.Migrado,
                Atdp = incluirATDP ? await ObtenerATDP(idPeticion) : null
            };
        }

        public IAsyncEnumerable<DatosConsultaContingencia> ConsultarPendientes(
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null,
            int? paralelismoMaximo = null,
            int bufferMaximo = 0,
            int reintentosMaximos = 0,
            Action<Exception> enExcepcion = null)
        {
            return AsyncStreamParallel.Select(ConsultarDatosPendientes(fechaInicio, fechaFin),
                async (datos, cancelacion) =>
                {
                    for (int intentos = 0; intentos <= reintentosMaximos; intentos++)
                    {
                        cancelacion.ThrowIfCancellationRequested();
                        try
                        {
                            datos.Atdp = await ObtenerATDP(datos.DatosPeticionRS.IdPeticion, cancelacion);
                            break;
                        }
                        catch (Exception ex)
                        {
                            enExcepcion?.Invoke(ex);
                        }
                    }
                    return datos;
                }, maxParallelism: paralelismoMaximo,
                maxBufferSize: bufferMaximo,
                preserveOrder: false);
        }

        private async IAsyncEnumerable<DatosConsultaContingencia> ConsultarDatosPendientes(
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null,
            [EnumeratorCancellation] CancellationToken cancelacion = default)
        {
            var condicion =
                TableQuery.GenerateFilterConditionForBool(
                    nameof(DatosConsultaContingenciaEntity.Migrado),
                    QueryComparisons.Equal,
                    false);

            void componer(DateTime? fecha, string comparacion)
            {
                if (fecha == null) return;

                var condicionFecha =
                    TableQuery.GenerateFilterCondition(
                        nameof(DatosConsultaContingenciaEntity.PartitionKey),
                        comparacion,
                        fecha.Value.ToString("yyyyMMdd")
                        );
                condicion = TableQuery.CombineFilters(
                    condicion, TableOperators.And, condicionFecha);
            };

            componer(fechaInicio, QueryComparisons.GreaterThanOrEqual);
            componer(fechaFin, QueryComparisons.LessThanOrEqual);

            var query = new TableQuery<DatosConsultaContingenciaEntity>()
                .Where(condicion);

            TableContinuationToken token = null;
            do
            {
                var resultado = await Tabla.ExecuteQuerySegmentedAsync(query, token, cancelacion);
                foreach (var fila in resultado)
                {
                    yield return new DatosConsultaContingencia()
                    {
                      
                        DatosPeticionRS = JsonConvert.DeserializeObject<DatosPeticionRS>(fila.DatosPeticionRS),
                        LogOperacionRS = JsonConvert.DeserializeObject<LogOperacionesContingencia>(fila.LogOperacionRS),
                        PeticionOperadorAliado = JsonConvert.DeserializeObject(fila.PeticionOperadorAliado),
                        RespuestaOperadorAliado = JsonConvert.DeserializeObject(fila.RespuestaOperadorAliado),
                        Migrado = fila.Migrado
               
                    };
                }
                token = resultado.ContinuationToken;
            } while (token != null);
        }

        public async Task MarcarMigrado(Guid idPeticion)
        {
            var fila = await ObtenerFila(idPeticion);

            fila.Migrado = true;

            await Tabla.ExecuteAsync(TableOperation.Merge(fila));
        }

        internal async Task<byte[]> ObtenerATDP(Guid idPeticion, CancellationToken cancelacion = default)
        {
            var blobClient = Contenedor.GetBlobClient($"{idPeticion}.pdf");
            return (await blobClient.DownloadContentAsync(cancelacion)).Value.Content.ToArray();
        }

        internal async Task<DatosConsultaContingenciaEntity> ObtenerFila(Guid idPeticion)
        {
            var condicion =
                TableQuery.GenerateFilterCondition(
                    nameof(DatosConsultaContingenciaEntity.RowKey),
                    QueryComparisons.Equal,
                    idPeticion.ToString());

            var query = new TableQuery<DatosConsultaContingenciaEntity>()
                .Where(condicion);


            TableContinuationToken token = null;
            do
            {
                var resultado = await Tabla.ExecuteQuerySegmentedAsync(query, token);
                foreach (var fila in resultado)
                {
                    return fila;
                }
                token = resultado.ContinuationToken;
            } while (token != null);

            return null;
        }
    }
}

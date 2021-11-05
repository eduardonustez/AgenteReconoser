using Azure.Storage.Blobs;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContingenciaOperador.AzureStorage.Interno
{
    internal class Conexion : IConexion
    {
        private CloudTableClient _tableClient;
        private BlobServiceClient _blobServiceClient;
        public Conexion (CloudTableClient tableClient, BlobServiceClient blobServiceClient)
        {
            _tableClient = tableClient;
            _blobServiceClient = blobServiceClient;
        }
        public IAlmacenamientoContingencia ObtenerAlmacenamiento(string tabla, string contenedor)
        {
            string contenedorHypen = StringUtils.CamelCaseToHyphen(contenedor);

            var tablaRef = _tableClient.GetTableReference(tabla);
            var blobClient = _blobServiceClient.GetBlobContainerClient(contenedorHypen);

            return new AlmacenamientoContingencia(tablaRef, blobClient);
        }
    }
}

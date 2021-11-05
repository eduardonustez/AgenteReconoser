using Azure.Storage.Blobs;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContingenciaOperador.AzureStorage.Interno
{
    internal class FabricaConexion : IFabricaConexion
    {
        public IConexion Obtener(string cadenaConexionTablas, string cadenaConexionArchivos)
        {
            var clienteTablas = CloudStorageAccount.Parse(cadenaConexionTablas)
                                                .CreateCloudTableClient();
            var clienteArchivos = new BlobServiceClient(cadenaConexionArchivos);
            return new Conexion(clienteTablas, clienteArchivos);
        }
    }
}

using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContingenciaOperador.AzureStorage.Interno
{
    internal interface IFabricaConexion
    {
        IConexion Obtener(string cadenaConexionTablas, string cadenaConexionArchivos);
    }
}

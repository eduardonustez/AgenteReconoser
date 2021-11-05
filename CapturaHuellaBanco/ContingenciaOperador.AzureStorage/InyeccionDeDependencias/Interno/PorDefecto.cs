using ContingenciaOperador.AzureStorage.Interno;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContingenciaOperador.AzureStorage.InyeccionDeDependencias.Interno
{
    internal static class PorDefecto
    {
        public static IFabricaConexion FabricaStorageAccount
            => new FabricaConexion();
    }
}

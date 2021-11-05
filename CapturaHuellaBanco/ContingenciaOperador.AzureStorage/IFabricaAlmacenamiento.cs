using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContingenciaOperador.AzureStorage
{
    public interface IFabricaAlmacenamiento
    {
        IAlmacenamientoContingencia Obtener(Configuracion configuracion);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContingenciaOperador.AzureStorage.Interno
{
    internal interface IConexion
    {
        IAlmacenamientoContingencia ObtenerAlmacenamiento(string tabla, string contenedor);
    }
}

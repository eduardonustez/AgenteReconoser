using ContingenciaOperador.AzureStorage.Interno;
using ContingenciaOperador.AzureStorage.InyeccionDeDependencias.Interno;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContingenciaOperador.AzureStorage
{
    public class FabricaAlmacenamiento : IFabricaAlmacenamiento
    {
        IFabricaConexion _fabricaConexion;
        public FabricaAlmacenamiento():
            this(PorDefecto.FabricaStorageAccount)
        { }

        internal FabricaAlmacenamiento(IFabricaConexion fabricaConexion)
        {
            _fabricaConexion = fabricaConexion
                ?? throw new ArgumentNullException(nameof(fabricaConexion));
        }

        public IAlmacenamientoContingencia Obtener(Configuracion configuracion)
        {
            var conexion = _fabricaConexion.Obtener(configuracion.CadenaDeConexionTablas, configuracion.CadenaDeConexionArchivos);
            return conexion.ObtenerAlmacenamiento(configuracion.Tabla, configuracion.ContenedorArchivos);
        }
    }
}

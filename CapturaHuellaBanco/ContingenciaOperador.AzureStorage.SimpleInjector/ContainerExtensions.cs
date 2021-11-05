using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContingenciaOperador.AzureStorage.SimpleInjector
{
    public static class ContainerExtensions
    {
        public static void AgregarAzureStorageContingencia(this Container container, Configuracion configuracion)
        {
            var copiaConfiguracion = configuracion.Copia();

            container.Register(() => copiaConfiguracion.Copia(),
                                Lifestyle.Scoped);
            container.Register<IFabricaAlmacenamiento, FabricaAlmacenamiento>(Lifestyle.Scoped);
            container.Register(() =>
                    container.GetInstance<IFabricaAlmacenamiento>()
                        .Obtener(container.GetInstance<Configuracion>()),
                        Lifestyle.Scoped
            );
        }
    }
}

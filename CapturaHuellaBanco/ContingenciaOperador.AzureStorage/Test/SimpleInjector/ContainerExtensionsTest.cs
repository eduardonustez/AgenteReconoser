using ContingenciaOperador.AzureStorage.AppConfig;
using ContingenciaOperador.AzureStorage.SimpleInjector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContingenciaOperador.AzureStorage.Test.SimpleInjector
{

    [TestClass]
    public class ContainerExtensionsTest
    {
        private Container _contenedor;

        [TestInitialize]
        public void Init()
        {
            _contenedor = new Container();
            _contenedor.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            _contenedor.AgregarAzureStorageContingencia(Obtener.Configuracion);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _contenedor.Dispose();
        }

        [TestMethod]
        public void AlmacenamientoShouldBeNotNull()
        {

            using (AsyncScopedLifestyle.BeginScope(_contenedor))
            {
                Assert.IsNotNull(_contenedor.GetInstance<IAlmacenamientoContingencia>());
            }
        }

        [TestMethod]
        public async Task AlmacenamientoShouldBeDifferentInSimultaneousTasks()
        {
            int nHilos = 3;
            var almacenamientos = new IAlmacenamientoContingencia[nHilos];
            async Task TareaLarga(int hilo)
            {
                using (AsyncScopedLifestyle.BeginScope(_contenedor))
                {
                    var almacenamientoInicio
                        = _contenedor.GetInstance<IAlmacenamientoContingencia>();

                    await Task.Delay(200*(hilo+1));

                    var almacenamientoFin
                        = _contenedor.GetInstance<IAlmacenamientoContingencia>();

                    Assert.AreSame(almacenamientoInicio, almacenamientoFin);
                    almacenamientos[hilo] = _contenedor.GetInstance<IAlmacenamientoContingencia>();
                }
            };

            await Task.WhenAll(Enumerable.Range(0, 3)
                                    .Select(i => TareaLarga(i))
                                );

            for (int i = 0; i < nHilos; i++)
                for (int j = i + 1; j < nHilos; j++)
                    Assert.AreNotSame(almacenamientos[i], almacenamientos[j]);
        }
    }
}

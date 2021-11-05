using ContingenciaOperador.AzureStorage.AppConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace ContingenciaOperador.AzureStorage.Test.AppConfig
{
    [TestClass]
    public class ConfigurationTest
    {
        private const string DEV_CONNECTION_STRING =
            "DefaultEndpointsProtocol=https;AccountName=sacaeudevcontingencia;AccountKey=r9f8vKLDYx49Tv27ZCNgGu6G2ksujgmpK9QHtp54xsvEC8b7OzDq+p1zMeYn0ZGDAaPaeqJYpzSp4yssmhN6qg==;EndpointSuffix=core.windows.net";
        private const string DEV_TABLE_NAME =
            "PruebasIntegracion";

        [TestMethod]
        public void TableConnectionStringShouldBeReadFromAppConfig()
        {
            string expected = DEV_CONNECTION_STRING;
            Assert.AreEqual(expected, Obtener.Configuracion.CadenaDeConexionTablas);
        }

        [TestMethod]
        public void BlobConnectionStringShouldBeReadFromAppConfig()
        {
            string expected = DEV_CONNECTION_STRING;
            Assert.AreEqual(expected, Obtener.Configuracion.CadenaDeConexionArchivos);
        }

        [TestMethod]
        public void TableNameShouldBeReadFromAppConfig()
        {
            string expected = DEV_TABLE_NAME;
            Assert.AreEqual(expected, Obtener.Configuracion.Tabla);
        }

        [TestMethod]
        public void AlmacenamientoShouldBeNotNull()
        {
            Assert.IsNotNull(Obtener.Almacenamiento);
        }
    }
}

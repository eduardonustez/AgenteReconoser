using ContingenciaOperador.AzureStorage;
using System;
using Xunit;

namespace Contingencia.Operador.AzureStorage.Test.Core
{
    public class ConfigurationTest
    {
        private const string DEV_CONNECTION_STRING =
            "DefaultEndpointsProtocol=https;AccountName=sacaeudevcontingencia;AccountKey=r9f8vKLDYx49Tv27ZCNgGu6G2ksujgmpK9QHtp54xsvEC8b7OzDq+p1zMeYn0ZGDAaPaeqJYpzSp4yssmhN6qg==;EndpointSuffix=core.windows.net";

        [Fact]
        public void TableConnectionStringShouldBeReadFromAppConfig()
        {
            string expected = DEV_CONNECTION_STRING;
            Assert.Equal(expected, Configuration.TableConnectionString);
        }

        [Fact]
        public void BlobConnectionStringShouldBeReadFromAppConfig()
        {
            string expected = DEV_CONNECTION_STRING;
            Assert.Equal(expected, Configuration.BlobConnectionString);
        }
    }
}

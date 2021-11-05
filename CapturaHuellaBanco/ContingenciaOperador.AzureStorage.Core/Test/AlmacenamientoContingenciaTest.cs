using Azure.Storage.Blobs;
using ContingenciaOperador.Entidades;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ContingenciaOperador.AzureStorage.Core.Test
{
    public class AlmacenamientoCOntingenciaFixture : IAsyncLifetime
    {
        private readonly Configuracion _configuracion;
        public AlmacenamientoContingencia Sut { get; private set; }
        public AlmacenamientoCOntingenciaFixture(IAlmacenamientoContingencia sut, Configuracion configuracion)
        {
            if (sut is AlmacenamientoContingencia sutObj)
            {
                Sut = sutObj;
            }
            else
            {
                Assert.True(false);
            }
            _configuracion = configuracion;
        }
        public async Task DisposeAsync()
        {
            {
                var client = CloudStorageAccount.Parse(_configuracion.CadenaDeConexionTablas)
                                                    .CreateCloudTableClient();

                var tabla = client.GetTableReference(_configuracion.Tabla);
                await tabla.DeleteAsync();
            }
            {
                var client = new BlobContainerClient(_configuracion.CadenaDeConexionArchivos,
                    StringUtils.CamelCaseToHyphen(_configuracion.ContenedorArchivos));
                await client.DeleteAsync();
            }

        }

        public async Task InitializeAsync()
        {
            Guid ultimoGuid = Guid.NewGuid();
            for (int i = 0; i < 4; i++)
            {
                DatosPeticionRS datosPeticionRS = new DatosPeticionRS()
                {
                    Asesor = "jsilva",
                    Convenio = Guid.NewGuid(),
                    Documento = "123456789",
                    IdCliente = 123,
                    IdOficina = "Of. 123",
                    IdPeticion = Guid.NewGuid(),
                    IdProducto = 321,
                    IdServicio = 456,
                    IP = "0.0.0.0",
                    Mac = "90-E3-7A-25-14-63",
                    Marca = "Morpho",
                    Modelo = "MSO-1300",
                    Serial = "ABCD-123",
                    TipoBiometrico = 1,
                    TipoDocumento = "CC",
                    Tramite = "prueba"
                };

                var logOperaciones = new LogOperacionesContingencia
                {
                    RespuestaAFI = "HIT"
                };

                object peticionOperadorAliado = new
                {
                    Documento = "123456789",
                    Metadata = "ABCDEF"
                };

                object respuestaOperadorAliado = new
                {
                    HIT = true,
                    Nombre = "ABC",
                    Apellido = "DEF"
                };

                byte[] atdp = { 0x00, 0x01, 0x02 };

                await Sut.Agregar(datosPeticionRS, logOperaciones, peticionOperadorAliado, respuestaOperadorAliado, atdp);
                ultimoGuid = datosPeticionRS.IdPeticion;
            }

            await Sut.MarcarMigrado(ultimoGuid);
        }
    }

    public class AlmacenamientoContingenciaTest : IClassFixture<AlmacenamientoCOntingenciaFixture>
    {
        private readonly AlmacenamientoContingencia _sut;

        public AlmacenamientoContingenciaTest(AlmacenamientoCOntingenciaFixture data)
        {
            _sut = data.Sut;
        }

        [Fact]
        public void SutShouldNotBeNull()
        {
            Assert.NotNull(_sut);
        }

        [Fact]
        public async Task ConsultarPendientesShouldIterateOverTable()
        {
            int len = 0;
            await foreach (var pendiente in _sut.ConsultarPendientes())
            {
                Assert.False(pendiente.Migrado);
                Assert.NotNull(pendiente.Atdp);
                len++;
            }
            Assert.Equal(3, len);
        }
    }
}

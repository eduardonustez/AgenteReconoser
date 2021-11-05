using Azure.Storage.Blobs;
using ContingenciaOperador.AzureStorage.AppConfig;
using ContingenciaOperador.AzureStorage.SimpleInjector;
using ContingenciaOperador.Entidades;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Threading.Tasks;

namespace ContingenciaOperador.AzureStorage.Test
{
    [TestClass]
    public class AlmacenamientoContingenciaTest
    {
        static IAlmacenamientoContingencia _sut;
        static Guid? _guidInsertado = null;
        static Scope _scope;

        static readonly DatosPeticionRS _datosPeticionRS = new DatosPeticionRS()
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

        static readonly LogOperacionesContingencia _logOperaciones = new LogOperacionesContingencia()
        {
            RespuestaAFI = "HIT"
        };

        static readonly dynamic _peticionOperadorAliado = new
        {
            Documento = "123456789",
            Metadata = "ABCDEF"
        };

        static readonly dynamic _respuestaOperadorAliado = new
        {
            HIT = true,
            Nombre = "ABC",
            Apellido = "DEF"
        };

        static readonly byte[] _atdp = { 0x00, 0x01, 0x02 };

        [ClassInitialize]
        public static void Init(TestContext _)
        {
            var contenedor = new Container();
            contenedor.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            contenedor.AgregarAzureStorageContingencia(Obtener.Configuracion);

            _scope = AsyncScopedLifestyle.BeginScope(contenedor);
            _sut = contenedor.GetInstance<IAlmacenamientoContingencia>();
        }

        [ClassCleanup]
        public static async Task Cleanup()
        {
            await _scope.DisposeScopeAsync();
            if (_guidInsertado == null)
                return;

            var config = Obtener.Configuracion;
            {
                var client = CloudStorageAccount.Parse(config.CadenaDeConexionTablas)
                                                    .CreateCloudTableClient();
                var tabla = client.GetTableReference(config.Tabla);


                TableEntity del = new TableEntity()
                {
                    PartitionKey = DateTime.UtcNow.ToString("yyyyMMdd"),
                    RowKey = _guidInsertado.ToString(),
                    ETag = "*"
                };
                await tabla.ExecuteAsync(TableOperation.Delete(del));
            }
            {

                var client = new BlobClient(config.CadenaDeConexionArchivos,
                    StringUtils.CamelCaseToHyphen(config.ContenedorArchivos),
                    $"{_guidInsertado}.pdf");
                await client.DeleteAsync();
            }
        }


        [TestMethod]
        public async Task T1_AgregarDatos()
        {
            _guidInsertado = _datosPeticionRS.IdPeticion;

            var almacenado = await _sut.Agregar(_datosPeticionRS,
                                            _logOperaciones,
                                            _peticionOperadorAliado,
                                            _respuestaOperadorAliado,
                                            _atdp);

            Assert.IsTrue(almacenado);
        }

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public async Task T2_ObtenerDatos(bool incluirATDP)
        {
            if (_guidInsertado == null)
                Assert.Fail();

            var consultado = await _sut.Consultar(_guidInsertado.Value, incluirATDP);

            Assert.AreEqual(_datosPeticionRS.Asesor, consultado.DatosPeticionRS.Asesor);
            Assert.AreEqual(_datosPeticionRS.Convenio, consultado.DatosPeticionRS.Convenio);
            Assert.AreEqual(_datosPeticionRS.Documento, consultado.DatosPeticionRS.Documento);
            Assert.AreEqual(_datosPeticionRS.IdCliente, consultado.DatosPeticionRS.IdCliente);
            Assert.AreEqual(_datosPeticionRS.IdOficina, consultado.DatosPeticionRS.IdOficina);
            Assert.AreEqual(_datosPeticionRS.IdPeticion, consultado.DatosPeticionRS.IdPeticion);
            Assert.AreEqual(_datosPeticionRS.IdProducto, consultado.DatosPeticionRS.IdProducto);
            Assert.AreEqual(_datosPeticionRS.IdServicio, consultado.DatosPeticionRS.IdServicio);
            Assert.AreEqual(_datosPeticionRS.IP, consultado.DatosPeticionRS.IP);
            Assert.AreEqual(_datosPeticionRS.Mac, consultado.DatosPeticionRS.Mac);
            Assert.AreEqual(_datosPeticionRS.Marca, consultado.DatosPeticionRS.Marca);
            Assert.AreEqual(_datosPeticionRS.Modelo, consultado.DatosPeticionRS.Modelo);
            Assert.AreEqual(_datosPeticionRS.Serial, consultado.DatosPeticionRS.Serial);
            Assert.AreEqual(_datosPeticionRS.TipoBiometrico, consultado.DatosPeticionRS.TipoBiometrico);
            Assert.AreEqual(_datosPeticionRS.TipoDocumento, consultado.DatosPeticionRS.TipoDocumento);
            Assert.AreEqual(_datosPeticionRS.Tramite, consultado.DatosPeticionRS.Tramite);

            Assert.AreEqual(_logOperaciones.RespuestaAFI, consultado.LogOperacionRS.RespuestaAFI);

            Assert.AreEqual(_peticionOperadorAliado.Documento, (string)consultado.PeticionOperadorAliado.Documento);
            Assert.AreEqual(_peticionOperadorAliado.Metadata, (string)consultado.PeticionOperadorAliado.Metadata);

            Assert.AreEqual(_respuestaOperadorAliado.HIT, (bool)consultado.RespuestaOperadorAliado.HIT);
            Assert.AreEqual(_respuestaOperadorAliado.Nombre, (string)consultado.RespuestaOperadorAliado.Nombre);
            Assert.AreEqual(_respuestaOperadorAliado.Apellido, (string)consultado.RespuestaOperadorAliado.Apellido);

            Assert.IsFalse(consultado.Migrado);

            CollectionAssert.AreEqual(incluirATDP ? _atdp : null, consultado.Atdp);
        }
    }
}

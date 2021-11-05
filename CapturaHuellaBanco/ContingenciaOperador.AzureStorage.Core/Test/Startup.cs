using ContingenciaOperador.AzureStorage.Core.InyeccionDeDependencias;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ContingenciaOperador.AzureStorage.Core.Test
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup()
        {
            Random random = new Random();
            var run_code = new string(Enumerable.Range(1, 5)
                    .Select(i => (char)random.Next('a', 'z'))
                    .ToArray());

            var fileConfiguration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var newValues = new List<KeyValuePair<string, string>>();
            foreach (var prop in new[] { nameof(Configuracion.Tabla), nameof(Configuracion.ContenedorArchivos) })
            {

                var address = $"{StartupExtensions.SECCION}:{prop}";
                var value =
                    fileConfiguration.GetSection(address)
                    .Value;

                newValues.Add(new KeyValuePair<string, string>(address, $"{value}{run_code}"));
            }

            Configuration = new ConfigurationBuilder()
                .AddConfiguration(fileConfiguration)
                .AddInMemoryCollection(newValues)
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AgregarAzureStorageContingencia(Configuration);
            var configuracion = new Configuracion()
            {
                CadenaDeConexionArchivos = Configuration.GetSection($"{StartupExtensions.SECCION}:{nameof(Configuracion.CadenaDeConexionArchivos)}").Value,
                CadenaDeConexionTablas = Configuration.GetSection($"{StartupExtensions.SECCION}:{nameof(Configuracion.CadenaDeConexionTablas)}").Value,
                Tabla = Configuration.GetSection($"{StartupExtensions.SECCION}:{nameof(Configuracion.Tabla)}").Value,
                ContenedorArchivos = Configuration.GetSection($"{StartupExtensions.SECCION}:{nameof(Configuracion.ContenedorArchivos)}").Value
            };
            services.AddSingleton(configuracion);
        }
    }
}

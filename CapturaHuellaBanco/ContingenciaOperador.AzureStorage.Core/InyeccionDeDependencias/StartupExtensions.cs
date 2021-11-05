using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContingenciaOperador.AzureStorage.Core.InyeccionDeDependencias
{
    public static class StartupExtensions
    {
        public const string SECCION = "ContingenciaOperador.AzureStorage";
        public static void AgregarAzureStorageContingencia(this IServiceCollection services, IConfiguration configuration)
        {
            var configuracion = new Configuracion()
            {
                CadenaDeConexionArchivos = configuration.GetSection($"{SECCION}:{nameof(Configuracion.CadenaDeConexionArchivos)}").Value,
                CadenaDeConexionTablas = configuration.GetSection($"{SECCION}:{nameof(Configuracion.CadenaDeConexionTablas)}").Value,
                Tabla = configuration.GetSection($"{SECCION}:{nameof(Configuracion.Tabla)}").Value,
                ContenedorArchivos = configuration.GetSection($"{SECCION}:{nameof(Configuracion.ContenedorArchivos)}").Value
            };

            services.AddScoped<IFabricaAlmacenamiento, FabricaAlmacenamiento>();
            services.AddScoped((provider) =>
                    provider.GetRequiredService<IFabricaAlmacenamiento>()
                        .Obtener(configuracion)
            );
        }
    }
}

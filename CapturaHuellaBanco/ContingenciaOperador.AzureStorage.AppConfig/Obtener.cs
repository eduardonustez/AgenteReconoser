using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;

namespace ContingenciaOperador.AzureStorage.AppConfig
{
    public static class Obtener
    {
        public const string SECCION = "ContingenciaOperador.AzureStorage";
        private static NameValueCollection ConfigSection
            => (NameValueCollection)ConfigurationManager.GetSection(SECCION);

        public static Configuracion Configuracion
            => new Configuracion()
            {
                CadenaDeConexionArchivos = ConfigSection.Get(nameof(Configuracion.CadenaDeConexionArchivos)),
                CadenaDeConexionTablas = ConfigSection.Get(nameof(Configuracion.CadenaDeConexionTablas)),
                Tabla = ConfigSection.Get(nameof(Configuracion.Tabla)),
                ContenedorArchivos = ConfigSection.Get(nameof(Configuracion.ContenedorArchivos)),
            };

        public static IAlmacenamientoContingencia Almacenamiento
            => new FabricaAlmacenamiento().Obtener(Configuracion);
    }
}

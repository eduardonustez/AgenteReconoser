using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.EstampaCronologica
{
    public class Configuracion
    {
        public const string SECCION = "Utilidades.EstampaCronologica";
        private static NameValueCollection ConfigSection
            => (NameValueCollection)ConfigurationManager.GetSection(SECCION);
        public static Configuracion ConfiguracionDefecto
            => new Configuracion()
            {
                NombreFirma = ConfigSection.Get(nameof(ConfiguracionDefecto.NombreFirma)),
                Url = ConfigSection.Get(nameof(ConfiguracionDefecto.Url)),
                Usuario = ConfigSection.Get(nameof(ConfiguracionDefecto.Usuario)),
                Contrasena = ConfigSection.Get(nameof(ConfiguracionDefecto.Contrasena)),
                Hash = ConfigSection.Get(nameof(ConfiguracionDefecto.Hash)),
            };

        public string NombreFirma { get; set; }
        public string Url { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Hash { get; set; }
    }
}

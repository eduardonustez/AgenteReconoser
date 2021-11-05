using System;

namespace CapturaHuellaBanco
{
    internal static class Global
    {
        private static string _ArchivoFormatoProtDatos = "";
        private static string _DispositivoFirma = "";
        private static string _DispositivoHuella = "";
        private static string _IdentificadorMaq = "";
        private static bool _ModoIntegrado = false;

        private static string _PuertoUIC = string.Empty;

        private static byte[] _TunnelingCert = null;

        public static string ArchivoFormatoProtDatos
        {
            get { return _ArchivoFormatoProtDatos; }
            set { _ArchivoFormatoProtDatos = value; }
        }

        public static string DispositivoFirma
        {
            get { return "MORPHO2"; }
            set { _DispositivoFirma = value; }
        }

        public static string DispositivoHuella
        {
            get { return _DispositivoHuella; }
            set { _DispositivoHuella = value; }
        }

        public static string IdentificadorMaq
        {
            get { return _IdentificadorMaq; }
            set { _IdentificadorMaq = value; }
        }

        public static bool ModoIntegrado
        {
            get { return _ModoIntegrado; }
            set { _ModoIntegrado = value; }
        }
        public static string PuertoUIC
        {
            get { return _PuertoUIC; }
            set { _PuertoUIC = value; }
        }
        public static byte[] TunnelingCert
        {
            get { return _TunnelingCert; }
            set { _TunnelingCert = value; }
        }
    }
}
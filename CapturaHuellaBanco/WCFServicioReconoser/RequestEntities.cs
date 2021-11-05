using System;
using System.Runtime.Serialization;

namespace WCFServicioReconoser
{
    namespace RequestEntities
    {
        [DataContract]
        public class CapturarHuellaRequest
        {
            [DataMember]
            internal string cedula;

            [DataMember]
            internal string dedo;

            [DataMember]
            internal string captura;

            [DataMember]
            internal string ticks;
        }

        [DataContract]
        public class ValidarIdentidadRequest
        {
            [DataMember]
            internal string cedula;

            [DataMember]
            internal string asesor;

            [DataMember]
            internal string oficina;

            [DataMember]
            internal string producto;

            [DataMember]
            internal string ticks;

            [DataMember]
            internal string grafo;

            [DataMember]
            internal Guid? idConvenio;
        }

        [DataContract]
        public class ValidarIdentidadSecuRequest
        {
            [DataMember]
            internal string cedula;

            [DataMember]
            internal string asesor;

            [DataMember]
            internal string oficina;

            [DataMember]
            internal string producto;

            [DataMember]
            internal string token;

            [DataMember]
            internal string ticks;

            [DataMember]
            internal Guid? idConvenio;
        }

        [DataContract]
        public class ObtenerFormatoAutorizacionRequest
        {
            [DataMember]
            internal string cedula;

            [DataMember]
            internal string ticks;

            [DataMember]
            internal Guid? idConvenio;
        }

        [DataContract]
        public class GenerarAutorizacionRequest
        {
            [DataMember]
            internal string cedula;

            [DataMember]
            internal string asesor;

            [DataMember]
            internal string oficina;

            [DataMember]
            internal string producto;

            [DataMember]
            internal string ticks;

            [DataMember]
            internal Guid? idConvenio;
        }

        [DataContract]
        public class CancelarCapturaRequest
        {
            [DataMember]
            internal string ticks;
        }
    }
}
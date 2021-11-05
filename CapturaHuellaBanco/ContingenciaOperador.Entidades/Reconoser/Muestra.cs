using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ContingenciaOperador.Entidades.Reconoser
{
    [Serializable]
    [DataContract]
    [KnownType("ObtenerMuestrasConocidas")]
    public abstract class Muestra
    {
        [DataMember]
        public Guid IdProceso { get; set; }

        [DataMember]
        public string NombreMuestra { get; set; }

        [DataMember]
        public string Formato { get; set; }

        [DataMember]
        public string IdDispositivo { get; set; }

        [DataMember]
        public byte[] ValorMuestra { get; set; }

        [DataMember]
        public Dictionary<string, string> MetaData { get; set; }

        private static List<Type> lista = null;
        private static object _flag = new object();
        public static IEnumerable<Type> ObtenerMuestrasConocidas()
        {
            lock (_flag)
            {
                if (lista == null)
                {
                    lista = new List<Type>();
                    lista.Add(typeof(Huellas));

                    lista.Add(typeof(Huellas[]));

                }
            }

            return lista;
        }
    }
}

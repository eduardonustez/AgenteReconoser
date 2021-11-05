using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ContingenciaOperador.Entidades.Reconoser
{
    [Serializable]
    [DataContract]
    [KnownType("ObtenerMuestrasConocidas")]
    public abstract class Template
    {

        [DataMember]
        public Guid IdProceso
        {
            get;
            set;
        }


        [DataMember]
        public string Nombre
        {
            get;
            set;
        }


        [DataMember]
        public string Formato
        {
            get;
            set;
        }


        [DataMember]
        public byte[] Valor
        {
            get;
            set;
        }
        private static List<Type> lista = null;
        private static object _flag = new object();
        public static IEnumerable<Type> ObtenerMuestrasConocidas()
        {
            lock (_flag)
            {
                if (lista == null)
                {
                    lista = new List<Type>();
                    lista.Add(typeof(TemplateHuella));

                    lista.Add(typeof(TemplateHuella[]));
                }
            }

            return lista;
        }
    }

    public abstract class Template<TMuestra> : Template where TMuestra : Muestra
    {
    }
}

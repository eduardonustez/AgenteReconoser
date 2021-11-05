using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ContingenciaOperador
{
    /// <remarks/>
    [GeneratedCode("svcutil", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://tempuri.org/")]
    [DataContract]
    public class MatcherServices_V0R1
    {
        private KeyValueOfstringstring[] diccionarioolimpiaField;
        private string clientIdField;
        private string nUTField;
        private string operatorIdField;
        private string aplicantIdField;
        private FingerPrintGroup[] fingerGroupField;
        private UserInfoGroup userInfoField;
        private PosicionGroup posicionField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        [DataMember]
        public KeyValueOfstringstring[] Diccionarioolimpia
        {
            get { return this.diccionarioolimpiaField; }
            set { this.diccionarioolimpiaField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        [DataMember]
        public string ClientId
        {
            get { return this.clientIdField; }
            set { this.clientIdField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        [DataMember]
        public string NUT
        {
            get { return this.nUTField; }
            set { this.nUTField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        [DataMember]
        public string OperatorId
        {
            get { return this.operatorIdField; }
            set { this.operatorIdField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [DataMember]
        public string AplicantId
        {
            get { return this.aplicantIdField; }
            set { this.aplicantIdField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        [DataMember]
        public FingerPrintGroup[] FingerGroup
        {
            get { return this.fingerGroupField; }
            set { this.fingerGroupField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        [DataMember]
        public UserInfoGroup UserInfo
        {
            get { return this.userInfoField; }
            set { this.userInfoField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        [DataMember]
        public PosicionGroup Posicion
        {
            get { return this.posicionField; }
            set { this.posicionField = value; }
        }
    }
}

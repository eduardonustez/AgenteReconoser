using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Security.Tokens;
using System.Xml;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Web.Services3.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

namespace WCFBanco
{
    public class MessageInspectorZ : System.ServiceModel.Dispatcher.IClientMessageInspector
    {

public string Username { get; set; }
public string Password { get; set; }
public bool Firmar { get; set; }

public MessageInspectorZ(string username, string password, bool Firmar)
{
  this.Username = username;
  this.Password = password;
  this.Firmar = Firmar;
}

public MessageInspectorZ()
{
 
}

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            System.Diagnostics.Trace.WriteLine("DFZ795");
            var estp = reply.ToString();

            guardararchivoResp(estp);
  
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel)
        {
            System.Diagnostics.Trace.WriteLine("DFZ790");

            //Envio de token de usuario en wse

            bool PasswordHahsed = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("AutSHA2AAA"));
 
            //Solo token   
            this.Username = HttpUtility.HtmlDecode(ConfigurationManager.AppSettings.Get("UsuarioAAA"));
            this.Password = HttpUtility.HtmlDecode(ConfigurationManager.AppSettings.Get("PasswordAAA"));

            if (PasswordHahsed)
            {
                this.Password = sha256(this.Password);
            }

            // Use the WSE 3.0 security token class
            UsernameToken token = new UsernameToken(this.Username, this.Password, PasswordOption.SendPlainText);


            // Serialize the token to XML
            XmlElement securityToken = token.GetXml(new XmlDocument());

            XmlNodeList nodes = securityToken.GetElementsByTagName("wsse:Nonce");
            securityToken.RemoveChild(nodes[0]);

            nodes = securityToken.GetElementsByTagName("wsu:Created");
            securityToken.RemoveChild(nodes[0]);

            //
            MessageHeader securityHeader = MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", securityToken, false);
            request.Headers.Add(securityHeader);


            //Poner Must Understand en 0
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(request.ToString().Replace("mustUnderstand=\"1\"", "mustUnderstand=\"0\"")));
            XmlDictionaryReader xdr = XmlDictionaryReader.CreateTextReader(ms, new XmlDictionaryReaderQuotas());
            Message newMessage = Message.CreateMessage(xdr, int.MaxValue, request.Version);
            newMessage.Properties.CopyProperties(request.Properties);
            request = newMessage;


            guardararchivo(request.ToString());



            // complete
            return Convert.DBNull;
        }
        private void guardararchivo(string text)
        {
            try
            {
                bool GuadarLog = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("GuardarLog"));
                if (GuadarLog == true)
                {
                    System.IO.File.WriteAllText(@"c:\oli\log\ClientReqlog" + DateTime.Now.Ticks + ".txt", text);
                }
            }
            catch (Exception Ex) 
            {
                System.Diagnostics.Trace.WriteLine("WCFBanco EIGA: " + Ex.ToString());            
            }


        }
        private void guardararchivoResp(string text)
        {
            try
            {
                bool GuadarLog = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("GuardarLog"));
                if (GuadarLog == true)
                {
                    System.IO.File.WriteAllText(@"c:\oli\log\ClientResplog" + DateTime.Now.Ticks + ".txt", text);
                }
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Trace.WriteLine("WCFBanco EIGAR: " + Ex.ToString());
            }


        }
        static string sha256(string password)
        {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        // Sign an XML request and return it
        public static string SignRequest(string request, string SubjectName, string Signature, string keyInfoRefId, string UsuarioM, string PasswordM, string SerialCertificado)
        {
            try
            {

                request = request.Replace("<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\">", "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:tem=\"http://tempuri.org/\">");
                request = request.Replace("<s:Header>", "<soapenv:Header>");
                request = request.Replace("<Security>", "<wsse:Security xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">");

                request = request.Replace("</Security>", "</wsse:Security>");
                request = request.Replace("</s:Header>", "</soapenv:Header>");
                request = request.Replace("</s:Envelope>", "</soapenv:Envelope>");

                request = request.Replace("s:mustUnderstand=\"1\"", "soapenv:mustUnderstand=\"0\"");
                request = request.Replace("s:Body", "soapenv:Body");




                if (string.IsNullOrEmpty(request))
                    throw new ArgumentNullException("request");
                if (string.IsNullOrEmpty(SubjectName))
                    throw new ArgumentNullException("SubjectName");

                System.Diagnostics.Trace.WriteLine("[DFZ] Client BeforeSendReply: FirmarRespuesta: 10");

                // Load the certificate from the certificate store.
                var cert = GetCertificateBySubject(SerialCertificado);

                System.Diagnostics.Trace.WriteLine("[DFZ] Client BeforeSendReply: FirmarRespuesta: 20");

                 // Create a new XML document.
                XmlDocument doc = new XmlDocument();

                // Add the declaration as per Entrust sample provided -don't think it's necessary though
                if (!(doc.FirstChild is XmlDeclaration))
                {
                    XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
                    doc.InsertBefore(declaration, doc.FirstChild);
                }

                // Format the document to ignore white spaces.
                doc.PreserveWhitespace = false;

                // Load the passed XML 
                doc.LoadXml(request);

               
                    XmlNode headerNode = null;
                    XmlNodeList nodeList = doc.GetElementsByTagName("Action");
                    if (nodeList.Count > 0)
                    {
                        headerNode = nodeList[0].ParentNode;
                        //headerNode.RemoveChild(nodeList[0]); //Quitar To
                    }
                    if (1 == 2)
                    {

                    XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
                    ns.AddNamespace("s", "http://schemas.xmlsoap.org/soap/envelope/");
                    XmlElement body = doc.DocumentElement.SelectSingleNode(@"//s:Body", ns) as XmlElement;
                    if (body == null)
                        throw new ApplicationException("No body tag found");
                    body.RemoveAllAttributes();  // no need to have namespace
                    body.SetAttribute("Id", "NombreBody123"); // Body Id could be passed as a param



                    CustomSignedXml signedXml = new CustomSignedXml(doc);

                    // Add the key to the SignedXml document. 
                    signedXml.SigningKey = cert.PrivateKey;

                    // Create a new KeyInfo object.
                    KeyInfo keyInfo = new KeyInfo();
                    keyInfo.Id = keyInfoRefId;

                    // Load the certificate into a KeyInfoX509Data object
                    // and add it to the KeyInfo object.
                    //KeyInfoX509Data keyInfoData = new KeyInfoX509Data();
                    //keyInfoData.AddCertificate(cert);                
                    //keyInfo.AddClause(keyInfoData);

                    KeyInfoX509Data keyInfoData = new KeyInfoX509Data();

                    X509IssuerSerial esot = new X509IssuerSerial();
                    esot.IssuerName = cert.IssuerName.Name;
                    esot.SerialNumber = cert.SerialNumber;

                    keyInfoData.AddIssuerSerial(cert.IssuerName.Name, cert.SerialNumber);
                    keyInfo.AddClause(keyInfoData);


                    //SecurityTokenReference keyInfoDataSTF = new SecurityTokenReference();
                    //keyInfoDataSTF.ValueType = "valuetype";
                    //keyInfoDataSTF.Reference = "reference";
                    //keyInfo.AddClause(keyInfoDataSTF);

                    // Add the KeyInfo object to the SignedXml object.
                    signedXml.KeyInfo = keyInfo;

                    // Create a reference to be signed.
                    Reference reference = new Reference();
                    reference.Uri = "#NombreBody123";

                    // Add an enveloped transformation to the reference.
                    XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                    reference.AddTransform(env);

                    // Add the reference to the SignedXml object.
                    signedXml.AddReference(reference);

                    //Reference reference2 = new Reference();
                    //reference2.Uri = "#" + keyInfoRefId;
                    //signedXml.AddReference(reference2);

                    // Add the Signature Id
                    signedXml.Signature.Id = Signature;

                    // Compute the signature.
                    signedXml.ComputeSignature();

                    // Get the XML representation of the signature and save
                    // it to an XmlElement object.
                    XmlElement xmlDigitalSignature = signedXml.GetXml();

                    bool SecurityElement = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("SecurityElement"));

                    if (SecurityElement == false)
                    {
                        // Append the Signature element to the XML document.
                        if (headerNode != null)
                        {
                            //XmlElement soapSecurity = doc.CreateElement("Security");
                            XmlElement soapSecurity = doc.CreateElement("wsse", "Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                            // soapSecurity.Prefix = "wsse";
                            //soapSecurity.SetAttribute("xmlns:wsse", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                            soapSecurity.SetAttribute("xmlns:wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");




                            soapSecurity.AppendChild(xmlDigitalSignature);

                            UsernameToken token = new UsernameToken(UsuarioM, PasswordM, PasswordOption.SendPlainText);
                            XmlElement securityToken = token.GetXml(doc);
                            XmlNodeList nodes = securityToken.GetElementsByTagName("wsse:Nonce");
                            securityToken.RemoveChild(nodes[0]);
                            nodes = securityToken.GetElementsByTagName("wsu:Created");
                            securityToken.RemoveChild(nodes[0]);
                            soapSecurity.AppendChild(securityToken);



                            headerNode.AppendChild(doc.ImportNode(soapSecurity, true));
                        }
                    }
                }

             
              
                if (1 == 1)
                {
                    //bool SecurityElement = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("SecurityElement"));

                    //XmlElement soapSecurity = doc.CreateElement("wsse:Security");

                    XmlElement soapSecurity = doc.CreateElement("wsse", "Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                    // soapSecurity.Prefix = "wsse";
                    //soapSecurity.SetAttribute("xmlns:wsse", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                    soapSecurity.SetAttribute("xmlns:wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");

                    X509SecurityToken signatureToken = new X509SecurityToken(cert);
                    //soapSecurity.AppendChild(signatureToken.GetXml(doc));
                    // soapSecurity.AppendChild(xmlDigitalSignature);

                    

                    MessageSignature messageSignature = new MessageSignature(signatureToken)
                    { /*Aca se puede definir q partes se van a firmar (con O |) . */ /*Para nuestro caso solo vamos a firmar el body*/
                        SignatureOptions = SignatureOptions.IncludeSoapBody,
                        Document = doc
                    };                    

                    messageSignature.ComputeSignature();

                    soapSecurity.AppendChild(signatureToken.GetXml(doc)); //DFZ
                    soapSecurity.AppendChild(messageSignature.GetXml(doc));

                    UsernameToken token = new UsernameToken(UsuarioM, PasswordM, PasswordOption.SendPlainText);
                    XmlElement securityToken = token.GetXml(doc);
                    XmlNodeList nodes = securityToken.GetElementsByTagName("wsse:Nonce");
                    securityToken.RemoveChild(nodes[0]);
                    nodes = securityToken.GetElementsByTagName("wsu:Created");
                    securityToken.RemoveChild(nodes[0]);
                    soapSecurity.AppendChild(securityToken);

                    // Append the Signature element to the XML document.
                    if (headerNode != null)
                    {
                        headerNode.AppendChild(doc.ImportNode(soapSecurity, true));
                    }
                }

          
                return doc.InnerXml;
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Trace.WriteLine("[DFZ] Error Firmando. " + Ex.ToString());
            }

            return "";

        }

        public class CustomSignedXml : System.Security.Cryptography.Xml.SignedXml
        {
            public CustomSignedXml(XmlDocument doc)
                : base(doc)
            {
                return;
            }
            public override XmlElement GetIdElement(XmlDocument doc, string id)
            {
                // see if this is the key info being referenced, otherwise fall back to default behavior
                if (String.Compare(id, this.KeyInfo.Id, StringComparison.OrdinalIgnoreCase) == 0)
                    return this.KeyInfo.GetXml();
                else
                    return base.GetIdElement(doc, id);
            }
        }

        public static X509Certificate2 GetCertificateBySubject(string CertificateSubject)
        {
            System.Diagnostics.Trace.WriteLine("[DFZ555]" + CertificateSubject);

            // Check the args.
            if (string.IsNullOrEmpty(CertificateSubject))
                throw new ArgumentNullException("CertificateSubject");

            // Load the certificate from the certificate store.
            X509Certificate2 cert = null;

            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);

            try
            {
                // Open the store.
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                foreach (var esto in store.Certificates)
                {
                    System.Diagnostics.Trace.WriteLine("[DFZ] Lista Certificado. " + esto.FriendlyName + " [" + esto.SerialNumber + "]" + " [" + esto.SubjectName + "]");

                }

                // Find the certificate with the specified subject.
                cert = store.Certificates.Find(X509FindType.FindBySerialNumber, CertificateSubject, false)[0];

                System.Diagnostics.Trace.WriteLine("[DFZ] Certificado Seleccionado " + cert.FriendlyName + " [" + cert.SerialNumber + "]" + " [" + cert.SubjectName + "]");
                //cert = store.Certificates.Find(X509FindType.fin, CertificateSubject, false)[0];

                // Throw an exception of the certificate was not found.
                if (cert == null)
                {
                    throw new CryptographicException("The certificate could not be found.");
                }
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Trace.WriteLine("[DFZ] Error Obteniendo Certificado. " + Ex.ToString());

            }
            finally
            {
                // Close the store even if an exception was thrown.
                store.Close();
            }

            return cert;
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.Protocols;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace Utilidades
{
    public class AutenticacionLDAP
    {
        #region Propiedades

        private string _DisplayName;
        private string _Dominio;
        private string _filterAttribute;
        private Image _Imagen;
        private string _mail;
        private string _path;
        private string _title;
        private string _Usuario;

        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }

        public string Dominio
        {
            get { return _Dominio; }
            set { _Dominio = value; }
        }

        public Image Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        #endregion Propiedades

        public AutenticacionLDAP()
        {
        }

        public bool IsAuthenticated(string domain, string username, string pwd)
        {
            try
            {
                using (var pc = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["IP"], ConfigurationManager.AppSettings["Identificador"], ContextOptions.Negotiate))
                {
                    return pc.ValidateCredentials(username, pwd);
                }
            }
            catch (Exception)
            {
                throw new Exception("Error de autenticación, valide sus credenciales y que su cuenta no esté bloqueada. ");
            }
        }

        public bool IsAuthenticatedSSL(string domain, string server, string username, string pwd)
        {
            const int ldapErrorInvalidCredentials = 0x31;

            try
            {
                using (var ldapConnection = new LdapConnection(server))
                {
                    var networkCredential = new NetworkCredential(username, pwd, domain);
                    ldapConnection.SessionOptions.SecureSocketLayer = true;
                    ldapConnection.SessionOptions.VerifyServerCertificate = new VerifyServerCertificateCallback((con, cer) => true);
                    ldapConnection.AuthType = AuthType.Negotiate;
                    ldapConnection.Bind(networkCredential);
                }

                // If the bind succeeds, the credentials are valid
                return true;
            }
            catch (LdapException ldapException)
            {
                // Invalid credentials throw an exception with a specific error code
                if (ldapException.ErrorCode.Equals(ldapErrorInvalidCredentials))
                {
                    return false;
                }

                throw;
            }
        }

        public void ObtenerPropiedades(string username)
        {
            DirectorySearcher search = new DirectorySearcher();

            try
            {
                System.Diagnostics.Trace.WriteLine("DFZ400");
                search.Filter = "(SAMAccountName=" + username + ")";

                SearchResult result = search.FindOne();

                if (result != null)
                {
                    System.Diagnostics.Trace.WriteLine("DFZ410");
                    DirectoryEntry user = result.GetDirectoryEntry();

                    if (user != null)
                    {
                        System.Diagnostics.Trace.WriteLine("DFZ420");

                        _DisplayName = user.Properties["displayName"] != null ? user.Properties["displayName"].Value.ToString() : string.Empty;

                        if (user.Properties.Contains("mail"))
                        {
                            _mail = user.Properties["mail"] != null ? user.Properties["mail"].Value.ToString() : string.Empty;
                        }

                        System.Diagnostics.Trace.WriteLine("DFZ430");

                        if (user.Properties.Contains("title"))
                        {
                            _title = user.Properties["title"] != null ? user.Properties["title"].Value.ToString() : string.Empty;
                        }

                        _Imagen = null;
                        if (user.Properties["displayName"] != null)
                        {
                            if (user.Properties.Contains("thumbnailPhoto"))
                            {
                                if (user.Properties["thumbnailPhoto"].Count > 0)
                                {
                                    byte[] b = (byte[])user.Properties["thumbnailPhoto"][0];
                                    _Imagen = UtilImagen.ConvertirImagen(b);
                                }
                            }
                        }
                    }
                }
            }
            catch (DirectoryServicesCOMException Ex)
            {
                System.Diagnostics.Trace.WriteLine("DFZ499E " + Ex.ToString());
                _DisplayName = username;
                _mail = "";
                _title = "";
                _Imagen = null;
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Trace.WriteLine("DFZ500E " + Ex.Message);
            }
        }

        private void guardararchivo(string text)
        {
            try
            {
                string sFile = string.Format(@"{0}\ErrorLDAP.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                StreamWriter writer = new StreamWriter(sFile, true);
                string sLineaDetalle = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ms") + ": " + text;
                writer.WriteLine(sLineaDetalle);
                writer.Close();
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Trace.WriteLine("WCFBanco EIGA: " + Ex.ToString());
            }
        }

        #region Funciones de información LDAP

        private static string GetDomainName()
        {
            try
            {
                return IPGlobalProperties.GetIPGlobalProperties().DomainName;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static string GetLDAPDomainName(string domainName)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(domainName))
                {
                    throw new ArgumentNullException();
                }

                string[] dcItems = domainName.Split(".".ToCharArray());
                sb.Append("LDAP://");
                foreach (string item in dcItems)
                {
                    sb.AppendFormat("DC={0},", item);
                }
                return sb.ToString().Substring(0, sb.ToString().Length - 1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static List<string> GetUserLDAPProperties()
        {
            try
            {
                List<string> properties = new List<string>();
                ActiveDirectorySchema adSchema = ActiveDirectorySchema.GetCurrentSchema();
                ActiveDirectorySchemaClass userSchema = default(ActiveDirectorySchemaClass);
                ActiveDirectorySchemaPropertyCollection propertiesCollection = default(ActiveDirectorySchemaPropertyCollection);

                userSchema = adSchema.FindClass("user");
                propertiesCollection = userSchema.MandatoryProperties;

                foreach (ActiveDirectorySchemaProperty prop in propertiesCollection)
                {
                    properties.Add(prop.Name);
                }

                propertiesCollection = userSchema.OptionalProperties;
                foreach (ActiveDirectorySchemaProperty prop in propertiesCollection)
                {
                    properties.Add(prop.Name);
                }
                return properties;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion Funciones de información LDAP
    }
}
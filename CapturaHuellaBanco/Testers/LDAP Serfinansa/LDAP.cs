using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using System.Drawing;
using System.IO;
using System.Net;

namespace LDAP_Serfinansa
{
    public class LDAP
    {
        #region Propiedades

        private string _path;
        private string _filterAttribute;

        private string _Usuario;
        private string _Dominio;
        private string _DisplayName;
        private string _mail;
        private string _title;
        private Image _Imagen;
        private string _TelephoneNumber;
        private string _PostalAddress;
        private string _Grupos;

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string Dominio
        {
            get { return _Dominio; }
            set { _Dominio = value; }
        }

        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
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

        public Image Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        public string TelephoneNumber
        {
            get { return _TelephoneNumber; }
            set { _TelephoneNumber = value; }
        }

        public string PostalAddress
        {
            get { return _PostalAddress; }
            set { _PostalAddress = value; }
        }

        public string Grupos
        {
            get { return _Grupos; }
            set { _Grupos = value; }
        }

        #endregion Propiedades

        public LDAP()
        {
        }

        public void ObtenerPropiedades(string username)
        {
            DirectorySearcher search = new DirectorySearcher();

            System.Diagnostics.Trace.WriteLine("DFZ10");

            try
            {
                System.Diagnostics.Trace.WriteLine("DFZ20");

                search.Filter = "(SAMAccountName=" + username + ")";

                System.Diagnostics.Trace.WriteLine("DFZ30");

                SearchResult result = search.FindOne();

                System.Diagnostics.Trace.WriteLine("DFZ40");

                if (result != null)
                {
                    System.Diagnostics.Trace.WriteLine("DFZ50");

                    DirectoryEntry user = result.GetDirectoryEntry();

                    if (user != null)
                    {
                        System.Diagnostics.Trace.WriteLine("DFZ60");

                        if (user.Properties.Contains("displayName"))
                        {
                            _DisplayName = user.Properties["displayName"].Value != null ? user.Properties["displayName"].Value.ToString() : string.Empty;
                        }

                        if (user.Properties.Contains("mail"))
                        {
                            _mail = user.Properties["mail"].Value != null ? user.Properties["mail"].Value.ToString() : string.Empty;
                        }

                        if (user.Properties.Contains("title"))
                        {
                            _title = user.Properties["title"].Value != null ? user.Properties["title"].Value.ToString() : string.Empty;
                        }

                        _Imagen = null;
                        if (user.Properties["displayName"] != null)
                        {
                            if (user.Properties.Contains("thumbnailPhoto"))
                            {
                                if (user.Properties["thumbnailPhoto"].Count > 0)
                                {
                                    byte[] b = (byte[])user.Properties["thumbnailPhoto"][0];
                                    _Imagen = ConvertirImagen(b);
                                }
                            }
                        }

                        if (user.Properties["telephoneNumber"] != null)
                        {
                            _TelephoneNumber = user.Properties["telephoneNumber"].Value != null ? user.Properties["telephoneNumber"].Value.ToString() : string.Empty;
                        }

                        if (user.Properties["postalAddress"] != null)
                        {
                            _PostalAddress = user.Properties["postalAddress"].Value != null ? user.Properties["postalAddress"].Value.ToString() : string.Empty;
                        }
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine("DFZ62");
                    }
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine("DFZ52");
                }
            }
            catch (DirectoryServicesCOMException Ex)
            {
                _DisplayName = username;
                _mail = "";
                _title = "";
                _Imagen = null;
                throw new Exception(Ex.ToString());
            }
            catch (Exception)
            {
                throw new Exception("Ex");
            }
        }

        public void ObtenerPropiedadesOD(string username, string a_Password)
        {
        //DirectoryEntry entry = new DirectoryEntry("ldap://172.40.40.3:389/DC=proteccion,DC=local", username, a_Password);
        LDAP://primary.mydomain.local:389/DC=MyDomain,DC=Local"
             // DirectoryEntry entry = new DirectoryEntry("ldap://172.40.40.3:389/rootDSE", username, a_Password);
            DirectoryEntry entry = new DirectoryEntry("ldap://172.29.100.3:636/rootDSE", username, a_Password);

            DirectorySearcher search = new DirectorySearcher(entry);

            System.Diagnostics.Trace.WriteLine("DFZ10");

            try
            {
                System.Diagnostics.Trace.WriteLine("DFZ20");

                search.Filter = "(SAMAccountName=" + username + ")";

                System.Diagnostics.Trace.WriteLine("DFZ30");

                SearchResult result = search.FindOne();

                System.Diagnostics.Trace.WriteLine("DFZ40");

                if (result != null)
                {
                    System.Diagnostics.Trace.WriteLine("DFZ50");

                    DirectoryEntry user = result.GetDirectoryEntry();

                    if (user != null)
                    {
                        System.Diagnostics.Trace.WriteLine("DFZ60");

                        if (user.Properties.Contains("displayName"))
                        {
                            _DisplayName = user.Properties["displayName"].Value != null ? user.Properties["displayName"].Value.ToString() : string.Empty;
                        }

                        if (user.Properties.Contains("mail"))
                        {
                            _mail = user.Properties["mail"].Value != null ? user.Properties["mail"].Value.ToString() : string.Empty;
                        }

                        if (user.Properties.Contains("title"))
                        {
                            _title = user.Properties["title"].Value != null ? user.Properties["title"].Value.ToString() : string.Empty;
                        }

                        _Imagen = null;
                        if (user.Properties["displayName"] != null)
                        {
                            if (user.Properties.Contains("thumbnailPhoto"))
                            {
                                if (user.Properties["thumbnailPhoto"].Count > 0)
                                {
                                    byte[] b = (byte[])user.Properties["thumbnailPhoto"][0];
                                    _Imagen = ConvertirImagen(b);
                                }
                            }
                        }

                        if (user.Properties["telephoneNumber"] != null)
                        {
                            _TelephoneNumber = user.Properties["telephoneNumber"].Value != null ? user.Properties["telephoneNumber"].Value.ToString() : string.Empty;
                        }

                        if (user.Properties["postalAddress"] != null)
                        {
                            _PostalAddress = user.Properties["postalAddress"].Value != null ? user.Properties["postalAddress"].Value.ToString() : string.Empty;
                        }
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine("DFZ62");
                    }
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine("DFZ52");
                }
            }
            catch (DirectoryServicesCOMException Ex)
            {
                System.Diagnostics.Trace.WriteLine("DFZ10E: " + Ex.ToString());

                _DisplayName = username;
                _mail = "";
                _title = "";
                _Imagen = null;
                throw new Exception(Ex.ToString());
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Trace.WriteLine("DFZ20E: " + Ex.ToString());
                throw new Exception("Ex");
            }
        }

        public bool IsAuthenticated(string domain2, string username, string pwd)
        {
            try
            {
                using (var pc = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["IP"], ConfigurationManager.AppSettings["Identificador"], ContextOptions.Negotiate))
                {
                    return pc.ValidateCredentials(username, pwd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool IsAuthenticated1(string domain, string username, string pwd)
        {
            try
            {
                using (var pc = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["IP"], ConfigurationManager.AppSettings["Identificador"], ContextOptions.Negotiate | ContextOptions.SecureSocketLayer))
                {
                    return pc.ValidateCredentials(username, pwd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool IsAuthenticated2(string domain, string username, string pwd)
        {
            try
            {
                using (var pc = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["IP"], ConfigurationManager.AppSettings["Identificador"], ContextOptions.Negotiate))
                {
                    return pc.ValidateCredentials(username, pwd, ContextOptions.Negotiate | ContextOptions.SecureSocketLayer);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool IsAuthenticated4(string domain, string username2, string pwd2)
        {
            const int ldapErrorInvalidCredentials = 0x31;

            //const string server = "LDAPPROTECCION:636";
            string server = ConfigurationManager.AppSettings["IP"];
            //const string domain = "proteccion";

            //const string server = "10.150.14.50:389";
            //const string domain = "olimpiait";

            try
            {
                using (var ldapConnection = new LdapConnection(server))
                {
                    var networkCredential = new NetworkCredential(username2, pwd2, domain);
                    //ldapConnection.SessionOptions.SecureSocketLayer = true;
                    //ldapConnection.SessionOptions.VerifyServerCertificate = new VerifyServerCertificateCallback((con, cer) => true);
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

        public bool IsAuthenticatedOD(string domain2, string username2, string pwd2)
        {
            const int ldapErrorInvalidCredentials = 0x31;

            //const string server = "172.40.40.3:636";
            //const string server = "10.150.14.50:389";
            //string server = ConfigurationManager.AppSettings["IP"];

            const string server = "172.29.100.3:636";

            //const string server = "172.40.40.3:636";

            try
            {
                System.Diagnostics.Trace.WriteLine("DFZ100");

                using (var ldapConnection = new LdapConnection(server))
                {
                    System.Diagnostics.Trace.WriteLine("DFZ110");
                    ldapConnection.SessionOptions.ReferralChasing = ReferralChasingOptions.None;
                    var networkCredential = new NetworkCredential(username2, pwd2, domain2);
                    ldapConnection.SessionOptions.SecureSocketLayer = true;
                    ldapConnection.SessionOptions.VerifyServerCertificate = new VerifyServerCertificateCallback((con, cer) => true);
                    ldapConnection.AuthType = AuthType.Negotiate;

                    System.Diagnostics.Trace.WriteLine("DFZ130");

                    ldapConnection.Bind(networkCredential);

                    System.Diagnostics.Trace.WriteLine("DFZ140");

                    List<string> lstAt = new List<string>();
                    lstAt.Add("SAMAccountName");
                    lstAt.Add("name");
                    lstAt.Add("description");
                    lstAt.Add("displayName");
                    lstAt.Add("memberOf");
                    //string[] attributes  = string{SID, ACCOUNTISLOCKEDOUT, ACCOUNTISDISABLED};

                    SearchRequest search = new SearchRequest(
                   ConfigurationManager.AppSettings["Identificador"],
                   string.Format("(sAMAccountName={0})", username2),
                   System.DirectoryServices.Protocols.SearchScope.Subtree,
                   lstAt.ToArray());

                    SearchResponse response = (SearchResponse)ldapConnection.SendRequest(search);

                    System.Diagnostics.Trace.WriteLine("DFZ150: " + response.Entries.Count);

                    List<string> lstRespName = new List<string>();
                    foreach (SearchResultEntry entry in response.Entries)
                    {
                        System.Diagnostics.Trace.WriteLine("DFZ160");
                        string SAMAccountName = entry.Attributes["SAMAccountName"][0].ToString();
                        string name = entry.Attributes["name"][0].ToString();
                        string description = entry.Attributes["description"][0].ToString();

                        string displayName = entry.Attributes["displayName"][0].ToString();
                        _DisplayName = displayName;

                        string memberOf = "";
                        if (entry.Attributes.Contains("memberOf") && entry.Attributes["memberOf"] != null)
                        {
                            memberOf = entry.Attributes["memberOf"][0].ToString();
                        }
                        _Grupos = memberOf;
                    }

                    int esto = 0;
                    esto += lstAt.Count;
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

        public bool IsAuthenticated5(string domain2, string username2, string pwd2)
        {
            const int ldapErrorInvalidCredentials = 0x31;

            const string server = "172.29.100.3:636";
            //const string server = "10.150.14.50:389";

            try
            {
                using (var ldapConnection = new LdapConnection(server))
                {
                    ldapConnection.SessionOptions.ReferralChasing = ReferralChasingOptions.None;
                    var networkCredential = new NetworkCredential(username2, pwd2, domain2);
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

        public Image ConvertirImagen(byte[] array)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(array))
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    return new Bitmap(System.Drawing.Image.FromStream(ms));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
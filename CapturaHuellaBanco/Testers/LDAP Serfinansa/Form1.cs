using Olimpia.UIC;
using System;
using System.Configuration;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace LDAP_Serfinansa
{
    public partial class Form1 : Form
    {
        private UICPinPad pinPad;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txbDominio.Text = Environment.UserDomainName;
            txbUsuario.Text = Environment.UserName;

            comboBox2.DataSource = SerialPort.GetPortNames();

            var COMPorts = Utilidades.UtilidadesCOM.ObtenerDispositvosCOM();
            comboBox2.SelectedItem = COMPorts.FirstOrDefault((x) => { return x.descripcionBus == "Signature PIN Pad PP795"; }).puerto;

            if (comboBox2.Items.Count > 0)
            {
                try
                {
                    CreatePinPad();
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    if (ex.FileName == "UICWrapper.dll")
                    {
                        if (MessageBox.Show("Las librerías de visual c++ 2015 no están instaladas y son necesarias para ejecutar la aplicación. ¿Desea descargarlas ahora?", "Dependencias faltantes!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("https://download.microsoft.com/download/9/3/F/93FCF1E7-E6A4-478B-96E7-D4B285925B00/vc_redist.x86.exe");
                        }
                    }
                    else
                    {
                        groupBox3.Enabled = false;
                    }
                }
            }
            else
            {
                groupBox3.Enabled = false;
            }
        }

        private void CreatePinPad()
        {
            pinPad = new UICPinPad();
            label15.Text = pinPad.Status.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            LDAP LD = new LDAP();

            try
            {
                bool b = LD.IsAuthenticated(txbDominio.Text, txbUsuario.Text, txbPassword.Text);

                if (b)
                {
                    LD.ObtenerPropiedades(txbUsuario.Text);

                    pbFoto.Image = LD.Imagen;
                    txbNombre.Text = LD.DisplayName;
                    txbMail.Text = LD.Mail;
                    txbCargo.Text = LD.Title;
                    txbTelefono.Text = LD.TelephoneNumber;
                    txbDireccion.Text = LD.PostalAddress;
                    Mensaje("Autenticación exitosa!", false);
                }
                else
                {
                    pbFoto.Image = null;
                    txbNombre.Text = string.Empty;
                    txbMail.Text = string.Empty;
                    txbCargo.Text = string.Empty;
                    txbTelefono.Text = string.Empty;
                    txbDireccion.Text = string.Empty;
                    Mensaje("Autenticación fallida!", true);
                }
            }
            catch (Exception ex)
            {
                Mensaje(ex.ToString(), true);
            }
        }

        private void Mensaje(string msj, bool esError)
        {
            if (esError)
            {
                rtb.SelectionColor = Color.Red;
                rtb.AppendText(msj + "\r\n");
                rtb.ScrollToCaret();
            }
            else
            {
                rtb.SelectionColor = Color.Green;
                rtb.AppendText(msj + "\r\n");
                rtb.ScrollToCaret();
            }
        }

        private void lnkLimpiar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rtb.Clear();
        }

        public void PorIp(string Ip, int Puerto)
        {
            rtbConexion.Text = "";
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(new IPEndPoint(IPAddress.Parse(Ip), Puerto));
                client.Close();
                txtIPConexion.Text = "Bien";
            }
            catch (Exception Ex)
            {
                rtbConexion.Text = Ex.ToString();
            }
        }

        public void PorNombre(string Nombre, int Puerto)
        {
            rtbConexion.Text = "";

            TcpClient client = new TcpClient();
            try
            {
                var esto = Dns.GetHostEntry(Nombre);

                //MessageBox.Show(esto.HostName);

                client.Connect(Dns.GetHostEntry(Nombre).HostName, Puerto);
                //client.Connect("fachadaservicioolimpia", 8061);
                client.Close();
                rtbConexion.Text = "Bien";
            }
            catch (Exception Ex)
            {
                rtbConexion.Text = Ex.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(txtNombrePuerto.Text.Trim(), out n);

            if (isNumeric)
            {
                PorIp(txtIPConexion.Text.Trim(), n);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Pruebas")
            {
                txtIPConexion.Text = ConfigurationManager.AppSettings["PorIpPruebas"];
                txtNombreConexion.Text = ConfigurationManager.AppSettings["PorNombrePruebas"];
                txtNombrePuerto.Text = ConfigurationManager.AppSettings["PuertoPruebas"];
            }
            if (comboBox1.SelectedItem.ToString() == "Producción")
            {
                txtIPConexion.Text = ConfigurationManager.AppSettings["PorIpProd"];
                txtNombreConexion.Text = ConfigurationManager.AppSettings["PorNombreProd"];
                txtNombrePuerto.Text = ConfigurationManager.AppSettings["PuertoProd"];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(txtNombrePuerto.Text.Trim(), out n);

            if (isNumeric)
            {
                PorNombre(txtNombreConexion.Text.Trim(), n);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var t = ((string)comboBox2.SelectedItem).Substring(3);
            pinPad.ComPort = int.Parse(t);
            pinPad.onCaptureFinished = OnSignatureFinished;
            pinPad.onStatusChanged = OnStatusChanged;
            try
            {
                pinPad.Open();
                button3.Enabled = comboBox2.Enabled = false;
                button4.Enabled = button5.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pinPad.Close();
            button3.Enabled = comboBox2.Enabled = true;
            button4.Enabled = button5.Enabled = false;
        }

        private void OnSignatureFinished(Bitmap bmp)
        {
            if (InvokeRequired)
            {
                Invoke(new OnCaptureFinished(OnSignatureFinished), bmp);
            }
            else if (bmp != null)
            {
                pictureBox1.Image = (Image)bmp.Clone();
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pinPad.StartSigCapture();
        }

        private void OnStatusChanged(PinPadStatus newStatus)
        {
            if (InvokeRequired)
            {
                Invoke(new OnStatusChanged(OnStatusChanged), newStatus);
            }
            else
            {
                label15.Text = newStatus.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LDAP LD = new LDAP();

            try
            {
                bool b = LD.IsAuthenticatedOD(txbDominio.Text, txbUsuario.Text, txbPassword.Text);

                if (b)
                {
                    //LD.ObtenerPropiedadesOD(txbUsuario.Text, txbPassword.Text);

                    //pbFoto.Image = LD.Imagen;
                    txbNombre.Text = LD.DisplayName;
                    //txbMail.Text = LD.Mail;
                    //txbCargo.Text = LD.Title;
                    //txbTelefono.Text = LD.TelephoneNumber;
                    //txbDireccion.Text = LD.PostalAddress;
                    txtGrupos.Text = LD.Grupos;
                    Mensaje("Autenticación exitosa!", false);
                }
                else
                {
                    pbFoto.Image = null;
                    txbNombre.Text = string.Empty;
                    txbMail.Text = string.Empty;
                    txbCargo.Text = string.Empty;
                    txbTelefono.Text = string.Empty;
                    txbDireccion.Text = string.Empty;
                    Mensaje("Autenticación fallida!", true);
                }
            }
            catch (Exception ex)
            {
                Mensaje(ex.ToString(), true);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LDAP LD = new LDAP();

            try
            {
                bool b = LD.IsAuthenticated2(txbDominio.Text, txbUsuario.Text, txbPassword.Text);

                if (b)
                {
                    //LD.ObtenerPropiedades(txbUsuario.Text);

                    //pbFoto.Image = LD.Imagen;
                    //txbNombre.Text = LD.DisplayName;
                    //txbMail.Text = LD.Mail;
                    //txbCargo.Text = LD.Title;
                    //txbTelefono.Text = LD.TelephoneNumber;
                    //txbDireccion.Text = LD.PostalAddress;
                    Mensaje("Autenticación exitosa!", false);
                }
                else
                {
                    //pbFoto.Image = null;
                    //txbNombre.Text = string.Empty;
                    //txbMail.Text = string.Empty;
                    //txbCargo.Text = string.Empty;
                    //txbTelefono.Text = string.Empty;
                    //txbDireccion.Text = string.Empty;
                    Mensaje("Autenticación fallida!", true);
                }
            }
            catch (Exception ex)
            {
                Mensaje(ex.ToString(), true);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LDAP LD = new LDAP();

            try
            {
                bool b = LD.IsAuthenticated1(txbDominio.Text, txbUsuario.Text, txbPassword.Text);

                if (b)
                {
                    LD.ObtenerPropiedades(txbUsuario.Text);

                    pbFoto.Image = LD.Imagen;
                    txbNombre.Text = LD.DisplayName;
                    txbMail.Text = LD.Mail;
                    txbCargo.Text = LD.Title;
                    txbTelefono.Text = LD.TelephoneNumber;
                    txbDireccion.Text = LD.PostalAddress;
                    Mensaje("Autenticación exitosa!", false);
                }
                else
                {
                    pbFoto.Image = null;
                    txbNombre.Text = string.Empty;
                    txbMail.Text = string.Empty;
                    txbCargo.Text = string.Empty;
                    txbTelefono.Text = string.Empty;
                    txbDireccion.Text = string.Empty;
                    Mensaje("Autenticación fallida!", true);
                }
            }
            catch (Exception ex)
            {
                Mensaje(ex.ToString(), true);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LDAP LD = new LDAP();

            try
            {
                bool b = LD.IsAuthenticated4(txbDominio.Text, txbUsuario.Text, txbPassword.Text);

                if (b)
                {
                    LD.ObtenerPropiedades(txbUsuario.Text);

                    pbFoto.Image = LD.Imagen;
                    txbNombre.Text = LD.DisplayName;
                    txbMail.Text = LD.Mail;
                    txbCargo.Text = LD.Title;
                    txbTelefono.Text = LD.TelephoneNumber;
                    txbDireccion.Text = LD.PostalAddress;
                    Mensaje("Autenticación exitosa!", false);
                }
                else
                {
                    pbFoto.Image = null;
                    txbNombre.Text = string.Empty;
                    txbMail.Text = string.Empty;
                    txbCargo.Text = string.Empty;
                    txbTelefono.Text = string.Empty;
                    txbDireccion.Text = string.Empty;
                    Mensaje("Autenticación fallida!", true);
                }
            }
            catch (Exception ex)
            {
                Mensaje(ex.ToString(), true);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LDAP LD = new LDAP();

            try
            {
                bool b = LD.IsAuthenticated5(txbDominio.Text, txbUsuario.Text, txbPassword.Text);

                if (b)
                {
                    LD.ObtenerPropiedadesOD(txbUsuario.Text, txbPassword.Text);

                    pbFoto.Image = LD.Imagen;
                    txbNombre.Text = LD.DisplayName;
                    txbMail.Text = LD.Mail;
                    txbCargo.Text = LD.Title;
                    txbTelefono.Text = LD.TelephoneNumber;
                    txbDireccion.Text = LD.PostalAddress;
                    Mensaje("Autenticación exitosa!", false);
                }
                else
                {
                    pbFoto.Image = null;
                    txbNombre.Text = string.Empty;
                    txbMail.Text = string.Empty;
                    txbCargo.Text = string.Empty;
                    txbTelefono.Text = string.Empty;
                    txbDireccion.Text = string.Empty;
                    Mensaje("Autenticación fallida!", true);
                }
            }
            catch (Exception ex)
            {
                Mensaje(ex.ToString(), true);
            }
        }
    }
}
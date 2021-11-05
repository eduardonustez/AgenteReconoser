using System;
using System.Windows.Forms;
using Utilidades;
using Entidades;
namespace CapturaHuellaBanco.ControlesWF
{
    public partial class ctrlLogin : UserControl
    {
        Banco.ServicioBanco banco = new Banco.ServicioBanco();
        AutenticacionLDAP aut;
        frmBase _Base;
        static LogErrores error = null;
        
        ObtenerIP ObtenerIP = new ObtenerIP();
        ObtenerMac ObtenerMac = new ObtenerMac();
        public ctrlLogin()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = txbUsuario.Text;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlLogin : ctrlLogin";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                banco.InsertarLogError(error);

                throw;
            }

        }

        private void ctrlLogin_Load(object sender, EventArgs e)
        {
            try
            {
                //Carga Info control
                txbInfoUsuario.Text = string.Empty;
                aut = new AutenticacionLDAP();
                txbUsuario.Text = aut.Usuario.ToUpper();
                txbDominio.Text = aut.Dominio.ToUpper();
                pbUsuario.Image = aut.Imagen;
                txbInfoUsuario.AppendText(aut.DisplayName + "\r\n");
                txbInfoUsuario.AppendText(aut.Title + "\r\n");
                txbInfoUsuario.AppendText(aut.Mail + "\r\n");
                txbPassword.Focus();

                //Carga Formulario _Base
                _Base = (frmBase)this.ParentForm;

                _Base.Usuario = aut.Usuario.ToUpper();
                _Base.ImagenUsuario = aut.Imagen;
                _Base.DisplayName = aut.DisplayName;
                _Base.Title = aut.Title;
                _Base.Mail = aut.Mail;
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = txbUsuario.Text;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlLogin : ctrlLogin_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                banco.InsertarLogError(error);

                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnLogin_EventoClick(object sender, EventArgs e)
        {
            bool res = false;

            if (txbPassword.Text == string.Empty)
            {
                MessageBox.Show("Ingrese su password antes de iniciar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                res = aut.IsAuthenticated(txbDominio.Text, txbUsuario.Text, txbPassword.Text);
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = txbUsuario.Text;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlLogin : btnLogin_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                banco.InsertarLogError(error);

                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (res)
            {
                try
                {
                    _Base.IdAutenticacion = banco.InsertarIngreso(txbUsuario.Text, DateTime.Now, ObtenerIP.GetIP(), ObtenerMac.GetMac(), 1, true);
                    _Base.CargarControl(new ctrlCapturaHuella());
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = txbUsuario.Text;
                    error.Capa = "CapturaHuellaBanco";
                    error.Metodo = "ctrlLogin : btnLogin_EventoClick";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    banco.InsertarLogError(error);

                    banco.InsertarIngreso(txbUsuario.Text, DateTime.Now, ObtenerIP.GetIP(), ObtenerMac.GetMac(), 1, false);

                    throw;
                }

            }
            else
            {
                MessageBox.Show("Password es inválido, intente de nuevo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
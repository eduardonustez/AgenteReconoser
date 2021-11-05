namespace CapturaHuellaBanco
{
    partial class FormLogin2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin2));
            this.pbLogoColpatria = new System.Windows.Forms.PictureBox();
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDominio = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogin = new Controles.Boton();
            this.btnMinimizar = new Controles.Boton();
            this.btnCerrar = new Controles.Boton();
            this.btnHelp = new Controles.Boton();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoColpatria)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbLogoColpatria
            // 
            this.pbLogoColpatria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogoColpatria.Image = global::CapturaHuellaBanco.Properties.Resources.Colpatria;
            this.pbLogoColpatria.Location = new System.Drawing.Point(61, 129);
            this.pbLogoColpatria.Name = "pbLogoColpatria";
            this.pbLogoColpatria.Size = new System.Drawing.Size(301, 56);
            this.pbLogoColpatria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogoColpatria.TabIndex = 41;
            this.pbLogoColpatria.TabStop = false;
            // 
            // txbUsuario
            // 
            this.txbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsuario.Location = new System.Drawing.Point(61, 233);
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.Size = new System.Drawing.Size(301, 22);
            this.txbUsuario.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 43;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 45;
            this.label2.Text = "Pasword:";
            // 
            // txbPassword
            // 
            this.txbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.Location = new System.Drawing.Point(61, 277);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(301, 22);
            this.txbPassword.TabIndex = 44;
            this.txbPassword.UseSystemPasswordChar = true;
            this.txbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPassword_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 47;
            this.label3.Text = "Dominio:";
            // 
            // txbDominio
            // 
            this.txbDominio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDominio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDominio.Location = new System.Drawing.Point(61, 321);
            this.txbDominio.Name = "txbDominio";
            this.txbDominio.Size = new System.Drawing.Size(301, 22);
            this.txbDominio.TabIndex = 46;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(58, 356);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 48;
            this.lblVersion.Text = "Version";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pbLogoColpatria);
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.txbUsuario);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txbPassword);
            this.panel1.Controls.Add(this.txbDominio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(650, 209);
            this.panel1.MaximumSize = new System.Drawing.Size(400, 400);
            this.panel1.MinimumSize = new System.Drawing.Size(400, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 400);
            this.panel1.TabIndex = 49;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Imagen = global::CapturaHuellaBanco.Properties.Resources.continuar;
            this.btnLogin.ImagenDesabilitado = null;
            this.btnLogin.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.continuarSobre;
            this.btnLogin.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.continuar;
            this.btnLogin.Location = new System.Drawing.Point(366, 270);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(29, 29);
            this.btnLogin.TabIndex = 50;
            this.btnLogin.TamamoTexto = 11.25F;
            this.btnLogin.TextoBoton = "";
            this.btnLogin.Tooltip = null;
            this.btnLogin.EventoClick += new Controles.Boton.ClickEventHandler(this.btnLogin_EventoClick);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Imagen = global::CapturaHuellaBanco.Properties.Resources.minimizex32;
            this.btnMinimizar.ImagenDesabilitado = null;
            this.btnMinimizar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.minimizex32_hover;
            this.btnMinimizar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.minimizex32;
            this.btnMinimizar.Location = new System.Drawing.Point(1018, 12);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(35, 35);
            this.btnMinimizar.TabIndex = 40;
            this.btnMinimizar.TamamoTexto = 8.25F;
            this.btnMinimizar.TextoBoton = "";
            this.btnMinimizar.Tooltip = null;
            this.btnMinimizar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnMinimizar_EventoClick);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Imagen = global::CapturaHuellaBanco.Properties.Resources.closex32;
            this.btnCerrar.ImagenDesabilitado = null;
            this.btnCerrar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.closex32_hover;
            this.btnCerrar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.closex32;
            this.btnCerrar.Location = new System.Drawing.Point(1059, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.TabIndex = 39;
            this.btnCerrar.TamamoTexto = 8.25F;
            this.btnCerrar.TextoBoton = "";
            this.btnCerrar.Tooltip = null;
            this.btnCerrar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnCerrar_EventoClick);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn13icon;
            this.btnHelp.ImagenDesabilitado = null;
            this.btnHelp.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources._18icon;
            this.btnHelp.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn13icon;
            this.btnHelp.Location = new System.Drawing.Point(977, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(35, 35);
            this.btnHelp.TabIndex = 50;
            this.btnHelp.TamamoTexto = 8.25F;
            this.btnHelp.TextoBoton = "";
            this.btnHelp.Tooltip = "Ayuda";
            this.btnHelp.EventoClick += new Controles.Boton.ClickEventHandler(this.btnHelp_EventoClick);
            // 
            // FormLogin2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.login_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1106, 784);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.btnCerrar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin2";
            this.Text = "ReconoSer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormLogin2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoColpatria)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.Boton btnMinimizar;
        private Controles.Boton btnCerrar;
        private System.Windows.Forms.PictureBox pbLogoColpatria;
        private System.Windows.Forms.TextBox txbUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbDominio;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel panel1;
        private Controles.Boton btnLogin;
        private Controles.Boton btnHelp;
    }
}
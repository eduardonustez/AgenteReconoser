namespace CapturaHuellaBanco
{
    partial class frmLogin
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.validarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteTransaccionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeIngresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeActividadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteTiemposDeRespuestaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCerrar = new Controles.Boton();
            this.btnMinimizar = new Controles.Boton();
            this.btnLogin = new Controles.Boton();
            this.pbUsuario = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbDominio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.pbLogoColpatria = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoColpatria)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.validarClienteToolStripMenuItem,
            this.informesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(970, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.Visible = false;
            // 
            // validarClienteToolStripMenuItem
            // 
            this.validarClienteToolStripMenuItem.Name = "validarClienteToolStripMenuItem";
            this.validarClienteToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.reporteTransaccionalToolStripMenuItem,
            this.reporteDeIngresosToolStripMenuItem,
            this.reporteDeActividadesToolStripMenuItem,
            this.reporteTiemposDeRespuestaToolStripMenuItem});
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.informesToolStripMenuItem.Text = "Informes";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            // 
            // reporteTransaccionalToolStripMenuItem
            // 
            this.reporteTransaccionalToolStripMenuItem.Name = "reporteTransaccionalToolStripMenuItem";
            this.reporteTransaccionalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            // 
            // reporteDeIngresosToolStripMenuItem
            // 
            this.reporteDeIngresosToolStripMenuItem.Name = "reporteDeIngresosToolStripMenuItem";
            this.reporteDeIngresosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            // 
            // reporteDeActividadesToolStripMenuItem
            // 
            this.reporteDeActividadesToolStripMenuItem.Name = "reporteDeActividadesToolStripMenuItem";
            this.reporteDeActividadesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            // 
            // reporteTiemposDeRespuestaToolStripMenuItem
            // 
            this.reporteTiemposDeRespuestaToolStripMenuItem.Name = "reporteTiemposDeRespuestaToolStripMenuItem";
            this.reporteTiemposDeRespuestaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Imagen = global::CapturaHuellaBanco.Properties.Resources.closex32;
            this.btnCerrar.ImagenDesabilitado = null;
            this.btnCerrar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.closex32_hover;
            this.btnCerrar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.closex32;
            this.btnCerrar.Location = new System.Drawing.Point(907, 25);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.TabIndex = 37;
            this.btnCerrar.TamamoTexto = 8.25F;
            this.btnCerrar.TextoBoton = "";
            this.btnCerrar.Tooltip = null;
            this.btnCerrar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnCerrar_EventoClick);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Imagen = global::CapturaHuellaBanco.Properties.Resources.minimizex32;
            this.btnMinimizar.ImagenDesabilitado = null;
            this.btnMinimizar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.minimizex32_hover;
            this.btnMinimizar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.minimizex32;
            this.btnMinimizar.Location = new System.Drawing.Point(866, 25);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(35, 35);
            this.btnMinimizar.TabIndex = 38;
            this.btnMinimizar.TamamoTexto = 8.25F;
            this.btnMinimizar.TextoBoton = "";
            this.btnMinimizar.Tooltip = null;
            this.btnMinimizar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnMinimizar_EventoClick);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Imagen = global::CapturaHuellaBanco.Properties.Resources.continuar;
            this.btnLogin.ImagenDesabilitado = null;
            this.btnLogin.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.continuarSobre;
            this.btnLogin.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.continuar;
            this.btnLogin.Location = new System.Drawing.Point(883, 337);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(29, 29);
            this.btnLogin.TabIndex = 18;
            this.btnLogin.TamamoTexto = 11.25F;
            this.btnLogin.TextoBoton = "";
            this.btnLogin.Tooltip = null;
            this.btnLogin.EventoClick += new Controles.Boton.ClickEventHandler(this.btnLogin_EventoClick);
            // 
            // pbUsuario
            // 
            this.pbUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbUsuario.Location = new System.Drawing.Point(441, 294);
            this.pbUsuario.Name = "pbUsuario";
            this.pbUsuario.Size = new System.Drawing.Size(102, 112);
            this.pbUsuario.TabIndex = 16;
            this.pbUsuario.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(589, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(589, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password";
            // 
            // txbDominio
            // 
            this.txbDominio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbDominio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDominio.Location = new System.Drawing.Point(592, 387);
            this.txbDominio.Name = "txbDominio";
            this.txbDominio.Size = new System.Drawing.Size(254, 23);
            this.txbDominio.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(589, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Dominio";
            // 
            // txbPassword
            // 
            this.txbPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.Location = new System.Drawing.Point(592, 339);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(254, 23);
            this.txbPassword.TabIndex = 14;
            this.txbPassword.UseSystemPasswordChar = true;
            this.txbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPassword_KeyPress);
            // 
            // txbUsuario
            // 
            this.txbUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsuario.Location = new System.Drawing.Point(592, 291);
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.Size = new System.Drawing.Size(254, 23);
            this.txbUsuario.TabIndex = 13;
            // 
            // pbLogoColpatria
            // 
            this.pbLogoColpatria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbLogoColpatria.Image = global::CapturaHuellaBanco.Properties.Resources.Colpatria;
            this.pbLogoColpatria.Location = new System.Drawing.Point(592, 184);
            this.pbLogoColpatria.Name = "pbLogoColpatria";
            this.pbLogoColpatria.Size = new System.Drawing.Size(254, 56);
            this.pbLogoColpatria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogoColpatria.TabIndex = 39;
            this.pbLogoColpatria.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(691, 424);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(0, 13);
            this.lblVersion.TabIndex = 40;
            // 
            // frmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.login_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(970, 550);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pbLogoColpatria);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pbUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txbDominio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbUsuario);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmLogin";
            this.Text = "ReconoSer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoColpatria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem validarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private Controles.Boton btnCerrar;
        private Controles.Boton btnMinimizar;
        private System.Windows.Forms.ToolStripMenuItem reporteTransaccionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeIngresosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeActividadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteTiemposDeRespuestaToolStripMenuItem;
        private Controles.Boton btnLogin;
        private System.Windows.Forms.PictureBox pbUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbDominio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.TextBox txbUsuario;
        private System.Windows.Forms.PictureBox pbLogoColpatria;
        private System.Windows.Forms.Label lblVersion;
    }
}
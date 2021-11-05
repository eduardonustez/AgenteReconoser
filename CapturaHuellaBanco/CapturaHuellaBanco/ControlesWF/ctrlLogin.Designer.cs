namespace CapturaHuellaBanco.ControlesWF
{
    partial class ctrlLogin
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbDominio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.TextBox txbUsuario;
        private System.Windows.Forms.PictureBox pbUsuario;
        private System.Windows.Forms.TextBox txbInfoUsuario;
        private Controles.Boton btnLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txbInfoUsuario = new System.Windows.Forms.TextBox();
            this.pbUsuario = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbDominio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.gbLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbLogin.Controls.Add(this.pictureBox2);
            this.gbLogin.Controls.Add(this.pictureBox1);
            this.gbLogin.Controls.Add(this.txbInfoUsuario);
            this.gbLogin.Controls.Add(this.pbUsuario);
            this.gbLogin.Controls.Add(this.label1);
            this.gbLogin.Controls.Add(this.label2);
            this.gbLogin.Controls.Add(this.txbDominio);
            this.gbLogin.Controls.Add(this.label3);
            this.gbLogin.Controls.Add(this.txbPassword);
            this.gbLogin.Controls.Add(this.txbUsuario);
            this.gbLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLogin.ForeColor = System.Drawing.Color.DimGray;
            this.gbLogin.Location = new System.Drawing.Point(53, 47);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(615, 311);
            this.gbLogin.TabIndex = 8;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "LOGIN";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::CapturaHuellaBanco.Properties.Resources.lineaGris;
            this.pictureBox2.Location = new System.Drawing.Point(21, 195);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(568, 1);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::CapturaHuellaBanco.Properties.Resources.lineaGrisVertical;
            this.pictureBox1.Location = new System.Drawing.Point(212, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // txbInfoUsuario
            // 
            this.txbInfoUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbInfoUsuario.BackColor = System.Drawing.Color.White;
            this.txbInfoUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbInfoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbInfoUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.txbInfoUsuario.Location = new System.Drawing.Point(16, 225);
            this.txbInfoUsuario.Multiline = true;
            this.txbInfoUsuario.Name = "txbInfoUsuario";
            this.txbInfoUsuario.ReadOnly = true;
            this.txbInfoUsuario.Size = new System.Drawing.Size(577, 77);
            this.txbInfoUsuario.TabIndex = 17;
            this.txbInfoUsuario.Text = "Nombre Usuario";
            this.txbInfoUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbUsuario
            // 
            this.pbUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbUsuario.Location = new System.Drawing.Point(79, 60);
            this.pbUsuario.Name = "pbUsuario";
            this.pbUsuario.Size = new System.Drawing.Size(102, 112);
            this.pbUsuario.TabIndex = 16;
            this.pbUsuario.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(273, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(273, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password";
            // 
            // txbDominio
            // 
            this.txbDominio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDominio.Location = new System.Drawing.Point(276, 150);
            this.txbDominio.Name = "txbDominio";
            this.txbDominio.ReadOnly = true;
            this.txbDominio.Size = new System.Drawing.Size(254, 23);
            this.txbDominio.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(273, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Dominio";
            // 
            // txbPassword
            // 
            this.txbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.Location = new System.Drawing.Point(276, 102);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(254, 23);
            this.txbPassword.TabIndex = 14;
            this.txbPassword.UseSystemPasswordChar = true;
            // 
            // txbUsuario
            // 
            this.txbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsuario.Location = new System.Drawing.Point(276, 54);
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.ReadOnly = true;
            this.txbUsuario.Size = new System.Drawing.Size(254, 23);
            this.txbUsuario.TabIndex = 13;
            // 
            // ctrlLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbLogin);
            this.Name = "ctrlLogin";
            this.Size = new System.Drawing.Size(744, 401);
            this.Load += new System.EventHandler(this.ctrlLogin_Load);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion




    }
}

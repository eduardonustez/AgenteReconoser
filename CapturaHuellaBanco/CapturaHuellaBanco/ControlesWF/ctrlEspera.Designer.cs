namespace CapturaHuellaBanco.ControlesWF
{
    partial class ctrlEspera
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.pnlBorde = new Controles.PanelPersonalizado();
            this.pnlCentro = new Controles.PanelPersonalizado();
            this.lblIndicadorDedo = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlBorde.SuspendLayout();
            this.pnlCentro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBorde
            // 
            this.pnlBorde.AnchoBorde = 30F;
            this.pnlBorde.BackColor = System.Drawing.Color.DarkGray;
            this.pnlBorde.ColorBorde = System.Drawing.Color.DarkGray;
            this.pnlBorde.Controls.Add(this.pnlCentro);
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(354, 288);
            this.pnlBorde.TabIndex = 37;
            // 
            // pnlCentro
            // 
            this.pnlCentro.AnchoBorde = 0F;
            this.pnlCentro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCentro.BackColor = System.Drawing.Color.White;
            this.pnlCentro.ColorBorde = System.Drawing.Color.Empty;
            this.pnlCentro.Controls.Add(this.lblIndicadorDedo);
            this.pnlCentro.Controls.Add(this.pictureBox2);
            this.pnlCentro.Controls.Add(this.pictureBox1);
            this.pnlCentro.Location = new System.Drawing.Point(6, 8);
            this.pnlCentro.Name = "pnlCentro";
            this.pnlCentro.Size = new System.Drawing.Size(341, 273);
            this.pnlCentro.TabIndex = 36;
            // 
            // lblIndicadorDedo
            // 
            this.lblIndicadorDedo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIndicadorDedo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicadorDedo.ForeColor = System.Drawing.Color.DimGray;
            this.lblIndicadorDedo.Location = new System.Drawing.Point(11, 184);
            this.lblIndicadorDedo.Name = "lblIndicadorDedo";
            this.lblIndicadorDedo.Size = new System.Drawing.Size(320, 47);
            this.lblIndicadorDedo.TabIndex = 40;
            this.lblIndicadorDedo.Text = "UN MOMENTO POR FAVOR, ESTAMOS PROCESANDO SU INFORMACIÓN...\r\n";
            this.lblIndicadorDedo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CapturaHuellaBanco.Properties.Resources.Espera_Clock;
            this.pictureBox2.Location = new System.Drawing.Point(108, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(121, 120);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapturaHuellaBanco.Properties.Resources.barfooter_Image;
            this.pictureBox1.Location = new System.Drawing.Point(-5, 268);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 5);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlEspera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBorde);
            this.Name = "ctrlEspera";
            this.Size = new System.Drawing.Size(354, 288);
            this.pnlBorde.ResumeLayout(false);
            this.pnlCentro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.PanelPersonalizado pnlBorde;
        private Controles.PanelPersonalizado pnlCentro;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblIndicadorDedo;

    }
}

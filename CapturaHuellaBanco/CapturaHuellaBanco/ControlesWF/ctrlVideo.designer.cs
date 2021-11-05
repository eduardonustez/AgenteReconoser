namespace CapturaHuellaBanco.ControlesWF
{
    partial class ctrlVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlVideo));
            this.wmpVideo = new AxWMPLib.AxWindowsMediaPlayer();
            this.pnlBorde = new Controles.PanelPersonalizado();
            this.pnlCentro = new Controles.PanelPersonalizado();
            this.btnCerrar = new Controles.Boton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.wmpVideo)).BeginInit();
            this.pnlBorde.SuspendLayout();
            this.pnlCentro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // wmpVideo
            // 
            this.wmpVideo.Enabled = true;
            this.wmpVideo.Location = new System.Drawing.Point(3, 33);
            this.wmpVideo.Name = "wmpVideo";
            this.wmpVideo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpVideo.OcxState")));
            this.wmpVideo.Size = new System.Drawing.Size(1000, 562);
            this.wmpVideo.TabIndex = 0;
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
            this.pnlBorde.Size = new System.Drawing.Size(1021, 639);
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
            this.pnlCentro.Controls.Add(this.btnCerrar);
            this.pnlCentro.Controls.Add(this.wmpVideo);
            this.pnlCentro.Controls.Add(this.pictureBox1);
            this.pnlCentro.Location = new System.Drawing.Point(6, 8);
            this.pnlCentro.Name = "pnlCentro";
            this.pnlCentro.Size = new System.Drawing.Size(1008, 624);
            this.pnlCentro.TabIndex = 36;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Imagen = global::CapturaHuellaBanco.Properties.Resources.closex32;
            this.btnCerrar.ImagenDesabilitado = null;
            this.btnCerrar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.closex32_hover;
            this.btnCerrar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.closex32;
            this.btnCerrar.Location = new System.Drawing.Point(974, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(29, 25);
            this.btnCerrar.TabIndex = 17;
            this.btnCerrar.TamamoTexto = 8.25F;
            this.btnCerrar.TextoBoton = "";
            this.btnCerrar.Tooltip = null;
            this.btnCerrar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnCerrar_EventoClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapturaHuellaBanco.Properties.Resources.barfooter_Image;
            this.pictureBox1.Location = new System.Drawing.Point(0, 611);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1029, 10);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBorde);
            this.Name = "ctrlVideo";
            this.Size = new System.Drawing.Size(1021, 639);
            ((System.ComponentModel.ISupportInitialize)(this.wmpVideo)).EndInit();
            this.pnlBorde.ResumeLayout(false);
            this.pnlCentro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer wmpVideo;
        private Controles.PanelPersonalizado pnlBorde;
        private Controles.PanelPersonalizado pnlCentro;
        private Controles.Boton btnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}

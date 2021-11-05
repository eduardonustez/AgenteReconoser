namespace CapturaHuellaBanco.ControlesWF
{
    partial class ctrlDashboard
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
            this.pnlNewPanel = new System.Windows.Forms.Panel();
            this.boton2 = new Controles.Boton();
            this.boton1 = new Controles.Boton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNewResumen = new Controles.Boton();
            this.btnNewHuella = new Controles.Boton();
            this.pnlNewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNewPanel
            // 
            this.pnlNewPanel.Controls.Add(this.boton2);
            this.pnlNewPanel.Controls.Add(this.boton1);
            this.pnlNewPanel.Controls.Add(this.pictureBox2);
            this.pnlNewPanel.Controls.Add(this.pictureBox1);
            this.pnlNewPanel.Controls.Add(this.btnNewResumen);
            this.pnlNewPanel.Controls.Add(this.btnNewHuella);
            this.pnlNewPanel.Location = new System.Drawing.Point(301, 69);
            this.pnlNewPanel.Name = "pnlNewPanel";
            this.pnlNewPanel.Size = new System.Drawing.Size(578, 424);
            this.pnlNewPanel.TabIndex = 2;
            this.pnlNewPanel.Visible = false;
            // 
            // boton2
            // 
            this.boton2.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.validacion_on_21;
            this.boton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boton2.CausesValidation = false;
            this.boton2.Enabled = false;
            this.boton2.Imagen = null;
            this.boton2.ImagenDesabilitado = global::CapturaHuellaBanco.Properties.Resources.validacion_21;
            this.boton2.ImagenSobre = null;
            this.boton2.ImagenVisitada = null;
            this.boton2.Location = new System.Drawing.Point(387, 140);
            this.boton2.Name = "boton2";
            this.boton2.Size = new System.Drawing.Size(180, 230);
            this.boton2.TabIndex = 7;
            this.boton2.TamamoTexto = 8.25F;
            this.boton2.TextoBoton = "";
            this.boton2.Tooltip = null;
            // 
            // boton1
            // 
            this.boton1.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.validacion_on_22;
            this.boton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boton1.Enabled = false;
            this.boton1.Imagen = null;
            this.boton1.ImagenDesabilitado = global::CapturaHuellaBanco.Properties.Resources.validacion_22;
            this.boton1.ImagenSobre = null;
            this.boton1.ImagenVisitada = null;
            this.boton1.Location = new System.Drawing.Point(196, 140);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(185, 230);
            this.boton1.TabIndex = 6;
            this.boton1.TamamoTexto = 8.25F;
            this.boton1.TextoBoton = "";
            this.boton1.Tooltip = null;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::CapturaHuellaBanco.Properties.Resources.validacion_23;
            this.pictureBox2.Location = new System.Drawing.Point(5, 371);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(564, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapturaHuellaBanco.Properties.Resources.reportes;
            this.pictureBox1.Location = new System.Drawing.Point(6, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(564, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnNewResumen
            // 
            this.btnNewResumen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNewResumen.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_resumen_on;
            this.btnNewResumen.ImagenDesabilitado = null;
            this.btnNewResumen.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_resumen_on;
            this.btnNewResumen.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_resumen_on;
            this.btnNewResumen.Location = new System.Drawing.Point(6, 58);
            this.btnNewResumen.Name = "btnNewResumen";
            this.btnNewResumen.Size = new System.Drawing.Size(563, 77);
            this.btnNewResumen.TabIndex = 3;
            this.btnNewResumen.TamamoTexto = 8.25F;
            this.btnNewResumen.TextoBoton = "";
            this.btnNewResumen.Tooltip = null;
            this.btnNewResumen.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnReporteTransacciones_EventoClick);
            // 
            // btnNewHuella
            // 
            this.btnNewHuella.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNewHuella.Imagen = global::CapturaHuellaBanco.Properties.Resources.validacion_20;
            this.btnNewHuella.ImagenDesabilitado = global::CapturaHuellaBanco.Properties.Resources.validacion_20;
            this.btnNewHuella.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.validacion_20;
            this.btnNewHuella.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.validacion_20;
            this.btnNewHuella.Location = new System.Drawing.Point(6, 140);
            this.btnNewHuella.Name = "btnNewHuella";
            this.btnNewHuella.Size = new System.Drawing.Size(185, 230);
            this.btnNewHuella.TabIndex = 1;
            this.btnNewHuella.TamamoTexto = 8.25F;
            this.btnNewHuella.TextoBoton = "";
            this.btnNewHuella.Tooltip = "Ingrese a Validación de Identidad";
            this.btnNewHuella.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnValidacion_EventoClick);
            // 
            // ctrlDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNewPanel);
            this.Name = "ctrlDashboard";
            this.Size = new System.Drawing.Size(1208, 630);
            this.Load += new System.EventHandler(this.ctrlDashboard_Load);
            this.pnlNewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.Boton btnNewHuella;
        private System.Windows.Forms.Panel pnlNewPanel;
        private Controles.Boton btnNewResumen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Controles.Boton boton2;
        private Controles.Boton boton1;



    }
}

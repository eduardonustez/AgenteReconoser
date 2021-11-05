namespace CapturaHuellaBanco.ControlesWF
{
    partial class ctrlHuella
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
            this.pbHuella = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new Controles.Boton();
            this.lblIndicadorDedo = new System.Windows.Forms.Label();
            this.btnCerrar = new Controles.Boton();
            this.rtbEstado = new System.Windows.Forms.RichTextBox();
            this.btnHuellaValida = new Controles.Boton();
            this.btnBorrar = new Controles.Boton();
            this.pnlBorde = new Controles.PanelPersonalizado();
            this.pnlCentro = new Controles.PanelPersonalizado();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelPersonalizado1 = new Controles.PanelPersonalizado();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).BeginInit();
            this.pnlBorde.SuspendLayout();
            this.pnlCentro.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelPersonalizado1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbHuella
            // 
            this.pbHuella.BackColor = System.Drawing.SystemColors.Control;
            this.pbHuella.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbHuella.Location = new System.Drawing.Point(0, 0);
            this.pbHuella.Name = "pbHuella";
            this.pbHuella.Size = new System.Drawing.Size(94, 110);
            this.pbHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHuella.TabIndex = 0;
            this.pbHuella.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuardar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_small_nonerow;
            this.btnGuardar.ImagenDesabilitado = null;
            this.btnGuardar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_small_nonerow_over;
            this.btnGuardar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_small_nonerow;
            this.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGuardar.Location = new System.Drawing.Point(104, 247);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(128, 37);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.TamamoTexto = 10F;
            this.btnGuardar.TextoBoton = "CONTINUAR";
            this.btnGuardar.Tooltip = null;
            this.btnGuardar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnGuardar_EventoClick);
            // 
            // lblIndicadorDedo
            // 
            this.lblIndicadorDedo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIndicadorDedo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicadorDedo.ForeColor = System.Drawing.Color.DimGray;
            this.lblIndicadorDedo.Location = new System.Drawing.Point(7, 39);
            this.lblIndicadorDedo.Name = "lblIndicadorDedo";
            this.lblIndicadorDedo.Size = new System.Drawing.Size(320, 18);
            this.lblIndicadorDedo.TabIndex = 16;
            this.lblIndicadorDedo.Text = "DEDO INDICE, MANO DERECHA";
            this.lblIndicadorDedo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Imagen = global::CapturaHuellaBanco.Properties.Resources.closex32;
            this.btnCerrar.ImagenDesabilitado = null;
            this.btnCerrar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.closex32_hover;
            this.btnCerrar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.closex32;
            this.btnCerrar.Location = new System.Drawing.Point(300, 6);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(29, 25);
            this.btnCerrar.TabIndex = 17;
            this.btnCerrar.TamamoTexto = 8.25F;
            this.btnCerrar.TextoBoton = "";
            this.btnCerrar.Tooltip = null;
            this.btnCerrar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnCerrar_EventoClick);
            // 
            // rtbEstado
            // 
            this.rtbEstado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rtbEstado.BackColor = System.Drawing.Color.White;
            this.rtbEstado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbEstado.Location = new System.Drawing.Point(10, 286);
            this.rtbEstado.Name = "rtbEstado";
            this.rtbEstado.ReadOnly = true;
            this.rtbEstado.Size = new System.Drawing.Size(317, 31);
            this.rtbEstado.TabIndex = 33;
            this.rtbEstado.Text = "";
            // 
            // btnHuellaValida
            // 
            this.btnHuellaValida.Enabled = false;
            this.btnHuellaValida.Imagen = global::CapturaHuellaBanco.Properties.Resources.end_vacio;
            this.btnHuellaValida.ImagenDesabilitado = null;
            this.btnHuellaValida.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.end_vacio;
            this.btnHuellaValida.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.end_vacio;
            this.btnHuellaValida.Location = new System.Drawing.Point(134, 12);
            this.btnHuellaValida.Name = "btnHuellaValida";
            this.btnHuellaValida.Size = new System.Drawing.Size(29, 25);
            this.btnHuellaValida.TabIndex = 34;
            this.btnHuellaValida.TamamoTexto = 8.25F;
            this.btnHuellaValida.TextoBoton = "";
            this.btnHuellaValida.Tooltip = null;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_0001_limpiar_azul;
            this.btnBorrar.ImagenDesabilitado = global::CapturaHuellaBanco.Properties.Resources.btn_0001_limpiar_azul;
            this.btnBorrar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_0000_limpiar_rojo;
            this.btnBorrar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_0001_limpiar_azul;
            this.btnBorrar.Location = new System.Drawing.Point(35, 144);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(94, 25);
            this.btnBorrar.TabIndex = 35;
            this.btnBorrar.TamamoTexto = 8.25F;
            this.btnBorrar.TextoBoton = "";
            this.btnBorrar.Tooltip = "Reanudar Captura";
            this.btnBorrar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnBorrar_EventoClick);
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
            this.pnlBorde.Size = new System.Drawing.Size(351, 341);
            this.pnlBorde.TabIndex = 36;
            // 
            // pnlCentro
            // 
            this.pnlCentro.AnchoBorde = 0F;
            this.pnlCentro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCentro.BackColor = System.Drawing.Color.White;
            this.pnlCentro.ColorBorde = System.Drawing.Color.Empty;
            this.pnlCentro.Controls.Add(this.groupBox1);
            this.pnlCentro.Controls.Add(this.rtbEstado);
            this.pnlCentro.Controls.Add(this.btnCerrar);
            this.pnlCentro.Controls.Add(this.lblIndicadorDedo);
            this.pnlCentro.Controls.Add(this.btnGuardar);
            this.pnlCentro.Controls.Add(this.pictureBox1);
            this.pnlCentro.Location = new System.Drawing.Point(6, 8);
            this.pnlCentro.Name = "pnlCentro";
            this.pnlCentro.Size = new System.Drawing.Size(338, 326);
            this.pnlCentro.TabIndex = 36;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.panelPersonalizado1);
            this.groupBox1.Controls.Add(this.btnHuellaValida);
            this.groupBox1.Controls.Add(this.btnBorrar);
            this.groupBox1.Location = new System.Drawing.Point(86, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 179);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // panelPersonalizado1
            // 
            this.panelPersonalizado1.AnchoBorde = 3F;
            this.panelPersonalizado1.ColorBorde = System.Drawing.Color.Gainsboro;
            this.panelPersonalizado1.Controls.Add(this.pbHuella);
            this.panelPersonalizado1.Location = new System.Drawing.Point(35, 28);
            this.panelPersonalizado1.Name = "panelPersonalizado1";
            this.panelPersonalizado1.Size = new System.Drawing.Size(94, 110);
            this.panelPersonalizado1.TabIndex = 36;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapturaHuellaBanco.Properties.Resources.barfooter_Image;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 321);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 5);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlHuella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBorde);
            this.Name = "ctrlHuella";
            this.Size = new System.Drawing.Size(351, 341);
            this.Load += new System.EventHandler(this.ctrlHuella_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).EndInit();
            this.pnlBorde.ResumeLayout(false);
            this.pnlCentro.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panelPersonalizado1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbHuella;
        private Controles.Boton btnGuardar;
        private System.Windows.Forms.Label lblIndicadorDedo;
        private Controles.Boton btnCerrar;
        private System.Windows.Forms.RichTextBox rtbEstado;
        private Controles.Boton btnHuellaValida;
        private Controles.Boton btnBorrar;
        private Controles.PanelPersonalizado pnlBorde;
        private Controles.PanelPersonalizado pnlCentro;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controles.PanelPersonalizado panelPersonalizado1;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}

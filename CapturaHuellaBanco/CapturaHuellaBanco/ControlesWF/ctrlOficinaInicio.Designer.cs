namespace CapturaHuellaBanco.ControlesWF
{
    partial class ctrlOficinaInicio
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
            this.lblServicio = new System.Windows.Forms.Label();
            this.cbOficina = new System.Windows.Forms.ComboBox();
            this.lblOficina = new System.Windows.Forms.Label();
            this.pnlCentro = new Controles.PanelPersonalizado();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new Controles.Boton();
            this.pnlCentro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBorde
            // 
            this.pnlBorde.AnchoBorde = 30F;
            this.pnlBorde.BackColor = System.Drawing.Color.DarkGray;
            this.pnlBorde.ColorBorde = System.Drawing.Color.DarkGray;
            this.pnlBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(351, 176);
            this.pnlBorde.TabIndex = 37;
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.BackColor = System.Drawing.Color.White;
            this.lblServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.ForeColor = System.Drawing.Color.DimGray;
            this.lblServicio.Location = new System.Drawing.Point(44, 80);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(275, 18);
            this.lblServicio.TabIndex = 48;
            this.lblServicio.Text = "Por favor seleccione la oficina de origen.";
            // 
            // cbOficina
            // 
            this.cbOficina.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbOficina.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbOficina.BackColor = System.Drawing.Color.White;
            this.cbOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOficina.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOficina.ForeColor = System.Drawing.Color.Black;
            this.cbOficina.FormattingEnabled = true;
            this.cbOficina.Items.AddRange(new object[] {
            "Mantenimiento",
            "Originación"});
            this.cbOficina.Location = new System.Drawing.Point(47, 53);
            this.cbOficina.Name = "cbOficina";
            this.cbOficina.Size = new System.Drawing.Size(265, 24);
            this.cbOficina.TabIndex = 47;
            // 
            // lblOficina
            // 
            this.lblOficina.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOficina.BackColor = System.Drawing.Color.White;
            this.lblOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOficina.ForeColor = System.Drawing.Color.DimGray;
            this.lblOficina.Location = new System.Drawing.Point(15, 18);
            this.lblOficina.Name = "lblOficina";
            this.lblOficina.Size = new System.Drawing.Size(320, 18);
            this.lblOficina.TabIndex = 46;
            this.lblOficina.Text = "OFICINA DE ORIGEN";
            this.lblOficina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCentro
            // 
            this.pnlCentro.AnchoBorde = 0F;
            this.pnlCentro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCentro.BackColor = System.Drawing.Color.White;
            this.pnlCentro.ColorBorde = System.Drawing.Color.Empty;
            this.pnlCentro.Controls.Add(this.pictureBox1);
            this.pnlCentro.Controls.Add(this.btnGuardar);
            this.pnlCentro.Location = new System.Drawing.Point(4, 3);
            this.pnlCentro.Name = "pnlCentro";
            this.pnlCentro.Size = new System.Drawing.Size(342, 170);
            this.pnlCentro.TabIndex = 45;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapturaHuellaBanco.Properties.Resources.barfooter_Image;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 165);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 5);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
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
            this.btnGuardar.Location = new System.Drawing.Point(100, 110);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(128, 37);
            this.btnGuardar.TabIndex = 41;
            this.btnGuardar.TamamoTexto = 10F;
            this.btnGuardar.TextoBoton = "CONTINUAR";
            this.btnGuardar.Tooltip = null;
            this.btnGuardar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnGuardar_EventoClick);
            // 
            // ctrlOficinaInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblServicio);
            this.Controls.Add(this.cbOficina);
            this.Controls.Add(this.lblOficina);
            this.Controls.Add(this.pnlCentro);
            this.Controls.Add(this.pnlBorde);
            this.Name = "ctrlOficinaInicio";
            this.Size = new System.Drawing.Size(351, 176);
            this.Load += new System.EventHandler(this.ctrlOficina_Load);
            this.pnlCentro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.PanelPersonalizado pnlBorde;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.ComboBox cbOficina;
        private System.Windows.Forms.Label lblOficina;
        private Controles.PanelPersonalizado pnlCentro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controles.Boton btnGuardar;

    }
}

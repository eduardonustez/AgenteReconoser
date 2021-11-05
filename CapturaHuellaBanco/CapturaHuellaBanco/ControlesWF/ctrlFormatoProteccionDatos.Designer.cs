namespace CapturaHuellaBanco.ControlesWF
{
    partial class ctrlFormatoProteccionDatos
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
            this.gbFormatoProteccionDatos = new System.Windows.Forms.GroupBox();
            this.lblPto = new System.Windows.Forms.Label();
            this.cboPtoSig = new System.Windows.Forms.ComboBox();
            this.lblSiguiente = new System.Windows.Forms.Label();
            this.btnAcepta = new Controles.Boton();
            this.btNContinuar = new Controles.Boton();
            this.pbSeparador = new System.Windows.Forms.PictureBox();
            this.btnFinalizar = new Controles.Boton();
            this.rtbres = new System.Windows.Forms.RichTextBox();
            this.pbHuella = new System.Windows.Forms.PictureBox();
            this.lblFirma = new System.Windows.Forms.Label();
            this.btnNoAcepta = new Controles.Boton();
            this.rdNoAcepta = new System.Windows.Forms.RadioButton();
            this.rbAcepta = new System.Windows.Forms.RadioButton();
            this.pnlVisor = new System.Windows.Forms.Panel();
            this.panelPersonalizado1 = new Controles.PanelPersonalizado();
            this.panelPersonalizado2 = new Controles.PanelPersonalizado();
            this.gbFormatoProteccionDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeparador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).BeginInit();
            this.panelPersonalizado1.SuspendLayout();
            this.panelPersonalizado2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFormatoProteccionDatos
            // 
            this.gbFormatoProteccionDatos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbFormatoProteccionDatos.BackColor = System.Drawing.Color.White;
            this.gbFormatoProteccionDatos.Controls.Add(this.lblPto);
            this.gbFormatoProteccionDatos.Controls.Add(this.cboPtoSig);
            this.gbFormatoProteccionDatos.Controls.Add(this.lblSiguiente);
            this.gbFormatoProteccionDatos.Controls.Add(this.btnAcepta);
            this.gbFormatoProteccionDatos.Controls.Add(this.btNContinuar);
            this.gbFormatoProteccionDatos.Controls.Add(this.pbSeparador);
            this.gbFormatoProteccionDatos.Controls.Add(this.btnFinalizar);
            this.gbFormatoProteccionDatos.Controls.Add(this.rtbres);
            this.gbFormatoProteccionDatos.Controls.Add(this.pbHuella);
            this.gbFormatoProteccionDatos.Controls.Add(this.lblFirma);
            this.gbFormatoProteccionDatos.Controls.Add(this.btnNoAcepta);
            this.gbFormatoProteccionDatos.Controls.Add(this.rdNoAcepta);
            this.gbFormatoProteccionDatos.Controls.Add(this.rbAcepta);
            this.gbFormatoProteccionDatos.Controls.Add(this.pnlVisor);
            this.gbFormatoProteccionDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbFormatoProteccionDatos.ForeColor = System.Drawing.Color.DimGray;
            this.gbFormatoProteccionDatos.Location = new System.Drawing.Point(3, 23);
            this.gbFormatoProteccionDatos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbFormatoProteccionDatos.Name = "gbFormatoProteccionDatos";
            this.gbFormatoProteccionDatos.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbFormatoProteccionDatos.Size = new System.Drawing.Size(1617, 668);
            this.gbFormatoProteccionDatos.TabIndex = 0;
            this.gbFormatoProteccionDatos.TabStop = false;
            this.gbFormatoProteccionDatos.Text = "FORMATO PROTECCIÓN DE DATOS";
            // 
            // lblPto
            // 
            this.lblPto.AutoSize = true;
            this.lblPto.Location = new System.Drawing.Point(1183, 540);
            this.lblPto.Name = "lblPto";
            this.lblPto.Size = new System.Drawing.Size(90, 29);
            this.lblPto.TabIndex = 24;
            this.lblPto.Text = "Puerto";
            this.lblPto.Visible = false;
            // 
            // cboPtoSig
            // 
            this.cboPtoSig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPtoSig.FormattingEnabled = true;
            this.cboPtoSig.Location = new System.Drawing.Point(1278, 536);
            this.cboPtoSig.Name = "cboPtoSig";
            this.cboPtoSig.Size = new System.Drawing.Size(108, 37);
            this.cboPtoSig.TabIndex = 23;
            this.cboPtoSig.Visible = false;
            this.cboPtoSig.DropDown += new System.EventHandler(this.cboPtoSig_DropDown);
            this.cboPtoSig.SelectedIndexChanged += new System.EventHandler(this.cboPtoSig_SelectedIndexChanged);
            // 
            // lblSiguiente
            // 
            this.lblSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSiguiente.AutoSize = true;
            this.lblSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiguiente.ForeColor = System.Drawing.Color.DimGray;
            this.lblSiguiente.Location = new System.Drawing.Point(1365, 594);
            this.lblSiguiente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSiguiente.Name = "lblSiguiente";
            this.lblSiguiente.Size = new System.Drawing.Size(165, 29);
            this.lblSiguiente.TabIndex = 21;
            this.lblSiguiente.Text = "CONTINUAR";
            this.lblSiguiente.Visible = false;
            // 
            // btnAcepta
            // 
            this.btnAcepta.Imagen = global::CapturaHuellaBanco.Properties.Resources.end_vacio;
            this.btnAcepta.ImagenDesabilitado = null;
            this.btnAcepta.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.end;
            this.btnAcepta.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.end_vacio;
            this.btnAcepta.Location = new System.Drawing.Point(18, 548);
            this.btnAcepta.Margin = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.btnAcepta.Name = "btnAcepta";
            this.btnAcepta.Size = new System.Drawing.Size(45, 46);
            this.btnAcepta.TabIndex = 5;
            this.btnAcepta.TamamoTexto = 11.25F;
            this.btnAcepta.TextoBoton = "";
            this.btnAcepta.Tooltip = null;
            this.btnAcepta.EventoClick += new Controles.Boton.ClickEventHandler(this.btnAcepta_EventoClick);
            // 
            // btNContinuar
            // 
            this.btNContinuar.Imagen = global::CapturaHuellaBanco.Properties.Resources.continuar;
            this.btNContinuar.ImagenDesabilitado = global::CapturaHuellaBanco.Properties.Resources.continuar;
            this.btNContinuar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.continuarSobre;
            this.btNContinuar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.continuar;
            this.btNContinuar.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btNContinuar.Location = new System.Drawing.Point(1538, 572);
            this.btNContinuar.Margin = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.btNContinuar.Name = "btNContinuar";
            this.btNContinuar.Size = new System.Drawing.Size(68, 71);
            this.btNContinuar.TabIndex = 22;
            this.btNContinuar.TamamoTexto = 11.25F;
            this.btNContinuar.TextoBoton = "";
            this.btNContinuar.Tooltip = null;
            this.btNContinuar.Visible = false;
            this.btNContinuar.EventoClick += new Controles.Boton.ClickEventHandler(this.btNContinuar_EventoClick);
            // 
            // pbSeparador
            // 
            this.pbSeparador.Image = global::CapturaHuellaBanco.Properties.Resources.barfooter_Image;
            this.pbSeparador.Location = new System.Drawing.Point(24, 526);
            this.pbSeparador.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbSeparador.Name = "pbSeparador";
            this.pbSeparador.Size = new System.Drawing.Size(1581, 5);
            this.pbSeparador.TabIndex = 0;
            this.pbSeparador.TabStop = false;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizar.Imagen = global::CapturaHuellaBanco.Properties.Resources.resultado_7;
            this.btnFinalizar.ImagenDesabilitado = null;
            this.btnFinalizar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.resultado_7;
            this.btnFinalizar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.resultado_7;
            this.btnFinalizar.Location = new System.Drawing.Point(874, 572);
            this.btnFinalizar.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(183, 43);
            this.btnFinalizar.TabIndex = 10;
            this.btnFinalizar.TamamoTexto = 11.25F;
            this.btnFinalizar.TextoBoton = "";
            this.btnFinalizar.Tooltip = null;
            this.btnFinalizar.Visible = false;
            this.btnFinalizar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnFinalizar_EventoClick);
            // 
            // rtbres
            // 
            this.rtbres.BackColor = System.Drawing.Color.White;
            this.rtbres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rtbres.Location = new System.Drawing.Point(873, 626);
            this.rtbres.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbres.Name = "rtbres";
            this.rtbres.ReadOnly = true;
            this.rtbres.Size = new System.Drawing.Size(358, 29);
            this.rtbres.TabIndex = 9;
            this.rtbres.Text = "";
            this.rtbres.Visible = false;
            // 
            // pbHuella
            // 
            this.pbHuella.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbHuella.Location = new System.Drawing.Point(650, 538);
            this.pbHuella.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbHuella.Name = "pbHuella";
            this.pbHuella.Size = new System.Drawing.Size(100, 116);
            this.pbHuella.TabIndex = 7;
            this.pbHuella.TabStop = false;
            this.pbHuella.Visible = false;
            // 
            // lblFirma
            // 
            this.lblFirma.AutoSize = true;
            this.lblFirma.Location = new System.Drawing.Point(870, 538);
            this.lblFirma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirma.Name = "lblFirma";
            this.lblFirma.Size = new System.Drawing.Size(279, 29);
            this.lblFirma.TabIndex = 8;
            this.lblFirma.Text = "FIRMA ELECTRÓNICA";
            this.lblFirma.Visible = false;
            // 
            // btnNoAcepta
            // 
            this.btnNoAcepta.Imagen = global::CapturaHuellaBanco.Properties.Resources.end_vacio;
            this.btnNoAcepta.ImagenDesabilitado = null;
            this.btnNoAcepta.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.end;
            this.btnNoAcepta.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.end_vacio;
            this.btnNoAcepta.Location = new System.Drawing.Point(18, 605);
            this.btnNoAcepta.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            this.btnNoAcepta.Name = "btnNoAcepta";
            this.btnNoAcepta.Size = new System.Drawing.Size(45, 46);
            this.btnNoAcepta.TabIndex = 6;
            this.btnNoAcepta.TamamoTexto = 11.25F;
            this.btnNoAcepta.TextoBoton = "";
            this.btnNoAcepta.Tooltip = null;
            this.btnNoAcepta.EventoClick += new Controles.Boton.ClickEventHandler(this.btnNoAcepta_EventoClick);
            // 
            // rdNoAcepta
            // 
            this.rdNoAcepta.AutoSize = true;
            this.rdNoAcepta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNoAcepta.Location = new System.Drawing.Point(24, 609);
            this.rdNoAcepta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdNoAcepta.Name = "rdNoAcepta";
            this.rdNoAcepta.Size = new System.Drawing.Size(488, 33);
            this.rdNoAcepta.TabIndex = 2;
            this.rdNoAcepta.TabStop = true;
            this.rdNoAcepta.Text = "  No acepta los términos y condiciones";
            this.rdNoAcepta.UseVisualStyleBackColor = true;
            this.rdNoAcepta.CheckedChanged += new System.EventHandler(this.rdNoAcepta_CheckedChanged);
            // 
            // rbAcepta
            // 
            this.rbAcepta.AutoSize = true;
            this.rbAcepta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAcepta.Location = new System.Drawing.Point(24, 554);
            this.rbAcepta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbAcepta.Name = "rbAcepta";
            this.rbAcepta.Size = new System.Drawing.Size(449, 33);
            this.rbAcepta.TabIndex = 1;
            this.rbAcepta.TabStop = true;
            this.rbAcepta.Text = "  Acepta los términos y condiciones";
            this.rbAcepta.UseVisualStyleBackColor = true;
            this.rbAcepta.CheckedChanged += new System.EventHandler(this.rbAcepta_CheckedChanged);
            // 
            // pnlVisor
            // 
            this.pnlVisor.AutoScroll = true;
            this.pnlVisor.Location = new System.Drawing.Point(24, 40);
            this.pnlVisor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlVisor.Name = "pnlVisor";
            this.pnlVisor.Size = new System.Drawing.Size(1581, 477);
            this.pnlVisor.TabIndex = 0;
            // 
            // panelPersonalizado1
            // 
            this.panelPersonalizado1.AnchoBorde = 0F;
            this.panelPersonalizado1.BackColor = System.Drawing.Color.DimGray;
            this.panelPersonalizado1.ColorBorde = System.Drawing.Color.Empty;
            this.panelPersonalizado1.Controls.Add(this.panelPersonalizado2);
            this.panelPersonalizado1.Location = new System.Drawing.Point(0, 0);
            this.panelPersonalizado1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelPersonalizado1.Name = "panelPersonalizado1";
            this.panelPersonalizado1.Size = new System.Drawing.Size(1684, 740);
            this.panelPersonalizado1.TabIndex = 1;
            // 
            // panelPersonalizado2
            // 
            this.panelPersonalizado2.AnchoBorde = 0F;
            this.panelPersonalizado2.BackColor = System.Drawing.Color.White;
            this.panelPersonalizado2.ColorBorde = System.Drawing.Color.Empty;
            this.panelPersonalizado2.Controls.Add(this.gbFormatoProteccionDatos);
            this.panelPersonalizado2.Location = new System.Drawing.Point(21, 22);
            this.panelPersonalizado2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelPersonalizado2.Name = "panelPersonalizado2";
            this.panelPersonalizado2.Size = new System.Drawing.Size(1640, 697);
            this.panelPersonalizado2.TabIndex = 0;
            // 
            // ctrlFormatoProteccionDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelPersonalizado1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlFormatoProteccionDatos";
            this.Size = new System.Drawing.Size(1683, 745);
            this.Load += new System.EventHandler(this.ctrlFormatoProteccionDatos_Load);
            this.gbFormatoProteccionDatos.ResumeLayout(false);
            this.gbFormatoProteccionDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeparador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).EndInit();
            this.panelPersonalizado1.ResumeLayout(false);
            this.panelPersonalizado2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFormatoProteccionDatos;
        private System.Windows.Forms.Panel pnlVisor;
        private System.Windows.Forms.RadioButton rdNoAcepta;
        private System.Windows.Forms.RadioButton rbAcepta;
        private Controles.Boton btnNoAcepta;
        private Controles.Boton btnAcepta;
        private Controles.PanelPersonalizado panelPersonalizado1;
        private Controles.PanelPersonalizado panelPersonalizado2;
        private System.Windows.Forms.PictureBox pbHuella;
        private System.Windows.Forms.Label lblFirma;
        private System.Windows.Forms.RichTextBox rtbres;
        private Controles.Boton btnFinalizar;
        private System.Windows.Forms.PictureBox pbSeparador;
        private System.Windows.Forms.Label lblSiguiente;
        private Controles.Boton btNContinuar;
        private System.Windows.Forms.ComboBox cboPtoSig;
        private System.Windows.Forms.Label lblPto;
    }
}

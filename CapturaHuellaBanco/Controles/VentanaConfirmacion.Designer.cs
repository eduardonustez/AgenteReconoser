namespace Controles
{
    partial class VentanaConfirmacion
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
            this.lblMensaje = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTituloVentana = new System.Windows.Forms.Label();
            this.botonAceptar = new Controles.Boton();
            this.botonCancelar = new Controles.Boton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMensaje.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.DimGray;
            this.lblMensaje.Location = new System.Drawing.Point(38, 49);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(318, 117);
            this.lblMensaje.TabIndex = 0;
            this.lblMensaje.Text = "label1";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Controles.Properties.Resources.FondoHeimdal;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(394, 267);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblTituloVentana
            // 
            this.lblTituloVentana.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloVentana.ForeColor = System.Drawing.Color.White;
            this.lblTituloVentana.Image = global::Controles.Properties.Resources.bar_tl;
            this.lblTituloVentana.Location = new System.Drawing.Point(85, 80);
            this.lblTituloVentana.Name = "lblTituloVentana";
            this.lblTituloVentana.Size = new System.Drawing.Size(328, 33);
            this.lblTituloVentana.TabIndex = 2;
            this.lblTituloVentana.Text = "label1";
            this.lblTituloVentana.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloVentana.Visible = false;
            // 
            // botonAceptar
            // 
            this.botonAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonAceptar.Imagen = global::Controles.Properties.Resources.btn_small_nonerow;
            this.botonAceptar.ImagenDesabilitado = null;
            this.botonAceptar.ImagenSobre = global::Controles.Properties.Resources.btn_small_nonerow_hover;
            this.botonAceptar.ImagenVisitada = global::Controles.Properties.Resources.btn_small_nonerow;
            this.botonAceptar.Location = new System.Drawing.Point(106, 185);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(67, 40);
            this.botonAceptar.TabIndex = 1;
            this.botonAceptar.TamamoTexto = 8.25F;
            this.botonAceptar.TextoBoton = "SI";
            this.botonAceptar.Tooltip = null;
            this.botonAceptar.EventoClick += new Controles.Boton.ClickEventHandler(this.botonAceptar_EventoClick);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonCancelar.Imagen = global::Controles.Properties.Resources.btn_small_nonerow_hover;
            this.botonCancelar.ImagenDesabilitado = null;
            this.botonCancelar.ImagenSobre = global::Controles.Properties.Resources.btn_small_nonerow_hover;
            this.botonCancelar.ImagenVisitada = global::Controles.Properties.Resources.btn_small_nonerow_hover;
            this.botonCancelar.Location = new System.Drawing.Point(224, 185);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(67, 40);
            this.botonCancelar.TabIndex = 3;
            this.botonCancelar.TamamoTexto = 8.25F;
            this.botonCancelar.TextoBoton = "NO";
            this.botonCancelar.Tooltip = null;
            this.botonCancelar.EventoClick += new Controles.Boton.ClickEventHandler(this.botonCancelar_EventoClick);
            // 
            // VentanaConfirmacion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.lblTituloVentana);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.pictureBox1);
            this.Name = "VentanaConfirmacion";
            this.Size = new System.Drawing.Size(394, 270);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMensaje;
        private Boton botonAceptar;
        private System.Windows.Forms.Label lblTituloVentana;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Boton botonCancelar;
    }
}

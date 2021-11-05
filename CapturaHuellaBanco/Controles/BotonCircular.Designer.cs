namespace Controles
{
    partial class BotonCircular
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
            this.lblDescripcionAccion = new System.Windows.Forms.Label();
            this.pbCirculo = new System.Windows.Forms.PictureBox();
            this.pbImagenCentral = new System.Windows.Forms.PictureBox();
            this.pbImgCentral = new System.Windows.Forms.PictureBox();
            this.pnlImagenes = new System.Windows.Forms.Panel();
            this.pnlTexto = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbCirculo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenCentral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgCentral)).BeginInit();
            this.pnlImagenes.SuspendLayout();
            this.pnlTexto.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescripcionAccion
            // 
            this.lblDescripcionAccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescripcionAccion.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionAccion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDescripcionAccion.Location = new System.Drawing.Point(0, 0);
            this.lblDescripcionAccion.Name = "lblDescripcionAccion";
            this.lblDescripcionAccion.Size = new System.Drawing.Size(130, 71);
            this.lblDescripcionAccion.TabIndex = 2;
            this.lblDescripcionAccion.Text = "TEXTO DESCRIPTIVO";
            this.lblDescripcionAccion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbCirculo
            // 
            this.pbCirculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCirculo.Image = global::Controles.Properties.Resources.circle;
            this.pbCirculo.Location = new System.Drawing.Point(0, 0);
            this.pbCirculo.Name = "pbCirculo";
            this.pbCirculo.Size = new System.Drawing.Size(130, 128);
            this.pbCirculo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCirculo.TabIndex = 1;
            this.pbCirculo.TabStop = false;
            this.pbCirculo.Click += new System.EventHandler(this.pbCirculo_Click);
            this.pbCirculo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCirculo_MouseDown);
            this.pbCirculo.MouseLeave += new System.EventHandler(this.pbCirculo_MouseLeave);
            this.pbCirculo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCirculo_MouseMove);
            this.pbCirculo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbCirculo_MouseUp);
            // 
            // pbImagenCentral
            // 
            this.pbImagenCentral.Location = new System.Drawing.Point(-18, -46);
            this.pbImagenCentral.Name = "pbImagenCentral";
            this.pbImagenCentral.Size = new System.Drawing.Size(100, 50);
            this.pbImagenCentral.TabIndex = 0;
            this.pbImagenCentral.TabStop = false;
            // 
            // pbImgCentral
            // 
            this.pbImgCentral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImgCentral.Location = new System.Drawing.Point(45, 44);
            this.pbImgCentral.Name = "pbImgCentral";
            this.pbImgCentral.Size = new System.Drawing.Size(40, 40);
            this.pbImgCentral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImgCentral.TabIndex = 3;
            this.pbImgCentral.TabStop = false;
            this.pbImgCentral.Click += new System.EventHandler(this.pbCirculo_Click);
            this.pbImgCentral.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCirculo_MouseDown);
            this.pbImgCentral.MouseLeave += new System.EventHandler(this.pbCirculo_MouseLeave);
            this.pbImgCentral.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCirculo_MouseMove);
            this.pbImgCentral.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbCirculo_MouseUp);
            // 
            // pnlImagenes
            // 
            this.pnlImagenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlImagenes.Controls.Add(this.pbImgCentral);
            this.pnlImagenes.Controls.Add(this.pbCirculo);
            this.pnlImagenes.Location = new System.Drawing.Point(0, 0);
            this.pnlImagenes.Name = "pnlImagenes";
            this.pnlImagenes.Size = new System.Drawing.Size(130, 128);
            this.pnlImagenes.TabIndex = 4;
            // 
            // pnlTexto
            // 
            this.pnlTexto.Controls.Add(this.lblDescripcionAccion);
            this.pnlTexto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTexto.Location = new System.Drawing.Point(0, 139);
            this.pnlTexto.Name = "pnlTexto";
            this.pnlTexto.Size = new System.Drawing.Size(130, 71);
            this.pnlTexto.TabIndex = 5;
            // 
            // BotonCircular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTexto);
            this.Controls.Add(this.pnlImagenes);
            this.Name = "BotonCircular";
            this.Size = new System.Drawing.Size(130, 210);
            this.Load += new System.EventHandler(this.BotonCircular_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCirculo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenCentral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgCentral)).EndInit();
            this.pnlImagenes.ResumeLayout(false);
            this.pnlTexto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCirculo;
        private System.Windows.Forms.PictureBox pbImagenCentral;
        private System.Windows.Forms.PictureBox pbImgCentral;
        private System.Windows.Forms.Label lblDescripcionAccion;
        private System.Windows.Forms.Panel pnlImagenes;
        private System.Windows.Forms.Panel pnlTexto;
    }
}

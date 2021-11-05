namespace Controles
{
    partial class Boton
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
            this.imagen = new System.Windows.Forms.PictureBox();
            this.lblTextoBoton = new Controles.LabelPersonalizado();
            ((System.ComponentModel.ISupportInitialize)(this.imagen)).BeginInit();
            this.SuspendLayout();
            // 
            // imagen
            // 
            this.imagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagen.Location = new System.Drawing.Point(0, 0);
            this.imagen.Name = "imagen";
            this.imagen.Size = new System.Drawing.Size(100, 100);
            this.imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagen.TabIndex = 0;
            this.imagen.TabStop = false;
            this.imagen.Click += new System.EventHandler(this.imagen_Click);
            this.imagen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imagen_MouseDown);
            this.imagen.MouseLeave += new System.EventHandler(this.imagen_MouseLeave);
            this.imagen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imagen_MouseMove);
            this.imagen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imagen_MouseUp);
            // 
            // lblTextoBoton
            // 
            this.lblTextoBoton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextoBoton.AutoSize = true;
            this.lblTextoBoton.Color = System.Drawing.Color.White;
            this.lblTextoBoton.ForeColor = System.Drawing.Color.White;
            this.lblTextoBoton.Location = new System.Drawing.Point(12, 5);
            this.lblTextoBoton.Name = "lblTextoBoton";
            this.lblTextoBoton.Size = new System.Drawing.Size(0, 13);
            this.lblTextoBoton.TabIndex = 1;
            this.lblTextoBoton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTextoBoton.Click += new System.EventHandler(this.imagen_Click);
            this.lblTextoBoton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imagen_MouseDown);
            this.lblTextoBoton.MouseLeave += new System.EventHandler(this.imagen_MouseLeave);
            this.lblTextoBoton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imagen_MouseMove);
            this.lblTextoBoton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imagen_MouseUp);
            // 
            // Boton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTextoBoton);
            this.Controls.Add(this.imagen);
            this.Name = "Boton";
            this.Size = new System.Drawing.Size(100, 100);
            this.Load += new System.EventHandler(this.Boton_Load);
            this.EnabledChanged += new System.EventHandler(this.Boton_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.imagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imagen;
        private LabelPersonalizado lblTextoBoton;
    }
}

namespace Controles
{
    partial class MensajeInformativo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPersonalizado1 = new Controles.PanelPersonalizado();
            this.panelPersonalizado2 = new Controles.PanelPersonalizado();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.botonAceptar = new Controles.Boton();
            this.panelPersonalizado1.SuspendLayout();
            this.panelPersonalizado2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPersonalizado1
            // 
            this.panelPersonalizado1.AnchoBorde = 30F;
            this.panelPersonalizado1.BackColor = System.Drawing.Color.DarkGray;
            this.panelPersonalizado1.ColorBorde = System.Drawing.Color.DarkGray;
            this.panelPersonalizado1.Controls.Add(this.panelPersonalizado2);
            this.panelPersonalizado1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPersonalizado1.Location = new System.Drawing.Point(0, 0);
            this.panelPersonalizado1.Name = "panelPersonalizado1";
            this.panelPersonalizado1.Size = new System.Drawing.Size(334, 262);
            this.panelPersonalizado1.TabIndex = 6;
            // 
            // panelPersonalizado2
            // 
            this.panelPersonalizado2.AnchoBorde = 0F;
            this.panelPersonalizado2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPersonalizado2.BackColor = System.Drawing.Color.White;
            this.panelPersonalizado2.ColorBorde = System.Drawing.Color.Empty;
            this.panelPersonalizado2.Controls.Add(this.lblMensaje);
            this.panelPersonalizado2.Location = new System.Drawing.Point(23, 12);
            this.panelPersonalizado2.Name = "panelPersonalizado2";
            this.panelPersonalizado2.Size = new System.Drawing.Size(299, 242);
            this.panelPersonalizado2.TabIndex = 6;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.DimGray;
            this.lblMensaje.Location = new System.Drawing.Point(26, 13);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(258, 153);
            this.lblMensaje.TabIndex = 0;
            this.lblMensaje.Text = "label1";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botonAceptar
            // 
            this.botonAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonAceptar.Imagen = global::Controles.Properties.Resources.btn_small_nonerow;
            this.botonAceptar.ImagenDesabilitado = null;
            this.botonAceptar.ImagenSobre = global::Controles.Properties.Resources.btn_small_nonerow_hover;
            this.botonAceptar.ImagenVisitada = global::Controles.Properties.Resources.btn_small_nonerow;
            this.botonAceptar.Location = new System.Drawing.Point(83, 196);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(166, 40);
            this.botonAceptar.TabIndex = 2;
            this.botonAceptar.TamamoTexto = 8.25F;
            this.botonAceptar.TextoBoton = "ACEPTAR";
            this.botonAceptar.Tooltip = null;
            this.botonAceptar.EventoClick += new Controles.Boton.ClickEventHandler(this.botonAceptar_EventoClick);
            // 
            // MensajeInformativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 262);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.panelPersonalizado1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MensajeInformativo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MensajeInformativo";
            this.TopMost = true;
            this.panelPersonalizado1.ResumeLayout(false);
            this.panelPersonalizado2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Boton botonAceptar;
        private PanelPersonalizado panelPersonalizado1;
        private PanelPersonalizado panelPersonalizado2;
        private System.Windows.Forms.Label lblMensaje;
    }
}
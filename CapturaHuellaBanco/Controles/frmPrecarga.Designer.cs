namespace Controles
{
    partial class frmPrecarga
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTextoMostrar = new System.Windows.Forms.Label();
            this.panelPersonalizado1.SuspendLayout();
            this.panelPersonalizado2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPersonalizado1
            // 
            this.panelPersonalizado1.AnchoBorde = 0F;
            this.panelPersonalizado1.BackColor = System.Drawing.Color.DarkGray;
            this.panelPersonalizado1.ColorBorde = System.Drawing.Color.Empty;
            this.panelPersonalizado1.Controls.Add(this.panelPersonalizado2);
            this.panelPersonalizado1.Location = new System.Drawing.Point(0, 0);
            this.panelPersonalizado1.Name = "panelPersonalizado1";
            this.panelPersonalizado1.Size = new System.Drawing.Size(330, 190);
            this.panelPersonalizado1.TabIndex = 2;
            // 
            // panelPersonalizado2
            // 
            this.panelPersonalizado2.AnchoBorde = 0F;
            this.panelPersonalizado2.BackColor = System.Drawing.Color.White;
            this.panelPersonalizado2.ColorBorde = System.Drawing.Color.Empty;
            this.panelPersonalizado2.Controls.Add(this.pictureBox1);
            this.panelPersonalizado2.Controls.Add(this.lblTextoMostrar);
            this.panelPersonalizado2.Location = new System.Drawing.Point(5, 5);
            this.panelPersonalizado2.Name = "panelPersonalizado2";
            this.panelPersonalizado2.Size = new System.Drawing.Size(320, 180);
            this.panelPersonalizado2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Controles.Properties.Resources.preloader;
            this.pictureBox1.Location = new System.Drawing.Point(26, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTextoMostrar
            // 
            this.lblTextoMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoMostrar.ForeColor = System.Drawing.Color.DimGray;
            this.lblTextoMostrar.Location = new System.Drawing.Point(137, 8);
            this.lblTextoMostrar.Margin = new System.Windows.Forms.Padding(0);
            this.lblTextoMostrar.Name = "lblTextoMostrar";
            this.lblTextoMostrar.Size = new System.Drawing.Size(180, 165);
            this.lblTextoMostrar.TabIndex = 1;
            this.lblTextoMostrar.Text = "UN MOMENTO POR FAVOR";
            this.lblTextoMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPrecarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(330, 190);
            this.Controls.Add(this.panelPersonalizado1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPrecarga";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrecarga";
            this.TopMost = true;
            this.panelPersonalizado1.ResumeLayout(false);
            this.panelPersonalizado2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTextoMostrar;
        private PanelPersonalizado panelPersonalizado1;
        private PanelPersonalizado panelPersonalizado2;
    }
}
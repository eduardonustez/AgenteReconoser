namespace ReconoserEstado
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.lbEstadoServicio = new System.Windows.Forms.Label();
            this.lbEstadoHost = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbVersionEstado = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkRegisterDll = new System.Windows.Forms.LinkLabel();
            this.btIniciarServicio = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.button2.Location = new System.Drawing.Point(28, 354);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 41);
            this.button2.TabIndex = 2;
            this.button2.Text = "Consultar Estado";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(28, 177);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(513, 163);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Hola";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(208)))), ((int)(((byte)(115)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Consulta estado ReconoSer";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.09393F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.90607F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbVersion, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbEstadoServicio, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbEstadoHost, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(28, 73);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(513, 98);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 64);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(3);
            this.label6.Size = new System.Drawing.Size(151, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Versión del Servicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Estado Servicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 32);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(3);
            this.label4.Size = new System.Drawing.Size(99, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Estado Host";
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.BackColor = System.Drawing.Color.Gainsboro;
            this.lbVersion.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbVersion.Location = new System.Drawing.Point(167, 64);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Padding = new System.Windows.Forms.Padding(3);
            this.lbVersion.Size = new System.Drawing.Size(169, 25);
            this.lbVersion.TabIndex = 5;
            this.lbVersion.Text = "Versión No disponible";
            // 
            // lbEstadoServicio
            // 
            this.lbEstadoServicio.AutoSize = true;
            this.lbEstadoServicio.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstadoServicio.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbEstadoServicio.Location = new System.Drawing.Point(167, 0);
            this.lbEstadoServicio.Name = "lbEstadoServicio";
            this.lbEstadoServicio.Padding = new System.Windows.Forms.Padding(3);
            this.lbEstadoServicio.Size = new System.Drawing.Size(190, 22);
            this.lbEstadoServicio.TabIndex = 1;
            this.lbEstadoServicio.Text = "Estado Servicio No disponible";
            // 
            // lbEstadoHost
            // 
            this.lbEstadoHost.AutoSize = true;
            this.lbEstadoHost.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstadoHost.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbEstadoHost.Location = new System.Drawing.Point(167, 32);
            this.lbEstadoHost.Name = "lbEstadoHost";
            this.lbEstadoHost.Padding = new System.Windows.Forms.Padding(3);
            this.lbEstadoHost.Size = new System.Drawing.Size(172, 22);
            this.lbEstadoHost.TabIndex = 3;
            this.lbEstadoHost.Text = "Estado Host No disponible";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.button1.Location = new System.Drawing.Point(445, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 41);
            this.button1.TabIndex = 7;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.button3.Location = new System.Drawing.Point(190, 354);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(189, 41);
            this.button3.TabIndex = 8;
            this.button3.Text = "Buscar Actualizaciones";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(208)))), ((int)(((byte)(115)))));
            this.panel1.Controls.Add(this.lbVersionEstado);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-18, -7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 64);
            this.panel1.TabIndex = 10;
            // 
            // lbVersionEstado
            // 
            this.lbVersionEstado.AutoSize = true;
            this.lbVersionEstado.Location = new System.Drawing.Point(531, 35);
            this.lbVersionEstado.Name = "lbVersionEstado";
            this.lbVersionEstado.Size = new System.Drawing.Size(38, 14);
            this.lbVersionEstado.TabIndex = 6;
            this.lbVersionEstado.Text = "label3";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panel2.Location = new System.Drawing.Point(-38, 409);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(628, 10);
            this.panel2.TabIndex = 11;
            // 
            // lnkRegisterDll
            // 
            this.lnkRegisterDll.AutoSize = true;
            this.lnkRegisterDll.Location = new System.Drawing.Point(32, 326);
            this.lnkRegisterDll.Name = "lnkRegisterDll";
            this.lnkRegisterDll.Size = new System.Drawing.Size(117, 14);
            this.lnkRegisterDll.TabIndex = 12;
            this.lnkRegisterDll.TabStop = true;
            this.lnkRegisterDll.Text = "Registrar wgssSTU.dll";
            this.lnkRegisterDll.Visible = false;
            this.lnkRegisterDll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegisterDll_LinkClicked);
            // 
            // btIniciarServicio
            // 
            this.btIniciarServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btIniciarServicio.BackColor = System.Drawing.Color.Transparent;
            this.btIniciarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btIniciarServicio.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIniciarServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btIniciarServicio.Location = new System.Drawing.Point(440, 70);
            this.btIniciarServicio.Name = "btIniciarServicio";
            this.btIniciarServicio.Size = new System.Drawing.Size(96, 27);
            this.btIniciarServicio.TabIndex = 14;
            this.btIniciarServicio.Text = "Iniciar Servicio";
            this.btIniciarServicio.UseVisualStyleBackColor = false;
            this.btIniciarServicio.Click += new System.EventHandler(this.btIniciarServicio_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(563, 414);
            this.Controls.Add(this.btIniciarServicio);
            this.Controls.Add(this.lnkRegisterDll);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(431, 296);
            this.Name = "Form1";
            this.Text = "Reconoser Servicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbEstadoServicio;
        private System.Windows.Forms.Label lbEstadoHost;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbVersionEstado;
        private System.Windows.Forms.LinkLabel lnkRegisterDll;
        private System.Windows.Forms.Button btIniciarServicio;
    }
}
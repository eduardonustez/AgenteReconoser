namespace CapturaHuellaBanco.ControlesParametrizacion
{
    partial class ctrlImportarExcel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelPersonalizado1 = new Controles.PanelPersonalizado();
            this.panelPersonalizado2 = new Controles.PanelPersonalizado();
            this.btnPlantilla = new Controles.Boton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new Controles.Boton();
            this.btnGuardar = new Controles.Boton();
            this.btnBuscar = new Controles.Boton();
            this.pnlRegistros = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.Habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelPersonalizado1.SuspendLayout();
            this.panelPersonalizado2.SuspendLayout();
            this.pnlRegistros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPersonalizado1
            // 
            this.panelPersonalizado1.AnchoBorde = 0F;
            this.panelPersonalizado1.BackColor = System.Drawing.Color.Gray;
            this.panelPersonalizado1.ColorBorde = System.Drawing.Color.Empty;
            this.panelPersonalizado1.Controls.Add(this.panelPersonalizado2);
            this.panelPersonalizado1.ForeColor = System.Drawing.Color.DarkGray;
            this.panelPersonalizado1.Location = new System.Drawing.Point(0, 0);
            this.panelPersonalizado1.Name = "panelPersonalizado1";
            this.panelPersonalizado1.Size = new System.Drawing.Size(1030, 472);
            this.panelPersonalizado1.TabIndex = 0;
            // 
            // panelPersonalizado2
            // 
            this.panelPersonalizado2.AnchoBorde = 0F;
            this.panelPersonalizado2.BackColor = System.Drawing.Color.White;
            this.panelPersonalizado2.ColorBorde = System.Drawing.Color.Empty;
            this.panelPersonalizado2.Controls.Add(this.btnPlantilla);
            this.panelPersonalizado2.Controls.Add(this.label1);
            this.panelPersonalizado2.Controls.Add(this.btnCerrar);
            this.panelPersonalizado2.Controls.Add(this.btnGuardar);
            this.panelPersonalizado2.Controls.Add(this.btnBuscar);
            this.panelPersonalizado2.Controls.Add(this.pnlRegistros);
            this.panelPersonalizado2.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado2.Location = new System.Drawing.Point(14, 15);
            this.panelPersonalizado2.Name = "panelPersonalizado2";
            this.panelPersonalizado2.Size = new System.Drawing.Size(1000, 442);
            this.panelPersonalizado2.TabIndex = 0;
            // 
            // btnPlantilla
            // 
            this.btnPlantilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnPlantilla.Imagen = global::CapturaHuellaBanco.Properties.Resources.file;
            this.btnPlantilla.ImagenDesabilitado = global::CapturaHuellaBanco.Properties.Resources.file;
            this.btnPlantilla.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.file;
            this.btnPlantilla.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.file;
            this.btnPlantilla.Location = new System.Drawing.Point(458, 145);
            this.btnPlantilla.Name = "btnPlantilla";
            this.btnPlantilla.Size = new System.Drawing.Size(100, 100);
            this.btnPlantilla.TabIndex = 29;
            this.btnPlantilla.TamamoTexto = 8.25F;
            this.btnPlantilla.TextoBoton = "";
            this.btnPlantilla.Tooltip = "Descargue Plantilla";
            this.btnPlantilla.EventoClick += new Controles.Boton.ClickEventHandler(this.btnPlantilla_EventoClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(429, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Descargue Plantilla";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Imagen = global::CapturaHuellaBanco.Properties.Resources.closex32;
            this.btnCerrar.ImagenDesabilitado = null;
            this.btnCerrar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.closex32_hover;
            this.btnCerrar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.closex32;
            this.btnCerrar.Location = new System.Drawing.Point(956, 14);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(29, 25);
            this.btnCerrar.TabIndex = 18;
            this.btnCerrar.TamamoTexto = 8.25F;
            this.btnCerrar.TextoBoton = "";
            this.btnCerrar.Tooltip = null;
            this.btnCerrar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnCerrar_EventoClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnGuardar.ImagenDesabilitado = null;
            this.btnGuardar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnGuardar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnGuardar.Location = new System.Drawing.Point(718, 401);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(22, 11, 22, 11);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 26);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.TamamoTexto = 8.25F;
            this.btnGuardar.TextoBoton = "Guardar";
            this.btnGuardar.Tooltip = null;
            this.btnGuardar.Visible = false;
            this.btnGuardar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnGuardar_EventoClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_0005_buscar_azul;
            this.btnBuscar.ImagenDesabilitado = null;
            this.btnBuscar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_0004_buscar_rojo;
            this.btnBuscar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_0005_buscar_azul;
            this.btnBuscar.Location = new System.Drawing.Point(845, 401);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(22, 11, 22, 11);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(117, 26);
            this.btnBuscar.TabIndex = 19;
            this.btnBuscar.TamamoTexto = 8.25F;
            this.btnBuscar.TextoBoton = "";
            this.btnBuscar.Tooltip = null;
            this.btnBuscar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnBuscar_EventoClick);
            // 
            // pnlRegistros
            // 
            this.pnlRegistros.Controls.Add(this.label3);
            this.pnlRegistros.Controls.Add(this.dgvLista);
            this.pnlRegistros.Location = new System.Drawing.Point(20, 18);
            this.pnlRegistros.Name = "pnlRegistros";
            this.pnlRegistros.Size = new System.Drawing.Size(965, 379);
            this.pnlRegistros.TabIndex = 28;
            this.pnlRegistros.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(20, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Errores";
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.AllowUserToOrderColumns = true;
            this.dgvLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLista.BackgroundColor = System.Drawing.Color.White;
            this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Habilitado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLista.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLista.EnableHeadersVisualStyles = false;
            this.dgvLista.GridColor = System.Drawing.Color.White;
            this.dgvLista.Location = new System.Drawing.Point(23, 41);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLista.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dgvLista.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(918, 335);
            this.dgvLista.TabIndex = 26;
            // 
            // Habilitado
            // 
            this.Habilitado.DataPropertyName = "Habilitado";
            this.Habilitado.HeaderText = "Habilitado";
            this.Habilitado.Name = "Habilitado";
            this.Habilitado.ReadOnly = true;
            this.Habilitado.Visible = false;
            // 
            // ctrlImportarExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelPersonalizado1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ctrlImportarExcel";
            this.Size = new System.Drawing.Size(1030, 472);
            this.panelPersonalizado1.ResumeLayout(false);
            this.panelPersonalizado2.ResumeLayout(false);
            this.panelPersonalizado2.PerformLayout();
            this.pnlRegistros.ResumeLayout(false);
            this.pnlRegistros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.PanelPersonalizado panelPersonalizado1;
        private Controles.PanelPersonalizado panelPersonalizado2;
        private Controles.Boton btnCerrar;
        private System.Windows.Forms.Label label3;
        private Controles.Boton btnBuscar;
        private System.Windows.Forms.DataGridView dgvLista;
        private Controles.Boton btnGuardar;
        private System.Windows.Forms.Panel pnlRegistros;
        private Controles.Boton btnPlantilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Habilitado;
    }
}

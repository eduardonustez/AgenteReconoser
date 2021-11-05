namespace CapturaHuellaBanco.ControlesWF
{
    partial class ctrlReporteTiemposRespuesta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCantidadRegistros = new System.Windows.Forms.Label();
            this.ContenedorPaneles = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ContenedorIZQ = new System.Windows.Forms.Panel();
            this.dgvReporteTiemposRespuesta = new System.Windows.Forms.DataGridView();
            this.ContenedorDER = new System.Windows.Forms.Panel();
            this.LblFecha = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LblDuracion = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LblMetodo = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.LblCapa = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.BtnExportar = new Controles.Boton();
            this.BtnBuscar = new Controles.Boton();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.Metodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContenedorPaneles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ContenedorIZQ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteTiemposRespuesta)).BeginInit();
            this.ContenedorDER.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCantidadRegistros
            // 
            this.lblCantidadRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantidadRegistros.AutoSize = true;
            this.lblCantidadRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidadRegistros.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadRegistros.ForeColor = System.Drawing.Color.White;
            this.lblCantidadRegistros.Location = new System.Drawing.Point(564, 29);
            this.lblCantidadRegistros.Name = "lblCantidadRegistros";
            this.lblCantidadRegistros.Size = new System.Drawing.Size(101, 13);
            this.lblCantidadRegistros.TabIndex = 55;
            this.lblCantidadRegistros.Text = "N° registros:10000";
            // 
            // ContenedorPaneles
            // 
            this.ContenedorPaneles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContenedorPaneles.Controls.Add(this.splitContainer1);
            this.ContenedorPaneles.Location = new System.Drawing.Point(3, 67);
            this.ContenedorPaneles.Name = "ContenedorPaneles";
            this.ContenedorPaneles.Size = new System.Drawing.Size(1104, 452);
            this.ContenedorPaneles.TabIndex = 53;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ContenedorIZQ);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.ContenedorDER);
            this.splitContainer1.Size = new System.Drawing.Size(1104, 452);
            this.splitContainer1.SplitterDistance = 665;
            this.splitContainer1.TabIndex = 0;
            // 
            // ContenedorIZQ
            // 
            this.ContenedorIZQ.BackColor = System.Drawing.Color.White;
            this.ContenedorIZQ.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.Supervisor;
            this.ContenedorIZQ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ContenedorIZQ.Controls.Add(this.lblCantidadRegistros);
            this.ContenedorIZQ.Controls.Add(this.dgvReporteTiemposRespuesta);
            this.ContenedorIZQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorIZQ.Location = new System.Drawing.Point(0, 0);
            this.ContenedorIZQ.Margin = new System.Windows.Forms.Padding(0);
            this.ContenedorIZQ.Name = "ContenedorIZQ";
            this.ContenedorIZQ.Size = new System.Drawing.Size(665, 452);
            this.ContenedorIZQ.TabIndex = 50;
            // 
            // dgvReporteTiemposRespuesta
            // 
            this.dgvReporteTiemposRespuesta.AllowUserToAddRows = false;
            this.dgvReporteTiemposRespuesta.AllowUserToDeleteRows = false;
            this.dgvReporteTiemposRespuesta.AllowUserToOrderColumns = true;
            this.dgvReporteTiemposRespuesta.AllowUserToResizeRows = false;
            this.dgvReporteTiemposRespuesta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReporteTiemposRespuesta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvReporteTiemposRespuesta.BackgroundColor = System.Drawing.Color.White;
            this.dgvReporteTiemposRespuesta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReporteTiemposRespuesta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReporteTiemposRespuesta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReporteTiemposRespuesta.ColumnHeadersHeight = 43;
            this.dgvReporteTiemposRespuesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReporteTiemposRespuesta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Metodo,
            this.Duracion});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReporteTiemposRespuesta.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvReporteTiemposRespuesta.EnableHeadersVisualStyles = false;
            this.dgvReporteTiemposRespuesta.GridColor = System.Drawing.Color.White;
            this.dgvReporteTiemposRespuesta.Location = new System.Drawing.Point(3, 65);
            this.dgvReporteTiemposRespuesta.MultiSelect = false;
            this.dgvReporteTiemposRespuesta.Name = "dgvReporteTiemposRespuesta";
            this.dgvReporteTiemposRespuesta.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReporteTiemposRespuesta.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvReporteTiemposRespuesta.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dgvReporteTiemposRespuesta.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvReporteTiemposRespuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvReporteTiemposRespuesta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporteTiemposRespuesta.Size = new System.Drawing.Size(659, 384);
            this.dgvReporteTiemposRespuesta.TabIndex = 53;
            this.dgvReporteTiemposRespuesta.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReporteTiemposRespuesta_RowEnter);
            // 
            // ContenedorDER
            // 
            this.ContenedorDER.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.detalle_2;
            this.ContenedorDER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ContenedorDER.Controls.Add(this.LblFecha);
            this.ContenedorDER.Controls.Add(this.label10);
            this.ContenedorDER.Controls.Add(this.LblDuracion);
            this.ContenedorDER.Controls.Add(this.label11);
            this.ContenedorDER.Controls.Add(this.LblMetodo);
            this.ContenedorDER.Controls.Add(this.label13);
            this.ContenedorDER.Controls.Add(this.LblCapa);
            this.ContenedorDER.Controls.Add(this.label14);
            this.ContenedorDER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorDER.Location = new System.Drawing.Point(0, 0);
            this.ContenedorDER.Name = "ContenedorDER";
            this.ContenedorDER.Size = new System.Drawing.Size(435, 452);
            this.ContenedorDER.TabIndex = 52;
            // 
            // LblFecha
            // 
            this.LblFecha.AutoSize = true;
            this.LblFecha.BackColor = System.Drawing.Color.Transparent;
            this.LblFecha.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblFecha.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblFecha.Location = new System.Drawing.Point(95, 161);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(97, 21);
            this.LblFecha.TabIndex = 14;
            this.LblFecha.Text = "Fecha inicial:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(29, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 23);
            this.label10.TabIndex = 13;
            this.label10.Text = "Fecha:";
            // 
            // LblDuracion
            // 
            this.LblDuracion.AutoSize = true;
            this.LblDuracion.BackColor = System.Drawing.Color.Transparent;
            this.LblDuracion.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblDuracion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblDuracion.Location = new System.Drawing.Point(122, 198);
            this.LblDuracion.Name = "LblDuracion";
            this.LblDuracion.Size = new System.Drawing.Size(97, 21);
            this.LblDuracion.TabIndex = 12;
            this.LblDuracion.Text = "Fecha inicial:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(29, 197);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 23);
            this.label11.TabIndex = 11;
            this.label11.Text = "Duración:";
            // 
            // LblMetodo
            // 
            this.LblMetodo.AutoSize = true;
            this.LblMetodo.BackColor = System.Drawing.Color.Transparent;
            this.LblMetodo.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblMetodo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblMetodo.Location = new System.Drawing.Point(113, 89);
            this.LblMetodo.Name = "LblMetodo";
            this.LblMetodo.Size = new System.Drawing.Size(97, 21);
            this.LblMetodo.TabIndex = 8;
            this.LblMetodo.Text = "Fecha inicial:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(29, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 23);
            this.label13.TabIndex = 7;
            this.label13.Text = "Método:";
            // 
            // LblCapa
            // 
            this.LblCapa.AutoSize = true;
            this.LblCapa.BackColor = System.Drawing.Color.Transparent;
            this.LblCapa.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblCapa.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblCapa.Location = new System.Drawing.Point(95, 123);
            this.LblCapa.Name = "LblCapa";
            this.LblCapa.Size = new System.Drawing.Size(97, 21);
            this.LblCapa.TabIndex = 6;
            this.LblCapa.Text = "Fecha inicial:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(29, 121);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 23);
            this.label14.TabIndex = 5;
            this.label14.Text = "Capa:";
            // 
            // BtnExportar
            // 
            this.BtnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExportar.BackColor = System.Drawing.Color.Transparent;
            this.BtnExportar.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.btn_0003_excel_azul;
            this.BtnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportar.Imagen = null;
            this.BtnExportar.ImagenDesabilitado = null;
            this.BtnExportar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_0002_excel_rojo;
            this.BtnExportar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_0003_excel_azul;
            this.BtnExportar.Location = new System.Drawing.Point(1011, 34);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(98, 27);
            this.BtnExportar.TabIndex = 73;
            this.BtnExportar.TamamoTexto = 8.25F;
            this.BtnExportar.TextoBoton = "";
            this.BtnExportar.Tooltip = null;
            this.BtnExportar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnExportar_EventoClick);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.BtnBuscar.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.btn_0005_buscar_azul;
            this.BtnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscar.Imagen = null;
            this.BtnBuscar.ImagenDesabilitado = null;
            this.BtnBuscar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_0004_buscar_rojo;
            this.BtnBuscar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_0005_buscar_azul;
            this.BtnBuscar.Location = new System.Drawing.Point(907, 34);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(98, 27);
            this.BtnBuscar.TabIndex = 74;
            this.BtnBuscar.TamamoTexto = 8.25F;
            this.BtnBuscar.TextoBoton = "";
            this.BtnBuscar.Tooltip = null;
            this.BtnBuscar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnBuscar_EventoClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(131, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Fecha final:";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(26, 32);
            this.dtpFechaIngreso.MaxDate = new System.DateTime(3016, 7, 18, 0, 0, 0, 0);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(102, 22);
            this.dtpFechaIngreso.TabIndex = 68;
            this.dtpFechaIngreso.Value = new System.DateTime(2016, 7, 18, 0, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(455, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 72;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Fecha inicial:";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(134, 33);
            this.dtpFechaFinal.MaxDate = new System.DateTime(3016, 7, 18, 0, 0, 0, 0);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(104, 22);
            this.dtpFechaFinal.TabIndex = 70;
            this.dtpFechaFinal.Value = new System.DateTime(2016, 7, 18, 0, 0, 0, 0);
            // 
            // Metodo
            // 
            this.Metodo.DataPropertyName = "Metodo";
            this.Metodo.HeaderText = "Método";
            this.Metodo.Name = "Metodo";
            this.Metodo.ReadOnly = true;
            this.Metodo.Width = 79;
            // 
            // Duracion
            // 
            this.Duracion.DataPropertyName = "Duracion";
            this.Duracion.HeaderText = "Duración";
            this.Duracion.Name = "Duracion";
            this.Duracion.ReadOnly = true;
            this.Duracion.Width = 87;
            // 
            // ctrlReporteTiemposRespuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ContenedorPaneles);
            this.Controls.Add(this.BtnExportar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaIngreso);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaFinal);
            this.Name = "ctrlReporteTiemposRespuesta";
            this.Size = new System.Drawing.Size(1131, 562);
            this.Load += new System.EventHandler(this.ctrlReporteTiemposRespuesta_Load);
            this.ContenedorPaneles.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ContenedorIZQ.ResumeLayout(false);
            this.ContenedorIZQ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteTiemposRespuesta)).EndInit();
            this.ContenedorDER.ResumeLayout(false);
            this.ContenedorDER.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidadRegistros;
        private System.Windows.Forms.Panel ContenedorPaneles;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel ContenedorIZQ;
        private System.Windows.Forms.DataGridView dgvReporteTiemposRespuesta;
        private System.Windows.Forms.Panel ContenedorDER;
        private System.Windows.Forms.Label LblFecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LblDuracion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LblMetodo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label LblCapa;
        private System.Windows.Forms.Label label14;
        private Controles.Boton BtnExportar;
        private Controles.Boton BtnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Metodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duracion;
    }
}

namespace CapturaHuellaBanco.ControlesWF
{
    partial class ctrlReporteAuditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txbDocumento = new System.Windows.Forms.TextBox();
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.ContenedorPaneles = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ContenedorIZQ = new System.Windows.Forms.Panel();
            this.dgvInforme = new System.Windows.Forms.DataGridView();
            this.lblCantidadRegistros = new System.Windows.Forms.Label();
            this.ContenedorDER = new System.Windows.Forms.Panel();
            this.panelDetalle = new System.Windows.Forms.Panel();
            this.lblSerial = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDedos = new Controles.LabelPersonalizado();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIdProducto = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblFechaTrans = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblFormato = new System.Windows.Forms.Label();
            this.LblOficina = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.LblTituloEstado = new Controles.LabelPersonalizado();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.BtnLogoEstado = new Controles.Boton();
            this.LblTextoEstado = new Controles.LabelPersonalizado();
            this.BtnLimpiar = new Controles.Boton();
            this.BtnExportar = new Controles.Boton();
            this.BtnBuscar = new Controles.Boton();
            this.txbOficina = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ContenedorPaneles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ContenedorIZQ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInforme)).BeginInit();
            this.ContenedorDER.SuspendLayout();
            this.panelDetalle.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(579, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 79;
            this.label2.Text = "Respuesta:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Exitoso",
            "No Exitoso"});
            this.cmbEstado.Location = new System.Drawing.Point(582, 26);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(117, 23);
            this.cmbEstado.TabIndex = 78;
            // 
            // txbDocumento
            // 
            this.txbDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDocumento.Location = new System.Drawing.Point(349, 29);
            this.txbDocumento.Name = "txbDocumento";
            this.txbDocumento.Size = new System.Drawing.Size(110, 21);
            this.txbDocumento.TabIndex = 71;
            // 
            // txbUsuario
            // 
            this.txbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsuario.Location = new System.Drawing.Point(236, 29);
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.Size = new System.Drawing.Size(107, 21);
            this.txbUsuario.TabIndex = 69;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd-mm-yyyy";
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(22, 27);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(103, 22);
            this.dtpFechaInicio.TabIndex = 67;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(125, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 17);
            this.label14.TabIndex = 70;
            this.label14.Text = "Fecha final:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd-mm-yyyy";
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(128, 27);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(102, 22);
            this.dtpFechaFin.TabIndex = 72;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label16.Location = new System.Drawing.Point(19, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 17);
            this.label16.TabIndex = 66;
            this.label16.Text = "Fecha inicial:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(233, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 17);
            this.label15.TabIndex = 73;
            this.label15.Text = "Usuario:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(346, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 17);
            this.label17.TabIndex = 74;
            this.label17.Text = "Documento:";
            // 
            // ContenedorPaneles
            // 
            this.ContenedorPaneles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContenedorPaneles.Controls.Add(this.splitContainer1);
            this.ContenedorPaneles.Location = new System.Drawing.Point(19, 58);
            this.ContenedorPaneles.Name = "ContenedorPaneles";
            this.ContenedorPaneles.Size = new System.Drawing.Size(1012, 477);
            this.ContenedorPaneles.TabIndex = 80;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
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
            this.splitContainer1.Size = new System.Drawing.Size(1012, 477);
            this.splitContainer1.SplitterDistance = 610;
            this.splitContainer1.TabIndex = 0;
            // 
            // ContenedorIZQ
            // 
            this.ContenedorIZQ.BackColor = System.Drawing.Color.White;
            this.ContenedorIZQ.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.resumen_consulta;
            this.ContenedorIZQ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ContenedorIZQ.Controls.Add(this.dgvInforme);
            this.ContenedorIZQ.Controls.Add(this.lblCantidadRegistros);
            this.ContenedorIZQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorIZQ.Location = new System.Drawing.Point(0, 0);
            this.ContenedorIZQ.Margin = new System.Windows.Forms.Padding(0);
            this.ContenedorIZQ.Name = "ContenedorIZQ";
            this.ContenedorIZQ.Size = new System.Drawing.Size(610, 477);
            this.ContenedorIZQ.TabIndex = 49;
            // 
            // dgvInforme
            // 
            this.dgvInforme.AllowUserToAddRows = false;
            this.dgvInforme.AllowUserToDeleteRows = false;
            this.dgvInforme.AllowUserToOrderColumns = true;
            this.dgvInforme.AllowUserToResizeRows = false;
            this.dgvInforme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInforme.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvInforme.BackgroundColor = System.Drawing.Color.White;
            this.dgvInforme.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInforme.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInforme.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvInforme.ColumnHeadersHeight = 43;
            this.dgvInforme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInforme.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvInforme.EnableHeadersVisualStyles = false;
            this.dgvInforme.GridColor = System.Drawing.Color.White;
            this.dgvInforme.Location = new System.Drawing.Point(0, 64);
            this.dgvInforme.MultiSelect = false;
            this.dgvInforme.Name = "dgvInforme";
            this.dgvInforme.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInforme.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvInforme.RowHeadersVisible = false;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            this.dgvInforme.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvInforme.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvInforme.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInforme.Size = new System.Drawing.Size(610, 410);
            this.dgvInforme.TabIndex = 53;
            this.dgvInforme.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInforme_RowEnter);
            // 
            // lblCantidadRegistros
            // 
            this.lblCantidadRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantidadRegistros.AutoSize = true;
            this.lblCantidadRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidadRegistros.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadRegistros.ForeColor = System.Drawing.Color.White;
            this.lblCantidadRegistros.Location = new System.Drawing.Point(496, 31);
            this.lblCantidadRegistros.Name = "lblCantidadRegistros";
            this.lblCantidadRegistros.Size = new System.Drawing.Size(98, 13);
            this.lblCantidadRegistros.TabIndex = 50;
            this.lblCantidadRegistros.Text = "N° registros: 1000";
            // 
            // ContenedorDER
            // 
            this.ContenedorDER.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.detalle_2;
            this.ContenedorDER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ContenedorDER.Controls.Add(this.panelDetalle);
            this.ContenedorDER.Controls.Add(this.panel1);
            this.ContenedorDER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorDER.Location = new System.Drawing.Point(0, 0);
            this.ContenedorDER.Name = "ContenedorDER";
            this.ContenedorDER.Size = new System.Drawing.Size(398, 477);
            this.ContenedorDER.TabIndex = 52;
            // 
            // panelDetalle
            // 
            this.panelDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetalle.BackColor = System.Drawing.Color.Transparent;
            this.panelDetalle.Controls.Add(this.lblCodigo);
            this.panelDetalle.Controls.Add(this.label10);
            this.panelDetalle.Controls.Add(this.lblSerial);
            this.panelDetalle.Controls.Add(this.label9);
            this.panelDetalle.Controls.Add(this.lblDedos);
            this.panelDetalle.Controls.Add(this.label1);
            this.panelDetalle.Controls.Add(this.lblIdProducto);
            this.panelDetalle.Controls.Add(this.label4);
            this.panelDetalle.Controls.Add(this.label3);
            this.panelDetalle.Controls.Add(this.LblFechaTrans);
            this.panelDetalle.Controls.Add(this.label7);
            this.panelDetalle.Controls.Add(this.LblFormato);
            this.panelDetalle.Controls.Add(this.LblOficina);
            this.panelDetalle.Controls.Add(this.label5);
            this.panelDetalle.Location = new System.Drawing.Point(5, 203);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Size = new System.Drawing.Size(390, 259);
            this.panelDetalle.TabIndex = 13;
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.BackColor = System.Drawing.Color.Transparent;
            this.lblSerial.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.lblSerial.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSerial.Location = new System.Drawing.Point(81, 147);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(0, 21);
            this.lblSerial.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(15, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Serial:";
            // 
            // lblDedos
            // 
            this.lblDedos.Color = System.Drawing.Color.Empty;
            this.lblDedos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDedos.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDedos.Location = new System.Drawing.Point(93, 174);
            this.lblDedos.MaximumSize = new System.Drawing.Size(250, 80);
            this.lblDedos.Name = "lblDedos";
            this.lblDedos.Size = new System.Drawing.Size(250, 80);
            this.lblDedos.TabIndex = 16;
            this.lblDedos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(15, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Dedos:";
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.AutoSize = true;
            this.lblIdProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblIdProducto.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.lblIdProducto.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIdProducto.Location = new System.Drawing.Point(109, 90);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(0, 21);
            this.lblIdProducto.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(15, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Formato Protección:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(15, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Oficina:";
            // 
            // LblFechaTrans
            // 
            this.LblFechaTrans.AutoSize = true;
            this.LblFechaTrans.BackColor = System.Drawing.Color.Transparent;
            this.LblFechaTrans.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblFechaTrans.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblFechaTrans.Location = new System.Drawing.Point(171, 36);
            this.LblFechaTrans.Name = "LblFechaTrans";
            this.LblFechaTrans.Size = new System.Drawing.Size(0, 21);
            this.LblFechaTrans.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(15, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "Fecha transacción:";
            // 
            // LblFormato
            // 
            this.LblFormato.AutoSize = true;
            this.LblFormato.BackColor = System.Drawing.Color.Transparent;
            this.LblFormato.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblFormato.ForeColor = System.Drawing.Color.Green;
            this.LblFormato.Location = new System.Drawing.Point(193, 119);
            this.LblFormato.Name = "LblFormato";
            this.LblFormato.Size = new System.Drawing.Size(75, 21);
            this.LblFormato.TabIndex = 10;
            this.LblFormato.Text = "Aceptado";
            // 
            // LblOficina
            // 
            this.LblOficina.AutoSize = true;
            this.LblOficina.BackColor = System.Drawing.Color.Transparent;
            this.LblOficina.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblOficina.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblOficina.Location = new System.Drawing.Point(93, 10);
            this.LblOficina.MaximumSize = new System.Drawing.Size(250, 0);
            this.LblOficina.Name = "LblOficina";
            this.LblOficina.Size = new System.Drawing.Size(0, 21);
            this.LblOficina.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(15, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Producto:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.splitContainer2);
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 85);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.LblTituloEstado);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(392, 85);
            this.splitContainer2.SplitterDistance = 28;
            this.splitContainer2.TabIndex = 0;
            // 
            // LblTituloEstado
            // 
            this.LblTituloEstado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LblTituloEstado.Color = System.Drawing.Color.Empty;
            this.LblTituloEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTituloEstado.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.LblTituloEstado.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblTituloEstado.Location = new System.Drawing.Point(0, 0);
            this.LblTituloEstado.Name = "LblTituloEstado";
            this.LblTituloEstado.Size = new System.Drawing.Size(392, 28);
            this.LblTituloEstado.TabIndex = 1;
            this.LblTituloEstado.Text = "Estado";
            this.LblTituloEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.BtnLogoEstado);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.LblTextoEstado);
            this.splitContainer3.Size = new System.Drawing.Size(392, 53);
            this.splitContainer3.SplitterDistance = 199;
            this.splitContainer3.TabIndex = 0;
            // 
            // BtnLogoEstado
            // 
            this.BtnLogoEstado.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogoEstado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnLogoEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLogoEstado.Enabled = false;
            this.BtnLogoEstado.Imagen = null;
            this.BtnLogoEstado.ImagenDesabilitado = null;
            this.BtnLogoEstado.ImagenSobre = null;
            this.BtnLogoEstado.ImagenVisitada = null;
            this.BtnLogoEstado.Location = new System.Drawing.Point(0, 0);
            this.BtnLogoEstado.Name = "BtnLogoEstado";
            this.BtnLogoEstado.Size = new System.Drawing.Size(199, 53);
            this.BtnLogoEstado.TabIndex = 0;
            this.BtnLogoEstado.TamamoTexto = 8.25F;
            this.BtnLogoEstado.TextoBoton = "";
            this.BtnLogoEstado.Tooltip = null;
            // 
            // LblTextoEstado
            // 
            this.LblTextoEstado.Color = System.Drawing.Color.Empty;
            this.LblTextoEstado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblTextoEstado.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblTextoEstado.Location = new System.Drawing.Point(0, 0);
            this.LblTextoEstado.MaximumSize = new System.Drawing.Size(180, 50);
            this.LblTextoEstado.Name = "LblTextoEstado";
            this.LblTextoEstado.Size = new System.Drawing.Size(180, 50);
            this.LblTextoEstado.TabIndex = 0;
            this.LblTextoEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.BtnLimpiar.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.btn_0001_limpiar_azul;
            this.BtnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.Imagen = null;
            this.BtnLimpiar.ImagenDesabilitado = null;
            this.BtnLimpiar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_0000_limpiar_rojo;
            this.BtnLimpiar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_0001_limpiar_azul;
            this.BtnLimpiar.Location = new System.Drawing.Point(927, 22);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(104, 27);
            this.BtnLimpiar.TabIndex = 75;
            this.BtnLimpiar.TamamoTexto = 8.25F;
            this.BtnLimpiar.TextoBoton = "";
            this.BtnLimpiar.Tooltip = null;
            this.BtnLimpiar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnLimpiar_EventoClick);
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
            this.BtnExportar.Location = new System.Drawing.Point(817, 22);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(104, 27);
            this.BtnExportar.TabIndex = 76;
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
            this.BtnBuscar.Location = new System.Drawing.Point(707, 22);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(104, 27);
            this.BtnBuscar.TabIndex = 77;
            this.BtnBuscar.TamamoTexto = 8.25F;
            this.BtnBuscar.TextoBoton = "";
            this.BtnBuscar.Tooltip = null;
            this.BtnBuscar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnBuscar_EventoClick);
            // 
            // txbOficina
            // 
            this.txbOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbOficina.Location = new System.Drawing.Point(465, 28);
            this.txbOficina.Name = "txbOficina";
            this.txbOficina.Size = new System.Drawing.Size(110, 21);
            this.txbOficina.TabIndex = 99;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(462, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 17);
            this.label6.TabIndex = 100;
            this.label6.Text = "Oficina:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.lblCodigo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCodigo.Location = new System.Drawing.Point(109, 62);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(0, 21);
            this.lblCodigo.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(15, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 23);
            this.label10.TabIndex = 19;
            this.label10.Text = "Código:";
            // 
            // ctrlReporteAuditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txbOficina);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ContenedorPaneles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnExportar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.txbDocumento);
            this.Controls.Add(this.txbUsuario);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label17);
            this.Name = "ctrlReporteAuditor";
            this.Size = new System.Drawing.Size(1041, 547);
            this.Load += new System.EventHandler(this.ctrlReporteAuditor_Load);
            this.ContenedorPaneles.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ContenedorIZQ.ResumeLayout(false);
            this.ContenedorIZQ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInforme)).EndInit();
            this.ContenedorDER.ResumeLayout(false);
            this.panelDetalle.ResumeLayout(false);
            this.panelDetalle.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEstado;
        private Controles.Boton BtnLimpiar;
        private Controles.Boton BtnExportar;
        private Controles.Boton BtnBuscar;
        private System.Windows.Forms.TextBox txbDocumento;
        private System.Windows.Forms.TextBox txbUsuario;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel ContenedorPaneles;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel ContenedorIZQ;
        private System.Windows.Forms.DataGridView dgvInforme;
        private System.Windows.Forms.Label lblCantidadRegistros;
        private System.Windows.Forms.Panel ContenedorDER;
        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblFechaTrans;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblFormato;
        private System.Windows.Forms.Label LblOficina;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controles.LabelPersonalizado LblTituloEstado;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Controles.Boton BtnLogoEstado;
        private Controles.LabelPersonalizado LblTextoEstado;
        private System.Windows.Forms.Label lblIdProducto;
        private System.Windows.Forms.Label label4;
        private Controles.LabelPersonalizado lblDedos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbOficina;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label10;

    }
}

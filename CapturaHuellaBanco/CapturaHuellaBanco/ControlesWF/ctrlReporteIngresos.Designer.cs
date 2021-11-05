namespace CapturaHuellaBanco.ControlesWF
{
    partial class ctrlReporteIngresos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCantidadRegistros = new System.Windows.Forms.Label();
            this.ContenedorPaneles = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ContenedorIZQ = new System.Windows.Forms.Panel();
            this.dgvReporteIngresos = new System.Windows.Forms.DataGridView();
            this.UsuarioLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContenedorDER = new System.Windows.Forms.Panel();
            this.panelDetalle = new System.Windows.Forms.Panel();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblIp = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblFechaIngreso = new System.Windows.Forms.Label();
            this.LblOficina = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.LblExitoso = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnLimpiar = new Controles.Boton();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnExportar = new Controles.Boton();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.BtnBuscar = new Controles.Boton();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ContenedorPaneles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ContenedorIZQ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteIngresos)).BeginInit();
            this.ContenedorDER.SuspendLayout();
            this.panelDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCantidadRegistros
            // 
            this.lblCantidadRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantidadRegistros.AutoSize = true;
            this.lblCantidadRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidadRegistros.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadRegistros.ForeColor = System.Drawing.Color.White;
            this.lblCantidadRegistros.Location = new System.Drawing.Point(541, 32);
            this.lblCantidadRegistros.Name = "lblCantidadRegistros";
            this.lblCantidadRegistros.Size = new System.Drawing.Size(101, 13);
            this.lblCantidadRegistros.TabIndex = 42;
            this.lblCantidadRegistros.Text = "N° registros:10000";
            // 
            // ContenedorPaneles
            // 
            this.ContenedorPaneles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContenedorPaneles.Controls.Add(this.splitContainer1);
            this.ContenedorPaneles.Location = new System.Drawing.Point(18, 67);
            this.ContenedorPaneles.Name = "ContenedorPaneles";
            this.ContenedorPaneles.Size = new System.Drawing.Size(1104, 475);
            this.ContenedorPaneles.TabIndex = 53;
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
            this.splitContainer1.Size = new System.Drawing.Size(1104, 475);
            this.splitContainer1.SplitterDistance = 665;
            this.splitContainer1.TabIndex = 0;
            // 
            // ContenedorIZQ
            // 
            this.ContenedorIZQ.BackColor = System.Drawing.Color.White;
            this.ContenedorIZQ.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.Accesos;
            this.ContenedorIZQ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ContenedorIZQ.Controls.Add(this.dgvReporteIngresos);
            this.ContenedorIZQ.Controls.Add(this.lblCantidadRegistros);
            this.ContenedorIZQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorIZQ.Location = new System.Drawing.Point(0, 0);
            this.ContenedorIZQ.Margin = new System.Windows.Forms.Padding(0);
            this.ContenedorIZQ.Name = "ContenedorIZQ";
            this.ContenedorIZQ.Size = new System.Drawing.Size(665, 475);
            this.ContenedorIZQ.TabIndex = 50;
            // 
            // dgvReporteIngresos
            // 
            this.dgvReporteIngresos.AllowUserToAddRows = false;
            this.dgvReporteIngresos.AllowUserToDeleteRows = false;
            this.dgvReporteIngresos.AllowUserToOrderColumns = true;
            this.dgvReporteIngresos.AllowUserToResizeRows = false;
            this.dgvReporteIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReporteIngresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvReporteIngresos.BackgroundColor = System.Drawing.Color.White;
            this.dgvReporteIngresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReporteIngresos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReporteIngresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvReporteIngresos.ColumnHeadersHeight = 43;
            this.dgvReporteIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReporteIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UsuarioLogin,
            this.IP,
            this.Fecha});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReporteIngresos.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvReporteIngresos.EnableHeadersVisualStyles = false;
            this.dgvReporteIngresos.GridColor = System.Drawing.Color.White;
            this.dgvReporteIngresos.Location = new System.Drawing.Point(3, 63);
            this.dgvReporteIngresos.MultiSelect = false;
            this.dgvReporteIngresos.Name = "dgvReporteIngresos";
            this.dgvReporteIngresos.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReporteIngresos.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvReporteIngresos.RowHeadersVisible = false;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            this.dgvReporteIngresos.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvReporteIngresos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvReporteIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporteIngresos.Size = new System.Drawing.Size(659, 409);
            this.dgvReporteIngresos.TabIndex = 53;
            this.dgvReporteIngresos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReporteIngresos_RowEnter);
            // 
            // UsuarioLogin
            // 
            this.UsuarioLogin.DataPropertyName = "UsuarioLogin";
            this.UsuarioLogin.HeaderText = "Usuario";
            this.UsuarioLogin.Name = "UsuarioLogin";
            this.UsuarioLogin.ReadOnly = true;
            this.UsuarioLogin.Width = 78;
            // 
            // IP
            // 
            this.IP.DataPropertyName = "IP";
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.Width = 43;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha Ingreso";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 106;
            // 
            // ContenedorDER
            // 
            this.ContenedorDER.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.detalle_2;
            this.ContenedorDER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ContenedorDER.Controls.Add(this.panelDetalle);
            this.ContenedorDER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorDER.Location = new System.Drawing.Point(0, 0);
            this.ContenedorDER.Name = "ContenedorDER";
            this.ContenedorDER.Size = new System.Drawing.Size(435, 475);
            this.ContenedorDER.TabIndex = 52;
            // 
            // panelDetalle
            // 
            this.panelDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetalle.BackColor = System.Drawing.Color.Transparent;
            this.panelDetalle.Controls.Add(this.lblCodigo);
            this.panelDetalle.Controls.Add(this.label8);
            this.panelDetalle.Controls.Add(this.LblIp);
            this.panelDetalle.Controls.Add(this.label14);
            this.panelDetalle.Controls.Add(this.label7);
            this.panelDetalle.Controls.Add(this.LblFechaIngreso);
            this.panelDetalle.Controls.Add(this.LblOficina);
            this.panelDetalle.Controls.Add(this.label13);
            this.panelDetalle.Controls.Add(this.label10);
            this.panelDetalle.Controls.Add(this.LblUsuario);
            this.panelDetalle.Controls.Add(this.LblExitoso);
            this.panelDetalle.Controls.Add(this.label11);
            this.panelDetalle.Location = new System.Drawing.Point(3, 87);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Size = new System.Drawing.Size(429, 230);
            this.panelDetalle.TabIndex = 17;
            this.panelDetalle.Visible = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.lblCodigo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCodigo.Location = new System.Drawing.Point(155, 164);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(60, 21);
            this.lblCodigo.TabIndex = 18;
            this.lblCodigo.Text = "Código";
            this.lblCodigo.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(14, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "Código Oficina:";
            this.label8.Visible = false;
            // 
            // LblIp
            // 
            this.LblIp.AutoSize = true;
            this.LblIp.BackColor = System.Drawing.Color.Transparent;
            this.LblIp.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblIp.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblIp.Location = new System.Drawing.Point(51, 44);
            this.LblIp.Name = "LblIp";
            this.LblIp.Size = new System.Drawing.Size(97, 21);
            this.LblIp.TabIndex = 16;
            this.LblIp.Text = "Fecha inicial:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(14, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 23);
            this.label14.TabIndex = 5;
            this.label14.Text = "Fecha ingreso:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(14, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Ip:";
            // 
            // LblFechaIngreso
            // 
            this.LblFechaIngreso.AutoSize = true;
            this.LblFechaIngreso.BackColor = System.Drawing.Color.Transparent;
            this.LblFechaIngreso.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblFechaIngreso.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblFechaIngreso.Location = new System.Drawing.Point(144, 86);
            this.LblFechaIngreso.Name = "LblFechaIngreso";
            this.LblFechaIngreso.Size = new System.Drawing.Size(97, 21);
            this.LblFechaIngreso.TabIndex = 6;
            this.LblFechaIngreso.Text = "Fecha inicial:";
            // 
            // LblOficina
            // 
            this.LblOficina.AutoSize = true;
            this.LblOficina.BackColor = System.Drawing.Color.Transparent;
            this.LblOficina.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblOficina.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblOficina.Location = new System.Drawing.Point(92, 198);
            this.LblOficina.Name = "LblOficina";
            this.LblOficina.Size = new System.Drawing.Size(97, 21);
            this.LblOficina.TabIndex = 14;
            this.LblOficina.Text = "Fecha inicial:";
            this.LblOficina.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(14, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 23);
            this.label13.TabIndex = 7;
            this.label13.Text = "Usuario:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(14, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 23);
            this.label10.TabIndex = 13;
            this.label10.Text = "Oficina:";
            this.label10.Visible = false;
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.LblUsuario.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblUsuario.Location = new System.Drawing.Point(103, 6);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(97, 21);
            this.LblUsuario.TabIndex = 8;
            this.LblUsuario.Text = "Fecha inicial:";
            // 
            // LblExitoso
            // 
            this.LblExitoso.AutoSize = true;
            this.LblExitoso.BackColor = System.Drawing.Color.Transparent;
            this.LblExitoso.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblExitoso.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblExitoso.Location = new System.Drawing.Point(165, 127);
            this.LblExitoso.Name = "LblExitoso";
            this.LblExitoso.Size = new System.Drawing.Size(97, 21);
            this.LblExitoso.TabIndex = 12;
            this.LblExitoso.Text = "Fecha inicial:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(14, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 23);
            this.label11.TabIndex = 11;
            this.label11.Text = "Ingreso exitoso:";
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
            this.BtnLimpiar.Location = new System.Drawing.Point(1011, 31);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(95, 27);
            this.BtnLimpiar.TabIndex = 63;
            this.BtnLimpiar.TamamoTexto = 8.25F;
            this.BtnLimpiar.TextoBoton = "";
            this.BtnLimpiar.Tooltip = null;
            this.BtnLimpiar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnLimpiar_EventoClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(486, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 62;
            this.label5.Text = "Exitoso";
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
            this.BtnExportar.Location = new System.Drawing.Point(910, 31);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(95, 27);
            this.BtnExportar.TabIndex = 64;
            this.BtnExportar.TamamoTexto = 8.25F;
            this.BtnExportar.TextoBoton = "";
            this.BtnExportar.Tooltip = null;
            this.BtnExportar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnExportar_EventoClick);
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(137, 39);
            this.dtpFechaFinal.MaxDate = new System.DateTime(3016, 7, 18, 0, 0, 0, 0);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(102, 22);
            this.dtpFechaFinal.TabIndex = 54;
            this.dtpFechaFinal.Value = new System.DateTime(2016, 7, 18, 0, 0, 0, 0);
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
            this.BtnBuscar.Location = new System.Drawing.Point(811, 31);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(95, 27);
            this.BtnBuscar.TabIndex = 65;
            this.BtnBuscar.TamamoTexto = 8.25F;
            this.BtnBuscar.TextoBoton = "";
            this.BtnBuscar.Tooltip = null;
            this.BtnBuscar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnBuscar_EventoClick);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(243, 39);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(117, 21);
            this.txtUsuario.TabIndex = 55;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Todos",
            "Exitoso",
            "No Exitoso"});
            this.cmbEstado.Location = new System.Drawing.Point(489, 38);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(117, 23);
            this.cmbEstado.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(240, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 59;
            this.label2.Text = "Usuario:";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(29, 39);
            this.dtpFechaIngreso.MaxDate = new System.DateTime(3016, 7, 18, 0, 0, 0, 0);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(102, 22);
            this.dtpFechaIngreso.TabIndex = 53;
            this.dtpFechaIngreso.Value = new System.DateTime(2016, 7, 18, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 56;
            this.label1.Text = "Fecha inicial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(363, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 60;
            this.label3.Text = "Dirección IP:";
            // 
            // txtIp
            // 
            this.txtIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIp.Location = new System.Drawing.Point(366, 39);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(117, 21);
            this.txtIp.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(134, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 61;
            this.label4.Text = "Fecha final:";
            // 
            // ctrlReporteIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ContenedorPaneles);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnExportar);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaIngreso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.label4);
            this.Name = "ctrlReporteIngresos";
            this.Size = new System.Drawing.Size(1141, 565);
            this.Load += new System.EventHandler(this.ctrlReporteIngresos_Load);
            this.ContenedorPaneles.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ContenedorIZQ.ResumeLayout(false);
            this.ContenedorIZQ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteIngresos)).EndInit();
            this.ContenedorDER.ResumeLayout(false);
            this.panelDetalle.ResumeLayout(false);
            this.panelDetalle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidadRegistros;
        private System.Windows.Forms.Panel ContenedorPaneles;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel ContenedorIZQ;
        private System.Windows.Forms.DataGridView dgvReporteIngresos;
        private System.Windows.Forms.Panel ContenedorDER;
        private System.Windows.Forms.Label LblOficina;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LblExitoso;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label LblFechaIngreso;
        private System.Windows.Forms.Label label14;
        private Controles.Boton BtnLimpiar;
        private System.Windows.Forms.Label label5;
        private Controles.Boton BtnExportar;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private Controles.Boton BtnBuscar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblIp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
    }
}

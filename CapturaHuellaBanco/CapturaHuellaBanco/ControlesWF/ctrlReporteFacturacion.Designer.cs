namespace CapturaHuellaBanco.ControlesWF
{
    partial class ctrlReporteFacturacion
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
            this.lblCantidadRegistros = new System.Windows.Forms.Label();
            this.ContenedorPaneles = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ContenedorIZQ = new System.Windows.Forms.Panel();
            this.dgvInforme = new System.Windows.Forms.DataGridView();
            this.ContenedorDER = new System.Windows.Forms.Panel();
            this.panelDetalle = new System.Windows.Forms.Panel();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblNoAprobados = new System.Windows.Forms.Label();
            this.LblValor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblAprobados = new System.Windows.Forms.Label();
            this.LblOficina = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnLimpiar = new Controles.Boton();
            this.BtnExportar = new Controles.Boton();
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.BtnBuscar = new Controles.Boton();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.txbDocumento = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIdProducto = new System.Windows.Forms.Label();
            this.ContenedorPaneles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ContenedorIZQ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInforme)).BeginInit();
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
            this.lblCantidadRegistros.Location = new System.Drawing.Point(631, 28);
            this.lblCantidadRegistros.Name = "lblCantidadRegistros";
            this.lblCantidadRegistros.Size = new System.Drawing.Size(101, 13);
            this.lblCantidadRegistros.TabIndex = 58;
            this.lblCantidadRegistros.Text = "N° registros:10000";
            // 
            // ContenedorPaneles
            // 
            this.ContenedorPaneles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContenedorPaneles.Controls.Add(this.splitContainer1);
            this.ContenedorPaneles.Location = new System.Drawing.Point(15, 68);
            this.ContenedorPaneles.Name = "ContenedorPaneles";
            this.ContenedorPaneles.Size = new System.Drawing.Size(1210, 616);
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
            this.splitContainer1.Size = new System.Drawing.Size(1210, 616);
            this.splitContainer1.SplitterDistance = 748;
            this.splitContainer1.TabIndex = 0;
            // 
            // ContenedorIZQ
            // 
            this.ContenedorIZQ.BackColor = System.Drawing.Color.White;
            this.ContenedorIZQ.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.Facturacion;
            this.ContenedorIZQ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ContenedorIZQ.Controls.Add(this.dgvInforme);
            this.ContenedorIZQ.Controls.Add(this.lblCantidadRegistros);
            this.ContenedorIZQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorIZQ.Location = new System.Drawing.Point(0, 0);
            this.ContenedorIZQ.Margin = new System.Windows.Forms.Padding(0);
            this.ContenedorIZQ.Name = "ContenedorIZQ";
            this.ContenedorIZQ.Size = new System.Drawing.Size(748, 616);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInforme.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInforme.ColumnHeadersHeight = 43;
            this.dgvInforme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInforme.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInforme.EnableHeadersVisualStyles = false;
            this.dgvInforme.GridColor = System.Drawing.Color.White;
            this.dgvInforme.Location = new System.Drawing.Point(0, 66);
            this.dgvInforme.MultiSelect = false;
            this.dgvInforme.Name = "dgvInforme";
            this.dgvInforme.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInforme.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInforme.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvInforme.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInforme.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvInforme.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInforme.Size = new System.Drawing.Size(748, 554);
            this.dgvInforme.TabIndex = 53;
            this.dgvInforme.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInforme_RowEnter);
            // 
            // ContenedorDER
            // 
            this.ContenedorDER.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.detalle_2;
            this.ContenedorDER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ContenedorDER.Controls.Add(this.panelDetalle);
            this.ContenedorDER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorDER.Location = new System.Drawing.Point(0, 0);
            this.ContenedorDER.Name = "ContenedorDER";
            this.ContenedorDER.Size = new System.Drawing.Size(458, 616);
            this.ContenedorDER.TabIndex = 52;
            // 
            // panelDetalle
            // 
            this.panelDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetalle.BackColor = System.Drawing.Color.Transparent;
            this.panelDetalle.Controls.Add(this.lblIdProducto);
            this.panelDetalle.Controls.Add(this.label4);
            this.panelDetalle.Controls.Add(this.lblValorTotal);
            this.panelDetalle.Controls.Add(this.label2);
            this.panelDetalle.Controls.Add(this.label1);
            this.panelDetalle.Controls.Add(this.LblNoAprobados);
            this.panelDetalle.Controls.Add(this.LblValor);
            this.panelDetalle.Controls.Add(this.label7);
            this.panelDetalle.Controls.Add(this.label3);
            this.panelDetalle.Controls.Add(this.LblAprobados);
            this.panelDetalle.Controls.Add(this.LblOficina);
            this.panelDetalle.Controls.Add(this.label5);
            this.panelDetalle.Location = new System.Drawing.Point(2, 88);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Size = new System.Drawing.Size(453, 251);
            this.panelDetalle.TabIndex = 13;
            this.panelDetalle.Visible = false;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblValorTotal.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.lblValorTotal.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblValorTotal.Location = new System.Drawing.Point(146, 197);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(97, 21);
            this.lblValorTotal.TabIndex = 14;
            this.lblValorTotal.Text = "Fecha inicial:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(12, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Valor Total:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Valor unitario:";
            // 
            // LblNoAprobados
            // 
            this.LblNoAprobados.AutoSize = true;
            this.LblNoAprobados.BackColor = System.Drawing.Color.Transparent;
            this.LblNoAprobados.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblNoAprobados.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblNoAprobados.Location = new System.Drawing.Point(146, 163);
            this.LblNoAprobados.Name = "LblNoAprobados";
            this.LblNoAprobados.Size = new System.Drawing.Size(97, 21);
            this.LblNoAprobados.TabIndex = 12;
            this.LblNoAprobados.Text = "Fecha inicial:";
            // 
            // LblValor
            // 
            this.LblValor.AutoSize = true;
            this.LblValor.BackColor = System.Drawing.Color.Transparent;
            this.LblValor.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblValor.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblValor.Location = new System.Drawing.Point(142, 88);
            this.LblValor.Name = "LblValor";
            this.LblValor.Size = new System.Drawing.Size(97, 21);
            this.LblValor.TabIndex = 6;
            this.LblValor.Text = "Fecha inicial:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(12, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "No aprobados:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(12, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Oficina:";
            // 
            // LblAprobados
            // 
            this.LblAprobados.AutoSize = true;
            this.LblAprobados.BackColor = System.Drawing.Color.Transparent;
            this.LblAprobados.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblAprobados.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblAprobados.Location = new System.Drawing.Point(121, 124);
            this.LblAprobados.Name = "LblAprobados";
            this.LblAprobados.Size = new System.Drawing.Size(97, 21);
            this.LblAprobados.TabIndex = 10;
            this.LblAprobados.Text = "Fecha inicial:";
            // 
            // LblOficina
            // 
            this.LblOficina.AutoSize = true;
            this.LblOficina.BackColor = System.Drawing.Color.Transparent;
            this.LblOficina.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblOficina.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblOficina.Location = new System.Drawing.Point(90, 21);
            this.LblOficina.Name = "LblOficina";
            this.LblOficina.Size = new System.Drawing.Size(97, 21);
            this.LblOficina.TabIndex = 8;
            this.LblOficina.Text = "Fecha inicial:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Aprobados:";
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
            this.BtnLimpiar.Location = new System.Drawing.Point(1114, 35);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(102, 27);
            this.BtnLimpiar.TabIndex = 68;
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
            this.BtnExportar.Location = new System.Drawing.Point(1006, 35);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(102, 27);
            this.BtnExportar.TabIndex = 69;
            this.BtnExportar.TamamoTexto = 8.25F;
            this.BtnExportar.TextoBoton = "";
            this.BtnExportar.Tooltip = null;
            this.BtnExportar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnExportar_EventoClick);
            // 
            // txbUsuario
            // 
            this.txbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsuario.Location = new System.Drawing.Point(246, 29);
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.Size = new System.Drawing.Size(128, 21);
            this.txbUsuario.TabIndex = 62;
            this.txbUsuario.Visible = false;
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
            this.BtnBuscar.Location = new System.Drawing.Point(898, 35);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(102, 27);
            this.BtnBuscar.TabIndex = 70;
            this.BtnBuscar.TamamoTexto = 8.25F;
            this.BtnBuscar.TextoBoton = "";
            this.BtnBuscar.Tooltip = null;
            this.BtnBuscar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnBuscar_EventoClick);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd-mm-yyyy";
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(29, 29);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(103, 22);
            this.dtpFechaInicio.TabIndex = 61;
            // 
            // txbDocumento
            // 
            this.txbDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDocumento.Location = new System.Drawing.Point(380, 29);
            this.txbDocumento.Name = "txbDocumento";
            this.txbDocumento.Size = new System.Drawing.Size(128, 21);
            this.txbDocumento.TabIndex = 64;
            this.txbDocumento.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label16.Location = new System.Drawing.Point(27, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 17);
            this.label16.TabIndex = 60;
            this.label16.Text = "Fecha inicial:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(377, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 17);
            this.label17.TabIndex = 67;
            this.label17.Text = "Documento:";
            this.label17.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(243, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 17);
            this.label15.TabIndex = 66;
            this.label15.Text = "Usuario:";
            this.label15.Visible = false;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd-mm-yyyy";
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(138, 29);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(102, 22);
            this.dtpFechaFin.TabIndex = 65;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(135, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 17);
            this.label14.TabIndex = 63;
            this.label14.Text = "Fecha final:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(12, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Producto:";
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.AutoSize = true;
            this.lblIdProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblIdProducto.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.lblIdProducto.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIdProducto.Location = new System.Drawing.Point(106, 55);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(97, 21);
            this.lblIdProducto.TabIndex = 16;
            this.lblIdProducto.Text = "Fecha inicial:";
            // 
            // ctrlReporteFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ContenedorPaneles);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnExportar);
            this.Controls.Add(this.txbUsuario);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.txbDocumento);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.label14);
            this.Name = "ctrlReporteFacturacion";
            this.Size = new System.Drawing.Size(1244, 705);
            this.Load += new System.EventHandler(this.ctrlReporteFacturacion_Load);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidadRegistros;
        private System.Windows.Forms.Panel ContenedorPaneles;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel ContenedorIZQ;
        private System.Windows.Forms.DataGridView dgvInforme;
        private System.Windows.Forms.Panel ContenedorDER;
        private System.Windows.Forms.Label LblNoAprobados;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblAprobados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblOficina;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblValor;
        private System.Windows.Forms.Label label1;
        private Controles.Boton BtnLimpiar;
        private Controles.Boton BtnExportar;
        private System.Windows.Forms.TextBox txbUsuario;
        private Controles.Boton BtnBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.TextBox txbDocumento;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIdProducto;
        private System.Windows.Forms.Label label4;
    }
}

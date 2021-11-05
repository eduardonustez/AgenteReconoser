namespace CapturaHuellaBanco.ControlesWF
{
    partial class ctrlReporteErrores
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
            this.ContenedorPaneles = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ContenedorIZQ = new System.Windows.Forms.Panel();
            this.lblCantidadRegistros = new System.Windows.Forms.Label();
            this.dgvReporteErrores = new System.Windows.Forms.DataGridView();
            this.UsuarioLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdOficina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContenedorDER = new System.Windows.Forms.Panel();
            this.LblDesc = new System.Windows.Forms.Label();
            this.LblOficina = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblFechaInc = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblCapa = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnLimpiar = new Controles.Boton();
            this.BtnExportar = new Controles.Boton();
            this.BtnBuscar = new Controles.Boton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.ContenedorPaneles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ContenedorIZQ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteErrores)).BeginInit();
            this.ContenedorDER.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContenedorPaneles
            // 
            this.ContenedorPaneles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContenedorPaneles.Controls.Add(this.splitContainer1);
            this.ContenedorPaneles.Location = new System.Drawing.Point(15, 65);
            this.ContenedorPaneles.Name = "ContenedorPaneles";
            this.ContenedorPaneles.Size = new System.Drawing.Size(1208, 521);
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
            this.splitContainer1.Size = new System.Drawing.Size(1208, 521);
            this.splitContainer1.SplitterDistance = 727;
            this.splitContainer1.TabIndex = 0;
            // 
            // ContenedorIZQ
            // 
            this.ContenedorIZQ.BackColor = System.Drawing.Color.White;
            this.ContenedorIZQ.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.Errores;
            this.ContenedorIZQ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ContenedorIZQ.Controls.Add(this.lblCantidadRegistros);
            this.ContenedorIZQ.Controls.Add(this.dgvReporteErrores);
            this.ContenedorIZQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorIZQ.Location = new System.Drawing.Point(0, 0);
            this.ContenedorIZQ.Margin = new System.Windows.Forms.Padding(0);
            this.ContenedorIZQ.Name = "ContenedorIZQ";
            this.ContenedorIZQ.Size = new System.Drawing.Size(727, 521);
            this.ContenedorIZQ.TabIndex = 49;
            // 
            // lblCantidadRegistros
            // 
            this.lblCantidadRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantidadRegistros.AutoSize = true;
            this.lblCantidadRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidadRegistros.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadRegistros.ForeColor = System.Drawing.Color.White;
            this.lblCantidadRegistros.Location = new System.Drawing.Point(613, 33);
            this.lblCantidadRegistros.Name = "lblCantidadRegistros";
            this.lblCantidadRegistros.Size = new System.Drawing.Size(101, 13);
            this.lblCantidadRegistros.TabIndex = 61;
            this.lblCantidadRegistros.Text = "N° registros:10000";
            // 
            // dgvReporteErrores
            // 
            this.dgvReporteErrores.AllowUserToAddRows = false;
            this.dgvReporteErrores.AllowUserToDeleteRows = false;
            this.dgvReporteErrores.AllowUserToOrderColumns = true;
            this.dgvReporteErrores.AllowUserToResizeRows = false;
            this.dgvReporteErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReporteErrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvReporteErrores.BackgroundColor = System.Drawing.Color.White;
            this.dgvReporteErrores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReporteErrores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReporteErrores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvReporteErrores.ColumnHeadersHeight = 43;
            this.dgvReporteErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReporteErrores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UsuarioLogin,
            this.IdOficina,
            this.Descripcion});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReporteErrores.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvReporteErrores.EnableHeadersVisualStyles = false;
            this.dgvReporteErrores.GridColor = System.Drawing.Color.White;
            this.dgvReporteErrores.Location = new System.Drawing.Point(3, 74);
            this.dgvReporteErrores.MultiSelect = false;
            this.dgvReporteErrores.Name = "dgvReporteErrores";
            this.dgvReporteErrores.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReporteErrores.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvReporteErrores.RowHeadersVisible = false;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            this.dgvReporteErrores.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvReporteErrores.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvReporteErrores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporteErrores.Size = new System.Drawing.Size(722, 444);
            this.dgvReporteErrores.TabIndex = 53;
            this.dgvReporteErrores.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReporteErrores_RowEnter);
            // 
            // UsuarioLogin
            // 
            this.UsuarioLogin.DataPropertyName = "UsuarioLogin";
            this.UsuarioLogin.HeaderText = "Usuario";
            this.UsuarioLogin.Name = "UsuarioLogin";
            this.UsuarioLogin.ReadOnly = true;
            this.UsuarioLogin.Width = 78;
            // 
            // IdOficina
            // 
            this.IdOficina.DataPropertyName = "IdOficina";
            this.IdOficina.HeaderText = "Oficina";
            this.IdOficina.Name = "IdOficina";
            this.IdOficina.ReadOnly = true;
            this.IdOficina.Width = 75;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 103;
            // 
            // ContenedorDER
            // 
            this.ContenedorDER.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.detalle_2;
            this.ContenedorDER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ContenedorDER.Controls.Add(this.LblDesc);
            this.ContenedorDER.Controls.Add(this.LblOficina);
            this.ContenedorDER.Controls.Add(this.label9);
            this.ContenedorDER.Controls.Add(this.label7);
            this.ContenedorDER.Controls.Add(this.LblFechaInc);
            this.ContenedorDER.Controls.Add(this.label5);
            this.ContenedorDER.Controls.Add(this.LblUsuario);
            this.ContenedorDER.Controls.Add(this.label4);
            this.ContenedorDER.Controls.Add(this.LblCapa);
            this.ContenedorDER.Controls.Add(this.label6);
            this.ContenedorDER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorDER.Location = new System.Drawing.Point(0, 0);
            this.ContenedorDER.Name = "ContenedorDER";
            this.ContenedorDER.Size = new System.Drawing.Size(477, 521);
            this.ContenedorDER.TabIndex = 52;
            // 
            // LblDesc
            // 
            this.LblDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblDesc.AutoSize = true;
            this.LblDesc.BackColor = System.Drawing.Color.Transparent;
            this.LblDesc.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblDesc.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblDesc.Location = new System.Drawing.Point(26, 250);
            this.LblDesc.MaximumSize = new System.Drawing.Size(400, 0);
            this.LblDesc.Name = "LblDesc";
            this.LblDesc.Size = new System.Drawing.Size(97, 21);
            this.LblDesc.TabIndex = 12;
            this.LblDesc.Text = "Fecha inicial:";
            this.LblDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblOficina
            // 
            this.LblOficina.AutoSize = true;
            this.LblOficina.BackColor = System.Drawing.Color.Transparent;
            this.LblOficina.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblOficina.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblOficina.Location = new System.Drawing.Point(115, 183);
            this.LblOficina.Name = "LblOficina";
            this.LblOficina.Size = new System.Drawing.Size(97, 21);
            this.LblOficina.TabIndex = 14;
            this.LblOficina.Text = "Fecha inicial:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(26, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 13;
            this.label9.Text = "Oficina:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(26, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "Descripción:";
            // 
            // LblFechaInc
            // 
            this.LblFechaInc.AutoSize = true;
            this.LblFechaInc.BackColor = System.Drawing.Color.Transparent;
            this.LblFechaInc.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblFechaInc.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblFechaInc.Location = new System.Drawing.Point(186, 147);
            this.LblFechaInc.Name = "LblFechaInc";
            this.LblFechaInc.Size = new System.Drawing.Size(97, 21);
            this.LblFechaInc.TabIndex = 10;
            this.LblFechaInc.Text = "Fecha inicial:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(26, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha incidente:";
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.LblUsuario.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblUsuario.Location = new System.Drawing.Point(115, 76);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(97, 21);
            this.LblUsuario.TabIndex = 8;
            this.LblUsuario.Text = "Fecha inicial:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(26, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Usuario:";
            // 
            // LblCapa
            // 
            this.LblCapa.AutoSize = true;
            this.LblCapa.BackColor = System.Drawing.Color.Transparent;
            this.LblCapa.Font = new System.Drawing.Font("Segoe UI", 11.75F);
            this.LblCapa.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblCapa.Location = new System.Drawing.Point(115, 112);
            this.LblCapa.Name = "LblCapa";
            this.LblCapa.Size = new System.Drawing.Size(97, 21);
            this.LblCapa.TabIndex = 6;
            this.LblCapa.Text = "Fecha inicial:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(26, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Capa:";
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
            this.BtnLimpiar.Location = new System.Drawing.Point(1124, 32);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(99, 27);
            this.BtnLimpiar.TabIndex = 71;
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
            this.BtnExportar.Location = new System.Drawing.Point(1019, 32);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(99, 27);
            this.BtnExportar.TabIndex = 72;
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
            this.BtnBuscar.Location = new System.Drawing.Point(914, 32);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(99, 27);
            this.BtnBuscar.TabIndex = 73;
            this.BtnBuscar.TamamoTexto = 8.25F;
            this.BtnBuscar.TextoBoton = "";
            this.BtnBuscar.Tooltip = null;
            this.BtnBuscar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnBuscar_EventoClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(139, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 69;
            this.label2.Text = "Fecha final:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(247, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 70;
            this.label3.Text = "Usuario:";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(32, 32);
            this.dtpFechaIngreso.MaxDate = new System.DateTime(3016, 7, 18, 0, 0, 0, 0);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(103, 22);
            this.dtpFechaIngreso.TabIndex = 65;
            this.dtpFechaIngreso.Value = new System.DateTime(2016, 7, 18, 0, 0, 0, 0);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(250, 32);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(111, 21);
            this.txtUsuario.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(29, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 68;
            this.label1.Text = "Fecha inicial:";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(141, 32);
            this.dtpFechaFinal.MaxDate = new System.DateTime(3016, 7, 18, 0, 0, 0, 0);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(103, 22);
            this.dtpFechaFinal.TabIndex = 66;
            this.dtpFechaFinal.Value = new System.DateTime(2016, 7, 18, 0, 0, 0, 0);
            // 
            // ctrlReporteErrores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ContenedorPaneles);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnExportar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFechaIngreso);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaFinal);
            this.Name = "ctrlReporteErrores";
            this.Size = new System.Drawing.Size(1243, 601);
            this.Load += new System.EventHandler(this.ctrlReporteErrores_Load);
            this.ContenedorPaneles.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ContenedorIZQ.ResumeLayout(false);
            this.ContenedorIZQ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteErrores)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvReporteErrores;
        private System.Windows.Forms.Panel ContenedorDER;
        private System.Windows.Forms.Label LblDesc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblFechaInc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblCapa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblOficina;
        private System.Windows.Forms.Label label9;
        private Controles.Boton BtnLimpiar;
        private Controles.Boton BtnExportar;
        private Controles.Boton BtnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOficina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;


    }
}

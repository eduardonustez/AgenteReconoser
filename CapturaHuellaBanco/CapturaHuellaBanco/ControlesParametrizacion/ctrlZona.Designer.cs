namespace CapturaHuellaBanco.ControlesParametrizacion
{
    partial class ctrlZona
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.dgvZona = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.IdZona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblZonaBusqueda = new System.Windows.Forms.Label();
            this.txtZonaBusqueda = new System.Windows.Forms.TextBox();
            this.gbCreacion = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtZona = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbEdicion = new System.Windows.Forms.GroupBox();
            this.txtDescripcionEdicion = new System.Windows.Forms.TextBox();
            this.txtZonaEdicion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlZona = new System.Windows.Forms.Panel();
            this.BtnExportar = new Controles.Boton();
            this.btnLimpiar = new Controles.Boton();
            this.BtnBuscar = new Controles.Boton();
            this.btnImportarExcel = new Controles.Boton();
            this.btnGuardar = new Controles.Boton();
            this.btnCancelar = new Controles.Boton();
            this.btnActualizar = new Controles.Boton();
            this.gbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZona)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.gbCreacion.SuspendLayout();
            this.gbEdicion.SuspendLayout();
            this.pnlZona.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbBusqueda.Controls.Add(this.dgvZona);
            this.gbBusqueda.Controls.Add(this.pnlFiltros);
            this.gbBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbBusqueda.ForeColor = System.Drawing.Color.DimGray;
            this.gbBusqueda.Location = new System.Drawing.Point(14, 10);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(1110, 260);
            this.gbBusqueda.TabIndex = 1;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Búsqueda";
            // 
            // dgvZona
            // 
            this.dgvZona.AllowUserToAddRows = false;
            this.dgvZona.AllowUserToDeleteRows = false;
            this.dgvZona.AllowUserToOrderColumns = true;
            this.dgvZona.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvZona.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvZona.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvZona.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvZona.BackgroundColor = System.Drawing.Color.White;
            this.dgvZona.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvZona.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvZona.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvZona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.IdZona,
            this.Descripcion});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvZona.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvZona.EnableHeadersVisualStyles = false;
            this.dgvZona.GridColor = System.Drawing.Color.White;
            this.dgvZona.Location = new System.Drawing.Point(13, 94);
            this.dgvZona.MultiSelect = false;
            this.dgvZona.Name = "dgvZona";
            this.dgvZona.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvZona.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvZona.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.dgvZona.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvZona.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvZona.Size = new System.Drawing.Size(1094, 160);
            this.dgvZona.TabIndex = 4;
            this.dgvZona.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvZona_CellContentClick);
            // 
            // Editar
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Editar.DefaultCellStyle = dataGridViewCellStyle3;
            this.Editar.FillWeight = 45.68527F;
            this.Editar.HeaderText = "Editar";
            this.Editar.Image = global::CapturaHuellaBanco.Properties.Resources.Edit_Azul;
            this.Editar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.ToolTipText = "Editar";
            // 
            // IdZona
            // 
            this.IdZona.DataPropertyName = "IdZona";
            this.IdZona.FillWeight = 127.1573F;
            this.IdZona.HeaderText = "Zona";
            this.IdZona.MaxInputLength = 100;
            this.IdZona.Name = "IdZona";
            this.IdZona.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.FillWeight = 127.1573F;
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MaxInputLength = 100;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.Controls.Add(this.BtnExportar);
            this.pnlFiltros.Controls.Add(this.btnLimpiar);
            this.pnlFiltros.Controls.Add(this.BtnBuscar);
            this.pnlFiltros.Controls.Add(this.textBox1);
            this.pnlFiltros.Controls.Add(this.lblZonaBusqueda);
            this.pnlFiltros.Controls.Add(this.txtZonaBusqueda);
            this.pnlFiltros.Location = new System.Drawing.Point(13, 20);
            this.pnlFiltros.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1094, 71);
            this.pnlFiltros.TabIndex = 48;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 4);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1094, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "   FILTROS DE BÚSQUEDA";
            // 
            // lblZonaBusqueda
            // 
            this.lblZonaBusqueda.AutoSize = true;
            this.lblZonaBusqueda.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZonaBusqueda.Location = new System.Drawing.Point(11, 28);
            this.lblZonaBusqueda.Name = "lblZonaBusqueda";
            this.lblZonaBusqueda.Size = new System.Drawing.Size(37, 13);
            this.lblZonaBusqueda.TabIndex = 45;
            this.lblZonaBusqueda.Text = "Zona:";
            // 
            // txtZonaBusqueda
            // 
            this.txtZonaBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZonaBusqueda.Location = new System.Drawing.Point(14, 44);
            this.txtZonaBusqueda.MaxLength = 100;
            this.txtZonaBusqueda.Name = "txtZonaBusqueda";
            this.txtZonaBusqueda.Size = new System.Drawing.Size(135, 21);
            this.txtZonaBusqueda.TabIndex = 1;
            // 
            // gbCreacion
            // 
            this.gbCreacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbCreacion.Controls.Add(this.btnImportarExcel);
            this.gbCreacion.Controls.Add(this.btnGuardar);
            this.gbCreacion.Controls.Add(this.txtDescripcion);
            this.gbCreacion.Controls.Add(this.txtZona);
            this.gbCreacion.Controls.Add(this.label3);
            this.gbCreacion.Controls.Add(this.label4);
            this.gbCreacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbCreacion.ForeColor = System.Drawing.Color.DimGray;
            this.gbCreacion.Location = new System.Drawing.Point(14, 273);
            this.gbCreacion.Name = "gbCreacion";
            this.gbCreacion.Size = new System.Drawing.Size(1110, 174);
            this.gbCreacion.TabIndex = 2;
            this.gbCreacion.TabStop = false;
            this.gbCreacion.Text = "Creación";
            this.gbCreacion.Visible = false;
            this.gbCreacion.Leave += new System.EventHandler(this.gbCreacion_Leave);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtDescripcion.Location = new System.Drawing.Point(132, 65);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(843, 100);
            this.txtDescripcion.TabIndex = 6;
            // 
            // txtZona
            // 
            this.txtZona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtZona.Location = new System.Drawing.Point(132, 20);
            this.txtZona.MaxLength = 100;
            this.txtZona.Name = "txtZona";
            this.txtZona.Size = new System.Drawing.Size(240, 21);
            this.txtZona.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Zona: ";
            // 
            // gbEdicion
            // 
            this.gbEdicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbEdicion.Controls.Add(this.btnCancelar);
            this.gbEdicion.Controls.Add(this.btnActualizar);
            this.gbEdicion.Controls.Add(this.txtDescripcionEdicion);
            this.gbEdicion.Controls.Add(this.txtZonaEdicion);
            this.gbEdicion.Controls.Add(this.label2);
            this.gbEdicion.Controls.Add(this.label1);
            this.gbEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbEdicion.ForeColor = System.Drawing.Color.DimGray;
            this.gbEdicion.Location = new System.Drawing.Point(14, 273);
            this.gbEdicion.Name = "gbEdicion";
            this.gbEdicion.Size = new System.Drawing.Size(1110, 174);
            this.gbEdicion.TabIndex = 3;
            this.gbEdicion.TabStop = false;
            this.gbEdicion.Text = "Edición";
            this.gbEdicion.Leave += new System.EventHandler(this.gbEdicion_Leave);
            // 
            // txtDescripcionEdicion
            // 
            this.txtDescripcionEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtDescripcionEdicion.Location = new System.Drawing.Point(132, 65);
            this.txtDescripcionEdicion.MaxLength = 100;
            this.txtDescripcionEdicion.Multiline = true;
            this.txtDescripcionEdicion.Name = "txtDescripcionEdicion";
            this.txtDescripcionEdicion.Size = new System.Drawing.Size(843, 100);
            this.txtDescripcionEdicion.TabIndex = 9;
            // 
            // txtZonaEdicion
            // 
            this.txtZonaEdicion.Enabled = false;
            this.txtZonaEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtZonaEdicion.Location = new System.Drawing.Point(132, 20);
            this.txtZonaEdicion.MaxLength = 100;
            this.txtZonaEdicion.Name = "txtZonaEdicion";
            this.txtZonaEdicion.Size = new System.Drawing.Size(240, 21);
            this.txtZonaEdicion.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zona: ";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "IdZona";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.NullValue = null;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewImageColumn1.DividerWidth = 3;
            this.dataGridViewImageColumn1.FillWeight = 76.14214F;
            this.dataGridViewImageColumn1.HeaderText = "Editar";
            this.dataGridViewImageColumn1.Image = global::CapturaHuellaBanco.Properties.Resources.Edit_Azul;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.ToolTipText = "Editar";
            this.dataGridViewImageColumn1.Width = 277;
            // 
            // pnlZona
            // 
            this.pnlZona.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlZona.Controls.Add(this.gbBusqueda);
            this.pnlZona.Controls.Add(this.gbCreacion);
            this.pnlZona.Controls.Add(this.gbEdicion);
            this.pnlZona.Location = new System.Drawing.Point(0, 0);
            this.pnlZona.Name = "pnlZona";
            this.pnlZona.Size = new System.Drawing.Size(1139, 472);
            this.pnlZona.TabIndex = 4;
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
            this.BtnExportar.Location = new System.Drawing.Point(845, 33);
            this.BtnExportar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(117, 27);
            this.BtnExportar.TabIndex = 73;
            this.BtnExportar.TamamoTexto = 8.25F;
            this.BtnExportar.TextoBoton = "";
            this.BtnExportar.Tooltip = null;
            this.BtnExportar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnExportar_EventoClick);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.BackgroundImage = global::CapturaHuellaBanco.Properties.Resources.btn_0001_limpiar_azul;
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Imagen = null;
            this.btnLimpiar.ImagenDesabilitado = null;
            this.btnLimpiar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_0000_limpiar_rojo;
            this.btnLimpiar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_0001_limpiar_azul;
            this.btnLimpiar.Location = new System.Drawing.Point(972, 33);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(117, 27);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.TamamoTexto = 8.25F;
            this.btnLimpiar.TextoBoton = "";
            this.btnLimpiar.Tooltip = null;
            this.btnLimpiar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnLimpiar_EventoClick);
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
            this.BtnBuscar.Location = new System.Drawing.Point(718, 33);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(117, 27);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.TamamoTexto = 8.25F;
            this.BtnBuscar.TextoBoton = "";
            this.BtnBuscar.Tooltip = null;
            this.BtnBuscar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnBuscar_EventoClick);
            // 
            // btnImportarExcel
            // 
            this.btnImportarExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnImportarExcel.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnImportarExcel.ImagenDesabilitado = null;
            this.btnImportarExcel.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnImportarExcel.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnImportarExcel.Location = new System.Drawing.Point(985, 109);
            this.btnImportarExcel.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.btnImportarExcel.Name = "btnImportarExcel";
            this.btnImportarExcel.Size = new System.Drawing.Size(117, 26);
            this.btnImportarExcel.TabIndex = 8;
            this.btnImportarExcel.TamamoTexto = 8.25F;
            this.btnImportarExcel.TextoBoton = "Importar Excel";
            this.btnImportarExcel.Tooltip = null;
            this.btnImportarExcel.EventoClick += new Controles.Boton.ClickEventHandler(this.btnImportarExcel_EventoClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            this.btnGuardar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnGuardar.ImagenDesabilitado = null;
            this.btnGuardar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnGuardar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnGuardar.Location = new System.Drawing.Point(985, 138);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 26);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.TamamoTexto = 8.25F;
            this.btnGuardar.TextoBoton = "Guardar";
            this.btnGuardar.Tooltip = null;
            this.btnGuardar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnGuardar_EventoClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            this.btnCancelar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnCancelar.ImagenDesabilitado = null;
            this.btnCancelar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnCancelar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnCancelar.Location = new System.Drawing.Point(985, 109);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(62, 21, 62, 21);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 26);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.TamamoTexto = 8.25F;
            this.btnCancelar.TextoBoton = "Cancelar";
            this.btnCancelar.Tooltip = null;
            this.btnCancelar.EventoClick += new Controles.Boton.ClickEventHandler(this.Cancelar_EventoClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnActualizar.ImagenDesabilitado = null;
            this.btnActualizar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnActualizar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnActualizar.Location = new System.Drawing.Point(985, 138);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(13, 8, 13, 8);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(117, 26);
            this.btnActualizar.TabIndex = 11;
            this.btnActualizar.TamamoTexto = 8.25F;
            this.btnActualizar.TextoBoton = "Actualizar";
            this.btnActualizar.Tooltip = null;
            this.btnActualizar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnActualizar_EventoClick);
            // 
            // ctrlZona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlZona);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ctrlZona";
            this.Size = new System.Drawing.Size(1139, 472);
            this.Load += new System.EventHandler(this.ctrlZona_Load);
            this.gbBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZona)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.gbCreacion.ResumeLayout(false);
            this.gbCreacion.PerformLayout();
            this.gbEdicion.ResumeLayout(false);
            this.gbEdicion.PerformLayout();
            this.pnlZona.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.GroupBox gbCreacion;
        private System.Windows.Forms.GroupBox gbEdicion;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblZonaBusqueda;
        private System.Windows.Forms.TextBox txtZonaBusqueda;
        private Controles.Boton BtnBuscar;
        private Controles.Boton btnLimpiar;
        private System.Windows.Forms.DataGridView dgvZona;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtZona;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcionEdicion;
        private System.Windows.Forms.TextBox txtZonaEdicion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Controles.Boton btnGuardar;
        private Controles.Boton btnActualizar;
        private Controles.Boton btnCancelar;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdZona;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private Controles.Boton btnImportarExcel;
        private System.Windows.Forms.Panel pnlZona;
        private Controles.Boton BtnExportar;
    }
}

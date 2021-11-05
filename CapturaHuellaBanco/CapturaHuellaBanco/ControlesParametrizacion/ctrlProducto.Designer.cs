namespace CapturaHuellaBanco.ControlesParametrizacion
{
    partial class ctrlProducto
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
            this.gbEdicion = new System.Windows.Forms.GroupBox();
            this.txtDescripcionEdicion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancelar = new Controles.Boton();
            this.btnActualizar = new Controles.Boton();
            this.chbHabilitadoEdicion = new System.Windows.Forms.CheckBox();
            this.txtCodigoEdicion = new System.Windows.Forms.TextBox();
            this.cbxServicioEdicion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbCreacion = new System.Windows.Forms.GroupBox();
            this.btnImportarExcel = new Controles.Boton();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGuardar = new Controles.Boton();
            this.chbHabilitado = new System.Windows.Forms.CheckBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cbxServicio = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.dgvProducto = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.ProductoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.cbxServicioBusqueda = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new Controles.Boton();
            this.BtnBuscar = new Controles.Boton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblZonaBusqueda = new System.Windows.Forms.Label();
            this.txtProductoBusqueda = new System.Windows.Forms.TextBox();
            this.pnlProductos = new System.Windows.Forms.Panel();
            this.BtnExportar = new Controles.Boton();
            this.gbEdicion.SuspendLayout();
            this.gbCreacion.SuspendLayout();
            this.gbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.pnlProductos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEdicion
            // 
            this.gbEdicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbEdicion.Controls.Add(this.txtDescripcionEdicion);
            this.gbEdicion.Controls.Add(this.label9);
            this.gbEdicion.Controls.Add(this.btnCancelar);
            this.gbEdicion.Controls.Add(this.btnActualizar);
            this.gbEdicion.Controls.Add(this.chbHabilitadoEdicion);
            this.gbEdicion.Controls.Add(this.txtCodigoEdicion);
            this.gbEdicion.Controls.Add(this.cbxServicioEdicion);
            this.gbEdicion.Controls.Add(this.label4);
            this.gbEdicion.Controls.Add(this.label3);
            this.gbEdicion.Controls.Add(this.label2);
            this.gbEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbEdicion.ForeColor = System.Drawing.Color.DimGray;
            this.gbEdicion.Location = new System.Drawing.Point(14, 273);
            this.gbEdicion.Name = "gbEdicion";
            this.gbEdicion.Size = new System.Drawing.Size(1110, 174);
            this.gbEdicion.TabIndex = 6;
            this.gbEdicion.TabStop = false;
            this.gbEdicion.Text = "Edición";
            this.gbEdicion.Visible = false;
            this.gbEdicion.Leave += new System.EventHandler(this.gbEdicion_Leave);
            // 
            // txtDescripcionEdicion
            // 
            this.txtDescripcionEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtDescripcionEdicion.Location = new System.Drawing.Point(140, 77);
            this.txtDescripcionEdicion.MaxLength = 100;
            this.txtDescripcionEdicion.Multiline = true;
            this.txtDescripcionEdicion.Name = "txtDescripcionEdicion";
            this.txtDescripcionEdicion.Size = new System.Drawing.Size(818, 73);
            this.txtDescripcionEdicion.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "Descripción:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            this.btnCancelar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnCancelar.ImagenDesabilitado = null;
            this.btnCancelar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnCancelar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnCancelar.Location = new System.Drawing.Point(981, 109);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(62, 21, 62, 21);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 26);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.TamamoTexto = 8.25F;
            this.btnCancelar.TextoBoton = "Cancelar";
            this.btnCancelar.Tooltip = null;
            this.btnCancelar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnCancelar_EventoClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            this.btnActualizar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnActualizar.ImagenDesabilitado = null;
            this.btnActualizar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnActualizar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnActualizar.Location = new System.Drawing.Point(981, 138);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(172, 40, 172, 40);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(117, 26);
            this.btnActualizar.TabIndex = 16;
            this.btnActualizar.TamamoTexto = 8.25F;
            this.btnActualizar.TextoBoton = "Actualizar";
            this.btnActualizar.Tooltip = null;
            this.btnActualizar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnActualizar_EventoClick);
            // 
            // chbHabilitadoEdicion
            // 
            this.chbHabilitadoEdicion.AutoSize = true;
            this.chbHabilitadoEdicion.Location = new System.Drawing.Point(703, 43);
            this.chbHabilitadoEdicion.Name = "chbHabilitadoEdicion";
            this.chbHabilitadoEdicion.Size = new System.Drawing.Size(15, 14);
            this.chbHabilitadoEdicion.TabIndex = 14;
            this.chbHabilitadoEdicion.UseVisualStyleBackColor = true;
            // 
            // txtCodigoEdicion
            // 
            this.txtCodigoEdicion.Enabled = false;
            this.txtCodigoEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtCodigoEdicion.Location = new System.Drawing.Point(140, 41);
            this.txtCodigoEdicion.MaxLength = 20;
            this.txtCodigoEdicion.Name = "txtCodigoEdicion";
            this.txtCodigoEdicion.Size = new System.Drawing.Size(448, 21);
            this.txtCodigoEdicion.TabIndex = 11;
            // 
            // cbxServicioEdicion
            // 
            this.cbxServicioEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cbxServicioEdicion.FormattingEnabled = true;
            this.cbxServicioEdicion.Location = new System.Drawing.Point(677, 12);
            this.cbxServicioEdicion.Name = "cbxServicioEdicion";
            this.cbxServicioEdicion.Size = new System.Drawing.Size(448, 23);
            this.cbxServicioEdicion.TabIndex = 13;
            this.cbxServicioEdicion.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(594, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Habilitado :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(597, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Servicio:";
            this.label2.Visible = false;
            // 
            // gbCreacion
            // 
            this.gbCreacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbCreacion.Controls.Add(this.btnImportarExcel);
            this.gbCreacion.Controls.Add(this.txtDescripcion);
            this.gbCreacion.Controls.Add(this.label8);
            this.gbCreacion.Controls.Add(this.btnGuardar);
            this.gbCreacion.Controls.Add(this.chbHabilitado);
            this.gbCreacion.Controls.Add(this.txtCodigo);
            this.gbCreacion.Controls.Add(this.cbxServicio);
            this.gbCreacion.Controls.Add(this.label5);
            this.gbCreacion.Controls.Add(this.label6);
            this.gbCreacion.Controls.Add(this.label7);
            this.gbCreacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbCreacion.ForeColor = System.Drawing.Color.DimGray;
            this.gbCreacion.Location = new System.Drawing.Point(14, 273);
            this.gbCreacion.Name = "gbCreacion";
            this.gbCreacion.Size = new System.Drawing.Size(1110, 174);
            this.gbCreacion.TabIndex = 5;
            this.gbCreacion.TabStop = false;
            this.gbCreacion.Text = "Creación";
            this.gbCreacion.Leave += new System.EventHandler(this.gbCreacion_Leave);
            // 
            // btnImportarExcel
            // 
            this.btnImportarExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnImportarExcel.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnImportarExcel.ImagenDesabilitado = null;
            this.btnImportarExcel.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnImportarExcel.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnImportarExcel.Location = new System.Drawing.Point(981, 109);
            this.btnImportarExcel.Margin = new System.Windows.Forms.Padding(22, 11, 22, 11);
            this.btnImportarExcel.Name = "btnImportarExcel";
            this.btnImportarExcel.Size = new System.Drawing.Size(117, 26);
            this.btnImportarExcel.TabIndex = 32;
            this.btnImportarExcel.TamamoTexto = 8.25F;
            this.btnImportarExcel.TextoBoton = "Importar Excel";
            this.btnImportarExcel.Tooltip = null;
            this.btnImportarExcel.EventoClick += new Controles.Boton.ClickEventHandler(this.btnImportarExcel_EventoClick);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtDescripcion.Location = new System.Drawing.Point(140, 77);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(818, 73);
            this.txtDescripcion.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 18);
            this.label8.TabIndex = 31;
            this.label8.Text = "Descripción:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            this.btnGuardar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnGuardar.ImagenDesabilitado = null;
            this.btnGuardar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnGuardar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnGuardar.Location = new System.Drawing.Point(981, 138);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(62, 21, 62, 21);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 26);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.TamamoTexto = 8.25F;
            this.btnGuardar.TextoBoton = "Guardar";
            this.btnGuardar.Tooltip = null;
            this.btnGuardar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnGuardar_EventoClick);
            // 
            // chbHabilitado
            // 
            this.chbHabilitado.AutoSize = true;
            this.chbHabilitado.Location = new System.Drawing.Point(703, 43);
            this.chbHabilitado.Name = "chbHabilitado";
            this.chbHabilitado.Size = new System.Drawing.Size(15, 14);
            this.chbHabilitado.TabIndex = 9;
            this.chbHabilitado.UseVisualStyleBackColor = true;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtCodigo.Location = new System.Drawing.Point(140, 41);
            this.txtCodigo.MaxLength = 20;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(448, 21);
            this.txtCodigo.TabIndex = 6;
            // 
            // cbxServicio
            // 
            this.cbxServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cbxServicio.FormattingEnabled = true;
            this.cbxServicio.Location = new System.Drawing.Point(662, 12);
            this.cbxServicio.Name = "cbxServicio";
            this.cbxServicio.Size = new System.Drawing.Size(317, 23);
            this.cbxServicio.TabIndex = 8;
            this.cbxServicio.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(594, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Habilitado :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "Código:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(582, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Servicio:";
            this.label7.Visible = false;
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbBusqueda.Controls.Add(this.dgvProducto);
            this.gbBusqueda.Controls.Add(this.pnlFiltros);
            this.gbBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbBusqueda.ForeColor = System.Drawing.Color.DimGray;
            this.gbBusqueda.Location = new System.Drawing.Point(14, 10);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(1110, 260);
            this.gbBusqueda.TabIndex = 4;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Búsqueda";
            // 
            // dgvProducto
            // 
            this.dgvProducto.AllowUserToAddRows = false;
            this.dgvProducto.AllowUserToDeleteRows = false;
            this.dgvProducto.AllowUserToOrderColumns = true;
            this.dgvProducto.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducto.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProducto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.ProductoId,
            this.Codigo,
            this.IdServicio,
            this.Servicio,
            this.Descripcion,
            this.Habilitado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducto.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProducto.EnableHeadersVisualStyles = false;
            this.dgvProducto.GridColor = System.Drawing.Color.White;
            this.dgvProducto.Location = new System.Drawing.Point(9, 94);
            this.dgvProducto.MultiSelect = false;
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProducto.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dgvProducto.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducto.Size = new System.Drawing.Size(1094, 160);
            this.dgvProducto.TabIndex = 5;
            this.dgvProducto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducto_CellContentClick);
            // 
            // Editar
            // 
            this.Editar.FillWeight = 60.9137F;
            this.Editar.HeaderText = "Editar";
            this.Editar.Image = global::CapturaHuellaBanco.Properties.Resources.Edit_Azul;
            this.Editar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ProductoId
            // 
            this.ProductoId.DataPropertyName = "IdProducto";
            this.ProductoId.HeaderText = "IdProducto";
            this.ProductoId.Name = "ProductoId";
            this.ProductoId.ReadOnly = true;
            this.ProductoId.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.FillWeight = 133.5552F;
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // IdServicio
            // 
            this.IdServicio.DataPropertyName = "IdServicio";
            this.IdServicio.HeaderText = "IdServicio";
            this.IdServicio.Name = "IdServicio";
            this.IdServicio.ReadOnly = true;
            this.IdServicio.Visible = false;
            // 
            // Servicio
            // 
            this.Servicio.DataPropertyName = "Servicio";
            this.Servicio.FillWeight = 133.5552F;
            this.Servicio.HeaderText = "Servicio";
            this.Servicio.Name = "Servicio";
            this.Servicio.ReadOnly = true;
            this.Servicio.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Habilitado
            // 
            this.Habilitado.DataPropertyName = "Habilitado";
            this.Habilitado.FillWeight = 71.97586F;
            this.Habilitado.HeaderText = "Habilitado";
            this.Habilitado.Name = "Habilitado";
            this.Habilitado.ReadOnly = true;
            this.Habilitado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Habilitado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.Controls.Add(this.BtnExportar);
            this.pnlFiltros.Controls.Add(this.cbxServicioBusqueda);
            this.pnlFiltros.Controls.Add(this.label1);
            this.pnlFiltros.Controls.Add(this.btnLimpiar);
            this.pnlFiltros.Controls.Add(this.BtnBuscar);
            this.pnlFiltros.Controls.Add(this.textBox1);
            this.pnlFiltros.Controls.Add(this.lblZonaBusqueda);
            this.pnlFiltros.Controls.Add(this.txtProductoBusqueda);
            this.pnlFiltros.Location = new System.Drawing.Point(9, 20);
            this.pnlFiltros.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1094, 71);
            this.pnlFiltros.TabIndex = 56;
            // 
            // cbxServicioBusqueda
            // 
            this.cbxServicioBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cbxServicioBusqueda.FormattingEnabled = true;
            this.cbxServicioBusqueda.Location = new System.Drawing.Point(165, 42);
            this.cbxServicioBusqueda.Name = "cbxServicioBusqueda";
            this.cbxServicioBusqueda.Size = new System.Drawing.Size(135, 23);
            this.cbxServicioBusqueda.TabIndex = 2;
            this.cbxServicioBusqueda.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Código:";
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
            this.btnLimpiar.TabIndex = 4;
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
            this.BtnBuscar.Location = new System.Drawing.Point(712, 33);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(117, 27);
            this.BtnBuscar.TabIndex = 3;
            this.BtnBuscar.TamamoTexto = 8.25F;
            this.BtnBuscar.TextoBoton = "";
            this.BtnBuscar.Tooltip = null;
            this.BtnBuscar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnBuscar_EventoClick);
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
            this.lblZonaBusqueda.Location = new System.Drawing.Point(162, 28);
            this.lblZonaBusqueda.Name = "lblZonaBusqueda";
            this.lblZonaBusqueda.Size = new System.Drawing.Size(50, 13);
            this.lblZonaBusqueda.TabIndex = 45;
            this.lblZonaBusqueda.Text = "Servicio:";
            this.lblZonaBusqueda.Visible = false;
            // 
            // txtProductoBusqueda
            // 
            this.txtProductoBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductoBusqueda.Location = new System.Drawing.Point(14, 44);
            this.txtProductoBusqueda.MaxLength = 20;
            this.txtProductoBusqueda.Name = "txtProductoBusqueda";
            this.txtProductoBusqueda.Size = new System.Drawing.Size(135, 21);
            this.txtProductoBusqueda.TabIndex = 1;
            // 
            // pnlProductos
            // 
            this.pnlProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProductos.Controls.Add(this.gbBusqueda);
            this.pnlProductos.Controls.Add(this.gbCreacion);
            this.pnlProductos.Controls.Add(this.gbEdicion);
            this.pnlProductos.Location = new System.Drawing.Point(0, 0);
            this.pnlProductos.Name = "pnlProductos";
            this.pnlProductos.Size = new System.Drawing.Size(1139, 472);
            this.pnlProductos.TabIndex = 7;
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
            this.BtnExportar.Location = new System.Drawing.Point(842, 33);
            this.BtnExportar.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(117, 27);
            this.BtnExportar.TabIndex = 74;
            this.BtnExportar.TamamoTexto = 8.25F;
            this.BtnExportar.TextoBoton = "";
            this.BtnExportar.Tooltip = null;
            this.BtnExportar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnExportar_EventoClick);
            // 
            // ctrlProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlProductos);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ctrlProducto";
            this.Size = new System.Drawing.Size(1139, 472);
            this.Load += new System.EventHandler(this.ctrlProducto_Load);
            this.gbEdicion.ResumeLayout(false);
            this.gbEdicion.PerformLayout();
            this.gbCreacion.ResumeLayout(false);
            this.gbCreacion.PerformLayout();
            this.gbBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlProductos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEdicion;
        private System.Windows.Forms.GroupBox gbCreacion;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.CheckBox chbHabilitadoEdicion;
        private System.Windows.Forms.TextBox txtCodigoEdicion;
        private System.Windows.Forms.ComboBox cbxServicioEdicion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvProducto;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label label1;
        private Controles.Boton btnLimpiar;
        private Controles.Boton BtnBuscar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblZonaBusqueda;
        private System.Windows.Forms.TextBox txtProductoBusqueda;
        private System.Windows.Forms.CheckBox chbHabilitado;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ComboBox cbxServicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxServicioBusqueda;
        private Controles.Boton btnActualizar;
        private Controles.Boton btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private Controles.Boton btnCancelar;
        private System.Windows.Forms.TextBox txtDescripcionEdicion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Habilitado;
        private System.Windows.Forms.Panel pnlProductos;
        private Controles.Boton btnImportarExcel;
        private Controles.Boton BtnExportar;
    }
}

namespace CapturaHuellaBanco.ControlesParametrizacion
{
    partial class ctrlOficina
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
            this.txtCodigoEdicion = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCancelar = new Controles.Boton();
            this.btnActualizar = new Controles.Boton();
            this.chbHabilitadoEdicion = new System.Windows.Forms.CheckBox();
            this.txtCiudadEdicion = new System.Windows.Forms.TextBox();
            this.txtDireccionEdicion = new System.Windows.Forms.TextBox();
            this.txtOficinaEdicion = new System.Windows.Forms.TextBox();
            this.cbxZonaEdicion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbCreacion = new System.Windows.Forms.GroupBox();
            this.btnImportarExcel = new Controles.Boton();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGuardar = new Controles.Boton();
            this.chbHabilitado = new System.Windows.Forms.CheckBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtOficina = new System.Windows.Forms.TextBox();
            this.cbxZona = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.dgvOficina = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.IdOficina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdZona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.cbxZonaBusqueda = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOficinaBusqueda = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new Controles.Boton();
            this.BtnBuscar = new Controles.Boton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblZonaBusqueda = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlOficina = new System.Windows.Forms.Panel();
            this.BtnExportar = new Controles.Boton();
            this.gbEdicion.SuspendLayout();
            this.gbCreacion.SuspendLayout();
            this.gbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOficina)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.pnlOficina.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEdicion
            // 
            this.gbEdicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbEdicion.Controls.Add(this.txtCodigoEdicion);
            this.gbEdicion.Controls.Add(this.label12);
            this.gbEdicion.Controls.Add(this.btnCancelar);
            this.gbEdicion.Controls.Add(this.btnActualizar);
            this.gbEdicion.Controls.Add(this.chbHabilitadoEdicion);
            this.gbEdicion.Controls.Add(this.txtCiudadEdicion);
            this.gbEdicion.Controls.Add(this.txtDireccionEdicion);
            this.gbEdicion.Controls.Add(this.txtOficinaEdicion);
            this.gbEdicion.Controls.Add(this.cbxZonaEdicion);
            this.gbEdicion.Controls.Add(this.label6);
            this.gbEdicion.Controls.Add(this.label5);
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
            // txtCodigoEdicion
            // 
            this.txtCodigoEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtCodigoEdicion.Location = new System.Drawing.Point(653, 32);
            this.txtCodigoEdicion.MaxLength = 50;
            this.txtCodigoEdicion.Name = "txtCodigoEdicion";
            this.txtCodigoEdicion.Size = new System.Drawing.Size(328, 21);
            this.txtCodigoEdicion.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(536, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 18);
            this.label12.TabIndex = 12;
            this.label12.Text = "Código:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            this.btnCancelar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnCancelar.ImagenDesabilitado = null;
            this.btnCancelar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnCancelar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnCancelar.Location = new System.Drawing.Point(985, 108);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(37, 15, 37, 15);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 26);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.TamamoTexto = 8.25F;
            this.btnCancelar.TextoBoton = "Cancelar";
            this.btnCancelar.Tooltip = null;
            this.btnCancelar.EventoClick += new Controles.Boton.ClickEventHandler(this.Cancelar_EventoClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            this.btnActualizar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnActualizar.ImagenDesabilitado = null;
            this.btnActualizar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnActualizar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnActualizar.Location = new System.Drawing.Point(985, 138);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(22, 11, 22, 11);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(117, 26);
            this.btnActualizar.TabIndex = 19;
            this.btnActualizar.TamamoTexto = 8.25F;
            this.btnActualizar.TextoBoton = "Actualizar";
            this.btnActualizar.Tooltip = null;
            this.btnActualizar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnActualizar_EventoClick);
            // 
            // chbHabilitadoEdicion
            // 
            this.chbHabilitadoEdicion.AutoSize = true;
            this.chbHabilitadoEdicion.Location = new System.Drawing.Point(653, 140);
            this.chbHabilitadoEdicion.Name = "chbHabilitadoEdicion";
            this.chbHabilitadoEdicion.Size = new System.Drawing.Size(15, 14);
            this.chbHabilitadoEdicion.TabIndex = 17;
            this.chbHabilitadoEdicion.UseVisualStyleBackColor = true;
            // 
            // txtCiudadEdicion
            // 
            this.txtCiudadEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtCiudadEdicion.Location = new System.Drawing.Point(653, 83);
            this.txtCiudadEdicion.MaxLength = 50;
            this.txtCiudadEdicion.Name = "txtCiudadEdicion";
            this.txtCiudadEdicion.Size = new System.Drawing.Size(328, 21);
            this.txtCiudadEdicion.TabIndex = 15;
            // 
            // txtDireccionEdicion
            // 
            this.txtDireccionEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtDireccionEdicion.Location = new System.Drawing.Point(144, 135);
            this.txtDireccionEdicion.MaxLength = 100;
            this.txtDireccionEdicion.Name = "txtDireccionEdicion";
            this.txtDireccionEdicion.Size = new System.Drawing.Size(328, 21);
            this.txtDireccionEdicion.TabIndex = 16;
            // 
            // txtOficinaEdicion
            // 
            this.txtOficinaEdicion.Enabled = false;
            this.txtOficinaEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtOficinaEdicion.Location = new System.Drawing.Point(145, 32);
            this.txtOficinaEdicion.MaxLength = 100;
            this.txtOficinaEdicion.Name = "txtOficinaEdicion";
            this.txtOficinaEdicion.Size = new System.Drawing.Size(328, 21);
            this.txtOficinaEdicion.TabIndex = 12;
            // 
            // cbxZonaEdicion
            // 
            this.cbxZonaEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cbxZonaEdicion.FormattingEnabled = true;
            this.cbxZonaEdicion.Location = new System.Drawing.Point(145, 83);
            this.cbxZonaEdicion.Name = "cbxZonaEdicion";
            this.cbxZonaEdicion.Size = new System.Drawing.Size(328, 23);
            this.cbxZonaEdicion.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(536, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Habilitado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(536, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ciudad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Dirección:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Zona:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Oficina:";
            // 
            // gbCreacion
            // 
            this.gbCreacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbCreacion.Controls.Add(this.btnImportarExcel);
            this.gbCreacion.Controls.Add(this.txtCodigo);
            this.gbCreacion.Controls.Add(this.label13);
            this.gbCreacion.Controls.Add(this.btnGuardar);
            this.gbCreacion.Controls.Add(this.chbHabilitado);
            this.gbCreacion.Controls.Add(this.txtCiudad);
            this.gbCreacion.Controls.Add(this.txtDireccion);
            this.gbCreacion.Controls.Add(this.txtOficina);
            this.gbCreacion.Controls.Add(this.cbxZona);
            this.gbCreacion.Controls.Add(this.label7);
            this.gbCreacion.Controls.Add(this.label8);
            this.gbCreacion.Controls.Add(this.label9);
            this.gbCreacion.Controls.Add(this.label10);
            this.gbCreacion.Controls.Add(this.label11);
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
            this.btnImportarExcel.Location = new System.Drawing.Point(985, 108);
            this.btnImportarExcel.Margin = new System.Windows.Forms.Padding(13, 8, 13, 8);
            this.btnImportarExcel.Name = "btnImportarExcel";
            this.btnImportarExcel.Size = new System.Drawing.Size(117, 26);
            this.btnImportarExcel.TabIndex = 22;
            this.btnImportarExcel.TamamoTexto = 8.25F;
            this.btnImportarExcel.TextoBoton = "Importar Excel";
            this.btnImportarExcel.Tooltip = null;
            this.btnImportarExcel.EventoClick += new Controles.Boton.ClickEventHandler(this.btnImportarExcel_EventoClick);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtCodigo.Location = new System.Drawing.Point(653, 32);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(328, 21);
            this.txtCodigo.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(536, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 18);
            this.label13.TabIndex = 21;
            this.label13.Text = "Código:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            this.btnGuardar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnGuardar.ImagenDesabilitado = null;
            this.btnGuardar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnGuardar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnGuardar.Location = new System.Drawing.Point(985, 138);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 26);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.TamamoTexto = 8.25F;
            this.btnGuardar.TextoBoton = "   Guardar";
            this.btnGuardar.Tooltip = null;
            this.btnGuardar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnGuardar_EventoClick);
            // 
            // chbHabilitado
            // 
            this.chbHabilitado.AutoSize = true;
            this.chbHabilitado.Location = new System.Drawing.Point(653, 140);
            this.chbHabilitado.Name = "chbHabilitado";
            this.chbHabilitado.Size = new System.Drawing.Size(15, 14);
            this.chbHabilitado.TabIndex = 10;
            this.chbHabilitado.UseVisualStyleBackColor = true;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtCiudad.Location = new System.Drawing.Point(653, 83);
            this.txtCiudad.MaxLength = 50;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(328, 21);
            this.txtCiudad.TabIndex = 8;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtDireccion.Location = new System.Drawing.Point(145, 135);
            this.txtDireccion.MaxLength = 100;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(328, 21);
            this.txtDireccion.TabIndex = 9;
            // 
            // txtOficina
            // 
            this.txtOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtOficina.Location = new System.Drawing.Point(145, 32);
            this.txtOficina.MaxLength = 100;
            this.txtOficina.Name = "txtOficina";
            this.txtOficina.Size = new System.Drawing.Size(328, 21);
            this.txtOficina.TabIndex = 5;
            // 
            // cbxZona
            // 
            this.cbxZona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cbxZona.FormattingEnabled = true;
            this.cbxZona.Location = new System.Drawing.Point(145, 83);
            this.cbxZona.Name = "cbxZona";
            this.cbxZona.Size = new System.Drawing.Size(328, 23);
            this.cbxZona.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(536, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Habilitado:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(536, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "Ciudad:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 18);
            this.label9.TabIndex = 12;
            this.label9.Text = "Dirección:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 18);
            this.label10.TabIndex = 11;
            this.label10.Text = "Zona:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 18);
            this.label11.TabIndex = 10;
            this.label11.Text = "Oficina:";
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbBusqueda.Controls.Add(this.dgvOficina);
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
            // dgvOficina
            // 
            this.dgvOficina.AllowUserToAddRows = false;
            this.dgvOficina.AllowUserToDeleteRows = false;
            this.dgvOficina.AllowUserToOrderColumns = true;
            this.dgvOficina.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvOficina.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOficina.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOficina.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOficina.BackgroundColor = System.Drawing.Color.White;
            this.dgvOficina.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOficina.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOficina.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOficina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOficina.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.IdOficina,
            this.IdZona,
            this.Direccion,
            this.Codigo,
            this.Ciudad,
            this.Habilitado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOficina.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOficina.EnableHeadersVisualStyles = false;
            this.dgvOficina.GridColor = System.Drawing.Color.White;
            this.dgvOficina.Location = new System.Drawing.Point(8, 92);
            this.dgvOficina.MultiSelect = false;
            this.dgvOficina.Name = "dgvOficina";
            this.dgvOficina.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOficina.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOficina.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dgvOficina.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOficina.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOficina.Size = new System.Drawing.Size(1094, 160);
            this.dgvOficina.TabIndex = 4;
            this.dgvOficina.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOficina_CellContentClick);
            // 
            // Editar
            // 
            this.Editar.FillWeight = 91.37056F;
            this.Editar.HeaderText = "Editar";
            this.Editar.Image = global::CapturaHuellaBanco.Properties.Resources.Edit_Azul;
            this.Editar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            // 
            // IdOficina
            // 
            this.IdOficina.DataPropertyName = "IdOficina";
            this.IdOficina.HeaderText = "Oficina";
            this.IdOficina.Name = "IdOficina";
            this.IdOficina.ReadOnly = true;
            // 
            // IdZona
            // 
            this.IdZona.DataPropertyName = "IdZona";
            this.IdZona.FillWeight = 103.7484F;
            this.IdZona.HeaderText = "Zona";
            this.IdZona.Name = "IdZona";
            this.IdZona.ReadOnly = true;
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "Direccion";
            this.Direccion.FillWeight = 103.7484F;
            this.Direccion.HeaderText = "Dirección";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Ciudad
            // 
            this.Ciudad.DataPropertyName = "Ciudad";
            this.Ciudad.FillWeight = 103.7484F;
            this.Ciudad.HeaderText = "Ciudad";
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.ReadOnly = true;
            // 
            // Habilitado
            // 
            this.Habilitado.DataPropertyName = "Habilitado";
            this.Habilitado.FillWeight = 93.63586F;
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
            this.pnlFiltros.Controls.Add(this.cbxZonaBusqueda);
            this.pnlFiltros.Controls.Add(this.label1);
            this.pnlFiltros.Controls.Add(this.txtOficinaBusqueda);
            this.pnlFiltros.Controls.Add(this.btnLimpiar);
            this.pnlFiltros.Controls.Add(this.BtnBuscar);
            this.pnlFiltros.Controls.Add(this.textBox1);
            this.pnlFiltros.Controls.Add(this.lblZonaBusqueda);
            this.pnlFiltros.Location = new System.Drawing.Point(8, 18);
            this.pnlFiltros.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1094, 71);
            this.pnlFiltros.TabIndex = 50;
            // 
            // cbxZonaBusqueda
            // 
            this.cbxZonaBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cbxZonaBusqueda.FormattingEnabled = true;
            this.cbxZonaBusqueda.Location = new System.Drawing.Point(13, 42);
            this.cbxZonaBusqueda.Name = "cbxZonaBusqueda";
            this.cbxZonaBusqueda.Size = new System.Drawing.Size(135, 23);
            this.cbxZonaBusqueda.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(162, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Oficina:";
            // 
            // txtOficinaBusqueda
            // 
            this.txtOficinaBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOficinaBusqueda.Location = new System.Drawing.Point(165, 44);
            this.txtOficinaBusqueda.MaxLength = 100;
            this.txtOficinaBusqueda.Name = "txtOficinaBusqueda";
            this.txtOficinaBusqueda.Size = new System.Drawing.Size(135, 21);
            this.txtOficinaBusqueda.TabIndex = 1;
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
            this.BtnBuscar.Location = new System.Drawing.Point(712, 33);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(117, 27);
            this.BtnBuscar.TabIndex = 2;
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
            this.lblZonaBusqueda.Location = new System.Drawing.Point(11, 28);
            this.lblZonaBusqueda.Name = "lblZonaBusqueda";
            this.lblZonaBusqueda.Size = new System.Drawing.Size(37, 13);
            this.lblZonaBusqueda.TabIndex = 45;
            this.lblZonaBusqueda.Text = "Zona:";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 91.37056F;
            this.dataGridViewImageColumn1.HeaderText = "Editar";
            this.dataGridViewImageColumn1.Image = global::CapturaHuellaBanco.Properties.Resources.Edit_Azul;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 166;
            // 
            // pnlOficina
            // 
            this.pnlOficina.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOficina.Controls.Add(this.gbBusqueda);
            this.pnlOficina.Controls.Add(this.gbCreacion);
            this.pnlOficina.Controls.Add(this.gbEdicion);
            this.pnlOficina.Location = new System.Drawing.Point(0, 0);
            this.pnlOficina.Name = "pnlOficina";
            this.pnlOficina.Size = new System.Drawing.Size(1139, 472);
            this.pnlOficina.TabIndex = 7;
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
            // ctrlOficina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlOficina);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ctrlOficina";
            this.Size = new System.Drawing.Size(1139, 472);
            this.Load += new System.EventHandler(this.ctrlOficina_Load);
            this.gbEdicion.ResumeLayout(false);
            this.gbEdicion.PerformLayout();
            this.gbCreacion.ResumeLayout(false);
            this.gbCreacion.PerformLayout();
            this.gbBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOficina)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlOficina.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEdicion;
        private System.Windows.Forms.GroupBox gbCreacion;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.CheckBox chbHabilitado;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtOficina;
        private System.Windows.Forms.ComboBox cbxZona;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvOficina;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOficinaBusqueda;
        private Controles.Boton btnLimpiar;
        private Controles.Boton BtnBuscar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblZonaBusqueda;
        private Controles.Boton btnGuardar;
        private System.Windows.Forms.ComboBox cbxZonaBusqueda;
        private System.Windows.Forms.CheckBox chbHabilitadoEdicion;
        private System.Windows.Forms.TextBox txtCiudadEdicion;
        private System.Windows.Forms.TextBox txtDireccionEdicion;
        private System.Windows.Forms.TextBox txtOficinaEdicion;
        private System.Windows.Forms.ComboBox cbxZonaEdicion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Controles.Boton btnActualizar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Controles.Boton btnCancelar;
        private System.Windows.Forms.TextBox txtCodigoEdicion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOficina;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdZona;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Habilitado;
        private System.Windows.Forms.Panel pnlOficina;
        private Controles.Boton btnImportarExcel;
        private Controles.Boton BtnExportar;
    }
}

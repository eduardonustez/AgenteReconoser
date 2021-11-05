namespace CapturaHuellaBanco.ControlesParametrizacion
{
    partial class ctrlServicio
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
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelar = new Controles.Boton();
            this.btnActualizar = new Controles.Boton();
            this.chbHabilitadoEdicion = new System.Windows.Forms.CheckBox();
            this.txtCodigoEdicion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbCreacion = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGuardar = new Controles.Boton();
            this.chbHabilitado = new System.Windows.Forms.CheckBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.dgvServicio = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.IdServico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new Controles.Boton();
            this.BtnBuscar = new Controles.Boton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCodigoBusqueda = new System.Windows.Forms.TextBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.gbEdicion.SuspendLayout();
            this.gbCreacion.SuspendLayout();
            this.gbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicio)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEdicion
            // 
            this.gbEdicion.Controls.Add(this.txtDescripcionEdicion);
            this.gbEdicion.Controls.Add(this.label6);
            this.gbEdicion.Controls.Add(this.btnCancelar);
            this.gbEdicion.Controls.Add(this.btnActualizar);
            this.gbEdicion.Controls.Add(this.chbHabilitadoEdicion);
            this.gbEdicion.Controls.Add(this.txtCodigoEdicion);
            this.gbEdicion.Controls.Add(this.label3);
            this.gbEdicion.Controls.Add(this.label2);
            this.gbEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbEdicion.ForeColor = System.Drawing.Color.DimGray;
            this.gbEdicion.Location = new System.Drawing.Point(14, 292);
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
            this.txtDescripcionEdicion.Location = new System.Drawing.Point(126, 81);
            this.txtDescripcionEdicion.Multiline = true;
            this.txtDescripcionEdicion.Name = "txtDescripcionEdicion";
            this.txtDescripcionEdicion.Size = new System.Drawing.Size(845, 83);
            this.txtDescripcionEdicion.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 18);
            this.label6.TabIndex = 17;
            this.label6.Text = "Descripción:";
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
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.TamamoTexto = 8.25F;
            this.btnCancelar.TextoBoton = "Cancelar";
            this.btnCancelar.Tooltip = null;
            this.btnCancelar.Load += new System.EventHandler(this.btnCancelar_Load);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            this.btnActualizar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnActualizar.ImagenDesabilitado = null;
            this.btnActualizar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnActualizar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnActualizar.Location = new System.Drawing.Point(985, 138);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(103, 29, 103, 29);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(117, 26);
            this.btnActualizar.TabIndex = 14;
            this.btnActualizar.TamamoTexto = 8.25F;
            this.btnActualizar.TextoBoton = "Actualizar";
            this.btnActualizar.Tooltip = null;
            this.btnActualizar.UseWaitCursor = true;
            this.btnActualizar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnActualizar_EventoClick);
            // 
            // chbHabilitadoEdicion
            // 
            this.chbHabilitadoEdicion.AutoSize = true;
            this.chbHabilitadoEdicion.Location = new System.Drawing.Point(721, 41);
            this.chbHabilitadoEdicion.Name = "chbHabilitadoEdicion";
            this.chbHabilitadoEdicion.Size = new System.Drawing.Size(15, 14);
            this.chbHabilitadoEdicion.TabIndex = 11;
            this.chbHabilitadoEdicion.UseVisualStyleBackColor = true;
            // 
            // txtCodigoEdicion
            // 
            this.txtCodigoEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtCodigoEdicion.Location = new System.Drawing.Point(126, 38);
            this.txtCodigoEdicion.Name = "txtCodigoEdicion";
            this.txtCodigoEdicion.Size = new System.Drawing.Size(436, 21);
            this.txtCodigoEdicion.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(615, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Habilitado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Código:";
            // 
            // gbCreacion
            // 
            this.gbCreacion.Controls.Add(this.txtDescripcion);
            this.gbCreacion.Controls.Add(this.label7);
            this.gbCreacion.Controls.Add(this.btnGuardar);
            this.gbCreacion.Controls.Add(this.chbHabilitado);
            this.gbCreacion.Controls.Add(this.txtCodigo);
            this.gbCreacion.Controls.Add(this.label4);
            this.gbCreacion.Controls.Add(this.label5);
            this.gbCreacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbCreacion.ForeColor = System.Drawing.Color.DimGray;
            this.gbCreacion.Location = new System.Drawing.Point(14, 292);
            this.gbCreacion.Name = "gbCreacion";
            this.gbCreacion.Size = new System.Drawing.Size(1110, 174);
            this.gbCreacion.TabIndex = 5;
            this.gbCreacion.TabStop = false;
            this.gbCreacion.Text = "Creación";
            this.gbCreacion.Leave += new System.EventHandler(this.gbCreacion_Leave);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtDescripcion.Location = new System.Drawing.Point(126, 81);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(845, 83);
            this.txtDescripcion.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 18);
            this.label7.TabIndex = 30;
            this.label7.Text = "Descripción:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            this.btnGuardar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnGuardar.ImagenDesabilitado = null;
            this.btnGuardar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnGuardar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnGuardar.Location = new System.Drawing.Point(985, 138);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(37, 15, 37, 15);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 26);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.TamamoTexto = 8.25F;
            this.btnGuardar.TextoBoton = "Guardar";
            this.btnGuardar.Tooltip = null;
            this.btnGuardar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnGuardar_EventoClick);
            // 
            // chbHabilitado
            // 
            this.chbHabilitado.AutoSize = true;
            this.chbHabilitado.Location = new System.Drawing.Point(721, 41);
            this.chbHabilitado.Name = "chbHabilitado";
            this.chbHabilitado.Size = new System.Drawing.Size(15, 14);
            this.chbHabilitado.TabIndex = 6;
            this.chbHabilitado.UseVisualStyleBackColor = true;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtCodigo.Location = new System.Drawing.Point(126, 38);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(436, 21);
            this.txtCodigo.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(615, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Habilitado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Código:";
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.dgvServicio);
            this.gbBusqueda.Controls.Add(this.pnlFiltros);
            this.gbBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbBusqueda.ForeColor = System.Drawing.Color.DimGray;
            this.gbBusqueda.Location = new System.Drawing.Point(14, 6);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(1110, 280);
            this.gbBusqueda.TabIndex = 4;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Busqueda";
            // 
            // dgvServicio
            // 
            this.dgvServicio.AllowUserToAddRows = false;
            this.dgvServicio.AllowUserToDeleteRows = false;
            this.dgvServicio.AllowUserToOrderColumns = true;
            this.dgvServicio.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvServicio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServicio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicio.BackgroundColor = System.Drawing.Color.White;
            this.dgvServicio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvServicio.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.IdServico,
            this.Codigo,
            this.Descripcion,
            this.Habilitado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServicio.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvServicio.EnableHeadersVisualStyles = false;
            this.dgvServicio.GridColor = System.Drawing.Color.White;
            this.dgvServicio.Location = new System.Drawing.Point(9, 93);
            this.dgvServicio.MultiSelect = false;
            this.dgvServicio.Name = "dgvServicio";
            this.dgvServicio.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicio.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvServicio.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dgvServicio.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvServicio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicio.Size = new System.Drawing.Size(1094, 180);
            this.dgvServicio.TabIndex = 4;
            this.dgvServicio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicio_CellContentClick);
            // 
            // Editar
            // 
            this.Editar.FillWeight = 76.14214F;
            this.Editar.HeaderText = "Editar";
            this.Editar.Image = global::CapturaHuellaBanco.Properties.Resources.Edit_Azul;
            this.Editar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            // 
            // IdServico
            // 
            this.IdServico.DataPropertyName = "IdServico";
            this.IdServico.HeaderText = "IdServico ";
            this.IdServico.Name = "IdServico";
            this.IdServico.ReadOnly = true;
            this.IdServico.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.FillWeight = 167.0412F;
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
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
            this.Habilitado.FillWeight = 56.81672F;
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
            this.pnlFiltros.Controls.Add(this.label1);
            this.pnlFiltros.Controls.Add(this.btnLimpiar);
            this.pnlFiltros.Controls.Add(this.BtnBuscar);
            this.pnlFiltros.Controls.Add(this.textBox1);
            this.pnlFiltros.Controls.Add(this.txtCodigoBusqueda);
            this.pnlFiltros.Location = new System.Drawing.Point(9, 19);
            this.pnlFiltros.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1094, 71);
            this.pnlFiltros.TabIndex = 58;
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
            this.BtnBuscar.Location = new System.Drawing.Point(845, 33);
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
            this.textBox1.Text = "   FILTROS DE BUSQUEDA";
            // 
            // txtCodigoBusqueda
            // 
            this.txtCodigoBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBusqueda.Location = new System.Drawing.Point(14, 44);
            this.txtCodigoBusqueda.Name = "txtCodigoBusqueda";
            this.txtCodigoBusqueda.Size = new System.Drawing.Size(135, 21);
            this.txtCodigoBusqueda.TabIndex = 1;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 76.14214F;
            this.dataGridViewImageColumn1.HeaderText = "Editar";
            this.dataGridViewImageColumn1.Image = global::CapturaHuellaBanco.Properties.Resources.Edit_Azul;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 277;
            // 
            // ctrlServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.gbEdicion);
            this.Controls.Add(this.gbCreacion);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ctrlServicio";
            this.Size = new System.Drawing.Size(1139, 472);
            this.Load += new System.EventHandler(this.ctrlServicio_Load);
            this.gbEdicion.ResumeLayout(false);
            this.gbEdicion.PerformLayout();
            this.gbCreacion.ResumeLayout(false);
            this.gbCreacion.PerformLayout();
            this.gbBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicio)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEdicion;
        private System.Windows.Forms.GroupBox gbCreacion;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.CheckBox chbHabilitadoEdicion;
        private System.Windows.Forms.TextBox txtCodigoEdicion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvServicio;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label label1;
        private Controles.Boton btnLimpiar;
        private Controles.Boton BtnBuscar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtCodigoBusqueda;
        private System.Windows.Forms.CheckBox chbHabilitado;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Controles.Boton btnGuardar;
        private Controles.Boton btnActualizar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Controles.Boton btnCancelar;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdServico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Habilitado;
        private System.Windows.Forms.TextBox txtDescripcionEdicion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label7;
    }
}

namespace CapturaHuellaBanco.ControlesParametrizacion
{
    partial class ctrlParametros
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
            this.gbParametros = new System.Windows.Forms.GroupBox();
            this.dgvParametro = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Parametros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdParametros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbEdicion = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new Controles.Boton();
            this.btnActualizar = new Controles.Boton();
            this.txtValorEdicion = new System.Windows.Forms.TextBox();
            this.txtParametroEdicon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlParametros = new System.Windows.Forms.Panel();
            this.BtnExportar = new Controles.Boton();
            this.gbParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParametro)).BeginInit();
            this.gbEdicion.SuspendLayout();
            this.pnlParametros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbParametros
            // 
            this.gbParametros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbParametros.Controls.Add(this.BtnExportar);
            this.gbParametros.Controls.Add(this.dgvParametro);
            this.gbParametros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbParametros.ForeColor = System.Drawing.Color.DimGray;
            this.gbParametros.Location = new System.Drawing.Point(14, 10);
            this.gbParametros.Name = "gbParametros";
            this.gbParametros.Size = new System.Drawing.Size(1110, 330);
            this.gbParametros.TabIndex = 7;
            this.gbParametros.TabStop = false;
            this.gbParametros.Text = "Parámetros";
            // 
            // dgvParametro
            // 
            this.dgvParametro.AllowUserToAddRows = false;
            this.dgvParametro.AllowUserToDeleteRows = false;
            this.dgvParametro.AllowUserToOrderColumns = true;
            this.dgvParametro.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvParametro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvParametro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvParametro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParametro.BackgroundColor = System.Drawing.Color.White;
            this.dgvParametro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvParametro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParametro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvParametro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParametro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.Parametros,
            this.IdParametros,
            this.Valor,
            this.FechaModificacion,
            this.UsuarioModificacion});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParametro.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvParametro.EnableHeadersVisualStyles = false;
            this.dgvParametro.GridColor = System.Drawing.Color.White;
            this.dgvParametro.Location = new System.Drawing.Point(8, 41);
            this.dgvParametro.MultiSelect = false;
            this.dgvParametro.Name = "dgvParametro";
            this.dgvParametro.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParametro.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvParametro.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dgvParametro.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvParametro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParametro.Size = new System.Drawing.Size(1094, 282);
            this.dgvParametro.TabIndex = 1;
            this.dgvParametro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParametro_CellContentClick);
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
            // Parametros
            // 
            this.Parametros.DataPropertyName = "Parametro";
            this.Parametros.HeaderText = "Parámetro";
            this.Parametros.Name = "Parametros";
            this.Parametros.ReadOnly = true;
            // 
            // IdParametros
            // 
            this.IdParametros.DataPropertyName = "IdParametro";
            this.IdParametros.HeaderText = "IdParametro";
            this.IdParametros.Name = "IdParametros";
            this.IdParametros.ReadOnly = true;
            this.IdParametros.Visible = false;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            this.Valor.FillWeight = 103.7484F;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // FechaModificacion
            // 
            this.FechaModificacion.DataPropertyName = "FechaModificacion";
            this.FechaModificacion.FillWeight = 103.7484F;
            this.FechaModificacion.HeaderText = "Fecha de Modificación";
            this.FechaModificacion.Name = "FechaModificacion";
            this.FechaModificacion.ReadOnly = true;
            // 
            // UsuarioModificacion
            // 
            this.UsuarioModificacion.DataPropertyName = "UsuarioModificacion";
            this.UsuarioModificacion.FillWeight = 103.7484F;
            this.UsuarioModificacion.HeaderText = "Usuario de Modificación";
            this.UsuarioModificacion.Name = "UsuarioModificacion";
            this.UsuarioModificacion.ReadOnly = true;
            // 
            // gbEdicion
            // 
            this.gbEdicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbEdicion.Controls.Add(this.btnCancelar);
            this.gbEdicion.Controls.Add(this.btnActualizar);
            this.gbEdicion.Controls.Add(this.txtValorEdicion);
            this.gbEdicion.Controls.Add(this.txtParametroEdicon);
            this.gbEdicion.Controls.Add(this.label8);
            this.gbEdicion.Controls.Add(this.label11);
            this.gbEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbEdicion.ForeColor = System.Drawing.Color.DimGray;
            this.gbEdicion.Location = new System.Drawing.Point(14, 343);
            this.gbEdicion.Name = "gbEdicion";
            this.gbEdicion.Size = new System.Drawing.Size(1110, 107);
            this.gbEdicion.TabIndex = 8;
            this.gbEdicion.TabStop = false;
            this.gbEdicion.Text = "Edición";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(95)))));
            this.btnCancelar.Imagen = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnCancelar.ImagenDesabilitado = null;
            this.btnCancelar.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.btn_rojo;
            this.btnCancelar.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.btn_azul;
            this.btnCancelar.Location = new System.Drawing.Point(864, 67);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(62, 21, 62, 21);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 26);
            this.btnCancelar.TabIndex = 4;
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
            this.btnActualizar.Location = new System.Drawing.Point(985, 67);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(117, 26);
            this.btnActualizar.TabIndex = 20;
            this.btnActualizar.TamamoTexto = 8.25F;
            this.btnActualizar.TextoBoton = "Actualizar";
            this.btnActualizar.Tooltip = null;
            this.btnActualizar.EventoClick += new Controles.Boton.ClickEventHandler(this.btnActualizar_EventoClick);
            // 
            // txtValorEdicion
            // 
            this.txtValorEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtValorEdicion.Location = new System.Drawing.Point(629, 32);
            this.txtValorEdicion.Name = "txtValorEdicion";
            this.txtValorEdicion.Size = new System.Drawing.Size(328, 21);
            this.txtValorEdicion.TabIndex = 3;
            // 
            // txtParametroEdicon
            // 
            this.txtParametroEdicon.Enabled = false;
            this.txtParametroEdicon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtParametroEdicon.Location = new System.Drawing.Point(145, 32);
            this.txtParametroEdicon.MaxLength = 50;
            this.txtParametroEdicon.Name = "txtParametroEdicon";
            this.txtParametroEdicon.Size = new System.Drawing.Size(328, 21);
            this.txtParametroEdicon.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(536, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "Valor:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 18);
            this.label11.TabIndex = 10;
            this.label11.Text = "Parámetro:";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 91.37056F;
            this.dataGridViewImageColumn1.HeaderText = "Editar";
            this.dataGridViewImageColumn1.Image = global::CapturaHuellaBanco.Properties.Resources.Edit_Azul;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 167;
            // 
            // pnlParametros
            // 
            this.pnlParametros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlParametros.Controls.Add(this.gbEdicion);
            this.pnlParametros.Controls.Add(this.gbParametros);
            this.pnlParametros.Location = new System.Drawing.Point(0, 0);
            this.pnlParametros.Name = "pnlParametros";
            this.pnlParametros.Size = new System.Drawing.Size(1139, 472);
            this.pnlParametros.TabIndex = 9;
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
            this.BtnExportar.Location = new System.Drawing.Point(985, 13);
            this.BtnExportar.Margin = new System.Windows.Forms.Padding(13, 8, 13, 8);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(117, 26);
            this.BtnExportar.TabIndex = 75;
            this.BtnExportar.TamamoTexto = 8.25F;
            this.BtnExportar.TextoBoton = "";
            this.BtnExportar.Tooltip = null;
            this.BtnExportar.EventoClick += new Controles.Boton.ClickEventHandler(this.BtnExportar_EventoClick);
            // 
            // ctrlParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlParametros);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ctrlParametros";
            this.Size = new System.Drawing.Size(1139, 472);
            this.Load += new System.EventHandler(this.ctrlParametros_Load);
            this.gbParametros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParametro)).EndInit();
            this.gbEdicion.ResumeLayout(false);
            this.gbEdicion.PerformLayout();
            this.pnlParametros.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbParametros;
        private System.Windows.Forms.DataGridView dgvParametro;
        private System.Windows.Forms.GroupBox gbEdicion;
        private Controles.Boton btnActualizar;
        private System.Windows.Forms.TextBox txtValorEdicion;
        private System.Windows.Forms.TextBox txtParametroEdicon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Controles.Boton btnCancelar;
        private System.Windows.Forms.Panel pnlParametros;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parametros;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdParametros;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioModificacion;
        private Controles.Boton BtnExportar;
    }
}
 
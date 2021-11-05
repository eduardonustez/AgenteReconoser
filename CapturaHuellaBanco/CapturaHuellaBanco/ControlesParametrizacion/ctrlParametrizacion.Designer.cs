namespace CapturaHuellaBanco.ControlesParametrizacion
{
    partial class ctrlParametrizacion
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
            this.gbEmpresa = new System.Windows.Forms.GroupBox();
            this.lblOficina = new System.Windows.Forms.Label();
            this.lblZona = new System.Windows.Forms.Label();
            this.btnZona = new Controles.Boton();
            this.btnOficina = new Controles.Boton();
            this.gbPermisos = new System.Windows.Forms.GroupBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.btnUsuario = new Controles.Boton();
            this.btnRol = new Controles.Boton();
            this.gbServicios = new System.Windows.Forms.GroupBox();
            this.lblServico = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.btnProducto = new Controles.Boton();
            this.btnServicio = new Controles.Boton();
            this.gbConfiguracion = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnParametros = new Controles.Boton();
            this.pnlParametrizacion = new System.Windows.Forms.Panel();
            this.gbEmpresa.SuspendLayout();
            this.gbPermisos.SuspendLayout();
            this.gbServicios.SuspendLayout();
            this.gbConfiguracion.SuspendLayout();
            this.pnlParametrizacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEmpresa
            // 
            this.gbEmpresa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbEmpresa.Controls.Add(this.lblOficina);
            this.gbEmpresa.Controls.Add(this.lblZona);
            this.gbEmpresa.Controls.Add(this.btnZona);
            this.gbEmpresa.Controls.Add(this.btnOficina);
            this.gbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbEmpresa.ForeColor = System.Drawing.Color.DimGray;
            this.gbEmpresa.Location = new System.Drawing.Point(65, 41);
            this.gbEmpresa.Name = "gbEmpresa";
            this.gbEmpresa.Size = new System.Drawing.Size(250, 200);
            this.gbEmpresa.TabIndex = 0;
            this.gbEmpresa.TabStop = false;
            this.gbEmpresa.Text = "EMPRESA";
            // 
            // lblOficina
            // 
            this.lblOficina.AutoSize = true;
            this.lblOficina.BackColor = System.Drawing.Color.White;
            this.lblOficina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOficina.Location = new System.Drawing.Point(147, 140);
            this.lblOficina.Name = "lblOficina";
            this.lblOficina.Size = new System.Drawing.Size(72, 20);
            this.lblOficina.TabIndex = 3;
            this.lblOficina.Text = "Oficinas";
            // 
            // lblZona
            // 
            this.lblZona.AutoSize = true;
            this.lblZona.BackColor = System.Drawing.Color.White;
            this.lblZona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblZona.Location = new System.Drawing.Point(49, 140);
            this.lblZona.Name = "lblZona";
            this.lblZona.Size = new System.Drawing.Size(57, 20);
            this.lblZona.TabIndex = 2;
            this.lblZona.Text = "Zonas";
            // 
            // btnZona
            // 
            this.btnZona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnZona.Imagen = global::CapturaHuellaBanco.Properties.Resources.Company_Disable;
            this.btnZona.ImagenDesabilitado = global::CapturaHuellaBanco.Properties.Resources.Company_Disable;
            this.btnZona.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.Company;
            this.btnZona.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.Company_Disable;
            this.btnZona.Location = new System.Drawing.Point(23, 49);
            this.btnZona.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnZona.Name = "btnZona";
            this.btnZona.Size = new System.Drawing.Size(100, 100);
            this.btnZona.TabIndex = 1;
            this.btnZona.TamamoTexto = 11.25F;
            this.btnZona.TextoBoton = "";
            this.btnZona.Tooltip = "Zonas";
            this.btnZona.EventoClick += new Controles.Boton.ClickEventHandler(this.btnZona_EventoClick);
            // 
            // btnOficina
            // 
            this.btnOficina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnOficina.Imagen = global::CapturaHuellaBanco.Properties.Resources.zone_disable;
            this.btnOficina.ImagenDesabilitado = global::CapturaHuellaBanco.Properties.Resources.zone_disable;
            this.btnOficina.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.zone;
            this.btnOficina.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.zone_disable;
            this.btnOficina.Location = new System.Drawing.Point(133, 49);
            this.btnOficina.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnOficina.Name = "btnOficina";
            this.btnOficina.Size = new System.Drawing.Size(100, 100);
            this.btnOficina.TabIndex = 2;
            this.btnOficina.TamamoTexto = 11.25F;
            this.btnOficina.TextoBoton = "";
            this.btnOficina.Tooltip = "Oficinas";
            this.btnOficina.EventoClick += new Controles.Boton.ClickEventHandler(this.btnOficina_EventoClick);
            // 
            // gbPermisos
            // 
            this.gbPermisos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbPermisos.Controls.Add(this.lblUsuario);
            this.gbPermisos.Controls.Add(this.lblRol);
            this.gbPermisos.Controls.Add(this.btnUsuario);
            this.gbPermisos.Controls.Add(this.btnRol);
            this.gbPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbPermisos.ForeColor = System.Drawing.Color.DimGray;
            this.gbPermisos.Location = new System.Drawing.Point(333, 41);
            this.gbPermisos.Name = "gbPermisos";
            this.gbPermisos.Size = new System.Drawing.Size(250, 200);
            this.gbPermisos.TabIndex = 1;
            this.gbPermisos.TabStop = false;
            this.gbPermisos.Text = "PERMISOS";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.White;
            this.lblUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUsuario.Location = new System.Drawing.Point(141, 140);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(78, 20);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "Usuarios";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.BackColor = System.Drawing.Color.White;
            this.lblRol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRol.Location = new System.Drawing.Point(44, 140);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(54, 20);
            this.lblRol.TabIndex = 4;
            this.lblRol.Text = "Roles";
            // 
            // btnUsuario
            // 
            this.btnUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnUsuario.Imagen = global::CapturaHuellaBanco.Properties.Resources.user_disable;
            this.btnUsuario.ImagenDesabilitado = global::CapturaHuellaBanco.Properties.Resources.user_disable;
            this.btnUsuario.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.user_;
            this.btnUsuario.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.user_disable;
            this.btnUsuario.Location = new System.Drawing.Point(130, 49);
            this.btnUsuario.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(100, 100);
            this.btnUsuario.TabIndex = 4;
            this.btnUsuario.TamamoTexto = 11.25F;
            this.btnUsuario.TextoBoton = "";
            this.btnUsuario.Tooltip = "Usuarios";
            this.btnUsuario.EventoClick += new Controles.Boton.ClickEventHandler(this.btnUsuario_EventoClick);
            // 
            // btnRol
            // 
            this.btnRol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRol.Imagen = global::CapturaHuellaBanco.Properties.Resources.rol_disable;
            this.btnRol.ImagenDesabilitado = global::CapturaHuellaBanco.Properties.Resources.rol_disable;
            this.btnRol.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.rol;
            this.btnRol.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.rol_disable;
            this.btnRol.Location = new System.Drawing.Point(20, 49);
            this.btnRol.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRol.Name = "btnRol";
            this.btnRol.Size = new System.Drawing.Size(100, 100);
            this.btnRol.TabIndex = 3;
            this.btnRol.TamamoTexto = 11.25F;
            this.btnRol.TextoBoton = "";
            this.btnRol.Tooltip = "Roles";
            this.btnRol.EventoClick += new Controles.Boton.ClickEventHandler(this.btnRol_EventoClick);
            // 
            // gbServicios
            // 
            this.gbServicios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbServicios.Controls.Add(this.lblServico);
            this.gbServicios.Controls.Add(this.lblProducto);
            this.gbServicios.Controls.Add(this.btnProducto);
            this.gbServicios.Controls.Add(this.btnServicio);
            this.gbServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbServicios.ForeColor = System.Drawing.Color.DimGray;
            this.gbServicios.Location = new System.Drawing.Point(603, 41);
            this.gbServicios.Name = "gbServicios";
            this.gbServicios.Size = new System.Drawing.Size(250, 200);
            this.gbServicios.TabIndex = 2;
            this.gbServicios.TabStop = false;
            this.gbServicios.Text = "PRODUCTOS";
            // 
            // lblServico
            // 
            this.lblServico.AutoSize = true;
            this.lblServico.BackColor = System.Drawing.Color.White;
            this.lblServico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblServico.Location = new System.Drawing.Point(143, 140);
            this.lblServico.Name = "lblServico";
            this.lblServico.Size = new System.Drawing.Size(80, 20);
            this.lblServico.TabIndex = 7;
            this.lblServico.Text = "Servicios";
            this.lblServico.Visible = false;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.BackColor = System.Drawing.Color.White;
            this.lblProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProducto.Location = new System.Drawing.Point(22, 140);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(88, 20);
            this.lblProducto.TabIndex = 6;
            this.lblProducto.Text = "Productos";
            // 
            // btnProducto
            // 
            this.btnProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnProducto.Imagen = global::CapturaHuellaBanco.Properties.Resources.Product_disable;
            this.btnProducto.ImagenDesabilitado = global::CapturaHuellaBanco.Properties.Resources.Product_disable;
            this.btnProducto.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.Product;
            this.btnProducto.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.Product_disable;
            this.btnProducto.Location = new System.Drawing.Point(17, 49);
            this.btnProducto.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(100, 100);
            this.btnProducto.TabIndex = 6;
            this.btnProducto.TamamoTexto = 11.25F;
            this.btnProducto.TextoBoton = "";
            this.btnProducto.Tooltip = "Productos";
            this.btnProducto.EventoClick += new Controles.Boton.ClickEventHandler(this.btnProducto_EventoClick);
            // 
            // btnServicio
            // 
            this.btnServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnServicio.Imagen = global::CapturaHuellaBanco.Properties.Resources.Services_disable;
            this.btnServicio.ImagenDesabilitado = global::CapturaHuellaBanco.Properties.Resources.Services_disable;
            this.btnServicio.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.Service;
            this.btnServicio.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.Services_disable;
            this.btnServicio.Location = new System.Drawing.Point(133, 49);
            this.btnServicio.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnServicio.Name = "btnServicio";
            this.btnServicio.Size = new System.Drawing.Size(100, 100);
            this.btnServicio.TabIndex = 5;
            this.btnServicio.TamamoTexto = 11.25F;
            this.btnServicio.TextoBoton = "";
            this.btnServicio.Tooltip = "Servicios";
            this.btnServicio.Visible = false;
            this.btnServicio.EventoClick += new Controles.Boton.ClickEventHandler(this.btnServicio_EventoClick);
            // 
            // gbConfiguracion
            // 
            this.gbConfiguracion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbConfiguracion.Controls.Add(this.label2);
            this.gbConfiguracion.Controls.Add(this.btnParametros);
            this.gbConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbConfiguracion.ForeColor = System.Drawing.Color.DimGray;
            this.gbConfiguracion.Location = new System.Drawing.Point(875, 41);
            this.gbConfiguracion.Name = "gbConfiguracion";
            this.gbConfiguracion.Size = new System.Drawing.Size(250, 200);
            this.gbConfiguracion.TabIndex = 3;
            this.gbConfiguracion.TabStop = false;
            this.gbConfiguracion.Text = "CONFIGURACIÓN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(24, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Parámetros";
            // 
            // btnParametros
            // 
            this.btnParametros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnParametros.Imagen = global::CapturaHuellaBanco.Properties.Resources.parameters_disable;
            this.btnParametros.ImagenDesabilitado = global::CapturaHuellaBanco.Properties.Resources.parameters_disable;
            this.btnParametros.ImagenSobre = global::CapturaHuellaBanco.Properties.Resources.parameters;
            this.btnParametros.ImagenVisitada = global::CapturaHuellaBanco.Properties.Resources.parameters_disable;
            this.btnParametros.Location = new System.Drawing.Point(23, 49);
            this.btnParametros.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnParametros.Name = "btnParametros";
            this.btnParametros.Size = new System.Drawing.Size(100, 100);
            this.btnParametros.TabIndex = 7;
            this.btnParametros.TamamoTexto = 11.25F;
            this.btnParametros.TextoBoton = "";
            this.btnParametros.Tooltip = "Parámetros";
            this.btnParametros.EventoClick += new Controles.Boton.ClickEventHandler(this.btnParametros_EventoClick);
            // 
            // pnlParametrizacion
            // 
            this.pnlParametrizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlParametrizacion.Controls.Add(this.gbEmpresa);
            this.pnlParametrizacion.Controls.Add(this.gbPermisos);
            this.pnlParametrizacion.Controls.Add(this.gbServicios);
            this.pnlParametrizacion.Controls.Add(this.gbConfiguracion);
            this.pnlParametrizacion.Location = new System.Drawing.Point(0, 0);
            this.pnlParametrizacion.Name = "pnlParametrizacion";
            this.pnlParametrizacion.Size = new System.Drawing.Size(1139, 320);
            this.pnlParametrizacion.TabIndex = 4;
            // 
            // ctrlParametrizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlParametrizacion);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ctrlParametrizacion";
            this.Size = new System.Drawing.Size(1139, 320);
            this.Load += new System.EventHandler(this.ctrlParametrizacion_Load);
            this.gbEmpresa.ResumeLayout(false);
            this.gbEmpresa.PerformLayout();
            this.gbPermisos.ResumeLayout(false);
            this.gbPermisos.PerformLayout();
            this.gbServicios.ResumeLayout(false);
            this.gbServicios.PerformLayout();
            this.gbConfiguracion.ResumeLayout(false);
            this.gbConfiguracion.PerformLayout();
            this.pnlParametrizacion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEmpresa;
        private System.Windows.Forms.GroupBox gbPermisos;
        private Controles.Boton btnOficina;
        private System.Windows.Forms.GroupBox gbServicios;
        private Controles.Boton btnZona;
        private Controles.Boton btnUsuario;
        private Controles.Boton btnRol;
        private Controles.Boton btnProducto;
        private Controles.Boton btnServicio;
        private System.Windows.Forms.Label lblOficina;
        private System.Windows.Forms.Label lblZona;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblServico;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.GroupBox gbConfiguracion;
        private System.Windows.Forms.Label label2;
        private Controles.Boton btnParametros;
        private System.Windows.Forms.Panel pnlParametrizacion;
    }
}

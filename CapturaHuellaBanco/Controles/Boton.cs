using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Controles
{
    public partial class Boton : UserControl
    {
        private ToolTip Ctooltip = new ToolTip();
        private ArrayList puntosActivos = new ArrayList();
        private string tooltip;

        public Boton()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public delegate void ClickEventHandler(object sender, EventArgs e);

        public delegate void EventoDelegado();

        [Category("Boton")]
        [Description("Ocurre cuando el botón es presionado.")]
        public event ClickEventHandler EventoClick;

        [Category("Boton")]
        [Description("Imagen")]
        public Image Imagen
        {
            get
            {
                return this.imagen.Image;
            }
            set
            {
                this.imagen.Image = value;
                this.lblTextoBoton.Image = value;
            }
        }

        [Category("Boton")]
        [Description("Imagen deshabilitada")]
        public Image ImagenDesabilitado { get; set; }

        [Category("Boton")]
        [Description("Imagen alterna cuando el ratón pasa por el botón")]
        public Image ImagenSobre { get; set; }

        [Category("Boton")]
        [Description("Imagen cuando el boton ya ha sido presionado")]
        public Image ImagenVisitada { get; set; }

        [Category("Boton")]
        [Description("Tamaño del texto del botón")]
        public float TamamoTexto
        {
            get
            {
                return this.lblTextoBoton.Font.Size;
            }
            set
            {
                this.lblTextoBoton.Font = new Font(lblTextoBoton.Font.FontFamily, value);
            }
        }

        [Category("Boton")]
        [Description("Texto del botón")]
        public string TextoBoton
        {
            get
            {
                return this.lblTextoBoton.Text;
            }
            set
            {
                this.lblTextoBoton.Text = value;
            }
        }

        [Category("Boton")]
        [Description("Tooltip.")]
        public string Tooltip
        {
            get
            {
                return tooltip;
            }
            set
            {
                tooltip = value;
                Ctooltip.SetToolTip(this.imagen, value);
            }
        }

        private Image ImagenDesabilitadoTexto { get; set; }

        public void CambiarImagen(bool valor)
        {
            try
            {
                if (this.ImagenDesabilitado != null)
                {
                    if (valor == false)
                    {
                        this.imagen.Image = this.lblTextoBoton.Image = this.ImagenDesabilitado;
                    }
                    else
                    {
                        this.imagen.Image = this.lblTextoBoton.Image = this.ImagenVisitada;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CentrarControlesHorizontalmente(Control padre, List<Control> listaControles, int margen)
        {
            try
            {
                int anchoControles = margen * (listaControles.Count - 1);
                foreach (var item in listaControles)
                {
                    anchoControles += item.Width;
                }
                int i = 0;
                int controlesUbicados = 0;

                foreach (Control control in listaControles)
                {
                    control.Location = new Point((padre.Width - anchoControles) / 2 + controlesUbicados + i * margen, (padre.Height - control.Height) / 2);
                    controlesUbicados += control.Width;
                    i++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Boton_EnabledChanged(object sender, EventArgs e)
        {
        }

        private void Boton_Load(object sender, EventArgs e)
        {
            try
            {
                CentrarControlesHorizontalmente(this, new List<Control>() { this.lblTextoBoton }, 0);
                CambiarImagenBoton(this);
            }
            catch (Exception)
            {
            }
        }

        private void CambiarImagenBoton(Control control)
        {
            try
            {
                if (this.ImagenDesabilitado != null)
                {
                    if (control.Enabled == false)
                    {
                        this.imagen.Image = this.lblTextoBoton.Image = this.ImagenDesabilitado;
                    }
                    else
                    {
                        this.imagen.Image = this.lblTextoBoton.Image = this.ImagenVisitada;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void imagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (EventoClick != null)
                {
                    EventoClick(this, e);
                }
            }
            catch (Exception)
            {
            }
        }

        private void imagen_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                Point pOver = new Point(e.X, e.Y);
                if (puntosActivos.IndexOf(pOver) < 0)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void imagen_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                this.imagen.Image = this.lblTextoBoton.Image = this.ImagenVisitada;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void imagen_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Point pOver = new Point(e.X, e.Y);
                if (puntosActivos.IndexOf(pOver) < 0)
                {
                    this.imagen.Image = this.lblTextoBoton.Image = this.ImagenSobre;
                    this.Cursor = Cursors.Hand;
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void imagen_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Point pOver = new Point(e.X, e.Y);
                if (puntosActivos.IndexOf(pOver) < 0)
                {
                    return;
                }
                this.imagen_Click(sender, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
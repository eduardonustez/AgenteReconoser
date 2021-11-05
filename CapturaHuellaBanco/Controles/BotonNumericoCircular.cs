using Controles.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Controles
{
    public partial class BotonNumericoCircular : UserControl
    {
        public BotonNumericoCircular()
        {
            InitializeComponent();
            Texto = "0";
            ColorFondo = Color.Gray;
            esPasoAnterior = false;
        }

        [Category("Activo")]
        [Description("Activo")]
        public bool Activo { get; set; }

        [Category("BotonNumericoCircular")]
        [Description("Color de fondo")]
        public Color ColorFondo { get; set; }

        [Category("BotonNumericoCircular")]
        [Description("Color de fondo con hover")]
        public Color ColorFondoHover { get; set; }

        [Category("BotonNumericoCircular")]
        [Description("esPasoAnterior")]
        public bool esPasoAnterior { get; set; }

        [Category("BotonNumericoCircular")]
        [Description("Número")]
        public string Texto { get; set; }
        private GraphicsPath path { get; set; }
        public void Activar()
        {
            this.Activo = true;
            Graphics g = this.CreateGraphics();
            PintarNumero(g, ColorFondo, Texto);
        }

        public void Desactivar()
        {
            this.Activo = false;
            Graphics g = this.CreateGraphics();
            PintarNumero(g, ColorFondo, Texto);
        }

        public void PasoAnterior()
        {
            this.Activo = true;
            Graphics g = this.CreateGraphics();
            PintarNumero(g, ColorFondo, Texto);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            path = RoundedRectangle.Create(-1, 0, 35, 35, 18);
            if (Activo)
            {
                PintarNumero(e.Graphics, ColorFondo, Texto);
            }
            else
            {
                PintarNumero(e.Graphics, ColorFondo, Texto);
            }
        }

        private void BotonNumericoCircular_MouseHover(object sender, EventArgs e)
        {
            if (!Activo)
            {
                Graphics g = this.CreateGraphics();
                PintarNumero(g, ColorFondo, Texto);
            }
        }

        private void BotonNumericoCircular_MouseLeave(object sender, EventArgs e)
        {
            if (!Activo)
            {
                Graphics g = this.CreateGraphics();
                PintarNumero(g, ColorFondo, Texto);
            }
        }
        private void PintarNumero(Graphics g, Color color, string numero)
        {
            if (path != null)
            {
                g.FillPath(new SolidBrush(color), path);
                g.SetClip(path);
            }
            using (Font f = new Font("Calibri Light", 14, FontStyle.Bold))
            {
                Rectangle rect2 = new Rectangle(2, 2, 30, 30);
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter;
                TextRenderer.DrawText(g, numero, f, rect2, Color.FromArgb(255, 255, 255), flags);
                g.DrawRectangle(Pens.Transparent, rect2);
                if (esPasoAnterior)
                {
                    g.DrawImage(Resources.ch_bar, 0, 0, 36, 36);
                }
            }
            g.ResetClip();
        }
    }
}
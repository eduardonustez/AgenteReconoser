using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Controles
{
    public partial class PanelPersonalizado : Panel
    {
        [Category("PanelPersonalizado")]
        [Description("Ancho del borde")]
        public float AnchoBorde { get; set; }

        [Category("PanelPersonalizado")]
        [Description("Color del borde")]
        public Color ColorBorde { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
                int _Izquierda = 0;
                int _Arriba = 0;
                int _Ancho = this.Width;
                int _Altura = this.Height;
                Color _ColorBorde = ColorBorde;
                float _AnchoBorde = AnchoBorde;
                float _Radio = 9;

                GraphicsPath GP = new GraphicsPath(FillMode.Alternate);

                GP.AddLine(_Izquierda + _Radio, _Arriba, _Izquierda + _Ancho - (_Radio * 2), _Arriba); // Line
                GP.AddArc(_Izquierda + _Ancho - (_Radio * 2), _Arriba, _Radio * 2, _Radio * 2, 270, 90); // Corner
                GP.AddLine(_Izquierda + _Ancho, _Arriba + _Radio, _Izquierda + _Ancho, _Arriba + _Altura - (_Radio * 2)); // Line
                GP.AddArc(_Izquierda + _Ancho - (_Radio * 2), _Arriba + _Altura - (_Radio * 2), _Radio * 2, _Radio * 2, 0, 90); // Corner
                GP.AddLine(_Izquierda + _Ancho - (_Radio * 2), _Arriba + _Altura, _Izquierda + _Radio, _Arriba + _Altura); // Line
                GP.AddArc(_Izquierda, _Arriba + _Altura - (_Radio * 2), _Radio * 2, _Radio * 2, 90, 90); // Corner
                GP.AddLine(_Izquierda, _Arriba + _Altura - (_Radio * 2), _Izquierda, _Arriba + _Radio); // Line
                GP.AddArc(_Izquierda, _Arriba, _Radio * 2, _Radio * 2, 180, 90); // Corner

                Graphics _Area = this.CreateGraphics();

                Pen oPen = new Pen(_ColorBorde, _AnchoBorde);

                _Area.DrawPath(oPen, GP);
                this.Region = new Region(GP);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
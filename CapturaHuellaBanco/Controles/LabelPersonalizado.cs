using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Utilidades;

namespace Controles
{
    public partial class LabelPersonalizado : Label
    {
        [Category("LabelPersonalizado")]
        [Description("Color del borde")]
        public Color Color { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (!Enabled)
                {
                    using (Label temp = new Label())
                    using (Bitmap bitmap = new Bitmap(Width, Height))
                    {
                        // Copy the relevant properties
                        temp.BackColor = BackColor;
                        temp.AutoSize = AutoSize;
                        temp.Size = Size;
                        temp.Text = Text;

                        if (Image != null)
                        {
                            temp.Image = UtilImagen.Redimensionar(Image, 131, 43);
                        }

                        temp.ForeColor = Color;   // the new disabled color

                        temp.DrawToBitmap(bitmap, temp.ClientRectangle);   // (1) draw the temporary label to a bitmap, and then

                        e.Graphics.DrawImage(bitmap, Point.Empty);    // (2) draw that bitmap instead of the label object
                    }
                }
                else
                {
                    base.OnPaint(e);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
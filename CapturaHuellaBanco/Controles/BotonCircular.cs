using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Controles
{
    public partial class BotonCircular : UserControl
    {
        private int _AltoImagen = 54;
        private int _AnchoImagen = 69;
        private int _localizacionX = 34;
        private int _localizacionY = 36;
        private int _RelacionImagenCentral = 50;
        private int _TamañoTexto = 12;
        private ArrayList puntosActivos = new ArrayList();

        public BotonCircular()
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

        [Category("BotonCircular")]
        [Description("Ocurre cuando el botón es presionado.")]
        public event ClickEventHandler EventoClick;

        [Category("BotonCircular")]
        [Description("Asigna la rotación de la imagen")]
        public float Angulo { get; set; }

        [Category("BotonCircular")]
        [Description("Imagen central")]
        public Image ImagenCentral { set; get; }

        [Category("BotonCircular")]
        [Description("Tamaño de la imagen central con relacion a la circunferencia")]
        public int RelacionImagenCentral
        {
            get { return this._RelacionImagenCentral; }
            set
            {
                this._RelacionImagenCentral = value;
                CentrarImagen();
            }
        }

        [Category("BotonCircular")]
        [Description("Tamaño texto del botón")]
        public int TamañoTexto
        {
            get { return this._TamañoTexto; }
            set { this._TamañoTexto = value; }
        }

        [Category("BotonCircular")]
        [Description("Asigna la descripción")]
        public string Texto
        {
            set
            {
                this.lblDescripcionAccion.Text = value;
            }
            get
            {
                return this.lblDescripcionAccion.Text;
            }
        }

        public void AplicarPropiedades()
        {
        }

        public void QuitarSeleccionarBoton()
        {
            try
            {
                this.pbCirculo.BorderStyle = BorderStyle.None;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Bitmap RotarImagen(Image image, float angle)
        {
            try
            {
                return RotarImagen(image, new PointF((float)image.Width / 2, (float)image.Height / 2), angle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Bitmap RotarImagen(Image image, PointF offset, float angle)
        {
            try
            {
                if (image == null)
                {
                    throw new ArgumentNullException("image");
                }

                //create a new empty bitmap to hold rotated image
                Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
                rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                //make a graphics object from the empty bitmap
                Graphics g = Graphics.FromImage(rotatedBmp);

                //Put the rotation point in the center of the image
                g.TranslateTransform(offset.X, offset.Y);

                //rotate the image
                g.RotateTransform(angle);

                //move the image back
                g.TranslateTransform(-offset.X, -offset.Y);

                //draw passed in image onto graphics object
                g.DrawImage(image, new PointF(0, 0));

                return rotatedBmp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SeleccionarBoton()
        {
            try
            {
                this.pbCirculo.BorderStyle = BorderStyle.Fixed3D;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AsignarImagen()
        {
            try
            {
                Image image = new Bitmap(Properties.Resources.circle);
                pbCirculo.Image = (Bitmap)image.Clone();
                RotarImagen(pbCirculo, image, this.Angulo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AsignarImagenCentral()
        {
            try
            {
                if (this.ImagenCentral != null)
                {
                    this.pbImgCentral.Image = (Bitmap)this.ImagenCentral.Clone();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void BotonCircular_Load(object sender, EventArgs e)
        {
            try
            {
                AsignarImagen();
                AsignarImagenCentral();
                ConfigurarDiseñoBoton();
                CentrarImagen();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AsignarImagenCentral();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CentrarImagen()
        {
            try
            {
                this.pbImgCentral.Width = this.pbCirculo.Width * this._RelacionImagenCentral / 100;
                this.pbImgCentral.Height = this.pbCirculo.Height * this._RelacionImagenCentral / 100;

                this.pbImgCentral.Location = new Point((this.pbCirculo.Width - this.pbImgCentral.Width) / 2, (this.pbCirculo.Height - this.pbImgCentral.Height) / 2);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ConfigurarDiseñoBoton()
        {
            try
            {
                this.lblDescripcionAccion.Font = new Font(this.lblDescripcionAccion.Font.FontFamily, (float)TamañoTexto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void pbCirculo_Click(object sender, EventArgs e)
        {
            try
            {
                if (EventoClick != null)
                {
                    Application.DoEvents();
                    EventoClick(this, e);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void pbCirculo_MouseDown(object sender, MouseEventArgs e)
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

        private void pbCirculo_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                AsignarImagen();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void pbCirculo_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Image imagenOver = new Bitmap(Properties.Resources.circle_hv);

                Point pOver = new Point(e.X, e.Y);
                if (puntosActivos.IndexOf(pOver) < 0)
                {
                    pbCirculo.Image = (Bitmap)imagenOver.Clone();
                    this.Cursor = Cursors.Hand;
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void pbCirculo_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Point pOver = new Point(e.X, e.Y);
                if (puntosActivos.IndexOf(pOver) < 0)
                {
                    return;
                }
                this.pbCirculo_Click(sender, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void RotarImagen(PictureBox pb, Image img, float angle)
        {
            try
            {
                if (img == null || pb.Image == null)
                {
                    return;
                }

                Image oldImage = pb.Image;
                pb.Image = RotarImagen(img, angle);
                if (oldImage != null)
                {
                    oldImage.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
using Entidades;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CapturaHuellaBanco.ControlesWF
{
    public partial class ctrlNewResultadoHuella2 : UserControl
    {
        internal Guid IdPeticion;
        private static LogErrores error = null;
        private Olimpia.Servicios.ConsumirServicio sb = new Olimpia.Servicios.ConsumirServicio();
        public ctrlNewResultadoHuella2()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlResultadoHuella : ctrlNewResultadoHuella";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        public ctrlNewResultadoHuella2(LogOperaciones LO)
        {
            try
            {
                InitializeComponent();

                string NombreCompleto = string.Format("{0} {1} {2} {3}", LO.PrimerApellido, LO.SegundoApellido, LO.PrimerNombre, LO.SegundoNombre);
                LblNombre.Text = NombreCompleto;

                LblDocumento.Text = LO.Documento;
                if (LO.Vigencia != null)
                {
                    if (LO.Vigencia.ToUpper() == "VIGENTE")
                    {
                        boton3.BackgroundImage = Properties.Resources.resultado_15_verde;
                        lbltituloEstado.ForeColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(75)))));
                        lblResultEstado.ForeColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(75)))));
                        lblResultEstado.Text = LO.Vigencia.ToUpper();
                    }
                    else
                    {
                        boton3.BackgroundImage = Properties.Resources.resultado_15_Rojo;
                        lbltituloEstado.ForeColor = Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
                        lblResultEstado.ForeColor = Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
                        lblResultEstado.Text = LO.Vigencia.ToUpper();
                    }
                }

                DateTime FechaLarga = LO.FechaExpedicion;
                lblFechaExpedicion.Text = string.Format("{0} {1} {2} {3} {4}", FechaLarga.Day, "de", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(FechaLarga.Month), "de", FechaLarga.Year);

                LblServicio.Text = LO.NombreServicio;

                if (LO.RespuestaAFI == "HIT")
                {
                    BtnResIdentificado.BackgroundImage = Properties.Resources.resultado_11;
                    BtnResNoIdentificado.BackgroundImage = Properties.Resources.resultado_12;
                }
                else
                {
                    ContenedorDerecho.Visible = false;
                    ContenedorIzquierdo.Location = new Point(244, 0);

                    BtnResIdentificado.BackgroundImage = Properties.Resources.resultado_4;
                    BtnResNoIdentificado.BackgroundImage = Properties.Resources.resultado_5;

                    BtnReintentar.Visible = true;
                }

                foreach (var item in LO.HA)
                {
                    switch (item.NumeroDedo)
                    {
                        case 1:
                            if (item.RespuestaAFI != "HIT")
                            {
                                BtnPulgarDer.BackgroundImage = Properties.Resources.resultado_9;
                            }
                            else
                            {
                                BtnPulgarDer.BackgroundImage = Properties.Resources.resultado_8;
                            }

                            BtnPulgarDer.Visible = true;
                            break;

                        case 2:
                            if (item.RespuestaAFI != "HIT")
                            {
                                BtnIndiceDer.BackgroundImage = Properties.Resources.resultado_9;
                            }
                            else
                            {
                                BtnIndiceDer.BackgroundImage = Properties.Resources.resultado_8;
                            }

                            BtnIndiceDer.Visible = true;
                            break;

                        case 3:
                            if (item.RespuestaAFI != "HIT")
                            {
                                BtnMedioDer.BackgroundImage = Properties.Resources.resultado_9;
                            }
                            else
                            {
                                BtnMedioDer.BackgroundImage = Properties.Resources.resultado_8;
                            }

                            BtnMedioDer.Visible = true;
                            break;

                        case 4:
                            if (item.RespuestaAFI != "HIT")
                            {
                                BtnAnularDer.BackgroundImage = Properties.Resources.resultado_9;
                            }
                            else
                            {
                                BtnAnularDer.BackgroundImage = Properties.Resources.resultado_8;
                            }

                            BtnAnularDer.Visible = true;
                            break;

                        case 5:
                            if (item.RespuestaAFI != "HIT")
                            {
                                BtnMeñiqueDer.BackgroundImage = Properties.Resources.resultado_9;
                            }
                            else
                            {
                                BtnMeñiqueDer.BackgroundImage = Properties.Resources.resultado_8;
                            }

                            BtnMeñiqueDer.Visible = true;
                            break;

                        case 6:
                            if (item.RespuestaAFI != "HIT")
                            {
                                BtnPulgarIzq.BackgroundImage = Properties.Resources.resultado_9;
                            }
                            else
                            {
                                BtnPulgarIzq.BackgroundImage = Properties.Resources.resultado_8;
                            }

                            BtnPulgarIzq.Visible = true;
                            break;

                        case 7:
                            if (item.RespuestaAFI != "HIT")
                            {
                                BtnIndiceIzq.BackgroundImage = Properties.Resources.resultado_9;
                            }
                            else
                            {
                                BtnIndiceIzq.BackgroundImage = Properties.Resources.resultado_8;
                            }

                            BtnIndiceIzq.Visible = true;
                            break;

                        case 8:
                            if (item.RespuestaAFI != "HIT")
                            {
                                BtnMedioIzq.BackgroundImage = Properties.Resources.resultado_9;
                            }
                            else
                            {
                                BtnMedioIzq.BackgroundImage = Properties.Resources.resultado_8;
                            }

                            BtnMedioIzq.Visible = true;
                            break;

                        case 9:
                            if (item.RespuestaAFI != "HIT")
                            {
                                BtnAnularIzq.BackgroundImage = Properties.Resources.resultado_9;
                            }
                            else
                            {
                                BtnAnularIzq.BackgroundImage = Properties.Resources.resultado_8;
                            }

                            BtnAnularIzq.Visible = true;
                            break;

                        case 10:
                            if (item.RespuestaAFI != "HIT")
                            {
                                BtnMeñiqueIzq.BackgroundImage = Properties.Resources.resultado_9;
                            }
                            else
                            {
                                BtnMeñiqueIzq.BackgroundImage = Properties.Resources.resultado_8;
                            }

                            BtnMeñiqueIzq.Visible = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = "";
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlNewResultadoHuella : ctrlNewResultadoHuella";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }

        private void BtnFinalizar_EventoClick(object sender, EventArgs e)
        {
            frmBase _Base = (frmBase)this.ParentForm;

            _Base.CargarControl(new ctrlDashboard());
        }

        private void BtnReintentar_EventoClick(object sender, EventArgs e)
        {
            frmBase _Base = (frmBase)this.ParentForm;
            IdPeticion = Guid.Empty;
            _Base.CargarControl(new ctrlCapturaHuella());
        }

        private void ctrlNewResultadoHuella_Load(object sender, EventArgs e)
        {
            frmBase _Base = (frmBase)this.ParentForm;
            _Base.Titulo = "RESULTADOS DE AUTENTICACIÓN";
            _Base.MostrarIconoDashboard();
        }
        private void ctrlNewResultadoHuella2_ParentChanged(object sender, EventArgs e)
        {
            if (Parent == null && IdPeticion != Guid.Empty)
            {
                Olimpia.Servicios.Solicitudes.ActualizarSolicitudTerminada(IdPeticion);
            }
        }
    }
}
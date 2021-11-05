using CapturaHuellaBanco.Properties;
using Entidades;
using Entidades.Autenticacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilidades;

namespace CapturaHuellaBanco.ControlesWF
{
    public partial class ctrlCapturaHuella : UserControl
    {
        private static LogErrores error = null;

        private frmBase _Base;
        private long _IdAutorizacion;
        private int _NumeroRequeridos;
        private string _Serial;
        private List<HuellaAFI> Dedos = new List<HuellaAFI>();
        private bool FormatoDatos = false;
        private List<string> HuellasObligatorias;
        private List<string> HuellasOpcionales;
        private int iDedoSeleccionado;
        private Guid IdPeticion;
        private long IdSolicitudConvenioRNEC;
        private Olimpia.Servicios.ConsumirServicio sb = new Olimpia.Servicios.ConsumirServicio();

        //TODO: Serfinansas
        private Solicitud solicitud = new Solicitud();

        public ctrlCapturaHuella()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlCapturaHuella : ctrlCapturaHuella";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void ActualizarDiccionario(int iDedo, Bitmap img, byte[] _Template)
        {
            try
            {
                HuellaAFI AuxDedo = Dedos.FirstOrDefault(x => x.NumeroDedo == iDedo);

                SimpleAES SAE = new SimpleAES();

                if (AuxDedo == null)
                {
                    Dedos.Add(new HuellaAFI
                    {
                        NumeroDedo = iDedo,
                        NombreDedo = UtilidadesHuellas.NombreDedo(iDedo),
                        Template = SAE.EncryptToString(UtilidadesHuellas.ConvertirTemplateToB64(_Template)),
                        RespuestaAFI = "APROBADA"
                    });
                }
                else
                {
                    AuxDedo.Template = SAE.EncryptToString(UtilidadesHuellas.ConvertirTemplateToB64(_Template));
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlCapturaHuella : ActualizarDiccionario";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        //TODO: Serfinansas
        private void ActualizarEstadoSolicitud(int IdSolicitud, int Estado)
        {
            if (Estado == 3)//Cancelada
            {
                var response = Olimpia.Servicios.Solicitudes.cancelarSolicitud(IdPeticion);

                if (response.Estado == Olimpia.Servicios.ServicioFachadaZeus.RespuestaEstadoRespuesta.Ok)
                {
                    timerEstadoSolicitud.Stop();
                    timerSolicitud.Stop();
                }
            }
        }

        //TODO: Serfinansas
        private void ActualizarSolicitud(Solicitud solicitud)
        {
            Olimpia.Servicios.Solicitudes.ActualizarSolicitudTerminada(IdPeticion);
        }

        //TODO: Serfinansas
        private void btnCancelar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                int Estado = 3; //Cancelado
                ActualizarEstadoSolicitud(solicitud.IdSolicitudes, Estado);
                _Base.CargarControl(new ctrlCapturaHuella());
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlCapturaHuella : btnCancelar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnDedo_EventoClick(object sender, EventArgs e)
        {
            try
            {
                if (txbNumeroIdentificacion.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Ingrese el número de identificación antes de tomar las huellas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Pregunta si ya capturó el número de huellas requeridas por el convenio
                if (Dedos.Count == _NumeroRequeridos)
                {
                    MessageBox.Show(string.Format("Ya se hizo la captura de {0} huellas requeridas por el convenio.", Dedos.Count), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var btnDedo = (Controles.Boton)sender;
                iDedoSeleccionado = Convert.ToInt32(btnDedo.Name.Replace("btnDedo", string.Empty));
                Capturar(iDedoSeleccionado);
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlCapturaHuella : btnDedo_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void BtnFinalizar_EventoClick(object sender, EventArgs e)
        {
            frmBase _Base = (frmBase)this.ParentForm;

            //TODO: Serfinansas
            if (_Base.ModoIntegrado)
            {
                _Base.CargarControl(new ctrlCapturaHuella());
            }
            else
            {
                _Base.CargarControl(new ctrlDashboard());
            }
        }

        private void btnNumId_EventoClick(object sender, EventArgs e)
        {
            //si txb está deshabilitado
            if (txbNumeroIdentificacion.ReadOnly)
            {
                txbNumeroIdentificacion.ReadOnly = false;

                btnNumId.Imagen = Resources.continuar;
                btnNumId.ImagenDesabilitado = Resources.continuar;
                btnNumId.ImagenSobre = Resources.continuarSobre;
                btnNumId.ImagenVisitada = Resources.continuar;

                btnValidar.Visible = false;

                //Eliminar fotos
                Dedos.Clear();

                //Limpiar todo
                for (int f = 1; f <= 10; f++)
                {
                    SeleccionarDedo(f, false);
                    HabilitarMenuDedo(f, false, string.Empty);
                    CargarHuellaCapturada(f, null);
                    OcultarDedo(f, false);
                }

                gbManoIzquierda.Enabled = false;
                gbManoDerecha.Enabled = false;
            }
            else
            {
                if (cbOficina.SelectedValue == null)
                {
                    MessageBox.Show("Asegúrese de escoger una Oficina válida antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txbNumeroIdentificacion.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Ingrese el número de identificación antes de tomar las huellas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string codProducto = _Base.ProductosAll.Where(x => x.Descripcion == cbProducto.Text).First().Codigo;
                string CiudadOfi = _Base.OficinasAll.Where(x => x.IdOficina == cbOficina.SelectedValue.ToString()).First().Ciudad;

                string archrTempProtDatos = "";
                using (ctrlFormatoProteccionDatos control = new ctrlFormatoProteccionDatos(cbOficina.SelectedValue.ToString(), cbOficina.Text, Convert.ToInt32(cbProducto.SelectedValue), codProducto, cbProducto.Text, _Base.Usuario, txbNumeroIdentificacion.Text, cbTipoIdentificacion.SelectedValue.ToString(), _Base.FormatoProteccion, CiudadOfi))
                {
                    _Base.PopUp(control);

                    _IdAutorizacion = control.IdAutorizacion;
                    archrTempProtDatos = control.ArchivoTemporal.Substring(0);

                    if (control.Acepta)
                    {
                        FormatoDatos = true;
                    }
                    else
                    {
                        FormatoDatos = false;

                        //TODO: Serfinansas
                        if (_Base.ModoIntegrado)
                        {
                            int Estado = 3; //Cancelado
                            ActualizarEstadoSolicitud(solicitud.IdSolicitudes, Estado);
                            _Base.CargarControl(new ctrlCapturaHuella());
                        }
                        else
                        {
                            _Base.CargarControl(new ctrlDashboard());
                        }
                    }
                }

                if (FormatoDatos == true)
                {
                    CargarRequeridos();

                    txbNumeroIdentificacion.ReadOnly = true;

                    btnNumId.Imagen = Resources.btn15icon;
                    btnNumId.ImagenDesabilitado = Resources.btn15icon;
                    btnNumId.ImagenSobre = Resources._16icon;
                    btnNumId.ImagenVisitada = Resources.btn15icon;

                    btnValidar.Visible = true;

                    gbManoIzquierda.Enabled = true;
                    gbManoDerecha.Enabled = true;
                }
            }
        }

        private void btnSiguiente_EventoClick(object sender, EventArgs e)
        {
        }

        private void btnValidar_EventoClick(object sender, EventArgs e)
        {
            Form frm = new Form();
            try
            {
                //Campos requeridos
                if (cbProducto.SelectedValue.ToString() == string.Empty || cbTipoIdentificacion.SelectedValue.ToString() == string.Empty
                    || txbNumeroIdentificacion.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }//Alguna huella capturada
                else if (Dedos.Count == 0)
                {
                    MessageBox.Show("Asegúrese de capturar una huella.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Huellas obligatorias
                foreach (string val in HuellasObligatorias)
                {
                    var aux = Dedos.FirstOrDefault(x => x.NumeroDedo == Convert.ToInt32(val));
                    if (aux == null)
                    {
                        string sDedo = UtilidadesHuellas.NombreDedo(Convert.ToInt32(val));

                        MessageBox.Show(string.Format("El dedo {0} es obligatorio", sDedo), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                //Validar cantidad de huellas
                if (Dedos.Count < _NumeroRequeridos)
                {
                    MessageBox.Show(string.Format("Debe capturar {0} huellas, según la parametrización del convenio", _NumeroRequeridos.ToString()), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frm.AutoSize = true;
                frm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                frm.Controls.Add(new ctrlEspera());
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.BringToFront();
                frm.Show();
                Application.DoEvents();

                ObtenerMac OM = new ObtenerMac();
                ObtenerIP OI = new ObtenerIP();

                string auxSerial = _Serial;
                int idx = auxSerial.IndexOf('=');
                if (idx != -1)
                {
                    auxSerial = auxSerial.Remove(0, auxSerial.IndexOf('=') + 1);
                }

                idx = auxSerial.IndexOf(';');
                if (idx != -1)
                {
                    auxSerial = auxSerial.Remove(auxSerial.IndexOf(';'));
                }

                auxSerial = "P/N: " + auxSerial.Replace("-", " S/N: ");
                string _Tramite = "";

                try
                {
                    string CodigoOficina = _Base.OficinasAll.Where(x => x.IdOficina == cbOficina.SelectedValue.ToString()).First().Codigo;
                    if (CodigoOficina.Contains("-"))
                    {
                        CodigoOficina = CodigoOficina.Substring(0, CodigoOficina.IndexOf("-"));
                    }

                    _Tramite = _Base.ProductosAll.Where(x => x.Descripcion == cbProducto.Text).First().Codigo + "|" + CodigoOficina;
                }
                catch
                {
                    _Tramite = _Base.ProductosAll.Where(x => x.Descripcion == cbProducto.Text).First().Codigo + "|" + _Base.OficinasAll.Where(x => x.IdOficina == cbOficina.SelectedValue.ToString()).First().Codigo;
                }

                int IdServico = _Base.ProductosAll.Where(x => x.Descripcion == cbProducto.Text).First().IdServicio;

                Guid IdPeticionVer = Guid.NewGuid();
                if (Global.ModoIntegrado)
                {
                    IdPeticionVer = IdPeticion;
                }

                LogOperaciones LO = sb.VerificarIdentidad(_Base.IdCliente, _Base.IdConvenioAutenticacion, _Base.Usuario, cbOficina.SelectedValue.ToString(),
                    Convert.ToInt32(cbProducto.SelectedValue), _Tramite, cbTipoIdentificacion.SelectedValue.ToString(), txbNumeroIdentificacion.Text.Trim(), Dedos,
                    OI.GetIP(), OM.GetMac(), auxSerial, _IdAutorizacion, IdServico, IdPeticionVer);

                LO.TipoDocumento = cbTipoIdentificacion.Text;
                LO.NombreServicio = cbProducto.Text;

                frm.Hide();
                if (LO.IdOperacion != 0)
                {
                    //TODO: Serfinansas
                    if (_Base.ModoIntegrado)
                    {
                        solicitud.Asesor = LO.UsuarioLogin;
                        solicitud.TipoIdentidad = LO.TipoDocumento;
                        solicitud.NumeroIdentidad = LO.Documento;
                        solicitud.Servicio = LO.NombreServicio;
                        solicitud.Estado = 2; //Finalizado
                        solicitud.UsuarioAprobado = LO.RespuestaAFI == "NOHIT" ? false : true;
                        if (solicitud.UsuarioAprobado)
                        {
                            solicitud.Nombre = LO.PrimerNombre + " " + LO.SegundoNombre + " " + LO.PrimerApellido + " " + LO.SegundoApellido;
                        }
                    }
                    timerEstadoSolicitud.Stop();
                    timerSolicitud.Stop();
                    ctrlNewResultadoHuella2 RH = new ctrlNewResultadoHuella2(LO);
                    RH.IdPeticion = IdPeticion;
                    _Base.CargarControl(RH);
                }
                else
                {
                    btnNumId_EventoClick(null, null);
                    Dedos = new List<HuellaAFI>();
                    if (!string.IsNullOrEmpty(LO.DescripcionError))
                    {
                        MessageBox.Show(LO.DescripcionError);
                        return;
                    }

                    MessageBox.Show("Ocurrió un error insertando el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                frm.Hide();
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlCapturaHuella : btnEnviar_Click";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void Capturar(int iDedo)
        {
            try
            {
                using (ctrlHuella CH = new ctrlHuella(iDedo))
                {
                    _Base.PopUp(CH);

                    if (CH.ImagenCapturada != null)
                    {
                        CargarHuellaCapturada(iDedo, CH.ImagenCapturada);
                        SeleccionarDedo(iDedo, true);
                        ActualizarDiccionario(iDedo, CH.ImagenCapturada, CH.Template);
                        _Serial = CH.Serial;

                        //Si es obligatoria, deja excepción y eliminar, sino solo eliminar
                        if (HuellasObligatorias.Contains(iDedo.ToString()))
                        {
                            HabilitarMenuDedo(iDedo, true, "Eliminar,Excepción");
                        }
                        else
                        {
                            HabilitarMenuDedo(iDedo, true, "Eliminar");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlCapturaHuella : Capturar";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void CapturarHuella_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "REGISTRO DE HUELLAS";
                _Base.ActivarPaneles(true);
                CargarCombos();

                cbOficina.SelectedValue = _Base._OficinaOrigen;
                cbOficina.Enabled = false;

                //TODO: Serfinansas
                if (_Base.ModoIntegrado)
                {
                    _Base.OcultarIconoDashboard();
                    ubicarControles();
                    ObtenerSoliciudEnproceso();

                    if (IdPeticion == Guid.Empty)
                    {
                        timerSolicitud.Tick += new EventHandler(timerSolicitud_Tick);
                        timerSolicitud.Enabled = true;
                        timerSolicitud.Interval = 7000;
                        timerSolicitud.Start();
                    }
                }
                else
                {
                    _Base.MostrarIconoDashboard();
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlCapturaHuella : CapturarHuella_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void CargarCombos()
        {
            try
            {
                //Cargar combo de Oficinas
                if (_Base.Oficinas != null)
                {
                    cbOficina.DataSource = _Base.Oficinas;
                    cbOficina.DisplayMember = "Codigo";
                    cbOficina.ValueMember = "IdOficina";
                }
                else
                {
                    MessageBox.Show("No se pudo obtener oficinas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //Cargar combo de Productos
                if (_Base.Productos != null)
                {
                    cbProducto.DataSource = _Base.Productos;
                    cbProducto.DisplayMember = "Descripcion";
                    cbProducto.ValueMember = "IdProducto";
                }
                else
                {
                    MessageBox.Show("No se pudo obtener productos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //Cargar combo de tipos de identificación
                cbTipoIdentificacion.DataSource = _Base.PBTD._ListDocs;
                cbTipoIdentificacion.DisplayMember = "NombreTipoDocumento";
                cbTipoIdentificacion.ValueMember = "Sigla";

                cbOficina.SelectedItem = 0;
                cbProducto.SelectedItem = 0;
                cbTipoIdentificacion.SelectedItem = 0;

                //OcultarDedos Y menu
                for (int f = 1; f <= 10; f++)
                {
                    OcultarDedo(f, false);
                    //Inhabilitar menus de dedos
                    HabilitarMenuDedo(f, false, string.Empty);
                }

                cbOficina.SelectedIndex = 0;
                cbOficina.Focus();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlCapturaHuella : CargarCombos";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void CargarHuellaCapturada(int iDedo, Bitmap img)
        {
            try
            {
                string spb = string.Format("pbDedo{0}", iDedo.ToString());

                var pbDedo = (PictureBox)this.Controls.Find(spb, true).FirstOrDefault();

                if (pbDedo != null)
                {
                    if (img == null)
                    {
                        pbDedo.Image = null;
                        pbDedo.Dock = DockStyle.None;
                    }
                    else
                    {
                        pbDedo.Dock = DockStyle.Fill;
                        pbDedo.Image = img;
                    }
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlCapturaHuella : CargarHuellaCapturada";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void CargarOpcionales()
        {
            //Cargar Dedos Opcionales
            HuellasOpcionales = new List<string>(_Base.PBTD._Biometrias.HuellasOpcionales);

            foreach (string s in HuellasOpcionales)
            {
                OcultarDedo(Convert.ToInt32(s), true);
            }
        }

        private void CargarRequeridos()
        {
            //Limpiar todo
            for (int f = 1; f <= 10; f++)
            {
                OcultarDedo(f, false);
                //Inhabilitar menus de dedos
                HabilitarMenuDedo(f, false, string.Empty);
            }

            //Cargar Dedos Requeridos
            HuellasObligatorias = new List<string>(_Base.PBTD._Biometrias.HuellasObligatorias);

            //Cambiar el color a los requeridos
            foreach (string i in HuellasObligatorias)
            {
                SeleccionarDedo(Convert.ToInt32(i), false);

                //Habilitar menu dedo
                HabilitarMenuDedo(Convert.ToInt32(i), true, "Excepción");
            }

            _NumeroRequeridos = _Base.PBTD._Biometrias.NumeroMuestras;
        }

        private void contexMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var cms = (ToolStripMenuItem)e.ClickedItem;
            toolStripMenuItem_Click(cms, null);
        }

        private void HabilitarMenuDedo(int i, bool act, string labels)
        {
            string sMenu = string.Format("menu{0}", i.ToString());
            var menu = (MenuStrip)this.Controls.Find(sMenu, true).FirstOrDefault();
            var tmenu = (ToolStripMenuItem)menu.Items[0];

            for (int k = 0; k < tmenu.DropDownItems.Count;)
            {
                tmenu.DropDownItems.RemoveAt(0);
            }

            menu.Enabled = act;
            if (act)
            {
                menu.Items[0].Font = new Font("Segoe UI", 8, FontStyle.Underline);
                menu.Items[0].ForeColor = Color.Blue;
            }
            else
            {
                menu.Items[0].Font = new Font("Segoe UI", 8, FontStyle.Regular);
                menu.Items[0].ForeColor = Color.DimGray;
            }

            char[] separador = { ',' };

            if (!string.IsNullOrEmpty(labels))
            {
                ContextMenuStrip cm = new ContextMenuStrip();

                foreach (string s in labels.Split(separador))
                {
                    tmenu.DropDownItems.Add(s);
                    int c = tmenu.DropDownItems.Count;
                    tmenu.DropDownItems[c - 1].Name = i.ToString() + s;
                    tmenu.DropDownItems[c - 1].Font = new Font("Segoe UI", 8, FontStyle.Regular);
                    tmenu.DropDownItems[c - 1].Click += new EventHandler(this.toolStripMenuItem_Click);

                    cm.Items.Add(s);
                    cm.Items[c - 1].Name = i.ToString() + s;
                    cm.ItemClicked += new ToolStripItemClickedEventHandler(contexMenu_ItemClicked);
                }

                //Copiar el menu al btndedo con el botón secundario
                string sbtnDedo = string.Format("btnDedo{0}", i.ToString());
                var btnDedo = (Controles.Boton)this.Controls.Find(sbtnDedo, true).FirstOrDefault();
                btnDedo.ContextMenuStrip = cm;
            }
        }

        //TODO: Serfinansas
        private void ObtenerSoliciudEnproceso()
        {
            try
            {
                string strMaquina = "";
                switch (Global.IdentificadorMaq)
                {
                    case "IP":
                        ObtenerIP OI = new ObtenerIP();
                        strMaquina = OI.GetIP();
                        break;

                    case "NOMBRE":
                        strMaquina = Environment.MachineName;
                        break;

                    case "MAC":
                        ObtenerMac OM = new ObtenerMac();
                        strMaquina = OM.GetMac();
                        break;

                    default:
                        ObtenerIP OI2 = new ObtenerIP();
                        strMaquina = OI2.GetIP();
                        break;
                }
                var tipoIdentidadMaquina = 1;
                var sol = Olimpia.Servicios.Solicitudes.consultarSolicitudAplicacion(strMaquina, tipoIdentidadMaquina);

                if (sol.Estado == Estado.Ok && sol.Lista.Count > 0)
                {
                    btnCancelar.Enabled = true;
                    btnCancelar.Imagen = Resources.btn_azul;
                    btnNumId.Enabled = true;
                    btnNumId.Imagen = Resources.continuar;
                    cbOficina.Enabled = false;
                    cbProducto.Enabled = false;
                    cbTipoIdentificacion.Enabled = false;
                    txbNumeroIdentificacion.Enabled = false;

                    gbManoIzquierda.Enabled = true;
                    gbManoDerecha.Enabled = true;

                    var fst = sol.Lista.FirstOrDefault();

                    IdPeticion = fst.IdPeticion;
                    cbTipoIdentificacion.SelectedText = fst.TipoIdentificacionCandidato;
                    cbProducto.SelectedValue = fst.IdProducto;

                    cbOficina.SelectedValue = _Base._OficinaOrigen;
                    cbOficina.Enabled = false;

                    txbNumeroIdentificacion.Text = fst.Candidato;
                    lblMensaje.Font = new Font(FontFamily.GenericSansSerif, 11.25F, FontStyle.Regular);
                    lblMensaje.ForeColor = Color.DimGray;
                    lblMensaje.Text = "Se está validando el proceso de autenticación con el consecutivo de solicitud No.";
                    lblNoSolicitud.Visible = true;
                    lblNoSolicitud.Text = fst.IdSolicitudCliente.ToString();

                    timerSolicitud.Stop();
                }
                else
                {
                    solicitud = new Solicitud();
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Font = new Font(FontFamily.GenericSansSerif, 14.0F, FontStyle.Bold);
                    lblMensaje.Text = "En espera de Solicitud.";
                    lblNoSolicitud.Visible = false;

                    btnCancelar.Enabled = false;
                    btnCancelar.Imagen = Resources.btn_disabled;
                    btnNumId.Enabled = false;
                    btnNumId.Imagen = Resources.continuar_disabled;
                    cbOficina.Enabled = false;
                    cbProducto.Enabled = false;
                    cbTipoIdentificacion.Enabled = false;
                    txbNumeroIdentificacion.Enabled = false;

                    gbManoIzquierda.Enabled = false;
                    gbManoDerecha.Enabled = false;
                }
            }
            catch (Exception)
            {
                solicitud = new Solicitud();
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Font = new Font(FontFamily.GenericSansSerif, 14.0F, FontStyle.Bold);
                lblMensaje.Text = "En espera de Solicitud.";
                lblNoSolicitud.Visible = false;

                btnCancelar.Enabled = false;
                btnCancelar.Imagen = Resources.btn_disabled;
                btnNumId.Enabled = false;
                btnNumId.Imagen = Resources.continuar_disabled;
                cbOficina.Enabled = false;
                cbProducto.Enabled = false;
                cbTipoIdentificacion.Enabled = false;
                txbNumeroIdentificacion.Enabled = false;

                gbManoIzquierda.Enabled = false;
                gbManoDerecha.Enabled = false;
            }
        }

        private void OcultarDedo(int iDedo, bool b)
        {
            try
            {
                string sbtnDedo = string.Format("btnDedo{0}", iDedo.ToString());
                var btnDedo = (Controles.Boton)this.Controls.Find(sbtnDedo, true).FirstOrDefault();
                btnDedo.Visible = b;
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlCapturaHuella : OcultarDedo";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void SeleccionarDedo(int iDedo, bool act)
        {
            try
            {
                //Cambiar la imagen del Botón
                string sbtnDedo = string.Format("btnDedo{0}", iDedo.ToString());
                var btnDedo = (Controles.Boton)this.Controls.Find(sbtnDedo, true).FirstOrDefault();

                if (act)//Activado o Desactivado
                {
                    if (HuellasObligatorias.Contains(iDedo.ToString()))
                    {
                        btnDedo.Imagen = Resources.end;
                        btnDedo.ImagenVisitada = Resources.end;
                        btnDedo.Tooltip = "Dedo Requerido";
                        btnDedo.Visible = true;
                    }
                    else
                    {
                        btnDedo.Imagen = Resources.endGris;
                        btnDedo.ImagenVisitada = Resources.endGris;
                        btnDedo.Tooltip = "Dedo Opcional";
                    }
                }
                else
                {
                    if (HuellasObligatorias.Contains(iDedo.ToString()))
                    {
                        btnDedo.Imagen = Resources.end_vacio;
                        btnDedo.ImagenVisitada = Resources.end_vacio;
                        btnDedo.ImagenSobre = Resources.end;
                        btnDedo.ImagenDesabilitado = Resources.end_vacio;
                        btnDedo.Tooltip = "Dedo Requerido";
                        btnDedo.Visible = true;
                    }
                    else
                    {
                        btnDedo.Imagen = Resources.endGris_vacio;
                        btnDedo.ImagenVisitada = Resources.endGris_vacio;
                        btnDedo.Tooltip = "Dedo Opcional";
                    }
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlCapturaHuella : SeleccionarDedo";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }

        //TODO: Serfinansas
        private void timerSolicitud_Tick(object sender, EventArgs e)
        {
            ObtenerSoliciudEnproceso();
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var tmenu = (ToolStripMenuItem)sender;
                int iDedo = Convert.ToInt32(tmenu.Name.Substring(0, 1));

                if (tmenu.Text == "Eliminar")
                {
                    //Eliminar Huellas
                    Dedos.RemoveAll(x => x.NumeroDedo == iDedo);

                    //Eliminar btn dedo
                    SeleccionarDedo(iDedo, false);

                    //Eliminar foto
                    CargarHuellaCapturada(iDedo, null);

                    //Cargar menu
                    if (HuellasObligatorias.Contains(iDedo.ToString()))
                    {
                        HabilitarMenuDedo(iDedo, true, "Excepción");
                    }
                    else
                    {
                        HabilitarMenuDedo(iDedo, false, string.Empty);
                    }
                }
                else if (tmenu.Text == "Excepción")
                {
                    //Eliminar lista de Obligatorias
                    HuellasObligatorias.RemoveAll(x => x == iDedo.ToString());

                    //Eliminar Huellas
                    Dedos.RemoveAll(x => x.NumeroDedo == iDedo);

                    //Eliminar btn dedo
                    SeleccionarDedo(iDedo, false);

                    //Eliminar btn dedo
                    OcultarDedo(iDedo, false);

                    //Eliminar foto
                    CargarHuellaCapturada(iDedo, null);

                    //Cargar menu
                    HabilitarMenuDedo(iDedo, false, string.Empty);

                    //Habilita Opcionales
                    CargarOpcionales();
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlCapturaHuella : OcultarDedo";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void txbNumeroIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnNumId.Imagen = Resources.continuarSobre;
                Application.DoEvents();
                btnNumId_EventoClick(null, null);
            }

            if (e.KeyChar == '\b')
            {
                return;
            }

            if (!char.IsNumber(e.KeyChar)) { e.Handled = true; }
        }

        //TODO: Serfinansas
        private void ubicarControles()
        {
            gbxSolicitud.Visible = true;
            this.label1.Location = new Point(21, 154);
            this.cbOficina.Location = new Point(24, 175);
            this.lblServicio.Location = new Point(21, 207);
            this.cbProducto.Location = new Point(24, 228);
            this.lblTipoIdentificacion.Location = new Point(21, 257);
            this.cbTipoIdentificacion.Location = new Point(24, 278);
            this.lblNumeroIdentificacion.Location = new Point(21, 308);
            this.txbNumeroIdentificacion.Location = new Point(24, 329);
            this.btnNumId.Location = new Point(262, 329);
            this.btnValidar.Location = new Point(30, 361);
        }
    }
}
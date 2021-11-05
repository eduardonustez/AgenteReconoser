using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
using Utilidades;
using System.Globalization;
using Entidades.Parametrizacion;
using WCFBanco.ServicioFachadaOlimpia;
using System.Runtime.Caching;
using System.Web;

namespace WCFBanco
{
    public class ServicioBanco : IServicioBanco
    {
        private static IServicioColpatria ServicioFachada = new ServicioColpatriaClient();

        #region Biometria

        public ParametrosBiometria_TiposDoc ObtenerBiometrias(int _IdCliente, Guid _IdConvenioAutenticacion)
        {
            return Biometria.ObtenerBiometrias(_IdCliente, _IdConvenioAutenticacion);
        }

        public LogOperaciones VerificarIdentidad(int _IdCliente, Guid _IdConvenioAutenticacion, string UsuarioLogin, string IdOficina, int IdProducto, string _Tramite, string Sigla,
            string NumeroDocumento, List<HuellaAFI> Dedos, string IP, string MAC, string _Serial, long _IdAutorizacion)
        {
            IP = HttpContext.Current.Request.UserHostAddress;
            Parametrizacion par = new Parametrizacion();
            Entidades.LogOperaciones LO = new Entidades.LogOperaciones();

            try
            {
                var p = par.ConsultarTodosParametros(false);
                DateTime Ya = DateTime.Now;

                string sInicio = p.Lista.FirstOrDefault(x => x.Parametro == "HoraInicionOperacion").Valor.ToString();
                string sFin = p.Lista.FirstOrDefault(x => x.Parametro == "HorafinOperacion").Valor.ToString();

                DateTime inicioOperacion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(sInicio.Substring(0, 2)), Convert.ToInt32(sInicio.Substring(3, 2)), Convert.ToInt32(sInicio.Substring(6, 2)));
                DateTime finOperacion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(sFin.Substring(0, 2)), Convert.ToInt32(sFin.Substring(3, 2)), Convert.ToInt32(sFin.Substring(6, 2)));

                if (!(Ya >= inicioOperacion && Ya <= finOperacion))
                {
                    LO.DescripcionError = "La aplicación se encuentra por fuera del horario de operación";
                    LO.IdOperacion = 0;
                    return LO;
                }
            }
            catch (Exception ex)
            {
                LO.DescripcionError = "La aplicación se encuentra por fuera del horario de operación";
                LO.IdOperacion = 0;
                return LO;
            }

            if (System.Configuration.ConfigurationManager.AppSettings.Get("HashHuellas") == "true")
            {
                //Valida si existe una huella totalmente igual en caché
                ObjectCache Cache = MemoryCache.Default;
                if (Cache.Contains("DocVSHuellas"))
                {
                    var v = (List<DocVSHuellas>)Cache["DocVSHuellas"];

                    foreach (Entidades.HuellaAFI AuxHuella in Dedos)
                    {
                        var auxhash = Utilidades.UtilidadesHuellas.sha256_hash(AuxHuella.Template);

                        if (v.Where(x => x.Huella == auxhash).Count() > 0)
                        {
                            //error de inyeccion
                            LO.DescripcionError = "Error de inyección de huella";
                            LO.IdOperacion = 0;
                            return LO;
                        }
                        else
                        {
                            v.Add(new DocVSHuellas { Documento = NumeroDocumento, Huella = auxhash });
                        }
                    }
                    //guardar huella en cache
                    Cache.Add("DocVSHuellas", v, DateTime.Now.AddHours(6));
                }
                else
                {
                    List<DocVSHuellas> LDH = new List<DocVSHuellas>();
                    Dedos.ForEach(x => LDH.Add(new DocVSHuellas { Documento = NumeroDocumento, Huella = Utilidades.UtilidadesHuellas.sha256_hash(x.Template) }));
                    Cache.Add("DocVSHuellas", LDH, DateTime.Now.AddHours(6));
                }
            }

            var res = Biometria.VerificarIdentidad(_IdCliente, _IdConvenioAutenticacion, UsuarioLogin, IdProducto, _Tramite, Sigla, NumeroDocumento, Dedos, IP, MAC, _IdAutorizacion);

            string strDedosUnion = "";

            //Respuesta a entidad LogOperaciones
            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                if (res.EstadoPeticion == "COMPLETA")
                {
                    long IdOperacion = 0;
                    if (res.Resultado == "HIT")
                    {
                        int index = res.Candidato.ExpFecha.IndexOf(" ");
                        string fecha = res.Candidato.ExpFecha.Remove(index);

                        LO.Accion = "Validación de huella";
                        LO.Fecha = res.Fecharespuesta;
                        try
                        {
                            LO.FechaExpedicion = Convert.ToDateTime(fecha);
                        }
                        catch (Exception)
                        {
                            LO.FechaExpedicion = new DateTime(2000, 1, 1);
                        }
                        LO.IdProducto = IdProducto;
                        LO.TipoDocumento = Sigla;
                        LO.Documento = NumeroDocumento;
                        LO.PrimerApellido = res.Candidato.PrimerApellido;
                        LO.PrimerNombre = res.Candidato.PrimerNombre;
                        LO.SegundoApellido = res.Candidato.SegundoApellido;
                        LO.SegundoNombre = res.Candidato.SegundoNombre;
                        LO.Vigencia = res.Candidato.Vigencia;
                        LO.Sigla = Sigla;
                        LO.UsuarioLogin = UsuarioLogin;
                        LO.IdOficina = IdOficina;

                        //Campos adicionales
                        LO.IP = IP;
                        LO.MAC = MAC;
                        LO.Serial = _Serial;
                        LO.IdAutorizacion = _IdAutorizacion;
                        LO.IdPeticion = res.IdPeticion;

                        List<Entidades.HuellaAFI> LHA = new List<Entidades.HuellaAFI>();
                        var biomes = res.Biometrias.Where(x => x.IdTipo == 2).ToList();

                        foreach (BiometriaRespuesta BR in biomes)
                        {
                            LHA.Add(new Entidades.HuellaAFI
                            {
                                NumeroDedo = BR.IdSubtipo,
                                NombreDedo = Utilidades.UtilidadesHuellas.NombreDedo(BR.IdSubtipo),
                                RespuestaAFI = BR.Resultado,
                                Score = BR.Score,
                                Error = BR.Error
                            });

                            LO.NombreDedo = Utilidades.UtilidadesHuellas.NombreDedo(BR.IdSubtipo);
                            LO.NumeroDedo = BR.IdSubtipo;
                            strDedosUnion += BR.IdSubtipo;
                            //LO.RespuestaAFI = BR.Resultado;
                            LO.RespuestaAFI = res.Resultado;
                        }

                        IdOperacion = Reportes.InsertarLogOperaciones(LO, strDedosUnion);

                        LO.IdOperacion = IdOperacion;
                        LO.RespuestaAFI = res.Resultado;
                        LO.HA = LHA;
                    }
                    else
                    {
                        LO.Accion = "Validación de huella";
                        LO.Fecha = DateTime.Now;
                        LO.IdProducto = IdProducto;
                        LO.TipoDocumento = Sigla;
                        LO.Sigla = Sigla;
                        LO.Documento = NumeroDocumento;
                        LO.UsuarioLogin = UsuarioLogin;
                        LO.FechaExpedicion = DateTime.MinValue;
                        LO.IdOficina = IdOficina;

                        //Campos adicionales
                        LO.IP = IP;
                        LO.MAC = MAC;
                        LO.Serial = _Serial;
                        LO.IdAutorizacion = _IdAutorizacion;
                        LO.IdPeticion = res.IdPeticion;

                        List<Entidades.HuellaAFI> LHA = new List<Entidades.HuellaAFI>();
                        var biomes = res.Biometrias.Where(x => x.IdTipo == 2).ToList();

                        foreach (BiometriaRespuesta BR in biomes)
                        {
                            LHA.Add(new Entidades.HuellaAFI
                            {
                                NumeroDedo = BR.IdSubtipo,
                                NombreDedo = Utilidades.UtilidadesHuellas.NombreDedo(BR.IdSubtipo),
                                RespuestaAFI = BR.Resultado,
                                Score = BR.Score,
                                Error = BR.Error
                            });

                            LO.NombreDedo = Utilidades.UtilidadesHuellas.NombreDedo(BR.IdSubtipo);
                            LO.NumeroDedo = BR.IdSubtipo;
                            strDedosUnion += BR.IdSubtipo;
                            LO.RespuestaAFI = BR.Resultado;
                        }

                        //Todas son no HIT
                        LO.RespuestaAFI = "NOHIT";
                        IdOperacion = Reportes.InsertarLogOperaciones(LO, strDedosUnion);


                        LO.IdOperacion = IdOperacion;
                        LO.RespuestaAFI = res.Resultado;
                        LO.HA = LHA;
                    }
                }
                else
                {
                    LO.CodigoError = res.CodigoError;
                    LO.DescripcionError = res.DescripcionError;
                }
            }
            else
            {
                LO.CodigoError = res.CodigoError;
                LO.DescripcionError = res.DescripcionError;

                LO.Accion = "Validación de huella";
                LO.Fecha = DateTime.Now;
                LO.IdProducto = IdProducto;
                LO.TipoDocumento = Sigla;
                LO.Sigla = Sigla;
                LO.Documento = NumeroDocumento;
                LO.UsuarioLogin = UsuarioLogin;
                LO.FechaExpedicion = DateTime.MinValue;
                LO.IdOficina = IdOficina;

                //Campos adicionales
                LO.IP = IP;
                LO.MAC = MAC;
                LO.Serial = _Serial;
                LO.IdAutorizacion = _IdAutorizacion;
                LO.IdPeticion = res.IdPeticion;

                LO.NumeroDedo = 1;
                LO.RespuestaAFI = "NOHIT";

                foreach (var BR in Dedos)
                {
                    strDedosUnion += BR.NumeroDedo;
                }

                Reportes.InsertarLogOperaciones(LO, strDedosUnion);

            }

            return LO;
        }

        public long CrearAutorizacionCandidato(bool acepta, byte[] DocumentoAutorizacion, string _IdOficina, int _IdProducto, byte[] ImagenHuella, string _Ip, string _Usuario, string _Documento, string _Sigla, byte[] TemplateHuella)
        {
            _Ip = HttpContext.Current.Request.UserHostAddress;
            return Biometria.CrearAutorizacionCandidato(acepta, DocumentoAutorizacion, _IdOficina, _IdProducto, ImagenHuella, _Ip, _Usuario, _Documento, _Sigla, TemplateHuella);
        }

        #endregion

        #region LogOperaciones

        public List<LogOperaciones> SeleccionarLogOperaciones(long? IdOperacion, DateTime? FechaInicio, DateTime? FechaFin, string Documento, string UsuarioLogin, string RespuestaAFI, string IdOficina)
        {
            if (UtilidadesFecha.EsmayorAB((DateTime)FechaInicio, (DateTime)FechaFin))
                return null;

            if (UtilidadesFecha.CantidadDias((DateTime)FechaInicio, (DateTime)FechaFin))
                return null;

            List<LogOperaciones> LLO;
            LLO = Reportes.SeleccionarLogOperaciones(IdOperacion, FechaInicio, FechaFin, Documento, UsuarioLogin, RespuestaAFI, IdOficina);
            return LLO;
        }

        public List<Entidades.TransaccionesOficina> SeleccionarLogTransacciones(long? IdOperacion, DateTime? FechaInicio, DateTime? FechaFin, string Documento, string UsuarioLogin, string RespuestaAFI)
        {
            if (UtilidadesFecha.EsmayorAB((DateTime)FechaInicio, (DateTime)FechaFin))
                return null;

            if (UtilidadesFecha.CantidadDias((DateTime)FechaInicio, (DateTime)FechaFin))
                return null;

            List<Entidades.TransaccionesOficina> LLO;
            LLO = Reportes.SeleccionarLogOperacionesTransaccion(IdOperacion, FechaInicio, FechaFin, Documento, UsuarioLogin, RespuestaAFI);
            return LLO;
        }

        #endregion

        #region Autenticar

        public UsuarioLogin IsAuthenticated(string Dominio, string Usuario, string Password, string MAC)
        {
            List<UsuarioLoginCache> ULC = new List<UsuarioLoginCache>();
            Parametrizacion par = new Parametrizacion();

            //string IP = HttpContext.Current.Request.UserHostAddress;
            string IP = HttpContext.Current.Request.GetClientIp();
            System.Diagnostics.Trace.WriteLine("[DFZ710] IP: " + IP);


            DateTime Ya = DateTime.Now;
            int IdSucursal;

            try
            {
                var p = par.ConsultarTodosParametros(false);

                string aux = p.Lista.FirstOrDefault(x => x.Parametro == "SucursalDefecto").Valor;
                IdSucursal = string.IsNullOrEmpty(aux) ? 1 : Convert.ToInt32(aux);

                string sInicio = p.Lista.FirstOrDefault(x => x.Parametro == "HoraInicionOperacion").Valor.ToString();
                string sFin = p.Lista.FirstOrDefault(x => x.Parametro == "HorafinOperacion").Valor.ToString();

                DateTime inicioOperacion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(sInicio.Substring(0, 2)), Convert.ToInt32(sInicio.Substring(3, 2)), Convert.ToInt32(sInicio.Substring(6, 2)));
                DateTime finOperacion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(sFin.Substring(0, 2)), Convert.ToInt32(sFin.Substring(3, 2)), Convert.ToInt32(sFin.Substring(6, 2)));

                if (!(Ya >= inicioOperacion && Ya <= finOperacion))
                {
                    InsertarIngreso(Usuario, Ya, IP, MAC, IdSucursal, false);
                    throw new Exception("La aplicación no puede iniciar, debido a que está por fuera del horario de operación.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {
                //Valida si el usuario está en cache
                ObjectCache Cache = MemoryCache.Default;

                if (Cache.Contains("UsuarioLoginCache"))
                {
                    ULC = (List<UsuarioLoginCache>)Cache["UsuarioLoginCache"];

                    if (ULC.Count == 0)
                    {
                        UsuarioLoginCache L = new UsuarioLoginCache();
                        L.IP = IP;
                        L.Login = Usuario;
                        L.Fecha = Ya;
                        ULC.Add(L);

                        Cache.Remove("UsuarioLoginCache");
                        Cache.Add("UsuarioLoginCache", ULC, DateTime.Now.AddHours(6));
                    }
                    else
                    {
                        foreach (UsuarioLoginCache aux in ULC)
                        {
                            if (aux.Login.ToUpper() == Usuario.ToUpper())
                            {
                                //Si es IP diferente y se logueó hace menos de una hora, no permite
                                if (aux.IP != IP)
                                {
                                    if (DateTime.Now.AddHours(1) > aux.Fecha)
                                    {
                                        throw new Exception("El usuario ya se encuentra registrado en el sistema.");
                                    }
                                    else
                                    {
                                        aux.IP = IP;
                                        aux.Fecha = Ya;
                                    }
                                }
                                else
                                {
                                    aux.Fecha = Ya;
                                }
                                Cache.Remove("UsuarioLoginCache");
                                Cache.Add("UsuarioLoginCache", ULC, DateTime.Now.AddHours(6));
                            }
                        }
                    }
                }
                else
                {
                    UsuarioLoginCache L = new UsuarioLoginCache();
                    L.IP = IP;
                    L.Login = Usuario;
                    L.Fecha = Ya;
                    ULC.Add(L);

                    Cache.Add("UsuarioLoginCache", ULC, DateTime.Now.AddHours(6));
                }

                Utilidades.AutenticacionLDAP ALDAP = new AutenticacionLDAP();
                UsuarioLogin UL = new UsuarioLogin();
                bool res = ALDAP.IsAuthenticated(Dominio, Usuario, Password);
                if (res)
                {
                    UsuarioVM user = this.ValidarUsuario(Usuario);
                    if (user != null)
                    {
                        ALDAP.ObtenerPropiedades(Usuario);
                        UL.Usuario = Usuario;
                        UL.DisplayName = ALDAP.DisplayName;
                        UL.Dominio = Dominio;
                        UL.EsValido = true;
                        UL.Imagen = (Bitmap)ALDAP.Imagen;
                        UL.Mail = ALDAP.Mail;
                        UL.Title = ALDAP.Title;
                        UL.IdRol = user.IdRol;
                        UL.CodigoRol = user.CodigoRol;
                        UL.IdOficina = user.IdOficina;

                        UL.IdAutenticacion = InsertarIngreso(Usuario, Ya, IP, MAC, IdSucursal, true);
                        return UL;
                    }
                    else
                        throw new Exception("El usuario no se encuentra registrado en el sistema.");
                }

                InsertarIngreso(Usuario, Ya, IP, MAC, IdSucursal, false);
                UL.EsValido = false;
                return UL;
            }
            catch (Exception ex)
            {
                InsertarIngreso(Usuario, Ya, IP, MAC, IdSucursal, false);
                throw new Exception(ex.Message);
            }
        }

        private UsuarioVM ValidarUsuario(string usuario)
        {
            var respuesta = ServicioFachada.ConsultarUsuarioPorId(usuario, true);
            return respuesta.Entidad;
        }

        #endregion

        #region LogIngresos

        public long InsertarIngreso(string usuarioLogin, DateTime fecha, string ip, string mac, long idSucursal, Boolean exitoso)
        {
            ip = HttpContext.Current.Request.UserHostAddress;
            long id = 0;
            LogAutenticacionVM LI = new LogAutenticacionVM();
            LI.UsuarioLogin = usuarioLogin;
            LI.FechaIngreso = fecha;
            LI.IpTerminal = ip;
            LI.MacTerminal = mac;
            LI.IdOficina = "Oficina " + idSucursal.ToString();
            LI.Exitoso = exitoso;

            id = Reportes.InsertarLogIngresos(LI);
            return id;
        }

        public List<NewLogIngresos> ObtenerIngresosAplicacion(string fechaIngreso, string fechaFin, string usuario, string ip, bool? estado)
        {            
            if (UtilidadesFecha.EsmayorAB(Convert.ToDateTime(fechaIngreso), Convert.ToDateTime(fechaFin)))
                return null;

            if (UtilidadesFecha.CantidadDias(Convert.ToDateTime(fechaIngreso), Convert.ToDateTime(fechaFin)))
                return null;

            return Reportes.ObtenerLogIngresos(fechaIngreso, fechaFin, usuario, ip, estado);
        }

        public void ActualizarSalidaAplicacion(long idAutenticacion, string usuario)
        {
            List<UsuarioLoginCache> ULC = new List<UsuarioLoginCache>();
            ObjectCache Cache = MemoryCache.Default;

            if (Cache.Contains("UsuarioLoginCache"))
            {
                ULC = (List<UsuarioLoginCache>)Cache["UsuarioLoginCache"];
                ULC.RemoveAll(x => x.Login.ToUpper() == usuario.ToUpper());
                Cache.Remove("UsuarioLoginCache");
                Cache.Add("UsuarioLoginCache", ULC, DateTime.Now.AddHours(6));
            }

            Reportes.ActualizarSalidaAplicacion(idAutenticacion);
        }

        #endregion

        #region LogTiemposRespuesta

        static async void ProcessDataAsync(string metodo, string[] parametros, string capa, DateTime FechaInicio, DateTime FechaFin, string duracion, string ip, Guid grupo)
        {
            /*string parametrosArray;
            if (parametros != null)
            {
                parametrosArray = string.Join(",", parametros);
            }
            else
            {
                parametrosArray = null;
            }

            LogTiempoRespuesta log = new LogTiempoRespuesta();

            log.Metodo = metodo;
            log.Parametros = parametrosArray;
            log.Capa = capa;
            log.FechaInicio = FechaInicio;
            log.FechaFin = FechaFin;
            log.Duracion = duracion;
            log.Ip = ip;
            log.Grupo = grupo;


            ReporteTiempoRespuesta respuesta = new ReporteTiempoRespuesta();
            respuesta.InsertarLogTiemposRespuesta(log);

            await Task.Delay(100);*/
        }

        public List<LogTiempoRespuesta> ObtenerTiemposRespuesta(string fechaIngreso, string fechaFin)
        {
            if (UtilidadesFecha.EsmayorAB(Convert.ToDateTime(fechaIngreso), Convert.ToDateTime(fechaFin)))
                return null;

            if (UtilidadesFecha.CantidadDias(Convert.ToDateTime(fechaIngreso), Convert.ToDateTime(fechaFin)))
                return null;

            return Reportes.ObtenerTiemposRespuesta(fechaIngreso, fechaFin);
        }
        #endregion

        #region LogErrores
        public List<LogErrores> ObtenerLogErrores(string fechaIngreso, string fechaFin, string usuario)
        {
            if (UtilidadesFecha.EsmayorAB(Convert.ToDateTime(fechaIngreso), Convert.ToDateTime(fechaFin)))
                return null;

            if (UtilidadesFecha.CantidadDias(Convert.ToDateTime(fechaIngreso), Convert.ToDateTime(fechaFin)))
                return null;

            return Reportes.ObtenerLogErrores(fechaIngreso, fechaFin, usuario);
        }

        public void InsertarLogError(LogErrores Error)
        {
            LogErrorVM LE = new LogErrorVM();
            LE.Capa = Error.Capa;
            LE.Descripcion = Error.Descripcion;
            LE.Fecha = Error.Fecha;
            LE.IdOficina = string.IsNullOrEmpty(Error.IdOficina) ? null : Error.IdOficina;
            LE.IpTerminal = Error.Ip;
            LE.MacTerminal = Error.Mac;
            LE.Metodo = Error.Metodo;
            LE.UsuarioLogin = Error.UsuarioLogin;

            Reportes.InsertarLogError(LE);
        }

        #endregion

        #region Dashboard

        public List<CantidadSolicitudes> ObtenerSolicitudesXAccion()
        {
            return DashBoard.ObtenerSolicitudesXAccion();
        }

        public List<RespuestaXsolicitud> RespuestaXsolicitud()
        {
            return DashBoard.RespuestaXsolicitud();
        }

        public List<TiemposDentroYFuera> TiemposDentroYFuera()
        {
            return DashBoard.TiemposDentroYFuera();
        }

        public List<SolicitudesAprobadassXServicio> SolicitudesAprobadassXServicio(string fechaInicio, string fechaFin)
        {
            if (UtilidadesFecha.EsmayorAB(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin)))
                return null;

            if (UtilidadesFecha.CantidadDias(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin)))
                return null;

            return DashBoard.SolicitudesAprobadassXServicio(fechaInicio, fechaFin);
        }

        public List<SolicitudesAprobadassVSNoAprobadas> SolicitudesAprobadassVSNoAprobadas(string fechaInicio, string fechaFin)
        {
            if (UtilidadesFecha.EsmayorAB(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin)))
                return null;

            if (UtilidadesFecha.CantidadDias(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin)))
                return null;

            return DashBoard.SolicitudesAprobadassVSNoAprobadas(fechaInicio, fechaFin);
        }

        public List<HitsVSNoHitsXDias> HitsVSNoHitsXDias(int dias)
        {
            if (dias > 31)
                return null;

            return DashBoard.HitsVSNoHitsXDias(dias);
        }

        public int AprobadosHoy(string fechaInicio, string fechaFin)
        {
            if (UtilidadesFecha.EsmayorAB(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin)))
                return 0;

            if (UtilidadesFecha.CantidadDias(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin)))
                return 0;

            return DashBoard.AprobadosHoy(fechaInicio, fechaFin);
        }

        public int NoAprobadosHoy(string fechaInicio, string fechaFin)
        {
            if (UtilidadesFecha.EsmayorAB(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin)))
                return 0;

            if (UtilidadesFecha.CantidadDias(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin)))
                return 0;

            return DashBoard.NoAprobadosHoy(fechaInicio, fechaFin);
        }

        public int AprobadosHoyAsesor(string fechaInicio, string fechaFin, string _Asesor)
        {
            if (UtilidadesFecha.EsmayorAB(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin)))
                return 0;

            if (UtilidadesFecha.CantidadDias(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin)))
                return 0;

            return DashBoard.AprobadosHoyAsesor(fechaInicio, fechaFin, _Asesor);
        }

        public int NoAprobadosHoyAsesor(string fechaInicio, string fechaFin, string _Asesor)
        {
            if (UtilidadesFecha.EsmayorAB(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin)))
                return 0;

            if (UtilidadesFecha.CantidadDias(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin)))
                return 0;

            return DashBoard.NoAprobadosHoyAsesor(fechaInicio, fechaFin, _Asesor);
        }

        public List<HitsVSNoHitsXDias> HitsVSNoHitsXDiasAsesor(int dias, string _Asesor)
        {
            if (dias > 31)
                return null;

            return DashBoard.HitsVSNoHitsXDiasAsesor(dias, _Asesor);
        }
        #endregion

        #region FormatoProteccionDatos
        public RespuestaFormatos ObtenerFormatoProteccionDatos(int idCliente, Guid idConvenioautenticacion)
        {
            RespuestaFormatos formatos = new RespuestaFormatos();

            var res = ServicioFachada.ObtenerFormatoProteccionDatos(idCliente, idConvenioautenticacion);

            if (res != null)
            {
                formatos.IdFormato = res.IdFormato;
                formatos.Nombre = res.Nombre;
                formatos.Formato = res.Formato;
                formatos.Archivo = res.Archivo;
                formatos.ArchivoRechazo = res.ArchivoRechazo;
            }

            return formatos;
        }

        public List<Entidades.FormatoProteccion> ConsultarAceptaNoAcepta(DateTime fechaInicio, DateTime fechaFin, string usuario, string Oficina, string numeroDocumento, string oficinaOrigen)
        {
            if (UtilidadesFecha.EsmayorAB(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin)))
                return null;

            if (UtilidadesFecha.CantidadDias(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin)))
                return null;

            return Reportes.ConsultarAceptaNoAcepta(fechaInicio, fechaFin, usuario, Oficina, numeroDocumento, oficinaOrigen);
        }
        #endregion
    }
}
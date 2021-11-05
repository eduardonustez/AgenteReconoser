using ContingenciaOperador;
using Entidades;
using Entidades.Parametrizacion;
using Olimpia.Servicios.ServicioFachadaZeus;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Utilidades;

namespace Olimpia.Servicios
{
    public class ConsumirServicio
    {
        private static RSACryptoServiceProvider cert = (RSACryptoServiceProvider)new X509Certificate2(Properties.Resources.client, "Olimpia.2017").PrivateKey;
        private static IServicioFachadaZeus ServicioFachada = new ServicioFachadaZeusClient();
        public ConsumirServicio()
        {
        }

        #region Biometria

        public long CrearAutorizacionCandidato(bool acepta, byte[] DocumentoAutorizacion, string _IdOficina, int _IdProducto, byte[] ImagenHuella, string _Ip, string _Usuario, string _Documento, string _Sigla, byte[] TemplateHuella, int idCliente, Guid idConvenio, Guid? IdPeticion = null)
        {
            ObtenerIP ObtenerIP = new ObtenerIP();
            _Ip = ObtenerIP.GetIP();
            return Biometria.CrearAutorizacionCandidato(acepta, DocumentoAutorizacion, _IdOficina, _IdProducto, ImagenHuella, _Ip, _Usuario, _Documento, _Sigla, TemplateHuella, idCliente, idConvenio, IdPeticion);
        }

        public ParametrosBiometria_TiposDoc ObtenerBiometrias(int _IdCliente, Guid _IdConvenioAutenticacion)
        {
            return Biometria.ObtenerBiometrias(_IdCliente, _IdConvenioAutenticacion);
        }

        public LogOperaciones VerificarIdentidad(int _IdCliente, Guid _IdConvenioAutenticacion, string UsuarioLogin, string IdOficina, int IdProducto, string _Tramite, string Sigla,
            string NumeroDocumento, List<HuellaAFI> Dedos, string IP, string MAC, string _Serial, string _Marca, string _Modelo, int _Tipo, long _IdAutorizacion, int IdServicio, Guid IdPeticion)
        {
            ObtenerIP ObtenerIP = new ObtenerIP();
            IP = ObtenerIP.GetIP();
            LogOperaciones LO = new LogOperaciones();

            string metodo = "obtenerBiometricoActivo";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = Encoding.UTF8.GetBytes(_Serial)
                .Concat(Encoding.UTF8.GetBytes(_Marca))
                .Concat(Encoding.UTF8.GetBytes(_Modelo))
                .Concat(BitConverter.GetBytes(_Tipo))
                .Concat(Encoding.UTF8.GetBytes(MAC))
                .Concat(BitConverter.GetBytes(_IdCliente))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));
            var biometrico = ServicioFachada.obtenerBiometricoActivo(_Serial, _Marca, _Modelo, _Tipo, MAC, _IdCliente, ticks, firma);

            if (biometrico == null || biometrico.Estado != RespuestaEstadoRespuesta.Ok || !biometrico.Habilitado)
            {
                if (biometrico == null)
                {
                    LO.DescripcionError = "La maquina no existe";
                    LO.IdOperacion = 0;
                }
                else if (biometrico.CodigoError == "NMAQ")
                {
                    LO.DescripcionError = "La maquina no existe o está bloqueada";
                    LO.IdOperacion = 0;
                }
                else
                {
                    LO.DescripcionError = "El dispositivo biométrico se encuentra bloqueado";
                    LO.IdOperacion = 0;
                }
                return LO;
            }            

            var res = Biometria.VerificarIdentidad(_IdCliente, _IdConvenioAutenticacion, UsuarioLogin, IdProducto, _Tramite, Sigla, NumeroDocumento, Dedos, IP, MAC, _IdAutorizacion, IdPeticion);

            string strDedosUnion = "";

            //Respuesta a entidad LogOperaciones
            if (res.Estado == RespuestaEstadoRespuesta.Ok)
            {
                if (res.EstadoPeticion == "COMPLETA")
                {
                    long IdOperacion = 0;
                    if (res.Resultado == "HIT")
                    {
                        LO.Accion = "Validación de huella";
                        LO.Fecha = res.Fecharespuesta;
                        try
                        {
                            int index = res.Candidato.ExpFecha.IndexOf(" ");
                            string fecha = res.Candidato.ExpFecha.Remove(index);

                            LO.FechaExpedicion = Convert.ToDateTime(fecha);
                        }
                        catch (Exception)
                        {
                            LO.FechaExpedicion = new DateTime(2000, 1, 1);
                        }
                        LO.IdProducto = IdProducto;
                        LO.IdServicio = IdServicio;
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

                        List<HuellaAFI> LHA = new List<HuellaAFI>();
                        var biomes = res.Biometrias.Where(x => x.IdTipo == 2).ToList();

                        foreach (BiometriaRespuesta BR in biomes)
                        {
                            LHA.Add(new HuellaAFI
                            {
                                NumeroDedo = BR.IdSubtipo,
                                NombreDedo = UtilidadesHuellas.NombreDedo(BR.IdSubtipo),
                                RespuestaAFI = BR.Resultado,
                                Score = BR.Score,
                                Error = BR.Error
                            });

                            LO.NombreDedo = UtilidadesHuellas.NombreDedo(BR.IdSubtipo);
                            LO.NumeroDedo = BR.IdSubtipo;
                            strDedosUnion += BR.IdSubtipo;
                            LO.RespuestaAFI = res.Resultado;
                        }

                        IdOperacion = Reportes.InsertarLogOperaciones(LO, strDedosUnion, _IdCliente);

                        LO.IdOperacion = IdOperacion;
                        LO.RespuestaAFI = res.Resultado;
                        LO.HA = LHA;
                    }
                    else
                    {
                        LO.Accion = "Validación de huella";
                        LO.Fecha = DateTime.Now;
                        LO.IdProducto = IdProducto;
                        LO.IdServicio = IdServicio;
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

                        List<HuellaAFI> LHA = new List<HuellaAFI>();
                        var biomes = res.Biometrias.Where(x => x.IdTipo == 2).ToList();

                        foreach (BiometriaRespuesta BR in biomes)
                        {
                            LHA.Add(new HuellaAFI
                            {
                                NumeroDedo = BR.IdSubtipo,
                                NombreDedo = UtilidadesHuellas.NombreDedo(BR.IdSubtipo),
                                RespuestaAFI = BR.Resultado,
                                Score = BR.Score,
                                Error = BR.Error
                            });

                            LO.NombreDedo = UtilidadesHuellas.NombreDedo(BR.IdSubtipo);
                            LO.NumeroDedo = BR.IdSubtipo;
                            strDedosUnion += BR.IdSubtipo;
                            LO.RespuestaAFI = BR.Resultado;
                        }

                        //Todas son no HIT
                        LO.RespuestaAFI = "NOHIT";
                        IdOperacion = Reportes.InsertarLogOperaciones(LO, strDedosUnion, _IdCliente);

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
                LO.IdServicio = IdServicio;
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
                LO.IdPeticion = IdPeticion;

                LO.NumeroDedo = 1;
                LO.RespuestaAFI = "NOHIT";

                foreach (var BR in Dedos)
                {
                    strDedosUnion += BR.NumeroDedo;
                }

                Reportes.InsertarLogOperaciones(LO, strDedosUnion, _IdCliente);
            }

            return LO;
        }
        #endregion Biometria

        private bool RegistraHallazgos
        {
            get
            {
                bool rh = false;
                bool.TryParse(ConfigurationManager.AppSettings["RegistraHallazgos"], out rh);
                return rh;
            }
        }

        public void InsertarHallazgoBiometrico(LogHallazgoBiometrico hallazgo, int idCliente)
        {
            if (!RegistraHallazgos || SwitchContingenciaUtil.OperadorAliadoActivo())
                return;
            try
            {
                HallazgoBiometrico HB = new HallazgoBiometrico();
                HB.Descripcion = hallazgo.Descripcion;
                HB.Fecha = hallazgo.Fecha;
                HB.IdOficina = string.IsNullOrEmpty(hallazgo.IdOficina) ? null : hallazgo.IdOficina;
                HB.IpTerminal = hallazgo.Ip;
                HB.MacTerminal = hallazgo.Mac;
                HB.Metodo = hallazgo.Metodo;
                HB.UsuarioLogin = hallazgo.UsuarioLogin;

                Reportes.InsertarLogHallazgoBiometrico(HB, idCliente);
            }
            catch (Exception ex)
            {
                //Log en disco
                string sFile = string.Format(@"{0}\LogReconoser.txt", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                using (var writer = new StreamWriter(sFile, true))
                {
                    writer.WriteLine("HALLAZGO NO REPORTADO:");
                    writer.WriteLine("\t" + ex.ToString());
                    writer.WriteLine("\tMetodo:\t" + hallazgo.Metodo);
                    writer.WriteLine("\tDescripcion:\t" + hallazgo.Descripcion);
                    writer.WriteLine("\tUsuario:\t" + hallazgo.UsuarioLogin);
                    writer.WriteLine("\tFecha:\t" + hallazgo.Fecha.ToString());
                }
            }
        }

        public void InsertarLogError(LogErrores Error, int idCliente)
        {
            try
            {
                if (!SwitchContingenciaUtil.OperadorAliadoActivo())
                {
                    ErrorAppEntrada LE = new ErrorAppEntrada();
                    LE.Capa = Error.Capa;
                    LE.Descripcion = Error.Descripcion;
                    LE.Fecha = Error.Fecha;
                    LE.IdOficina = string.IsNullOrEmpty(Error.IdOficina) ? null : Error.IdOficina;
                    LE.IpTerminal = Error.Ip;
                    LE.MacTerminal = Error.Mac;
                    LE.Metodo = Error.Metodo;
                    LE.UsuarioLogin = Error.UsuarioLogin;

                    Reportes.InsertarLogError(LE, idCliente);
                }
                else
                    LogEnDisco(Error, null);
            }
            catch (Exception ex)
            {
                LogEnDisco(Error, ex);
            }
        }

        private static string sFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogReconoser.txt");
        private void LogEnDisco(LogErrores Error, Exception ex)
        {
            using (var writer = new StreamWriter(sFile, true))
            {
                writer.WriteLine("ERROR NO REPORTADO:");
                if (ex != null)
                    writer.WriteLine("\t" + ex.ToString());
                writer.WriteLine("\tCapa:\t" + Error.Capa);
                writer.WriteLine("\tMetodo:\t" + Error.Metodo);
                writer.WriteLine("\tDescripcion:\t" + Error.Descripcion);
                writer.WriteLine("\tUsuario:\t" + Error.UsuarioLogin);
                writer.WriteLine("\tFecha:\t" + Error.Fecha.ToString());
            }
        }

        public RespuestaFormatos ObtenerFormatoProteccionDatos(int idCliente, Guid idConvenioautenticacion)
        {
            //Valida si el usuario está en cache
            ObjectCache Cache = MemoryCache.Default;

            if (Cache.Contains(idConvenioautenticacion.ToString()))
            {
                var resC = (RespuestaFormatos)Cache[idConvenioautenticacion.ToString()];

                if (resC != null)
                {
                    System.Diagnostics.Trace.WriteLine("DFZM FormatoAut en memoria");
                    return resC;
                }
            }

            RespuestaFormatos formatos = new RespuestaFormatos();

            string metodo = "ObtenerFormatoProteccionDatos";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = BitConverter.GetBytes(idCliente)
                .Concat(Encoding.UTF8.GetBytes(idConvenioautenticacion.ToString()))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

            var res = ServicioFachada.ObtenerFormatoProteccionDatos(idCliente, idConvenioautenticacion, ticks, firma);

            if (res != null)
            {
                formatos.IdFormato = res.IdFormato;
                formatos.Nombre = res.Nombre;
                formatos.Formato = res.Formato;
                formatos.Archivo = res.Archivo;
                formatos.ArchivoRechazo = res.ArchivoRechazo;
            }

            Cache.Add(idConvenioautenticacion.ToString(), formatos, DateTime.Now.AddMinutes(60));
            System.Diagnostics.Trace.WriteLine("DFZM FormatoAut NO!!! en memoria");

            return formatos;
        }

        public List<LogOperaciones> SeleccionarLogOperaciones(long? IdOperacion, DateTime? FechaInicio, DateTime? FechaFin, string Documento, string UsuarioLogin, string RespuestaAFI, string IdOficina, int IdCliente)
        {
            if (UtilidadesFecha.EsmayorAB((DateTime)FechaInicio, (DateTime)FechaFin))
            {
                return null;
            }

            if (UtilidadesFecha.CantidadDias((DateTime)FechaInicio, (DateTime)FechaFin))
            {
                return null;
            }

            List<LogOperaciones> LLO;
            LLO = Reportes.SeleccionarLogOperaciones(IdOperacion, FechaInicio, FechaFin, Documento, UsuarioLogin, RespuestaAFI, IdOficina, IdCliente);
            return LLO;
        }

        #region Autenticar

        public long CrearActualizarUsuario(Usuario usuario, int idCliente)
        {
            SolicitudUsuarioRNEC solicitud = new SolicitudUsuarioRNEC()
            {
                Area = usuario.Area,
                Cargo = usuario.Cargo,
                Habilitado = usuario.Habilitado,
                IdTipoIdentificacion = usuario.TipoIdentificacion,
                Login = usuario.usuario,
                Nombre = usuario.Nombre,
                NumeroIdentificacion = usuario.NumeroIdentificacion,
                IdCliente = idCliente
            };

            string metodo = "crearActualizarUsuarioRNEC";
            var ss = Newtonsoft.Json.JsonConvert.SerializeObject(solicitud).OrderBy(x => x).ToArray();
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = Encoding.UTF8.GetBytes(new string(ss))
                .Concat(Encoding.UTF8.GetBytes(usuario.IdOficina))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

            return ServicioFachada.crearActualizarUsuarioRNEC(solicitud, usuario.IdOficina, ticks, firma);
        }

        public UsuarioLogin IsAuthenticated(string Dominio, string Usuario, string Password, string MAC, bool UsuarioAdministrado, int idCliente)
        {
            bool res = false;
            AutenticacionLDAP ALDAP = new AutenticacionLDAP();
            UsuarioLogin UL = new UsuarioLogin();
            DateTime Ya = DateTime.Now;
            ObtenerIP ObtenerIP = new ObtenerIP();
            string IP = ObtenerIP.GetIP();
            System.Diagnostics.Trace.WriteLine("[DFZ710] IP: " + IP);
            string IdSucursal = null;
            RespuestaVerificacionUsuario resultadoVerificacion = null;

            RespuestaUsuario user = null;
            try
            {
                if (!UsuarioAdministrado)
                {
                    string serverLDAP = ConfigurationManager.AppSettings["IP"].Trim();

                    if (serverLDAP.Contains(":636"))
                    {
                        //Con SSL
                        res = ALDAP.IsAuthenticatedSSL(Dominio, ConfigurationManager.AppSettings["IP"], Usuario, Password);
                    }
                    else
                    {
                        //Sin SSL
                        res = ALDAP.IsAuthenticated(Dominio, Usuario, Password);
                    }
                    user = this.ValidarUsuario(Usuario, idCliente);
                }
                else
                {
                    SimpleAES simple = new SimpleAES();
                    string passCyph = simple.EncryptToString(Password);

                    string metodo = "verificarUsuario";
                    long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
                    byte[] data = Encoding.UTF8.GetBytes(Usuario)
                        .Concat(Encoding.UTF8.GetBytes(passCyph))
                        .Concat(BitConverter.GetBytes(idCliente))
                        .Concat(BitConverter.GetBytes(ticks))
                        .Concat(Encoding.UTF8.GetBytes(metodo))
                        .ToArray();

                    byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

                    resultadoVerificacion = ServicioFachada.verificarUsuario(Usuario, passCyph, idCliente, ticks, firma);
                    if (resultadoVerificacion != null)
                    {
                        res = resultadoVerificacion.Exitoso;

                        user = this.ValidarUsuario(Usuario, resultadoVerificacion.IdCliente);
                    }
                    else
                    {
                        res = false;
                    }
                }
                if (res)
                {
                    if (user != null)
                    {
                        UL.Usuario = Usuario;
                        UL.Dominio = Dominio;
                        UL.EsValido = true;
                        UL.IdRol = user.IdRol;
                        UL.CodigoRol = user.CodigoRol;
                        UL.IdOficina = user.IdOficina;
                        if (!UsuarioAdministrado)
                        {
                            ALDAP.ObtenerPropiedades(Usuario);

                            UL.Imagen = (Bitmap)ALDAP.Imagen;
                            UL.Mail = ALDAP.Mail;
                            UL.Title = ALDAP.Title;
                            UL.DisplayName = ALDAP.DisplayName;
                        }
                    }
                    else
                    {
                        throw new Exception("El usuario no se encuentra registrado en el sistema.");
                    }
                }

                var p = Parametrizacion.ConsultarTodosParametros(false, idCliente);

                string aux = p.Lista.FirstOrDefault(x => x.Parametro == "SucursalDefecto").Valor;
                IdSucursal = aux.Trim();

                string sInicio = p.Lista.FirstOrDefault(x => x.Parametro == "HoraInicionOperacion").Valor.ToString();
                string sFin = p.Lista.FirstOrDefault(x => x.Parametro == "HorafinOperacion").Valor.ToString();

                DateTime inicioOperacion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(sInicio.Substring(0, 2)), Convert.ToInt32(sInicio.Substring(3, 2)), Convert.ToInt32(sInicio.Substring(6, 2)));
                DateTime finOperacion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(sFin.Substring(0, 2)), Convert.ToInt32(sFin.Substring(3, 2)), Convert.ToInt32(sFin.Substring(6, 2)));

                if (!(Ya >= inicioOperacion && Ya <= finOperacion))
                {
                    InsertarIngreso(Usuario, Ya, IP, MAC, IdSucursal, false, idCliente);
                    throw new Exception("La aplicación no puede iniciar, debido a que está por fuera del horario de operación.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {
                if (res)
                {
                    UL.IdAutenticacion = InsertarIngreso(Usuario, Ya, IP, MAC, UL.IdOficina, true, idCliente);
                    return UL;
                }

                InsertarIngreso(Usuario, Ya, IP, MAC, IdSucursal, false, idCliente);
                UL.EsValido = false;
                return UL;
            }
            catch (Exception ex)
            {
                InsertarIngreso(Usuario, Ya, IP, MAC, IdSucursal, false, idCliente);
                throw new Exception(ex.Message);
            }
        }

        public RespuestaUsuario ValidarToken(string usuario, string token, int idCliente)
        {
            string metodo = "verificarToken";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = Encoding.UTF8.GetBytes(usuario)
                .Concat(Encoding.UTF8.GetBytes(token))
                .Concat(BitConverter.GetBytes(idCliente))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

            var respuesta = ServicioFachada.verificarToken(usuario, token, idCliente, ticks, firma);
            return respuesta;
        }

        public RespuestaUsuario ValidarUsuario(string usuario, int idCliente)
        {
            string metodo = "obtenerUsuarioActivo";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = Encoding.UTF8.GetBytes(usuario)
                .Concat(BitConverter.GetBytes(idCliente))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

            var respuesta = ServicioFachada.obtenerUsuarioActivo(usuario, idCliente, ticks, firma);
            return respuesta;
        }
        #endregion Autenticar

        #region LogIngresos

        public void ActualizarSalidaAplicacion(long idAutenticacion, string usuario, int idCliente)
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

            Reportes.ActualizarSalidaAplicacion(idAutenticacion, idCliente);
        }

        public long InsertarIngreso(string usuarioLogin, DateTime fecha, string ip, string mac, string idSucursal, bool exitoso, int idCliente)
        {
            ObtenerIP ObtenerIP = new ObtenerIP();
            string IP = ObtenerIP.GetIP();
            ip = ObtenerIP.GetIP();
            long id = 0;
            IngresoAppEntrada LI = new IngresoAppEntrada();
            LI.UsuarioLogin = usuarioLogin;
            LI.FechaIngreso = fecha;
            LI.IpTerminal = ip;
            LI.MacTerminal = mac;
            LI.IdOficina = idSucursal;
            LI.Exitoso = exitoso;

            id = Reportes.InsertarLogIngresos(LI, idCliente);
            return id;
        }
        #endregion LogIngresos
    }
}
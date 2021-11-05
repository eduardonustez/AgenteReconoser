using Entidades;
using Entidades.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Caching;

namespace WCFBanco
{
    public class ServicioParametrizacion : IServicioParametrizacion
    {
        private ServicioFachadaOlimpia.ServicioColpatriaClient sb = new ServicioFachadaOlimpia.ServicioColpatriaClient();

        #region Zonas
        public RespuestaListas<Zona> ConsultarTodosZonas(bool incluirNoHab)
        {
            RespuestaListas<Zona> Rl = new RespuestaListas<Zona>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaLogOfZonaVMmd83opfb Todos = sb.ConsultarTodosZonas();

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                List<WCFBanco.ServicioFachadaOlimpia.ZonaVM> Result = Todos.Lista.ToList();
                Rl.Lista = new List<Zona>();
                Result.ForEach(x =>
                    Rl.Lista.Add(new Zona
                    {
                        IdZona = x.IdZona,
                        Descripcion = x.Descripcion
                    }));
            }
            return Rl;
        }

        public RespuestaListas<Zona> ConsultarZonaPorId(string idZona)
        {
            RespuestaListas<Zona> Rl = new RespuestaListas<Zona>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaEntidadOfZonaVMmd83opfb Todos = sb.ConsultarZonaPorId(idZona);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                WCFBanco.ServicioFachadaOlimpia.ZonaVM Result = Todos.Entidad;
                Rl.Lista.Add(new Zona
                {
                    IdZona = Result.IdZona,
                    Descripcion = Result.Descripcion
                });
            }
            return Rl;
        }

        public long CrearActualizarZona(Zona Zona)
        {
            WCFBanco.ServicioFachadaOlimpia.ZonaVM Registo = new ServicioFachadaOlimpia.ZonaVM()
            {
                IdZona = Zona.IdZona,
                Descripcion = Zona.Descripcion
            };
            return sb.CrearActualizarZona(Registo);
        }

        public long EliminarZona(string idZona)
        {
            return sb.EliminarZona(idZona);
        }
        #endregion

        #region Oficinas
        public RespuestaListas<Oficina> ConsultarTodosOficinas(bool incluirNoHab)
        {
            RespuestaListas<Oficina> Rl = new RespuestaListas<Oficina>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaLogOfOficinaVMozTLvJBi Todos = sb.ConsultarTodosOficinas(incluirNoHab);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                List<WCFBanco.ServicioFachadaOlimpia.OficinaVM> Result = Todos.Lista.ToList();
                Rl.Lista = new List<Oficina>();
                Result.ForEach(x =>
                    Rl.Lista.Add(new Oficina
                    {
                        IdOficina = x.IdOficina,
                        IdZona = x.IdZona,
                        Direccion = x.Direccion,
                        Codigo = x.Codigo,
                        Ciudad = x.Ciudad,
                        Habilitado = x.Habilitado
                    }));
            }
            return Rl;
        }

        public RespuestaListas<Oficina> ConsultarOficinaPorId(string idOficina, bool activo)
        {
            RespuestaListas<Oficina> Rl = new RespuestaListas<Oficina>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaEntidadOfOficinaVMozTLvJBi Todos = sb.ConsultarOficinaPorId(idOficina, activo);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                WCFBanco.ServicioFachadaOlimpia.OficinaVM Result = Todos.Entidad;
                Rl.Lista.Add(new Oficina
                {
                    IdOficina = Result.IdOficina,
                    IdZona = Result.IdZona,
                    Direccion = Result.Direccion,
                    Codigo = Result.Codigo,
                    Ciudad = Result.Ciudad,
                    Habilitado = Result.Habilitado
                });
            }
            return Rl;
        }

        public long CrearActualizarOficina(Oficina Oficina)
        {
            WCFBanco.ServicioFachadaOlimpia.OficinaVM Registo = new ServicioFachadaOlimpia.OficinaVM()
            {
                IdOficina = Oficina.IdOficina,
                IdZona = Oficina.IdZona,
                Direccion = Oficina.Direccion,
                Codigo = Oficina.Codigo,
                Ciudad = Oficina.Ciudad,
                Habilitado = Oficina.Habilitado
            };
            return sb.CrearActualizarOficina(Registo);
        }

        public long CambiarEstadoOficina(string idOficina)
        {
            return sb.CambiarEstadoOficina(idOficina);
        }
        #endregion

        #region Roles
        public RespuestaListas<Rol> ConsultarTodosRoles(bool incluirNoHab)
        {
            RespuestaListas<Rol> Rl = new RespuestaListas<Rol>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaLogOfRolVMB_SOyXRSX Todos = sb.ConsultarTodosRoles(incluirNoHab);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                List<WCFBanco.ServicioFachadaOlimpia.RolVM> Result = Todos.Lista.ToList();
                Rl.Lista = new List<Rol>();
                Result.ForEach(x =>
                    Rl.Lista.Add(new Rol
                    {
                        IdRol = x.IdRol,
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        Habilitado = x.Habilitado
                    }));
            }
            return Rl;
        }

        public RespuestaListas<Rol> ConsultarRolPorId(int idRol, bool activo)
        {
            RespuestaListas<Rol> Rl = new RespuestaListas<Rol>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaEntidadOfRolVMB_SOyXRSX Todos = sb.ConsultarRolPorId(idRol, activo);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                WCFBanco.ServicioFachadaOlimpia.RolVM Result = Todos.Entidad;
                Rl.Lista.Add(new Rol
                {
                    IdRol = Result.IdRol,
                    Codigo = Result.Codigo,
                    Descripcion = Result.Descripcion,
                    Habilitado = Result.Habilitado
                });
            }
            return Rl;
        }

        public long CrearActualizarRol(Rol Rol)
        {
            WCFBanco.ServicioFachadaOlimpia.RolVM Registo = new ServicioFachadaOlimpia.RolVM()
            {
                IdRol = Rol.IdRol,
                Codigo = Rol.Codigo,
                Descripcion = Rol.Descripcion,
                Habilitado = Rol.Habilitado
            };
            return sb.CrearActualizarRol(Registo);
        }

        public long CambiarEstadoRol(int idRol)
        {
            return sb.CambiarEstadoRol(idRol);
        }
        #endregion

        #region Usuarios
        public RespuestaListas<Usuario> ConsultarTodosUsuarios(bool incluirNoHab)
        {
            RespuestaListas<Usuario> Rl = new RespuestaListas<Usuario>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaLogOfUsuarioVMGvIObl1R Todos = sb.ConsultarTodosUsuarios(incluirNoHab);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                List<WCFBanco.ServicioFachadaOlimpia.UsuarioVM> Result = Todos.Lista.ToList();
                Rl.Lista = new List<Usuario>();
                Result.ForEach(x =>
                    Rl.Lista.Add(new Usuario
                    {
                        IdUsuario = x.IdUsuario,
                        IdRol = x.IdRol,
                        Rol = x.CodigoRol,
                        Nombre = x.Nombre,
                        IdTipoIdentificacion = x.TipoIdentificacion,
                        TipoIdentificacion = x.TipoIdentificacion,
                        NumeroIdentificacion = x.NumeroIdentificacion,
                        IdOficina = x.IdOficina,
                        //FechaCreacion = x.FechaCreacion,
                        //UsuarioCreacion = x.UsuarioCreacion,
                        //FechaModificacion = x.FechaModificacion,
                        //UsuarioModificacion = x.UsuarioModificacion,
                        Area = x.Area,
                        Cargo = x.Cargo,
                        TipoAutenticacion = x.TipoAutenticacion,
                        Password = x.Password,
                        Habilitado = x.Habilitado
                    }));
            }
            return Rl;
        }

        public RespuestaListas<Usuario> ConsultarUsuarioPorId(string usuario, bool Activo)
        {
            RespuestaListas<Usuario> Rl = new RespuestaListas<Usuario>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaEntidadOfUsuarioVMGvIObl1R Todos = sb.ConsultarUsuarioPorId(usuario, Activo);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                WCFBanco.ServicioFachadaOlimpia.UsuarioVM Result = Todos.Entidad;
                Rl.Lista.Add(new Usuario
                {
                    IdUsuario = Result.IdUsuario,
                    IdRol = Result.IdRol,
                    Rol = Result.CodigoRol,
                    Nombre = Result.Nombre,
                    IdTipoIdentificacion = Result.TipoIdentificacion,
                    //TODO: Consultar
                    TipoIdentificacion = Result.TipoIdentificacion,
                    NumeroIdentificacion = Result.NumeroIdentificacion,
                    IdOficina = Result.IdOficina,
                    //FechaCreacion = Result.FechaCreacion,
                    //UsuarioCreacion = Result.UsuarioCreacion,
                    //FechaModificacion = Result.FechaModificacion,
                    //UsuarioModificacion = Result.UsuarioModificacion,
                    Area = Result.Area,
                    Cargo = Result.Cargo,
                    TipoAutenticacion = Result.TipoAutenticacion,
                    Password = Result.Password,
                    Habilitado = Result.Habilitado
                });
            }
            return Rl;
        }

        public long CrearActualizarUsuario(Usuario Usuario)
        {
            WCFBanco.ServicioFachadaOlimpia.UsuarioVM Registo = new ServicioFachadaOlimpia.UsuarioVM()
            {
                IdUsuario = Usuario.IdUsuario,
                IdRol = Usuario.IdRol,
                Nombre = Usuario.Nombre,
                TipoIdentificacion = Usuario.TipoIdentificacion.ToString(),
                NumeroIdentificacion = Usuario.NumeroIdentificacion,
                IdOficina = Usuario.IdOficina,
                Usuario = Usuario.usuario == null ? Usuario.UsuarioModificacion:Usuario.usuario,
                //FechaCreacion = Usuario.FechaCreacion,
                //UsuarioCreacion = Usuario.UsuarioCreacion,
                //FechaModificacion = Usuario.FechaModificacion,
                //UsuarioModificacion = Usuario.UsuarioModificacion,
                Area = Usuario.Area,
                Cargo = Usuario.Cargo,
                TipoAutenticacion = Usuario.TipoAutenticacion,
                Password = Usuario.Password,
                Habilitado = Usuario.Habilitado
            };
            return sb.CrearActualizarUsuario(Registo);
        }

        public long CambiarEstadoUsuario(string login)
        {
            return sb.CambiarEstadoUsuario(login);
        }
        #endregion

        #region Servicios
        public RespuestaListas<Entidades.Parametrizacion.Servicio> ConsultarTodosServicios(bool incluirNoHab)
        {
            RespuestaListas<Entidades.Parametrizacion.Servicio> Rl = new RespuestaListas<Entidades.Parametrizacion.Servicio>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaLogOfServicioVMyQgq8qZw Todos = sb.ConsultarTodosServicios(incluirNoHab);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                List<WCFBanco.ServicioFachadaOlimpia.ServicioVM> Result = Todos.Lista.ToList();
                Rl.Lista = new List<Entidades.Parametrizacion.Servicio>();
                Result.ForEach(x =>
                    Rl.Lista.Add(new Entidades.Parametrizacion.Servicio
                    {
                        IdServicio = x.IdServicio,
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        Habilitado = x.Habilitado
                    }));
            }
            return Rl;
        }

        public RespuestaListas<Entidades.Parametrizacion.Servicio> ConsultarServicioPorId(int idServicio, bool activo)
        {
            RespuestaListas<Entidades.Parametrizacion.Servicio> Rl = new RespuestaListas<Entidades.Parametrizacion.Servicio>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaEntidadOfServicioVMyQgq8qZw Todos = sb.ConsultarServicioPorId(idServicio, activo);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                WCFBanco.ServicioFachadaOlimpia.ServicioVM Result = Todos.Entidad;
                Rl.Lista.Add(new Entidades.Parametrizacion.Servicio
                {
                    IdServicio = Result.IdServicio,
                    Codigo = Result.Codigo,
                    Descripcion = Result.Descripcion,
                    Habilitado = Result.Habilitado
                });
            }
            return Rl;
        }

        public long CrearActualizarServicio(Entidades.Parametrizacion.Servicio Servicio)
        {
            WCFBanco.ServicioFachadaOlimpia.ServicioVM Registo = new ServicioFachadaOlimpia.ServicioVM()
            {
                IdServicio = Servicio.IdServicio,
                Codigo = Servicio.Codigo,
                Descripcion = Servicio.Descripcion,
                Habilitado = Servicio.Habilitado
            };
            return sb.CrearActualizarServicio(Registo);
        }

        public long CambiarEstadoServicio(int idServicio)
        {
            return sb.CambiarEstadoServicio(idServicio);
        }
        #endregion

        #region Productos
        public RespuestaListas<Producto> ConsultarTodosProductos(bool incluirNoHab)
        {
            RespuestaListas<Producto> Rl = new RespuestaListas<Producto>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaLogOfProductoVMBrCV2MnN Todos = sb.ConsultarTodosProductos(incluirNoHab);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                List<WCFBanco.ServicioFachadaOlimpia.ProductoVM> Result = Todos.Lista.ToList();
                Rl.Lista = new List<Producto>();
                Result.ForEach(x =>
                    Rl.Lista.Add(new Producto
                    {
                        IdProducto = x.IdProducto,
                        IdServicio = x.IdServicio,
                        //TODO: Consultar
                        Servicio = "",
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        Habilitado = x.Habilitado
                    }));
            }
            return Rl;
        }

        public RespuestaListas<Producto> ConsultarProductoPorId(int idServicio, bool activo)
        {
            RespuestaListas<Producto> Rl = new RespuestaListas<Producto>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaEntidadOfProductoVMBrCV2MnN Todos = sb.ConsultarProductoPorId(idServicio, activo);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                WCFBanco.ServicioFachadaOlimpia.ProductoVM Result = Todos.Entidad;
                Rl.Lista.Add(new Producto
                {
                    IdProducto = Result.IdProducto,
                    IdServicio = Result.IdServicio,
                    //TODO: Consultar
                    Servicio = "",
                    Codigo = Result.Codigo,
                    Descripcion = Result.Descripcion,
                    Habilitado = Result.Habilitado
                });
            }
            return Rl;
        }

        public long CrearActualizarProducto(Producto Producto)
        {
            WCFBanco.ServicioFachadaOlimpia.ProductoVM Registo = new ServicioFachadaOlimpia.ProductoVM()
            {
                IdProducto = Producto.IdProducto,
                IdServicio = Producto.IdServicio,
                //Servicio = "",
                Codigo = Producto.Codigo,
                Descripcion = Producto.Descripcion,
                Habilitado = Producto.Habilitado
            };
            return sb.CrearActualizarProducto(Registo);
        }

        public long CambiarEstadoProducto(int idProducto)
        {
            return sb.CambiarEstadoProducto(idProducto);
        }
        #endregion

        #region Parametros
        public RespuestaListas<Parametros> ConsultarTodosParametros(bool incluirNoHab)
        {
            System.Diagnostics.Trace.WriteLine("DFZ780");

            //AutorizacionWA.ValidarAutorizacion(System.ServiceModel.OperationContext.Current.IncomingMessageHeaders.Action, ServiceSecurityContext.Current.WindowsIdentity);


            Parametrizacion p = new Parametrizacion();
            return p.ConsultarTodosParametros(false);

            /*
            RespuestaListas<Parametros> Rl = new RespuestaListas<Parametros>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaLogOfParametroVMrJHE_SDAL Todos = sb.ConsultarTodosParametros();

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                List<WCFBanco.ServicioFachadaOlimpia.ParametroVM> Result = Todos.Lista.ToList();
                Rl.Lista = new List<Parametros>();
                Result.ForEach(x =>
                    Rl.Lista.Add(new Parametros
                    {
                        IdParametro = x.IdParametro,
                        Parametro = x.Codigo,
                        Valor = x.Valor,
                        UsuarioModificacion = x.UsuarioModificacion,
                        FechaModificacion = x.FechaModificacion
                    }));
            }
            return Rl;
             * */
        }

        public RespuestaListas<Parametros> ConsultarParametroPorId(string idParametro)
        {
            RespuestaListas<Parametros> Rl = new RespuestaListas<Parametros>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaEntidadOfParametroVMrJHE_SDAL Todos = sb.ConsultarParametroPorId(idParametro);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                WCFBanco.ServicioFachadaOlimpia.ParametroVM Result = Todos.Entidad;
                Rl.Lista.Add(new Parametros
                {
                    IdParametro = Result.IdParametro,
                    Parametro = Result.Codigo,
                    Valor = Result.Valor,
                    UsuarioModificacion = Result.UsuarioModificacion,
                    FechaModificacion = Result.FechaModificacion
                });
            }
            return Rl;
        }

        public long ActualizarParametro(Parametros Parametros)
        {
            WCFBanco.ServicioFachadaOlimpia.ParametroVM Registo = new ServicioFachadaOlimpia.ParametroVM()
            {
                IdParametro = Parametros.IdParametro,
                Codigo = Parametros.Parametro,
                Valor = Parametros.Valor,
                UsuarioModificacion = Parametros.UsuarioModificacion,
                FechaModificacion = Parametros.FechaModificacion
            };
            var l = sb.ActualizarParametro(Registo);

            try
            {
                ObjectCache Cache = MemoryCache.Default;
                if (Cache.Contains("ListParametros"))
                    Cache.Remove("ListParametros");
            }
            catch
            {
                System.Diagnostics.Trace.WriteLine("RCS1020 EXCEPTION");

            }

            ConsultarTodosParametros(false);
            return l;
        }
        #endregion
    }
}

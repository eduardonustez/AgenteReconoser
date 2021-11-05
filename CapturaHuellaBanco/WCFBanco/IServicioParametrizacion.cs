using Entidades;
using Entidades.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFBanco
{
    [ServiceContract]
    public interface IServicioParametrizacion
    {

        #region Zonas
        [OperationContract(Name = "ConsultarTodosZonas")]
        RespuestaListas<Zona> ConsultarTodosZonas(bool incluirNoHab);

        //[OperationContract(Name = "ConsultarZonaPorId")]
        //RespuestaListas<Zona> ConsultarZonaPorId(string idZona);

        [OperationContract(Name = "CrearActualizarZona")]
        long CrearActualizarZona(Zona Zona);

        //[OperationContract(Name = "EliminarZona")]
        //long EliminarZona(string idZona);
        #endregion

        #region Oficinas
        [OperationContract(Name = "ConsultarTodosOficinas")]
        RespuestaListas<Oficina> ConsultarTodosOficinas(bool incluirNoHab);

        //[OperationContract(Name = "ConsultarOficinaPorId")]
        //RespuestaListas<Oficina> ConsultarOficinaPorId(string idOficina, bool activo);

        [OperationContract(Name = "CrearActualizarOficina")]
        long CrearActualizarOficina(Oficina Oficina);

        [OperationContract(Name = "CambiarEstadoOficina")]
        long CambiarEstadoOficina(string idOficina);
        #endregion

        #region Roles
        [OperationContract(Name = "ConsultarTodosRoles")]
        RespuestaListas<Rol> ConsultarTodosRoles(bool incluirNoHab);

        //[OperationContract(Name = "ConsultarRolPorId")]
        //RespuestaListas<Rol> ConsultarRolPorId(int idRol, bool activo);

        [OperationContract(Name = "CrearActualizarRol")]
        long CrearActualizarRol(Rol Rol);

        [OperationContract(Name = "CambiarEstadoRol")]
        long CambiarEstadoRol(int idRol);
        #endregion

        #region Usuarios
        [OperationContract(Name = "ConsultarTodosUsuarios")]
        RespuestaListas<Usuario> ConsultarTodosUsuarios(bool incluirNoHab);

        //[OperationContract(Name = "ConsultarUsuarioPorId")]
        //RespuestaListas<Usuario> ConsultarUsuarioPorId(string usuario, bool activo);

        [OperationContract(Name = "CrearActualizarUsuario")]
        long CrearActualizarUsuario(Usuario Usuario);

        [OperationContract(Name = "CambiarEstadoUsuario")]
        long CambiarEstadoUsuario(string login);
        #endregion

        #region Servicios
        //[OperationContract(Name = "ConsultarTodosServicios")]
        //RespuestaListas<Entidades.Parametrizacion.Servicio> ConsultarTodosServicios(bool incluirNoHab);

        //[OperationContract(Name = "ConsultarServicioPorId")]
        //RespuestaListas<Entidades.Parametrizacion.Servicio> ConsultarServicioPorId(int idServicio, bool activo);

        //[OperationContract(Name = "CrearActualizarServicio")]
        //long CrearActualizarServicio(Entidades.Parametrizacion.Servicio Servicio);

        //[OperationContract(Name = "CambiarEstadoServicio")]
        //long CambiarEstadoServicio(int idServicio);
        #endregion

        #region Productos
        [OperationContract(Name = "ConsultarTodosProductos")]
        RespuestaListas<Producto> ConsultarTodosProductos(bool incluirNoHab);

        //[OperationContract(Name = "ConsultarProductoPorId")]
        //RespuestaListas<Producto> ConsultarProductoPorId(int idServicio, bool activo);

        [OperationContract(Name = "CrearActualizarProducto")]
        long CrearActualizarProducto(Producto Producto);

        [OperationContract(Name = "CambiarEstadoProducto")]
        long CambiarEstadoProducto(int idProducto);
        #endregion

        #region Parametros
        [OperationContract(Name = "ConsultarTodosParametros")]
        RespuestaListas<Parametros> ConsultarTodosParametros(bool incluirNoHab);

        [OperationContract(Name = "ConsultarParametroPorId")]
        RespuestaListas<Parametros> ConsultarParametroPorId(string idParametro);

        [OperationContract(Name = "ActualizarParametro")]
        long ActualizarParametro(Parametros Parametros);
        #endregion
    }
}
